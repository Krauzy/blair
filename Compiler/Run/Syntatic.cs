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

        #region main
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

        #region declaration
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

                        while (this.token.Code != "end")
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

        #region command
        private void _command()
        {
            try
            {
                if (first.Command.Contains(this.token.Code))
                {
                    this.token = NextToken();
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
                            if (this.token.Code == "end")
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

        #region if
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
                                    if (this.token.Code == "close-bracket")
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

        #region else
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
                            if (this.token.Code == "close-bracket")
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

        private void _condition()
        {

        }

        private void _allocation()
        {

        }

        #region while            
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
                                    if (this.token.Code == "close-bracket")
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

        #region loop
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
                        if (this.token.Code != "end")
                        {
                            _allocation();
                            if (this.token.Code != "end")
                                this.errors.Add(new Error("';' esperado", this.token.Line, this.token.Column));
                        }
                        else
                        {
                            this.token = NextToken();
                            if (this.token.Code != "end")
                            {
                                _condition();
                                if (this.token.Code != "end")
                                    this.errors.Add(new Error("';' esperado", this.token.Line, this.token.Column));
                            }
                            else
                            {
                                this.token = NextToken();
                                if (this.token.Code != "end")
                                    _allocation();
                                if (this.token.Code == "close-parenthesis")
                                {
                                    this.token = NextToken();
                                    if (this.token.Code == "opening")
                                    {
                                        this.token = NextToken();
                                        if (this.token.Code == "open-bracket")
                                        {
                                            _command();
                                            if (this.token.Code == "close-bracket")
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
