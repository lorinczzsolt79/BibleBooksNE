
E:\Adatok\Szoftver Fejlesztő Suli\Visual Studio\source\repos\BibleBookNew\BibleBookNew\Documentation\

## Examples:

* 1-moz	Teremtés
* 2-moz	Kivonulás
* 3-moz	Léviták
* 4-moz	Számok
* 5-moz	Igék

* NIV Bible (1984) / Genesis / 1

* »1.1.1«
* »1.1.1.«
* »001.001.001«
* »001.001.001.«
* »1-moz.1.1«
* »1-moz.1.1.«

* »1-moz.001.001«
* »1-moz.001.001.«
* »002.001.001.001«
* »002.001.001.001.«
* »HUK.001.001.001«
* »HUK.001.001.001.«
* »HUK.1-moz.001.001«
* »HUK.1-moz.001.001.«
* »002.1-moz.001.001«
* »002.1-moz.001.001.«
	
* »GEN.1.1«
* »GEN.1.1.«
* »NIV.001.001.001«
* »NIV.001.001.001.«
* »003.001.001.001«
* »003.001.001.001.«

## Output:

| Name | Description|
| :--- | :--- |
| Bible | Short Name, LongName, | number (1), formatted number (001),	formattedWithSeparator (001.) |
| Book | Short Name, LongName, | number (1), formatted number (001),	formattedWithSeparator (001.) |
| Chapter | 					  | number (1), formatted number (001),	formattedWithSeparator (001.) |
| Verse	| 					  | number (1), formatted number (001),	formattedWithSeparator (001.) |
| Text Title Format |	| LongBibleName / LongBookName / Chapter ( NIV Bible (1984) / Genesis / 1 )	Separator: /  |

## Separators:

| Name| Description| Example |
| :--- | :--- | :--- |
| space			| between FullIds and text 	|	001.001.001. At the Begining ... |
| full stop			| separator between two ids	|	(002.001.001.001.) |
||||
| semicolon	| separator between two FullIds	|	(001.001.001.001.;002.002.002.002.;003.003.003.003.) |
| comma		| separator between two verse ids, enumeration	|	(1,5,7,9) |
| minus sign	| separator between two verse ids, from to	|	(1-5) |
| mixed		| 	|	(1-5;7;10-12;15;20-31) |

## Bible parts:

* Old Testament

	| Long Name         | With Short Names | From To |
	| :---				| :---			   |  :---   |
	| Pentateuch		| (1Mó -- 5Mó)	   | 1-5	 |
	| History			| (Jós -- Esz)	   | 6-17	 |
	| Wisdom			| (Jób -- Ene)	   | 18-22	 |
	| Major Prophets	| (Ezs -- Dán)	   | 23-27	 |
	| Minor Prophets	| (Hos -- Mal)	   | 28-39	 |

* New Testament

	| Long Name| With Short Names | From To |
	| :--- | :--- | :--- |
	| Gospels & Acts	| (Mat -- ACS)	| 40-44 |
	| Paul's Letters	| (Róm -- Zsi)	| 45-58 |
	| General Letters	| (Jak -- Júd)	| 59-65 |
	| Apocalypse		| (Jel)			| 66	|
