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
            long start = DateTime.Now.Ticks;
            Reserved.Load();
            string output = string.Empty;
            Lexical lexical = new Lexical(code);
            lexical.Run();
            foreach(Error err in lexical.Errors)
            {
                output += $"> Erro: {err}";
            }
            foreach(Token t in lexical.Tokens)
            {
                Console.WriteLine(t.ToString());
            }
            long stop = DateTime.Now.Ticks;
            output = (output == string.Empty) ? "> Compilado com sucesso!" : output;
            int res = Convert.ToInt32(stop - start);
            output += "\n> \n> Tempo de compilação: " + (double)res / 10000000 + "s";
            return output;
        }
    }
}
