using BibleBooksNE.Persistency.Files;
using System.Collections.Generic;

namespace BibleBooksNE.TMP.DBs
{
    internal class ReadIn_BibleVersesFromTextFile
    {

        protected string FileName { get; set; }
        protected string[] BookNames;

        protected readonly string[] ShortNames = new string[] {
            "",
            "GEN",
            "EXO",
            "LEV",
            "NUM",
            "DEU",
            "JOS",
            "JDG",
            "RUT",
            "1SA",
            "2SA",
            "1KI",
            "2KI",
            "1CH",
            "2CH",
            "EZR",
            "NEH",
            "EST",
            "JOB",
            "PSA",
            "PRO",
            "ECC",
            "SNG",
            "ISA",
            "JER",
            "LAM",
            "EZK",
            "DAN",
            "HOS",
            "JOL",
            "AMO",
            "OBA",
            "JON",
            "MIC",
            "NAM",
            "HAB",
            "ZEP",
            "HAG",
            "ZEC",
            "MAL",
            "MAT",
            "MRK",
            "LUK",
            "JHN",
            "ACT",
            "ROM",
            "1CO",
            "2CO",
            "GAL",
            "EPH",
            "PHP",
            "COL",
            "1TH",
            "2TH",
            "1TI",
            "2TI",
            "TIT",
            "PHM",
            "HEB",
            "JAS",
            "1PE",
            "2PE",
            "1JN",
            "2JN",
            "3JN",
            "JUD",
            "REV",
            "TOB",
            "JDT",
            "ESG",
            "WIS",
            "SIR",
            "BAR",
            "1MA",
            "2MA",
            "1ES",
            "MAN",
            "PS2",
            "3MA",
            "2ES",
            "4MA",
            "DAG"
        };

        public ReadIn_BibleVersesFromTextFile()
        {
        }

        public virtual void Run()
        {

        }

        protected List<string> GetFileLines()
        {
            return FileIO.ReadFromFile(FileName);
        }

        protected void WriteToSQLFile(string[] fileLines)
        {
            WriteToFile(fileLines, FileName + ".sql");
        }

        protected static void WriteToFile(string[] fileLines, string fullName)
        {
            FileIO.WriteToFile(fullName, fileLines);
        }

        protected static string InsertIntoVerseTypeCommandPart(string book, string chapter, string verse, string text)
        {
            //  (19, 119, 1, 'ALEPH');
            return string.Format("({0}, {1}, {2}, '{3}')", book, chapter, verse, text);
        }

    }

}
