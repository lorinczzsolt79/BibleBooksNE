using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BibleBooksNE.TMP.DBs
{
    internal class ReadIn_BRB_BibleVersesFromTextFile : ReadIn_BibleVersesFromTextFileExtended
    {

        public ReadIn_BRB_BibleVersesFromTextFile()
        {
        }
        
        public override void Run()
        {
            ChapterHeadLinesToInsertIntoCommand(@"E:\Win10\Desktop\internet\downloads\Downloaded 20251220\Bible text files\third\BRB Chapter Headlines.txt");
            BookNamesToInsertIntoCommandAndWriteToFile();
            VersesToInsertIntoCommand(@"E:\Win10\Desktop\internet\downloads\Downloaded 20251220\Bible text files\third\brb.txt");
        }

        private void VersesToInsertIntoCommand(string fileName)
        {
            FileName = fileName;
            /* Bible Short Name
             * Bible Long Name
             * Bible Description
             * If line starts with # => Title
             *      get lines while not starts with # 
             *      and add lines to list.
             *      Add list to Verses
             */
            List<TitleVerses> list = new List<TitleVerses>();
            List<string> fileLines = GetFileLines();
            int counter = -1;
            for (int i = 3; i < fileLines.Count; i++)
            {
                if (fileLines[i].StartsWith("#"))
                {
                    string[] _titleParts = fileLines[i].Substring(2).Split('\t');
                    list.Add(new TitleVerses(BookNameToNumber(_titleParts[0]), _titleParts[1]));
                    counter++;
                }
                else
                {
                    list[counter].Add(fileLines[i]);
                }
            }
            WriteToSQLFile(new List<string>() {
                "INSERT INTO \"main\".\"Verses\" (\"book\", \"chapter\", \"verse\", \"text\") VALUES\n",
               string.Join(",\n", (from item in list select item.ToString()).ToList()), ";" }.ToArray());
        }

        #region TitleVerses

        struct TitleVerses
        {
            public TitleVerses(string book, string chapter)
            {
                Book = book;
                Chapter = chapter;
                Verses = new List<string>();
            }
            public string Book { get; set; }
            public string Chapter { get; set; }
            public List<string> Verses { get; set; }
            public void Add(string item) => Verses.Add(item);

            override
            public string ToString()
            {
                List<string> result = new List<string>();
                for (int i = 1; i < Verses.Count; i++)
                {
                    result.Add(InsertIntoVerseTypeCommandPart(Book, Chapter, i.ToString(), Verses[i].Trim())); 
                }
                return string.Join(",\n", result);
            }
        }

        #endregion

        #region Chapter

        private void ChapterHeadLinesToInsertIntoCommand(string fileName)
        {
            FileName = fileName;
            SetStringParts(GetFileLines());
            SetBookNames();
            List<string> result = new List<string>();
            foreach (string[] item in StringParts)
            {
                result.Add(StringPartsToInsertIntoCommand(item));
            }
            WriteToSQLFile(new List<string>() {
                "INSERT INTO \"main\".\"Headlines\" (\"book\", \"chapter\", \"verse\", \"text\") VALUES\n",
                string.Join(",\n", result), ";" }.ToArray());

        }

        #endregion

        #region BookNames

        protected void BookNamesToInsertIntoCommandAndWriteToFile()
        {
            string fileName = new FileInfo(FileName).DirectoryName + "\\Names";
            FileName = fileName;
            WriteToSQLFile(BookNamesToInsertIntoCommand());
        }

        #endregion

    }

}
