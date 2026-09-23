using BibleBooksNE.Model.Enums;

namespace BibleBooksNE.Persistency.SQLite
{

    /// <summary>
    /// Make SQL commands for queries
    /// </summary>
    internal class SQL_QueryCommands : SQL_General
    {

        #region Select All commands

        private static string Select(string what, TableName tableName, string condition)
        {
            return string.Format("SELECT {0} FROM {1}{2};", what, tableName, condition);
        }

        private static string Select(string what, TableName tableName)
        {
            return Select(what, tableName, string.Empty);
        }

        private static string SelectAll(TableName tableName) => Select("*", tableName);

        public static string SelectAllBibleInfo => SelectAll(TableName.BibleInfo);
        public static string SelectAllBookNames => SelectAll(TableName.BookNames);
        public static string SelectAllBibleParts => SelectAll(TableName.BibleParts);
        public static string SelectAllChangeLog => SelectAll(TableName.ChangeLog);

        public static string SelectAllVerseType(TableName tableName)
        {
            return SelectAll(tableName);
        }

        #endregion

        #region Counter commands

        public static string CountBibleInfo => Count(TableName.BibleInfo);
        public static string CountBibleParts => Count(TableName.BibleParts);
        public static string CountBookParts => Count(TableName.BookParts);
        public static string CountChapterParts => Count(TableName.ChapterParts);
        public static string CountVerses => Count(TableName.Verses);
        public static string CountBookInfo => Count(TableName.BookNames);
        public static string CountCrosslinks => Count(TableName.CrossReferences);
        public static string CountFootnotes => Count(TableName.Footnotes);
        public static string CountHeadlines => Count(TableName.Headlines);
        public static string CountWordsList => Count(TableName.WordList);
        public static string CountChangeLog => Count(TableName.ChangeLog);


        private static string Count(TableName tableName) => Select("count()", tableName);

        //SELECT book, count(chapter) FROM (SELECT DISTINCT book, chapter FROM Verses) GROUP BY book;
        public static string CountChapterNumbers() => string.Format("SELECT {0}, count({1}) FROM (SELECT DISTINCT {0}, {1} FROM {2}) GROUP BY {0};", VersesFieldNames[0], VersesFieldNames[1], TableName.Verses);
        public static string CountVersesNumbers() => string.Format("SELECT {0}, {1}, count({2}) FROM {3} GROUP BY {0}, {1};", VersesFieldNames[0], VersesFieldNames[1], VersesFieldNames[2], TableName.Verses);

        #endregion

        #region GET methods

        public static string GetBookNumbers() => Select("DISTINCT " + VersesFieldNames[0], TableName.Verses);
        public static string GetChapterNumbers(int book) => Select("DISTINCT " + VersesFieldNames[1], TableName.Verses, MakeConditionPart(book, -1, -1, string.Empty));
        public static string GetVersesNumbers(int book, int chapter) => Select(VersesFieldNames[2], TableName.Verses, MakeConditionPart(book, chapter, -1, string.Empty));

        #endregion

        #region Selections with condition

        public static string SelectWithCondition(TableName tableName, int book, int chapter, int verse)
        {
            return Select("*", tableName, MakeConditionPart(book, chapter, verse, string.Empty));
        }

        private static string MakeConditionPart(int book, int chapter, int verse, string text)
        {
            int[] array = new int[] { book, chapter, verse };
            List<string> list = new();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    string str = VersesFieldNames[i] + " = " + array[i];
                    list.Add(str);
                }
            }
            if (!string.IsNullOrWhiteSpace(text))
            {
                list.Add(string.Format("{0} LIKE '%{1}%'", VersesFieldNames[3], text));
            }
            if (list.Count > 0)
            {
                return " WHERE " + string.Join(" AND ", list);
            }
            return string.Empty;
        }

        #endregion

        #region Search

        /// <summary>
        /// Search the given text, in the given table, in the given book and chapter
        /// </summary>
        /// <param name="searchedText">searched text</param>
        /// <param name="tableName">headline, verse, footnote, wordlist only</param>
        /// <param name="book">book id</param>
        /// <param name="chapter">chapter id</param>
        /// <returns>found results</returns>
        public static string Search(string searchedText, TableName tableName, int book, int chapter, int verse)
        {
            return Select("*", tableName, MakeConditionPart(book, chapter, verse, searchedText));
        }

        #endregion

    }
}