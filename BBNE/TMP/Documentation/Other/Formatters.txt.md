
# Formatters

## Number to name formatters

- Bible number to name formatter (and back) class
- Book number to name formatter (and back) class
- FullIds Formatter/Converter class (Bible, Book, with others)

## VerseTypeItem to Markdown format

- Headline to Markdown format
- Verse to Markdown format
- Crosslinks to Markdown format
- Footnotes to Markdown format
- Wordlist to Markdown format
- Audio to Markdown format

## VerseTypeItem to Html format

- Headline to Html format
- Verse to Html format
- Crosslinks to Html format
- Footnotes to Html format
- Wordlist to Html format
- Audio to Html format

## FullIds Examples

- Documentation\FullIdsWithText.txt.md
- Describe the output type with NameType enum

| | Bible | Book | Chapter | Verse | Number | Type |
| |:--- | |:--- | |:--- | |:--- | |:--- | |:--- | |:--- |
| 1 | long_name | long_name | number | none | none | none |
| 2 | number_with_separator | number_with_separator | number_with_separator | number_with_separator | number_with_separator | number_with_separator |
| 3 | formatted_number | formatted_number | formatted_number | formatted_number | none | none |
| 4 | formatted_number_with_separator | formatted_number_with_separator | formatted_number_with_separator | formatted_number_with_separator | formatted_number_with_separator | formatted_number_with_separator |
| 5 | short_name | short_name | formatted_number_with_separator | formatted_number_with_separator | none | none |

1. NIV Bible (1984) / Genesis / 1
2. 2.2.2.2.2.2.
3. 3.3.3.3.
4. 004.004.004.004.004.004.
5. NIV.GEN.001.001.
6. 006006006006

## Note (Hungarian)

* Bible Name Formatter class
	+ Biblia nevek lekérdezése a listához
	+ Biblia nevek átalakítása azonosítóhoz
	+ long, short, other name

* Book Name Formatter class
	+ Könyvnevek lekérdezése a listához
	+ Könyvnevek átalakítása azonosítóhoz
		- BookNameFormatter, különböző bibliák, különböző könyvneveinek kezelésére létrehozott osztály
		- BookNames, egy adott biblia különböző könyvneveinek kezelésére létrehozott osztály
		- Name, egy adott biblia különböző neveinek osztálya
		- NameType, külöböző nevek jelölésére létrehozott enum
	+ long, short, dir name

* FullIds Formatter class
