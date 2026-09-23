
namespace BibleBooksNE.Persistency.Html.WebPages
{
    internal class VersesWebPageTemplates
    {
        #region Groups

        /// <summary>
        /// Verse group template
        /// </summary>
        /// <param name="name">group fullId</param> // name: Full_Id 000.1.1.1.-1.12. (bible id = 0);
        /// <param name="title">HtmlVerseIdFormatLong</param>    // title: Formatted Id: HKB.1.1.1. (bible, book, ch., v. ) ;
        /// <param name="id">group fullId</param>   // id: Full_Id 000.1.1.1.-1.12. (bible id = 0);
        /// <param name="entities">html entities</param> // entities: headlines, verses, crossReferences
        /// <returns>Verse group html entity</returns>
        public static string VerseGroupTemplate(string title, string fullId, string entities)
        {
            return string.Format("<section>" +
                "\n\t<a name =\"{1}\"><span class=\"marker\" title=\"{0}\">•</span></a>" +
                "\n\t<div id=\"{1}\" class=\"normal group\" onclick=\"select(this.id)\">" +
                "\n{2}\n</div>" +
                "\n</section>",
                title, fullId, entities);
        }


        /// <summary>
        /// Details Group Template
        /// </summary>
        /// <param name="headerLevel">HTML H tag level between 1 and 6</param>
        /// <param name="id">id part</param>
        /// <param name="headerText">H tag contant, title</param>
        /// <param name="detailsContant">DETAILS tag contant</param>
        /// <returns>Details Group Html entity</returns>
        public static string DetailsGroupTemplate(
            string headerLevel, string id, string headerText, string detailsContant)
        {
            return string.Format(@"
    <details open>
        <summary><h{0} id=""{1}"">{2}</h{0}></summary>
        {3}
    </details>", headerLevel, id, headerText, detailsContant);
        }

        #endregion

        #region Verse type items

        /// <summary>
        /// Headline template
        /// </summary>
        /// <param name="fullId">headline fullId</param>   // Full_Id 1.1.1.1.-1.12. ;
        /// <param name="htmlTypeId">HtmlVerseIdFormatLong</param>   // Id: 1.1.1.1. (bible, book, ch., v. ) ;
        /// <param name="headline">headline text</param> // Text: Headline verse
        /// <returns>Headline html entity</returns>
        public static string HeadlineTemplate(string fullId, string htmlTypeId, string headline)
        {
            return string.Format("<div id=\"{0}\" class=\"headline\"><span class=\"invId\">{1}</span>\n{2}\n</div>",
                fullId, htmlTypeId, headline);
        }

        /// <summary>
        /// Verse template
        /// </summary>
        /// <param name="fullId">verse full id</param>
        /// <param name="shortBibleNameBookChapterIds">Short bible name, book, and chapter, numbers</param> 
        /// <param name="verseId">verse id</param>
        /// <param name="verseText">verse text</param>
        /// <param name="shortId">bible, book, chapter, and verse numbers</param> 
        /// <returns>verse html entity</returns>
        public static string VerseTemplate(string fullId, string shortBibleNameBookChapterIds, string verseId, string verseText, string bibleBookChapterVerseIds)
        {
            string aStart = string.Empty;
            string aEnd = string.Empty;
            if (!string.IsNullOrWhiteSpace(bibleBookChapterVerseIds))
            {
                aStart = "<a href=\"link:" + bibleBookChapterVerseIds + "\">";
                aEnd = "</a>";
            }
            return string.Format("<div id=\"{0}\" class=\"verse\">{4}<sup class=\"bbchId\">{1}</sup><sup class=\"verseId\">{2}</sup>\n{5}{3}\n</div>",
                fullId, shortBibleNameBookChapterIds, verseId, verseText, aStart, aEnd);
        }

        public static string HighlightedSearchedText(string searchedText)
        {
            return string.Format(@"<span class=""highlighted"">{0}</span>", searchedText);
        }

        /// <summary>
        /// CrossReferences template 
        /// </summary>
        /// <param name="fullId">CrossReferences full id</param>
        /// <param name="htmlTypeId">Bible, book, chapter, and verse ids</param>
        /// <param name="anchors">html anchor entities</param>
        /// <returns> crossReferences html entity</returns>
        public static string CrossReferencesTemplate(string fullId, string htmlTypeId, string anchors)
        {
            return string.Format("<div id=\"{0}\" class=\"crossReferences\"><span class=\"invId\">{1}</span>\n{2}\n</div>",
                fullId, htmlTypeId, anchors);
        }

        #endregion

        #region Anchors

        public static string FootnoteLinkAnchorTemplate(string footnoteId, string footnoteNumber)
        {
            return string.Format(@"<a href=""#{0}""><sup>[{1}]</sup></a>", footnoteId, footnoteNumber);
        }
        public static string CrossReferenceAnchorTemplate(string uriType, string ids, string formattedIds)
        {
            return string.Format(@"<a href=""{0}:{1}"">{2}</a>", uriType, ids, formattedIds);
        }

        #endregion

        #region NAV bars

        public static string SimpleTopNavBarTemplate => @"<nav id=""topNav""><span class=""navi""><span id =""lTOP"">TOP</span></span></nav>";
        public static string SimpleBottomNavBarTemplate => @"<nav id =""bottomNav""><span class=""navi""><a href=""#"" target=""_top"" rel=""noreferrer""><span id=""lUp"">Up</span></a></span></nav>";

        #endregion

        #region JS Templates

        /// <summary>
        /// JS Constants Template
        /// </summary>
        /// <param name="values">array of values</param>
        /// <returns>JS Constant value entities string</returns>
        public static string ConstantsTemplate(string[] values)
        {
            return string.Format(@"
    const SORTING = {0};
    const LANGUAGE = {1};
    const VERSEBYVERSE = {2};
    const DARK = {3};
    const WITH_HLS = {4};
    const WITH_VRS = {5};
    const WITH_CRS = {6};
    const WITH_FNS = {7};
    const WITH_WL = {8};
    const WITH_ADS = {9};
    const WITH_STAT = {10};
", values);
        }

        public static string ValuesTemplate(string[] values)
        {
            return string.Format(@"
const VALUES = [
    [""Date"", ""{0}""],
    [""Program_Name"", ""{1}""],
    [""Program_Version"", ""{2}""]
];", values);
        }


        /// <summary>
        /// Verse Group Ids Template
        /// </summary>
        /// <param name="values">comma separated values</param>
        /// <returns>Verse Group Ids Js array</returns>
        public static string VerseGroupIdsTemplate(string values)
        {
            return string.Format(@"const VERSE_GROUP_IDS = [{0}];", values);
        }

        #endregion

        #region Footnote

        /// <summary>
        /// Footnote List Template
        /// </summary>
        /// <param name="footnoteList">list of LI entities</param>
        /// <returns>a full UL Html entity with its LI entities</returns>
        public static string FootnoteListTemplate(string footnoteList)
        {
            return string.Format("<ul>{0}</ul>", footnoteList);
        }

        /// <summary>
        /// Footnote Item Template
        /// </summary>
        /// <param name="footnoteFullId">footnote identifier</param>
        /// <param name="itemGroupId">verse identifier</param>
        /// <param name="verseNumber">number of verse</param>
        /// <param name="footnoteText">text of footnote</param>
        /// <returns>footnote LI Html entity</returns>
        public static string FootnoteItemTemplate(string footnoteFullId, string itemGroupId, string verseNumber,
            string footnoteText, string bibleBookChapterId, string footnoteNumber)
        {
            return string.Format(@"
   <li><div id=""{0}"" class=""footnote"">
      <span class=""footnoteN"" title=""{4}"">{5}.&nbsp;</span>
      <a href=""#{1}""><sup>[{2}]</sup></a>
      <a name=""{0}"">{3}</a>
   </div></li>", footnoteFullId, itemGroupId, verseNumber,
   footnoteText, bibleBookChapterId, footnoteNumber);
        }

        #endregion

        #region Statistic

        public static string StatisticTableTemplate(string searchedText, string tableRows, string lastRow)
        {
            return string.Format(@"
    <table>
        <caption>{0}</caption>
        <tr>
            <th colspan=""5""><span id=""lMatches"">Matches</span></th>
        </tr>
        <tr>
            <th id=""lBible"" scope=""col"" class=""inv"">Bible</th>
            <th scope=""col""><span id=""lHeadline_Matches"">Headline</span></th>
            <th scope=""col""><span id=""lVerse_Matches"">Verse</span></th>
            <th scope=""col""><span id=""lFootnote_Matches"">Footnote</span></th>
            <th scope=""col"" class=""inv"">&sum;</th>
        </tr>
        {1}
        {2}
    </table>", searchedText, tableRows, lastRow);
        }

        /// <summary>
        /// Statistic Table Row Template
        /// </summary>
        /// <param name="bibleName">Short name of the bible</param>
        /// <param name="headline">number of headline matches</param>
        /// <param name="verse">number of verse matches</param>
        /// <param name="footnote">number of footnote matches</param>
        /// <param name="sum">all matches number in bible</param>
        /// <returns>Html table roe entity string </returns>
        public static string StatisticTableRowTemplate(
            string bibleName, string headline, string verse, string footnote, string sum)
        {
            return string.Format(@"
    <tr>
        <th scope=""row"">{0}</th>
        <td>{1}</td>
        <td>{2}</td>
        <td>{3}</td>
        <td class=""myColor"">{4}</td>
    </tr>", bibleName, headline, verse, footnote, sum);
        }

        /// <summary>
        /// Statistic Table LAST Row Template
        /// </summary>
        /// <param name="bibles">sum of bibles</param>
        /// <param name="headline">all headline matches</param>
        /// <param name="headline">all headline matches</param>
        /// <param name="verse">all verse matches</param>
        /// <param name="footnote">all footnote matches</param>
        /// <param name="sum">all matches</param>
        /// <returns></returns>

        public static string StatisticTableLastRowTemplate(
            string bibles, string headlines, string verse, string footnote, string sum)
        {
            return string.Format(@"
    <tr>
        <th scope=""row"" class=""inv"">{0}</th>
        <td class=""myColor"">{1}</td>
        <td class=""myColor"">{2}</td>
        <td class=""myColor"">{3}</td>
        <td class=""inv bolder"">{4}</td>
    </tr>"
                , bibles, headlines, verse, footnote, sum);
        }

        #endregion

        #region Word list

        public static string WordListItemTemplate(string fullId, string wordList)
        {
            return string.Format("<p id=\"{0}\">{1}</p>", fullId, wordList);
        }

        #endregion

    }
}