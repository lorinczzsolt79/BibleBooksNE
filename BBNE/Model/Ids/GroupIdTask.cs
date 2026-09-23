
using BibleBooksNE.Model.Enums;

namespace BibleBooksNE.Model.Ids
{
    internal class GroupIdTask
    {
        private PageOrder _pageOrder = PageOrder.unknown;

        public HashSet<FullIdentifierWithText> Items { get; } = [];

        public GroupIdTask() { }
        public GroupIdTask(PageOrder pageOrder)
        {
            _pageOrder = pageOrder;
        }

        public void Add(FullIdentifierWithText fullIdentifierWithText)
        {
            foreach (FullIdentifierWithText item in new GroupIdMaker(fullIdentifierWithText).Make(_pageOrder))
            {
                Items.Add(item);
            }
        }

        public void AddAll(FullIdentifierWithText[] fullIdentifierWithText)
        {
            foreach (FullIdentifierWithText item in fullIdentifierWithText)
            {
                Add(item);
            }
        }

    }
}
