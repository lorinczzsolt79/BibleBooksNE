using BibleBooksNE.Model;
using BibleBooksNE.Model.Database;
using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;
using BibleBooksNE.Model.Other;
using BibleBooksNE.Persistency.Files;
using BibleBooksNE.Persistency.Html.WebPages;
using BibleBooksNE.Properties;
using BibleBooksNE.TMP.DBs;
using System.Diagnostics;
using System.Globalization;
using static System.Environment;

namespace BibleBooksNE.ViewAndController.Forms
{
    partial class Form_Main
    {

        #region Events

        private void ToolStripMenuItem_MakeSZPABibleOutput_Click(object sender, EventArgs e)
        {
            SZPABibleReader();
        }

        #endregion 

        #region Compare Bibles

        private void ShowBibleVerseNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FourthCompare();
            FifthCompare();
        }

        private void ToolStripMenuItem_CompareTreeBibles_Click(object sender, EventArgs e)
        {
            FirstCompare();
            SecondCompare();
            ThirdCompare();
        }

        #region Copmare HKB, BBE, and NIV Bibles

        private void FirstCompare()
        {
            ShowInTextBox.AppendLine();
            ShowInTextBox.AppendLine("# Setting\\Text Editor\\Word Wrap (Un)Checked\n");
            ShowInTextBox.AppendLine("# Compare Bibles and Verse Count\n");
            ShowInTextBox.AppendLine("## Rows: Books and Verses Count");
            ShowInTextBox.AppendLine("## Columns: Bibles and BBE=NIV? and HKB=NIV?\n");
            ShowInTextBox.Append(" N \t");
            for (int i = 0; i < 3; i++)
            {
                ShowInTextBox.Append(AllDatabases.DBs[i].Info.BibleNames.ShortName + "\t");
            }
            ShowInTextBox.AppendLine();
            for (int i = 0; i < 66; i++)
            {
                int x, y, z;
                x = AllDatabases.DBs[0].ChapterNumbers()[i][1];
                y = AllDatabases.DBs[1].ChapterNumbers()[i][1];
                z = AllDatabases.DBs[2].ChapterNumbers()[i][1];
                bool same = x == z;
                bool same2 = y == z;
                ShowInTextBox.AppendLine((i + 1).ToString() + "\t" + x + "\t" + y + "\t" + z + "\t" + same + "\t" + same2);
            }
        }

        private void SecondCompare()
        {
            ShowInTextBox.AppendLine();
            ShowInTextBox.AppendLine("# Bibles and Chapters Count\n");
            ShowInTextBox.AppendLine("BBE: " + AllDatabases.DBs[0].VerseNumbers().Length.ToString());
            ShowInTextBox.AppendLine("HKB: " + AllDatabases.DBs[1].VerseNumbers().Length.ToString());
            ShowInTextBox.AppendLine("NIV: " + AllDatabases.DBs[2].VerseNumbers().Length.ToString());
        }

