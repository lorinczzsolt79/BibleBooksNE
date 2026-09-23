using System.Collections.Generic;
using System.Linq;

namespace BibleBooksNE.TMP.DBs
{
    internal class ReadIn_BibleVersesFromTextFileExtended : ReadIn_BibleVersesFromTextFile
    {
        protected List<string[]> StringParts { get; set; }

        public ReadIn_BibleVersesFromTextFileExtended()
        {
        }

        protected void SetStringParts(List<string> input)
        {
            StringParts = (from str in input select str.Split('\t')).ToList();
        }

        protected string InsertIntoBookNamesCommand(int id, string shortName, string longName, string dirName)
        {
            // (1, 'GEN', 'Genesis', 'GEN');
            return string.Format("({0}, '{1}', '{2}', '{3}')", id, shortName, longName, dirName);
        }

        protected string StringPartsToInsertIntoCommand(string[] stringParts)
        {
            // Joshua	1	0	Joshua Takes Charge
            return InsertIntoVerseTypeCommandPart(BookNameToNumber(stringParts[0]), stringParts[1], stringParts[2], stringParts[3]);
        }

        #region NAMES

        protected void SetBookNames()
        {
            HashSet<string> bookNames = new HashSet<string>();
            foreach (string[] array in StringParts)
            {
                bookNames.Add(array[0].Trim());
            }
            List<string> result = new List<string>() { string.Empty };      // Add 0. item
            result.AddRange(bookNames);
            BookNames = result.ToArray();
        }

        protected string BookNameToNumber(string bookName)
        {
            for (int i = 0; i < BookNames.Length; i++)
            {
                if (BookNames[i].Equals(bookName))
                {
                    return i.ToString();
                }
            }
            return string.Empty;
        }

        protected string ShortName(int n, bool lower)
        {
            string result = string.Empty;
            result = ShortNames[n];
            if (lower)
            {
                result = result.ToLower();
            }
            return result;
        }

        protected string[] BookNamesToInsertIntoCommand()
        {
            List<string> result = new List<string>();
            for (int i = 1; i < BookNames.Length; i++)
            {
                int n = int.Parse(BookNameToNumber(BookNames[i]));
                result.Add(InsertIntoBookNamesCommand(n, ShortName(n, false), BookNames[i], ShortName(n, true)));
            }
            return new List<string>() {
                "INSERT INTO \"main\".\"BookNames\" (\"id\", \"shortName\", \"longName\", \"dirName\") VALUES\n",
                string.Join(",\n", result), ";" }.ToArray();
        }

        #endregion
    }

}
