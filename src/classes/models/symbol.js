import Token from './token';

export default class Symbol {
    constructor() {
        this.symbols = [];
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
        this.symbols.push(new Token('operation', '%'));
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
        this.symbols.push(new Token('$', '$'));
        this.symbols.push(new Token(',', ','));
        this.symbols.push(new Token(':', ':'));
        this.symbols.push(new Token('comment', '#'));
    }

    isReserved(word) {
        var result = undefined;
        this.symbols.forEach((value, index) => {
            if (value.lexem === word)
                result = value;
        });
        return result;
    }
}