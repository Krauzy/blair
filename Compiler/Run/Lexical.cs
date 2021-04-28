using Blair.Compiler.Tokens;
using Blair.Compiler.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blair.Compiler.Run
{
    public class Lexical
    {
        private string code;
        public int row;
        public int column;
        private int letters;

        public List<Token> Tokens { get; set; }
        public List<Error> Errors { get; set; }

        public Lexical (string code)
        {
            this.code = code;
            this.row = 0;
            this.column = 0;
            this.letters = 0;
            this.Errors = new List<Error>();
            this.Tokens = new List<Token>();
        }

        public Lexical(string code, List<Error> errors, List<Token> tokens)
        {
            this.code = code;
            this.row = 0;
            this.column = 0;
            this.letters = 0;
            this.Errors = errors;
            this.Tokens = tokens;
        }

        private bool IsNumber(string value)
        {
            return double.TryParse(value, out _);
        }

        private bool AddToken(string value)
        {
            Token t = Reserved.GetSymbol(value);
            if (t != null)
            {
                this.Tokens.Add(new Token(t, row, column));
                return true;
            }
            t = Reserved.GetWord(value);
            if (t != null)
            {
                this.Tokens.Add(new Token(t, row, column));
                return true;
            }
            return false;
        }

        private bool IsReserved(string value)
        {
            return Reserved.GetSymbol(value) != null || Reserved.GetWord(value) != null;
        }

        private void CheckDoubleSymbols()
        {
            string[] symbs = { "++", "--", "!=", "==", "<=", ">=" };
            for (int i = 0; i < this.Tokens.Count - 1; i++)
            {
                foreach(string s in symbs)
                {
                    if (Tokens[i].Lexem == s[0].ToString() && Tokens[i + 1].Lexem == s[1].ToString())
                    {
                        Tokens.RemoveAt(i + 1);
                        Tokens[i] = Reserved.GetSymbol(s);
                    }
                }
            }
        }

        public void Run()
        {
            try
            {
                string[] rows = code.Split('\n');
                foreach (string line in rows)
                {
                    for (this.column = 0; this.column < line.Length; this.column++, this.letters++)
                    {
                        if (line[this.column] == '#')       // Comment
                        {
                            this.Tokens.Add(new Token("comment", line.Substring(this.column), line: this.row, column: this.column));
                            continue;
                        }
                        else if (char.IsWhiteSpace(line[this.column]))      // White Space
                        {
                            continue;
                        }
                        else if (line[this.column] == '\'')     // String
                        {
                            string temp = string.Empty;
                            this.column++;
                            this.letters++;
                            while (this.column < line.Length && line[this.column] != '\'')
                            {
                                temp += line[this.column];
                                this.column++;
                                this.letters++;
                            }
                            if (this.column < line.Length && line[this.column] == '\'')      // String done ?
                            {
                                this.Tokens.Add(new Token("string", $"'{temp}'", line: this.row, column: this.column));      // String Token
                                continue;
                            }
                            else    // String not done ?
                            {
                                this.Errors.Add(new Error($"'{temp} -> Esperado \"'\"", row, column));      // Trigger String Error
                                continue;
                            }
                        }
                        else if (!this.IsNumber(line[this.column].ToString()))      // É Caracter
                        {
                            if (line[this.column] != '-' && AddToken(line[this.column].ToString()))     // É símbolo
                                continue;
                            else
                            {
                                if (line[this.column] == '-')       // É menos ou negativo ?
                                {
                                    if (line[this.column + 1] == ' ')       // É menos
                                    {
                                        AddToken(line[this.column].ToString());
                                        continue;
                                    }
                                    else        // É negativo
                                    {
                                        string temp = string.Empty;
                                        temp += line[this.column++];
                                        this.letters++;
                                        while (this.column < line.Length && !char.IsWhiteSpace(line[this.column]))
                                        {
                                            temp += line[this.column++];
                                            this.letters++;
                                        }
                                        if (!IsNumber(temp))
                                            this.Errors.Add(new Error($"{temp} não reconhecido!", row, column));
                                        else
                                            this.Tokens.Add(new Token("number", temp, line: this.row, column: this.column));
                                        continue;
                                    }
                                }
                                else        // É algum caracter
                                {
                                    string temp = string.Empty;
                                    while (this.column < line.Length && !char.IsWhiteSpace(line[this.column]) && !this.IsReserved(line[this.column].ToString()))
                                    {
                                        temp += line[this.column];
                                        this.column++;
                                        this.letters++;
                                    }
                                    if (!AddToken(temp))        // É palavra reservada
                                        this.Tokens.Add(new Token("var", temp, line: this.row, column: this.column));        // É variável
                                    AddToken(line[this.column].ToString());
                                    continue;
                                }
                            }
                        }
                        else    // É número
                        {
                            string temp = string.Empty;
                            while (this.column < line.Length && !char.IsWhiteSpace(line[this.column]) && !IsReserved(line[this.column].ToString()))
                            {
                                temp += line[this.column++];
                                this.letters++;
                            }
                            if (IsNumber(temp))
                                this.Tokens.Add(new Token("number", temp, line: this.row, column: this.column));
                            else
                                this.Errors.Add(new Error($"Valor '{temp}' inconsistente", row, column));

                            AddToken(line[this.column].ToString());

                        }
                    }
                    this.row++;
                }
                CheckDoubleSymbols();
            }
            catch
            {
                this.Errors.Add(new Error($"EOF inesperado", row, column));
            }
        }
    }
}
