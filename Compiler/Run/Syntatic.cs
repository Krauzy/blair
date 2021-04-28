using Blair.Compiler.Tokens;
using Blair.Compiler.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blair.Compiler.Run
{
    public class Syntatic
    {
        private List<Error> errors;
        private List<Token> tokens;
        private First first;
        private Follow follow;
        private Token token;
        private int lenght;

        public List<Error> Errors { get => this.errors; set => this.errors = value; }

        public Syntatic (List<Token> tokens)
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
                if (first.Main.Contains(this.token.Code))
                {
                    this.token = NextToken();
                    if (this.token.Code == "opening")
                    {
                        this.token = NextToken();
                        if (this.token.Code == "open-bracket")
                        {
                            this.token = NextToken();
                            _declaration();
                            _command();
                            if (this.token != null && !follow.Main.Contains(this.token.Code))
                                this.errors.Add(new Error("'}' esperado", this.token.Line, this.token.Column));
                        }
                        else
                            this.errors.Add(new Error("'{' esperado", this.token.Line, this.token.Column));
                    }
                    else
                        this.errors.Add(new Error("':' esperado", this.token.Line, this.token.Column));
                }
                else
                    this.errors.Add(new Error("'init' esperado", this.token.Line, this.token.Column));
            }
            catch
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
                if (first.Declaration.Contains(this.token.Code))
                {
                    this.token = NextToken();
                    if (this.token.Code == "opening")
                    {
                        this.token = NextToken();
                        bool var = true;
                        bool end = false;

                        while (this.token != null && !follow.Declaration.Contains(this.token.Code))
                        {
                            end = true;
                            if (this.token.Code == "var" && var)
                            {
                                var = false;
                                this.token = NextToken();
                                continue;
                            }
                            if (this.token.Code == "comma" && !var)
                            {
                                var = true;
                                this.token = NextToken();
                                continue;
                            }
                            if (this.token.Code == "var" && !var)
                            {
                                this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
                                this.token = NextToken();
                                continue;
                            }
                            if (this.token.Code == "comma" && var)
                            {
                                this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
                                this.token = NextToken();
                                continue;
                            }

                            if (this.token.Code != "comma" && this.token.Code != "var")
                                this.errors.Add(new Error($"token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));

                            this.token = NextToken();
                        }

                        if (!end)
                            this.errors.Add(new Error("';' inesperado", this.token.Line, this.token.Column));
                        else if (var)
                            this.errors.Add(new Error("<ID> esperado", this.token.Line, this.token.Column));

                        this.token = NextToken();
                        _declaration();
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

        #region COMMAND
        private void _command()
        {
            try
            {
                if (first.Command.Contains(this.token.Code))
                {
                    //this.token = NextToken();
                    switch(this.token.Code)
                    {
                        case "if":
                            _if();
                            break;

                        case "while":
                            _while();
                            break;

                        case "loop":
                            _loop();
                            break;

                        case "var":
                            _allocation();
                            if (follow.Allocation.Contains(this.token.Code))
                                this.token = NextToken();
                            else    
                                this.errors.Add(new Error("';' esperado", this.token.Line, this.token.Column));
                            break;
                    }
                    _command();
                }
            }
            catch
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
                                    this.token = NextToken();
                                    if (follow.If.Contains(this.token.Code))
                                        _else();
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
        }
        #endregion

        #region ELSE
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
                    else    //GAMBIARRA
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
                if (first.Result.Contains(this.token.Code))
                {
                    if (this.token.Code == "!")
                    {
                        this.token = NextToken();
                        not = true;
                    }

                    if (first.Compare.Contains(this.token.Code))
                    {
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
                    else
                        this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
                }
                else
                    this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
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
                if (first.Codition.Contains(this.token.Code))
                    _result();
                else
                    this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
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
                if (first.Allocation.Contains(this.token.Code))
                {
                    this.token = NextToken();
                    if (this.token.Code == "attribuition" || this.token.Code == "increment" || this.token.Code == "decrement")
                    {
                        if (this.token.Code == "attribuition")
                        {
                            this.token = NextToken();
                            if (this.token.Code == "string" || this.token.Code == "bool" || this.token.Code == "number" || this.token.Code == "var")
                            {
                                if (this.token.Code == "var" || this.token.Code == "number")
                                    _operation();
                            }
                            else
                                this.errors.Add(new Error($"Token '{this.token.Lexem}' inesperado", this.token.Line, this.token.Column));
                        }
                    }
                    else
                        this.errors.Add(new Error("Atributo de atribuição '=', '++' ou '--' esperado", this.token.Line, this.token.Column));
                }
                else
                    this.errors.Add(new Error("Tipo variável esperado", this.token.Line, this.token.Column));
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
                if (first.Operation.Contains(this.token.Code))
                {
                    this.token = NextToken();
                    if (this.token.Code == "operation")
                    {
                        this.token = NextToken();
                        _operation();
                    }
                    else if (!follow.Operation.Contains(this.token.Code))
                    {
                        this.errors.Add(new Error("';' esperado", this.token.Line, this.token.Column));
                    }
                }
                else
                    this.errors.Add(new Error("Tipo 'number' ou 'var' esperado", this.token.Line, this.token.Column));
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
        }
        #endregion

        #region LOOP
        private void _loop()
        {
            try
            {
                if (first.Loop.Contains(this.token.Code))
                {
                    this.token = NextToken();
                    if (this.token.Code == "open-parenthesis")
                    {
                        this.token = NextToken();
                        if (!follow.Declaration.Contains(this.token.Code))
                        {
                            _allocation();
                            if (!follow.Declaration.Contains(this.token.Code))
                            {
                                this.errors.Add(new Error("';' esperado", this.token.Line, this.token.Column));
                            }
                        }

                        this.token = NextToken();
                        if (this.token.Code != "end")
                        {
                            _condition();
                            if (this.token.Code != "end")
                                this.errors.Add(new Error("';' esperado", this.token.Line, this.token.Column));
                        }
                        
                        this.token = NextToken();
                        if (this.token.Code != "end")
                        {
                            _allocation();
                            this.token = NextToken();
                        }
                            
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
                                    if (follow.Loop.Contains(this.token.Code))
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
        }
    }
}
