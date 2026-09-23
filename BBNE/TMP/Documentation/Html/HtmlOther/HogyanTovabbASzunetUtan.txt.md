
"E:\Adatok\Developer\BibleBooksNE\Resources\BibleBooksNE HTML.code-workspace"

## Html entity-ket kell készíteni.

## Sima lap hivatkozások nélkül?

### Hogyan tovább?

- Hivatkozások
	+ Hogyan kellene navigálni?

### Web oldalak elkészítése

- verses oldlal elkészítése  
- keresés oldal elkészítése  
- egyéb oldalak  

#### Verses oldal elkészítése

Az alapoldal mindig angol nyelvű. Betöltéskor és utána is nyelv kiválasztható.

##### Feladatok:

+ script rész hozzáadása
+ Verses rész hozzáadása
+ Footnotes rész hozzáadása

###### Script part

* IS_MULTI	lekérdezés, beállítás  
* WITH_CLS	lekérdezés, beállítás  
* WITH_HLS	lekérdezés, beállítás  
  
* LANGUAGES JS tömb elkészítése  
* LABELS JS tömb elkészítése  
* VALUES JS tömb elkészítése  

###### Verses part

* ( Top nav bar )
* Title
* Verses
	+ Verses group template
		- headline template 
		- Verse template and footnote link  
		- crosslink template without navigation  
* ( Bottom nav bar )

###### Footnotes part			

* Footnote template with backward navigation
				
##### Other

###### Navigation

- toFootnote navigation
- fromFootnote navigation
- Nav bar navigation (Top and Bottom, Previous and Next)
- Crosslink navigation

A kiválasztott könyvek soha nem változnak a navigációkor, csak a könyv, fejezet változhat.

- Az első könyv,
		vagy az első könyv, első fejezete,
	vagy az első könyv, első fejezet, első verse
	nem mutat vissza. Nincs PREV.

- Az utolsó könyv,
	vagy az utolsó könyv, utolsó fejezete,
	vagy az utolsó könyv, utolsó fejezet, utolsó verse
	nem mutat tovább. Nincs NEXT.

###### Selected Verse

+ A kijelölt vers változhat oldalon belül,
	( és változhat első vagy utolsó versere,
	  a könyv vagy fejezet változásával. )

#### KERESÉS eredménye oldal elkészítése

- Verses után
- Soha nincs kereszthivatkozás!
- Lehet: Címsorokban, Versekben, Lábjegyzetekben találat

- Oldal felépítése a Body részen belül:
	+ Fő cím sor
		* Változó adattal: Találatok

	+ in Header part
		* Details: NEM változó adatoktal
			- in summary: title: Settings
			- Beállítások rész, összetett szerkezet

	+ in Main part
		* Details: Változó adatoktal
			- in summary: title: 
			- Cím: Címsorok (száma)
			- Találatok
			- Cím: Versek (száma)
			- Találatok
			- Cím: Lábjegyzetek (száma)
			- Találatok

	+ in Footer part
		* Details: NEM változó adatoktal
			- in summary: title: Information
			- Információs rész, összetett szerkezet

## TODO

* Template file: file:///E:/Adatok/Developer/BibleBooksNE/Resources/templates/VersesHtmlFileTemplate_001_WithData_BBNE.html

* Pages

VERSES
verse_group_id
verse
crosslink
footnote

SEARCH
pre_main_title
verse

* Items

VERSE part types

pre_nav_item,           //  ITEM				// not used

page_title,             //  TITLE

chapter_part,           //  ITEM				// not used

verse_group_id,         //  ITEM
headline_title,         //  TITLE

chapter_title,          //  ITEM
verse,                  //  ITEM

crosslink,              //  ITEM

post_nav_item,          //  ITEM				// not used

FOOTNOTE part types

post_main_title,        //  MAIN_TITLE			// not used
footnote,  

* Methods

- for titlels (page_title and, headline_title, post_main_title)
- for verse groupes
- for verses (chapter_title, verse); plus footnote link
- for crosslink; plus anchor links
- for footnotes; plus backward links
- ...
- for navbar (pre_nav_item, post_nav_item); previous and next ids

* Variables

IS_MULTI
WITH_CLS
WITH_HLS

* Arrays

Languages
Labels
Values
Group Ids

* Other Bible pages

- Pre Book Items
- ...
- Bibles with bible parts (All, New, Old, Other)
- Book groupes (books of Moses)
- Book with book parts
- Chapters with chapter parts
- ...
- Chapter with headlines, verses, crosslinks, footnotes, ...
- ...
- Post Book Items
