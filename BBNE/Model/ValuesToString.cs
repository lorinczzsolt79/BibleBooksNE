using System.Collections.Generic;
using System.Text;

namespace BibleBooksNE.Model
{
    abstract class ValuesToString
    {
        private readonly char _char = '\t';
        private int _indent = 1;

        public string ToString(List<KeyValuePair<string, string>> values)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].Key.StartsWith("#"))
                {
                    _indent = int.Parse(values[i].Key.Replace("#", string.Empty));
                    sb.AppendLine(Indent() + values[i].Value);
                    ++_indent;
                }
                else
                {
                    sb.AppendLine(string.Format("{0}{1}:" + _char + "{2}", Indent(), values[i].Key, values[i].Value));
                }
            }
            return sb.ToString();
        }

        public virtual List<KeyValuePair<string, string>> Values()
        {
            return new List<KeyValuePair<string, string>>();
        }

        public string Indent()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _indent; i++)
            {
                sb.Append(_char);
            }
            return sb.ToString();
        }
    }
}
