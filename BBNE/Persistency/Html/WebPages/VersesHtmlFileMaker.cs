using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;
using BibleBooksNE.Model.Names;
using BibleBooksNE.Model.VerseTypes;
using BibleBooksNE.Properties;
using System.Text;

namespace BibleBooksNE.Persistency.Html.WebPages
{

    internal class VersesHtmlFileMaker(VerseTypeListDictionaries verseTypeListDictionaries, NameFormatter nameFormatter, string searchedText)
    {
        #region General things

        private readonly VerseTypeListDictionaries dictionary = verseTypeListDictionaries;
        private readonly string _searchedText = searchedText;
        private readonly NameFormatter _nameFormatter = nameFormatter;
        private readonly HtmlVersesPartMaker maker = new(verseTypeListDictionaries, nameFormatter, searchedText);
        private readonly bool SortingType = Settings.Default.SortingType;
        private readonly bool Justify = Settings.Default.JustifyIfPossible;
        private readonly bool Dark = Settings.Default.DarkTheme;
        public string[] ProgramValues { get; set; } = [];
        private Counters[] Statistic { get; } = verseTypeListDictionaries.Statistic();
        private Counters Sum { get; } = Counters.Count(verseTypeListDictionaries.Statistic());

        public string SearchedText => _searchedText;
        private bool IsSearchResultsPage => !string.IsNullOrWhiteSpace(SearchedText);

        #endregion

        #region JS Constant values

        private bool WithHeadlines => Sum.Values[1] > 0;
        private bool WithVerses => Sum.Values[2] > 0;
        private bool WithCrosslinks => Sum.Values[3] > 0;
        private bool WithFootnotes => Sum.Values[4] > 0;
        private bool WithWordList => Sum.Values[5] > 0;
        private bool WithAudios => Sum.Values[6] > 0;
        private bool WithStatistic => IsSearchResultsPage;

        public int UserLanguage { get; set; } = 0;

        private string[] Constants()
        {
            List<string> list = [
                SortingType.ToString().ToLower(),
                UserLanguage.ToString(),
                Justify.ToString().ToLower(),
                Dark.ToString().ToLower(),
                WithHeadlines.ToString().ToLower(),
                WithVerses.ToString().ToLower(),
                WithCrosslinks.ToString().ToLower(),
                WithFootnotes.ToString().ToLower(),
                WithWordList.ToString().ToLower(),
                WithAudios.ToString().ToLower(),
                WithStatistic.ToString().ToLower()
            ];
            return [.. list];
        }

        #endregion

        #region Build html file

        public string Build()
        {
            if (WithVerses || !string.IsNullOrWhiteSpace(SearchedText))
            {
                return Resources.VersesHtmlFileTemplate_FirstPart + ScriptPart() +
                       Resources.VersesHtmlFileTemplate_SecondPart + string.Format(
                                        Resources.VersesHtmlFileTemplate_ThirdPart,
                                        VersePart(),
                                        FootnotePart(),
                                        WordPart(),
                                        StatisticPart());
            }
            return string.Empty;
        }

        private string ScriptPart()
        {
            StringBuilder sb = new();
            sb.AppendLine(VersesWebPageTemplates.ConstantsTemplate(Constants()));
            sb.AppendLine();
            sb.AppendLine(VersesWebPageTemplates.ValuesTemplate(ProgramValues));
            sb.AppendLine();
            sb.AppendLine(VersesWebPageTemplates.VerseGroupIdsTemplate(string.Join(',' + Environment.NewLine, MakeVerseGroupIds())));
            return sb.ToString();
        }

        private string[] MakeVerseGroupIds()
        {
            List<string> ids = [];
            foreach (FullIdentifierWithText item in GetVerseGroupIds())
            {
                    ids.Add('"' + item.Ids.ToString() + '"');
            }
            return [.. ids];
        }

        private IEnumerable<FullIdentifierWithText> GetVerseGroupIds()
        {
            byte type = (int)PageOrder.item_group;
            foreach (FullIdentifierWithText item in dictionary.VerseGroupIds)
            {
                if (item.Ids.Type.N == type)
                {
                    yield return item;
                }
            }
        }

        private string VersePart()
        {
            if (WithVerses)
            {
                return
                    VersesWebPageTemplates.SimpleTopNavBarTemplate + Environment.NewLine +
                    maker.MakeVersesPart()
                    + Environment.NewLine + VersesWebPageTemplates.SimpleBottomNavBarTemplate; 
            }
            return string.Empty;
        }

        private string FootnotePart()
        {
            if (WithFootnotes)
            {
                return maker.MakeFootnotePart();
            }
            return string.Empty;
        }
        private string WordPart()
        {
            if (WithWordList)
            {
                return maker.MakeWordListPart();
            }
            return string.Empty;
        }

        private string StatisticPart()
        {
            if (WithStatistic)
            {
                StringBuilder sb = new();
                for (int i = 0; i < Statistic.Length; i++)
                {
                    sb.AppendLine(VersesWebPageTemplates.StatisticTableRowTemplate(
                            _nameFormatter.ShortBibleNameOnly(
                                new FullIdentifier(new(), new((int)Statistic[i].Values[0]), PageOrder.unknown)),
                            Statistic[i].Values[1].ToString(),
                            Statistic[i].Values[2].ToString(),
                            Statistic[i].Values[4].ToString(),
                            Statistic[i].Values[7].ToString()));
                }
                string lastRow = VersesWebPageTemplates.StatisticTableLastRowTemplate(
                    Sum.Values[0].ToString(),
                    Sum.Values[1].ToString(),
                    Sum.Values[2].ToString(),
                    Sum.Values[4].ToString(),
                    Sum.Values[7].ToString());
                return VersesWebPageTemplates.StatisticTableTemplate(
                    VersesWebPageTemplates.HighlightedSearchedText(SearchedText), sb.ToString(),
                    lastRow);
            }
            return string.Empty;
        }
        #endregion
    }
}
