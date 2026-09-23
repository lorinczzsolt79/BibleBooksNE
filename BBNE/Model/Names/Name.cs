using BibleBooksNE.Model.Enums;
using BibleBooksNE.Model.Ids;
using BibleBooksNE.Properties;
using System.Collections.Generic;

namespace BibleBooksNE.Model.Names
{
    internal class Name : ValuesToString
    {
        #region General things

        private readonly Identifier _id = new Identifier();
        private readonly string _shortName = string.Empty;      // short bible or book name, for example: GEN
        private readonly string _longName = string.Empty;       // long bible or book name, for example: Genesis
        private readonly string _directoryName = string.Empty;  // usually same as _shortName

        public Name()
        {
            NameSeparator = _id.Separator;
        }

        public Name(int number, string shortName, string longName, string dirName)
        {
            _id = new Identifier(number);
            _shortName = shortName;
            _longName = longName;
            _directoryName = dirName;
            NameSeparator = _id.Separator;
        }

        public Identifier Id => _id;

        public string ShortName => _shortName;

        public string LongName => _longName;

        public string DirName => _directoryName;

        public char IdSeparator { get; set; }
        public char NameSeparator { get; set; }

        public char SetSeparators
        {
            set
            {
                NameSeparator = value;
                IdSeparator = value;
            }
        }

        public string GetName(NameType nameType)
        {
            switch (nameType)
            {
                case NameType.number_with_separator: return Id.ToString_WithSeparator();
                case NameType.formatted_number: return Id.ToString_Formatted();
                case NameType.formatted_number_with_separator: return Id.ToString_Formatted_WithSeparator();
                case NameType.short_name: return ShortName;
                case NameType.long_name: return LongName;
                case NameType.directory_name: return DirName;
                case NameType.short_name_with_separator : return AddSeparator(ShortName);
                case NameType.long_name_with_separator : return AddSeparator(LongName);
                case NameType.directory_name_with_separator: return AddSeparator(DirName);
                default: return Id.ToString();
            }
        }

        private string AddSeparator(string name) => string.Format("{0}{1}", name, NameSeparator);

        #endregion

        #region Values, ToString

        public override string ToString()
        {
            return ToString(Values());
        }

        public override List<KeyValuePair<string, string>> Values()
        {
            return new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("#3",Resources.Name),
                new KeyValuePair<string, string>(Resources.Identifier, Id.N.ToString()),
                new KeyValuePair<string, string>(Resources.ShortName, ShortName),
                new KeyValuePair<string, string>(Resources.LongName, LongName),
                new KeyValuePair<string, string>(Resources.DirectoryName, DirName)
            };
        }

        #endregion

    }
}
