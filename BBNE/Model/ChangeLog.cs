using BibleBooksNE.Model.Ids;
using BibleBooksNE.Model.Other;

namespace BibleBooksNE.Model
{
    internal class ChangeLog
    {

        #region General things
        
        private Identifier _identifier;
        private string _date;
        private string _text;

        public ChangeLog()
        {
            _identifier = new Identifier();
            _date = DT.DateEN;
            _text = string.Empty;
        }

        public ChangeLog(int identifier, string date, string text)
        {
            _identifier = new Identifier(identifier);
            _date = date;
            _text = text;
        }

        public ChangeLog(Identifier identifier, string date, string text)
        {
            _identifier = identifier;
            _date = date;
            _text = text;
        }

        public Identifier Id { get { return _identifier; } set { _identifier = value; } }
        public string Date { get { return _date; } set { _date = value; } }
        public string Text { get { return _text; ; } set { _text = value; } }

        public override string ToString()
        {
            return Id.ToString_Formatted_WithSeparator() + "\t" + Date + "\t" +  Text;
        }

        #endregion

        #region

        //private string _myVersion = string.Empty;

        //public string MyVersion
        //{
        //    get { return _myVersion; }
        //    set { _myVersion = value; }
        //}

        ///// <summary>
        ///// Get a new MyVersion string. (2025.04.12.001)
        ///// </summary>
        ///// <returns>Date+Number</returns>
        //public void SetNewMyVersion()
        //{
        //    MyVersion = DT.DateDot + NewMyVersionNumber();
        //}

        ///// <summary>
        ///// New number for MyVersion
        ///// </summary>
        ///// <returns>number</returns>
        //private byte NewMyVersionNumber()
        //{
        //    return (byte)(1 + LastMyVersionNumber());
        //}

        ///// <summary>
        ///// The last number from MyVersion.
        ///// </summary>
        ///// <returns>number</returns>
        //private byte LastMyVersionNumber()
        //{
        //    try
        //    {
        //        string[] array = MyVersion.Split('.');
        //        return byte.Parse(array[array.Length - 1]);
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}


        #endregion

    }
}
