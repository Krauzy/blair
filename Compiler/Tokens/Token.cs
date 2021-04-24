using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blair.Compiler.Tokens
{
    public class Token
    {

        public string Code { get; set; }
        public string Lexem { get; set; }
        public string Type { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }

        public Token(string token, string lexem, string type = "", int line = 0, int column = 0)
        {
            this.Code = token;
            this.Lexem = lexem;
            this.Lexem = type;
            this.Line = line;
            this.Column = column;
        }

        public override string ToString()
        {
            return "{token: '" + this.Code + "', lexem: '" + this.Lexem + "'}";
        }
    }
}
