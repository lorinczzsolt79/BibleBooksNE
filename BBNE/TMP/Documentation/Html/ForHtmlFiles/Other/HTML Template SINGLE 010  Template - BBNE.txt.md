# TODO

## Template handler class

- Create new class
- Verses Html File handler class
    + Multi?
    + Headlines?
    + Crosslinks?
    + Footnotes?
    + Verses Data Array
    + JS Arrays maker
    + GetVersesTempalte
    + Build html output file

## Insertation

1. JS script arrays
2. Verses part
3. Footnote part

### JS script arrays {0}

#### Constants

- Is multi or single?
    + JS Script Variable: const IS_MULTI = {0};

- With or without crosslinks?
    + JS Script Variable: const WITH_CLS = {0};

- With or without headlines?
    + JS Script Variable: const WITH_HLS = {0};

#### Languages

- New class: language handler
- Create langugaes (JS Script) array.
- JS Script Variable: const LANGUAGES = [];
- Array fields: Identifier, 1st language, 2nd language, n. language
- Identifier: short language form (en, hu, ...)

#### Labels

- New class: labels handler
- How to contain and handle?
- Create language (JS Script) array.
- JS Script Variable: const LABELS = [];
- Array fields: Identifier, 1st language, 2nd language, n. language
- Identifier: unique english identifier (Bible_Mode, ...)

#### Values

- New class: values handler
- How to contain and handle?
- Create language (JS Script) array.
- JS Script Variable: const VALUES = [];
- Array fields: Identifier, 1st language, 2nd language, n. language
- Identifier: unique english identifier (Bible_Mode, ...)

Bible mode: (single or multi?); language labels
Date: getDateNow();
Program name: getProgramName();
Program version: getProgramVersion();

##### Group Ids

- Create Group Ids (JS Script) array.
- Add all used group ids to array.
- JS Script Variable: const GROUP_IDS = [];

### Verses part {1}

- ( Previous and Next Chapter handler )
- ( Create Top nav bar and add to Verses part list )
- Create Titles parts
- Create Verses Group
    + Create Verses html entities with footnote links
    + Add to Verses part list
- ( Create Bottom nav bar and add to Verses part list )

#### Parts

* Top nav bar
* Titles
* Verses
* Bottom nav bar

### Footnote part {2}

- New class: footnote handler
- Create footnote html entities add to template.

## Missing

### Crosslinks

- Create crosslinks html entities
- Howto?
- JS Script function post and get data?
- Ids:
    + navigation (crosslink, prev, next): n:1.1.1.1.-1.24
    + verse changed: v:1

### Other pages

* Search html page
* Bible, book, chapter html pages
