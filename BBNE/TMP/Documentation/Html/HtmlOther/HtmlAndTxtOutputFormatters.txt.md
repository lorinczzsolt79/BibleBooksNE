
## árvíztûrõ tökörfúrógép

## ÁRVÍZTÛRÕ TÖKÖRFÚRÓGÉP

## Localazation:

## Formatter osztályok:

* TXT.MD , HTML (, SQL)
* Ezek az osztályok lehet, hogy nem szükségesek.
* Lehet, hogy egy külön Formatter osztálynak kellene kezelnie ezeket. A különbözõ feladatokat.

	+ new Verses class, extends FullIdsWithText class, MarkDown formázással

		- TXT.MD átalakítás, sima szöveggé, tisztítás
		- HTML átalakítás, lábjegyzet átalakítás, CSS, JS
		- HTML átalakítás, szöveg szín kezelés, CSS, JS

	+ new Crosslinks class, extends FullIdsWithText class, MarkDown formázással

		- TXT.MD átalakítás, Rövid Könyvneves formára
		- HTML átalakítás, hivatkozások más igehelyekre, CSS, JS
		- A WebView lapoz elõre és vissza

	+ new Footnote class, extends FullIdsWithText class, MarkDown formázással

		- TXT.MD átalakítás, szöveges lista formára
		- HTML átalakítás, hivatkozások versekre, CSS, JS
		- Egy Div-ben, listaszerûen, Címmel: Footnotes

	+ new Headline class, extends FullIdsWithText class, MarkDown formázással

		- TXT.MD átalakítás, szöveges címsorrá alakítás
		- HTML átalakítás, címsorrá, CSS, JS

	+ new WordList class, extends FullIdsWithText class

		- TXT.MD átalakítás, szöveges lista formára, MarkDown formázással
		- HTML átalakítás, lista felsorolás, CSS, JS
		- (szótár hivatkozás)

	+ new Audio class, extends FullIdsWithText class

		- Valahol hivatkozásként fog megjelenni

* HTML

	- char to HTML code
	- {cn} to HTML tag

* SQL

``` SQL
	- SELECT * FROM "Verses" WHERE "text" LIKE '%&%;%';
	- SELECT * FROM "Verses" WHERE "text" LIKE '%<%>%';
	- SELECT * FROM "Verses" WHERE "text" LIKE '%{%}%';
```