using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids.Comparers;
using BibleBooksNE.ViewAndController.Navigation;
using System.Text;

namespace BibleBooksNE.Model.Ids
{
    internal class FullIdentifier : IComparable<FullIdentifier>, IEquatable<FullIdentifier>
    {

        #region Identifiers, Getters, Empty Constructor

        private readonly Identifier _bible = new();
        private readonly Identifier _book = new();
        private readonly Identifier _chapter = new();
        private readonly Identifier _verse = new();
        private readonly Identifier _number = new();
        private readonly Identifier _type = new();

        public Identifier Bible => _bible;
        public Identifier Book => _book;
        public Identifier Chapter => _chapter;
        public Identifier Verse => _verse;
        public Identifier Number => _number;
        public Identifier Type => _type;

        public FullIdentifier() { }

        #endregion

        #region Constructors with Identifiers

        public FullIdentifier(Identifier bible, Identifier book, Identifier chapter, Identifier verse, Identifier number, PageOrder type)
        {
            _bible = bible;
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _number = number;
            _type = new Identifier(SetOrderNumber(type));
        }

        public FullIdentifier(Identifier bible, Identifier book, Identifier chapter, Identifier verse)
        {
            _bible = bible;
            _book = book;
            _chapter = chapter;
            _verse = verse;
        }

        public FullIdentifier(FullIdentifier fullIds, Identifier bible, PageOrder type)
        {
            _bible = bible;
            _book = fullIds.Book;
            _chapter = fullIds.Chapter;
            _verse = fullIds.Verse;
            _number = fullIds.Number;
            _type = new Identifier(SetOrderNumber(type));
        }

        public FullIdentifier(FullIdentifier fullIds, Identifier number)
        {
            _bible = fullIds.Bible;
            _book = fullIds.Book;
            _chapter = fullIds.Chapter;
            _verse = fullIds.Verse;
            _number = number;
            _type = new Identifier(SetOrderNumber(PageOrder.footnote));
        }

        public FullIdentifier(bool sortingType, FullIdentifier fullIds)
        {
            _bible = sortingType ? new() : fullIds.Bible;
            _book = fullIds.Book;
            _chapter = fullIds.Chapter;
            _verse = fullIds.Verse;
            _number = new();
            _type = new Identifier(SetOrderNumber(PageOrder.item_group));
        }

        private PageOrder SetOrderNumber(PageOrder order)
        {
            if (PageOrder.verse_item.Equals(order) && Verse.N == 0)
            {
                return PageOrder.chapter_title;
            }
            return order;
        }

        #endregion

        #region Constructors with Integers

        /// <summary>
        /// Constructor for SQL data transformation with number
        /// </summary>
        /// <param name="book">book id</param>
        /// <param name="chapter">chapter id</param>
        /// <param name="verse">verse id</param>
        /// <param name="number">number id</param>
        public FullIdentifier(int book, int chapter, int verse, int number)
        {
            _book = new Identifier(book);
            _chapter = new Identifier(chapter);
            _verse = new Identifier(verse);
            _number = new Identifier(number);
        }

        /// <summary>
        /// Constructor for SQL data transformation
        /// </summary>
        /// <param name="book">book id</param>
        /// <param name="chapter">chapter id</param>
        /// <param name="verse">verse id</param>
        public FullIdentifier(int book, int chapter, int verse)
        {
            _book = new Identifier(book);
            _chapter = new Identifier(chapter);
            _verse = new Identifier(verse);
        }

        #endregion

        #region Parser

        public static FullIdentifier TryParser(string identifiers, char separator)
        {
            try
            {
                int[] ids = Parser(identifiers, separator);
                return new FullIdentifier(
                    ToId(ids, 0),
                    ToId(ids, 1),
                    ToId(ids, 2),
                    ToId(ids, 3),
                    ToId(ids, 4),
                    ids.Length > 5 ? (PageOrder)ids[5] : PageOrder.unknown
                    );
            }
            catch
            {
                throw new Exception("FullIdentifier parse error!");
            }
        }

