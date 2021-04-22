using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blair.Compiler.Tokens
{
    public class Token
    {
        private string code;
        private string lexem;
        private string type;

        public string Code { get => this.code; set => this.code = value; }
        public string Lexem { get => this.lexem; set => this.lexem = value; }
        public string Type { get => this.type; set => this.type = value; }

        public Token (string token, string lexem, string type = "")
        {
            this.code = token;
            this.lexem = lexem;
            this.type = type;
        }

        public override string ToString()
        {
            return "{token: '" + this.code + "', lexem: '" + this.lexem + "'}";
        }
    }
}
