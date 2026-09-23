using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;
using BibleBooksNE.Properties;
using System.Text;

namespace BibleBooksNE.ViewAndController
{
    internal class UserActions
    {

        #region General things

        private int _previousBibleIndex = -1;
        private int[] _previousBibleIndices = [];
        private int _previousBookIndex = -1;
        private int _previousChapterIndex = -1;
        private int _previousVerseIndex = -1;

        private int _selectedBibleIndex = -1;
        private int[] _selectedBibleIndices = [];
        private int _selectedBookIndex = -1;
        private int _selectedChapterIndex = -1;
        private int _selectedVerseIndex = -1;

        private bool _previousWithHeadlinesState = true;
        private bool _previousWithCrosslinksState = true;
        private bool _previousWithFootnotesState = true;
        private bool _previousWithWordlistState = false;
        private bool _previousWithAudioState = false;

        private bool _checkedHeadline = true;
        private bool _checkedCrosslink = true;
        private bool _checkedFootnote = true;
        private bool _checkedWordlist = false;
        private bool _checkedAudio = false;

        public UserActions() { }
        public UserActions(IdsWithOrders idsWithOrders)
        {
            SetState(idsWithOrders);
        }

        private static string GetIndices(int[] array)
        {
            return string.Join(", ", array);
        }

        public FullIdentifier GetFullIdentifier()
        {
                return new FullIdentifier(
                    Settings.Default.SortingType ? new() : new(SelectedBibleIndex),
                    new(SelectedBookIndex),
                    new(SelectedChapterIndex),
                    new(SelectedVerseIndex),
                    new(),
                    PageOrder.item_group
                    );
        } 

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("User Actions:");
            sb.AppendLine("Ids:");
            sb.AppendLine("Previous Bible Index: " + _previousBibleIndex);
            sb.AppendLine("Previous Bible Indices: " + GetIndices(_previousBibleIndices));
            sb.AppendLine("Previous Book Index: " + _previousBookIndex);
            sb.AppendLine("Previous Chapter Index: " + _previousChapterIndex);
            sb.AppendLine("Previous Verse Index: " + _previousVerseIndex);
            sb.AppendLine();
            sb.AppendLine("Selected Bible Index: " + SelectedBibleIndex);
            sb.AppendLine("Selected Bible Indices: " + GetIndices(SelectedBibleIndices));
            sb.AppendLine("Selected Book Index: " + SelectedBookIndex);
            sb.AppendLine("Selected Chapter Index: " + SelectedChapterIndex);
            sb.AppendLine("Selected Verse Index: " + SelectedVerseIndex);
            sb.AppendLine();
            sb.AppendLine("Bible Id Changed: " + BibleIdChanged);
            sb.AppendLine("Bible Ids Changed: " + BibleIdsChanged);
            sb.AppendLine("Book Id Changed: " + BookIdChanged);
            sb.AppendLine("Chapter Id Changed: " + ChapterIdChanged);
            sb.AppendLine("Verse Id Changed: " + VerseIdChanged);
            sb.AppendLine();
            sb.AppendLine("SomethingChanged: " + SomethingChanged);
            sb.AppendLine("Bible, Book, Chapter, and Verse Changed: " + BibleBookChapterAndVerseChanged);
            sb.AppendLine("Bible, Book, Chapter, Changed: " + BibleBookChapterChanged);
            sb.AppendLine();
            sb.AppendLine("AddOns:");
            sb.AppendLine("With Headlines? " + WithHeadlines);
            sb.AppendLine("With Crosslinks? " + WithCrosslinks);
            sb.AppendLine("With Footnotes? " + WithFootnotes);
            sb.AppendLine("With Wordlist? " + WithWordlist);
            sb.AppendLine("With Audios? " + WithAudios);
            sb.AppendLine();
            sb.AppendLine("Previous With Headlines State? " + _previousWithHeadlinesState);
            sb.AppendLine("Previous With Crosslinks State? " + _previousWithCrosslinksState);
            sb.AppendLine("Previous With Footnotes State? " + _previousWithFootnotesState);
            sb.AppendLine("Previous With Wordlist State? " + _previousWithWordlistState);
            sb.AppendLine("Previous With Audio State? " + _previousWithAudioState);
            sb.AppendLine();
            sb.AppendLine("AddOnsChanged? " + AddOnsChanged);
            sb.AppendLine("With Headlines Changed? " + WithHeadlineChanged);
            sb.AppendLine("With Crosslinks Changed? " + WithCrosslinkChanged);
            sb.AppendLine("With Footnotes Changed? " + WithFootnoteChanged);
            sb.AppendLine("With Wordlist Changed? " + WithWordlistChanged);
            sb.AppendLine("With Audios Changed? " + WithAudiosChanged);
            return sb.ToString();
        }

        #endregion

        #region IDs

        public int SelectedBibleIndex
        {
            get { return _selectedBibleIndex; }
            set { _previousBibleIndex = _selectedBibleIndex; _selectedBibleIndex = value; }
        }

        public int[] SelectedBibleIndices
        {
            get { return _selectedBibleIndices; }
            set { _previousBibleIndices = _selectedBibleIndices; _selectedBibleIndices = value; }
        }

        public int SelectedBookIndex
        {
            get { return _selectedBookIndex; }
            set { _previousBookIndex = _selectedBookIndex; _selectedBookIndex = value; }
        }

        public int SelectedChapterIndex
        {
            get { return _selectedChapterIndex; }
            set { _previousChapterIndex = _selectedChapterIndex; _selectedChapterIndex = value; }
        }

