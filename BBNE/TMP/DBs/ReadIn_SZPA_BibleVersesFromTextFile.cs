using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;
using System.Text;
using System.Text.RegularExpressions;

namespace BibleBooksNE.TMP.DBs
{
    internal class ReadIn_SZPA_BibleVersesFromTextFile
    {

        /*
         * \{N} cím             ^\{\d+} .* 
         * # Könyv cím          ^# .* 
         * ## Fejezet szám      ^## .* 
         * ### Címsor           ^### .* 
         * szöveg / verssor     ^.*
        */

        private readonly string BOOKNUMBER_PATERN = "(?<=^\\{)\\d+(?=\\} .*)";
        private readonly string SHORTTITLE_PATERN = "(?<=^\\{\\d+} ).*";
        // private readonly string BOOKTITLE_PATERN = "(?<=^# ).*"; SKIP
        private readonly string CHAPTERNUMBER_PATERN = "(?<=^## )\\d+";
        private readonly string HEADLINE_PATTERN = "(?<=^### ).*";
        private readonly string HEADLINEMSG = "Headlines";
        private readonly string VERSESMSG = "Verses";
        public List<FullIdentifierWithText> _headlineList;
        public List<FullIdentifierWithText> _verseList;

        private readonly int BIBLE = 20;
        private int BookNumber { get; set; }
        private string ShortTitle { get; set; }
        private int ChapterNumber { get; set; }
        private string Headline { get; set; }
        private int VerseNumber { get; set; }

        public ReadIn_SZPA_BibleVersesFromTextFile()
        {
            BookNumber = 0;
            ShortTitle = string.Empty;
            ChapterNumber = 1;
            Headline = string.Empty;
            VerseNumber = 1;
            _headlineList = new List<FullIdentifierWithText>();
            _verseList = new List<FullIdentifierWithText>();
            DirPath = string.Empty;
        }

        public List<FullIdentifierWithText> HeadlineList => _headlineList;
        public List<FullIdentifierWithText> VerseList => _verseList;

        private string FileTail => " - SZPA Biblia.";
        private string FileName(string title) => DirPath + BookNumber + " " + ShortTitle + " " + title + FileTail;
        public string DirPath { get; set; }
        private string TextFileName(string title) => FileName(title) + "txt";
        private string SQLFileName(string title) => FileName(title) + "sql";

        public void Parse(string[] fileLines)
        {
            DirPath = fileLines[0];
            for (int i = 1; i < fileLines.Length; i++)
            {
                ParseLine(fileLines[i]);
            }
        }

        public void ParseLine(string text)
        {
            text = text.TrimEnd();
            if (!string.IsNullOrWhiteSpace(text))
            {
                if (text.StartsWith("{"))
                {
                    ParseBookNumberAndShortTitle(text);
                }
                else
                {
                    if (text.StartsWith("# "))
                    {
                        // Nothing to do!
                    }
                    else
                    {
                        if (text.StartsWith("## "))
                        {
                            ParseChapterNumber(text);
                        }
                        else
                        {
                            if (text.StartsWith("### "))
                            {
                                ParseHeadline(text);
                            }
                            else
                            {
                                ParseVerse(text);
                                if (!string.IsNullOrEmpty(Headline))
                                {
                                    AddHeadlineToList();
                                }
                                VerseNumber++;
                            }
                        }
                    }
                }
            }
        }

        private int ParseNumber(string text, string pattern)
        {
            return int.Parse(ParseString(text, pattern));
        }

        private string ParseString(string text, string pattern)
        {
            return Regex.Match(text, pattern).ToString();
        }

        private void ParseBookNumberAndShortTitle(string text)
        {
            BookNumber = ParseNumber(text, BOOKNUMBER_PATERN);
            ShortTitle = ParseString(text, SHORTTITLE_PATERN);
        }

        private void ParseChapterNumber(string text)
        {
            ChapterNumber = ParseNumber(text, CHAPTERNUMBER_PATERN);
            VerseNumber = 1;
        }

        private void ParseHeadline(string text)
        {
            Headline = ParseString(text, HEADLINE_PATTERN);
        }

        private void ParseVerse(string text)
        {
            VerseList.Add(GetFullIdText(PageOrder.verse_item, text));
        }

        private void AddHeadlineToList()
        {
            HeadlineList.Add(GetFullIdText(PageOrder.headline_title, Headline));
            Headline = string.Empty;
        }

        private FullIdentifierWithText GetFullIdText(PageOrder order, string text)
        {
            return new FullIdentifierWithText(GetFullId(order), text);
        }

        private FullIdentifier GetFullId(PageOrder order)
        {
            return new FullIdentifier(
                    new Identifier(BIBLE),
                    new Identifier(BookNumber),
                    new Identifier(ChapterNumber),
                    new Identifier(VerseNumber),
                    new Identifier(), order);
        }

        public string Help()
        {
            return "HELP\n\n" +
                "Beolvassa a SZPA Biblia Sorait és Átalakítja\n" +
                "Első sor: Könyvtár útvonal: dir\\\n" +
                "A SZPA biblia sorai.\n" +
                "\n TÖRÖLD KI ezt az üzenetet a következő használat előtt!"
                ;
        }

        public string Text_FullName_HEADLINE => TextFileName(HEADLINEMSG);
        public string Text_FullName_VERSES => TextFileName(VERSESMSG);
        public string SQL_FullName_HEADLINE => SQLFileName(HEADLINEMSG);
        public string SQL_FullName_VERSES => SQLFileName(VERSESMSG);

        public string ReturnMsg()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine(DirPath);
            sb.AppendLine(HEADLINEMSG + " List: " + HeadlineList.Count);
            sb.AppendLine(Text_FullName_HEADLINE);
            sb.AppendLine(SQL_FullName_HEADLINE);
            sb.AppendLine(VERSESMSG + " List: " + VerseList.Count);
            sb.AppendLine(Text_FullName_VERSES);
            sb.AppendLine(SQL_FullName_VERSES);
            return sb.ToString();
        }

        public IEnumerable<string> HeadlinesList()
        {
            return GetStringList(HeadlineList);
        }

        public IEnumerable<string> VersesList()
        {
            return GetStringList(VerseList);
        }

        private IEnumerable<string> GetStringList(List<FullIdentifierWithText> list)
        {
            foreach (FullIdentifierWithText item in list)
            {
                yield return item.ToString();
            }
        }

        public string[] SQLCommandHeadlines()
        {
            return SQLInsertIntoCommand(HeadlineList, HEADLINEMSG);
        }

        public string[] SQLCommandVerses()
        {
            return SQLInsertIntoCommand(VerseList, VERSESMSG);
        }

        private string[] SQLInsertIntoCommand(List<FullIdentifierWithText> fullIdentifierWithTexts, string tableName)
        {
            List<string> values = new List<string>();
            foreach (FullIdentifierWithText item in fullIdentifierWithTexts)
            {
                values.Add(InsertIntoValuePart(item));
            }
            return [ "INSERT INTO " + tableName + "(book, chapter, verse, text) VALUES",
                string.Join(",\n", values),
                ";" ];
        }

        private string InsertIntoValuePart(FullIdentifierWithText fullIdentifierWithText)
        {
            return string.Format("({0}, {1}, {2}, '{3}')",
                fullIdentifierWithText.Ids.Book,
                fullIdentifierWithText.Ids.Chapter,
                fullIdentifierWithText.Ids.Verse,
                fullIdentifierWithText.Text
                );
        }
    }
}
