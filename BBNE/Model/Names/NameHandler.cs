using BibleBooksNE.Model.Enums;

namespace BibleBooksNE.Model.Names

{
    internal class NameHandler
    {

        private readonly List<Name> _names;

        public NameHandler()
        {
            _names = new List<Name>();
        }

        public NameHandler(Name[] names)
        {
            _names = new List<Name>(names);
        }

        /// <summary>
        /// Get number (id) by name
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="nameType">name type</param>
        /// <returns>number of name</returns>
        public int NumberOf(string name, NameType nameType)
        {
            if (_names.Count > 0)
            {
                foreach (Name item in _names)
                {
                    if (item.GetName(nameType).ToLower().Equals(name.ToLower())) { return item.Id.N; }
                }
            }
            return -1;
        }

        /// <summary>
        /// Get name by number (id)
        /// </summary>
        /// <param name="number">number of name</param>
        /// <param name="nameType">name type</param>
        /// <returns>name</returns>
        public string Name(int number, NameType nameType)
        {
            if (_names.Count > 1 && number > 0)
            {
                for (int i = 1; i < _names.Count; i++)
                {
                    if (_names[i].Id.N == number)
                    {
                        return _names[i].GetName(nameType);
                    }
                }
            }
            return string.Empty;
        }

        /// <summary>
        ///  Make n. label format list
        /// </summary>
        /// <param name="numbers">numbers</param>
        /// <param name="nameType">Label format</param>
        /// <returns>n. label format list</returns>
        public string[] GetNumberedNames(int[] numbers, NameType nameType)
        {
            List<string> list = new List<string>();
            if (numbers.Contains(0) || !numbers.Contains(0))
            {
                list.Add(new NumberedListBoxItem(0).ToString());
            }
            foreach (int bookNumber in numbers)
            {
                if (bookNumber > 0)
                {
                    list.Add(new NumberedListBoxItem(bookNumber, Name(bookNumber, nameType)).ToString());
                }
            }
            return list.ToArray();
        }
    }
}