namespace BibleBooksNE.Model.Other
{
    internal class DT
    {
        /// <summary>
        /// output: 2025. 04. 12. 10:47:13
        /// </summary>
        public static string Now => DateTime.Now.ToString();
       
        /// <summary>
        /// output: 2025.04.12
        /// </summary>
        public static string DateEN => DateTime.Now.ToString("yyyy-MM-dd");
       
        /// <summary>
        /// output: 2025.04.12
        /// </summary>
        public static string DateHU => DateTime.Now.ToString("yyyy.MM.dd");
        
        /// <summary>
        /// output: 2025.04.12.
        /// </summary>
        public static string DateHU_withDot => DateTime.Now.ToString("yyyy.MM.dd.");

        /// <summary>
        /// output: _20250412104713
        /// </summary>
        public static string Now_FileTailFormat => string.Format("_{0}", DateTime.Now.ToString("yyyyMMddHHmmss"));

        /// <summary>
        /// output: 12:34:56
        /// </summary>
        public static string TimeHU => DateTime.Now.ToString("HH:mm:ss");

        /// <summary>
        /// output: 2025.04.12 - 10:47:13
        /// </summary>
        public static string NowHU => string.Format("{0} - {1}", DateHU, TimeHU);

    }
}
