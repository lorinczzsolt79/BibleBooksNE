using System.Text.RegularExpressions;

namespace BibleBooksNE.ViewAndController.Navigation
{

    public class UriSplitter
    {
        private KeyValuePair<string, string> _headAndTail = new();

        public UriSplitter(string uri)
        {
            _headAndTail = GetTypeAndTail(uri);
        }

        public KeyValuePair<string, string> HeadAndTail => _headAndTail;

        private static KeyValuePair<string, string> GetTypeAndTail(string uri)
        {
            return new KeyValuePair<string, string>(GetPart(uri, "^.*?(?=:)"), GetPart(uri, "(?<=^.*?:).*"));
        }

        private static string GetPart(string uri, string pattern)
        {
            if (!string.IsNullOrWhiteSpace(uri))
            {
                try
                {
                    return Regex.Match(uri, pattern).ToString();
                }
                catch { }
            }
            return string.Empty;
        }

        public override string? ToString()
        {
            return "Key: " + _headAndTail.Key + "\n" + _headAndTail.Value ;
        }
    }
    
}
