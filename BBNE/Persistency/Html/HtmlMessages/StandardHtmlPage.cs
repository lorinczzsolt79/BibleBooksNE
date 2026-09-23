using BibleBooksNE.Model.Other;
using BibleBooksNE.Properties;
using BibleBooksNE.ViewAndController.Forms;

namespace BibleBooksNE.Persistency.Html.HtmlMessages
{
    /// <summary>
    /// Create a Standard Html Page without data.
    /// </summary>
    internal class StandardHtmlPage
    {

        private readonly List<string> _style = [];
        private readonly List<string> _script = [];

        public string Title { get; set; }
        public string H1 { get; set; }
        public string Main { get; set; }

        public StandardHtmlPage()
        {
            Title = string.Empty;
            H1 = string.Empty;
            Main = string.Empty;
            AddStyle(Resources.MessagesStyle);
            AddScript(Resources.MessagesScript + SetColorTheme());
        }

        private static string SetColorTheme()
        {
            return Environment.NewLine + string.Format("const DARK = {0};", Settings.Default.DarkTheme.ToString().ToLower());
        }

        /// <summary>
        /// Add CSS style in a html style element.
        /// </summary>
        /// <param name="style">CSS style</param>
        public void AddStyle(string style)
        {
            _style.Add(style);
        }

        /// <summary>
        /// Add JS script in a html script element
        /// </summary>
        /// <param name="script">JS script</param>
        public void AddScript(string script)
        {
            _script.Add(script);
        }

        public string Document()
        {
            MessagesEmptyHtmlPage emptyHtmlPage = new();
            emptyHtmlPage.SetTitlePart(Title);
            emptyHtmlPage.SetStylePart(string.Join(Environment.NewLine, _style));
            emptyHtmlPage.SetScriptPart(string.Join(Environment.NewLine, _script));
            emptyHtmlPage.SetH1Part(H1);
            emptyHtmlPage.SetMainPart(Main);
            emptyHtmlPage.SetFooterPart(FooterMsg());
            return emptyHtmlPage.Document;
        }

        private static string FooterMsg()
        {
            return $"<p>{Resources.GeneratedBy}: {Assemblies.AssemblyTitle} v.{Assemblies.AssemblyVersion} - {DT.NowHU}</p>";
        }
    }
}
