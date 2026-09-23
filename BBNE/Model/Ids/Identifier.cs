using BibleBooksNE.Model.Enums;
using System;

namespace BibleBooksNE.Model.Ids
{
    internal class Identifier : IComparable<Identifier> , IEquatable<Identifier>
    {
        #region General things

        private static readonly char Delimiter_Char = '.';
        private static readonly char Padding_Char = '0';
        private static readonly int Total_Length = 3;
        private static readonly int DefaultValue = -1;

        private readonly int _id = DefaultValue;
        private char _separator = Delimiter_Char;
        private char _paddingChar = Padding_Char;
        private int _totalLength = Total_Length;

        public Identifier()
        {
        }

        public Identifier(int id)
        {
            _id = id;
        }

        public Identifier(string id)
        {
            _id = Parse(id).N;
        }

        public Identifier(PageOrder id)
        {
            _id = (int)id;
        }

        public int N => _id;

        public int TotalLength
        {
            get { return _totalLength; }
            set
            {
                if (value < 1)
                {
                    _totalLength = 1;
                }
                else
                {
                    _totalLength = value;
                }
            }
        }

        public char PaddingChar
        {
            get { return _paddingChar; }
            set
            {
                if (value < 32)
                {
                    _paddingChar = Padding_Char;
                }
                else
                {
                    _paddingChar = value;
                }
            }
        }

        public char Separator
        {
            get { return _separator; }
            set
            {
                if (value < 32 && char.IsDigit(value))
                {
                    _separator = Delimiter_Char;
                }
                else
                {
                    _separator = value;
                }
            }
        }

        public int CompareTo(Identifier? other)
        {
            if (other != null)
            {
                return N.CompareTo(other.N);
            }
            return 0;
        }

        #endregion

        #region Parser methods

        public Identifier Parse(string identifier)
        {
            try
            {
                return new Identifier(Parser(identifier));
            }
            catch { }
            return new Identifier();
        }

        public int Parser(string identifier)
        {
            if (!string.IsNullOrWhiteSpace(identifier))
            {
                if (identifier.Length <= TotalLength + 1)
                {
                    string str = identifier.TrimEnd(Separator);
                    if (str.Length <= TotalLength)
                    {
                        str = str.TrimStart(PaddingChar);
                        if (str.Equals(string.Empty))
                        {
                            return 0;
                        }
                        if (int.TryParse(str, out int result))
                        {
                            return result;
                        }
                    }
                }
            }
            return DefaultValue;
        }

        #endregion

        #region ToString methods

        public override string ToString()
        {
            return ToString(false, false);
        }

        /// <summary>
        /// number with separator.
        /// </summary>
        /// <returns>1.</returns>
        public string ToString_WithSeparator()
        {
            return ToString(false, true);
        }

        /// <summary>
        /// Formatted number
        /// </summary>
        /// <returns>001</returns>
        public string ToString_Formatted()
        {
            return ToString(true, false);
        }

        /// <summary>
        /// Formatted number with separator
        /// </summary>
        /// <returns>001.</returns>
        public string ToString_Formatted_WithSeparator()
        {
            return ToString(true, true);
        }

        public string ToString(NameType nameType)
        {
            switch (nameType)
            {
                case NameType.number_with_separator: { return ToString_WithSeparator(); }
                case NameType.formatted_number: { return ToString_Formatted(); }
                case NameType.formatted_number_with_separator: { return ToString_Formatted_WithSeparator(); }
                default: return ToString();
            }
        }

        private string ToString(bool formatted, bool withSeparator)
        {
            string n = N.ToString();
            if (formatted)
            {
                n = n.PadLeft(TotalLength, PaddingChar);
            }
            if (withSeparator)
            {
                n += Separator;
            }
            return n;
        }

        #endregion

        public bool Equals(Identifier? other)
        {
            if (other != null)
            {
                return Equals((object)other);
            }
            return false;
        }

        public override bool Equals(object? obj)
        {
            return obj is Identifier identifier && _id.Equals(identifier._id);
        }

        public override int GetHashCode()
        {
            return 1969571243 + _id.GetHashCode();
        }

    }
}
