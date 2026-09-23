using BibleBooksNE.Properties;
using System.Windows.Forms;

namespace BibleBooksNE.ViewAndController
{
    /* How to make context menu in richTextBox?
     * Source: https://ourcodeworld.com/articles/read/1094/how-to-implement-a-copy-cut-and-paste-context-menu-over-a-rich-text-box-in-winforms-c-sharp
     * Initialize!  RichTextBox_Title.EnableContextMenu(LocalizationLabels_ContextMenuForRichTextBox labels);
     * Important!   Create the ExtensionMethods class as a "public static" class
     */
    public static class ContextMenuForRichTextBox
    {
        public static void EnableContextMenu(this RichTextBox rtb)
        {
            if (rtb.ContextMenuStrip == null)
            {
                // Create a ContextMenuStrip without icons
                ContextMenuStrip cms = new ContextMenuStrip();
                cms.ShowImageMargin = false;

                // 1. Add the Undo option 
                ToolStripMenuItem toolStripMenuItem_Undo = new ToolStripMenuItem(Resources.Undo);
                toolStripMenuItem_Undo.Click += (sender, e) => rtb.Undo();
                cms.Items.Add(toolStripMenuItem_Undo);

                // 2. Add the Redo option
                ToolStripMenuItem toolStripMenuItem_Redo = new ToolStripMenuItem(Resources.Redo);
                toolStripMenuItem_Redo.Click += (sender, e) => rtb.Redo();
                cms.Items.Add(toolStripMenuItem_Redo);

                // Add a Separator
                cms.Items.Add(new ToolStripSeparator());

                // 3. Add the Cut option (cuts the selected text inside the RichTextBox)
                ToolStripMenuItem toolStripMenuItem_Cut = new ToolStripMenuItem(Resources.Cut);
                toolStripMenuItem_Cut.Click += (sender, e) => rtb.Cut();
                cms.Items.Add(toolStripMenuItem_Cut);

                // 4. Add the Copy option (copies the selected text inside the RichTextBox)
                ToolStripMenuItem toolStripMenuItem_Copy = new ToolStripMenuItem(Resources.Copy);
                toolStripMenuItem_Copy.Click += (sender, e) => rtb.Copy();
                cms.Items.Add(toolStripMenuItem_Copy);

                // 5. Add the Paste option (adds the text from the clipboard into the RichTextBox)
                ToolStripMenuItem toolStripMenuItem_Paste = new ToolStripMenuItem(Resources.Paste);
                toolStripMenuItem_Paste.Click += (sender, e) => rtb.Paste();
                cms.Items.Add(toolStripMenuItem_Paste);

                // 6. Add the Delete Option (remove the selected text in the RichTextBox)
                ToolStripMenuItem toolStripMenuItem_Delete = new ToolStripMenuItem(Resources.Delete);
                toolStripMenuItem_Delete.Click += (sender, e) => rtb.SelectedText = string.Empty;
                cms.Items.Add(toolStripMenuItem_Delete);

                // Add a Separator
                cms.Items.Add(new ToolStripSeparator());

                // 7. Add the Select All Option (selects all the text inside the RichTextBox)
                ToolStripMenuItem toolStripMenuItem_SelectAll = new ToolStripMenuItem(Resources.SelectAll);
                toolStripMenuItem_SelectAll.Click += (sender, e) => rtb.SelectAll();
                cms.Items.Add(toolStripMenuItem_SelectAll);


                // When opening the menu, check if the condition is fulfilled 
                // in order to enable the action
                cms.Opening += (sender, e) => {
                    toolStripMenuItem_Undo.Enabled = !rtb.ReadOnly && rtb.CanUndo;
                    toolStripMenuItem_Redo.Enabled = !rtb.ReadOnly && rtb.CanRedo;
                    toolStripMenuItem_Cut.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                    toolStripMenuItem_Copy.Enabled = rtb.SelectionLength > 0;
                    toolStripMenuItem_Paste.Enabled = !rtb.ReadOnly && Clipboard.ContainsText();
                    toolStripMenuItem_Delete.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                    toolStripMenuItem_SelectAll.Enabled = rtb.TextLength > 0 && rtb.SelectionLength < rtb.TextLength;
                };

                rtb.ContextMenuStrip = cms;
            }
        }
    }

}
