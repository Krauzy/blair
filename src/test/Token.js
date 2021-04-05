module.exports = class Token {
    constructor(token, lexem) {
        this.token = token;
        this.lexem = lexem;
    }

    getToken() {
        return this.token;
    }

    setToken(token) {
        this.token = token;
    }

    getLexem() {
        return this.lexem;
    }

    setLexem(lexem) {
        this.lexem = lexem;
    }
}