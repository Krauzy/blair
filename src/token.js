module.export = class Token {
    constructor(token, lexem) {
        this.token = token;
        this.lexem = lexem;
        this.value = null;
        this.type = "";
    }

    getJson() {
        return {
            token: this.token,
            lexem: this.lexem,
            value: this.value,
            type: this.type
        }
    }
}