using Blair.Compiler.Run;
using Blair.Compiler.Tokens;
using Blair.Compiler.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blair.Compiler
{
    public class Compiler
    {
        public static string Run(string code)
        {
            Reserved.Load();
            string output = string.Empty;
            Lexical lexical = new Lexical(code);
            lexical.Run();
            foreach(Error err in lexical.Errors)
            {
                output += $"> Erro: {err}\n";
            }
            foreach(Token t in lexical.Tokens)
            {
                Console.WriteLine(t.ToString());
            }
            return output;
        }
    }
}
