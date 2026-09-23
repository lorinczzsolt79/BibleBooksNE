using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleBooksNE.TMP.DBs
{
    internal class ReadIn_Default_BibleVersesFromTextFile : ReadIn_BibleVersesFromTextFileExtended
    {

        public ReadIn_Default_BibleVersesFromTextFile(string fileName)
        {
            FileName = fileName;
        }

        public void Print()
        {
            if (!string.IsNullOrWhiteSpace(FileName))
            {
                FileInfo fi = new FileInfo(FileName);
                Console.WriteLine();
                Console.WriteLine(fi.FullName);
                Console.WriteLine(fi.DirectoryName);
                Console.WriteLine(fi.Name);
                Console.WriteLine(fi.Extension);
                Console.WriteLine();
                Console.WriteLine(TextOutputFileFullName);
                Console.WriteLine(SQLOutputFileFullName);
            }
        }

        public override void Run()
        {
            // REMOVE! first 3 lines
            List<string> fileLines = GetFileLines();
            fileLines.RemoveRange(0, 3);
            // Set verse type line parts
            SetStringParts(fileLines);
            // Extract and save BookNames
            SetBookNames();
            WriteToFile(BookNames, TextOutputFileFullName);

            // SQL Results
            List<string> results = new List<string>();
            // BookNames
            results.AddRange(BookNamesToInsertIntoCommand());
            results.Add(string.Empty);
            // Verses
            results.AddRange(VersesSQLCommand());
            WriteToFile(results.ToArray(), SQLOutputFileFullName);
        }

        private List<string> VersesSQLCommand()
        {
            return new List<string>() {
                "INSERT INTO \"main\".\"Verses\" (\"book\", \"chapter\", \"verse\", \"text\") VALUES\n",
               string.Join(",\n",VersesToInsertIntoCommand()), ";"
                };
        }


        private IEnumerable<string> VersesToInsertIntoCommand()
        {
            foreach (string[] item in StringParts)
            {
                yield return InsertIntoVerseTypeCommandPart(BookNameToNumber(item[0]), item[1], item[2], item[3].Trim());
            }
        }

        private string TextOutputFileFullName => OutputFileName("BookNames", ".txt");
        private string SQLOutputFileFullName => OutputFileName("SQL_Commands", ".sql");

        private string OutputFileName(string header, string ext)
        {
            if (!string.IsNullOrWhiteSpace(FileName))
            {
                FileInfo fi = new FileInfo(FileName);
                int last = fi.Name.LastIndexOf('.');
                return fi.DirectoryName + "\\" + header + " - " + fi.Name.Remove(last, fi.Name.Length - last) + ext;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /* You should create a bible database with unique ids and bible names.      Ready.
         * 
         * Modify Empty database. Drop and Create ChangeLog table      Ready.
         * 
         * Create a new database files.      Ready.
         * Get SQL command.      Ready.
         * Drop BibleInfos table and Create BibleInfo table with its fields      Ready.
         * Insert Into BibleInfo tables the BibleInfo items      Ready.
         * 
         * Verses:
         *      Read in Verses data.
         *      Skip first 3 lines
         *      Make SQL command.
         *      Insert verses Into Verses table.
         * 
         * Names
         *      Get BookLongNames.
         *      Make BookName items
         *      Make SQL command.
         *      Insert names Into BookNames table.
         * 
         */
    }
}
