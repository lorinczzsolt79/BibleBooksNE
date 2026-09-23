using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;
using BibleBooksNE.Model.Ids.Comparers;
using BibleBooksNE.Properties;

namespace BibleBooksNE.Model.VerseTypes
{
    internal class VerseTypeListDictionaries
    {
        #region General things

        private readonly Dictionary<int, VerseTypeListDictionary> dictionary = [];

        public VerseTypeListDictionaries() { }

        public VerseTypeListDictionaries(int[] values)
        {
            AddAllKey(values);
        }

        public void Set(int index, VerseTypeListDictionary? value)
        {
            if (value != null)
            {
                if (!dictionary.TryAdd(index, value))
                {
                    dictionary[index] = value;
                }
            }
            else
            {
                dictionary.Remove(index);
            }
        }

        public VerseTypeListDictionary? Get(int index)
        {
            if (dictionary.TryGetValue(index, out var result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public bool ContainsKey(int key)
        {
            return dictionary.ContainsKey(key);
        }

        #endregion

        #region All

        private void AddAllKey(int[] values)
        {
            if (values != null)
            {
                foreach (int item in values)
                {
                    if (item >= 0)
                    {
                        Set(item, new());
                    }
                }
            }
        }

        private IEnumerable<FullIdentifierWithText> GetAll(PageOrder order) => GetAll([order]);

        private IEnumerable<FullIdentifierWithText> GetAll(PageOrder[] orders)
        {
            foreach (PageOrder order in orders)
            {
                foreach (KeyValuePair<int, VerseTypeListDictionary> dic in dictionary)
                {
                    var variable = dic.Value.Get(order);
                    if (variable != null)
                    {
                        foreach (FullIdentifierWithText item in variable)
                        {
                            yield return item;
                        }
                    }
                }
            }
        }

        #endregion

        #region Group ids

        private FullIdentifierWithText[] GetGroupIds(PageOrder pageOrder)
        {
            GroupIdTask groupIdTask = new(pageOrder);
            foreach (var item in GetAll(pageOrder))
            {
                groupIdTask.Add(item);
            }
            List<FullIdentifierWithText> list = [.. groupIdTask.Items];
            list.Sort(new StandardFullIdentifierWithTextComparer());
            return [.. list];
        }

        public FullIdentifierWithText[] VerseGroupIds => GetGroupIds(PageOrder.verse_item);
        public FullIdentifierWithText[] FootnoteGroupIds => GetGroupIds(PageOrder.footnote);
        public FullIdentifierWithText[] WordListGroupIds => GetGroupIds(PageOrder.wordlist);

        #endregion

        private PageOrder[] PageOrders = [
            PageOrder.headline_title,
            PageOrder.chapter_title,
            PageOrder.verse_item,
            PageOrder.crosslink_item];

        public List<FullIdentifierWithText> VerseTypeItems()
        {
            List<FullIdentifierWithText> list = [.. GetAll(PageOrders)];
            list.AddRange(VerseGroupIds);
            if (Settings.Default.SortingType)
            {
                list.Sort(new TogetherFullIdentifierWithTextComparer());
            }
            else
            {
                list.Sort(new StandardFullIdentifierWithTextComparer());
            }
            return [.. list];
        }

        public List<FullIdentifierWithText> FootnotesItems()
        {
            List<FullIdentifierWithText> list = [.. GetAll(PageOrder.footnote)];
            list.AddRange(FootnoteGroupIds);
            list.Sort(new StandardFullIdentifierWithTextComparer());
            return [.. list];
        }

        public List<FullIdentifierWithText> WorListItems()
        {
            List<FullIdentifierWithText> list = [.. GetAll(PageOrder.wordlist)];
            list.AddRange(WordListGroupIds);
            list.Sort(new StandardFullIdentifierWithTextComparer());
            return [.. list];
        }

        #region Statistic

        public Counters[] Statistic() => Count();

        private Counters[] Count()
        {
            List<Counters> counters = [];
            foreach (KeyValuePair<int, VerseTypeListDictionary> item in dictionary)
            {
                counters.Add(new Counters(item.Key, item.Value.Count()));
            }
            return [.. counters];
        }

        #endregion
    }
}
