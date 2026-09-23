using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Other;

namespace BibleBooksNE.Persistency.SQLite
{
    internal class SQL_General
    {
        public enum NonQuerySqlCommand
        {
            INSERT,
            UPDATE,
            DELETE            
        }


        public static string AsFieldsList(string[] fields) => string.Join( ", " , fields);

        #region Verses field type

        public static string[] VersesFieldNames => new string[] {
            "book",
            "chapter",
            "verse",
            "text"
        };
        public static string[] CrosslinksFields => VersesFieldNames;
        public static string[] HeadlinesFields => VersesFieldNames;
        public static string[] WordsListFields => VersesFieldNames;

        #endregion

        #region Footnotes field type

        public static string[] FootnotesFields => new string[] {
            "book",
            "chapter",
            "verse",
            "number",
            "text"
        };

        public static string[] BiblePartsFields => FootnotesFields;
        public static string[] BookPartsFields => FootnotesFields;
        public static string[] ChapterPartsFields => FootnotesFields;

        #endregion

        #region Different field type

        public static string[] BibleInfoFields => new string[] {
            "shortName",
            "longName",
            "dirName",
            "bible_id",
            "language",
            "description",
            "url",
            "version",
            "type",
            "copyright"
        };

        public static string[] BookNamesFields => new string[] {
            "id",
            "shortName",
            "longName",
            "dirName"
        };

        public static string[] ChangeLogFields => new string[] {
            "id",
            "date",
            "entry"
        };

        #endregion

    }
}