
# WEB PAGE STRUCTURE

- Output File Type: HTML, with CSS and JS

## EXPECTATIONS

- Title and Items parts
- Information Part
- Navigation from page and on page
- Light and Dark color theme

## PAGE TYPES

- Program Messages: WelcomeHtmlPage, SelectSomethingHtmlPage
- Information pages: ProgramSettingsPage , UserSettingsPage , DatabaseInfoPage
- Error Pages: NotFoundHtmlPage, 
- Bible pages: Bibles, Books, Chapters, Verses
- Search Result Pages: SearchResult Page
- ProgramTest Pages: SimpleTextHtmlPage, UserActionHtmlPage

### Bibles

- verses from only one bible, Reading Style: List or In Line
- verses from more bibles; Reading Style: always List; Id groups

## WEB PAGES

### Bibles page

- Bibles page contains Bible Name links
- onClick Bible Name link -> navigate to page; page content: Chapters of Selected Book

+ Title; (Available Bibles)
+ Long Bible Names; 
+ Footer: Information about the page

### Selected Bible Page

- Selected Bible page contains Book Name links
- onClick Book Name link -> navigate to page; page content: Chapters of Selected Book

+ Title; (Bible)
+ Book long names; 
+ Footer: Information about the page

### Selected Book Page
- Selected Book page contains Chapter links
- onClick Chapter -> navigate to page; page content: Verses of Selected Chapter

+ Title; (Bible, Book)
+ Navigation part; Previous book, Book Number, Next book
+ Chapter numbers
+ Navigation part; Previous book, Book Number, Next book
+ Footer: Information about the page

### Selected Chapter Page
- Selected Chapter page contains Verses, onClick Verse -> set Selected verse on page

+ Title; (Bible, Book, Chapter number)
+ Navigation part; Previous chapter, Chapter Number, Next chapter
+ Setting, Closable, Reading Style: List or In Line Ids, If the page contains verses from one bible.)
+ Verses: one row: Id & Verse; (with or without Headlines, Crosslinks, Footnote links)
+ With Or Without Footnotes
+ Navigation part; Previous chapter, Chapter Number, Next chapter
+ Footer: Information about the page

## NAVIGATION

### From Program
### Form Web Page
### On Web Page

