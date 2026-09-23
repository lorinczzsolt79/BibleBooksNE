namespace BibleBooksNE.ViewAndController.Forms
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            SplitContainer_Selector = new SplitContainer();
            GroupBox_Search = new GroupBox();
            TextBox_PreviousSearchedText = new TextBox();
            Button_Search = new Button();
            TextBox_Search = new TextBox();
            CheckBox_InCheckedAddOnsToo = new CheckBox();
            Label_BibleList = new Label();
            ListBox_Bibles = new ListBox();
            GroupBox_AddOns = new GroupBox();
            CheckBox_Audio = new CheckBox();
            CheckBox_Headlines = new CheckBox();
            CheckBox_Crosslinks = new CheckBox();
            CheckBox_Footnotes = new CheckBox();
            CheckBox_WordList = new CheckBox();
            Label_Book = new Label();
            ListBox_Chapters = new ListBox();
            Label_VerseList = new Label();
            Label_Chapter = new Label();
            ListBox_Books = new ListBox();
            ListBox_Verses = new ListBox();
            MenuStrip_Main = new MenuStrip();
            ToolStripMenuItem_File = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem_Tools = new ToolStripMenuItem();
            customizeToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem_UsersHomeDirectory = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem_Info = new ToolStripMenuItem();
            ToolStripMenuItem_ShowAllDatabaseInfo = new ToolStripMenuItem();
            ToolStripMenuItem_ShowAllProgramSettings = new ToolStripMenuItem();
            ToolStripMenuItem_Help = new ToolStripMenuItem();
            ToolStripMenuItem_Contents = new ToolStripMenuItem();
            ToolStripMenuItem_Index = new ToolStripMenuItem();
            ToolStripMenuItem_Search = new ToolStripMenuItem();
            ToolStripMenuItem_About = new ToolStripMenuItem();
            TabControl_UserInputs = new TabControl();
            TabPage_Selector = new TabPage();
            TabPage_Settings = new TabPage();
            GroupBox_ProgramSettings = new GroupBox();
            CheckBox_ClearTempDirBeforeQuit = new CheckBox();
            GroupBox_TextEditorSettings = new GroupBox();
            CheckBox_WordWrap = new CheckBox();
            CheckBox_SaveStateBeforeClosing = new CheckBox();
            GroupBox_SelectorSettings = new GroupBox();
            CheckBox_SaveSelectorStateBeforeQuit = new CheckBox();
            groupBox_WebPageSettings = new GroupBox();
            ListBox_UserLanguage = new ListBox();
            Label_UsersLanguage = new Label();
            CheckBox_DarkTheme = new CheckBox();
            GroupBox_Sorting = new GroupBox();
            CheckBox_SortingType = new CheckBox();
            CheckBox_JustifyIfPossible = new CheckBox();
            Button_SaveCurrentSettings = new Button();
            Button_ResetDefaultSettings = new Button();
            TabControl_BrowserAndText = new TabControl();
            TabPage_WebView = new TabPage();
            WebView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            TabPage_Text = new TabPage();
            RichTextBox_Text = new RichTextBox();
            toolStripSeparator6 = new ToolStripSeparator();
            Label_Message = new Label();
            ToolStripMenuItem_ShowAllSettings = new ToolStripMenuItem();
            ToolStripMenuItem_ShowAllInfo = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)SplitContainer_Selector).BeginInit();
            SplitContainer_Selector.Panel1.SuspendLayout();
            SplitContainer_Selector.Panel2.SuspendLayout();
            SplitContainer_Selector.SuspendLayout();
            GroupBox_Search.SuspendLayout();
            GroupBox_AddOns.SuspendLayout();
            MenuStrip_Main.SuspendLayout();
            TabControl_UserInputs.SuspendLayout();
            TabPage_Selector.SuspendLayout();
            TabPage_Settings.SuspendLayout();
            GroupBox_ProgramSettings.SuspendLayout();
            GroupBox_TextEditorSettings.SuspendLayout();
            GroupBox_SelectorSettings.SuspendLayout();
            groupBox_WebPageSettings.SuspendLayout();
            GroupBox_Sorting.SuspendLayout();
            TabControl_BrowserAndText.SuspendLayout();
            TabPage_WebView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)WebView21).BeginInit();
            TabPage_Text.SuspendLayout();
            SuspendLayout();
            // 
            // SplitContainer_Selector
            // 
            resources.ApplyResources(SplitContainer_Selector, "SplitContainer_Selector");
            SplitContainer_Selector.Name = "SplitContainer_Selector";
            // 
            // SplitContainer_Selector.Panel1
            // 
            SplitContainer_Selector.Panel1.Controls.Add(GroupBox_Search);
            SplitContainer_Selector.Panel1.Controls.Add(Label_BibleList);
            SplitContainer_Selector.Panel1.Controls.Add(ListBox_Bibles);
            // 
            // SplitContainer_Selector.Panel2
            // 
            SplitContainer_Selector.Panel2.Controls.Add(GroupBox_AddOns);
            SplitContainer_Selector.Panel2.Controls.Add(Label_Book);
            SplitContainer_Selector.Panel2.Controls.Add(ListBox_Chapters);
            SplitContainer_Selector.Panel2.Controls.Add(Label_VerseList);
            SplitContainer_Selector.Panel2.Controls.Add(Label_Chapter);
            SplitContainer_Selector.Panel2.Controls.Add(ListBox_Books);
            SplitContainer_Selector.Panel2.Controls.Add(ListBox_Verses);
            // 
            // GroupBox_Search
            // 
            resources.ApplyResources(GroupBox_Search, "GroupBox_Search");
            GroupBox_Search.Controls.Add(TextBox_PreviousSearchedText);
            GroupBox_Search.Controls.Add(Button_Search);
            GroupBox_Search.Controls.Add(TextBox_Search);
            GroupBox_Search.Controls.Add(CheckBox_InCheckedAddOnsToo);
            GroupBox_Search.Name = "GroupBox_Search";
            GroupBox_Search.TabStop = false;
            // 
            // TextBox_PreviousSearchedText
            // 
            TextBox_PreviousSearchedText.BackColor = SystemColors.Control;
            resources.ApplyResources(TextBox_PreviousSearchedText, "TextBox_PreviousSearchedText");
            TextBox_PreviousSearchedText.Name = "TextBox_PreviousSearchedText";
            TextBox_PreviousSearchedText.ReadOnly = true;
            TextBox_PreviousSearchedText.TabStop = false;
            TextBox_PreviousSearchedText.Click += TextBox_PreviousSearchedText_Click;
            // 
            // Button_Search
            // 
            resources.ApplyResources(Button_Search, "Button_Search");
            Button_Search.Name = "Button_Search";
            Button_Search.UseVisualStyleBackColor = true;
            Button_Search.Click += Button_Search_Click;
            // 
            // TextBox_Search
            // 
            resources.ApplyResources(TextBox_Search, "TextBox_Search");
            TextBox_Search.Name = "TextBox_Search";
            // 
            // CheckBox_InCheckedAddOnsToo
            // 
            resources.ApplyResources(CheckBox_InCheckedAddOnsToo, "CheckBox_InCheckedAddOnsToo");
            CheckBox_InCheckedAddOnsToo.Name = "CheckBox_InCheckedAddOnsToo";
            CheckBox_InCheckedAddOnsToo.UseVisualStyleBackColor = true;
            CheckBox_InCheckedAddOnsToo.CheckStateChanged += CheckBox_InCheckedAddOnsToo_CheckStateChanged;
            // 
            // Label_BibleList
            // 
            resources.ApplyResources(Label_BibleList, "Label_BibleList");
            Label_BibleList.Name = "Label_BibleList";
            // 
            // ListBox_Bibles
            // 
            resources.ApplyResources(ListBox_Bibles, "ListBox_Bibles");
            ListBox_Bibles.FormattingEnabled = true;
            ListBox_Bibles.Name = "ListBox_Bibles";
            ListBox_Bibles.SelectionMode = SelectionMode.MultiExtended;
            ListBox_Bibles.Click += ListBox_Bibles_Click;
            ListBox_Bibles.MouseClick += ListBox_Bibles_MouseClick;
            ListBox_Bibles.SelectedIndexChanged += ListBox_Bibles_SelectedIndexChanged;
            ListBox_Bibles.KeyPress += ListBox_Bibles_KeyPress;
            // 
            // GroupBox_AddOns
            // 
            resources.ApplyResources(GroupBox_AddOns, "GroupBox_AddOns");
            GroupBox_AddOns.Controls.Add(CheckBox_Audio);
            GroupBox_AddOns.Controls.Add(CheckBox_Headlines);
            GroupBox_AddOns.Controls.Add(CheckBox_Crosslinks);
            GroupBox_AddOns.Controls.Add(CheckBox_Footnotes);
            GroupBox_AddOns.Controls.Add(CheckBox_WordList);
            GroupBox_AddOns.Name = "GroupBox_AddOns";
            GroupBox_AddOns.TabStop = false;
            // 
            // CheckBox_Audio
            // 
            resources.ApplyResources(CheckBox_Audio, "CheckBox_Audio");
            CheckBox_Audio.Name = "CheckBox_Audio";
            CheckBox_Audio.UseVisualStyleBackColor = true;
            CheckBox_Audio.CheckedChanged += CheckBox_Audio_CheckedChanged;
            CheckBox_Audio.CheckStateChanged += CheckBox_Audio_CheckStateChanged;
            // 
            // CheckBox_Headlines
            // 
            resources.ApplyResources(CheckBox_Headlines, "CheckBox_Headlines");
            CheckBox_Headlines.Checked = true;
            CheckBox_Headlines.CheckState = CheckState.Checked;
            CheckBox_Headlines.Name = "CheckBox_Headlines";
            CheckBox_Headlines.UseVisualStyleBackColor = true;
            CheckBox_Headlines.CheckedChanged += CheckBox_Headlines_CheckedChanged;
            CheckBox_Headlines.CheckStateChanged += CheckBox_Headlines_CheckStateChanged;
            // 
            // CheckBox_Crosslinks
            // 
            resources.ApplyResources(CheckBox_Crosslinks, "CheckBox_Crosslinks");
            CheckBox_Crosslinks.Checked = true;
            CheckBox_Crosslinks.CheckState = CheckState.Checked;
            CheckBox_Crosslinks.Name = "CheckBox_Crosslinks";
            CheckBox_Crosslinks.UseVisualStyleBackColor = true;
            CheckBox_Crosslinks.CheckedChanged += CheckBox_Crosslinks_CheckedChanged;
            CheckBox_Crosslinks.CheckStateChanged += CheckBox_Crosslinks_CheckStateChanged;
            // 
            // CheckBox_Footnotes
            // 
            resources.ApplyResources(CheckBox_Footnotes, "CheckBox_Footnotes");
            CheckBox_Footnotes.Checked = true;
            CheckBox_Footnotes.CheckState = CheckState.Checked;
            CheckBox_Footnotes.Name = "CheckBox_Footnotes";
            CheckBox_Footnotes.UseVisualStyleBackColor = true;
            CheckBox_Footnotes.CheckedChanged += CheckBox_Footnotes_CheckedChanged;
            CheckBox_Footnotes.CheckStateChanged += CheckBox_Footnotes_CheckStateChanged;
            // 
            // CheckBox_WordList
            // 
            resources.ApplyResources(CheckBox_WordList, "CheckBox_WordList");
            CheckBox_WordList.Name = "CheckBox_WordList";
            CheckBox_WordList.UseVisualStyleBackColor = true;
            CheckBox_WordList.CheckedChanged += CheckBox_WordsList_CheckedChanged;
            CheckBox_WordList.CheckStateChanged += CheckBox_WordList_CheckStateChanged;
            // 
            // Label_Book
            // 
            resources.ApplyResources(Label_Book, "Label_Book");
            Label_Book.Name = "Label_Book";
            // 
            // ListBox_Chapters
            // 
            resources.ApplyResources(ListBox_Chapters, "ListBox_Chapters");
            ListBox_Chapters.FormattingEnabled = true;
            ListBox_Chapters.Name = "ListBox_Chapters";
            ListBox_Chapters.Click += ListBox_Chapters_Click;
            ListBox_Chapters.KeyPress += ListBox_Chapters_KeyPress;
            // 
            // Label_VerseList
            // 
            resources.ApplyResources(Label_VerseList, "Label_VerseList");
            Label_VerseList.Name = "Label_VerseList";
            // 
            // Label_Chapter
            // 
            resources.ApplyResources(Label_Chapter, "Label_Chapter");
            Label_Chapter.Name = "Label_Chapter";
            // 
            // ListBox_Books
            // 
            resources.ApplyResources(ListBox_Books, "ListBox_Books");
            ListBox_Books.FormattingEnabled = true;
            ListBox_Books.Name = "ListBox_Books";
            ListBox_Books.Click += ListBox_Books_Click;
            ListBox_Books.KeyPress += ListBox_Books_KeyPress;
            // 
            // ListBox_Verses
            // 
            resources.ApplyResources(ListBox_Verses, "ListBox_Verses");
            ListBox_Verses.FormattingEnabled = true;
            ListBox_Verses.Name = "ListBox_Verses";
            ListBox_Verses.Click += ListBox_Verses_Click;
            ListBox_Verses.KeyPress += ListBox_Verses_KeyPress;
            // 
            // MenuStrip_Main
            // 
            resources.ApplyResources(MenuStrip_Main, "MenuStrip_Main");
            MenuStrip_Main.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem_File, ToolStripMenuItem_Tools, ToolStripMenuItem_Info, ToolStripMenuItem_Help, ToolStripMenuItem_About });
            MenuStrip_Main.Name = "MenuStrip_Main";
            // 
            // ToolStripMenuItem_File
            // 
            ToolStripMenuItem_File.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            ToolStripMenuItem_File.Name = "ToolStripMenuItem_File";
            resources.ApplyResources(ToolStripMenuItem_File, "ToolStripMenuItem_File");
            // 
            // newToolStripMenuItem
            // 
            resources.ApplyResources(newToolStripMenuItem, "newToolStripMenuItem");
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            // 
            // openToolStripMenuItem
            // 
            resources.ApplyResources(openToolStripMenuItem, "openToolStripMenuItem");
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(toolStripSeparator, "toolStripSeparator");
            // 
            // saveToolStripMenuItem
            // 
            resources.ApplyResources(saveToolStripMenuItem, "saveToolStripMenuItem");
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            resources.ApplyResources(saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(exitToolStripMenuItem, "exitToolStripMenuItem");
            exitToolStripMenuItem.Click += ToolStripMenuItem_Exit_Click;
            // 
            // ToolStripMenuItem_Tools
            // 
            ToolStripMenuItem_Tools.DropDownItems.AddRange(new ToolStripItem[] { customizeToolStripMenuItem, optionsToolStripMenuItem });
            ToolStripMenuItem_Tools.Name = "ToolStripMenuItem_Tools";
            resources.ApplyResources(ToolStripMenuItem_Tools, "ToolStripMenuItem_Tools");
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_UsersHomeDirectory });
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            resources.ApplyResources(customizeToolStripMenuItem, "customizeToolStripMenuItem");
            // 
            // ToolStripMenuItem_UsersHomeDirectory
            // 
            ToolStripMenuItem_UsersHomeDirectory.Name = "ToolStripMenuItem_UsersHomeDirectory";
            resources.ApplyResources(ToolStripMenuItem_UsersHomeDirectory, "ToolStripMenuItem_UsersHomeDirectory");
            ToolStripMenuItem_UsersHomeDirectory.Click += ToolStripMenuItem_UsersHomeDirectory_Click;
            // 
            // optionsToolStripMenuItem
            // 
            resources.ApplyResources(optionsToolStripMenuItem, "optionsToolStripMenuItem");
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Click += OptionsToolStripMenuItem_Click;
            // 
            // ToolStripMenuItem_Info
            // 
            ToolStripMenuItem_Info.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_ShowAllDatabaseInfo, ToolStripMenuItem_ShowAllProgramSettings });
            ToolStripMenuItem_Info.Name = "ToolStripMenuItem_Info";
            resources.ApplyResources(ToolStripMenuItem_Info, "ToolStripMenuItem_Info");
            // 
            // ToolStripMenuItem_ShowAllDatabaseInfo
            // 
            ToolStripMenuItem_ShowAllDatabaseInfo.Name = "ToolStripMenuItem_ShowAllDatabaseInfo";
            resources.ApplyResources(ToolStripMenuItem_ShowAllDatabaseInfo, "ToolStripMenuItem_ShowAllDatabaseInfo");
            ToolStripMenuItem_ShowAllDatabaseInfo.Click += ToolStripMenuItem_ShowAllDatabaseInfo_Click;
            // 
            // ToolStripMenuItem_ShowAllProgramSettings
            // 
            ToolStripMenuItem_ShowAllProgramSettings.Name = "ToolStripMenuItem_ShowAllProgramSettings";
            resources.ApplyResources(ToolStripMenuItem_ShowAllProgramSettings, "ToolStripMenuItem_ShowAllProgramSettings");
            ToolStripMenuItem_ShowAllProgramSettings.Click += ToolStripMenuItem_ShowAllSettings_Click;
            // 
            // ToolStripMenuItem_Help
            // 
            ToolStripMenuItem_Help.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_Contents, ToolStripMenuItem_Index, ToolStripMenuItem_Search });
            ToolStripMenuItem_Help.Name = "ToolStripMenuItem_Help";
            resources.ApplyResources(ToolStripMenuItem_Help, "ToolStripMenuItem_Help");
            ToolStripMenuItem_Help.Click += ToolStripMenuItem_Help_Click;
            // 
            // ToolStripMenuItem_Contents
            // 
            resources.ApplyResources(ToolStripMenuItem_Contents, "ToolStripMenuItem_Contents");
            ToolStripMenuItem_Contents.Name = "ToolStripMenuItem_Contents";
            ToolStripMenuItem_Contents.Click += ToolStripMenuItem_Contents_Click;
            // 
            // ToolStripMenuItem_Index
            // 
            resources.ApplyResources(ToolStripMenuItem_Index, "ToolStripMenuItem_Index");
            ToolStripMenuItem_Index.Name = "ToolStripMenuItem_Index";
            ToolStripMenuItem_Index.Click += ToolStripMenuItem_Index_Click;
            // 
            // ToolStripMenuItem_Search
            // 
            resources.ApplyResources(ToolStripMenuItem_Search, "ToolStripMenuItem_Search");
            ToolStripMenuItem_Search.Name = "ToolStripMenuItem_Search";
            ToolStripMenuItem_Search.Click += ToolStripMenuItem_Search_Click;
            // 
            // ToolStripMenuItem_About
            // 
            ToolStripMenuItem_About.Name = "ToolStripMenuItem_About";
            resources.ApplyResources(ToolStripMenuItem_About, "ToolStripMenuItem_About");
            ToolStripMenuItem_About.Click += ToolStripMenuItem_About_Click;
            // 
            // TabControl_UserInputs
            // 
            resources.ApplyResources(TabControl_UserInputs, "TabControl_UserInputs");
            TabControl_UserInputs.Controls.Add(TabPage_Selector);
            TabControl_UserInputs.Controls.Add(TabPage_Settings);
            TabControl_UserInputs.Name = "TabControl_UserInputs";
            TabControl_UserInputs.SelectedIndex = 0;
            // 
            // TabPage_Selector
            // 
            TabPage_Selector.Controls.Add(SplitContainer_Selector);
            resources.ApplyResources(TabPage_Selector, "TabPage_Selector");
            TabPage_Selector.Name = "TabPage_Selector";
            TabPage_Selector.UseVisualStyleBackColor = true;
            // 
            // TabPage_Settings
            // 
            TabPage_Settings.Controls.Add(GroupBox_ProgramSettings);
            TabPage_Settings.Controls.Add(groupBox_WebPageSettings);
            TabPage_Settings.Controls.Add(Button_SaveCurrentSettings);
            TabPage_Settings.Controls.Add(Button_ResetDefaultSettings);
            resources.ApplyResources(TabPage_Settings, "TabPage_Settings");
            TabPage_Settings.Name = "TabPage_Settings";
            TabPage_Settings.UseVisualStyleBackColor = true;
            // 
            // GroupBox_ProgramSettings
            // 
            resources.ApplyResources(GroupBox_ProgramSettings, "GroupBox_ProgramSettings");
            GroupBox_ProgramSettings.Controls.Add(CheckBox_ClearTempDirBeforeQuit);
            GroupBox_ProgramSettings.Controls.Add(GroupBox_TextEditorSettings);
            GroupBox_ProgramSettings.Controls.Add(CheckBox_SaveStateBeforeClosing);
            GroupBox_ProgramSettings.Controls.Add(GroupBox_SelectorSettings);
            GroupBox_ProgramSettings.Name = "GroupBox_ProgramSettings";
            GroupBox_ProgramSettings.TabStop = false;
            // 
            // CheckBox_ClearTempDirBeforeQuit
            // 
            resources.ApplyResources(CheckBox_ClearTempDirBeforeQuit, "CheckBox_ClearTempDirBeforeQuit");
            CheckBox_ClearTempDirBeforeQuit.Checked = true;
            CheckBox_ClearTempDirBeforeQuit.CheckState = CheckState.Checked;
            CheckBox_ClearTempDirBeforeQuit.Name = "CheckBox_ClearTempDirBeforeQuit";
            CheckBox_ClearTempDirBeforeQuit.UseVisualStyleBackColor = true;
            CheckBox_ClearTempDirBeforeQuit.CheckedChanged += CheckBox_ClearTempDirBeforeQuit_CheckedChanged;
            // 
            // GroupBox_TextEditorSettings
            // 
            GroupBox_TextEditorSettings.Controls.Add(CheckBox_WordWrap);
            resources.ApplyResources(GroupBox_TextEditorSettings, "GroupBox_TextEditorSettings");
            GroupBox_TextEditorSettings.Name = "GroupBox_TextEditorSettings";
            GroupBox_TextEditorSettings.TabStop = false;
            // 
            // CheckBox_WordWrap
            // 
            resources.ApplyResources(CheckBox_WordWrap, "CheckBox_WordWrap");
            CheckBox_WordWrap.Name = "CheckBox_WordWrap";
            CheckBox_WordWrap.UseVisualStyleBackColor = true;
            CheckBox_WordWrap.CheckedChanged += CheckBox_WordWrap_CheckedChanged;
            CheckBox_WordWrap.CheckStateChanged += CheckBox_WordWrap_CheckStateChanged;
            // 
            // CheckBox_SaveStateBeforeClosing
            // 
            CheckBox_SaveStateBeforeClosing.Checked = true;
            CheckBox_SaveStateBeforeClosing.CheckState = CheckState.Checked;
            resources.ApplyResources(CheckBox_SaveStateBeforeClosing, "CheckBox_SaveStateBeforeClosing");
            CheckBox_SaveStateBeforeClosing.Name = "CheckBox_SaveStateBeforeClosing";
            CheckBox_SaveStateBeforeClosing.UseVisualStyleBackColor = true;
            CheckBox_SaveStateBeforeClosing.CheckStateChanged += CheckBox_SaveStateBeforeClosing_CheckStateChanged;
            // 
            // GroupBox_SelectorSettings
            // 
            GroupBox_SelectorSettings.Controls.Add(CheckBox_SaveSelectorStateBeforeQuit);
            resources.ApplyResources(GroupBox_SelectorSettings, "GroupBox_SelectorSettings");
            GroupBox_SelectorSettings.Name = "GroupBox_SelectorSettings";
            GroupBox_SelectorSettings.TabStop = false;
            // 
            // CheckBox_SaveReaderStateBeforeQuit
            // 
            resources.ApplyResources(CheckBox_SaveSelectorStateBeforeQuit, "CheckBox_SaveReaderStateBeforeQuit");
            CheckBox_SaveSelectorStateBeforeQuit.Name = "CheckBox_SaveReaderStateBeforeQuit";
            CheckBox_SaveSelectorStateBeforeQuit.UseVisualStyleBackColor = true;
            CheckBox_SaveSelectorStateBeforeQuit.CheckStateChanged += CheckBox_SaveReaderStateBeforeQuit_CheckStateChanged;
            // 
            // groupBox_WebPageSettings
            // 
            groupBox_WebPageSettings.Controls.Add(ListBox_UserLanguage);
            groupBox_WebPageSettings.Controls.Add(Label_UsersLanguage);
            groupBox_WebPageSettings.Controls.Add(CheckBox_DarkTheme);
            groupBox_WebPageSettings.Controls.Add(GroupBox_Sorting);
            groupBox_WebPageSettings.Controls.Add(CheckBox_JustifyIfPossible);
            resources.ApplyResources(groupBox_WebPageSettings, "groupBox_WebPageSettings");
            groupBox_WebPageSettings.Name = "groupBox_WebPageSettings";
            groupBox_WebPageSettings.TabStop = false;
            // 
            // ListBox_UserLanguage
            // 
            ListBox_UserLanguage.FormattingEnabled = true;
            resources.ApplyResources(ListBox_UserLanguage, "ListBox_UserLanguage");
            ListBox_UserLanguage.Name = "ListBox_UserLanguage";
            ListBox_UserLanguage.Click += ListBox_UserLanguage_Click;
            ListBox_UserLanguage.KeyPress += ListBox_UserLanguage_KeyPress;
            // 
            // Label_UsersLanguage
            // 
            resources.ApplyResources(Label_UsersLanguage, "Label_UsersLanguage");
            Label_UsersLanguage.Name = "Label_UsersLanguage";
            // 
            // CheckBox_DarkTheme
            // 
            resources.ApplyResources(CheckBox_DarkTheme, "CheckBox_DarkTheme");
            CheckBox_DarkTheme.Name = "CheckBox_DarkTheme";
            CheckBox_DarkTheme.UseVisualStyleBackColor = true;
            CheckBox_DarkTheme.CheckedChanged += CheckBox_DarkTheme_CheckedChanged;
            // 
            // GroupBox_Sorting
            // 
            GroupBox_Sorting.Controls.Add(CheckBox_SortingType);
            resources.ApplyResources(GroupBox_Sorting, "GroupBox_Sorting");
            GroupBox_Sorting.Name = "GroupBox_Sorting";
            GroupBox_Sorting.TabStop = false;
            // 
            // CheckBox_SortingType
            // 
            resources.ApplyResources(CheckBox_SortingType, "CheckBox_SortingType");
            CheckBox_SortingType.Name = "CheckBox_SortingType";
            CheckBox_SortingType.UseVisualStyleBackColor = true;
            CheckBox_SortingType.CheckedChanged += CheckBox_SortingType_CheckedChanged;
            // 
            // CheckBox_JustifyIfPossible
            // 
            resources.ApplyResources(CheckBox_JustifyIfPossible, "CheckBox_JustifyIfPossible");
            CheckBox_JustifyIfPossible.Name = "CheckBox_JustifyIfPossible";
            CheckBox_JustifyIfPossible.UseVisualStyleBackColor = true;
            CheckBox_JustifyIfPossible.CheckedChanged += CheckBox_JustifyIfPossible_CheckedChanged;
            // 
            // Button_SaveCurrentSettings
            // 
            resources.ApplyResources(Button_SaveCurrentSettings, "Button_SaveCurrentSettings");
            Button_SaveCurrentSettings.Name = "Button_SaveCurrentSettings";
            Button_SaveCurrentSettings.UseVisualStyleBackColor = true;
            Button_SaveCurrentSettings.Click += Button_SaveCurrentSettings_Click;
            // 
            // Button_ResetDefaultSettings
            // 
            resources.ApplyResources(Button_ResetDefaultSettings, "Button_ResetDefaultSettings");
            Button_ResetDefaultSettings.Name = "Button_ResetDefaultSettings";
            Button_ResetDefaultSettings.UseVisualStyleBackColor = true;
            Button_ResetDefaultSettings.Click += Button_ResetDefaultSettings_Click;
            // 
            // TabControl_BrowserAndText
            // 
            resources.ApplyResources(TabControl_BrowserAndText, "TabControl_BrowserAndText");
            TabControl_BrowserAndText.Controls.Add(TabPage_WebView);
            TabControl_BrowserAndText.Controls.Add(TabPage_Text);
            TabControl_BrowserAndText.Name = "TabControl_BrowserAndText";
            TabControl_BrowserAndText.SelectedIndex = 0;
            // 
            // TabPage_WebView
            // 
            TabPage_WebView.Controls.Add(WebView21);
            resources.ApplyResources(TabPage_WebView, "TabPage_WebView");
            TabPage_WebView.Name = "TabPage_WebView";
            TabPage_WebView.UseVisualStyleBackColor = true;
            // 
            // WebView21
            // 
            WebView21.AllowExternalDrop = true;
            WebView21.CreationProperties = null;
            WebView21.DefaultBackgroundColor = Color.White;
            resources.ApplyResources(WebView21, "WebView21");
            WebView21.Name = "WebView21";
            WebView21.ZoomFactor = 1D;
            WebView21.CoreWebView2InitializationCompleted += WebView21_CoreWebView2InitializationCompleted;
            WebView21.NavigationStarting += WebView21_NavigationStarting;
            WebView21.NavigationCompleted += WebView21_NavigationCompleted;
            WebView21.WebMessageReceived += WebView21_WebMessageReceived;
            // 
            // TabPage_Text
            // 
            TabPage_Text.Controls.Add(RichTextBox_Text);
            resources.ApplyResources(TabPage_Text, "TabPage_Text");
            TabPage_Text.Name = "TabPage_Text";
            TabPage_Text.UseVisualStyleBackColor = true;
            // 
            // RichTextBox_Text
            // 
            resources.ApplyResources(RichTextBox_Text, "RichTextBox_Text");
            RichTextBox_Text.Name = "RichTextBox_Text";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(toolStripSeparator6, "toolStripSeparator6");
            // 
            // Label_Message
            // 
            resources.ApplyResources(Label_Message, "Label_Message");
            Label_Message.Name = "Label_Message";
            Label_Message.Click += Label_Message_Click;
            // 
            // ToolStripMenuItem_ShowAllSettings
            // 
            ToolStripMenuItem_ShowAllSettings.Name = "ToolStripMenuItem_ShowAllSettings";
            resources.ApplyResources(ToolStripMenuItem_ShowAllSettings, "ToolStripMenuItem_ShowAllSettings");
            // 
            // ToolStripMenuItem_ShowAllInfo
            // 
            ToolStripMenuItem_ShowAllInfo.Name = "ToolStripMenuItem_ShowAllInfo";
            resources.ApplyResources(ToolStripMenuItem_ShowAllInfo, "ToolStripMenuItem_ShowAllInfo");
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "txt";
            // 
            // Form_Main
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Label_Message);
            Controls.Add(TabControl_BrowserAndText);
            Controls.Add(TabControl_UserInputs);
            Controls.Add(MenuStrip_Main);
            HelpButton = true;
            KeyPreview = true;
            MainMenuStrip = MenuStrip_Main;
            Name = "Form_Main";
            FormClosing += Form_Main_FormClosing;
            KeyDown += Form_Main_KeyDown;
            SplitContainer_Selector.Panel1.ResumeLayout(false);
            SplitContainer_Selector.Panel1.PerformLayout();
            SplitContainer_Selector.Panel2.ResumeLayout(false);
            SplitContainer_Selector.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainer_Selector).EndInit();
            SplitContainer_Selector.ResumeLayout(false);
            GroupBox_Search.ResumeLayout(false);
            GroupBox_Search.PerformLayout();
            GroupBox_AddOns.ResumeLayout(false);
            GroupBox_AddOns.PerformLayout();
            MenuStrip_Main.ResumeLayout(false);
            MenuStrip_Main.PerformLayout();
            TabControl_UserInputs.ResumeLayout(false);
            TabPage_Selector.ResumeLayout(false);
            TabPage_Settings.ResumeLayout(false);
            GroupBox_ProgramSettings.ResumeLayout(false);
            GroupBox_ProgramSettings.PerformLayout();
            GroupBox_TextEditorSettings.ResumeLayout(false);
            GroupBox_TextEditorSettings.PerformLayout();
            GroupBox_SelectorSettings.ResumeLayout(false);
            GroupBox_SelectorSettings.PerformLayout();
            groupBox_WebPageSettings.ResumeLayout(false);
            groupBox_WebPageSettings.PerformLayout();
            GroupBox_Sorting.ResumeLayout(false);
            GroupBox_Sorting.PerformLayout();
            TabControl_BrowserAndText.ResumeLayout(false);
            TabPage_WebView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)WebView21).EndInit();
            TabPage_Text.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Tools;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Contents;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Index;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Search;
        private System.Windows.Forms.TabControl TabControl_BrowserAndText;
        private System.Windows.Forms.TabPage TabPage_WebView;
        private System.Windows.Forms.CheckBox CheckBox_Footnotes;
        private System.Windows.Forms.CheckBox CheckBox_Crosslinks;
        private System.Windows.Forms.CheckBox CheckBox_Headlines;
        private System.Windows.Forms.CheckBox CheckBox_WordList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.TabControl TabControl_UserInputs;
        private System.Windows.Forms.TabPage TabPage_Selector;
        private System.Windows.Forms.RichTextBox RichTextBox_Text;
        private System.Windows.Forms.TabPage TabPage_Settings;
        private System.Windows.Forms.TabPage TabPage_Text;
        private System.Windows.Forms.CheckBox CheckBox_Audio;
        private System.Windows.Forms.GroupBox GroupBox_AddOns;
        private System.Windows.Forms.GroupBox GroupBox_TextEditorSettings;
        private System.Windows.Forms.CheckBox CheckBox_WordWrap;
        private System.Windows.Forms.Label Label_Message;
        private Microsoft.Web.WebView2.WinForms.WebView2 WebView21;
        private System.Windows.Forms.ListBox ListBox_Verses;
        private System.Windows.Forms.ListBox ListBox_Books;
        private System.Windows.Forms.ListBox ListBox_Bibles;
        private System.Windows.Forms.ListBox ListBox_Chapters;
        private System.Windows.Forms.GroupBox GroupBox_SelectorSettings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ShowAllSettings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ShowAllInfo;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Info;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ShowAllDatabaseInfo;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ShowAllProgramSettings;
        private System.Windows.Forms.Label Label_VerseList;
        private System.Windows.Forms.TextBox TextBox_Search;
        private System.Windows.Forms.Button Button_Search;
        private System.Windows.Forms.GroupBox GroupBox_ProgramSettings;
        private System.Windows.Forms.CheckBox CheckBox_InCheckedAddOnsToo;
        private System.Windows.Forms.TextBox TextBox_PreviousSearchedText;
        private System.Windows.Forms.Label Label_Chapter;
        private System.Windows.Forms.Label Label_Book;
        private System.Windows.Forms.Label Label_BibleList;
        private System.Windows.Forms.CheckBox CheckBox_SaveStateBeforeClosing;
        private System.Windows.Forms.Button Button_SaveCurrentSettings;
        private System.Windows.Forms.CheckBox CheckBox_SaveSelectorStateBeforeQuit;
        private System.Windows.Forms.Button Button_ResetDefaultSettings;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_UsersHomeDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private GroupBox GroupBox_Sorting;
        private CheckBox CheckBox_SortingType;
        private GroupBox groupBox_WebPageSettings;
        private CheckBox CheckBox_JustifyIfPossible;
        private CheckBox CheckBox_DarkTheme;
        private CheckBox CheckBox_ClearTempDirBeforeQuit;
        private ListBox ListBox_UserLanguage;
        private SplitContainer SplitContainer_Selector;
        private GroupBox GroupBox_Search;
        private ToolStripMenuItem ToolStripMenuItem_About;
        private Label Label_UsersLanguage;
        private ToolTip toolTip1;
    }
}