        private void ThirdCompare()
        {
            ShowInTextBox.AppendLine();
            ShowInTextBox.AppendLine("# Compare Bibles, Chapters and Verses Count\n");
            ShowInTextBox.AppendLine("## Rows: Bibles and Verses Count");
            ShowInTextBox.AppendLine("## Columns: Chapters\n");
            List<int[][]> bibles = [];
            {
                AllDatabases.DBs[0].VerseNumbers(); //Length: 1189 ; Length: 3  (book, chapter, verses)
                AllDatabases.DBs[1].VerseNumbers(); //Length: 1189 ; Length: 3  (book, chapter, verses)
                AllDatabases.DBs[2].VerseNumbers(); //Length: 1189 ; Length: 3  (book, chapter, verses)
            }
            ;
            bool bbeAndNiv = true;
            bool hkbAndNiv = true;

            for (int book = 1; book < 67; book++)
            {
                for (int bible = 0; bible < 3; bible++)
                {
                    if (bible == 0)
                    {
                        ShowInTextBox.Append("BBE");
                    }
                    else
                    {
                        ShowInTextBox.Append(bible == 1 ? "HKB" : "NIV");
                    }

                    ShowInTextBox.Append(" (   Book: " + (book).ToString().PadLeft(2) + ".)\t");
                    for (int chapter = 0; chapter < bibles[bible].Length; chapter++)    //Length: 1189
                    {
                        if (bibles[bible][chapter][0] == book)
                        {
                            ShowInTextBox.Append("\t" + bibles[bible][chapter][2].ToString().PadLeft(3));
                        }
                    }
                    ShowInTextBox.AppendLine();
                    if (bible < 2)
                    {
                        ShowInTextBox.Append(bible == 0 ? "1&3" : "2&3");
                        ShowInTextBox.Append(" ( Equals?    )\t");
                        for (int chapter = 0; chapter < bibles[bible].Length; chapter++)    //Length: 1189
                        {
                            if (bibles[bible][chapter][0] == book)
                            {
                                bool e = bibles[bible][chapter][2] == bibles[2][chapter][2];
                                if (bible == 0)
                                {
                                    if (!e)
                                    {
                                        bbeAndNiv = e;
                                    }
                                }
                                else
                                {
                                    if (!e)
                                    {
                                        hkbAndNiv = e;
                                    }
                                }
                                ShowInTextBox.Append("\t" + (e ? "   " : "NOT"));
                            }
                        }
                        ShowInTextBox.AppendLine();
                    }
                }
                ShowInTextBox.AppendLine();
            }
            ShowInTextBox.AppendLine("BBE & NIV structure: " + (bbeAndNiv ? "Equals!" : "NOT!"));
            ShowInTextBox.AppendLine("HKB & NIV structure: " + (hkbAndNiv ? "Equals!" : "NOT!"));
        }

        #endregion

        #region Compere Bibles

        private void FourthCompare()
        {
            ShowInTextBox.Append("\nBibles, Books, And Chapters Compare\n");
            ShowInTextBox.AppendLine();
            ShowShortNames("N.\t");
            List<int[][]> list = [];
            foreach (DatabaseInfo item in AllDatabases.DBs)
            {
                list.Add(item.ChapterNumbers());
            }
            for (int i = 0; i < 66; i++)
            {
                ShowInTextBox.Append((i + 1).ToString() + ".\t");
                foreach (int[][] item in list)
                {
                    ShowInTextBox.Append(item[i][1] + "\t");
                }
                ShowInTextBox.AppendLine();
            }
        }

        private void ShowShortNames(string firstPar)
        {
            ShowInTextBox.Append(firstPar);
            for (int i = 0; i < AllDatabases.DBs.Length; i++)
            {
                ShowInTextBox.Append(AllDatabases.DBs[i].Info.BibleNames.ShortName + "\t");
            }
            ShowInTextBox.AppendLine();
        }

        private void FifthCompare()
        {
            ShowInTextBox.Append("\nBibles, Books, Chapters, Verses Compare\n");
            ShowInTextBox.AppendLine();
            ShowShortNames("N.\tB. \tCh.\t   \t");

            List<int[][]> list = [];
            ShowInTextBox.Append("  \t  \t  \t  \t");
            int maxChapter = 0;
            int c = 0;
            int maxIndex = 0;
            foreach (DatabaseInfo item in AllDatabases.DBs)
            {
                int[][] array = item.VerseNumbers();
                list.Add(array);
                if (array.Length > maxChapter)
                {
                    maxChapter = array.Length;
                    maxIndex = c;
                }
                ShowInTextBox.Append(array.Length + "\t");
                c++;
            }
            ShowInTextBox.AppendLine("\nMaxChapter: " + maxChapter);
            ShowInTextBox.AppendLine();

            List<string> lines = new List<string>();
            for (int i = 0; i < maxChapter; i++)
            {
                string line = (i + 1).ToString() + ".\t" +
                    list[maxIndex][i][0] + "\t" + list[maxIndex][i][1] + "\t" + "  \t";

                foreach (int[][] item in list)
                {
                    if (i < item.Length)
                    {
                        line += item[i][2] + "\t";
                    }
                    else
                    {
                        line += " - \t";
                    }

                }
                lines.Add(line);
            }
            ShowInTextBox.AppendLines(lines.ToArray());

            lines.Clear();
            ShowInTextBox.AppendLine();
            c = 0;
            for (int i = 0; i < 1189; i++)
            {
                string line = (i + 1).ToString() + ".\t" + list[maxIndex][i][0] + "\t" + list[maxIndex][i][1] + "\t" + "  \t";

                bool same = true;
                c += list[5][i][2];
                for (int j = 5; j < list.Count; j++)
                {
                    if (j < list.Count - 1)
                    {
                        bool s = list[2][i][2].Equals(list[j + 1][i][2]);
                        if (!s)
                        {
                            same = false;
                            break;
                        }
                    }
                }
                line += "\t" + (same ? "true" : "FALSE");
                lines.Add(line);
            }
            lines.Add("Counter: " + c);
            ShowInTextBox.AppendLines(lines.ToArray());
        }


