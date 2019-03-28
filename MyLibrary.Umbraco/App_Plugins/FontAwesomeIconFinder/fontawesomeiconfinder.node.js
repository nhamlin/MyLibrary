"use strict";

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

// Node Object methods
var Node = function Node(text) {
  var _this = this;

  _classCallCheck(this, Node);

  this.text = text;
  this.children = {};
  this.parent = null;
  this.icons = [];

  this.isRoot = function () {
    return _this.parent === null;
  };
};

Node.prototype = function () {
  'use strict'; // Public Methods

  function toString(prefix) {
    console.log(prefix + (this.text || 'root'));

    for (var index in this.children) {
      prefix += "-";
      this.children[index].toString(prefix);
    }
  }

  function findLeaves(func, foundKey) {
    if (this.icons.length > 0) {
      // this is a valid path even if it doesn't end in a leaf
      func(this); // This is a debugging line. It will impact performance heavily. Dont use in production
      //this.printPath();
    }

    if (this.children) {
      for (var index in this.children) {
        if (foundKey && index !== foundKey || !foundKey) {
          this.children[index].findLeaves(func);
        }
      }
    }
  }

  function printPath(path) {
    var currentPath = "";

    if (!this.isRoot()) {
      currentPath = this.text + currentPath;
    }

    if (path) {
      currentPath = currentPath + path;
    }

    if (this.parent) {
      this.parent.printPath(currentPath);
    } else {
      console.log(currentPath);
    }
  }

  function filter(word) {
    if (word[0] === this.text || this.isRoot()) {
      if (word.length === 1 && !this.isRoot()) {
        this.findLeaves(_show);
      } else {
        if (this.children) {
          for (var index in this.children) {
            var newWord = this.isRoot() ? word : word.substring(1);
            this.children[index].filter(newWord);
          }
        } else {
          this.findLeaves(_show);
        }
      }
    }
  }

  function addWord(word, icon) {
    if (!word) {
      icon.activeNodes.push(this);
      this.icons.push(icon);
      return;
    }

    var nextChild = this.children ? this.children[word[0]] : null; // we've found the next child 

    if (nextChild) {
      nextChild.addWord(word.substring(1), icon);
    } else {
      var newChild = new Node(word[0]);
      newChild.parent = this;

      if (!this.children) {
        this.children = {};
      }

      this.children[word[0]] = newChild;
      newChild.addWord(word.substring(1), icon);
    }
  }

  return {
    toString: toString,
    findLeaves: findLeaves,
    printPath: printPath,
    filter: filter,
    addWord: addWord
  };
}();