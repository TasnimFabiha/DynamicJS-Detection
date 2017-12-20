chrome.runtime.onMessage.addListener(
  function (request, sender, sendResponse) {
      console.log(sender.tab ?
                  "from a content script:" + sender.tab.url :
                  "from the extension");
      if (request.greeting == "hello")
          sendResponse({ farewell: "goodbye" });
  });

// chrome.runtime.sendMessage({greeting: "hello"}, function(response) {
// console.log(response.farewell);
// });

findScripts((obj) => {
    console.log(obj);
    chrome.runtime.sendMessage(obj, function (response) {
        //console.log(response.farewell);
    });
});

function findScripts(callback) {
    var scriptList = [];
    var cookies = document.cookie;
    var currenturl = window.location.href;
    var scripts = document.getElementsByTagName("script");
    for (var i = 0; i < scripts.length; i++) {
        if (scripts[i].src) {
            scriptList.push({ index: i, src: scripts[i].src, content: "" });
        }
        //else {
        //scriptList.push({index:i, src: window.location.href, content:scripts[i].innerHTML});
        //}
    }
    callback({ currentUrl: currenturl, cookies: cookies, scripts: scriptList });

}