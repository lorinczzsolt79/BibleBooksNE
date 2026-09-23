using BibleBooksNE.Properties;
using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;
using BibleBooksNE.ViewAndController;

namespace BibleBooksNE.Persistency.Html.HtmlMessages
{
    internal class MessagesHtmlPage
    {
        #region General things

        private string TitlePart { get; set; }
        private string H1Part { get; set; }
        private string MainPart { get; set; }

        public MessagesHtmlPage()
        {
            TitlePart = string.Empty;
            H1Part = string.Empty;
            MainPart = string.Empty;
        }

        #endregion

        #region Messages web pages

        public string WelcomeHtmlPage()
        {
            TitlePart = Resources.WelcomeToBibleBooks;
            H1Part = TitlePart;
            MainPart = string.Empty;
            return MakeHtmlPageWithMsg();
        }

        public string NotFoundHtmlPage(PageOrder order)
        {
            TitlePart = Resources.NotFound;
            H1Part = GetNotFoundMsg(order);
            MainPart = string.Empty;
            return MakeHtmlPageWithMsg();
        }

        public string SelectSomethingHtmlPage(PageOrder order)
        {
            TitlePart = Resources.Selection;
            H1Part = GetSelectSomethingMsg(order);
            MainPart = string.Empty;
            return MakeHtmlPageWithMsg();
        }

        public string UserActionHtmlPage(UserActions userSelection)
        {
            TitlePart = Resources.UserActionPage;
            H1Part = TitlePart;
            MainPart = Paragraph(userSelection.ToString().Replace(Environment.NewLine, "<br>"));
            return MakeHtmlPageWithMsg();
        }

        public string HelpFileNotFoundPage()
        {
            TitlePart = Resources.HelpFileNotFound;
            H1Part = TitlePart;
            MainPart = string.Empty;
            return MakeHtmlPageWithMsg();
        }

        #endregion

        #region Accessories

        private static string GetSelectSomethingMsg(PageOrder order)
        {
            return order switch
            {
                PageOrder.bible => Resources.PleaseSelectOneOrMoreBibleWithoutZero,
                PageOrder.book => Resources.PleaseSelectBook,
                PageOrder.chapter => Resources.PleaseSelectChapter,
                PageOrder.verse_item => Resources.PleaseSelectVerse,
                _ => string.Empty
            };
        }

        private static string GetNotFoundMsg(PageOrder order)
        {
            return order switch
            {
                PageOrder.bible => Resources.DatabaseWasNotFound,
                PageOrder.book => Resources.NotFoundAnyBookItem,
                PageOrder.chapter => Resources.NotFoundAnyChapterItem,
                PageOrder.verse_item => Resources.NotFoundAnyVerseItem,
                _ => string.Empty
            };
        }

        private string MakeHtmlPageWithMsg()
        {
            if (string.IsNullOrWhiteSpace(H1Part))
            {
                H1Part = Resources.SorrySomethingWentWrong;
            }
            StandardHtmlPage standardHtmlPage = new()
            {
                Title = TitlePart,
                H1 = H1Part,
                Main = MainPart
            };
            return standardHtmlPage.Document();
        }

        #endregion

        #region Simple text web pages

        public string SimpleTextHtmlPage(string text)
        {
            TitlePart = Resources.SimpleTextPage;
            H1Part = TitlePart;
            MainPart = GetSimpleText_HtmlPage([text]);
            return MakeHtmlPageWithMsg();
        }

        public string SimpleTextHtmlPage(string[] text)
        {
            TitlePart = Resources.SimpleTextPage;
            H1Part = TitlePart;
            MainPart = GetSimpleText_HtmlPage(text);
            return MakeHtmlPageWithMsg();
        }

        public string SimpleVersesHtmlPage(List<FullIdentifierWithText> verseTypeLists)
        {
            TitlePart = Resources.SimpleTextPage;
            H1Part = TitlePart;
            MainPart = GetSimpleVerses_HtmlPage(verseTypeLists);
            return MakeHtmlPageWithMsg();
        }

        public string SimpleSearchResultHtmlPage(List<FullIdentifierWithText> fullIdsWithTexts)
        {
            TitlePart = Resources.Matches;
            H1Part = TitlePart;
            MainPart = SearchResultToHtmlPage(fullIdsWithTexts);
            return MakeHtmlPageWithMsg();
        }
        #endregion

        #region Accessories for simple pages


        private static string GetSimpleText_HtmlPage(string[] text)
        {
            return string.Format("<pre>{0}</pre>",
                    string.Join(Environment.NewLine, text)
                );
        }

        private static string Paragraph(string content)
        {
            return string.Format("<p>{0}</p>", content);
        }

        public static string GetSimpleVerses_HtmlPage(List<FullIdentifierWithText> list)
        {
            if (list != null && list.Count > 0)
            {
                return Paragraph(string.Join("</p>\n<p>", ToStringArray(list)));
            }
            return string.Empty;
        }

        public static string SearchResultToHtmlPage(List<FullIdentifierWithText> fullIdsWithTexts)
        {
            if (fullIdsWithTexts != null && fullIdsWithTexts.Count > 0)
            {
                return Paragraph(string.Join("</p>\n<p>", ToStringArray(fullIdsWithTexts)));
            }
            return Paragraph(Resources.NoMatches);
        }

        private static IEnumerable<string> ToStringArray(List<FullIdentifierWithText> fullIdsWithTexts)
        {
            foreach (FullIdentifierWithText item in fullIdsWithTexts)
            {
                if (item != null)
                {
                    yield return item.ToString();
                }
            }
        }


        #endregion

    }
}
