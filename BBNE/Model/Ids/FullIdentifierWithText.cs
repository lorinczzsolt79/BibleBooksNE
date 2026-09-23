
namespace BibleBooksNE.Model.Ids
{
    internal class FullIdentifierWithText : IComparable<FullIdentifierWithText>, IEquatable<FullIdentifierWithText>
    {

        #region General things

        private readonly FullIdentifier _fullIds;
        private readonly string _text;

        public FullIdentifierWithText()
        {
            _fullIds = new FullIdentifier();
            _text = string.Empty;
        }

        public FullIdentifierWithText(FullIdentifier fullIds, string text)
        {
            _fullIds = fullIds;
            _text = text;
        }

        public FullIdentifier Ids => _fullIds;

        public string Text => _text;

        public override string ToString()
        {
            return Ids.ToString() + " " + Text;
        }

        public int CompareTo(FullIdentifierWithText? other)
        {
            int result = 0;
            if (this != null && other != null)
            {
                result = Ids.CompareTo(other.Ids);
                if (result == 0)
                {
                    return Text.CompareTo(other.Text);
                }
            }
            return result;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as FullIdentifierWithText);
        }

        public bool Equals(FullIdentifierWithText? other)
        {
            return !(other is null) &&
                   _fullIds.Equals(other._fullIds) &&
                   _text.Equals(other.Text);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_fullIds, _text);
        }

        #endregion
    }

}