        #endregion

        #endregion

        #region Directories

        private void ListDirs()
        {
            //// ProgramData
            //string commonData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            //// AppData/Roaming
            //string roamingData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            //// AppData/Local
            //string localData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            List<string> pathList =
            [
                "Path Test\n",
                "PathSeparator:\t\t" + Path.PathSeparator.ToString(),
                "DirectorySeparatorChar:\t\t" + Path.DirectorySeparatorChar.ToString(),
                "AltDirectorySeparatorChar:\t\t" + Path.AltDirectorySeparatorChar.ToString(),
                "VolumeSeparatorChar:\t\t" + Path.VolumeSeparatorChar.ToString(),
                "GetInvalidPathChars:\t\t" + string.Join(", ", Path.GetInvalidPathChars()),
                "GetInvalidFileNameChars:\t\t" + string.Join(", ", Path.GetInvalidFileNameChars()),
                "GetRandomFileName:\t\t" + Path.GetRandomFileName(),
                "GetTempFileName:\t\t" + Path.GetTempFileName(),
                "GetTempPath:\t\t" + Path.GetTempPath(),
                string.Empty
            ];

            pathList.ForEach(i => Console.WriteLine(i));

            List<string> systemList = [
                "Environment Properties Test\n",
                "SystemDirectory:\t\t" + SystemDirectory,
                "CurrentDirectory:\t\t" + CurrentDirectory,
                "MachineName:\t\t" + MachineName,
                "UserDomainName:\t\t" + UserDomainName,
                "UserName:\t\t" + UserName,
                "OSVersion:\t\t" + OSVersion.ToString(),
                "Version:\t\t" + Environment.Version.ToString(),
                string.Empty
            ];
            systemList.ForEach(i => Console.WriteLine(i));

            List<SpecialFolder> directories = new List<SpecialFolder>()
            {
                SpecialFolder.CommonAdminTools,
                SpecialFolder.CommonApplicationData,
                SpecialFolder.CommonDesktopDirectory,
                SpecialFolder.CommonDocuments,
                SpecialFolder.CommonMusic,
                SpecialFolder.CommonPictures,
                SpecialFolder.CommonProgramFiles,
                SpecialFolder.CommonProgramFilesX86,
                SpecialFolder.CommonStartMenu,
                SpecialFolder.CommonStartup,
                SpecialFolder.CommonTemplates,
                SpecialFolder.CommonVideos,
                SpecialFolder.Cookies,
                SpecialFolder.Desktop,
                SpecialFolder.DesktopDirectory,
                SpecialFolder.Personal,
                SpecialFolder.Favorites,
                SpecialFolder.History,
                SpecialFolder.InternetCache,
                SpecialFolder.Resources,
                SpecialFolder.Recent,
                SpecialFolder.SendTo,
                SpecialFolder.System,
                SpecialFolder.ProgramFiles,
                SpecialFolder.UserProfile,
                SpecialFolder.Windows,
                SpecialFolder.MyComputer,
                SpecialFolder.MyDocuments,
                SpecialFolder.MyMusic,
                SpecialFolder.MyPictures,
                SpecialFolder.MyVideos
            };
            Console.WriteLine("SpecialFolder Test\n");
            (from i in directories select i + ":\t\t" + GetFolderPath(i)).ToList().ForEach(i => Console.WriteLine(i));
        }

