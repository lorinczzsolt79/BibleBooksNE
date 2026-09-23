
## Visoual Studio Workspace Path

E:\Adatok\Developer\BibleBooksNE\Resources

## Verses Html File Template For Program in project

\Resources\WebPageTemplates\Verses_Html_Template_v.4_BBNE.html

E:\Adatok\Szoftver Fejlesztő Suli\Visual Studio\source\repos\BBNE2\BBNE2\Resources\WebPageTemplates\Verses_Html_Template_v.4_BBNE.html

### Empty parts in html file template

* {0} script part (arrays)
* {1} verses part
* {2} footnotes part

Ha nincs headlines, crosslinks, vagy footnotes rész,
akkor elrejti ezeket a részeket. ( hidden )
( WITH_HLS = , WITH_CLS = , WITH_FNS = true/false )

## Get data

	* UserActions.ForJsConstants 
	* Program Data
	* Verses part

## web oldal elkészítése

	- kell egy osztály, ami összeállítja a megadott adataokból
	- kell egy osztály, ami VerseTypeLists tőmből készít html bejegyzéseket

	- hogyan, miből készöljön el a Title rész? (Több nyelvből is kellene, több biblia nyelve alapján. ??? )

---

Probléma a Titles résznél.

	- Le kellene kérdezni a bibliák nyelveit, és ezek szerint elkészíteni a többszörös title részt.
		- Beleteni egy tömbe, hogy változzon a nyelv választásakor.
		- Vagy mindet kiiratni, mint a verseket.



VerseWebPagePreprocessor

	HtmlDataPartMaker
		HtmlVersePartMaker()
			VersesPart
				Headlines
				VersesWithFootnotlinks
					- remove footnotes
					- simple (formatted text)
					- links (simple with link)
				Crosslinks
					CrosslinksMaker
					- simple (formatted text)
					- links (simple with link)
		HtmlFootnotePartMaker()
			- titles (Bible name)
			- Footnote groups ( get bible ids and make groups and titles )
		string[] Verses
		string[] Footnotes
		string[] GroupIds


TopNavbar
Titles
BottomNavbar


VerseWebPageBuilder
	HtmlScriptPartMaker

---

