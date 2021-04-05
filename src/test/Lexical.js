const Reserved = require('./Reserved');
const Token = require('./Token');
const Error = require('./Error');

module.exports = class Lexical {
    constructor(code) {
        this.code = code;
        this.errors = [];
        this.line = 0;
        this.column = 0;
        this.letters = 0;
        this.tokens = [];
        this.reserved = new Reserved();
    }

    getTokens() {
        return this.tokens;
    }

    getErrors() {
        return this.errors;
    }

    isNumber(value) {
        return !isNaN(parseFloat(value));
    }

    isReserved(value) {
        return this.reserved.isReserved(value) != undefined;
    }

    execute() {
        const splits = this.code.split('\n');
        splits.forEach(element => { // Roda todas as linhas
            const line = element.split('\t').join('').trim();
            // console.log(line);
            var end = false;
            for(var i = 0; i < line.length && !end; i++) { // Roda todas as colunas da linha
                if(line[i] == '#') {   // Comentário?
                    this.tokens.push(new Token('comment', line.substring(i))); // Retorna todo os comentário para um token e finaliza
                    end = true;
                }

                if(line[i] == ' ')
                    i++;

                if (!end && line[i] == "'") {   // String?
                    var temp = '';
                    i++;
                    while(line[i] != "'" && i < line.length) {
                        temp += line[i];
                        i++;
                    }

                    if(line[i] == "'") {
                        this.tokens.push(new Token('string', "'" + temp + "'"));
                        i++;
                    }
                    else {
                        this.errors.push(new Error(`"${"'" + temp}" -> Esperado um "'"`, this.line + 1, i));
                        end = true;
                    }                        
                }

                if (!end && !this.isNumber(line[i])) {    // Caracter?
                    if (this.isReserved(line[i]))
                        this.tokens.push(this.reserved.isReserved(line[i]));
                    else {
                        if (line[i] == '-') {   // É o símbolo do negativo?
                            i++;
                            var temp = '';
                            while(this.isNumber(line[i]) && i < line.length) {
                                temp += line[i];
                                i++;
                            }
                            if(i < line.length && temp.length > 0)
                                this.tokens.push(new Token('number', '-' + temp));
                            else {
                                if (temp.length == 0)
                                    this.errors.push(new Error(`"-" inesperado`, this.line + 1, i - 1));
                                else
                                    this.errors.push(new Error(`EOF inesperado`, this.line + 1, i));
                            }
                        }
                        else {
                            var temp = '';
                            while(line[i] != ' ' && !this.isReserved(line[i]) && i < line.length) {
                                temp += line[i];
                                i++;
                            }

                            if (i <= line.length) {
                                if(this.isReserved(temp))
                                    this.tokens.push(this.reserved.isReserved(temp));   // É uma palavra reservada
                                else
                                    this.tokens.push(new Token('variable', temp));      // É uma variável

                                if(this.isReserved(line[i])) {
                                    this.tokens.push(this.reserved.isReserved(line[i]));
                                    i++;
                                }                                  
                            }
                            else {
                                console.log(i);
                                this.errors.push(new Error(`EOF inesperado`, this.line + 1, i));
                            }
                                
                        }
                    }
                }
                else {      // É número?
                    var temp = '';
                    var aux = i;
                    while(this.isNumber(line[i]) || line[i] == '.') {
                        temp += line[i];
                        i++;
                    }
                    if (temp.replace(/[^.]/g, "").length > 1)
                        this.errors.push(new Error(`"${temp}" -> tipo <DECIMAL> inconsistente`, this.line + 1, aux));
                    else {
                        if(this.isNumber(temp))
                            this.tokens.push(new Token('number', temp));
                        else
                            this.errors.push(new Error(`"${temp}" -> tipo <?> inconsistente`, this.line + 1, aux));
                    }
                    if(this.isReserved(line[i])) {
                        this.tokens.push(this.reserved.isReserved(line[i]));
                        i++;
                    }                      
                }
            }
            this.line++;
        });
    }
}