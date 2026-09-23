using BibleBooksNE.Properties;
using System.Windows.Forms;

namespace BibleBooksNE.ViewAndController
{
    internal class Msg
    {
        public static void Error(string text)
        {
            OkMsg(text, Resources.Error, MessageBoxIcon.Error);
        }

        public static void Warning(string text)
        {
            OkMsg(text, Resources.Warning, MessageBoxIcon.Warning);
        }

        public static void Info(string text)
        {
            OkMsg(text, Resources.Information, MessageBoxIcon.Information);
        }

        private static void OkMsg(string text, string caption, MessageBoxIcon icon)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, icon);
        }

        public static bool YesOrNo(string text)
        {
            if (MessageBox.Show(text,
                Resources.Question,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