        public int SelectedVerseIndex
        {
            get { return _selectedVerseIndex; }
            set { _previousVerseIndex = _selectedVerseIndex; _selectedVerseIndex = value; }
        }

        #endregion

        #region IdsWithOrders methods

        /// <summary>
        /// For reader, always in Verses Table (plus with AddOns)
        /// </summary>
        /// <returns>IdsWithOrders for reader</returns>
        public IdsWithOrders GetIdsWithOrders()
        {
            return new IdsWithOrders(SelectedBibleIndices, SelectedBookIndex, SelectedChapterIndex, -1, WithOrders(true));
        }

        public string GetState()
        {
            return new IdsWithOrders(SelectedBibleIndices, SelectedBookIndex, SelectedChapterIndex,
                                                    SelectedVerseIndex, WithOrders(true)).GetState();
        }

        public void SetState(IdsWithOrders idsWithOrders)
        {
            if (idsWithOrders.Bibles.Length > 0)
            {
                SelectedBibleIndex = idsWithOrders.Bibles[0];
            }
            SelectedBibleIndices = idsWithOrders.Bibles;
            SelectedBookIndex = idsWithOrders.Book;
            SelectedChapterIndex = idsWithOrders.Chapter;
            SelectedVerseIndex = idsWithOrders.Verse;
            SetAddOns(idsWithOrders.Orders);
        }

        private void SetAddOns(PageOrder[] orders)
        {
            List<PageOrder> list = [.. orders];
            WithHeadlines = list.Contains(PageOrder.headline_title);
            WithCrosslinks = list.Contains(PageOrder.crosslink_item);
            WithFootnotes = list.Contains(PageOrder.footnote);
            WithWordlist = list.Contains(PageOrder.wordlist);
            WithAudios = list.Contains(PageOrder.audio);
        }

        /// <summary>
        /// For searching, always in Verses Table (plus with AddOns)
        /// </summary>
        /// <returns>IdsWithOrders for search</returns>
        public IdsWithOrders GetIdsWithOrdersForSearch(bool with)
        {
            return new IdsWithOrders(SelectedBibleIndices, SelectedBookIndex, SelectedChapterIndex, SelectedVerseIndex,
                with ? WithOrders(false) : []);
        }

        /// <summary>
        /// With AddOns for reader or search
        /// </summary>
        /// <param name="reader">true = for reader ; false = for search</param>
        /// <returns>orders array</returns>
        private PageOrder[] WithOrders(bool reader)
        {
            List<PageOrder> list = [];
            if (WithHeadlines) { list.Add(PageOrder.headline_title); }                // Reader, Search
            if (reader && WithCrosslinks) { list.Add(PageOrder.crosslink_item); }    // Reader, -
            if (WithFootnotes) { list.Add(PageOrder.footnote); }                // Reader, Search
            if (reader && WithWordlist) { list.Add(PageOrder.wordlist); }      // Reader, -
            if (reader && WithAudios) { list.Add(PageOrder.audio); }             // Reader, -
            return [.. list];
        }

        #endregion

        #region AddOns

        public bool WithHeadlines
        {
            get { return _checkedHeadline; }
            set { _previousWithHeadlinesState = _checkedHeadline; _checkedHeadline = value; }
        }

        public static bool WithVerses => true;

        public bool WithCrosslinks
        {
            get { return _checkedCrosslink; }
            set { _previousWithCrosslinksState = _checkedCrosslink; _checkedCrosslink = value; }
        }

        public bool WithFootnotes
        {
            get { return _checkedFootnote; }
            set { _previousWithFootnotesState = _checkedFootnote; _checkedFootnote = value; }
        }

        public bool WithWordlist
        {
            get { return _checkedWordlist; }
            set { _previousWithWordlistState = _checkedWordlist; _checkedWordlist = value; }
        }

        public bool WithAudios
        {
            get { return _checkedAudio; }
            set { _previousWithAudioState = _checkedAudio; _checkedAudio = value; }
        }

        #endregion

        #region Changed

        public bool SomethingChanged => BibleBookChapterAndVerseChanged || AddOnsChanged;

        #region IDs changed

        public bool BibleIdChanged => SelectedBibleIndex != _previousBibleIndex;
        public bool BibleIdsChanged => !IdsWithOrders.Same(SelectedBibleIndices, _previousBibleIndices);
        public bool BookIdChanged => SelectedBookIndex != _previousBookIndex;
        public bool ChapterIdChanged => SelectedChapterIndex != _previousChapterIndex;
        public bool VerseIdChanged => SelectedVerseIndex != _previousVerseIndex;
        public bool BibleBookChapterChanged => BibleIdChanged || BookIdChanged || ChapterIdChanged || BibleIdsChanged;
        public bool BibleBookChapterAndVerseChanged => BibleBookChapterChanged || VerseIdChanged;

        #endregion

        #region AddOns changed
        public bool AddOnsChanged => WithHeadlineChanged || WithCrosslinkChanged ||
                                        WithFootnoteChanged || WithWordlistChanged || WithAudiosChanged;

        public bool WithHeadlineChanged => WithHeadlines != _previousWithHeadlinesState;
        public bool WithCrosslinkChanged => WithCrosslinks != _previousWithCrosslinksState;
        public bool WithFootnoteChanged => WithFootnotes != _previousWithFootnotesState;
        public bool WithWordlistChanged => WithWordlist != _previousWithWordlistState;
        public bool WithAudiosChanged => WithAudios != _previousWithAudioState;

        #endregion

        #endregion

    }
}
