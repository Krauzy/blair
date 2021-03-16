import Token from './token';

export default class word {
    constructor() {
        this.words = [];
        this.words.push(new Token('main', 'init'));
        this.words.push(new Token('type', 'integer'));
        this.words.push(new Token('type', 'decimal'));
        this.words.push(new Token('type', 'character'));
        this.words.push(new Token('type', 'string'));
        this.words.push(new Token('type', 'bool'));
        this.words.push(new Token('bool', 'true'));
        this.words.push(new Token('bool', 'false'));
        this.words.push(new Token('if', 'if'));
        this.words.push(new Token('else', 'else'));
        this.words.push(new Token('loop', 'loop'));
        this.words.push(new Token('while', 'while'));
    }

    isReserved(word) {
        var result = undefined;
        this.words.forEach((value, index) => {
            if (value.lexem === word)
                result = value;
        });
        return result;
    }
}