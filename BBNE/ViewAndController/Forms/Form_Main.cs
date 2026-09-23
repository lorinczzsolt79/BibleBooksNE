using BibleBooksNE.Model;
using BibleBooksNE.Model.Database;
using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;
using BibleBooksNE.Model.Names;
using BibleBooksNE.Model.VerseTypes;
using BibleBooksNE.Persistency.Files;
using BibleBooksNE.Persistency.Html.HtmlMessages;
using BibleBooksNE.Persistency.SQLite;
using BibleBooksNE.Properties;
using BibleBooksNE.ViewAndController.Language;
using BibleBooksNE.ViewAndController.Navigation;
using Microsoft.Web.WebView2.Core;
using static BibleBooksNE.Persistency.Files.FileIO;
using static System.Environment;

namespace BibleBooksNE.ViewAndController.Forms
{
    public partial class Form_Main : Form
    {
        #region General things

        public Form_Main()
        {
            AllDatabases = new([]);
            Name_Formatter = new(new([]));
            ShowInTextBox = new();
            UserAction = new();
            VerseTypeList_Handler = new();
            Search_Handler = new();

            InitializeComponent();
            InitializeProgramThings();
            InitializeUserThings();
        }

        private DatabaseHandler AllDatabases { get; set; }
        private NameFormatter Name_Formatter { get; set; }
        private ShowIn ShowInTextBox { get; set; }
        private UserActions UserAction { get; set; }
        private VerseTypeListHandler VerseTypeList_Handler { get; set; }
        private SearchHandler Search_Handler { get; set; }

        private void InitializeProgramThings()
        {
            base.Text = Assemblies.AssemblyTitle;
            _ = InitWebViewAsync();
            RichTextBox_Text.EnableContextMenu();
            ShowInTextBox = new ShowIn(RichTextBox_Text);
            InitUserLanguageListBox();
        }

        private void InitializeUserThings()
        {
            DatabaseStart();
            UserSettings();
        }

        private void DatabaseStart()
        {
            // Databases
            DatabaseStart dbStart = new();
            AllDatabases = dbStart.GetDatabases();
            ShowInTextBox.AppendLine(Resources.Databases + ": " + dbStart.DatabaseFullNames.Count);
            ShowInTextBox.AppendLines([.. dbStart.DatabaseFullNames]);
            // EndDatabases
            Name_Formatter = new NameFormatter(AllDatabases);
        }

        private void UserSettings()
        {
            UserAction = new UserActions
            {
                SelectedBibleIndex = -1
            };
            if (AllDatabases.Size > 0)
            {
                VerseTypeList_Handler = new VerseTypeListHandler(databaseHandler: AllDatabases);
                Search_Handler = new SearchHandler(databaseHandler: AllDatabases);
                SetAllSettings();
            }
        }

        #endregion

        #region WebView2 Initialization

        private async Task InitWebViewAsync()
        {
            var env = await CoreWebView2Environment.CreateAsync(null, ProgramDirectories.TempDirForWebView);
            await WebView21.EnsureCoreWebView2Async(env);
        }

        private void WebView21_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            NavigateToString(WebView21, new MessagesHtmlPage().WelcomeHtmlPage());
            SetView();
        }

        #endregion

