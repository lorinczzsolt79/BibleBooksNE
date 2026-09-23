using BibleBooksNE.Properties;
using BibleBooksNE.ViewAndController;
using Microsoft.Data.Sqlite;

namespace BibleBooksNE.Persistency.SQLite
{
    internal class SQLite_DatabaseConnection
    {

        #region General things

        private readonly string _databaseName = "database";
        private readonly int _version = 3;
        private readonly bool _isNew = true;
        private readonly bool _compress = true;
        private readonly bool _encoding = true;
        private SqliteConnection _sqLite_connection = new();

        public SQLite_DatabaseConnection(string databaseName)
        {
            if (!string.IsNullOrWhiteSpace(databaseName))
            {
                if (new FileInfo(databaseName).Exists)
                {
                    _databaseName = databaseName;
                }
            }
            else
            {
                throw new ArgumentException(Resources.MissingDatabaseNameError + ": " + databaseName);
            }
        }

        public string DataBaseName => _databaseName;
        public int Version => _version;
        public bool IsNew => _isNew;
        public bool Compress => _compress;
        public bool Encoding => _encoding;

        #endregion

        #region Connection methods

        private string ConnectionParam()
        {
            string parameter = string.Format("Data Source = {0}; ; Mode=ReadOnly; Cache=Shared;", DataBaseName);
            return parameter;
        }

        /// <summary>
        /// Create Connection
        /// </summary>
        /// <returns>SQLiteConnection obj</returns>
        private SqliteConnection CreateConnection()
        {
            // Create a new database connection:
            try
            {
                _sqLite_connection = new SqliteConnection(ConnectionParam());
            }
            catch (Exception ex)
            {
                Msg.Error(ex.Message);
            }
            // Open the connection:
            try
            {
                _sqLite_connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to open db!\n" + ex.Message);
            }
            return _sqLite_connection;
        }

        /// <summary>
        /// Close Connection
        /// </summary>
        private void CloseConnection() => _sqLite_connection.Close();

        /// <summary>
        /// Make command
        /// </summary>
        /// <param name="sqlCommand">command text</param>
        /// <returns>SQLiteCommand</returns>
        private SqliteCommand Command(string sqlCommand)
        {
            SqliteCommand sqLite_cmd = CreateConnection().CreateCommand();
            sqLite_cmd.CommandText = sqlCommand;
            return sqLite_cmd;
        }

        #endregion

        #region Queries

        public int NonQueryCommand(string sqlCommand)
        {
            // create:  "CREATE TABLE IF NOT EXISTS SampleTable (Col1 VARCHAR(20), Col2 INT)";
            // insert:  "INSERT INTO SampleTable (Col1, Col2) VALUES('Test1 Text1 ', 1); "
            // update:  "UPDATE ??? TEST"
            CreateConnection();
            int i = Command(sqlCommand).ExecuteNonQuery();
            //Console.WriteLine($"{Resources.TheNumberOfRowsInserted_UpdatedAffectedByIt}: {i}");
            CloseConnection();
            return i;
        }

        public int[] NonQueryCommand(string[] sqlCommand)
        {
            CreateConnection();
            List<int> list = [];
            for (int i = 0; i < sqlCommand.Length; i++)
            {
                list.Add(Command(sqlCommand[i]).ExecuteNonQuery());
            }
            CloseConnection();
            return [.. list];
        }

        /// <summary>
        /// Connection with the database and run the query command
        /// </summary>
        /// <typeparam name="T">type of class?</typeparam>
        /// <param name="sqlCommand">SQL command text</param>
        /// <param name="func">data conversion function</param>
        /// <returns>T array</returns>
        /// <exception cref="Exception">Database Reading Error and Conversion Error</exception>
        public T[] QueryCommand<T>(string sqlCommand, Func<SqliteDataReader, T> func)
        {
            List<T> list = [];
            // Create Connection and Open database
            CreateConnection();
            // Data Reader with SQL command
            SqliteDataReader sqLiteDataReader = Command(sqlCommand).ExecuteReader();
            // return values
            try
            {
                // Reading from database
                while (sqLiteDataReader.Read())
                {
                    // Convert data and add to list
                    list.Add(func(sqLiteDataReader));
                }
            }
            catch { throw new Exception(Resources.DatabaseReadingError); }
            finally
            {
                // Close database and connection
                sqLiteDataReader.Close();
                CloseConnection();
            }
            return [.. list];
        }

        #endregion
    }
}

