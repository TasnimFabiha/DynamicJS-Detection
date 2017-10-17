chrome.tabs.onUpdated.addListener(function (tabId, changeInfo, tab) {
    //alert("background js");
    if (changeInfo.status == 'complete') {
        chrome.tabs.getSelected(null, function (tab) {
            chrome.tabs.sendRequest(0, {
                method: "getText"
            }, function (response) {
                if (response.method == "getText") {
                    alltext = response.data;
                }
            });
        });
    }
})