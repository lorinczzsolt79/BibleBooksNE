namespace BibleBooksNE.Model.Ids.Comparers
{

    internal class FullIdentifierComparer
    {
        public static int Compare(int[] results)
        {
            int result = results[0];
            if (result == 0)
            {
                result = results[1];
                if (result == 0)
                {
                    result = results[2];
                    if (result == 0)
                    {
                        result = results[3];
                        if (result == 0)
                        {
                            result = results[4];
                            if (result == 0)
                            {
                                result = results[5];
                            }
                        }
                    }
                }
            }
            return result;
        }
    }

}
