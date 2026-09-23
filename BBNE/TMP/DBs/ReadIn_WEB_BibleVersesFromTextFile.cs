using BibleBooksNE.Persistency.Files;
using System;
using System.Collections.Generic;

namespace BibleBooksNE.TMP.DBs
{
    internal class ReadIn_WEB_BibleVersesFromTextFile : ReadIn_BibleVersesFromTextFile
    {


        public ReadIn_WEB_BibleVersesFromTextFile(string fileName)
        {
            FileName = fileName;
        }

        public override void Run()
        {
            List<string> input = GetFileLines();
            bool doIt = true;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].Split('\t').Length != 4)
                {
                    doIt = false;
                    Console.WriteLine("Error: " + i + ". line");
                    break;
                }
            }
            if (doIt)
            {
                Convert(input);
            }
        }

        private void Convert(List<string> input)
        {
            List<string> output = new List<string>();
            foreach (string fileLine in input)
            {
                output.Add(LineToSqlCommand(fileLine));
            }
            WriteToSQLFile(new string[] { "INSERT INTO \"main\".\"Verses\" (\"book\", \"chapter\", \"verse\", \"text\") VALUES \n" + string.Join(",\n", output) + "\n;" });
        }


        private string Replacer(string shortName)
        {
            for (int i = 0; i < ShortNames.Length; i++)
            {
                if (shortName.Equals(ShortNames[i]))
                {
                    return i.ToString();
                }
            }
            return string.Empty;
        }

        private string LineToSqlCommand(string fileLine)
        {
            string[] array = fileLine.Split('\t');
            return InsertIntoVerseTypeCommandPart(Replacer(array[0]), array[1], array[2], array[3]);
        }
    }
}
