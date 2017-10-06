document.body.innerHTML = document.body.innerHTML.replace(new RegExp("Gmail", "g"), "nobody");

window.onload = function () {
    var scripts = document.getElementsByTagName("script");
    for (var i = 0; i < scripts.length; i++) {
        if (scripts[i].src) {
            console.log(i, scripts[i].src);
            window.loadDoc(i, scripts[i].src, "");
        }
        else {
            console.log(i, scripts[i]);
            window.loadDoc(i, "", scripts[i].innerHTML);

        }
    }
    //alert(scripts.length);
}
