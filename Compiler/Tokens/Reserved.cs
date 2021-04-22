using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blair.Compiler.Tokens
{
    public class Reserved
    {
        private static List<Token> symbols;
        private static List<Token> words;

        public static void Load ()
        {
            Reserved.symbols = new List<Token>
            {
                new Token("bracket", "{", "open-bracket"),
                new Token("bracket", "}", "close-bracket"),
                new Token("bracket", "(", "open-parenthesis"),
                new Token("bracket", ")", "close-parenthesis"),
                new Token("bracket", "[", "open-bracket_2"),
                new Token("bracket", "]", "close-bracket_2"),
                new Token("operation", "+", "operation_plus"),
                new Token("operation", "-", "operation_minus"),
                new Token("operation", "*", "operation_cross"),
                new Token("operation", "/", "operation_division"),
                new Token("operation", "%", "operation_porcent"),
                new Token("attribuition", "=", "attribuition_equals"),
                new Token("attribuition", "++", "attribuition_increment"),
                new Token("attribuition", "--", "attribuition_decrement"),
                new Token("compare", "<", "compare_less_than"),
                new Token("compare", ">", "compare_more_than"),
                new Token("compare", "<=", "compare_less_equals"),
                new Token("compare", ">=", "compare_more_equals"),
                new Token("compare", "==", "compare_equals"),
                new Token("compare", "!=", "compare_different"),
                new Token("end", ";", "end"),
                new Token("string", "'", "string_apostrophe"),
                //new Token("string", "\"", "string_quotation"),
                new Token("comma", ",", "comma"),
                new Token("opening", ":", "opening_double_dots"),
                new Token("comment", "#", "comment")
            };
            //-----------------------------------------------------//
            Reserved.words= new List<Token>
            {
                new Token("main", "init"),
                new Token("type", "integer"),
                new Token("type", "decimal"),
                new Token("main", "string"),
                new Token("main", "bool"),
                new Token("bool", "true"),
                new Token("bool", "false"),
                new Token("if", "if"),
                new Token("else", "else"),
                new Token("loop", "loop"),
                new Token("while", "while")
            };
        }

        public static Token GetSymbol (string symbol)
        {
            Token result = null;
            foreach (Token tk in Reserved.symbols)
            {
                if (tk.Lexem == symbol)
                    result = tk;
            }
            return result;
        }

        public static Token GetWord (string word)
        {
            Token result = null;
            foreach (Token tk in Reserved.words)
            {
                if (tk.Lexem == word)
                    result = tk;
            }
            return result;
        }
    }
}
