using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;
using BibleBooksNE.Model.Names;
using BibleBooksNE.Persistency.SQLite;
using BibleBooksNE.Properties;

namespace BibleBooksNE.Model.Database
{

    /// <summary>
    /// It contains the all information about a database.
    /// </summary>
    internal class DatabaseInfo : ValuesToString, IComparable<DatabaseInfo>
    {

        #region General things and Database Information

        private readonly string _fullName;
        private readonly SQLite_DatabaseDataHandler _dbh;

        // Database
        private BibleInfo _info;
        private int _bibleInfo = 0;
        private int _changeLog = 0;
        // Names
        private int _bibleParts = 0;
        private int _bookParts = 0;
        private int _chapterParts = 0;
        private int _bookNames = 0;
        // Verse Type Counters
        private int _verses = 0;
        private int _crosslinks = 0;
        private int _footnotes = 0;
        private int _headlines = 0;
        private int _wordlist = 0;

        public DatabaseInfo(string fullName)
        {
            _fullName = fullName;
            _dbh = new SQLite_DatabaseDataHandler(FullName);
            _info = Dbh.AllBibleInfo[0];    // Get bibleInfo (first only)
            Count();
        }

        /// <summary>
        /// Database info 
        /// </summary>
        public string FullName => _fullName;

        /// <summary>
        /// Database access
        /// </summary>
        private SQLite_DatabaseDataHandler Dbh => _dbh;

        /// <summary>
        /// Bible Information
        /// </summary>
        public BibleInfo Info => _info;

        private void Count()
        {
            // Database
            _bibleInfo = Dbh.CountBibleInfo;
            _changeLog = Dbh.CountChangeLog;
            //Names
            _bookNames = Dbh.CountBookInfo;
            _bibleParts = Dbh.CountBibleParts;
            _bookParts = Dbh.CountBookParts;
            _chapterParts = Dbh.CountChapterParts;
            // Verse Type Counters
            _verses = Dbh.CountVerses;
            _crosslinks = Dbh.CountCrosslinks;
            _footnotes = Dbh.CountFootnotes;
            _headlines = Dbh.CountHeadlines;
            _wordlist = Dbh.CountWordsList;
        }

        #endregion

        #region Values, ToString

        public override string ToString()
        {
            return ToString(Values());
        }

        public override List<KeyValuePair<string, string>> Values()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>() {
                new("#1", Resources.DatabaseInformation),
                new(string.Empty, string.Empty)
            };
            list.AddRange(Info.Values());
            list.Add(new KeyValuePair<string, string>(string.Empty, string.Empty));
            list.Add(new KeyValuePair<string, string>("#2",Resources.Counters));
            list.Add(new KeyValuePair<string, string>(Resources.BibleInformation, BibleInfo.ToString()));
            list.Add(new KeyValuePair<string, string>(Resources.ChangeLog, ChangeLog.ToString()));
            list.Add(new KeyValuePair<string, string>(Resources.BookNames, BookNames.ToString()));
            list.Add(new KeyValuePair<string, string>(Resources.BibleParts, BibleParts.ToString()));
            list.Add(new KeyValuePair<string, string>(Resources.BookParts, BookParts.ToString()));
            list.Add(new KeyValuePair<string, string>(Resources.ChapterParts, ChapterParts.ToString()));
            list.Add(new KeyValuePair<string, string>(Resources.Verses, Verses.ToString()));
            list.Add(new KeyValuePair<string, string>(Resources.Crosslinks, Crosslinks.ToString()));
            list.Add(new KeyValuePair<string, string>(Resources.Footnotes, Footnotes.ToString()));
            list.Add(new KeyValuePair<string, string>(Resources.Headlines, Headlines.ToString()));
            list.Add(new KeyValuePair<string, string>(Resources.WordsList, WordsList.ToString()));
            return list;
        }

        #endregion

        #region Database Statistic Data

        #region Sizes

        /// <summary>
        /// Number of BibleInfo
        /// </summary>
        public int BibleInfo => _bibleInfo;

        /// <summary>
        /// Number of BibleParts
        /// </summary>
        public int BibleParts => _bibleParts;

        /// <summary>
        /// Number of BookParts
        /// </summary>
        public int BookParts => _bookParts;

        /// <summary>
        /// Number of ChapterParts
        /// </summary>
        public int ChapterParts => _chapterParts;

        /// <summary>
        /// Number of Verses
        /// </summary>
        public int Verses => _verses;

        /// <summary>
        /// Number of BookNames
        /// </summary>
        public int BookNames => _bookNames;

        /// <summary>
        /// Number of Crosslinks
        /// </summary>
        public int Crosslinks => _crosslinks;

        /// <summary>
        /// Number of Footnotes
        /// </summary>
        public int Footnotes => _footnotes;

        /// <summary>
        /// Number of Headlines
        /// </summary>
        public int Headlines => _headlines;

        /// <summary>
        /// Number of WordsList
        /// </summary>
        public int WordsList => _wordlist;

        /// <summary>
        /// Number of ChangeLog
        /// </summary>
        public int ChangeLog => _changeLog;

        #endregion

        #region Complex sizes


        /// <summary>
        /// Book and Chapter numbers
        /// </summary>
        public int[][] ChapterNumbers() => Dbh.CountChapterNumbers();

        /// <summary>
        /// Book, Chapter, and Verses numbers
        /// </summary>
        public int[][] VerseNumbers() => Dbh.CountVerseNumbers();

        #endregion

        #endregion

        #region SQL Queries

        #region Get Verse Type Items

        /// <summary>
        /// Get Verse Type Items From Database
        /// </summary>
        /// <param name="fullIds">Identifiers for query</param>
        /// <returns>FullIdsWithText array</returns>
        public FullIdentifierWithText[] GetVerseTypeItems(FullIdentifier fullIds) => Dbh.GetVerseTypeItems(fullIds);

        #endregion

        #region Get Book, Chapter, Verse Numbers

        /// <summary>
        /// Book numbers in Bible
        /// </summary>
        public int[] GetBookNumbers() => Dbh.GetBookNumbers();

        /// <summary>
        /// Chapter numbers in Book
        /// </summary>
        public int[] GetChapterNumbers(int book) => Dbh.GetChapterNumbers(book);

        /// <summary>
        /// Verse numbers in Book and Chapter
        /// </summary>
        public int[] GetVerseNumbers(int book, int chapter) => Dbh.GetVerseNumbers(book, chapter);

        #endregion

        #region Get Bible, Book, Chapter Parts

        #endregion

        #region Get All Book Names

        public Name[] GetAllBookNames() => Dbh.AllBookNames;

        #endregion

        #region Search

        public FullIdentifierWithText[] Search(int bible, int book, int chapter, int verse, string searchedText, PageOrder order)
        {
            return Dbh.Search(bible, book, chapter, verse, searchedText, order);
        }

        public int CompareTo(DatabaseInfo? other)
        {
            int result = 0;
            if (other != null)
            {
                result = Info.BibleId.CompareTo(other.Info.BibleId);
            }
            return result;
        }

        #endregion

        #endregion

    }
}
