using System;
using System.Windows.Forms;

namespace BibleBooksNE.ViewAndController
{
    /// <summary>
    /// Help to show text messages in RichTextBox.
    /// </summary>
    internal class ShowIn
    {
        private readonly RichTextBox _rtb = new RichTextBox();
        public string _textSeparator = "********************\n\n";

        public ShowIn() { }

        public ShowIn(RichTextBox rtb)
        {
            _rtb = rtb;
        }

        /// <summary>
        /// the used RichTextBox.
        /// </summary>
        public RichTextBox Rtb { get { return _rtb; } }

        /// <summary>
        /// Get or Set the Text Separator.
        /// </summary>
        public string TextSeparator
        {
            get { return _textSeparator; }
            set { _textSeparator = value; }
        }

        public void Clear() { _rtb.Clear(); }

        /// <summary>
        /// Add TextSeparator to RichTextBox with line break.
        /// </summary>
        public void AppendSeparator() => AppendLine(TextSeparator);

        /// <summary>
        /// Add text to RichTextBox without line break.
        /// </summary>
        /// <param name="text"></param>
        public void Append(string text) => Rtb.AppendText(text);

        /// <summary>
        /// Add text to RichTextBox with line break.
        /// </summary>
        /// <param name="text"></param>
        public void AppendLine(string text) => Append(text + Environment.NewLine);

        /// <summary>
        /// Add text to RichTextBox with line break.
        /// </summary>
        /// <param name="texts"></param>
        public void AppendLines(string[] texts) => AppendLines(texts, false);

        /// <summary>
        /// Add text to RichTextBox with line break, started with a text separator line.
        /// </summary>
        /// <param name="texts"></param>
        public void AppendLinesSeparated(string[] texts) => AppendLines(texts, true);

        private void AppendLines(string[] texts, bool withTextSeparator)
        {
            foreach (string line in texts)
            {
                if (withTextSeparator)
                {
                    AppendLine(TextSeparator);
                }
                AppendLine(line);
            }
        }

        /// <summary>
        /// Add empty line to RichTextBox.
        /// </summary>
        public void AppendLine()
        {
            AppendLine(string.Empty);
        }
    }
}
