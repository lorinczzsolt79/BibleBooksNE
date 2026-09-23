using BibleBooksNE.Properties;
using BibleBooksNE.ViewAndController;
using System.Text;

namespace BibleBooksNE.Persistency.Files
{
    internal class FileIO
    {
        #region General things

        public enum FileType
        {
            unknown,
            txt,
            log,
            bak,
            md,
            htm,
            html,
            gl,
            db
        }

        // Invalid Windows File Name Characters:	\/:*?"<>|
        // slash, backslash, colon, asterisk, question mark, left angle, right angle, pipe

        public static readonly char DirSeparator = '\\';
        private static readonly char[] invalidCharacters = { DirSeparator, '/', ':', '*', '?', '\"', '<', '>', '|' };

        #endregion

        #region Reading

        public static List<string> ReadFromFile(FileInfo fileInfo) => ReadFromFile(fileInfo.FullName);

        public static List<string> ReadFromFile(string fullName)
        {
            List<string> fileLines = [];
            try
            {
                StreamReader inputFile = new(fullName, Encoding.UTF8);
                while (!inputFile.EndOfStream)
                {
                    var line = inputFile.ReadLine();
                    if (line != null)
                    {
                        fileLines.Add(line);
                    }
                }
                inputFile.Close();
                return fileLines;
            }
            catch (FileNotFoundException fnfException)
            {
                Msg.Error(Resources.FileReadingError + "\n" + fullName + "\n" + fnfException.Message);
            }
            catch (Exception)
            {
                Msg.Error(Resources.FileReadingError + "\n" + fullName);
            }
            return fileLines;
        }

        #endregion

        #region Append

        public static bool AppendToFile(string pathAndFileName, List<string> fileLines)
        {
            return Write(pathAndFileName, [.. fileLines], FileMode.Append);
        }

        public static bool AppendToFile(string pathAndFileName, string[] fileLines)
        {
            return Write(pathAndFileName, fileLines, FileMode.Append);
        }

        #endregion

        #region Writing

        public static bool WriteToFile(string pathAndFileName, List<string> fileLines)
        {
            return Write(pathAndFileName, fileLines.ToArray(), FileMode.Create);
        }

        public static bool WriteToFile(string pathAndFileName, string[] fileLines)
        {
            return Write(pathAndFileName, fileLines, FileMode.Create);
        }

        private static bool Write(string pathAndFileName, string[] fileLines, FileMode fileMode)
        {
            try
            {
                var fileInfo = new FileInfo(pathAndFileName).DirectoryName;
                if (fileInfo != null)
                {
                    Directory.CreateDirectory(fileInfo);
                    FileStream mode = File.Open(pathAndFileName, fileMode);
                    StreamWriter outputFile = new(mode);
                    foreach (string fileLine in fileLines)
                    {
                        outputFile.WriteLine(fileLine);
                    }
                    outputFile.Close();
                    return true;
                }
                return false;
            }
            catch (FileLoadException flException)
            {
                Msg.Error(Resources.FileWritingError + "\n" +
                pathAndFileName + "\n" + flException.Message);
            }
            catch (Exception)
            {
                Msg.Error(Resources.FileWritingError + "\n" + pathAndFileName);
            }
            return false;
        }

        #endregion

        #region File name checking

        public static string ToValidWindowsFileName(string str)
        {
            return ReplaceInvalidCharToSpace(str);
        }

        private static string ReplaceInvalidCharToSpace(string str)
        {
            foreach (char item in invalidCharacters)
            {
                str = str.Replace(item, ',');
            }
            return str;
        }

        #endregion

        #region Other methods

        public static FileType FileTypeFromFileInfo(FileInfo fileInfo)
        {
            if (fileInfo != null)
            {
                switch (fileInfo.Extension.ToLower())
                {
                    case ".txt":
                        return FileType.txt;
                    case ".log":
                        return FileType.log;
                    case ".bak":
                        return FileType.bak;
                    case ".md":
                        return FileType.md;
                    case ".htm":
                    case ".html":
                        return FileType.html;
                    default: break;
                }
            }
            return FileType.unknown;
        }

        public static string FileTypeToString(FileType fileType)
        {
            return fileType.ToString().ToLower();
        }

        public static string ToExt(FileType fileType) { return string.Concat('.' + FileTypeToString(fileType)); }

        public static string AsDir(string path) => path + DirSeparator;

        public static string AsDir(string[] dirNames)
        {
            return AsDir(string.Join(DirSeparator.ToString(), dirNames));
        }

        public static string FileName(string title, string author)
        {
            return title + " - " + author;
        }

        public static string FileNameExt(string title, string author, FileType fileType)
        {
            return FileName(title, author) + Ext(fileType);
        }

        public static string Ext(FileType type) => ToExt(type);

        public static string FullPath(string parentDirPath, string title, string author, FileType fileType)
        {
            return parentDirPath + FileNameExt(title, author, fileType);
        }

        #endregion

    }
}