        #region User's Settings

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CheckBox_SaveStateBeforeClosing.Checked)
            {
                SaveAllSettings();
            }
            ClearTempDirBeforeQuit();
        }

        private void SetSelectorState(string state)
        {
            if (!string.IsNullOrEmpty(state))
            {
                UserAction = new(IdsWithOrders.Parse(state));
            }
        }

        private void ClearTempDirBeforeQuit()
        {
            if (CheckBox_ClearTempDirBeforeQuit.Checked)
            {
                DirectoryInfo dfi = new(ProgramDirectories.TempDir);
                if (dfi.Exists)
                {
                    dfi.Delete(true);
                }
                dfi.Create();
            }
        }

        private void Button_SaveCurrentSettings_Click(object sender, EventArgs e)
        {
            SaveAllSettings();
        }

        private void Button_ResetDefaultSettings_Click(object sender, EventArgs e)
        {
            ResetAllSettings();
        }

        #region Checked Changed Settings

        private void CheckBox_WordWrap_CheckedChanged(object sender, EventArgs e)
        {
            RichTextBox_Text.WordWrap = CheckBox_WordWrap.Checked;
        }

        private void CheckBox_WordWrap_CheckStateChanged(object sender, EventArgs e)
        {
            SaveWordWrap_CheckState();
        }

        private void CheckBox_InCheckedAddOnsToo_CheckStateChanged(object sender, EventArgs e)
        {
            SaveInCheckedAddOnsToo_CheckState();
        }

        private void CheckBox_Headlines_CheckStateChanged(object sender, EventArgs e)
        {
            SaveHeadLines_CheckState();
        }

        private void CheckBox_Crosslinks_CheckStateChanged(object sender, EventArgs e)
        {
            SaveCrosslinks_CheckState();
        }

        private void CheckBox_Footnotes_CheckStateChanged(object sender, EventArgs e)
        {
            SaveFootnotes_CheckState();
        }

        private void CheckBox_WordList_CheckStateChanged(object sender, EventArgs e)
        {
            SaveWordList_CheckState();
        }

        private void CheckBox_Audio_CheckStateChanged(object sender, EventArgs e)
        {
            SaveAudio_CheckState();
        }

        private void CheckBox_SaveStateBeforeClosing_CheckStateChanged(object sender, EventArgs e)
        {
            SaveStateBeforeClosing_CheckState();
        }

        private void CheckBox_SaveReaderStateBeforeQuit_CheckStateChanged(object sender, EventArgs e)
        {
            SaveSelectorStateBeforeQuit_CheckState();
        }

        private void CheckBox_SortingType_CheckedChanged(object sender, EventArgs e)
        {
            SaveSortingType_CheckState();
        }

        private void CheckBox_JustifyIfPossible_CheckedChanged(object sender, EventArgs e)
        {
            SaveJustifyIfPossible_CheckedState();
        }

        private void CheckBox_DarkTheme_CheckedChanged(object sender, EventArgs e)
        {
            SaveDarkTheme_CheckState();
        }

        private void CheckBox_ClearTempDirBeforeQuit_CheckedChanged(object sender, EventArgs e)
        {
            SaveClearTempDirBeforeQuit_CheckState();
        }

        #endregion

        #region Set User Settings

        private void SetReaderStateBeforeQuit_CheckState() { CheckBox_SaveSelectorStateBeforeQuit.Checked = Settings.Default.SaveReaderStateBeforeQuit; }
        private void SetStateBeforeClosing_CheckState() { CheckBox_SaveStateBeforeClosing.Checked = Settings.Default.SaveStateBeforeClosing; }
        private void SetAudio_CheckState() { CheckBox_Audio.Checked = Settings.Default.Audio; }
        private void SetWordList_CheckState() { CheckBox_WordList.Checked = Settings.Default.WordList; }
        private void SetFootnotes_CheckState() { CheckBox_Footnotes.Checked = Settings.Default.Footnotes; }
        private void SetCrosslinks_CheckState() { CheckBox_Crosslinks.Checked = Settings.Default.Crosslinks; }
        private void SetHeadLines_CheckState() { CheckBox_Headlines.Checked = Settings.Default.Headlines; }
        private void SetInCheckedAddOnsToo_CheckState() { CheckBox_InCheckedAddOnsToo.Checked = Settings.Default.InCheckedAddOnsToo; }
        private void SetWordWrap_CheckState() { CheckBox_WordWrap.Checked = Settings.Default.WordWrap; }
        private void SetBibleReaderState() { SetSelectorState(Settings.Default.SelectorState); }
        private void SetSortingType_CheckState() { CheckBox_SortingType.Checked = Settings.Default.SortingType; }
        private void SetJustifyIfPossible_CheckedState() { CheckBox_JustifyIfPossible.Checked = Settings.Default.JustifyIfPossible; }
        private void SetDarkTheme_CheckState() { CheckBox_DarkTheme.Checked = Settings.Default.DarkTheme; }
        private void SetClearTempDirBeforeQuit_CheckState() { CheckBox_ClearTempDirBeforeQuit.Checked = Settings.Default.ClearTempDirBeforeQuit; }
        private void SetSplitterDistance() { SplitContainer_Selector.SplitterDistance = Settings.Default.SplitterDistance; }
        private void SetUserLanguage()
        {
            UserLang = Settings.Default.UserLanguage;
            SetUserLanguageListBoxSelectedItem();
        }

        private void SetAllSettings()
        {
            SetWordWrap_CheckState();
            SetInCheckedAddOnsToo_CheckState();
            SetHeadLines_CheckState();
            SetCrosslinks_CheckState();
            SetFootnotes_CheckState();
            SetWordList_CheckState();
            SetAudio_CheckState();
            SetStateBeforeClosing_CheckState();
            SetReaderStateBeforeQuit_CheckState();
            SetBibleReaderState();
            SetSortingType_CheckState();
            SetDarkTheme_CheckState();
            SetJustifyIfPossible_CheckedState();
            SetClearTempDirBeforeQuit_CheckState();
            SetSplitterDistance();
            SetUserLanguage();
        }

        #endregion

        #region Reset Default Settings

        private void ResetSortingType_CheckState() { CheckBox_SortingType.Checked = GetSettingsBoolProperty("SortingType"); }
        private void ResetReaderStateBeforeQuit_CheckState() { CheckBox_SaveSelectorStateBeforeQuit.Checked = GetSettingsBoolProperty("SaveReaderStateBeforeQuit"); }
        private void ResetStateBeforeClosing_CheckState() { CheckBox_SaveStateBeforeClosing.Checked = GetSettingsBoolProperty("SaveStateBeforeClosing"); }
        private void ResetAudio_CheckState() { CheckBox_Audio.Checked = GetSettingsBoolProperty("Audio"); }
        private void ResetWordList_CheckState() { CheckBox_WordList.Checked = GetSettingsBoolProperty("WordList"); }
        private void ResetFootnotes_CheckState() { CheckBox_Footnotes.Checked = GetSettingsBoolProperty("Footnotes"); }
        private void ResetCrosslinks_CheckState() { CheckBox_Crosslinks.Checked = GetSettingsBoolProperty("Crosslinks"); }
        private void ResetHeadLines_CheckState() { CheckBox_Headlines.Checked = GetSettingsBoolProperty("Headlines"); }
        private void ResetInCheckedAddOnsToo_CheckState() { CheckBox_InCheckedAddOnsToo.Checked = GetSettingsBoolProperty("InCheckedAddOnsToo"); }
        private void ResetWordWrap_CheckState() { CheckBox_WordWrap.Checked = GetSettingsBoolProperty("WordWrap"); }
        private void ResetBibleReaderState() { SetSelectorState(GetSettingsProperty("BibleReaderState")); }
        private void ResetJustifyIfPossible_CheckedState() { CheckBox_JustifyIfPossible.Checked = GetSettingsBoolProperty("JustifyIfPossible"); }
        private void ResetDarkTheme_CheckState() { CheckBox_DarkTheme.Checked = GetSettingsBoolProperty("DarkTheme"); }
        private void ResetClearTempDirBeforeQuit_CheckState() { CheckBox_ClearTempDirBeforeQuit.Checked = GetSettingsBoolProperty("ClearTempDirBeforeQuit"); }
        private void ResetSplitterDistance() { SplitContainer_Selector.SplitterDistance = int.Parse(GetSettingsProperty("SplitterDistance")); }
        private void ResetUserLanguage()
        {
            UserLang = int.Parse(GetSettingsProperty("UserLanguage"));
            SetUserLanguageListBoxSelectedItem();
        }


        private static bool GetSettingsBoolProperty(string name)
        {
            _ = bool.TryParse(GetSettingsProperty(name), out bool result);
            return result;
        }

        private static string GetSettingsProperty(string name)
        {
            return GetSettingsValue(Settings.Default.Properties[name].DefaultValue);
        }

        private static string GetSettingsValue(object obj)
        {
            string? s = obj.ToString();
            return obj == null ? string.Empty : s ?? string.Empty;
        }

        private void ResetAllSettings()
        {
            ResetReaderStateBeforeQuit_CheckState();
            ResetStateBeforeClosing_CheckState();
            ResetAudio_CheckState();
            ResetWordList_CheckState();
            ResetFootnotes_CheckState();
            ResetCrosslinks_CheckState();
            ResetHeadLines_CheckState();
            ResetSortingType_CheckState();
            ResetInCheckedAddOnsToo_CheckState();
            ResetWordWrap_CheckState();
            ResetBibleReaderState();
            ResetJustifyIfPossible_CheckedState();
            ResetDarkTheme_CheckState();
            ResetClearTempDirBeforeQuit_CheckState();
            ResetSplitterDistance();
            ResetUserLanguage();
            Settings.Default.Save();
        }

        #endregion

        #region Save User Settings

        private void SaveSortingType_CheckState() { Settings.Default.SortingType = CheckBox_SortingType.Checked; }
        private void SaveSelectorStateBeforeQuit_CheckState() { Settings.Default.SaveReaderStateBeforeQuit = CheckBox_SaveSelectorStateBeforeQuit.Checked; }
        private void SaveStateBeforeClosing_CheckState() { Settings.Default.SaveStateBeforeClosing = CheckBox_SaveStateBeforeClosing.Checked; }
        private void SaveAudio_CheckState() { Settings.Default.Audio = CheckBox_Audio.Checked; }
        private void SaveWordList_CheckState() { Settings.Default.WordList = CheckBox_WordList.Checked; }
        private void SaveFootnotes_CheckState() { Settings.Default.Footnotes = CheckBox_Footnotes.Checked; }
        private void SaveCrosslinks_CheckState() { Settings.Default.Crosslinks = CheckBox_Crosslinks.Checked; }
        private void SaveHeadLines_CheckState() { Settings.Default.Headlines = CheckBox_Headlines.Checked; }
        private void SaveInCheckedAddOnsToo_CheckState() { Settings.Default.InCheckedAddOnsToo = CheckBox_InCheckedAddOnsToo.Checked; }
        private void SaveWordWrap_CheckState() { Settings.Default.WordWrap = CheckBox_WordWrap.Checked; }
        private void SaveSelectorState()
        {
            if (CheckBox_SaveSelectorStateBeforeQuit.Checked)
            {
                Settings.Default.SelectorState = UserAction.GetState();
            }
        }
        private void SaveJustifyIfPossible_CheckedState() { Settings.Default.JustifyIfPossible = CheckBox_JustifyIfPossible.Checked; }
        private void SaveDarkTheme_CheckState() { Settings.Default.DarkTheme = CheckBox_DarkTheme.Checked; }
        private void SaveClearTempDirBeforeQuit_CheckState() { Settings.Default.ClearTempDirBeforeQuit = CheckBox_ClearTempDirBeforeQuit.Checked; }
        private void SaveSplitterDistance() { Settings.Default.SplitterDistance = SplitContainer_Selector.SplitterDistance; }
        private void SaveUserLanguage() { Settings.Default.UserLanguage = UserLang; }

        private void SaveAllSettings()
        {
            SaveSortingType_CheckState();
            SaveWordWrap_CheckState();
            SaveInCheckedAddOnsToo_CheckState();
            SaveHeadLines_CheckState();
            SaveCrosslinks_CheckState();
            SaveFootnotes_CheckState();
            SaveWordList_CheckState();
            SaveAudio_CheckState();
            SaveStateBeforeClosing_CheckState();
            SaveSelectorStateBeforeQuit_CheckState();
            SaveSelectorState();
            SaveJustifyIfPossible_CheckedState();
            SaveDarkTheme_CheckState();
            SaveClearTempDirBeforeQuit_CheckState();
            SaveSplitterDistance();
            SaveUserLanguage();
            Settings.Default.Save();
        }

        #endregion

        #endregion

        #region Menu Items
        private void ToolStripMenuItem_ShowAllDatabaseInfo_Click(object sender, EventArgs e)
        {
            ShowAllDatabaseInfo();
        }

        private void ToolStripMenuItem_ShowAllSettings_Click(object sender, EventArgs e)
        {
            ShowAllSettings();
        }

        private void ShowAllDatabaseInfo()
        {
            if (AllDatabases != null)
            {
                ShowInTextBox.AppendLine(AllDatabases.ToString());
            }
        }

        private void ShowAllSettings()
        {
            ShowInTextBox.AppendSeparator();
            ShowInTextBox.AppendLine(new ProgramDirectories().ToString());
        }

        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsFile();
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotImplementedYet();
        }

        private static void NotImplementedYet()
        {
            Msg.Info(Resources.NotImplementedYet);
        }

        #endregion

        #region Selector Events

        #region Selection from Listboxes

        private void ListBox_Bibles_MouseClick(object sender, MouseEventArgs e)
        {
            SetView_Bibles();
        }

        private void ListBox_Bibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FromUI)
            {
                SetView_Bibles();
            }
        }

        private void ListBox_Bibles_Click(object sender, EventArgs e)
        {
            SetView_Bibles();
        }

        private void SetView_Bibles()
        {
            if (ListBox_Bibles.Items.Count > 0)
            {
                SetView(PageOrder.bible);
            }
        }

        private void ListBox_Books_Click(object sender, EventArgs e)
        {
            SetView_Books();
        }

        private void SetView_Books()
        {
            if (ListBox_Books.Items.Count > 0)
            {
                SetView(PageOrder.book);
            }
        }

        private void ListBox_Chapters_Click(object sender, EventArgs e)
        {
            SetView_Chapters();
        }

        private void SetView_Chapters()
        {
            if (ListBox_Chapters.Items.Count > 0)
            {
                SetView(PageOrder.chapter);
            }
        }

        private void ListBox_Verses_Click(object sender, EventArgs e)
        {
            SetView_Verses();
        }

        private void SetView_Verses()
        {
            if (ListBox_Verses.Items.Count > 0)
            {
                SetView(PageOrder.verse_item);
            }
        }

        #endregion

        #region AddOns Changed


        private void CheckBox_Headlines_CheckedChanged(object sender, EventArgs e)
        {
            SetView(PageOrder.headline_title);
        }

        private void CheckBox_Crosslinks_CheckedChanged(object sender, EventArgs e)
        {
            SetView(PageOrder.crosslink_item);
        }

        private void CheckBox_Footnotes_CheckedChanged(object sender, EventArgs e)
        {
            SetView(PageOrder.footnote);
        }

        private void CheckBox_Audio_CheckedChanged(object sender, EventArgs e)
        {
            SetView(PageOrder.audio);
        }

        private void CheckBox_WordsList_CheckedChanged(object sender, EventArgs e)
        {
            SetView(PageOrder.wordlist);
        }

        #endregion

        private void TextBox_PreviousSearchedText_Click(object sender, EventArgs e)
        {
            SearchedText = PreviousSearchedText;
            PreviousSearchedText = string.Empty;
        }

        private void Button_Search_Click(object sender, EventArgs e)
        {
            SearchHtmlPage();
        }

        #endregion

        #region Navigation from browser

        private void WebView21_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            UriSplitter uriSplitter = new(e.Uri);
            KeyValuePair<string, string> headAndTail = uriSplitter.HeadAndTail;
            UriType uriType = ToUriType(headAndTail.Key);
            UriSelector(uriType, ToIdsWithOrders(headAndTail.Value, GetAddOnsState()));
        }

        private static UriType ToUriType(string uriType)
        {
            return EnumTask.ToEnum(uriType, false, UriType.unknown);
        }

        private PageOrder[] GetAddOnsState()
        {
            List<PageOrder> list = [];
            if (CheckBox_Headlines.Checked) list.Add(PageOrder.headline_title);
            if (CheckBox_Crosslinks.Checked) list.Add(PageOrder.crosslink_item);
            if (CheckBox_Footnotes.Checked) list.Add(PageOrder.footnote);
            if (CheckBox_WordList.Checked) list.Add(PageOrder.wordlist);
            if (CheckBox_Audio.Checked) list.Add(PageOrder.audio);
            return [.. list];
        }

        private bool FromUI = true;

        private void UriSelector(UriType uriType, IdsWithOrders idsWithOrders)
        {
            FromUI = false;
            switch (uriType)
            {
                case UriType.bible:
                case UriType.book:
                case UriType.chapter:
                case UriType.verse:
                case UriType.link:
                    {
                        UserAction = new(idsWithOrders);
                        SetView();
                        break;
                    }
                case UriType.next:
                case UriType.previous:
                default: break;
            }
            FromUI = true;
        }

        private static IdsWithOrders ToIdsWithOrders(string ids, PageOrder[] orders)
        {
            IdsWithOrders idsWithOrders = new();
            try
            {
                int[] idsArray = FullIdentifier.Parser(ids, '.');
                if (idsArray.Length > 3)
                {
                    idsWithOrders = new IdsWithOrders(
                        idsArray[0],
                        idsArray[1],
                        idsArray[2],
                        idsArray[3],
                        orders);
                }
            }
            catch { }
            return idsWithOrders;
        }
        #endregion

        #region Save File

        private void SaveFile()
        {
            DialogResult result;
            do
            {
                saveFileDialog1.FileName = string.Empty;
                saveFileDialog1.Filter = Resources.TextFile + "|*.txt|" +
                                         Resources.MarkdownFile + "|*.md|" +
                                         Resources.OtherFile + "|*.*";
                saveFileDialog1.FilterIndex = 1;
                result = saveFileDialog1.ShowDialog();
                saveFileDialog1.InitialDirectory = GetFolderPath(SpecialFolder.MyDocuments);
                if (result == DialogResult.OK)
                {
                    if (saveFileDialog1.CheckPathExists && !saveFileDialog1.CheckFileExists)
                    {
                        result = SaveTextFile(saveFileDialog1.FileName);
                    }
                }
            } while (result != DialogResult.Cancel);
        }

        private DialogResult SaveTextFile(string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                WriteToFile(fileName, RichTextBox_Text.Lines);
            }
            return DialogResult.Cancel;
        }

        private void SaveAsFile()
        {
            if (!string.IsNullOrEmpty(LastWebPageFullName))
            {
                DialogResult result;
                do
                {
                    saveFileDialog1.FileName = string.Empty;
                    saveFileDialog1.Filter = Resources.HtmlFile + "|*.html";
                    saveFileDialog1.FilterIndex = 1;
                    result = saveFileDialog1.ShowDialog();
                    saveFileDialog1.InitialDirectory = GetFolderPath(SpecialFolder.MyDocuments);
                    if (result == DialogResult.OK)
                    {
                        if (saveFileDialog1.CheckPathExists && !saveFileDialog1.CheckFileExists)
                        {
                            FileInfo ff = new FileInfo(LastWebPageFullName).CopyTo(saveFileDialog1.FileName);
                            if (ff == null || !ff.Exists)
                            {
                                Msg.Error(Resources.FileSavingError);
                            }
                            result = DialogResult.Cancel;
                        }
                    }
                } while (result != DialogResult.Cancel);
            }
        }

        #endregion

        #region Open File

        private void OpenFile()
        {
            DialogResult result;
            do
            {
                openFileDialog1.FileName = string.Empty;
                openFileDialog1.Filter =
                    Resources.FilesToOpen + "|*.txt; *.log; *.bak; *.md; *.htm; *.html|" +
                    Resources.OnlyTextFiles + "|*.txt|" +
                    Resources.OnlyHtmlFiles + "|*.html; *.htm|" +
                    Resources.AllFiles + "|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.DefaultExt = FileTypeToString(FileType.txt);
                openFileDialog1.InitialDirectory = GetFolderPath(SpecialFolder.MyDocuments);
                result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    result = OpenFileByExt(result, openFileDialog1.FileName);
                }
            } while (result != DialogResult.Cancel);
        }


        private DialogResult OpenFileByExt(DialogResult result, string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                FileInfo inputFileInfo = new(fileName);
                if (inputFileInfo.Exists)
                {
                    FileType fileType = FileTypeFromFileInfo(inputFileInfo);
                    switch (fileType)
                    {
                        case FileType.txt:
                        case FileType.log:
                        case FileType.bak:
                        case FileType.md:
                            OpenTextFile(inputFileInfo);
                            return DialogResult.Cancel;
                        case FileType.htm:
                        case FileType.html:
                            OpenHtmlFile(inputFileInfo);
                            return DialogResult.Cancel;
                        default:
                            FileOpenErrorMsg(Resources.FileIsNotValid, fileName);
                            break;
                    }
                }
                else
                {
                    FileOpenErrorMsg(Resources.FileNotExist, inputFileInfo == null ? fileName : inputFileInfo.FullName);
                }
            }
            else
            {
                FileOpenErrorMsg(Resources.FileNameIsNotValid, fileName);
            }
            return result;
        }

        private static void FileOpenErrorMsg(string msg, string fileName)
        {
            Msg.Error(string.Format("{0}\n{1}", msg, fileName));
        }

        private void OpenHtmlFile(FileInfo inputFileInfo)
        {
            NavigateToString(WebView21, [.. ReadFromFile(inputFileInfo)]);
        }

        private void OpenTextFile(FileInfo inputFileInfo)
        {
            ShowInTextBox.Clear();
            ShowInTextBox.AppendLines([.. ReadFromFile(inputFileInfo)]);
        }

        #endregion

        #region KeyPress methods

        private void ListBox_Bibles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsPressedEnter(e))
            {
                SetView_Bibles();
            }
        }

        private void ListBox_Books_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsPressedEnter(e))
            {
                SetView_Books();
            }
        }

        private void ListBox_Chapters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsPressedEnter(e))
            {
                SetView_Chapters();
            }
        }

        private void ListBox_Verses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsPressedEnter(e))
            {
                SetView_Verses();
            }
        }

        private static bool IsPressedEnter(KeyPressEventArgs e)
        {
            return e.KeyChar.Equals((char)Keys.Enter);
        }

        #endregion

        #region User's ProgramHome Directory

        private void ToolStripMenuItem_UsersHomeDirectory_Click(object sender, EventArgs e)
        {
            Settings.Default.UserHomeDirectory = SelectDirectory(Settings.Default.UserHomeDirectory);
        }

        private string SelectDirectory(string dirPath)
        {
            DialogResult dResult;
            folderBrowserDialog1.SelectedPath = dirPath;
            dResult = folderBrowserDialog1.ShowDialog();
            if (dResult == DialogResult.OK)
            {
                return folderBrowserDialog1.SelectedPath;
            }
            return dirPath;
        }
        #endregion

        #region User Language

        private int UserLang { get; set; } = 0;
        private void InitUserLanguageListBox()
        {
            ListBox_UserLanguage.Items.AddRange(ProgramLanguage.LangLabel);
        }

        private void SetUserLanguageListBoxSelectedItem()
        {
            if (ListBox_UserLanguage.Items.Count > 0)
            {
                if (UserLang >= 0 && UserLang < ListBox_UserLanguage.Items.Count)
                {
                    ListBox_UserLanguage.SelectedIndex = UserLang;
                }
            }
        }

        private void ListBox_UserLanguage_Click(object sender, EventArgs e)
        {
            SaveUserLanguageFromListBox();
        }

        private void SaveUserLanguageFromListBox()
        {
            if (ListBox_UserLanguage.Items.Count > 0)
            {
                if (ListBox_UserLanguage.SelectedIndex > -1)
                {
                    if (UserLang != ListBox_UserLanguage.SelectedIndex)
                    {
                        UserLang = ListBox_UserLanguage.SelectedIndex;
                        SaveUserLanguage();
                    }
                }
            }
        }

        private void ListBox_UserLanguage_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveUserLanguageFromListBox();
        }

        #endregion

        #region Help

        private void Form_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                OpenHelpFile(string.Empty);
                e.Handled = true;
            }
        }

        private void OpenHelpFile(string goToPart)
        {
            string helpFileText = Resources.HelpFileForBBNE + (string.IsNullOrEmpty(goToPart) ? string.Empty : "/#" + goToPart);
            if (string.IsNullOrEmpty(helpFileText))
            {
                NavigateToString(WebView21, new MessagesHtmlPage().HelpFileNotFoundPage());
            }
            else
            {
                NavigateToString(WebView21, helpFileText);
            }
        }


        private void ToolStripMenuItem_Help_Click(object sender, EventArgs e)
        {
            OpenHelpFile(string.Empty);

        }

        private void ToolStripMenuItem_Contents_Click(object sender, EventArgs e)
        {
            OpenHelpFile("Contents");
        }

        private void ToolStripMenuItem_Index_Click(object sender, EventArgs e)
        {
            OpenHelpFile("Index");
        }

        private void ToolStripMenuItem_Search_Click(object sender, EventArgs e)
        {
            OpenHelpFile("Search");
        }

        #endregion

    }
}
