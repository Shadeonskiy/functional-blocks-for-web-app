var theme_status = localStorage.getItem("theme");
var root = document.documentElement;
var get_style = getComputedStyle(root);

if(theme_status == null) {
    localStorage.setItem("theme", "light");
}

if(localStorage.getItem("theme") == "dark") {
    root.style.setProperty('--light-back', get_style.getPropertyValue('--dark-back'));
    root.style.setProperty('--light-form-back', get_style.getPropertyValue('--dark-form-back'));
    root.style.setProperty('--light-theme-color', get_style.getPropertyValue('--dark-theme-color'));
    root.style.setProperty('--light-background-item', get_style.getPropertyValue('--dark-background-item'));
    root.style.setProperty('--light-header-footer', get_style.getPropertyValue('--dark-header-footer'));
    }

function change_theme() {
    if(localStorage.getItem("theme") == "light") {
        localStorage.setItem("theme", "dark"); 
        root.style.setProperty('--light-back', get_style.getPropertyValue('--dark-back'));
        root.style.setProperty('--light-form-back', get_style.getPropertyValue('--dark-form-back'));
        root.style.setProperty('--light-theme-color', get_style.getPropertyValue('--dark-theme-color'));
        root.style.setProperty('--light-background-item', get_style.getPropertyValue('--dark-background-item'));
        root.style.setProperty('--light-header-footer', get_style.getPropertyValue('--dark-header-footer'));
    }
    else {
        localStorage.setItem("theme", "light"); 
        root.style.setProperty('--light-back', '#D9EAEA');
        root.style.setProperty('--light-form-back', '#F6FBF9');
        root.style.setProperty('--light-theme-color', '#000');
        root.style.setProperty('--light-background-item', '#ADCECC');
        root.style.setProperty('--light-header-footer', '#F0FBFB');
    }
}