# Localization

## Tasks

### Persistency
- get language file by user's settings
- open language file
- parse contents
- make dictionary for labels and messages => Localization class

### Model LocalizationHandler
- Get User's Language or Default Language
- Get labels and messages from file

### View controller
- set labels and messages through LocalizationMessages class
- present labels and messages

## JavaScript

- Every html file contains an js array that contains key and value pairs.
- Key is an integer. It is the unique identifier of a message.
- Value is the text of the message.

## Language Files

- Language file content can be deficient that not contains all keyAndValuePairs.
- But id must be unique.
- The first five items are very useful. Do not omit them!

### Pattern: key."Value"

- Key is a number. (0 and above)
- Separator is a period.
- "Value"

## Labels and Messages

### First 10 KeyValuePair Items

First 10 KeyValuePair Items contain information about the program and the language file.

0."1.0.0.0."                                        "1.0.0.0."							// Program Version
1."Zsolt Lőrincz"                                   "Lőrincz Zsolt"						// Author of Language File
2."lorinczzsolt79@gmail.com"                        "lorinczzsolt79@gmail.com"			// Author's email
3."English"                                         "Hungarian"							// English Language Name
4."English"                                         "Magyar"							// Local Language Name
5."en-EN"                                           "hu-HU"								// Short Language Names
6.
7.
8.
9.

### Other Labels

<data name = "" xml:space="preserve"><value></value></data>

### Context Menu Labels

10."Redo"                                           "Visszavonás"
11."Undo"                                           "Újra"
12."Cut"                                            "Kivágás"
13."Copy"                                           "Másolás"
14."Paste"                                          "Beillesztés"
15."Delete"                                         "Törlés"
16."Select All"                                     "Minden Kijelölése"

### Msg
20."Error!"                                            "Hiba!"
21."Warning!"                                          "Figyelem!"
22."Information!"                                      "Infó!"
23."Question!"                                         "Kérdés!"
24.
25.
26.
27.

### ProgramSettings CHANGED!
28."Program Directories"                               "Program Könyvtárak"
29."User's Document Directory"                         "Felhasználó Dokumentumok Könyvtára"
30."Base Directory"                                    "Alap Könyvtár"
31."Default Program Home Directory"                    "Alapértelmezett Program Alap Könyvtár"
32."Default Database Directory"                        "Alapértelmezett Adatbázis Könyvtár"
33."Default Resources Directory"                       "Alapértelmezett Források Könyvtár"
34."Alternative Database Directory"                    "Alternatív Program Alap Könyvtár"
35."Alternative Database Directory"                    "Alternatív Adatbázis Könyvtár"
36."Alternative Resources Directory"                   "Alternatív Források Könyvtár"
37."Developer Program Home Directory"                  "Fejlesztői Program Alap Könyvtára"
38."Developer Database Directory"                      "Fejlesztői Adatbázis Könyvtár"
39."Developer Resources Directory"                     "Fejlesztői Források Könyvtár"

### Form_Main
40."Not implemented yet."                              "Nincs megvalósítva még."
41."Error in navigation."                              "Hiba a navigációkor."

### FileIO
42."File reading error."                               "Fájl olvasási hiba."
43."File writing error."                               "Fájl írási hiba."

### EmptyHtmlPage
44."Template resource file access error."              "Sablon forrásfájl hozzáférési hiba."

### SQLiteDatabaseConnection
45."Missing database name error."                       "Hiányzó adatbázis név hiba."
46."Database reading error."                            "Adatbázis olvasási hiba."
47."The number of rows inserted/updated affected by it:"
                                                        "A sorok száma, amit a beillesztés/frissítés érintett:"
### JS Msg

48."JavaScript runtime error!"                          "JavaScript futtásiidejű hiba!"

### Save File messages
49."Text file"                                             "Szöveges fájl"
50."Markdown file"                                         "Markdown fájl"
51."Other file"                                            "Más fájl típus"

### Open File messages
52."Files to open"                                         "Megnyitható fájlok"
53."Only text files"                                       "Csak szöveges fájlok"
54."Only html files"                                       "Csak html fájlok"
55."All files"                                             "Minden fájl"
56."The file is not valid."                                "A fájl nem megfelelő!"
57."The file not exist."                                   "A fájl nem létezik!"

### Name

58."Name"                                               "Név"
59."Identifier"                                         "Azonosító"
60."Long name"                                          "Hosszú név"
61."Short name"                                         "Rövid név"
62."Directory name"                                     "Könyvtár név"

### Bible Information

63."Bible information"                                  "Biblia Információ"
64."Language"                                           "Nyelv"
65."Description"                                        "Leírás"
66."Source url"                                         "Forrás url"
67."Version"                                            "Verzió"
68."Type"                                               "Típus"
69."Copyright"                                          "Szerzői jog"

70."Searched text"                                      "Keresett Szöveg"
71."Found"                                              "Talált"
72."Database Information"                               "Adatbázis Információk"
73."Databases"                                          "Adatbázisok"
74."Counters"							                "Számlálók"
75."Change Log"						                    "Változás Napló"
76."Book Names"						                    "Könyv Nevek"
77."Bible Parts"						                "Biblia Részek"
78."Book Parts"						                    "Könyv Részek"
79."Chapter Parts"						                "Fejezet Részek"
80."Crosslinks"						                    "Kereszthivatkozások"
81."Headlines"							                "Címsorok"
82."WordsList"							                "Szavak listája"
83.
84.
85.
86.
87.
88.
89.
90.
91.
92.
93.
94.
95.
96.
97.
98.
99.

### Messages in Html Files
100."Welcome!"                                          "Üdvözlöm!"
101."Bibles"                                            "Bibliák"
102."Books"                                             "Könyvek"
103."Chapters"                                          "Fejezetek"
104."Verses"                                            "Versek"
105."Footnotes"                                         "Lábjegyzetek"
106."Information"                                       "Információ"
107."Settings"                                          "Beállítások"
108."Reader Style"                                      "Olvasó stílusa"
109."Multi bible mode"                                  "Többszörös biblia mód"
110."Single bible mode"                                 "Egyszeres biblia mód"
111."List"                                              "Lista"
112."Justify"                                           "Sorkizárt"

### StandardHtmlPage
113."Generated by"                                      "Létrehozva"

### WEB Pages messages
114."Welcome to BibleBooks!"                            "Üdvözli a BibleBooks"
115."User Action Page"                                  "Felhasználói Aktivitás Oldal"
116."No databases."                                     "Nincsenek adatbázisok."
117."Simple Text Page"                                  "Egyszerű Szöveges Oldal"
118."Not Found!"                                        "Nincs találat!"
119."Selection!"                                        "Kiválasztás!"
120."Search Results Page"                               "Keresési Eredmények Oldal"
121."Sorry, something went wrong!"                      "Bocsánat, valami rosszul alakult!"
122."Please, select one or more Bible without 0!"       "Kérem, válassszon egy vagy több Biblát a 0 nélkül!"
123."Please, select Book!"                              "Kérem, válassszon Könyvet!"
124."Please, select Chapter!"                           "Kérem, válassszon Fejezetet!"
125."Please, select Verse!"                             "Kérem, válassszon Verset!"
126."Database was not found."                           "Adatbázis nem található."
127."Not found any Book item."                          "Nem található egyetlen Könyv bejegyzést sem."
128."Not found any Chapter item."                       "Nem található egyetlen Fejezet bejegyzést sem."
129."Not found any Verse item."                         "Nem található egyetlen Verse bejegyzést sem."
130."No matches!"                                       "Nincs egyezés!"