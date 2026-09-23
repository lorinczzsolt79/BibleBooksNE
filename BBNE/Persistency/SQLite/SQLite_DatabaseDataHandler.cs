using BibleBooksNE.Model;
using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;
using BibleBooksNE.Model.Names;
using BibleBooksNE.Model.VerseTypes;
using Microsoft.Data.Sqlite;
using static BibleBooksNE.Persistency.SQLite.SQL_General;

namespace BibleBooksNE.Persistency.SQLite
{

    /// <summary>
    /// Read data from database
    /// </summary>
    internal class SQLite_DatabaseDataHandler(string databaseFullName) : SQLite_DatabaseConnection(databaseFullName)
    {

        #region Read all data

        public BibleInfo[] AllBibleInfo => QueryCommand(SQL_QueryCommands.SelectAllBibleInfo, BibleInfoFunc);
        public Name[] AllBookNames => QueryCommand(SQL_QueryCommands.SelectAllBookNames, BookNameFunc);
        public ChangeLog[] AllChangeLog => QueryCommand(SQL_QueryCommands.SelectAllChangeLog, ChangeLogFunc);

        public FullIdentifierWithText[] AllVerseTypeItems(int bible, PageOrder pageOrder)
        {
            return [.. from rersult
                    in QueryCommand(SQL_QueryCommands.SelectAllVerseType(ToTableName(pageOrder)), VerseTypeReaderFunc).ToList()
                    select rersult.FullIdsWithText(bible, pageOrder)];
        }

        private VerseTypeResults VerseTypeReaderFunc(SqliteDataReader sqLiteDataReader)
        {
            int value0 = sqLiteDataReader.GetInt32(0);       //  book id
            int value1 = sqLiteDataReader.GetInt32(1);       //  chapter id
            int value2 = sqLiteDataReader.GetInt32(2);       //  verse id
            if (sqLiteDataReader.FieldCount == 4)
            {
                return new VerseTypeResults(value0, value1, value2, sqLiteDataReader.GetString(3));
            }
            if (sqLiteDataReader.FieldCount == 5)
            {
                return new VerseTypeResults(value0, value1, value2, sqLiteDataReader.GetInt32(3), sqLiteDataReader.GetString(4));
            }
            return null;
        }

        #endregion

        #region Functions for Read all data section

        private BibleInfo BibleInfoFunc(SqliteDataReader sqLiteDataReader)
        {
            return new BibleInfo(
                sqLiteDataReader.GetInt32(0),      //  bibleId
                sqLiteDataReader.GetString(1),     //  shortName
                sqLiteDataReader.GetString(2),     //  longName
                sqLiteDataReader.GetString(3),     //  dirName
                sqLiteDataReader.GetString(4),     //  language
                sqLiteDataReader.GetString(5),     //  description
                sqLiteDataReader.GetString(6),     //  url
                sqLiteDataReader.GetString(7),      //  version
                sqLiteDataReader.GetString(8),      //  type
                sqLiteDataReader.GetString(9)      //  copyright
                );
        }

        private Name BookNameFunc(SqliteDataReader sqLiteDataReader)
        {
            return new Name(
                        sqLiteDataReader.GetInt32(0),   //  id
                        sqLiteDataReader.GetString(1),  //  shortName
                        sqLiteDataReader.GetString(2),  //  longName
                        sqLiteDataReader.GetString(3)   //  dirName
                        );
        }

        private ChangeLog ChangeLogFunc(SqliteDataReader sqLiteDataReader)
        {
            return new ChangeLog(
                            sqLiteDataReader.GetInt32(0),       //  ChangeLog id
                            sqLiteDataReader.GetString(1),     //  date
                            sqLiteDataReader.GetString(2)      //  text
                        );
        }

        #endregion

        #region Counters

        public int CountVerses => Counter(SQL_QueryCommands.CountVerses);
        public int CountBibleInfo => Counter(SQL_QueryCommands.CountBibleInfo);
        public int CountBibleParts => Counter(SQL_QueryCommands.CountBibleParts);
        public int CountBookParts => Counter(SQL_QueryCommands.CountBookParts);
        public int CountChapterParts => Counter(SQL_QueryCommands.CountChapterParts);
        public int CountBookInfo => Counter(SQL_QueryCommands.CountBookInfo);
        public int CountCrosslinks => Counter(SQL_QueryCommands.CountCrosslinks);
        public int CountFootnotes => Counter(SQL_QueryCommands.CountFootnotes);
        public int CountHeadlines => Counter(SQL_QueryCommands.CountHeadlines);
        public int CountWordsList => Counter(SQL_QueryCommands.CountWordsList);
        public int CountChangeLog => Counter(SQL_QueryCommands.CountChangeLog);

        public int[][] CountChapterNumbers() => QueryCommand(SQL_QueryCommands.CountChapterNumbers(), CountDualFunc);  // Books, Chapters
        public int[][] CountVerseNumbers() => QueryCommand(SQL_QueryCommands.CountVersesNumbers(), CountTripleFunc);  // Books, Chapters, Verses

        #endregion

        #region Functions for Counters

        private int Counter(string countCommand)
        {
            return QueryCommand(countCommand, CountFunc)[0];
        }

        private int CountFunc(SqliteDataReader sqLiteDataReader)
        {
            return sqLiteDataReader.GetInt32(0);
        }

        private int[] CountDualFunc(SqliteDataReader sqLiteDataReader)
        {
            return [
                sqLiteDataReader.GetInt32(0),
                sqLiteDataReader.GetInt32(1),
            ];
        }

        private int[] CountTripleFunc(SqliteDataReader sqLiteDataReader)
        {
            return [
                sqLiteDataReader.GetInt32(0),
                sqLiteDataReader.GetInt32(1),
                sqLiteDataReader.GetInt32(2)
            ];
        }

