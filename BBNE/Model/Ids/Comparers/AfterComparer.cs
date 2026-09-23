namespace BibleBooksNE.Model.Ids.Comparers
{

    internal class AfterComparer : IComparer<FullIdentifier>
    {
        public int Compare(FullIdentifier? first, FullIdentifier? second)
        {
            int result = 0;
            if (first != null && second != null)
            {
                result = FullIdentifierComparer.Compare([
                    first.Type.CompareTo(second.Type),
                    first.Bible.CompareTo(second.Bible),
                    first.Book.CompareTo(second.Book),
                    first.Chapter.CompareTo(second.Chapter),
                    first.Verse.CompareTo(second.Verse),
                    first.Number.CompareTo(second.Number)
                ]);
            }
            return result;
        }
    }

}
