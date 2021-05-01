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
        public List<Error> Errors { get; set; }
        public List<Token> Tokens { get; set; }

        public static int LINE = 0;
        public static int COLUMN = 0;

        public Compiler()
        {
            this.Errors = new List<Error>();
            this.Tokens = new List<Token>();
        }

        public static string Run(string code)
        {
            long start = DateTime.Now.Ticks;
            Compiler com = new Compiler();            
            Reserved.Load();
            string output = string.Empty;
            Lexical lexical = new Lexical(code);
            lexical.Run();
            Compiler.LINE = lexical.row;
            Compiler.COLUMN = lexical.column;
            com.Tokens = lexical.Tokens;
            foreach(Token t in com.Tokens)
                Console.WriteLine(t.ToString());
            com.Errors.AddRange(lexical.Errors);
            Syntactic syntatic = new Syntactic(com.Tokens);
            syntatic.Run();
            com.Errors.AddRange(syntatic.Errors);
            foreach(Error err in com.Errors)
                output += $">> Erro: {err}\n";
            long stop = DateTime.Now.Ticks;
            output = (output == string.Empty) ? ">> Compilado com sucesso!" : output;
            int res = Convert.ToInt32(stop - start);
            output += "\n>> Tempo de compilação: " + (double)res / 10000000 + "s";
            return output;
        }
    }
}