        private static Identifier ToId(int[] ids, int index)
        {
            return ids.Length > index ? new Identifier(ids[index]) : new();
        }

        /// <summary>
        /// For Identifiers string that contain one or more separator character
        /// </summary>
        /// <param name="identifiers">001.002.003</param>
        /// <param name="separator">.</param>
        /// <returns>numbers: 1, 2, 3</returns>
        public static int[] Parser(string identifiers, char separator)
        {
            List<int> list = [];
            if (!string.IsNullOrWhiteSpace(identifiers) && separator >= 32)
            {
                string[] array = identifiers.Split(separator);
                if (array.Length > 0)
                {
                    if (array.Length == 1)
                    {
                        list.Add(new Identifier().Parser(array[0]));
                    }
                    else
                    {
                        foreach (string item in array)
                        {
                            if (!string.IsNullOrWhiteSpace(item))
                            {
                                list.Add(new Identifier().Parser(item));
                            }
                        }
                    }
                }
            }
            return [.. list];
        }

        /// <summary>
        /// For Identifiers string that not contain any separator character
        /// </summary>
        /// <param name="identifiers">001002003</param>
        /// <param name="pieces">3</param>
        /// <returns>numbers: 1, 2, 3</returns>
        public static int[] Parser(string identifiers, int pieces)
        {
            List<int> list = [];
            if (!string.IsNullOrWhiteSpace(identifiers))
            {
                if (pieces > 0)
                {
                    if (pieces == 1)
                    {
                        list.Add(new Identifier().Parser(identifiers));
                    }
                    else
                    {
                        if (identifiers.Length % pieces == 0)
                        {
                            int n = identifiers.Length / pieces;
                            for (int i = 0; i < identifiers.Length; i += n)
                            {
                                list.Add(new Identifier().Parser(identifiers.Substring(i, n)));
                            }
                        }
                    }
                }
            }
            return [.. list];
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return ToString(NameType.number_with_separator);
        }

        public string ToString(NameType nameType)
        {
            StringBuilder sb = new();
            sb.Append(Bible.ToString(nameType));
            sb.Append(Book.ToString(nameType));
            sb.Append(Chapter.ToString(nameType));
            sb.Append(Verse.ToString(nameType));
            sb.Append(Number.ToString(nameType));
            sb.Append(Type.ToString(nameType));
            return sb.ToString();
        }

        #endregion

        #region ComperTo method

        public int CompareTo(FullIdentifier? other)
        {
            if (this != null && other != null)
            {
                return new StandardFullIdentifierComparer().Compare(this, other);
            }
            return 0;
        }

        public override bool Equals(object? obj)
        {
            return obj is FullIdentifier identifier &&
                   EqualityComparer<Identifier>.Default.Equals(_bible, identifier._bible) &&
                   EqualityComparer<Identifier>.Default.Equals(_book, identifier._book) &&
                   EqualityComparer<Identifier>.Default.Equals(_chapter, identifier._chapter) &&
                   EqualityComparer<Identifier>.Default.Equals(_verse, identifier._verse) &&
                   EqualityComparer<Identifier>.Default.Equals(_number, identifier._number) &&
                   EqualityComparer<Identifier>.Default.Equals(_type, identifier._type);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_bible, _book, _chapter, _verse, _number, _type);
        }

        public bool Equals(FullIdentifier? other)
        {
            if (other != null)
            {
                return Equals((object)other);
            }
            return false;
        }

        public static bool operator ==(FullIdentifier? left, FullIdentifier? right)
        {
            return EqualityComparer<FullIdentifier>.Default.Equals(left, right);
        }

        public static bool operator !=(FullIdentifier? left, FullIdentifier? right)
        {
            return !(left == right);
        }

        #endregion

    }
}
