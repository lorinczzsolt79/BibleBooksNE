using BibleBooksNE.Model.Enums;
using System.Text;

namespace BibleBooksNE.Model.Ids
{
    internal class IdsWithOrders
    {
        private readonly int[] _bibles = [0];
        private readonly int _book = -1;
        private readonly int _chapter = -1;
        private readonly int _verse = -1;
        private readonly PageOrder[] _orders = [0];

        public IdsWithOrders() { }

        public IdsWithOrders(int bible, int book, int chapter, int verse, PageOrder[] orders)
        {
            _bibles = [bible];
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _orders = orders;
        }

        public IdsWithOrders(int[] bibles, int book, int chapter, int verse, PageOrder[] orders)
        {
            _bibles = bibles;
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _orders = orders;
        }

        public int[] Bibles => _bibles;
        public int Book => _book;
        public int Chapter => _chapter;
        public int Verse => _verse;
        public PageOrder[] Orders => _orders;

        public bool Empty => Bibles.Length == 0 && Book == -1 && Chapter == -1 && Verse == -1 && Orders.Length == 0;

        public bool Same(IdsWithOrders other) => SameBibles(other.Bibles) &&
            Same_Ids(other.Book, other.Chapter, other.Verse) &&
            Same_Orders(other.Orders);

        public bool SameBibles(int[] other) => Same(Bibles, other);
        public bool Same_Ids(int book, int chapter, int verse) => Book == book && Chapter == chapter && Verse == verse;
        public bool Same_Orders(PageOrder[] other) => Same(Orders, other);

        public static bool Same<T>(T[] one, T[] two)
        {
            if (one != null && two != null)
            {
                HashSet<T> a = [.. one];
                HashSet<T> b = [.. two];
                if (a.Count == b.Count)
                {
                    HashSet<T> all = [.. a];
                    foreach (T item in b)
                    {
                        all.Add(item);
                    }
                    if (all.Count == a.Count)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static readonly char Separator1 = ',';
        private static readonly char Separator2 = ';';

        public string GetState()
        {
            StringBuilder sb = new();
            sb.Append(string.Join(Separator1.ToString(), Bibles));
            sb.Append(Separator2 + Book.ToString());
            sb.Append(Separator2 + Chapter.ToString());
            sb.Append(Separator2 + Verse.ToString());
            sb.Append(Separator2 + OrdersList());
            return sb.ToString();
        }

        public static IdsWithOrders Parse(string stateString)
        {
            string[] array = stateString.Split(Separator2);
            return new IdsWithOrders(
                GetDigits(array[0]),
                int.Parse(array[1]),
                int.Parse(array[2]),
                int.Parse(array[3]),
                GetOrders(array[4])
                );
        }

        private static int[] GetDigits(string digits)
        {
            if (!string.IsNullOrWhiteSpace(digits))
            {
                return [.. (from d in digits.Split(Separator1) select int.Parse(d))];
            }
            return [0];
        }

        private static PageOrder[] GetOrders(string orders)
        {
            return [.. (from order in GetDigits(orders) select (PageOrder)order)];
        }

        private string OrdersList()
        {
            return string.Join(", ", (from o in Orders.ToList() select ((int)o).ToString()).ToArray());
        }

        public override string ToString()
        {
            return "IdsWithOrders: [" + string.Join(", ", Bibles) + "] " + Book + ", " + Chapter + ", " + Verse + " [" + string.Join(", ", Orders) + "]";
        }

    }
}
