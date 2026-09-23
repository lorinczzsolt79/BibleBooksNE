using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;
using BibleBooksNE.Model.Names;
using BibleBooksNE.Model.VerseTypes;
using BibleBooksNE.Properties;
using BibleBooksNE.ViewAndController.Navigation;
using System.Text.RegularExpressions;

namespace BibleBooksNE.Persistency.Html.WebPages
{
    internal class HtmlVersesPartMaker(VerseTypeListDictionaries verseTypeListDictionaries, NameFormatter nameFormatter, string searchedText)
    {

        private readonly VerseTypeListDictionaries Dictionaries = verseTypeListDictionaries;
        private readonly NameFormatter Name_Formatter = nameFormatter;
        private readonly string _searchedText = searchedText;
        private readonly bool Searching = !string.IsNullOrWhiteSpace(searchedText);
        private List<FullIdentifierWithText> Items = [];
        private int Index = -1;

        public string MakeVersesPart() => Make(Dictionaries.VerseTypeItems());
        public string MakeFootnotePart() => Make(Dictionaries.FootnotesItems());
        public string MakeWordListPart() => Make(Dictionaries.WorListItems());

        private bool WithFootnote => Dictionaries.FootnotesItems().Count > 0;

        private string Make(List<FullIdentifierWithText> list)
        {
            Index = -1;
            Items = list;
            if (Items.Count > 0)
            {
                return RecursiveTask(new GroupMaker());
            }
            return string.Empty;
        }

        private string RecursiveTask(GroupMaker detailsMaker)
        {
            while (Index < Items.Count)
            {
                FullIdentifierWithText fullIdentifier_WithText;
                int type;
                if (Index + 1 < Items.Count)
                {
                    Index++;
                    fullIdentifier_WithText = Items[Index];
                    type = fullIdentifier_WithText.Ids.Type.N;
                }
                else
                {
                    break;
                }
                if (IsGroupId((PageOrder)type))
                {
                    detailsMaker.Add(RecursiveTask(new(fullIdentifier_WithText, type, GetName(fullIdentifier_WithText))));
                }
                else
                {
                    detailsMaker.Add(ItemMaker(fullIdentifier_WithText));
                }
                if (Index + 1 < Items.Count)
                {
                    int n = Items[Index + 1].Ids.Type.N;
                    if (IsGroupId((PageOrder)n) && n < type)
                    {
                        break;
                    }
                }
            }
            return detailsMaker.GetGroup();
        }

        private string ItemMaker(FullIdentifierWithText fullIdentifier_WithText)
        {

            return (PageOrder)fullIdentifier_WithText.Ids.Type.N switch
            {
                PageOrder.top_navbar => NavBarMaker(fullIdentifier_WithText, true),
                PageOrder.headline_title => HeadlineMaker(fullIdentifier_WithText),
                PageOrder.chapter_title => VerseMaker(fullIdentifier_WithText),
                PageOrder.verse_item => VerseMaker(fullIdentifier_WithText),
                PageOrder.crosslink_item => CrosslinkMaker(fullIdentifier_WithText),
                PageOrder.bottom_navbar => NavBarMaker(fullIdentifier_WithText, false),
                PageOrder.footnote => FootnoteMaker(fullIdentifier_WithText),
                PageOrder.wordlist => WordListMaker(fullIdentifier_WithText),
                PageOrder.audio => AudioMaker(fullIdentifier_WithText),
                _ => "Item maker error! No maker for this item."
            };
        }

        private string GetName(FullIdentifierWithText fullIdentifierWithText)
        {
            switch ((PageOrder)fullIdentifierWithText.Ids.Type.N)
            {
                case PageOrder.document: return Resources.Document;
                case PageOrder.page: return Resources.DocumentPage;
                case PageOrder.bible: return Name_Formatter.ShortBibleNameOnly(fullIdentifierWithText.Ids);
                case PageOrder.book: return Name_Formatter.ShortBibleNameBookNumber(fullIdentifierWithText.Ids);
                case PageOrder.chapter:
                case PageOrder.chapter_title:
                case PageOrder.verse_item:
                case PageOrder.footnote: return Name_Formatter.ShortBibleNameBookNumberChapterNumber(fullIdentifierWithText.Ids);
                case PageOrder.crosslink_item:
                case PageOrder.headline_title:
                case PageOrder.item_group: return Name_Formatter.ShortBibleNameBookChapterVerseNumbers(fullIdentifierWithText.Ids);
                default: return string.Empty;
            }
        }

        #region PageOrder Groups


