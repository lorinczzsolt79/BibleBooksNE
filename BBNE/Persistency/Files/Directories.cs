
namespace BibleBooksNE.Persistency.Files
{
    internal class Directories
    {

        /// <summary>
        /// Get all files from dir and its subdirs by extension.
        /// </summary>
        /// <param name="dirPath">Directory full path</param>
        /// <param name="fileExtension">.ext</param>
        /// <returns>array of fullNames</returns>
        public string[] AllFilesByExtFromDirAndSubDir(string dirPath, string fileExtension)
        {
            return AllFilesFromDirAndSubDir(dirPath, "*" + fileExtension);
        }

        /// <summary>
        /// Get all files from dir and its subdirs by searchPattern.
        /// </summary>
        /// <param name="extension">*.ext</param>
        /// <param name="fileNameWithExt">searchPattern</param>
        /// <returns></returns>
        public string[] AllFilesFromDirAndSubDir(string dirPath, string fileNameWithExt)
        {
            return Directory.GetFiles(dirPath, fileNameWithExt, SearchOption.AllDirectories);
        }

    }
}
