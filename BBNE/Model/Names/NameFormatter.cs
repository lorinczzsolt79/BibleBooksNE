using BibleBooksNE.Model.Database;
using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;

namespace BibleBooksNE.Model.Names
{
    internal class NameFormatter(DatabaseHandler databases)
    {

        #region Genral things

        private readonly DatabaseHandler _dbs = databases;
        private readonly Dictionary<int, NameHandler> _bookNamesDictionary = [];

        #endregion

        #region BibleName Methods

        private IEnumerable<Name> GetBibleNames()
        {
            foreach (DatabaseInfo databaseInfo in _dbs.GetDatabases())
            {
                yield return databaseInfo.Info.BibleNames;
            }
        }

        private NameHandler BibleNameHandler()
        {
            List<Name> array =
            [
                new(),
                .. GetBibleNames(),
            ]; // 0. item
            return new NameHandler([.. array]);
        }

        /// <summary>
        /// Get Numbered Bible Names
        /// </summary>
        /// <param name="bibleId"></param>
        /// <param name="bibleNumbers"></param>
        /// <param name="nameType"></param>
        /// <returns></returns>
        public string[] GetNumberedBibleNames(int[] bibleNumbers, NameType nameType)
        {
            return BibleNameHandler().GetNumberedNames(bibleNumbers, nameType);
        }

        private string GetBibleName(int bibleId, NameType nameType)
        {
            var item = _dbs.GetDatabase(bibleId);
            if (item != null)
            {
                Name name = item.Info.BibleNames;
                return name.GetName(nameType);
            }
            return string.Empty;
        }

        #endregion

        #region BookName methods

        /// <summary>
        /// Number with label: 1. Genesis or Number without label: 1.
        /// </summary>
        /// <param name="databaseNumber">Database id</param>
        /// <param name="numbers">book, chapter, or verse numbers</param>
        /// <param name="nameType">type of label</param>
        /// <returns>array with numbers with labels or without</returns>
        public string[] GetNumberedBookNames(int databaseNumber, int[] numbers, NameType nameType)
        {
            return GetBookName(databaseNumber).GetNumberedNames(numbers, nameType);
        }

        /// <summary>
        /// Get list of Names (0. Bible Name, n. Book Name)
        /// </summary>
        /// <param name="databaseNumber">database number</param>
        /// <returns>BookNames (list of Names)</returns>
        private NameHandler GetBookName(int databaseNumber)
        {
            if (databaseNumber > 0)
            {
                if (!_bookNamesDictionary.ContainsKey(databaseNumber))
                {
                    _bookNamesDictionary.Add(databaseNumber, GetBookNamesFromDatabase(databaseNumber));
                }
                return _bookNamesDictionary[databaseNumber];
            }
            return new NameHandler();
        }


        private NameHandler GetBookNamesFromDatabase(int databaseNumber)
        {
            var item = _dbs.GetDatabase(databaseNumber);
            List<Name> array = new();
            if (item != null)
            {
                array = [new Name(), .. item.GetAllBookNames()];
            }
            return new NameHandler([.. array]);
        }

        #endregion

        #region Formatters

        #region FullIdentifier ToString methods

        /// <summary>
        /// FullIdentifier to string format
        /// </summary>
        /// <param name="fullId">FullIdentifier</param>
        /// <param name="patterns">NameTypes in array (6 NameTypes)</param>
        /// <returns>FullIdentifier as string</returns>
        public string[] GetFormats(FullIdentifier fullId, NameType[] patterns)
        {
            string[] sb = [string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty];
            if (patterns != null && fullId != null)
            {
                if (patterns.Length > 0)
                {
                    if (fullId.Bible.N > 0)
                    {
                        sb[0] = GetStringFormat(fullId.Bible, fullId.Bible, true, patterns[0]);
                    }
                }
                if (patterns.Length > 1)
                {
                    sb[1] = GetStringFormat(fullId.Bible, fullId.Book, false, patterns[1]);
                }
                if (patterns.Length > 2)
                {
                    sb[2] = GetStringFormat(fullId.Bible, fullId.Chapter, false, patterns[2]);
                }
                if (patterns.Length > 3)
                {
                    sb[3] = GetStringFormat(fullId.Bible, fullId.Verse, false, patterns[3]);
                }
                if (patterns.Length > 4)
                {
                    sb[4] = GetStringFormat(fullId.Bible, fullId.Number, false, patterns[4]);
                }
                if (patterns.Length > 5)
                {
                    sb[5] = GetStringFormat(fullId.Bible, fullId.Type, false, patterns[5]);
                }
            }
            return [.. sb];
        }

