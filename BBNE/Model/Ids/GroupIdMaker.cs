using BibleBooksNE.Model.Enums;
using BibleBooksNE.Properties;

namespace BibleBooksNE.Model.Ids
{
    internal class GroupIdMaker(FullIdentifierWithText fullIdentifierWithText)
    {
        private FullIdentifier FullIdentifier => fullIdentifierWithText.Ids;

        public PageOrder _pageOrder = PageOrder.none;

        public FullIdentifierWithText[] Make(PageOrder pageOrder)
        {
            _pageOrder = GetGroupItem(pageOrder);
            List<FullIdentifierWithText> list = [
                    FullIdWithText(BibleGroupId()),
                    FullIdWithText(BibleBookGroupId()),
                    FullIdWithText(BibleBookChapterGroupId()),
                    FullIdWithText(BibleBookChapterVerseGroupId())
                ];
            return [.. list];
        }

        private static PageOrder GetGroupItem(PageOrder pageOrder)
        {
            return pageOrder switch
            {
                PageOrder.headline_title or
                PageOrder.chapter_title or
                PageOrder.verse_item or
                PageOrder.crosslink_item or
                PageOrder.item_group => PageOrder.item_group,
                PageOrder.footnote or
                PageOrder.footnote_group => PageOrder.footnote_group,
                PageOrder.wordlist or
                PageOrder.wordlist_group => PageOrder.wordlist_group,
                _ => throw new ArgumentException("No group enum for this type (" + pageOrder.ToString() + ").")
            };
        }

        #region FullIds
        private static FullIdentifierWithText FullIdWithText(FullIdentifier fi)
        {
            return new FullIdentifierWithText(fi, string.Empty);
        }

        private FullIdentifier BibleGroupId()
        {
            return new FullIdentifier(SeBibleId(),
                                       new(),
                                       new(),
                                       new(),
                                       new(),
                                       PageOrder.bible
                                    );
        }

        private Identifier SeBibleId()
        {
            if (After())
            {
                return FullIdentifier.Bible;
            }
            else
            {
                return Settings.Default.SortingType ? new() : FullIdentifier.Bible;
            }
        }

        private bool After()
        {
            return (int)PageOrder.break_point <= (int)_pageOrder;
        }

        private FullIdentifier BibleBookGroupId()
        {
            return new FullIdentifier(SeBibleId(),
                                       FullIdentifier.Book,
                                       new(),
                                       new(),
                                       new(),
                                       PageOrder.book
                                    );
        }

        private FullIdentifier BibleBookChapterGroupId()
        {
            return new FullIdentifier(SeBibleId(),
                                       FullIdentifier.Book,
                                       FullIdentifier.Chapter,
                                       new(),
                                       new(),
                                       PageOrder.chapter
                                    );
        }

        public FullIdentifier BibleBookChapterVerseGroupId()
        {
            return new FullIdentifier(SeBibleId(),
                                       FullIdentifier.Book,
                                       FullIdentifier.Chapter,
                                       After() ? new() : FullIdentifier.Verse,
                                       new(),
                                       _pageOrder
                                    );
        }

        #endregion

    }
}
