using BibleBooksNE.Properties;
using System;
using System.Text.RegularExpressions;

namespace BibleBooksNE.Persistency.Html.HtmlMessages
{

    /// <summary>
    /// For empty Html file template modification.
    /// </summary>
    internal class MessagesEmptyHtmlPage
    {
        #region General things

        private string _fileLines;

        public MessagesEmptyHtmlPage()
        {
            try
            {
                _fileLines = Resources.MessagesEmptyHtmlFileTemplate;
            }
            catch
            {
                throw new Exception(Resources.TemplateResourceFileAccessError);
            }
        }

        public string Document => _fileLines;

        #endregion

        #region Html Element methods

        public void SetTitlePart(string title)
        {
            Replace("title", title);
        }

        public void SetStylePart(string style)
        {
            Replace("style", style);
        }

        public void SetScriptPart(string script)
        {
            Replace("script", script);
        }

        public void SetH1Part(string h1)
        {
            Replace("h1", h1);
        }

        public void SetMainPart(string main)
        {
            Replace("main", main);
        }

        public void SetFooterPart(string footer)
        {
            Replace("footer", footer);
        }

        private void Replace(string pattern, string part)
        {
            if (!string.IsNullOrWhiteSpace(part))
            {
                _fileLines = Regex.Replace(Document, Pattern(pattern), part);
            }
        }

        private static string Pattern(string text)
        {
            return "(?<=" + text + ">).*(?=</" + text + ">)";
        }

        #endregion
    }
}
