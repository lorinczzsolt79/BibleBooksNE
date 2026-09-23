
# TODO

## Developer's folder

E:\Adatok\Developer

## PLANNED

- User Settings                             // Ready
- Context menu for Text (RichTextBox)       // Ready
- Select More Bibles                        // Ready
- Modify BibleParts and BookInfo class, Add BookParts, ChapterParts classes
- Modify UserActions class, replace int Bibles variable to int[], methods, ...
    + Selected Bible, SelectedIndex, return value int                               // Ready
    + Selected Bibles, SelectedIndices, return value int[]                          // Ready

- FullIds formatter class                   // TODO?
- BibleNames Handler                        // TODO?

## WHAT SHOULD I DO?

- Selection with key codes                                              // Test then Ready
- Language support (EN and HU messages)                                 // Test then Ready
    + for program messages

- NameFormatter (FullIdentifier Formatter) from String to FullId        // ready?


#### Maybe one day
- Settings                                                              // maybe
    + Settings in html format
    + Show in web browser

- Database Info                                                         // maybe
    + Database Info in html format
    + Show in web browser

- Messenger; MessageText; Localization;                                 // ?

- book_part (parts of Psalm) handler                                    // maybe
- Messenger, MessageText                                                // maybe
- Web Page Structure                                                    // maybe
    + Selected Bible page contains Book Names, onClick Book Name -> navigate to page, page: Chapters of Selected Book
    + Selected Book page contains Chapters, onClick Chapter -> navigate to page, page: Verses of Selected Chapter
    + Selected Chapter page contains Verses, onClick Verse -> set Selected verse
    
## ERROR

- Wrong Results ( Solution: Search in clean text. Remove unnecessary signs and marks. )

### Fixed

- Exception in searching when bible id is 0
- missing separator; Name Formatter ; Short-, Long-, and DirName + Separator
- Sorting

------------------------------------------------------------------------------------
------------------------------------------------------------------------------------

##### Program package and deploy

##### Help files

    - Help file main page.
    - more language

- Help files; Localization; EN, HU;                                     // TODO
    + Help in html format
    + Show in web browser

##### Database Tasks

    - Html tags (and signs), cleaning
    - Remove Html tags before search. How to? SQL???

- Database modification, modify signs and marks in the databases:  

- NIV.40.26 footnote html tag Error; Double quotes!!!

footnote anchor: {a: Gen. 1.1}

        #region Anchors

        /* Anchors
         * {a: Gen. 1.1}
         * {a: Gen. 1.1,3}
         * {a: Gen. 1.1-4}
         * <a href="http://"></a>
         * 
         * NEW
         * in NIV for example
         * number of NIV bible: 3
         * id: Bible, Book, Chapter, Verse
         * <a href="goto:3.1.1.1.">Gen. 1.1</a>
         * <a href="goto:3.1.1.1.">Gen. 1.1,3</a>
         * <a href="goto:3.1.1.1.">Gen. 1.1-4</a>
         * 
         */

        #endregion

## Next to do

- Clear text before searching; Remove sings and marks                   // TODO   HOW?
    + collect marks and signs to remove

    remove the html tags: <span style="color: red;">"Blessed are the poor in spirit, for theirs is the kingdom of heaven.</span>  
    remove all html entity: <abbr title="But this kind does not go out except by prayer and fasting.">F1.</abbr>



## READY

* 2026-08-27

    - Add Help menu events
    - Add F1 button press part
    - Create En and Hu Help files, with style

* 2026-08-06

    - Add Details tag to Information part on Web page
    - Add highlighted search result changes
    - Fix error! Modify recursive method in HtmlVersesPartMaker.

* 2026-08-04

    - Add message queue.
    - Add UriType to post_message function messages. For example: "error:Is wos not found!"
    - When the selected item on the verse list is 0, be nothing the selected item group on the web page.

    - to change the HUK English description
    - to change the SZPA English description
    - to change the SZPA name to SPA Saint Paul Academy

* 2026-08-03

    - Set selected Item group from list on web page.
    - Set selected verse index in list from web page.
    - Navigate from result id to verse page on search result page.
    - Fix Footnote navigations. (verse to footnote, and back)

* 2026-08-02

    - New! Set selected verse group id on WebPage (without Navigation) - Form_Main_Selector
    - Navigation from Web Browser (crosslink)

