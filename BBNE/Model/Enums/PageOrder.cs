
namespace BibleBooksNE.Model.Enums
{
    public enum PageOrder
    {
        unknown,            // 0. 	// --

        document,           // 1.   // H1
        page,               // 2.   // H2
        bible,              // 3.   // H3
        book,               // 4.   // H4
        chapter,            // 5.   // H5

        top_navbar,         // 6. 	// --

        item_group,         // 7. 	// --
        headline_title,     // 8. 	// H6
        chapter_title,      // 9. 	// --
        verse_item,         // 10.	// --
        crosslink_item,     // 11.	// --

        bottom_navbar,      // 12.	// --

        break_point,        // 13.	// --

        statistic,          // 14.	// --
        footnote_group,     // 15.	// --
        footnote,           // 16.	// --
        wordlist_group,     // 17.	// --
        wordlist,           // 18.	// --
        audio,              // 19.	// --

        none                // 20.  // --
    }
}