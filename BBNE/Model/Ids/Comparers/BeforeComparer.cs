namespace BibleBooksNE.Model.Ids.Comparers
{

    internal class BeforeComparer : IComparer<FullIdentifier>
    {
        public int Compare(FullIdentifier? first, FullIdentifier? second)
        {

            int result = 0;
            if (first != null && second != null)
            {
                result = FullIdentifierComparer.Compare([
                    first.Book.CompareTo(second.Book),
                    first.Chapter.CompareTo(second.Chapter),
                    first.Verse.CompareTo(second.Verse),
                    first.Number.CompareTo(second.Number),
                    first.Bible.CompareTo(second.Bible),
                    first.Type.CompareTo(second.Type)
                ]);
            }
            return result;
        }
    }

}
