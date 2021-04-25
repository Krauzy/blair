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
                new Token("open-bracket", "{"),
                new Token("close-bracket", "}"),
                new Token("open-parenthesis", "("),
                new Token("close-parenthesis", ")"),
                new Token("operation", "+"),
                new Token("operation", "-"),
                new Token("operation", "*"),
                new Token("operation", "/"),
                new Token("operation", "%"),
                new Token("attribuition", "="),
                new Token("increment", "++"),
                new Token("decrement", "--"),
                new Token("compare", "<"),
                new Token("compare", ">"),
                new Token("compare", "<="),
                new Token("compare", ">="),
                new Token("compare", "=="),
                new Token("compare", "!="),
                new Token("logic", "&&"),
                new Token("logic", "||"),
                new Token("end", ";"),
                new Token("string", "'"),
                new Token("comma", ","),
                new Token("opening", ":"),
                new Token("comment", "#")
            };
            //-----------------------------------------------------//
            Reserved.words= new List<Token>
            {
                new Token("main", "init"),
                new Token("type", "integer"),
                new Token("type", "decimal"),
                new Token("type", "string"),
                new Token("type", "bool"),
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
