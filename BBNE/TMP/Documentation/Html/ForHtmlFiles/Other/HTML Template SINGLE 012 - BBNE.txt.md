# TODO

## BUILDER CLASS

- Get data
- New class: Html file and template handler

    1. script part {0}
        + make constant variable items
        + make group ids array
        + make program data array

    2. verses {1}
        + make top navbar
        + make titles
        + make verses with footnote links
        + make crosslinks
        + make bottom navbar
        + make footnote links in verses
    
    3. footnote part {2}
        + make footnote item

## TEMPLATE HANDLER CLASS

- Create new class
- Verses Html File handler class
    + Multi?
    + Headlines?
    + Crosslinks?
    + Footnotes?
    + Verses Data Array
    + GetVersesTempalte
    + Build html output file

## INSERTATION

1. JS script arrays
2. Verses part
3. Footnote part


### JS Script part

#### Arrays

##### Get info about single or multi

``` js
    const IS_MULTI = false;
```

##### Get info about addons

``` JS
    const WITH_CLS = true;
    const WITH_HLS = true;
    const WITH_FNS = true;
```

##### Make values array

``` JS
    const VALUES = [
      ["Date", "2026-02-08"],
      ["Program_Name", "BibleBooks New Edition"],
      ["Program_Version", "v.1.0.0.0."]
    ];
```
    
##### Make group ids array

``` JS
    const GROUP_IDS = [
      "000001001000",
      "000001001001",
      "000001001002",
      "000001001003",
      "000001001004",
      "000001001005",
      "000001001006",
      "000001001998",
      "000001001999"
    ];
```

  Get group ids from List.

### Verses part

#### Add Simple top navbar

#### Add Titles

  + more languages

#### Add verses with crosslinks and with footnote links

  + verse entity maker
  + crosslinks entity maker
  + footnote link maker

#### Add Simple bottom navbar

### Footnotes part

  + make footnote html li entities

## MISSING

### Crosslinks

- Create crosslinks html entities
- Howto?

### Naviagtion

- JS Script function post and get data?
- Ids:
    + navigation (crosslink, prev, next): n:1.1.1.1.-1.24
    + verse changed: v:1

### Footnote groups

- titles (bible name)

#### Example

NIV
1. footnote
2. footnote

WEB
1. footnote

### Other pages

* Search html page
* Bible, book, chapter html pages

## WITHOUT

### Language and Labels handler

- no language files
- no language labels
- no language class

### Navigator items

- previous and next page handler
