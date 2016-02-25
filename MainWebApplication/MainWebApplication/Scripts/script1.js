

function hasClass(el, className) {
    if (el.classList)
        return el.classList.contains(className)
    else
        return !!el.className.match(new RegExp('(\\s|^)' + className + '(\\s|$)'))
}

function addClass(el, className) {
    if (el.classList)
        el.classList.add(className)
    else if (!hasClass(el, className)) el.className += " " + className
}

function removeClass(el, className) {
    if (el.classList)
        el.classList.remove(className)
    else if (hasClass(el, className)) {
        var reg = new RegExp('(\\s|^)' + className + '(\\s|$)')
        el.className = el.className.replace(reg, ' ')
    }
}

function MenuBarItemOnClick(obj) {
    
    var nav = document.getElementsByClassName("nav-tabs")[0].children;

    for (var i = 0; i < nav.length; i++) {
        removeClass(nav[i], "active");
    }
    
    addClass(obj, "active");
    alert("asd");
}


$(document).ready(function() {

    //if ($("#aside").css("visibility") == 'collapse') {
    //    $("#renderbody").removeClass("col-md-9");
    //    $("#renderbody").addClass("col-md-12");
    //} 
    
});

