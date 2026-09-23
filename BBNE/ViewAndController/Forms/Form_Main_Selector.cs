using BibleBooksNE.Model;
using BibleBooksNE.Model.Database;
using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;
using BibleBooksNE.Model.Other;
using BibleBooksNE.Model.VerseTypes;
using BibleBooksNE.Persistency.Files;
using BibleBooksNE.Persistency.Html.HtmlMessages;
using BibleBooksNE.Persistency.Html.WebPages;
using BibleBooksNE.Properties;
using BibleBooksNE.ViewAndController.Navigation;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace BibleBooksNE.ViewAndController.Forms
{
    partial class Form_Main
    {

        #region Selector Methods

        private void SetView()
        {
            SetBibleList();
            SetBookList();
            SetChapterList();
            SetVerseList();
            ShowBiblePage();
        }

        private void SetView(PageOrder order)
        {
            SetUserActions();
            SetListBoxes(order);
            ShowBiblePage();
        }

        private void SetUserActions()
        {
            SetSelectedItems();
            SetAddOnsState();
        }

        private void SetSelectedItems()
        {
            UserAction.SelectedBibleIndex = GetSelectedItem(ListBox_Bibles);
            UserAction.SelectedBibleIndices = GetSelectedItems(ListBox_Bibles);
            UserAction.SelectedBookIndex = GetSelectedItem(ListBox_Books);
            UserAction.SelectedChapterIndex = GetSelectedItem(ListBox_Chapters);
            UserAction.SelectedVerseIndex = GetSelectedItem(ListBox_Verses);
        }

        private void SetAddOnsState()
        {
            UserAction.WithHeadlines = CheckBox_Headlines.Checked;
            UserAction.WithCrosslinks = CheckBox_Crosslinks.Checked;
            UserAction.WithFootnotes = CheckBox_Footnotes.Checked;
            UserAction.WithWordlist = CheckBox_WordList.Checked;
            UserAction.WithAudios = CheckBox_Audio.Checked;
        }

        private static int GetSelectedItem(ListBox listBox)
        {
            if (listBox != null)
            {
                if (listBox.SelectedIndex == 0)
                {
                    return 0;
                }
                if (listBox.SelectedIndex > 0)
                {
                    object? item = listBox.SelectedItem;
                    string? str = string.Empty;
                    if (item != null)
                    {
                        str = item.ToString();
                        str ??= string.Empty;
                    }
                    return new NumberedListBoxItem().Parse(str).Number;
                }
            }
            return -1;
        }

        private static int[] GetSelectedItems(ListBox listBox)
        {
            if (listBox.SelectedIndices.Count > 0)
            {
                return [.. from item
                        in new NumberedListBoxItem().Parse([.. listBox.SelectedItems.Cast<string>()] )
                        where item.Number > 0
                        select item.Number];
            }
            return [];
        }

        private void SetListBoxes(PageOrder order)
        {
            switch (order)
            {
                case PageOrder.bible:
                    {
                        if (UserAction.SelectedBibleIndex < 1)
                        {
                            ClearBookListItems();
                            ClearChapterListItems();
                            ClearVerseListItems();
                        }
                        SetBookList();
                        SetChapterList();
                        SetVerseList();
                        break;
                    }
                case PageOrder.book:
                    {
                        if (UserAction.SelectedBookIndex < 1 || UserAction.BookIdChanged)
                        {
                            ClearChapterListItems();
                            ClearVerseListItems();
                        }
                        SetChapterList();
                        SetVerseList();
                        break;
                    }
                case PageOrder.chapter:
                    {
                        if (UserAction.SelectedChapterIndex < 1 || UserAction.ChapterIdChanged)
                        {
                            ClearVerseListItems();
                        }
                        SetVerseList();
                        break;
                    }
                default: break;
            }
        }

        #endregion

        #region Selector Setters

        private IEnumerable<int> GetBibleNumbers()
        {
            foreach (DatabaseInfo databaseInfo in AllDatabases.GetDatabases())
            {
                yield return databaseInfo.Info.BibleNames.Id.N;
            }
        }

        private void SetBibleList()
        {
            if (AllDatabases.Size > 0)
            {
                AddRangeToListBox(ListBox_Bibles, Name_Formatter.GetNumberedBibleNames([.. GetBibleNumbers()], NameType.long_name));
                SetSelectedItem(ListBox_Bibles, UserAction.SelectedBibleIndices);
            }
            else
            {
                NavigateToString(WebView21, new MessagesHtmlPage().NotFoundHtmlPage(PageOrder.bible));
            }
        }

        private void SetBookList()
        {
            if (UserAction.BibleIdChanged)
            {
                if (UserAction.SelectedBibleIndex > 0)
                {
                    var dbi = AllDatabases.GetDatabase(UserAction.SelectedBibleIndex);
                    if (dbi != null)
                    {
                        int[] bookNumbers = dbi.GetBookNumbers();
                        if (bookNumbers.Length > 0)
                        {
                            AddRangeToListBox(ListBox_Books,
                                Name_Formatter.GetNumberedBookNames(UserAction.SelectedBibleIndex, bookNumbers, NameType.long_name));
                            SetSelectedItem(ListBox_Books, UserAction.SelectedBookIndex);
                        }
                        else
                        {
                            NavigateToString(WebView21, new MessagesHtmlPage().NotFoundHtmlPage(PageOrder.book));
                        }
                    }
                }
            }
        }

        private void SetChapterList()
        {
            if (UserAction.BookIdChanged)
            {
                if (UserAction.SelectedBookIndex > 0)
                {
                    var dbi = AllDatabases.GetDatabase(UserAction.SelectedBibleIndex);
                    if (dbi != null)
                    {
                        int[] chapterNumbers = dbi.GetChapterNumbers(UserAction.SelectedBookIndex);
                        if (chapterNumbers.Length > 0)
                        {
                            AddRangeToListBox(ListBox_Chapters,
                                Name_Formatter.GetNumberedBookNames(0, chapterNumbers, NameType.none));
                            SetSelectedItem(ListBox_Chapters, UserAction.SelectedChapterIndex);
                        }
                        else
                        {
                            NavigateToString(WebView21, new MessagesHtmlPage().NotFoundHtmlPage(PageOrder.chapter));
                        }
                    }
                }
            }
        }

        private void SetVerseList()
        {
            if (UserAction.ChapterIdChanged)
            {
                if (UserAction.SelectedChapterIndex > 0)
                {
                    var dbi = AllDatabases.GetDatabase(UserAction.SelectedBibleIndex);
                    if (dbi != null)
                    {
                        int[] verseNumbers = dbi.GetVerseNumbers(UserAction.SelectedBookIndex, UserAction.SelectedChapterIndex);
                        if (verseNumbers.Length > 0)
                        {
                            AddRangeToListBox(ListBox_Verses,
                                Name_Formatter.GetNumberedBookNames(0, verseNumbers, NameType.none));
                            SetSelectedItem(ListBox_Verses, UserAction.SelectedVerseIndex);
                        }
                        else
                        {
                            NavigateToString(WebView21, new MessagesHtmlPage().NotFoundHtmlPage(PageOrder.verse_item));
                        }
                    }
                }
            }
        }

        private static void AddRangeToListBox(ListBox listBox, object[] items)
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(items);
        }

        private static void SetSelectedItem(ListBox listBox, int[] selectedIndices)
        {
            if (listBox.Items.Count > 0 && selectedIndices.Length > 0)
            {
                for (int i = 0; i < listBox.Items.Count; i++)
                {

                    object v = listBox.Items[i];
                    string? item = v.ToString();
                    item ??= string.Empty;
                    foreach (int index in selectedIndices)
                    {
                        if (item.StartsWith(index.ToString() + '.'))
                        {
                            listBox.SetSelected(i, true);
                        }
                    }
                }
            }
        }

        private static void SetSelectedItem(ListBox listBox, int selectedIndex)
        {
            SetSelectedItem(listBox, [selectedIndex]);
        }

        private void ClearBookListItems()
        {
            UserAction.SelectedBookIndex = -1;
            ListBox_Books.Items.Clear();
        }

        private void ClearChapterListItems()
        {
            UserAction.SelectedChapterIndex = -1;
            ListBox_Chapters.Items.Clear();

        }

        private void ClearVerseListItems()
        {
            UserAction.SelectedVerseIndex = -1;
            ListBox_Verses.Items.Clear();
        }

        #endregion

        #region Web Page Selection

        private void ShowBiblePage()
        {

            if (UserAction.SomethingChanged)
            {
                if (UserAction.BibleBookChapterAndVerseChanged)
                {
                    if (UserAction.BibleBookChapterChanged)
                    {
                        if (UserAction.SelectedBibleIndex < 1)
                        {
                            NavigateToString(WebView21, new MessagesHtmlPage().SelectSomethingHtmlPage(PageOrder.bible));
                        }
                        else
                        {
                            if (UserAction.SelectedBookIndex < 1)
                            {
                                NavigateToString(WebView21, new MessagesHtmlPage().SelectSomethingHtmlPage(PageOrder.book));
                            }
                            else
                            {
                                if (UserAction.SelectedChapterIndex < 1)
                                {
                                    NavigateToString(WebView21, new MessagesHtmlPage().SelectSomethingHtmlPage(PageOrder.chapter));
                                }
                                else
                                {
                                    VerseHtmlPage();
                                }
                            }
                        }
                    }
                    else
                    {
                        TrySetIdOnWebPage();
                    }
                }
                else
                {
                    if (UserAction.AddOnsChanged)
                    {
                        if (UserAction.SelectedBibleIndex > 0 &&
                            UserAction.SelectedBookIndex > 0 &&
                            UserAction.SelectedChapterIndex > 0
                            )
                        {
                            VerseHtmlPage();
                        }
                    }
                }
            }
        }

        #endregion

        #region Show Web Page

        private void VerseHtmlPage()
        {
            GetVerseTypeWebPage(UserAction.GetIdsWithOrders());
        }

        private void GetVerseTypeWebPage(IdsWithOrders idsWithOrders)
        {
            if (!idsWithOrders.Empty)
            {
                NavigateToPage(GetVerseTypeWebPage(VerseTypeList_Handler.Refresh(idsWithOrders), string.Empty));
            }
        }

        private string GetVerseTypeWebPage(VerseTypeListDictionaries dic, string searchedText)
        {
            VersesHtmlFileMaker versesHtmlFileMaker = new(dic, Name_Formatter, searchedText)
            {
                ProgramValues = GetProgramValues(),
                UserLanguage = UserLang
            };
            if (versesHtmlFileMaker != null)
            {
                return versesHtmlFileMaker.Build();
            }
            return string.Empty;
        }

        private void SearchHtmlPage()
        {
            if (!string.IsNullOrWhiteSpace(SearchedText) && !(UserAction.SelectedBibleIndices.Length == 1 && UserAction.SelectedBibleIndex == 0))
            {
                PreviousSearchedText = SearchedText;
                Search_Handler.WithAddOns = CheckBox_InCheckedAddOnsToo.Checked;
                VerseTypeListDictionaries dic = Search_Handler.Search(
                    UserAction.GetIdsWithOrdersForSearch(CheckBox_InCheckedAddOnsToo.Checked), SearchedText);
                NavigateToPage(GetVerseTypeWebPage(dic, Search_Handler.SearchedText));
                SearchedText = string.Empty;
            }
        }

        private static string[] GetProgramValues()
        {
            return [DT.NowHU, Assemblies.AssemblyProduct, Assemblies.AssemblyVersion];
        }

        #endregion

        #region Simple Pages

        private void UserActionPage()
        {
            NavigateToString(WebView21, new MessagesHtmlPage().UserActionHtmlPage(UserAction));
        }

        #endregion

        #region Navigation

        private void NavigateToString(WebView2 webView2, string[] htmlDocumentTextArray)
        {
            Navigate(webView2, string.Join(Environment.NewLine, htmlDocumentTextArray), false);
        }

        private void NavigateToString(WebView2 webView2, string htmlContent)
        {
            Navigate(webView2, htmlContent, false);
        }

        private void Navigate(string url, WebView2 webView2)
        {
            Navigate(webView2, url, true);
        }

        private void Navigate(WebView2 webView2, string str, bool isUrl)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (webView2 != null && webView2.CoreWebView2 != null)
                {
                    try
                    {
                        if (isUrl)
                        {
                            webView2.CoreWebView2.Navigate(str);
                        }
                        else
                        {
                            webView2.NavigateToString(str);
                        }
                        TabControl_BrowserAndText.SelectedIndex = 0;
                    }
                    catch
                    {
                        NavigationError();
                    }
                }
                else
                {
                    NavigationError();
                }
            }
        }

        private static void NavigationError()
        {
            Msg.Error(Resources.ErrorInNavigation);
        }

        private void NavigateToPage(string htmlPage)
        {
            if (string.IsNullOrEmpty(htmlPage))
            {
                htmlPage = new MessagesHtmlPage().UserActionHtmlPage(UserAction);
            }
            LastWebPageFullName = TempFile(htmlPage);
            Navigate(LastWebPageFullName, WebView21);
        }

        private string LastWebPageFullName { get; set; } = string.Empty;

        private static string TempFile(string htmlPage)
        {
            string tempFullName = ProgramDirectories.TempFile;
            FileIO.WriteToFile(tempFullName, new string[] { htmlPage });
            return tempFullName;
        }

        #endregion

        #region JS Script methods

        private async void RunJSScript_OnWebPage(string command)
        {
            try
            {
                string result = await WebView21.CoreWebView2.ExecuteScriptAsync(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Resources.JavaScriptRuntimeError}: {ex.Message}");
            }
        }

        private void WebView21_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            WebMessage(e.TryGetWebMessageAsString());
        }

        private void WebMessage(string message)
        {
            UriSplitter uriSplitter = new(message);
            KeyValuePair<string, string> headAndTail = uriSplitter.HeadAndTail;
            UriType uriType = ToUriType(headAndTail.Key);
            switch (uriType)
            {
                case UriType.bible: break;
                case UriType.book: break;
                case UriType.chapter: break;
                case UriType.verse: break;
                case UriType.selected:
                    {
                        FullIdentifier fullIdentifier = FullIdentifier.TryParser(headAndTail.Value, '.');
                        UserAction.SelectedVerseIndex = fullIdentifier.Verse.N;
                        SetSelectedItem(ListBox_Verses, UserAction.SelectedVerseIndex);
                        MessageText = headAndTail.Value;
                        break;
                    }
                case UriType.error:
                    {
                        MessageText = headAndTail.Key.ToUpper() + "! " + headAndTail.Value;
                        break;
                    }
                case UriType.message:
                case UriType.msg:
                default: MessageText = headAndTail.Value; break;
            }
        }

        private void TrySetIdOnWebPage()
        {
            RunJSScript_OnWebPage("select(\"" + UserAction.GetFullIdentifier().ToString() + "\")");
        }

        private void WebView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            TrySetIdOnWebPage();
            TrySetColorThemeOnWebPage();
        }

        private void TrySetColorThemeOnWebPage()
        {
            RunJSScript_OnWebPage("setColors(" + (!Settings.Default.DarkTheme).ToString().ToLower() + ")");
        }

        #endregion

        #region Messages

        private readonly List<string> MessageQueue = ["\nMessageQueue\n"];

        private string MessageText
        {
            get { return Label_Message.Text; }
            set
            {
                Label_Message.Text = "# " + (string.IsNullOrWhiteSpace(value) ? " _" : " " + value);
                MessageQueue.Add(MessageText);
            }
        }

        private string SearchedText
        {
            get
            {
                return string.IsNullOrWhiteSpace(TextBox_Search.Text) ? string.Empty : TextBox_Search.Text;
            }
            set
            {
                TextBox_Search.Text = value;
            }
        }

        private string PreviousSearchedText
        {
            get
            {
                return TextBox_PreviousSearchedText.Text == "?" ? string.Empty : TextBox_PreviousSearchedText.Text;
            }
            set
            {
                TextBox_PreviousSearchedText.Text = string.IsNullOrWhiteSpace(value) ? "?" : value;
            }
        }


        private void Label_Message_Click(object sender, EventArgs e)
        {
            ShowInTextBox.AppendLines([.. MessageQueue]);
        }
        #endregion

    }
}

