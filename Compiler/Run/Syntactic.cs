using Blair.Compiler.Tokens;
using Blair.Compiler.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blair.Compiler.Run
{
    public class Syntactic
    {
        private List<Error> errors;
        private List<Token> tokens;
        private First first;
        private Follow follow;
        private Token token;
        private int lenght;

        public List<Error> Errors { get => this.errors; set => this.errors = value; }

        public Syntactic (List<Token> tokens)
        {
            this.tokens = tokens;
            this.errors = new List<Error>();
            this.first = new First();
            this.follow = new Follow();
            this.lenght = 0;
        }

        private Token NextToken()
        {
            return (this.lenght < this.tokens.Count)
                ? this.tokens[this.lenght++] 
                : null;
        }

        #region MAIN
        private void _main()
        {
            try
            {
                this.token = NextToken();
                if (!first.Main.Contains(this.token.Code))  // Começa com init?
                    this.errors.Add(new Error("Token 'init' esperado", this.token.Line, this.token.Column));
                this.token = NextToken();
                if (this.token.Code != "opening")   // Depois tem o :?
                    this.errors.Add(new Error("Símbolo ':' esperado", this.token.Line, this.token.Column));
                this.token = NextToken();
                if (this.token.Code != "open-bracket")  // Depois abre chave?
                    this.errors.Add(new Error("Símbolo '{' esperado", this.token.Line, this.token.Column));
                this.token = NextToken();
                _declaration();     // Executa a checagem de declarações
                _command();     // Executa a checagem de comandos
                if (!follow.Main.Contains(this.token.Code))   // No fim, fecha as chaves?
                    this.errors.Add(new Error(" Símbolo '}' esperado", this.token.Line, this.token.Column));
                this.token = NextToken();
            }
            catch  // Os tokens chegaram ao final de forma inesperada 
            {
                this.errors.Add(new Error("EOF inesperado", Compiler.LINE, Compiler.COLUMN));
            }
        }
        #endregion

        #region DECLARATION
        private void _declaration()
        {
            try
            {
                if (first.Declaration.Contains(this.token.Code))    // Inicia com a declaração de tipo?
                {
                    this.token = NextToken();
                    if (this.token.Code != "opening")   // Depois possui o :
                        this.errors.Add(new Error("':' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();
                    bool var = true;
                    bool end = false;
                    bool next = true;

                    while (!follow.Declaration.Contains(this.token.Code) && next)     // Enquanto não for ;
                    {
                        end = true;
                        if (this.token.Code == "var" && var)    // Se é esperado uma variável e é uma variável
                        {
                            var = false;
                            this.token = NextToken();
                            continue;
                        }
                        if (this.token.Code == "comma" && !var)     // Se é esperado uma , e é uma ,
                        {
                            var = true;
                            this.token = NextToken();
                            continue;
                        }
                        if (this.token.Code == "var" && !var)   // Se é esperado uma variável e é uma ,
                        {
                            this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
                            this.token = NextToken();
                            continue;
                        }
                        if (this.token.Code == "comma" && var)   // Se é esperado uma , e é uma variável
                        {
                            this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
                            this.token = NextToken();
                            continue;
                        }

                        if (this.token.Code != "comma" && this.token.Code != "var")    // Se não é nem , nem variável nem ;
                        {
                            this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
                            next = false;
                        }
                        else
                            this.token = NextToken();
                    }

                    if (!end)   // Se não foi declarado nada
                        this.errors.Add(new Error("Token ';' inesperado", this.token.Line, this.token.Column));
                    else if (var)   // Se ainda é esperado uma variável
                        this.errors.Add(new Error("Token <ID> esperado", this.token.Line, this.token.Column));
                    
                    if (next)
                        this.token = NextToken();
                    _declaration();     // Executa a recursão (declaration->declaration->...->null)
                }
            }
            catch   // Os tokens chegaram ao final de forma inesperada 
            {
                this.errors.Add(new Error("EOF inesperado", Compiler.LINE, Compiler.COLUMN));
            }
        }
        #endregion 

        #region COMMAND
        private void _command()
        {
            try
            {
                if (first.Command.Contains(this.token.Code))    // É algum comando
                {
                    switch(this.token.Code)
                    {
                        case "if":  // É um IF
                            _if();  // Executa a checagem do IF
                            break;

                        case "while":   // É um while
                            _while();   // Executa a checagem do WHILE
                            break;

                        case "loop":    // É um loop
                            _loop();    // Executa a checagem do LOOP
                            break;

                        case "var":     // É uma alocação
                            _allocation();  // Executa a alocação de alocação
                            if (!follow.Allocation.Contains(this.token.Code))   // A alocação termina com ;
                                this.errors.Add(new Error("';' esperado", this.token.Line, this.token.Column));
                            this.token = NextToken();
                            break;
                    }
                    _command();     // Executa a recursão de comandos (comando->comando->...->null)
                }
            }
            catch   // Os tokens chegaram ao final de forma inesperada
            {
                this.errors.Add(new Error("EOF inesperado", Compiler.LINE, Compiler.COLUMN));
            }
        }
        #endregion

        #region IF
        private void _if()
        {
            try
            {
                if (first.If.Contains(this.token.Code))
                {
                    this.token = NextToken();
                    if (this.token.Code != "open-parenthesis")
                        this.errors.Add(new Error("Símbolo '(' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();
                    _condition();
                    if (this.token.Code != "close-parenthesis")
                        this.errors.Add(new Error("Símbolo ')' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();
                    if (this.token.Code != "opening")
                        this.errors.Add(new Error("Símbolo ':' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();
                    if (this.token.Code != "open-bracket")
                        this.errors.Add(new Error("'{' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();
                    _command();
                    if (!follow.If.Contains(this.token.Code))
                        this.errors.Add(new Error("'}' esperado", this.token.Line, this.token.Column));
                    _else();
                }
            }
            catch
            {
                this.errors.Add(new Error("EOF inesperado", Compiler.LINE, Compiler.COLUMN));
            }
        }
        #endregion

        #region ELSE
        private void _else()
        {
            if (first.Else.Contains(this.token.Code))
            {
                this.token = NextToken();
                if (this.token.Code != "opening")
                    this.errors.Add(new Error("':' esperado", this.token.Line, this.token.Column));
                this.token = NextToken();
                if (this.token.Code == "open-bracket")
                    this.errors.Add(new Error("'{' esperado", this.token.Line, this.token.Column));
                this.token = NextToken();
                _command();
            }
        }
        private void _else()
        {
            try
            {
                if (first.Else.Contains(this.token.Code))
                {
                    this.token = NextToken();
                    if (this.token.Code == "opening")
                    {
                        this.token = NextToken();
                        if (this.token.Code == "open-bracket")
                        {
                            this.token = NextToken();
                            _command();
                            if (follow.Else.Contains(this.token.Code))
                                this.token = NextToken();
                            else
                                this.errors.Add(new Error("'}' esperado", this.token.Line, this.token.Column));
                        }
                        else
                            this.errors.Add(new Error("'{' esperado", this.token.Line, this.token.Column));
                    }
                    else
                        this.errors.Add(new Error("':' esperado", this.token.Line, this.token.Column));
                }
            }
            catch
            {
                this.errors.Add(new Error("EOF inesperado", Compiler.LINE, Compiler.COLUMN));
            }
        }
        #endregion

        #region COMPARE
        private bool _compare()
        {
            Token aux;
            try
            {
                if (first.Compare.Contains(this.token.Code))
                {
                    aux = this.token;
                    this.token = NextToken();
                    if (this.token.Code == "compare")
                    {
                        this.token = NextToken();
                        if (first.Compare.Contains(this.token.Code))
                            return true;
                        else
                            this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
                    }
                    else
                    {
                        if (aux.Code == "string")
                            this.errors.Add(new Error($"Tipo <STRING> inesperado", this.token.Line, this.token.Column));

                        if (!follow.Compare.Contains(this.token.Code))
                            this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
                    }
                }
            }
            catch
            {
                this.errors.Add(new Error("EOF inesperado", Compiler.LINE, Compiler.COLUMN));
            }
            return false;
        }
        #endregion

        #region RESULT
        private void _result()
        {
            bool not = false;
            try
            {
                if (!first.Result.Contains(this.token.Code))
                    this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
                if (this.token.Code == "!")
                {
                    this.token = NextToken();
                    not = true;
                }

                if (!first.Compare.Contains(this.token.Code))
                    this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
                
                if (this.token.Code == "string" && not)
                    this.errors.Add(new Error($"Tipo <STRING> inesperado", this.token.Line, this.token.Column));
                else
                {
                    _compare();
                    this.token = NextToken();
                    if (this.token.Code == "logic")
                    {
                        this.token = NextToken();
                        _result();
                    }
                    else if (!follow.Result.Contains(this.token.Code))
                        this.errors.Add(new Error($"Token {this.token.Code} inesperado", this.token.Line, this.token.Column));
                }
            }
            catch
            {
                this.errors.Add(new Error("EOF inesperado", Compiler.LINE, Compiler.COLUMN));
            }
        }
        #endregion

        #region CONDITION
        private void _condition()
        {
            try
            {
                if (!first.Codition.Contains(this.token.Code))
                    this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
                _result();
            }
            catch
            {
                this.errors.Add(new Error("EOF inesperado", Compiler.LINE, Compiler.COLUMN));
            }
        }
        #endregion

        #region ALLOCATION
        private void _allocation()
        {
            try
            {
                if (!first.Allocation.Contains(this.token.Code))
                    this.errors.Add(new Error("Tipo variável esperado", this.token.Line, this.token.Column));
                this.token = NextToken();
                if (!(this.token.Code == "attribuition" || this.token.Code == "increment" || this.token.Code == "decrement"))
                    this.errors.Add(new Error("Atributo de atribuição '=', '++' ou '--' esperado", this.token.Line, this.token.Column));
                if (this.token.Code == "attribuition")
                {
                    this.token = NextToken();
                    if (!(this.token.Code == "string" || this.token.Code == "bool" || this.token.Code == "number" || this.token.Code == "var"))
                        this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
                    if (this.token.Code == "var" || this.token.Code == "number")
                        _operation();
                }
                else
                    this.token = NextToken();
            }
            catch
            {
                this.errors.Add(new Error("EOF inesperado", Compiler.LINE, Compiler.COLUMN));
            }
        }
        #endregion

        #region OPERATION
        private void _operation()
        {
            try
            {
                if (!first.Operation.Contains(this.token.Code))
                    this.errors.Add(new Error("Tipo 'number' ou 'var' esperado", this.token.Line, this.token.Column));
                this.token = NextToken();
                if (this.token.Code == "operation")
                {
                    this.token = NextToken();
                    _operation();
                }
                else if (!follow.Operation.Contains(this.token.Code))
                {
                    this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
                }
            }
            catch
            {
                this.errors.Add(new Error("EOF inesperado", Compiler.LINE, Compiler.COLUMN));
            }
        }
        #endregion

        #region WHILE

        private void _while()
        {
            try
            {
                if (first.While.Contains(this.token.Code))
                {
                    this.token = NextToken();
                    if (this.token.Code != "open-parenthesis")
                        this.errors.Add(new Error("Símbolo '(' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();
                    _condition();
                    if (this.token.Code != "close-parenthesis")
                        this.errors.Add(new Error("Símbolo ')' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();
                    if (this.token.Code != "opening")
                        this.errors.Add(new Error("Símbolo ':' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();
                    if (this.token.Code != "open-bracket")
                        this.errors.Add(new Error("Símbolo '{' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();
                    _command();
                    if (!follow.While.Contains(this.token.Code))
                        this.errors.Add(new Error("Símbolo '}' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();
                }
            }
            catch
            {
                this.errors.Add(new Error("EOF inesperado", Compiler.LINE, Compiler.COLUMN));
            }
        }
        /*private void _while()
        {
            try
            {
                if (first.While.Contains(this.token.Code))
                {
                    this.token = NextToken();
                    if (this.token.Code == "open-parenthesis")
                    {
                        _condition();
                        if (this.token.Code == "close-parenthesis")
                        {
                            this.token = NextToken();
                            if (this.token.Code == "opening")
                            {
                                this.token = NextToken();
                                if (this.token.Code == "open-bracket")
                                {
                                    this.token = NextToken();
                                    _command();
                                    if (follow.While.Contains(this.token.Code))
                                        this.token = NextToken();
                                    else
                                        this.errors.Add(new Error("'}' esperado", this.token.Line, this.token.Column));
                                }
                                else
                                    this.errors.Add(new Error("'{' esperado", this.token.Line, this.token.Column));
                            }
                            else
                                this.errors.Add(new Error("':' esperado", this.token.Line, this.token.Column));
                        }
                        else
                            this.errors.Add(new Error("')' esperado", this.token.Line, this.token.Column));
                    }
                    else
                        this.errors.Add(new Error("'(' esperado", this.token.Line, this.token.Column));
                }
            }
            catch
            {
                this.errors.Add(new Error("EOF inesperado", Compiler.LINE, Compiler.COLUMN));
            }
        }*/
        #endregion

        #region LOOP
        private void _loop()
        {
            try
            {
                if (first.Loop.Contains(this.token.Code))   // Começa com loop
                {
                    this.token = NextToken();
                    if (this.token.Code != "open-parenthesis")      // Abriu parentêses
                        this.errors.Add(new Error("Símbolo '(' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();
                    if (!follow.Allocation.Contains(this.token.Code))   // Se houver alocação
                    {
                        _allocation();  // Executa a checagem de alocação
                        if (!follow.Allocation.Contains(this.token.Code))   // Se ainda não tiver ;
                            this.errors.Add(new Error("Símbolo ';' esperado", this.token.Line, this.token.Column));
                    }

                    this.token = NextToken();
                    if (this.token.Code != "end")   // Se houver uma condição
                    {
                        _condition();   // Executa a checagem de condição
                        if (this.token.Code != "end")   // Se ainda não tiver ;
                            this.errors.Add(new Error("Símbolo ';' esperado", this.token.Line, this.token.Column));
                    }

                    this.token = NextToken();
                    if (this.token.Code != "close-parenthesis")     // Se houver o incremento/decremento
                    {
                        _allocation();  // Executa a checagem de alocação
                        //this.token = NextToken();
                    }

                    if (this.token.Code != "close-parenthesis")     // Fechou parentêses
                        this.errors.Add(new Error("Símbolo ')' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();
                    if (this.token.Code != "opening")   // Em seguida vem o : ?
                        this.errors.Add(new Error("Símbolo ':' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();   // Abriu chaves ?
                    if (this.token.Code != "open-bracket")
                        this.errors.Add(new Error("Símbolo '{' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();
                    _command();     // Executa a recursão de comandos (comando->comando->...->null)
                    if (this.token.Code != "close-bracket")
                        this.errors.Add(new Error("Símbolo '}' esperado", this.token.Line, this.token.Column));
                    this.token = NextToken();
                }
            }
            catch
            {
                this.errors.Add(new Error("EOF inesperado", Compiler.LINE, Compiler.COLUMN));
            }
        }
        #endregion

        public void Run()
        {
            _main();
            this.token = NextToken();
            while (this.token != null)
            {
                this.errors.Add(new Error($"Token '{this.token.Lexem}' fora da área de execução", this.token.Line, this.token.Column));
                this.token = NextToken();
            }
        }
    }
}
