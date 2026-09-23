using BibleBooksNE.Model.Database;
using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;

namespace BibleBooksNE.Model.VerseTypes
{
    internal class VerseTypeListHandler
    {
        # region General things

        private readonly DatabaseHandler _databaseHandler = new();
        private VerseTypeListDictionaries _verseTypeListDictionaries = new();

        public VerseTypeListHandler() { }

        public VerseTypeListHandler(DatabaseHandler databaseHandler)
        {
            _databaseHandler = databaseHandler;
        }

        private int Size => _databaseHandler.Size;

        private IdsWithOrders Previous { get; set; } = new();

        private IdsWithOrders Actual { get; set; } = new();
        private bool BibleChanged => !Previous.SameBibles(Actual.Bibles);
        private bool IdsChanged => !Previous.Same_Ids(Actual.Book, Actual.Chapter, Actual.Verse);
        private bool AddOnsChanged => !Previous.Same_Orders(Actual.Orders);

        #endregion

        #region Get Data from Database

        #region Get New Items

        public VerseTypeListDictionaries Refresh(IdsWithOrders idsWithOrdersArray)
        {
            Actual = idsWithOrdersArray;
            if (!Previous.Equals(Actual))
            {
                if (IdsChanged) // Book OR Chapter
                {
                    // Everything is NEW!
                    _verseTypeListDictionaries = new();
                    foreach (int bible in Actual.Bibles)
                    {

                        SetNewBibleData(bible);
                    }
                }
                else
                {
                    if (BibleChanged)   // + OR - Bible
                    {
                        State[] result = CheckBibles();
                        for (int i = 1; i < result.Length; i++)
                        {
                            if (result[i].Equals(State.new_item))     // + Bible; Everything is NEW!
                            {
                                SetNewBibleData(i);
                            }
                            if (result[i].Equals(State.none))    // - Bible, list = null.
                            {
                                _verseTypeListDictionaries.Set(i, null);
                            }
                            // 0 Nothing changes!
                        }
                    }
                    else
                    {
                        if (AddOnsChanged) // + OR - AddOn
                        {
                            for (int i = 0; i < Actual.Bibles.Length; i++)
                            {
                                GetAddOns(Actual.Bibles[i]);
                            }
                        }
                        // else Nothing changes!
                    }
                }
            }
            Previous = idsWithOrdersArray;
            return _verseTypeListDictionaries;
        }

        private State[] CheckBibles()
        {
            State[] result = new State[Size + 1];
            result[0] = 0;
            for (int i = 1; i <= Size; i++)
            {
                bool containsP = new List<int>(Previous.Bibles).Contains(i);
                bool contains = new List<int>(Actual.Bibles).Contains(i);
                if (!containsP && contains)
                {
                    result[i] = State.new_item;
                }
                else
                {
                    if (!contains)
                    {
                        result[i] = State.none;
                    }
                    else
                    {
                        result[i] = State.same_item;
                    }
                }
            }
            return result;
        }

        private enum State
        {
            none = -1,
            same_item = 0,
            new_item = 1
        }

        private void SetNewBibleData(int bible)
        {
            if (!_verseTypeListDictionaries.ContainsKey(bible))
            {
                _verseTypeListDictionaries.Set(bible, new());
            }
            var dic = _verseTypeListDictionaries.Get(bible);
            if (dic != null)
            {
                dic.Verses = [.. GetVerseTypeItems(GetFullIds(bible, PageOrder.verse_item))];
            }
            GetAddOns(bible);
        }

        #endregion

        #region Accessories

        private static PageOrder[] AddOns => [
            PageOrder.headline_title,
            PageOrder.crosslink_item,
            PageOrder.footnote,
            PageOrder.wordlist,
            PageOrder.audio
        ];

        private FullIdentifier GetFullIds(int bible, PageOrder order)
        {
            return new FullIdentifier(new Identifier(bible),
                                       new Identifier(Actual.Book),
                                       new Identifier(Actual.Chapter),
                                       new Identifier(Actual.Verse),
                                       new Identifier(),
                                       order);
        }

        private FullIdentifierWithText[] GetVerseTypeItems(FullIdentifier fullIds)
        {
            var database = _databaseHandler.GetDatabase(fullIds.Bible.N);
            if (database != null)
            {
                return database.GetVerseTypeItems(fullIds);
            }
            return [];
        }

        private void GetAddOns(int bible)
        {
            var database = _verseTypeListDictionaries.Get(bible);
            if (database != null)
            {
                foreach (PageOrder order in AddOns)
                {
                    switch (order)
                    {
                        case PageOrder.headline_title:
                            {
                                database.HeadLines = GetItems(bible, order, database.HeadLines == null);
                                break;
                            }
                        case PageOrder.crosslink_item:
                            {
                                database.CrossLinks = GetItems(bible, order, database.CrossLinks == null);
                                break;
                            }
                        case PageOrder.footnote:
                            {
                                database.Footnotes = GetItems(bible, order, database.Footnotes == null);
                                break;
                            }
                        case PageOrder.wordlist:
                            {
                                database.WordList = GetItems(bible, order, database.WordList == null);
                                break;
                            }
                        case PageOrder.audio:
                            {
                                //_verseTypeListsArray[bible].Audios = GetItems(idsWithOrders, with, order, _verseTypeListsArray[bible].Audios == null);
                                database.Audios = [];
                                break;
                            }
                    }
                }
            }
        }

        private List<FullIdentifierWithText>? GetItems(int bible, PageOrder order, bool isNull)
        {
            if (new List<PageOrder>(Actual.Orders).Contains(order))
            {
                if (isNull)
                {
                    return [.. GetVerseTypeItems(GetFullIds(bible, order))];
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        #endregion

        #endregion
    }
}