        #endregion

        #region Getters

        public FullIdentifierWithText[] GetVerseTypeItems(FullIdentifier fullIds)
        {
            PageOrder pageOrder = (PageOrder)fullIds.Type.N;
            return (from result
                    in QueryCommand(SQL_QueryCommands.SelectWithCondition(ToTableName(pageOrder),
                                    fullIds.Book.N, fullIds.Chapter.N, fullIds.Verse.N),
                                    VerseTypeReaderFunc).ToList()
                    select result.FullIdsWithText(fullIds.Bible.N, pageOrder)).ToArray();
        }

        public int[] GetBookNumbers() => QueryCommand(SQL_QueryCommands.GetBookNumbers(), CountFunc);
        public int[] GetChapterNumbers(int book) => QueryCommand(SQL_QueryCommands.GetChapterNumbers(book), CountFunc);
        public int[] GetVerseNumbers(int book, int chapter) => QueryCommand(SQL_QueryCommands.GetVersesNumbers(book, chapter), CountFunc);

        #endregion

        #region NonQueryCommands

        private int[] Execute(TableName tableName, FullIdentifierWithText[] values, NonQuerySqlCommand sqlCommand)
        {
            if (IsVerseType(tableName))
            {
                List<string> commands = [];
                foreach (FullIdentifierWithText item in values)
                {
                    commands.Add(SqlCommand(tableName, item, sqlCommand));
                }
                return NonQueryCommand(commands.ToArray());
            }
            return [];
        }

        private static string SqlCommand(TableName tableName, FullIdentifierWithText item, NonQuerySqlCommand sqlCommand)
        {
            switch (sqlCommand)
            {
                case NonQuerySqlCommand.INSERT:
                    return SQL_NonQueryCommands.Insert(tableName,
                                                    item.Ids.Book.N, item.Ids.Chapter.N, item.Ids.Verse.N,
                                                    item.Text);
                case NonQuerySqlCommand.UPDATE:
                    return SQL_NonQueryCommands.Update(tableName, item.Text,
                                                    item.Ids.Book.N, item.Ids.Chapter.N, item.Ids.Verse.N);
                case NonQuerySqlCommand.DELETE:
                    return SQL_NonQueryCommands.Delete(tableName,
                                                    item.Ids.Book.N, item.Ids.Chapter.N, item.Ids.Verse.N);
                default: throw new ArgumentException();
            }
        }

        private static bool IsVerseType(TableName tableName)
        {
            switch (tableName)
            {
                case TableName.Headlines:
                case TableName.Verses:
                case TableName.CrossReferences:
                case TableName.WordList: return true;
                default: return false;
            }
        }

        #region Insert

        public void Insert(PageOrder pageOrder, int book, int chapter, int verse, string text)
        {
            NonQueryCommand(SQL_NonQueryCommands.Insert(ToTableName(pageOrder), book, chapter, verse, text));
        }

        public void Insert(PageOrder pageOrder, FullIdentifierWithText value) => Insert(pageOrder, [value]);
        public void Insert(PageOrder pageOrder, FullIdentifierWithText[] values) => Execute(ToTableName(pageOrder), values, NonQuerySqlCommand.INSERT);

        #endregion

        #region Update

        public void Update(PageOrder pageOrder, string text, int book, int chapter, int verse)
        {
            NonQueryCommand(SQL_NonQueryCommands.Update(ToTableName(pageOrder), text, book, chapter, verse));
        }

        public void Update(PageOrder pageOrder, FullIdentifierWithText value) => Update(pageOrder, [value]);
        public void Update(PageOrder pageOrder, FullIdentifierWithText[] values) => Execute(ToTableName(pageOrder), values, NonQuerySqlCommand.UPDATE);

        #endregion

        #region Delete

        public void Delete(PageOrder pageOrder, int book, int chapter, int verse)
        {
            NonQueryCommand(SQL_NonQueryCommands.Delete(ToTableName(pageOrder), book, chapter, verse));
        }

        public void Delete(PageOrder pageOrder, FullIdentifierWithText  value) => Delete(pageOrder, [value]);
        public void Delete(PageOrder pageOrder, FullIdentifierWithText[] values) => Execute(ToTableName(pageOrder), values, NonQuerySqlCommand.DELETE);

        #endregion

        #endregion

        #region Search

        public FullIdentifierWithText[] Search(int bible, int book, int chapter, int verse, string searchedText, PageOrder order)
        {
            return [.. (from result in QueryCommand(
                SQL_QueryCommands.Search(searchedText, ToTableName(order), book, chapter, verse), VerseTypeReaderFunc).ToList()
                    select result.FullIdsWithText(bible, order))];
        }


        #endregion
        
        #region TablName and PageOrder

        public static PageOrder ToPageOrder(TableName tableName)
        {
            return tableName switch
            {
                TableName.Headlines => PageOrder.headline_title,
                TableName.Verses => PageOrder.verse_item,
                TableName.CrossReferences => PageOrder.crosslink_item,
                TableName.Footnotes => PageOrder.footnote,
                TableName.WordList => PageOrder.wordlist,
                _ => PageOrder.unknown
            };

        }

        public static TableName ToTableName(PageOrder pageOrder)
        {
            return pageOrder switch
            {
                PageOrder.headline_title => TableName.Headlines,
                PageOrder.verse_item => TableName.Verses,
                PageOrder.crosslink_item => TableName.CrossReferences,
                PageOrder.footnote => TableName.Footnotes,
                PageOrder.wordlist => TableName.WordList,
                _ => throw new Exception("Conversion error: PageOrder to TableName")
            };
        }

        #endregion
    }
}
