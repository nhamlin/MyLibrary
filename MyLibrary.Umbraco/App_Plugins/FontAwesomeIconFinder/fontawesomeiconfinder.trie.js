"use strict";

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var Trie = function Trie() {
  _classCallCheck(this, Trie);

  this.root = new Node();
  this.currentNode = null;
};

Trie.prototype = function () {
  'use strict'; // Prive methods

  function _hide(node) {
    for (var index in node.icons) {
      var icon = node.icons[index]; // Remove this node from the icon's list of active nodes

      icon.activeNodes = icon.activeNodes.filter(function (element) {
        return element !== node;
      }); // Only hide the node if there's no more active icons

      if (!icon.activeNodes.length) {
        if (!icon.classList.contains('hidden')) {
          icon.classList.add('hidden');
        }
      }
    }
  }

  ;

  function _show(node) {
    for (var index in node.icons) {
      var icon = node.icons[index]; // Add this node to this icons list of active nodes

      icon.activeNodes.push(node);
      node.icons[index].classList.remove('hidden');
    }
  }

  ; // Public Methods

  function addWords(words, icon) {
    icon.activeNodes = [];

    for (var index in words) {
      this.root.addWord(words[index].toLowerCase(), icon);
    }
  }

  function toString() {
    this.root.toString("");
  }

  function refine(key) {
    var t0 = performance.now();
    var nextNode = (this.currentNode || this.root).children[key];

    if (nextNode) {
      // We've found a valid child node
      this.currentNode = nextNode;

      if (key === 'backspace') {
        // show all the children
        this.currentNode.findLeaves(_show);
      } else {
        // hide all the siblings
        this.currentNode.parent.findLeaves(_hide, this.currentNode.text);
      }
    } else {
      // no valid child node found so just hide everything
      this.currentNode.findLeaves(_hide);
    }

    var t1 = performance.now();
    console.log("Refining finished in " + (t1 - t0) + "ms");
  }

  function getRoot() {
    return this.root;
  }

  function filter(word) {
    var t0 = performance.now();
    word = word.toLowerCase(); // Hide every thing and filter it later

    this.root.findLeaves(_hide);

    if (!word) {
      // Reset the current not
      this.currentNode = null;
      this.root.findLeaves(_show);
    } else {
      this.root.filter(word);
    }

    var t1 = performance.now();
    console.log("Filtering finished in " + (t1 - t0) + "ms");
  } // This method is used to help json strinify break the
  // circular references caused by the parent child replationships
  // Useage: JSON.stringify(trie.root, trie.replacer)


  function replacer(key, value) {
    if (key === 'text') {
      return {
        name: value
      };
    }

    if (key === 'children') {
      var arr = [];

      for (var k in value) {
        arr.push(value[k]);
      }

      return arr;
    }

    if (key !== 'parent' && key !== 'icons') {
      return value;
    }
  }

  return {
    filter: filter,
    addWords: addWords,
    toString: toString,
    root: getRoot,
    replacer: replacer,
    refine: refine
  };
}();