        #endregion

        #region Thread

        private static void ThreadTest()
        {
            // Task.Run(() => RunTest());
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            //btnStart.Enabled = false; // Gomb letiltása, hogy ne indítsák el kétszer
            //label1.Text = "Folyamatban...";

            // A Task.Run kiszervezi a munkát egy háttérszálra
            await Task.Run(() =>
            {
                // Itt fut a hosszú számítás vagy fájlművelet
                Thread.Sleep(10000); // 10 másodperces szimuláció
            });

            //label1.Text = "Kész!";
            //btnStart.Enabled = true;
        }


        private async void Button1_Click(object sender, EventArgs e)
        {
            //label1.Text = "Dolgozom...";

            // Háttérfeladat futtatása anélkül, hogy megakasztaná a felületet
            string result = await Task.Run(() => LongRunningProcess());

            //label1.Text = "Kész: " + result;
        }


        private void CrossThreadOperation()
        {
            Task.Run(() =>
            {
                // Ez egy külön szálon fut
                string data = "Adat a felhőből";

                // Vissza kell szólni a fő szálnak, hogy írja ki:
                this.Invoke(new Action(() =>
                {
                    //label1.Text = data;
                }));
            });
        }

        private string LongRunningProcess()
        {

            return "Ready";
        }

        #endregion

        #region TEST

        private void TestToolStripMenuItem_RunTest_Click(object sender, EventArgs e)
        {
            RunTest();
        }

        private void RunTest()
        {
            //ShowInTextBox.AppendLine("\nTEST");
            //PathCombine_Test();
            //Settings_Test();
            //Resources_Test();
            //Directories_Test();
            //DateTest();
            //Byte_Test();
            //IdentifierFormatter_Test();

            //FullIdsWithText_List_Test();

            //ReadInBibleVerses();
            //NameFormatterTest();
            //LanguagesTest();
            //ListDirs();
            Test_15();
            Debug.WriteLine(Resources.TestIsFinished);
            Msg.Info(Resources.TestIsFinished);
        }

        private void Test_15()
        {
            Debug.WriteLine("15. TESZT");
        }

        private void LanguagesTest()
        {

            //Console.WriteLine(Thread.CurrentThread.Name);
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            //Console.WriteLine(Thread.CurrentThread.ThreadState);
            //Console.WriteLine(Thread.CurrentThread.CurrentCulture);
            //Console.WriteLine(Thread.CurrentThread.CurrentUICulture);

            //// A Windows megjelenítési nyelvének lekérése
            //string uiLanguage = CultureInfo.CurrentUICulture.DisplayName;
            //string uiLanguageCode = CultureInfo.CurrentUICulture.Name; // pl. "hu-HU"

            //// A regionális beállítások nyelvének lekérése
            //string formatLanguage = CultureInfo.CurrentCulture.DisplayName;
            //string formatLanguageCode = CultureInfo.CurrentCulture.Name;

            //Console.WriteLine(" " + uiLanguage);    //  magyar (magyarországi)
            //Console.WriteLine(" " + uiLanguageCode);    //  hu-HU
            //Console.WriteLine(" " + formatLanguage);    //  magyar (magyarországi)
            //Console.WriteLine(" " + formatLanguageCode);    //  hu-HU
            //Console.WriteLine();

            //Console.WriteLine("Defaults:");
            //Console.WriteLine(CultureInfo.CurrentCulture.EnglishName);  // Hungarian (Hungary)
            //Console.WriteLine(CultureInfo.DefaultThreadCurrentCulture);
            //Console.WriteLine(CultureInfo.DefaultThreadCurrentUICulture);
            //Console.WriteLine(InputLanguage.CurrentInputLanguage.Culture.Name);
            //Console.WriteLine(InputLanguage.DefaultInputLanguage.Culture.Name);
            //Console.WriteLine();




            //foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            //{
            //    Console.WriteLine(lang.Culture.EnglishName);    // Hungarian (Hungary)
            //}
            //Console.WriteLine();
        }