        public static bool IsGroupId(PageOrder pageOrder) => pageOrder switch
        {
            PageOrder.document => true,
            PageOrder.page => true,
            PageOrder.bible => true,
            PageOrder.book => true,
            PageOrder.chapter => true,
            PageOrder.item_group => true,
            PageOrder.footnote_group => true,
            PageOrder.wordlist_group => true,
            _ => false
        };

        public static bool IsVerseTypeItem(PageOrder pageOrder) => pageOrder switch
        {
            PageOrder.headline_title => true,
            PageOrder.chapter_title => true,
            PageOrder.verse_item => true,
            PageOrder.crosslink_item => true,
            _ => false
        };
        #endregion

        #region Maker methods

        private static string NavBarMaker(FullIdentifierWithText item, bool top)
        {
            return top ? VersesWebPageTemplates.SimpleTopNavBarTemplate : VersesWebPageTemplates.SimpleBottomNavBarTemplate;
        }

        public string VerseMaker(FullIdentifierWithText item)
        {
            return VersesWebPageTemplates.VerseTemplate(item.Ids.ToString(), GetName(item), item.Ids.Verse.N.ToString(),
                HighlightedSearchedText(FootnoteLinkMaker(item)), Searching ? Name_Formatter.FourNumberWithSeparator(item.Ids) : string.Empty);
        }

        public string FootnoteLinkMaker(FullIdentifierWithText fullIdsWithText)
        {
            string pattern = @"\[\d+\]";
            string result = fullIdsWithText.Text;
            string[] matches = [.. Regex.Matches(result, pattern).Cast<Match>().Select(m => m.Value)];
            if (matches.Length > 0)
            {
                if (!Searching && WithFootnote)
                {
                    foreach (string match in matches)
                    {
                        string footnoteNumber = Regex.Match(match, "\\d+").ToString();
                        result = Regex.Replace(result, Regex.Escape(match),
                            VersesWebPageTemplates.FootnoteLinkAnchorTemplate(
                                new FullIdentifier(fullIdsWithText.Ids, new(footnoteNumber)).ToString(),
                                footnoteNumber));
                    }
                }
                else
                {
                    result = Regex.Replace(result, pattern, string.Empty);
                }

            }
            return result;
        }

        private string HighlightedSearchedText(string itemText)
        {
            string result = itemText;
            if (Searching)
            {
                foreach (string match in Regex.Matches(itemText, _searchedText, RegexOptions.IgnoreCase).Cast<Match>().Select(m => m.Value))
                {
                    result = result.Replace(match, VersesWebPageTemplates.HighlightedSearchedText(match));
                }
            }
            return result;
        }


        private string HeadlineMaker(FullIdentifierWithText item)
        {
            return VersesWebPageTemplates.HeadlineTemplate(item.Ids.ToString(), GetName(item), item.Text);
        }

        private string CrosslinkMaker(FullIdentifierWithText item)
        {
            return VersesWebPageTemplates.CrossReferencesTemplate(item.Ids.ToString(), GetName(item), GetCrosslinkItems(item.Ids.Bible.N, item.Text));
        }

        private string GetCrosslinkItems(int bibleId, string text)
        {
            List<string> cLinkList = [];
            if (!string.IsNullOrWhiteSpace(text))
            {
                string[] cLinks = text.Split(";");
                foreach (string cLink in cLinks)
                {
                    try
                    {
                        int[] numbers = FullIdentifier.Parser(cLink, '.');
                        FullIdentifier fullIdentifier = new(
                                new Identifier(bibleId),
                                new Identifier(numbers[0]),
                                new Identifier(numbers[1]),
                                new Identifier(numbers[2]),
                                new(),
                                PageOrder.crosslink_item
                                );
                        cLinkList.Add(VersesWebPageTemplates.CrossReferenceAnchorTemplate(UriType.link.ToString(),
                            fullIdentifier.ToString(),
                            Name_Formatter.ShortBookNameChapterVerseNumbers(fullIdentifier)));
                    }
                    catch { }
                }
            }
            return string.Join(" ", cLinkList);
        }

        private string FootnoteMaker(FullIdentifierWithText item)
        {
            return VersesWebPageTemplates.FootnoteItemTemplate(item.Ids.ToString(),
                new FullIdentifier(Settings.Default.SortingType, item.Ids).ToString(), item.Ids.Verse.N.ToString(),
                HighlightedSearchedText(item.Text),
                GetName(item), item.Ids.Number.N.ToString());
        }

        private static string WordListMaker(FullIdentifierWithText item)
        {
            return VersesWebPageTemplates.WordListItemTemplate(item.Ids.ToString(), item.Text);
        }

        private string AudioMaker(FullIdentifierWithText item)
        {
            return item.ToString();
        }

        #endregion
    }
}
