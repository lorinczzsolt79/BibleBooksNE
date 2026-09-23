using BibleBooksNE.Model.Enums;
using BibleBooksNE.Properties;

namespace BibleBooksNE.ViewAndController.Language
{
    internal class ProgramLanguage
    {

        public enum UserLanguage
        {
            English,
            Hungarian
        }

        public enum HtmlLanguage
        {
            en,
            hu
        }

        private static int LangLength => Enum.GetValues(typeof(PageOrder)).Length;

        public static UserLanguage Parse(int value)
        {
            try
            {
                if (value > 0 && value < LangLength)
                {
                    return (UserLanguage)value;
                }
            }
            catch { }
            return UserLanguage.English;
        }

        public static string[] LangLabel => [
                Resources.English,
                Resources.Hungarian,
            ];

    }
}
