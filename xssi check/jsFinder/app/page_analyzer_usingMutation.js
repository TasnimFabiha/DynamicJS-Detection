/*
// select the target node
var target = document.getElementsByTagName("script");

// create an observer instance
var observer = new MutationObserver(function (mutations) {
    mutations.forEach(function (mutation) {
        console.log(mutation.type);
    });
});

// configuration of the observer:
var config = { attributes: true, childList: true, characterData: true };

// pass in the target node, as well as the observer options
observer.observe(target, config);

// later, you can stop observing
observer.disconnect();
*/



/*
var observer = new MutationObserver(function (mutations) {
    mutations.forEach(function (mutation) {
        console.log('Mutation type: ' + mutation.type);
        if (mutation.type == 'childList') {
            if (mutation.addedNodes.length >= 1) {
                if (mutation.addedNodes[0].nodeName != '#text') {
                    console.log('Added ' + mutation.addedNodes[0].tagName + ' tag.');
                }
            }
            else if (mutation.removedNodes.length >= 1) {
                console.log('Removed ' + mutation.removedNodes[0].tagName + ' tag.')
            }
        }
        else if (mutation.type == 'attributes') {
            console.log('Modified ' + mutation.attributeName + ' attribute.')
        }
    });
});

var observerConfig = {
    attributes: true,
    childList: true,
    characterData: true
};

// Listen to all changes to body and child nodes
var targetNode = document.body;
observer.observe(targetNode, observerConfig);

// Let's add a sample node to see what the MutationRecord looks like
//document.body.appendChild(document.createElement('ol'));
//document.body.removeChild(document.querySelector('ol'));
//document.body.setAttribute('id', 'booooody');

*/


var MutationObserver = window.MutationObserver; /*|| window.WebKitMutationObserver || window.MozMutationObserver*/;
var list = document.querySelector('script');

var observer = new MutationObserver(function (mutations) {
    mutations.forEach(function (mutation) {
        if (mutation.type === 'childList') {
            var list_values = [].slice.call(list.children)
                .map(function (node) { return node.innerHTML; })
                .filter(function (s) {
                    if (s === '<br />') {
                        return false;
                    }
                    else {
                        return true;
                    }
                });
            console.log("here is js: "+list_values);
        }
    });
});

observer.observe(list, {
    attributes: true,
    childList: true,
    characterData: true
});