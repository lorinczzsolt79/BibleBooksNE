using BibleBooksNE.Model.Enums;
using static BibleBooksNE.Persistency.SQLite.SQL_General;

namespace BibleBooksNE.Persistency.SQLite
{
    internal class SQL_NonQueryCommands
    {
        #region INSERT

        public static string Insert(TableName tableName, int book, int chapter, int verse, string text)
        {
            return string.Format("INSERT INTO {0} ({1}, {2}, {3}, {4}) VALUES ('{5}','{6}','{7}','{8}');", tableName.ToString(),
                VersesFieldNames[0], VersesFieldNames[1], VersesFieldNames[2], VersesFieldNames[3],
                book.ToString(), chapter.ToString(), verse.ToString(), text);
        }

        #endregion

        #region UPDATE

        public static string Update(TableName tableName, string text, int book, int chapter, int verse)
        {
            return Update(tableName, text, string.Format("{0} = {1} AND {2} = {3} AND {4} = {5}",
                VersesFieldNames[0], book.ToString(), VersesFieldNames[1], chapter.ToString(), VersesFieldNames[2], verse.ToString()));
        }

        private static string Update(TableName tableName, string text, string condition)
        {
            return string.Format("UPDATE {0} SET {1} = '{2}' WHERE {3};", tableName.ToString(), VersesFieldNames[3] , text, condition);
        }

        #endregion

        #region DELETE

        public static string Delete(TableName tableName, int book, int chapter, int verse)
        {
            return Delete(tableName, string.Format("{0} = {1} AND {2} = {3} AND {4} = {5}",
                VersesFieldNames[0], book.ToString(), VersesFieldNames[1], chapter.ToString(), VersesFieldNames[2], verse.ToString()));
        }

        private static string Delete(TableName tableName, string condition)
        {
            return string.Format("DELETE FROM {0} WHERE {1};", tableName.ToString(), condition);
        }

        #endregion
    }
}
