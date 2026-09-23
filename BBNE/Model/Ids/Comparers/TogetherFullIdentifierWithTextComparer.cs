using BibleBooksNE.Model.Enums;

namespace BibleBooksNE.Model.Ids.Comparers
{
    internal class TogetherFullIdentifierWithTextComparer : IComparer<FullIdentifierWithText>
    {

        public int Compare(FullIdentifierWithText? first, FullIdentifierWithText? second)
        {
            if (first != null && second != null)
            {
                int result = SortingTogether(first.Ids, second.Ids);
                if (result == 0)
                {
                    return first.Text.CompareTo(second.Text);
                }
                return result;
            }
            return 0;
        }

        private static int SortingTogether(FullIdentifier first, FullIdentifier second)
        {

            if (Before(first.Type.N, second.Type.N))    // both Before
            {
                return new BeforeComparer().Compare(first, second);
            }
            else
            {
                return new AfterComparer().Compare(first, second);
            }
        }

        private static bool Before(int first, int second)
        {
            int _1st = OrderComparer(first, PageOrder.break_point);
            int _2nd = OrderComparer(second, PageOrder.break_point);
            if (_1st < 0 && _2nd < 0)
            {
                return true;  // both Before 
            }
            return false;
        }

        private static int OrderComparer(int number, PageOrder order)
        {
            int _order = (int)order;
            if (number == _order)
            {
                return 0;   // same
            }
            if (number > _order)
            {
                return 1;   // after
            }
            else
            {
                return -1;  // before
            }
        }

    }
}
