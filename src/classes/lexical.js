import Symbol from './models/symbol'
import Word from './models/word'
import Token from './models/token';

export default class Lexical {
    constructor(code) {
        this.code = code;
        this.line = 1;
        this.letters = 0;
        this.column = 0;
        this.error = [];
        this.symbols = Symbol();
        this.words = Word();
    }

    nextCharacter() {
        this.column++;
        this.letters++;
    }

    isNumeric(value) {
        return isNaN(value);
    }

    isSymbol(value) {
        return this.symbols.isReserved(value) != undefined;
    }

    getLineInfo() {
        return [this.line, this.column];
    }

    isFinished() {
        return this.letters >= this.code.lenght;
    }

    nextToken() {
        temp = '';
        while (!this.isFinished()) {                // Ler todo o código
            c = code[this.letters];                 // Pega o caracter, digito ou simbolo atual
            while (c == ' ') {                      // lida com todos os espaços logo no inicio
                this.nextCharacter();
                c = code[this.letters];
            }

            if (c == '#') {                         // Comentário ?
                while (c != '\n') {
                    this.nextCharacter();
                    c = code[this.letters];
                }                 
            }
            else {
                if (c == '\n') {                    // Próxima linha ?
                    this.letters++;
                    this.line++;
                    this.column = 0;
                }
                else {
                    if (!this.isNumeric(c)) {
                        while(!this.isSymbol(c) && c != ' ') {
                            temp += c;
                            this.nextCharacter();
                            c = code[this.letters];
                        }
                        tok = this.words.isReserved(temp);
                        if (tok != undefined) {
                            return tok;
                        }
                        else {
                            return new Token('id', temp);
                        }
                    }
                    else {
                        if(this.isNumeric(c) || c == '-') {
                            flag = false;
                            if (c == '-') {
                                temp += c;
                                this.nextCharacter();
                                c = code[this.letters];
                                if (!this.isNumeric(c)) {
                                    temp = '';
                                    this.letters--;
                                    this.column--;
                                    c = code[this.letters];
                                }
                                else {
                                    flag = true;
                                }
                            }
                            else {
                                flag = true;
                            }
                            //
                            if (flag) {
                                while(!this.isSymbol(c) && c != ' ') {
                                    if (c == '.' && temp.includes('.')) {
                                        this.error.push(new Error("Não foi possível processar '..' após um número", this.line, this.column));
                                    }
                                    else {
                                        temp += c;
                                    }
                                    this.nextCharacter();
                                    c = code[this.letters];
                                }

                                try {
                                    num = parseFloat(temp);
                                    if (!isNaN(num)) {
                                        tok = new Token('number', num + '');
                                        tok.type = 'numeric';
                                        tok.value = num + '';
                                        return tok;
                                    }
                                }
                                catch(e) {
                                    this.error.push(new Error('Não foi possível reconhecer o comando especificado', this.line, this.column));
                                    return new Token('id', temp);
                                }
                            }
                        }
                    }
                    //
                    if (c == "'" || c == '"') {
                        if (c == "'") {
                            temp += c;
                            this.nextCharacter();
                            c = code[this.letters];
                            while(c != "'") {
                                temp += c;
                                this.nextCharacter();
                                c = code[this.letters];
                                if(this.letters == this.code.lenght - 1) {
                                    this.error.push(new Error('EOF Inesperado', this.line, this.column));
                                    break;  // GAMBIARRA TEMPORARIA
                                }
                            }
                            temp += c;
                            tok = new Token('string', temp);
                            if (!(temp.startsWith("'") && temp.endsWith("'"))) {
                                this.error.push(new Error('Tipo string incompatível', this.line, this.column));
                            }
                            this.nextCharacter();
                            tok.type = 'string';
                            tok.value = temp;
                            return tok;
                        }
                        else {
                            if (c == '"') {
                                temp += c;
                                this.nextCharacter();
                                c = code[this.letters];
                                while(c != '"') {
                                    temp += c;
                                    this.nextCharacter();
                                    c = code[this.letters];
                                    if(this.letters == this.code.lenght - 1) {
                                        this.error.push(new Error('EOF Inesperado', this.line, this.column));
                                        break;  // GAMBIARRA TEMPORARIA
                                    }
                                }
                                temp += c;
                                tok = new Token('string', temp);
                                if (!(temp.startsWith('"') && temp.endsWith('"'))) {
                                    this.error.push(new Error('Tipo string incompatível', this.line, this.column));
                                }
                                this.nextCharacter();
                                tok.type = 'string';
                                tok.value = temp;
                                return tok;
                            }
                            else {
                                while (c != ' ' && c != '\n' && !this.isNumeric(c) && this.symbols.isReserved(temp) == undefined) {
                                    temp += c;
                                    this.nextCharacter();
                                    c = code[this.letters];
                                }

                                if (this.symbols.isReserved(temp + c) != undefined) {
                                    temp += c;
                                    this.nextCharacter();
                                }
                                tok = this.symbols.isReserved(temp);
                                if (tok != undefined) {
                                    return tok;
                                }
                                else {
                                    this.error.push(new Error('Não foi possível reconhecer o comando especificado', this.line, this.column));
                                    return new Token('?', '?');
                                }
                            }
                        }
                    }
                }
            }
        }
        return undefined;
    }
}