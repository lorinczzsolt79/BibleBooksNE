using BibleBooksNE.Model.Database;
using BibleBooksNE.Persistency.Files;
using BibleBooksNE.Properties;
using BibleBooksNE.ViewAndController;

namespace BibleBooksNE.Persistency.SQLite
{
    /// <summary>
    /// Get databases and information about them
    /// </summary>
    internal class DatabaseStart
    {
        public DatabaseStart()
        {
            DatabaseFullNames = [];
        }
        public List<string> DatabaseFullNames { get; }

        public DatabaseHandler GetDatabases()
        {
            return new DatabaseHandler(GetDatabaseFullNames());
        }

        private string[] GetDatabaseFullNames()
        {
            foreach (string path in ProgramDirectories.DatabaseDirectories())
            {
                if (new DirectoryInfo(path).Exists)
                {
                    DatabaseFullNames.AddRange(new Directories().AllFilesByExtFromDirAndSubDir(path, FileIO.Ext(FileIO.FileType.db)));
                }
                //else
                //{
                //    Msg.Error($"{Resources.DatabaseSubDirNotExist}\n\t{path}");
                //}
            }
            return [.. DatabaseFullNames];
        }

    }
}
