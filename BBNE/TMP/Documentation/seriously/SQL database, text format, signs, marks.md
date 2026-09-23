# SQL database Text format

## BibleInfo table

### BibleInfo table fields description

- **id**: unique bible identifier, different bibles with different id
- **shortName**: unique bible short name, usually with Capital letters, use Word characters and Digits, without whitespace character or period!
- **longName**: unique bible long name, with Small and Capital letters, use Word characters and Digits, minus sign, underline character, without whitespace ( except space ) character or period!
- **dirName**: directory name for output files, usually same as the short name, but can be different, with Small letters, use Word characters and Digits, minus sign, underline character without whitespace ( except space ) character or period!
- **language**: language of the bible
- **description**: bible description
- **url**: source or other url
- **version**: bible version
- **type**: Is the usage free or protected?
- **copyright**: copyright owner

## BibleParts table

### BibleParts table fields description

From book to number (other book number). For example: first five books.

- **book**: FROM book
- **chapter**: 0, not used
- **verse**: 0, not used
- **number**: TO book
- **text**: description of the book group, (rules: same as BibleInfo.longName )

## BookNames table

The names of the books.

### Order

- Old Testament Books (1-39)
- New Testament Books (40-66)
- Other Books (67-81 and more)

### BookNames table fields description

- **id**: unique bookName identifier (See: Order section above)
- **shortName**: unique book short name, usually with Capital letters, use Word characters and Digits, minus sign, underline character, without whitespace ( except space ) character or period!
- **longName**: unique book long name, with Small and Capital letters, use Word characters and Digits, minus sign, underline character, without whitespace ( except space ) character or period!
- **dirName**: usually same as the short name, but can be different, with Small letters, use Word characters and Digits, minus sign, underline character without whitespace ( except space ) character or period!

## BookParts table

In book, from chapter to number (other chapter number). For example: a part of the Psalms.

### BookParts table fields description

- **book**: IN book
- **chapter**: FROM chapter
- **verse**: 0, not used
- **number**: TO chapter
- **text**: description of the chapter group, (rules: same as BibleInfo.longName )

## ChangeLog table

Database modifications.

- **id**: unique change log identifier
- **date**: date of modification
- **entry**: short description of the modification. For example: CREATE database (database was created on that date).

## ChapterParts table

A part of the chapter. For example: the Lord's prayer.

### ChapterParts table fields description

- **book**: IN book
- **chapter**: IN chapter
- **verse**: FROM verse
- **number**: TO verse
- **text**: description of the verse group, (rules: same as BibleInfo.longName )

## Crosslinks table

Crosslinks items always appear after and under a verse.

### Crosslinks table fields description

- **book**: IN book
- **chapter**: IN chapter
- **verse**: after and under verse
- **text**: fullIdentifier item lists separated with semicolon. For example: 001.001.001;002.002.002;003.003.003

## Footnotes

A verse can contain one or more footnotes.  
Footnote items always appear after and under all verses.

### Footnotes table fields description

- **book**: IN book
- **chapter**: IN chapter
- **verse**: IN verse
- **number**: footnote identifier
- **text**: Footnote text, with any character.

## Headlines

Headlines items always appear before and above a verse.

### Headlines table fields description

- **book**: IN book
- **chapter**: IN chapter
- **verse**: before and above a verse
- **text**: It is a small title of a part, with any character. For example: "The Lord's prayer".

## Verses table seriously

The verse rows of the bible.

### Verses table fields description

- **book**: IN book
- **chapter**: IN chapter
- **verse**: verse identifier
- **text**: Verse text, with any character. It can contains special sings and marks.

## WordList

A word list from the verses of a chapter.

### WordList table fields description

- **book**: IN book
- **chapter**: IN chapter
- **verse**: IN verse
- **text**: A word (or expression) list, with any character, separated with semicolon. 

## Special sings and marks in verse items

### Quotation

- ‚text’
- „text”

### Quotation

{’}\n{‚}  line break in quotations

{”}\n{„}  line break in quotations
 
### Footnote item in verse

[n] footnote

### Html element item in verse or footnote:

<> html element

For example: \<b>, \<i>, \<br>, \</b>, \</i>

### Color entry

{cn}  color entity
- c = color
- n = number (0 or positive integer)

For example: \{c1}red text{/c1}

### Abbreviation

\{ab} abbreviations, {ab}"title"="text"{/ab}
