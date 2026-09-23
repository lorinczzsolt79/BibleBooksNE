const JS_VERSION = "v.001_20260724";

function init() {
    setColorTheme(!DARK);
}

function setColorTheme(isLight) {
    let root = document.querySelector(':root');
    if (isLight) {
        root.style.setProperty('--textColor', 'darkblue');
        root.style.setProperty('--bgColor', 'white');
        root.style.setProperty('--sTextColor', 'whitesmoke');
        root.style.setProperty('--sBgColor', 'darkblue');
        root.style.setProperty('--borderColor', 'blue');
        root.style.setProperty('--myColor', 'rgb(255, 135, 0)');
    } else {
        root.style.setProperty('--textColor', 'white');
        root.style.setProperty('--bgColor', 'black');
        root.style.setProperty('--sTextColor', 'whitesmoke');
        root.style.setProperty('--sBgColor', 'rgb(30, 30, 30)');
        root.style.setProperty('--borderColor', 'gray');
        root.style.setProperty('--myColor', 'rgb(255, 185, 0)');
    }
}