        private void SZPABibleReader()
        {
            ReadIn_SZPA_BibleVersesFromTextFile reader = new ReadIn_SZPA_BibleVersesFromTextFile();
            if (string.IsNullOrWhiteSpace(RichTextBox_Text.Text))
            {
                ShowInTextBox.AppendLine(reader.Help());
            }
            else
            {
                if (!RichTextBox_Text.Text.StartsWith("HELP"))
                {
                    reader.Parse(RichTextBox_Text.Lines);
                    // Write Text Files
                    FileIO.WriteToFile(reader.Text_FullName_HEADLINE, reader.HeadlinesList().ToList());
                    FileIO.WriteToFile(reader.Text_FullName_VERSES, reader.VersesList().ToList());

                    // Write SQL Files
                    FileIO.WriteToFile(reader.SQL_FullName_HEADLINE, reader.SQLCommandHeadlines());
                    FileIO.WriteToFile(reader.SQL_FullName_VERSES, reader.SQLCommandVerses());
                    Console.WriteLine(reader.ReturnMsg());
                }
            }
        }

        private void NameFormatterTest()
        {
        //    FullIdentifier fullId = new FullIdentifier(
        //        new Identifier(1),
        //        new Identifier(2),
        //        new Identifier(3),
        //        new Identifier(4),
        //        new Identifier(5),
        //        PageOrder.footnote);
        //    ShowInTextBox.AppendLine(fullId.ToString());
        //    ShowInTextBox.AppendLine();
        //    ShowInTextBox.AppendLine(Name_Formatter.FourFormattedNumbers(fullId));
        //    ShowInTextBox.AppendLine(Name_Formatter.SixFormattedNumbers(fullId));
        //    ShowInTextBox.AppendLine(Name_Formatter.SeparatedSixFormattedNumbers(fullId));
        //    ShowInTextBox.AppendLine(Name_Formatter.ShortBibleNameShortBookNameChapterNumberVerseNumber(fullId));
        //    ShowInTextBox.AppendLine(Name_Formatter.ShortBibleNameShortBookNameChapterNumber(fullId));
        //    ShowInTextBox.AppendLine(Name_Formatter.LongBibleNameLongBookNameChapterNumber(fullId));
        }

        private void ReadInBibleVerses()
        {
            // E:\Win10\Desktop\internet\downloads\Downloaded 20251220\Bible text files\third\BRB Chapter Headlines.txt
            // new ReadIn_WEB_BibleVersesFromTextFile(RichTextBox_Text.Lines[0]).Run();
            // new ReadIn_BRB_BibleVersesFromTextFile();.Run
             
            //if (RichTextBox_Text.Lines.Length > 0)
            //{
            //    foreach (string item in RichTextBox_Text.Lines)
            //    {
            //        new ReadIn_Default_BibleVersesFromTextFile(item).Run();
            //        Console.WriteLine();
            //        //new ReadIn_Default_BibleVersesFromTextFile(item).Print();
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No input!");
            //}
        }

        private static void FullIdentifier_Parser_Test()
        {
            //// identifiers without separator Test-
            //FullIdentifier.Parser("999", 0);
            //FullIdentifier.Parser("999", 1);
            //FullIdentifier.Parser("01002003", 3);
            //FullIdentifier.Parser("001002003", 3);
            //FullIdentifier.Parser("0-1002003", 3);
            //FullIdentifier.Parser("N-1002003", 3);

            //FullIdentifier.Parser("001002003004005006", 6);

            //// identifiers WITH separator Test

            //FullIdentifier.Parser("999", '.');
            //FullIdentifier.Parser("999.", '.');
            //FullIdentifier.Parser("1.22.333", '.');
            //FullIdentifier.Parser("001.002.003.", '.');
            //FullIdentifier.Parser("0-9.002.003.", '.');
            //FullIdentifier.Parser("N-1.002.003.", '.');

            //FullIdentifier.Parser("001.002.003.004.005.006", '.');

            //FullIdentifier.Parser("001.002.003.004.005.006.", '.');
        }