* 2026-07-31

    - new TogetherFullIdentifierWithTextComparer class
    - Fix sorting bugs
    - Add Wordlist group methods, modify classes for WordList items
    - Add Title part, WordList part to Html template
    - Rename GROUP_IDS to VERSE_GROUP_IDS
    - Sorting GROUP_IDS
    - Replace OL tag to UL, and add footnote number part to footnote items in Html file template
    - Delete footnote items from HKB and BBE databases
    
* 2026-07-30

    - new StandardFullIdentifierWithTextComparer class
    - Rename DetailsMaker class to GroupEntityMaker
    - new Make and RecursiveTask methods in HtmlVersesPartMaker, and other methods: ItemMaker, GetName, etc.
    - new NameTypePattern properties
    - new NameFormatter methods

* 2026-07-28

    - new DetailsMaker class
    - Rename Order to PageOrder
    - Simplify PageOrder enum
    - Modify SQL classes, replace PageOrder to TableName
    - Add  new methods to HtmlPageMaker class

* 2026-07-24

    - New Messages Html File Template, Script, and Style
    - Add new ProgramLanguage class
    - Add User's Language setter to view
    - Add UserLang setting setter methods
    - Modify VerseHtmlFileMaker class

* 2026-07-23

    - Modify Verses html file template
        * Add new constant properties
        * New setter functions
        * Create new template file
    - Add SplitterContainer to BibleReader Tab

* 2026-07-22

    - Save last html file
    - temporary html file directory and temp html files
    - add new checkboxes to view (JustifyIfPossible, DarkTheme, CleanTempDirBeforeQuit)
    - OrderType class for Order groups

* 2026-07-21

    - Modify GroupIds class, Get VerseGroup ids by SortingType
    - Get JS Constants by Statistic values
    - Modify group ids maker
    - Add Sorting type checkbox to UI

* 2026-07-20

    - Add Sorting Type User settings
    - New StandardComparer class for FullIdentifier class
    - Modify CompareTo method in FullIdentifier class

* 2026-07-19

    - New VerseTypeListDictionary class
    - New VerseTypeListDictionaries class
    - Remove SearchStatistic, VerseTypeLists, and VerseTypeListTasks classis
    - Replace old classes to new ones
    - Add Statistic html part

* 2026-07-16

    - Add new verses html file template (16) to project
    - Add new template parts to VersesTemplates (Statistic, Footnote, Constants templates)
    - Refactor and finish VersesHtmlFileMaker file
    - Extend UserAction.ForJsConstants() method (add WithVerses)
    - Add new GetVerseTypeWebPage() method to Form_Main_Selector class
    - Add other necessary methods (GetProgramValues,)
    - Remove SimpleSearchHtmlFile method
    - Remove SimpleVersesHtmlFile method
    - New GetVerseTypeWebPage() method
    - New VerseHtmlPage() method
    - New SearchHtmlPage() method
    - New Build() and other methods in VersesHtmlFileMaker class

* 2026-07-15
    
    - GroupIds and GroupIdCollection classes (bible, book, chapter, and verse group id maker classes)

* 2026-07-09

    - New Statistic part in verses html file

* 2026-07-7-8

    - Fix web page refreshing. (when selected bibles changed, when Crosslinks CheckState Changed)

* 2026-07-06

    - Add initDDictionary method to SearchHandler class
    - Fix FootnoteGroupIds
    - Add new method to SearchHandler, Statistic()

* 2026-07-05

    - Replace external SQLite extension to MS Sqlite extension

* 2026-07-03

    - Add Footnote groups methods (in VerseTypeListsTasks, FullIdentifierWithText, FullIdentifier classes)

* 2026-02-26

    - Add User's Home Directory Settings things

* 2026-02-13

    - Modify abbreviation to html format in Verses table 

* 2026-02-12

    - Modify Order class, add some new item 

* 2026-02-10

    - Modify crosslinks in Footnotes table

* 2026-02-09

    - Add LABELS array, Set Labels and Values

* 2026-02-08

* 2026-02-07

* 2026-02-05

    - Add Color Theme Setter to HTML Template

* 2026-02-01
* 2026-01-31

    - Make HTML Template for web pages
    - Single and Multi bible mode
    - id and verse html entities
    - Marked and normal verses
    - Information part
    - Settings: Reader style, Crosslinks visibility

* 2026-01-27

    - Remove Settings from Resources
    - Rename NameSpace, directory, project name to BibleBooksNE
    - Modify GetDatabaseFullNames method in DatabaseStart class

