
namespace BibleBooksNE.Model.Enums
{
    internal class EnumTask
    {
        public static T ToEnum<T>(string inputString, bool ignoreCase, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return defaultValue;
            }
            if (Enum.TryParse(inputString, ignoreCase, out T result))
            {
                return result;
            }
            return defaultValue;
        }

        public static string[] EnumValues<T>()
        {
            List<string> list = [];
            foreach (string item in Enum.GetValues(typeof(T)))
            {
                var value = item;
                if (value != null)
                {
                    list.Add(value.ToString());
                }
            }
            return [.. list];
        }

    }
}
