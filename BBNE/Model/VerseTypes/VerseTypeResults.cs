using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;

namespace BibleBooksNE.Model.VerseTypes
{
    internal class VerseTypeResults
    {
        private readonly FullIdentifier _fullIds;
        private readonly string _text = string.Empty;

        public VerseTypeResults(int book, int chapter, int verse, int number, string text)
        {
            _fullIds = new FullIdentifier(book, chapter, verse, number);
            _text = text;
        }

        public VerseTypeResults(int book, int chapter, int verse, string text)
        {
            _fullIds = new FullIdentifier(book, chapter, verse);
            _text = text;
        }

        public FullIdentifierWithText? FullIdsWithText(int bible, PageOrder order)
        {
            switch (order)
            {
                case PageOrder.headline_title:
                case PageOrder.verse_item:
                case PageOrder.crosslink_item:
                case PageOrder.footnote:
                case PageOrder.wordlist:
                    {
                        return new FullIdentifierWithText(new FullIdentifier(_fullIds, new Identifier(bible), order), _text);
                    }
                default: break;
            }
            return null;
        }

    }
}
