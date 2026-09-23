using BibleBooksNE.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BibleBooksNE.Model.Database
{

    internal class DatabaseHandler : ValuesToString
    {
        #region General things

        private readonly DatabaseInfo[] _database = [];

        public DatabaseHandler() { }

        public DatabaseHandler(string[] fullNames)
        {
            _database = ReadDatabaseInfoItems(fullNames);
        }

        private static DatabaseInfo[] ReadDatabaseInfoItems(string[] fullNames)
        {
            Dictionary<int, DatabaseInfo> dbInfo = [];
            foreach (string fullName in fullNames)
            {
                try
                {
                    DatabaseInfo dbi = new(fullName);
                    int key = dbi.Info.BibleId;
                    if (dbInfo.ContainsKey(key))
                    {
                        dbInfo[key] = dbi;
                    }
                    else
                    {
                        dbInfo.Add(key, dbi);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("DatabaseInfo Error" + ex.Message);
                }
            }
            List<DatabaseInfo> dbs = [.. from item in dbInfo.ToList() select item.Value];
            dbs.Sort();
            return dbs.ToArray();
        }

        public DatabaseInfo[] DBs => _database;

        public int Size => _database.Length;

        public DatabaseInfo? GetDatabase(int bibleId)
        {
            DatabaseInfo? db = null;
            if (0 < bibleId)
            {
                foreach (DatabaseInfo database in DBs)
                {
                    if (database.Info.BibleId == bibleId)
                    {
                        db = database;
                    }
                }
            }
            return db;
        }

        public IEnumerable<DatabaseInfo> GetDatabases()
        {
            foreach (DatabaseInfo databaseInfo in DBs)
            {
                yield return databaseInfo;
            }
        }

        public override string ToString()
        {
            return ToString(Values());
        }


        public override List<KeyValuePair<string, string>> Values()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("#0", Resources.Databases),
            };
            foreach (DatabaseInfo item in _database)
            {
                list.Add(new KeyValuePair<string, string>(string.Empty, string.Empty));
                list.AddRange(item.Values());
            }
            return list;
        }

        #endregion

    }
}