* 2026-01-26

    - Add Values method to DatabaseHandler, DatabaseInfo, BibleInfo, Names, ProgramDirectories classes
    - Make ValuesToString class
    - Rename ProgramSettings class to ProgramDirectories
    - Rebuild ProgramDirectories class

* 2026-01-25
    
    - Add some values to Resources, Localization with Resources items
    - Add KeyPress methods

* 2026-01-24

    - Add File Open methods
    - Add File Save methods

* 2026-01-17

    - Modify AboutBox, new Constructor for other description
    - Set, Reset, Save, User Settings methods

* 2026-01-06

    - Fix Settings Bugs. Set Selected Items Correctly

* 2026-01-05

    - Add feature: Save and Reset User Settings methods
    - Get and Parse IdsWithOrders for settings

* 2026-01-04

    - Add Context menu for RichTextBox_Text 

* 2026-01-03

    - Add Group Ids to VerseTypeList result

* 2025-12-30

    - Fix component sizes

* 2025-12-29

    - Make SZPA database, Insert some values Into some tables

* 2025-12-28

    - New method, ToString, in NameFormatter class

* 2025-12-28

    - Fix NULL reference error in VerseTypeListHandler class

* 2025-12-27

    - Insert values Into new English bible databases, Verses and BookNames
 
* 2025-12-26

    - Create new English bible databases with empty tables
    - Insert some default English values Into new English bible databases,  BibleInfo, Headlines, BibleParts, BookParts

* 2025-12-24

    - Modify NameFormatter class, replace List ot Dictionary and modify methods
    - Modify VerseTypeListHandler class, replace List ot Dictionary and modify methods

* 2025-12-23

    - Modify BibleInfo class, Add new fields (type, copyright)
    - Modify BibleInfo table in Databases, Add new fields (type, copyright)
        + type: free, protected
        + copyright: public (free), public domain (free), copyright owner (for example: NIV:Zondervan)

    - Add databaseId property to NameHandler

* 2025-12-15

    - Add FullIdentifierFormat method to NameFormatter class

* 2025-12-08

    - new SearchResultPage method in HtmlPages
    - new Form_Main_Selector.Search method
    - new SearchHandler class, Search and other methods
    - new DatabaseInfo.Search method
    - new SQLite_DatabaseDataHandler.Search method
    - new SQL_QueryCommands.Search method

* 2025-12-05

    - FullIdentifier sorting ready
    - New CompareTo method in FullIdentifier class
    - New BeforeComparer class
    - New AfterComparer class
    - New Before method in FootnoteChecker class
    - Modify verse number in Wordlist table to 255 in NIV Bible database

* 2025-12-02

    - Search Msg Getters and Setters
    - Refresh Web Page when BibleIndices changed

* 2025-11-26

    - New Refresh method for VerseTypeListHandler class
    - Compare method for IdsWithOrders class Same()

* 2025-11-23

    - Add new class VerseTypeListsFormatter
    - Add Refresh(IdentifiersWithOrders[] idsWithOrdersArray) method to VerseTypeListHandler
    - Add GetIdsWithOrders(int[] bibles) method to UserActions class
    - Add GetSelectedItems() method to Form_Main_Selector class
    - Add Parse(int[]) method to NumberedListBoxItem class
    - Add _verseTypeListsArray and FillWithNull method to VerseTypeListHandler

* 2025-11-19

    - Add To DataSelector method to NameFormatter
    - New class NameTypeArrays

* 2025-11-16

    - Modify Identifier.ToString method
    - Correct Namespaces
    - Modify Name class, Replace int number property to Identifier
    - Add GetAllBookNames() method to DatabaseInfo class
    - Add GetBibleNames() method to NameFormatter class
    - Add GetBookNames() method to NameFormatter class

* 2025-11-15

    - Modify BibleInfo tables
    - Modify some bible names
    - Modify BibleInfo class, Add Name property

* 2025-11-08

    - add footnote abbreviations to NIV database where verse was empty

* 2025-11-05

    - new class NumberedListBoxItem
    - new method GetNumberedBibleNames() in Databases class
    - new method GetNumberedBookNames() in BookNameHandler class

* 2025-11-03

    - Remove html character codes form Verses.text (BBE, HUK, NIV Databases)
    - Remove html character codes form Footnotes.text (NIV Database)

* 2025-10-29

    - Add other_name to NameType
    - Add GetName method to BibleInfo
    - Rename BookName class to Name
    - Rename properties in Name Class

