chrome.browserAction.onClicked.addListener(function (tab) {
    chrome.tabs.executeScript({
        code: 'document.body.style.backgroundColor="red"'
    });
    chrome.tabs.executeScript(null, { file: "page_analyzer.js" });
    // chrome.tabs.query({active: true, currentWindow: true}, function(tabs) {
    // chrome.tabs.sendMessage(tabs[0].id, {greeting: "hello"}, function(response) {
    // console.log(response.farewell);
    // });
    // });

});

chrome.runtime.onMessage.addListener(function (request, sender, sendResponse) {
    console.log(sender.tab ?
                "from a content script:" + sender.tab.url :
                "from the extension");
    console.log(request);
    initiateProcess(request)
    // if (request.greeting == "hello")
    // sendResponse({farewell: "goodbye"});
});

function initiateProcess(obj) {
    var cookies = obj.cookies;
    var currentUrl = obj.currentUrl;
    var scripts = obj.scripts;
    for (var i = 0; i < scripts.length; i++) {
        loadDoc(i, scripts[i].src, scripts[i].content);
    }
    postCookies(cookies, currentUrl);

}

function postCookies(cookies, currentUrl) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            getScriptContent();
        }
    };
    xhttp.open("POST", "http://localhost:55168/home/PostCookies", true);
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send("cookies=" + cookies + "&url=" + currentUrl);
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

