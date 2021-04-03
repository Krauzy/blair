export default class Token {
    constructor(token, lexem) {
        this.token = token;
        this.lexem = lexem;
        this.value = null;
        this.type = "";
    }

    setType(type) {
        this.type = type;
    }

    setValue(value) {
        this.value = value;
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