* 2025-10-28

    - Add Parser methods for FullIds class
    - Modify BookName class, Add BookNumber variable and Name() method
    - Add new methods (BookNumberOf, BookName, GetBookNames) to BooNameHandler class

* 2025-10-27

    - Add Parser method for Identifier class 
    - Refactoring Identifier class
    - Convert some Text file to Markdown file

* 2025-10-25

    - correct Order enum
    - Add Label_PreviousSearchedText
    - Remove Bible Tab
    - Modify Settings Tab, Add Program, Reader Setting Group
    - Add Read BookParts and ChapterParts methods
	
* 2025-10-24

    - BBE & NIV database structure: Equals!
    - HUK & NIV database structure: Equals!
    - Trim text field in NIV database
    - Database modification:
        + Modify BibleParts table
        + Add BookParts table
        + Move some data from Headlines to BookParts
        + Add ChapterParts table

* 2025-10-23

    - ShowBiblePage controller method
    - new class IdsWithOrders between UserActions and VerseTypeListHandler
    - modify Form_Main_Selector.ShowBiblePage()
    - add method UserActions.IDsChanged()
    - add method UserActions.IDsChanged_WithVerseId()
    - add method UserActions.WithOrders()
    - add method UserActions.GetIdsWithOrders()
    - add method FullIdsFormatter.ToFullIds(htmlFormatIds)
    - new class VerseTypeLists
    - new class VerseTypeListHandler

* 2025.10.22.

    - Active Verse setting on webpage methods (send and receive)
    - Add JsMethods

* 2025.10.16.

    - Add ForSQLQuery method
    - Fix some bug in UserActions class 
    - Modify Order enum class

* 2025.10.15.

    - Add Localization Class
    - Add SelectSomethingPage method to HtmlPages
    - Simplify EmptyHtmlPage class 

* 2025.10.10.

    - Fix Form_Main_Selector bugs
    - Rename from UserSelection class to UserActions
    - Rename from User_Selection class to UserAction
    - Add AddOn methods UserActions class

    - Set Tab indexes on Selector TabPage
    - Remove Welcome Resources.
    - Add NoDatabase page to HtmlPages class
    - Add FullIds methods to UserActions class

* 2025.10.09.

    - UserSelection, Form_Main_Selector

* 2025.10.08.

    - EmptyHtmlPage class
    - GetOrders method
    - MessageText method

* 2025.10.05.
        SetView (First Time) methods
        Sort FullIdsWithText

* 2025.10.04.

    - Queries access across BibleInfo
        + GetBookNumbers
        + GetChapterNumbers
        + GetVerseNumbers
        + GetVerseTypeItems

* 2025.09.27.

    - Add new methods to

        + SQLQueryCommands class
            * Selections with condition methods
            * Search  methods
            * renew Count commands
        
        + SQLNonQueryCommands
                INSERT methods
                UPDATE methods
                DELETE methods

* 2025.09.26.

    - Database synchronization

        + BBE struct = NIV struct
        + HUK not ready

* 2025.09.24.

    - Replace WebBrowser to WebView2
    - Change Checkboxes to ListBoxes
    - Renew Form_Main_Selector class
    - Rename BookInfo class to BookNames class
    - Rename BookInfo table name to BookNames in dbs
    - Add some methods databases class ( GetDatabaseByNumber)
    - Add ChapterNumbers and VerseNumbers methods for SQL query

* 2025.09.23.

    - Add some methods to Identifier class: (Separator, PadLeft)
    - Remove from dbs BookInfo.BiblePart, BookInfo Language fields.
    - Remove BiblePart and Language enum.
    - Remove from class BookInfo.BiblePart, BookInfo.Language fields and methods.
    - Create in databases BibleParts table and add values.
    - Create BibleParts class. and  Add BibleParts methods to classes.


* 2025.09.19.

    - Rename Footnotes.id to Footnotes.number in databases.
    - Remove Verses, Headlines, Footnotes, WordList, Crosslinks classes
    - New VerseTypeResults class (Read from database, convert to FullIdsWithText array)
    - New AllVerseTypeItems method in SQLiteDatabaseDataHandler class

* 2025.09.18.

    - Rename BibleRows to Verses

* 2025.09.17.

    - new FullIds class
    - new FullIdsWithText class

    - new BibleRow class, extends FullIdsWithText class
    - new Crosslinks class, extends FullIdsWithText class
    - new Footnote class, extends FullIdsWithText class
    - new Headline class, extends FullIdsWithText class
    - new WordList class, extends FullIdsWithText class
