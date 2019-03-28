"use strict";

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var Manager = function Manager(container) {
  _classCallCheck(this, Manager);

  this.container = container;
  this.trie = new Trie();
};

Manager.prototype = function () {
  'use strict'; // Instance Constants

  var _styles = {
    "brands": "fab",
    "solid": "fas",
    "light": "fal",
    "regular": "far"
  }; // Private Methods

  function _createIconNode(html) {
    var parser = new DOMParser();
    var doc = parser.parseFromString(html, "image/svg+xml");
    return doc.firstChild;
  }

  function _loadIcons(icons, selectedCallback, parentElement, trie) {
    var iconCount = 0;
    var nodeCount = 0;
    var t0 = performance.now();
    var containerElement = parentElement.getElementsByClassName('result')[0];

    for (var key in icons) {
      iconCount++;
      var icon = icons[key];
      var rawHtml = icon.svg[icon.styles[0]].raw;

      var iconElement = _createIconNode(rawHtml); // set the icon data class 


      iconElement.setAttribute("data-class", _styles[icon.styles[0]] + " fa-" + key);
      iconElement.addEventListener('click', function (e) {
        var iconClass = '';

        if (e.target.nodeName === 'path') {
          iconClass = e.target.parentNode.getAttribute("data-class");
        } else {
          iconClass = e.target.getAttribute("data-class");
        }

        selectedCallback(iconClass);
        console.log("Icon selected: " + iconClass);
      });
      containerElement.appendChild(iconElement);

      if (!icon.search.terms.indexOf(key) > -1) {
        icon.search.terms.push(key);
      }

      nodeCount += icon.search.terms.length;
      trie.addWords(icon.search.terms, iconElement);
    }

    var t1 = performance.now();
    console.log("Loading " + iconCount + " icons with " + nodeCount + " nodes finished in " + (t1 - t0) + "ms");
  } // Public Methods


  function dumpTrie() {
    console.log(JSON.stringify(this.trie.root(), this.trie.replacer));
  }

  function handleKeyUp(e) {
    var key = e.key.toLowerCase(); // Enter, delete or backspace we need to do a full filter of the trie

    if (key === "enter" || key === "delete" || key === "backspace") {
      this.trie.filter(e.target.value);
    } else {
      if (key.length === 1) {
        this.trie.refine(key);
      }
    }
  }

  function setup(selectedCallback, url) {
    var _this = this;

    var xmlhttp = new XMLHttpRequest();

    xmlhttp.onreadystatechange = function () {
      if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
        var json = JSON.parse(xmlhttp.responseText);

        _loadIcons(json, selectedCallback, _this.container, _this.trie);
      }
    };

    xmlhttp.open("GET", url, true);
    xmlhttp.send();
  }

  return {
    setup: setup,
    handleKeyUp: handleKeyUp,
    dumpTrie: dumpTrie
  };
}();