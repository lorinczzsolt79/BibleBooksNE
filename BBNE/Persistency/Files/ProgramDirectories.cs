using BibleBooksNE.Model;
using BibleBooksNE.Model.Other;
using BibleBooksNE.Properties;

namespace BibleBooksNE.Persistency.Files
{

    internal class ProgramDirectories : ValuesToString
    {

        /* Type
         *      Name                                    Example
         *
         * User directories
         *
         *      User's Documents:                       C:\Users\me\Documents
         *
         * Windows directories
         *
         *      Program Data Directory:                 C:\ProgramData
         *      Base Directory:                         C:\ProgramFiles
         * 
         * Default Program Directories
         *
         *      Default Home Directory:                 C:\ProgramFiles
         *      Default Program Home Directory:         C:\ProgramFiles\BibleBooksNE
         *      Default Database Directory:             C:\ProgramFiles\BibleBooksNE\Database
         *      Default Resources Directory:            C:\ProgramFiles\BibleBooksNE\Resources
         * 
         * Alternative Program Directories
         *      
         *      Alternative Home Directory:             C:\ProgramData
         *      Alternative Program Home Directory:     C:\ProgramData\BibleBooksNE
         *      Alternative Database Directory:         C:\ProgramData\BibleBooksNE\Database
         *      Alternative Resources Directory:        C:\ProgramData\BibleBooksNE\Resources
         *      
         * User's Program Directories
         * 
         *      User's Home Directory:                  C:\Users\me\Documents
         *      User's Program Home Directory:          C:\Users\me\Documents\BibleBooksNE
         *      User's Database Directory:              C:\Users\me\Documents\BibleBooksNE\Database
         *      User's Resources Directory:             C:\Users\me\Documents\BibleBooksNE\Resources
         */

        #region User's directories

        public static string UserDocuments => Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        #endregion

        #region Windows directories

        private static readonly string ProgramData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        private static string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;

        public static string ResourcesDir => Path.Combine(BaseDirectory, "Resources");

        public static string TempDirForWebView => Path.Combine(Path.GetTempPath(), Settings.Default.ProgramNameForFolder, "WebView2");

        public static string TempDir => Path.Combine(Path.GetTempPath(), Settings.Default.ProgramNameForFolder, "tmp");
        public static string TempFile => Path.Combine(TempDir, string.Format("tmp{0}_{1}{2}", DT.Now_FileTailFormat, new Random().Next(1, 999), FileIO.ToExt(FileIO.FileType.html)));


        #endregion

        #region Default Program Directories

        public static string DefaultProgramHomeDirectory => BaseDirectory;
        public static string DefaultDatabaseDirectory => AddDirectorySeparatorChar(DatabaseDirectory(DefaultProgramHomeDirectory, false));
        public static string DefaultResourcesDirectory => AddDirectorySeparatorChar(ResourcesDirectory(DefaultProgramHomeDirectory, false));

        #endregion

        #region Alternative Prorgram Directories

        public static string AlternativeProgramHomeDirectory => ProgramData;
        public static string AlternativeDatabaseDirectory => AddDirectorySeparatorChar(DatabaseDirectory(AlternativeProgramHomeDirectory, true));
        public static string AlternativeResourcesDirectory => AddDirectorySeparatorChar(ResourcesDirectory(AlternativeProgramHomeDirectory, true));
        #endregion

        #region Other Directories

        public static string User_HomeDirectory => Settings.Default.UserHomeDirectory;
        public static string UserDatabaseDirectory => AddDirectorySeparatorChar(DatabaseDirectory(User_HomeDirectory, true));
        public static string UserResourcesDirectory => AddDirectorySeparatorChar(ResourcesDirectory(User_HomeDirectory, true));

        #endregion

        #region Directory Path methods

        public static string DatabaseDirectory(string main, bool withProgName)
        {
            return PathCombine(main, withProgName, Settings.Default.DatabasesFolderName);
        }

        public static string ResourcesDirectory(string main, bool withProgName)
        {
            return PathCombine(main, withProgName, Settings.Default.ResourcesFolderName);
        }


        /// <summary>
        /// Combines an array of strings into a path 
        /// </summary>
        /// <param name="main">Main directories part</param>
        /// <param name="subdir">Subdirectory name</param>
        /// <returns></returns>
        private static string PathCombine(string main, bool withProgName,  string subdir)
        {
            return Path.Combine([main, withProgName ? Settings.Default.ProgramNameForFolder : string.Empty, subdir]);
        }
        private static string AddDirectorySeparatorChar(string path)
        {
            return path + Path.DirectorySeparatorChar;
        }

        #endregion

        #region Arrays

        public static string[] ProgramHomeDirectories()
        {
            return [
                DefaultProgramHomeDirectory,
                AlternativeProgramHomeDirectory,
                User_HomeDirectory
            ];
        }

        public static string[] DatabaseDirectories() {
            return [
                DefaultDatabaseDirectory,
                AlternativeDatabaseDirectory,
                UserDatabaseDirectory
            ];
        }

        public static string[] ResourcesDirectories() {
            return [
                DefaultResourcesDirectory,
                AlternativeResourcesDirectory,
                UserResourcesDirectory
            ];
        }

        #endregion

        #region Values, ToString

        public override string ToString()
        {
            return ToString(Values());
        }

        public override List<KeyValuePair<string, string>> Values()
        {
            return
            [
                new KeyValuePair<string, string>("#0", Resources.ProgramDirectories),
                new KeyValuePair<string, string>(Resources.UserDocuments, UserDocuments),
                new KeyValuePair<string, string>(Resources.BaseDirectory, BaseDirectory),
                new KeyValuePair<string, string>(Resources.DefaultProgramHomeDirectory, DefaultProgramHomeDirectory),
                new KeyValuePair<string, string>(Resources.DefaultDatabaseDirectory, DefaultDatabaseDirectory),
                new KeyValuePair<string, string>(Resources.DefaultResourcesDirectory, DefaultResourcesDirectory),
                new KeyValuePair<string, string>(Resources.AlternativeProgramHomeDirectory, AlternativeProgramHomeDirectory),
                new KeyValuePair<string, string>(Resources.AlternativeDatabaseDirectory, AlternativeDatabaseDirectory),
                new KeyValuePair<string, string>(Resources.AlternativeResourcesDirectory, AlternativeResourcesDirectory),
                new KeyValuePair<string, string>(Resources.UserHomeDirectory, User_HomeDirectory),
                new KeyValuePair<string, string>(Resources.UserDatabaseDirectory, UserDatabaseDirectory),
                new KeyValuePair<string, string>(Resources.UserResourcesDirectory, UserResourcesDirectory),
            ];
        }

        #endregion
    }
}
