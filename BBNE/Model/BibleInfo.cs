using BibleBooksNE.Model.Names;
using BibleBooksNE.Properties;
using System.Collections.Generic;

namespace BibleBooksNE.Model
{
    internal class BibleInfo : ValuesToString
    {
        #region General things

        private readonly Name _name;
        private readonly string _language = string.Empty;
        private readonly string _description = string.Empty;
        private readonly string _url = string.Empty;
        private readonly string _version = string.Empty;
        private readonly string _type = string.Empty;
        private readonly string _copyright = string.Empty;

        public BibleInfo(int bibleId, string shortName, string longName, string dirName, string language, string description, string url, string version, string type, string copyright)
        {
            _name = new Name(bibleId, shortName, longName, dirName);
            _language = language;
            _description = description;
            _url = url;
            _version = version;
            _type = type;
            _copyright = copyright;
        }

        public Name BibleNames => _name;

        public int BibleId => BibleNames.Id.N;
        public string Language => _language;
        public string Description => _description;
        public string Url => _url;
        public string Version => _version;
        public string Type => _type;
        public string Copyright => _copyright;

        #endregion

        #region Values, ToString

        public override string ToString()
        {
            return ToString(Values());
        }

        public override List<KeyValuePair<string, string>> Values()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("#2", Resources.BibleInformation)
            };
            list.AddRange(BibleNames.Values());
            list.Add(new KeyValuePair<string, string>("#2", string.Empty));
            list.Add(new KeyValuePair<string, string>(Resources.Identifier, BibleId.ToString()));
            list.Add(new KeyValuePair<string, string>(Resources.Language, Language));
            list.Add(new KeyValuePair<string, string>(Resources.Description, Description));
            list.Add(new KeyValuePair<string, string>(Resources.SourceUrl, Url));
            list.Add(new KeyValuePair<string, string>(Resources.Version, Version));
            list.Add(new KeyValuePair<string, string>(Resources.Type, Type));
            list.Add(new KeyValuePair<string, string>(Resources.Copyright, Copyright));
            return list;
        }

        #endregion

    }
}