        private string GetStringFormat(Identifier bible, Identifier id, bool isBible, NameType nameType) // or Identifier id?
        {
            switch (nameType)
            {
                /* *************** Identifier format */
                case NameType.number:
                case NameType.number_with_separator:
                case NameType.formatted_number:
                case NameType.formatted_number_with_separator:
                    {
                        return id.ToString(nameType);
                    }
                /* **************** Name format */
                case NameType.short_name:
                case NameType.long_name:
                case NameType.directory_name:
                case NameType.short_name_with_separator:
                case NameType.long_name_with_separator:
                case NameType.directory_name_with_separator:
                    {
                        return GetName(bible, id, isBible, nameType);
                    }
                default: return string.Empty;
            }
        }

        private string GetName(Identifier bible, Identifier id, bool isBible, NameType nameType)
        {
            if (isBible)
            {
                return GetBibleName(bible.N, nameType);
            }
            else
            {
                return GetBookName(bible.N).Name(id.N, nameType);
            }
        }

        #endregion

        #region FullIdentifier ToString

        public string FourFormattedNumbers(FullIdentifier fullId) => string.Join("", GetFormats(fullId, NameTypePattern.FourFormattedNumbers));
        public string SixFormattedNumbers(FullIdentifier fullId) => string.Join("", GetFormats(fullId, NameTypePattern.SixFormattedNumbers));
        public string SeparatedSixFormattedNumbers(FullIdentifier fullId) => string.Join("", GetFormats(fullId, NameTypePattern.FormattedNumbersWithSeparator));

        public string ShortBibleNameShortBookNameChapterNumberVerseNumber(FullIdentifier fullId) => string.Join("", GetFormats(fullId, NameTypePattern.ShortBibleNameShortBookNameChapterNumberVerseNumber));
        public string ShortBibleNameShortBookNameChapterNumber(FullIdentifier fullId) => string.Join("", GetFormats(fullId, NameTypePattern.ShortBibleNameShortBookNameChapterNumber));
        public string LongBibleNameLongBookNameChapterNumber(FullIdentifier fullId) => string.Join(" / ", GetFormats(fullId, NameTypePattern.LongBibleNameLongBookNameChapterNumber), 0, 3);

        public string ShortBibleNameOnly(FullIdentifier fullId) => string.Join("", GetFormats(fullId, NameTypePattern.ShortBibleNameOnly));
        public string ShortBibleNameBookNumber(FullIdentifier fullId) => string.Join("", GetFormats(fullId, NameTypePattern.ShortBibleNameBookNumber));
        public string ShortBibleNameBookNumberChapterNumber(FullIdentifier fullId) => string.Join("", GetFormats(fullId, NameTypePattern.ShortBibleNameBookNumberChapterNumber));
        public string ShortBibleNameBookChapterVerseNumbers(FullIdentifier fullId) => string.Join("", GetFormats(fullId, NameTypePattern.ShortBibleNameBookNumberChapterNumberVerseNumber));
        public string ShortBookNameChapterVerseNumbers(FullIdentifier fullId) => string.Join("", GetFormats(fullId, NameTypePattern.ShortBookNameChapterVerseNumbers));

        public string FourNumberWithSeparator(FullIdentifier fullId) => string.Join("", GetFormats(fullId, NameTypePattern.FourNumberWithSeparator));
        #endregion

        #region String to FullIdentifier

        ///// <summary>
        ///// From string to FullIdentifier
        ///// </summary>
        ///// <param name="fullId">FullIdentifier string</param>
        ///// <param name="patterns">NameTypes in array</param>
        ///// <returns>new FullIdentifier</returns>
        //public FullIdentifier TryParse(string fullId, NameType[] patterns)
        //{
        //    if (patterns != null && patterns.Length > 0)
        //    {
        //        // Search among short bible and book names
        //        /* 1st step: try parse bible name.
        //         * 2nd step: try parse book name
        //         * Try parse other ids.
        //         */
        //        /* switch(NameType)
        //            none,
        //         **************** Identifier format
        //            number,
        //            number_with_separator,
        //            formatted_number,
        //            formatted_number_with_separator,
        //         **************** Name format
        //            short_name,
        //            long_name,
        //            directory_name
        //            short_name_with_separator,
        //            long_name_with_separator,
        //            directory_name_with_separator
        //         */
        //    }
        //    return null;
        //}

        #endregion

        #endregion
    }
}