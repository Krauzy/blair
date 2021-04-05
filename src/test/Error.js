module.exports = class Error {
    constructor(error, line, column) {
        this.error = error;
        this.line = line;
        this.column = column;
    }

    getJson() {
        return {
            error: this.error,
            line: this.line,
            column: this.column
        };
    }

    getMessage() {
        return `ERROR: ${this.error} { line:[${this.line}] column:[${this.column}] }`;
    }
}