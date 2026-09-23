using System.Linq;
using System.Text.RegularExpressions;

namespace BibleBooksNE.Model
{
    internal class NumberedListBoxItem
    {
        public int Number { get; set; }
        public string Label { get; set; }

        public NumberedListBoxItem()
        {
            Number = -1;
            Label = string.Empty;
        }

        public NumberedListBoxItem(int number, string label)
        {
            Number = number;
            Label = label;
        }

        public NumberedListBoxItem(int number)
        {
            Number = number;
            Label = string.Empty;
        }

        public NumberedListBoxItem[] Parse(string[] numberedListBoxItems)
        {
            return (from item in numberedListBoxItems.ToList() select new NumberedListBoxItem().Parse(item)).ToArray();
        }

        public NumberedListBoxItem Parse(string numberedListBoxItem)
        {
            if (string.IsNullOrWhiteSpace(numberedListBoxItem))
            {
                Number = -1;
                Label = string.Empty;
            }
            else
            {
                // If the string starts with digit + dot + space.
                if (Regex.IsMatch(numberedListBoxItem, "^\\d*\\. "))
                {
                    // Extract and set the digit.
                    Number = int.Parse(Regex.Match(numberedListBoxItem, "^\\d*(?=\\. .*)").ToString());
                    // Extract and set the label.
                    Label = Regex.Match(numberedListBoxItem, "(?<=^\\d*\\. ).*").ToString();
                }
                else
                {
                    Number = -1;
                    Label = numberedListBoxItem;
                }
            }
            return this;
        }

        override
        public string ToString()
        {
            return string.Format("{0}. {1}", Number, Label);
        }
    }
}
