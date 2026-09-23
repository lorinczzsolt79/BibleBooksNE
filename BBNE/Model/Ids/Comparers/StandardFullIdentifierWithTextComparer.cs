namespace BibleBooksNE.Model.Ids.Comparers
{
    internal class StandardFullIdentifierWithTextComparer : IComparer<FullIdentifierWithText>
    {
        public int Compare(FullIdentifierWithText? first, FullIdentifierWithText? second)
        {
            if (first != null && second != null) return first.CompareTo(second);
            return 0;
        }
    }
}
