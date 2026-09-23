using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;

namespace BibleBooksNE.Model.VerseTypes
{
    internal class VerseTypeListDictionary
    {
        private readonly Dictionary<PageOrder, List<FullIdentifierWithText>> dictionary = [];

        public VerseTypeListDictionary() { }

        public List<FullIdentifierWithText>? HeadLines
        {
            get => Get(PageOrder.headline_title);
            set => Set(value, PageOrder.headline_title);
        }
        public List<FullIdentifierWithText>? Verses
        {
            get => Get(PageOrder.verse_item);
            set => Set(value, PageOrder.verse_item);
        }

        public List<FullIdentifierWithText>? CrossLinks
        {
            get => Get(PageOrder.crosslink_item);
            set => Set(value, PageOrder.crosslink_item);
        }

        public List<FullIdentifierWithText>? Footnotes
        {
            get => Get(PageOrder.footnote);
            set => Set(value, PageOrder.footnote);
        }

        public List<FullIdentifierWithText>? WordList
        {
            get => Get(PageOrder.wordlist);
            set => Set(value, PageOrder.wordlist);
        }

        public List<FullIdentifierWithText>? Audios
        {
            get => Get(PageOrder.audio);
            set => Set(value, PageOrder.audio);
        }

        private void Set(List<FullIdentifierWithText>? value, PageOrder order)
        {
            if (value != null)
            {
                if (!dictionary.TryAdd(order, value))
                {
                    dictionary[order] = value;
                }
            }
            else
            {
                dictionary.Remove(order);
            }
        }

        public List<FullIdentifierWithText>? Get(PageOrder order)
        {
            if (Orders.Contains(order))
            {
                if (dictionary.TryGetValue(order, out var result))
                {
                    return result;
                }
            }
            return null;
        }

        public static List<PageOrder> Orders => [
                PageOrder.headline_title,
                PageOrder.verse_item,
                PageOrder.crosslink_item,
                PageOrder.footnote,
                PageOrder.wordlist,
                PageOrder.audio ];

        public Counters Count()
        {
            long[] result = [0, 0, 0, 0, 0, 0];
            for (int i = 0; i < Orders.Count; i++)
            {
                var list = Get(Orders[i]);
                if (list != null)
                {
                    result[i] = list.Count;
                }
            }
            return new Counters(result[0], result[1], result[2], result[3], result[4], result[5]);
        }

        public IEnumerable<FullIdentifierWithText> All()
        {
            foreach (KeyValuePair<PageOrder, List<FullIdentifierWithText>> list in dictionary)
            {
                foreach (FullIdentifierWithText item in list.Value)
                {
                    yield return item;
                }
            }
        }

    }
}
