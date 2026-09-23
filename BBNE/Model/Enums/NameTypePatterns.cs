namespace BibleBooksNE.Model.Enums
{
    internal class NameTypePattern
    {
        #region Formatted numbers 

        /// <summary>
        /// 006006006006 format
        /// </summary>
        public static NameType[] FourFormattedNumbers => [
            NameType.formatted_number,
            NameType.formatted_number,
            NameType.formatted_number,
            NameType.formatted_number,
            NameType.none,
            NameType.none ];

        /// <summary>
        /// 004004004004004004 format
        /// </summary>
        public static NameType[] SixFormattedNumbers => [
            NameType.formatted_number,
            NameType.formatted_number,
            NameType.formatted_number,
            NameType.formatted_number,
            NameType.formatted_number,
            NameType.formatted_number ];

        #endregion

        #region Formatted numbers with separators 

        /// <summary>
        /// 004.004.004.004.004.004. format
        /// </summary>
        public static NameType[] FormattedNumbersWithSeparator => [
            NameType.formatted_number_with_separator,
            NameType.formatted_number_with_separator,
            NameType.formatted_number_with_separator,
            NameType.formatted_number_with_separator,
            NameType.formatted_number_with_separator,
            NameType.formatted_number_with_separator ];

        #endregion

        /// <summary>
        /// For page title format ( NIV Bible (1984) )
        /// </summary>
        public static NameType[] LongBibleNameOnly => [
            NameType.long_name_with_separator,
            NameType.none,
            NameType.none,
            NameType.none,
            NameType.none,
            NameType.none ];

        /// <summary>
        /// For page title format ( NIV Bible (1984) / Genesis )
        /// </summary>
        public static NameType[] LongBibleNameLongBookName => [
            NameType.long_name_with_separator,
            NameType.long_name_with_separator,
            NameType.none,
            NameType.none,
            NameType.none,
            NameType.none ];

        /// <summary>
        /// For page title format ( NIV Bible (1984) / Genesis / 1 )
        /// </summary>
        public static NameType[] LongBibleNameLongBookNameChapterNumber => [
            NameType.long_name_with_separator,
            NameType.long_name_with_separator,
            NameType.number,
            NameType.none,
            NameType.none,
            NameType.none ];

        #region Short names

        /// <summary>
        /// For Html Verses format ( NIV.GEN.1. )
        /// </summary>
        public static NameType[] ShortBibleNameShortBookNameChapterNumber => [
            NameType.short_name_with_separator,
            NameType.short_name_with_separator,
            NameType.number_with_separator,
            NameType.none,
            NameType.none,
            NameType.none ];

        /// <summary>
        /// For Html Verses format ( NIV.GEN.1.1. )
        /// </summary>
        public static NameType[] ShortBibleNameShortBookNameChapterNumberVerseNumber => [
            NameType.short_name_with_separator,
            NameType.short_name_with_separator,
            NameType.number_with_separator,
            NameType.number_with_separator,
            NameType.none,
            NameType.none ];

        #endregion

        #region Bible name with numbers

        /// <summary>
        /// For page title format ( NIV )
        /// </summary>
        public static NameType[] ShortBibleNameOnly => [
            NameType.short_name,
            NameType.none,
            NameType.none,
            NameType.none,
            NameType.none,
            NameType.none ];

        /// <summary>
        /// For Html Verses format ( NIV.3. )
        /// </summary>
        public static NameType[] ShortBibleNameBookNumber => [
            NameType.short_name_with_separator,
            NameType.number_with_separator,
            NameType.none,
            NameType.none,
            NameType.none,
            NameType.none ];

        /// <summary>
        /// For Html Verses format ( NIV.3.4. )
        /// </summary>
        public static NameType[] ShortBibleNameBookNumberChapterNumber => [
            NameType.short_name_with_separator,
            NameType.number_with_separator,
            NameType.number_with_separator,
            NameType.none,
            NameType.none,
            NameType.none ];

        /// <summary>
        /// For page title format ( NIV.3.4.5 )
        /// </summary>
        public static NameType[] ShortBibleNameBookNumberChapterNumberVerseNumber => [
            NameType.short_name_with_separator,
            NameType.number_with_separator,
            NameType.number_with_separator,
            NameType.number_with_separator,
            NameType.none,
            NameType.none ];

        /// <summary>
        /// For page title format ( Gen.6.7 )
        /// </summary>
        public static NameType[] ShortBookNameChapterVerseNumbers => [
            NameType.none,
            NameType.short_name_with_separator,
            NameType.number_with_separator,
            NameType.number_with_separator,
            NameType.none,
            NameType.none ];

        #endregion

        #region Numbers with separator

        public static NameType[] FourNumberWithSeparator => [
            NameType.number_with_separator,
            NameType.number_with_separator,
            NameType.number_with_separator,
            NameType.number_with_separator,
            NameType.none,
            NameType.none ];

        public static NameType[] FiveNumberWithSeparator => [
            NameType.number_with_separator,
            NameType.number_with_separator,
            NameType.number_with_separator,
            NameType.number_with_separator,
            NameType.number_with_separator,
            NameType.none ];

        #endregion
    }
}
