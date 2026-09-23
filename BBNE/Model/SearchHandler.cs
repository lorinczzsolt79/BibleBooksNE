using BibleBooksNE.Model.Database;
using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;
using BibleBooksNE.Model.VerseTypes;
using System.Text;

namespace BibleBooksNE.Model
{
    internal class SearchHandler
    {
        private readonly DatabaseHandler _databaseHandler = new();
        private string _searchedText = string.Empty;
        private bool _previous_WithAddOnsState = false;
        private bool _actual_WithAddOnsState = false;
        private VerseTypeListDictionaries _verseTypeLists_Dictionary = new();
        private IdsWithOrders _idsWithOrders = new();

        public SearchHandler()
        {
            PreviousIdsWithOrders = new IdsWithOrders();
            PreviousSearchedText = string.Empty;
        }

        public SearchHandler(DatabaseHandler databaseHandler)
        {
            _databaseHandler = databaseHandler;
            PreviousIdsWithOrders = new IdsWithOrders();
            PreviousSearchedText = string.Empty;
        }

        private IdsWithOrders PreviousIdsWithOrders { get; set; }

        private IdsWithOrders ActualIdsWithOrders
        {
            get { return _idsWithOrders; }
            set
            {
                _idsWithOrders = value;
            }
        }

        private string PreviousSearchedText { get; set; }

        private string ActualSearchedText
        {
            get { return _searchedText; }
            set
            {
                PreviousSearchedText = _searchedText;
                _searchedText = string.IsNullOrWhiteSpace(value) ? string.Empty : value;
            }
        }

        private bool SameText => ActualSearchedText.Equals(PreviousSearchedText);
        private bool TextChanged => !SameText;
        private bool WithChanged => SameText && _previous_WithAddOnsState == false && WithAddOns;

        public bool WithAddOns
        {
            get { return _actual_WithAddOnsState; }
            set
            {
                _previous_WithAddOnsState = _actual_WithAddOnsState;
                _actual_WithAddOnsState = value;
            }
        }

        public string SearchedText => ActualSearchedText;

        public VerseTypeListDictionaries Search(IdsWithOrders idsWithOrders, string searchedText)
        {
            if (!string.IsNullOrWhiteSpace(searchedText) &&
                idsWithOrders != null && idsWithOrders.Bibles.Length > 0)
            {
                ActualIdsWithOrders = idsWithOrders;
                ActualSearchedText = searchedText;
                if (TextChanged || WithChanged || !PreviousIdsWithOrders.Same(ActualIdsWithOrders))
                {
                    _verseTypeLists_Dictionary = new(ActualIdsWithOrders.Bibles);
                    PreviousIdsWithOrders = ActualIdsWithOrders;
                    foreach (int bible in ActualIdsWithOrders.Bibles)
                    {
                        AddTo(PageOrder.verse_item, bible, SearchResults(bible, PageOrder.verse_item));
                    }
                    if (WithAddOns)
                    {
                        foreach (int bible in ActualIdsWithOrders.Bibles)
                        {
                            foreach (PageOrder order in ActualIdsWithOrders.Orders)
                            {
                                AddTo(order, bible, SearchResults(bible, order));
                            }
                        }
                    }
                }
            }
            return _verseTypeLists_Dictionary;
        }

        private void AddTo(PageOrder order, int bible, List<FullIdentifierWithText> results)
        {
            switch (order)
            {
                case PageOrder.headline_title:
                    {
                        var item = _verseTypeLists_Dictionary.Get(bible);
                        if (item != null)
                        {
                            item.HeadLines = results;
                        }
                        break;
                    }
                case PageOrder.verse_item:
                    {
                        var item = _verseTypeLists_Dictionary.Get(bible);
                        if (item != null)
                        {
                            item.Verses = results;
                        }
                        break;
                    }
                case PageOrder.footnote:
                    {
                        var item = _verseTypeLists_Dictionary.Get(bible);
                        if (item != null)
                        {
                            item.Footnotes = results;
                        }
                        break;
                    }
                default: break;
            }
        }

        private List<FullIdentifierWithText> SearchResults(int bible, PageOrder order)
        {
            List<FullIdentifierWithText> list = [];
            if (bible != 0)
            {
                FullIdentifierWithText[] array = GetSearchResults(bible, order);
                list.AddRange(array);
            }
            return list;
        }

        private FullIdentifierWithText[] GetSearchResults(int bible, PageOrder order)
        {
            var item = _databaseHandler.GetDatabase(bible);
            if (item != null)
            {
                return item.Search(
                                            bible,
                                            ActualIdsWithOrders.Book,
                                            ActualIdsWithOrders.Chapter,
                                            ActualIdsWithOrders.Verse,
                                            ActualSearchedText,
                                            order);
            }
            return [];
        }

        private string DiagnosticMsg()
        {
            StringBuilder sb = new();
            sb.AppendLine("SearchHandler.DiagnosticMsg");
            sb.AppendLine("PreviousSearchedText : " + PreviousSearchedText);
            sb.AppendLine("ActualSearchedText: " + ActualSearchedText);
            sb.AppendLine("WithAddOns: " + WithAddOns);
            sb.AppendLine("SameText: " + SameText );
            sb.AppendLine("TextChanged: " + TextChanged );
            sb.AppendLine("WithChanged: " + WithChanged);
            sb.AppendLine("PreviousIdsWithOrders" + PreviousIdsWithOrders.ToString());
            sb.AppendLine("ActualIdsWithOrders" + ActualIdsWithOrders.ToString());
            return sb.ToString();
        }

    }
}