        private void Byte_Test()
        {
            //ShowInTextBox.AppendLine("\nByte Test:");
            //sbyte b;
            //int i = -257;
            //b = (sbyte)i;
            //ShowInTextBox.AppendLine(b.ToString());
        }

        private void PathCombine_Test()
        {
            //ShowInTextBox.AppendLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Settings.Default.DatabasesFolderName));
        }

        private void Settings_Test()
        {
            //ShowInTextBox.AppendLine("\nSettings test:");
            //ShowInTextBox.AppendLine(new ProgramDirectories().ToString());
        }

        private void Directories_Test()
        {
            //ShowInTextBox.AppendLine("\nDirectories test");
            //ShowInTextBox.AppendLine(GetFolderPath(SpecialFolder.Personal));       // C:\Users\me\Documents
            //ShowInTextBox.AppendLine(@"E:\Win10\Documents");                                               // E:\Win10\Documents
            //ShowInTextBox.AppendLine("GospelAndLyrics");                                                   // GospelAndLyrics
            //ShowInTextBox.AppendLine(@"E:\Win10\Documents" + "\\" + "GospelAndLyrics" + "\\");             // E:\Win10\Documents\GospelAndLyrics\
        }

        private void Resources_Test()
        {
            //ShowInTextBox.AppendLine("\nResources test");
            //ShowInTextBox.AppendLine(Settings.Default.ProgramNameForFolder);
            //ShowInTextBox.AppendLine(Settings.Default.DatabasesFolderName);
            //ShowInTextBox.AppendLine(Settings.Default.ResourcesFolderName);
        }


        private void DateTest()
        {
            //ShowInTextBox.AppendLine("\nDate test");
            //ShowInTextBox.AppendLine(DT.Now);          // output: 2025. 04. 12. 10:47:13
            //ShowInTextBox.AppendLine(DT.Date);         // output: 2025.04.12
            //ShowInTextBox.AppendLine(DT.DateDot);      // output: 2025.04.12.
            //ShowInTextBox.AppendLine(DT.DateTail);     // output: _20250412104713
        }

        private void FullIdsWithText_List_Test()
        {

            //FullIdentifier fullIds1 = new FullIdentifier(
            //    new Identifier(2),
            //    new Identifier(61),
            //    new Identifier(-1),
            //    new Identifier(-1),
            //    new Identifier(0),
            //    PageOrder.verse_item);

            //FullIdentifier fullIds2 = new FullIdentifier(
            //    new Identifier(2),
            //    new Identifier(61),
            //    new Identifier(-1),
            //    new Identifier(-1),
            //    new Identifier(0),
            //    PageOrder.footnote);

            //FullIdentifier fullIds3 = new FullIdentifier(
            //    new Identifier(2),
            //    new Identifier(61),
            //    new Identifier(-1),
            //    new Identifier(-1),
            //    new Identifier(0),
            //    PageOrder.headline_title);

            //FullIdentifier fullIds4 = new FullIdentifier(
            //    new Identifier(2),
            //    new Identifier(61),
            //    new Identifier(-1),
            //    new Identifier(-1),
            //    new Identifier(0),
            //    PageOrder.crosslink_item);

            //ShowInTextBox.AppendSeparator();
            //List<FullIdentifierWithText> list = new();
            //list.AddRange(AllDatabases.GetDatabase(AllDatabases.Size).GetVerseTypeItems(fullIds1));
            //list.AddRange(AllDatabases.GetDatabase(AllDatabases.Size).GetVerseTypeItems(fullIds2));
            //list.AddRange(AllDatabases.GetDatabase(AllDatabases.Size).GetVerseTypeItems(fullIds3));
            //list.AddRange(AllDatabases.GetDatabase(AllDatabases.Size).GetVerseTypeItems(fullIds4));
            //list.Sort();
            //foreach (FullIdentifierWithText item in list)
            //{
            //    ShowInTextBox.AppendLine(item.ToString());
            //}
        }

        #endregion
    }
}
