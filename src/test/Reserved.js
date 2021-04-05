const Token = require('./Token');

module.exports = class Reserved {
    constructor() {
        this.symbols = [];        
        this.words = [];
        this.load();
    }

    load() {
        this.loadWords();
        this.loadSymbols();
    }

    loadWords() {
        this.words.push(new Token('main', 'init'));
        this.words.push(new Token('type', 'integer'));
        this.words.push(new Token('type', 'decimal'));
        this.words.push(new Token('type', 'string'));
        this.words.push(new Token('type', 'bool'));
        this.words.push(new Token('bool', 'true'));
        this.words.push(new Token('bool', 'false'));
        this.words.push(new Token('if', 'if'));
        this.words.push(new Token('else', 'else'));
        this.words.push(new Token('loop', 'loop'));
        this.words.push(new Token('while', 'while'));
    }

    loadSymbols() {
        this.symbols.push(new Token('{', '{'));
        this.symbols.push(new Token('}', '}'));
        this.symbols.push(new Token('[', ']'));
        this.symbols.push(new Token(']', ']'));
        this.symbols.push(new Token('(', '('));
        this.symbols.push(new Token(')', ')'));
        this.symbols.push(new Token('operation', '*'));
        this.symbols.push(new Token('operation', '+'));
        this.symbols.push(new Token('operation', '-'));
        this.symbols.push(new Token('operation', '/'));
        // this.symbols.push(new Token('operation', '%'));
        this.symbols.push(new Token('attribuition', '='));
        this.symbols.push(new Token('attribuition', '++'));
        this.symbols.push(new Token('attribuition', '--'));
        this.symbols.push(new Token('compare', '>'));
        this.symbols.push(new Token('compare', '>='));
        this.symbols.push(new Token('compare', '<'));
        this.symbols.push(new Token('compare', '<='));
        this.symbols.push(new Token('compare', '!='));
        this.symbols.push(new Token('compare', '=='));
        this.symbols.push(new Token('end', ';'));
        this.symbols.push(new Token('"', '"'));
        this.symbols.push(new Token("'", "'"));
        this.symbols.push(new Token(',', ','));
        this.symbols.push(new Token(':', ':'));
        this.symbols.push(new Token('comment', '#'));
    }

    isReserved(word) {
        var result = undefined;
        this.symbols.forEach((value, index) => {
            if(word == value.getLexem())
                result = value;
        });
        if (result != undefined)
            return result
        this.words.forEach((value, index) => {
            if(word == value.getLexem())
                result = value;
        });
        return result;
    }
}