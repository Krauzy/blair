using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blair.Compiler.Tokens
{
    public class Follow
    {
        public List<string> Main { get; set; }
        public List<string> Var { get; set; }
        public List<string> Declaration { get; set; }
        public List<string> Command { get; set; }
        public List<string> Allocation { get; set; }
        public List<string> Type { get; set; }
        public List<string> Operation { get; set; }
        public List<string> Result { get; set; }
        public List<string> If { get; set; }
        public List<string> Else { get; set; }
        public List<string> Loop { get; set; }
        public List<string> While { get; set; }
        public List<string> Codition { get; set; }
        public List<string> Compare_Symbol { get; set; }
        public List<string> Compare { get; set; }
        public List<string> Logic_Symbol { get; set; }
        public List<string> End { get; set; }
        public List<string> Operation_Symbol { get; set; }
        public List<string> Bool { get; set; }
        public List<string> String { get; set; }

        public Follow ()
        {
            Main = new List<string> { "close-bracket" };
            Var = new List<string> { "end" };
            Declaration = new List<string> { "end" };
            Command = new List<string> { "end", "close-bracket" };
            Type = new List<string> { "var" };
            Allocation = new List<string> { "end" };
            Operation = new List<string> { "end" };
            If = new List<string> { "close-bracket" };
            Else = new List<string> { "close-bracket" };
            Loop = new List<string> { "close-bracket" };
            While = new List<string> { "close-bracket" };
            Codition = new List<string> { "close-parenthesis", "end" };
            Result = new List<string> { "close-parenthesis", "end" };
            Compare_Symbol = new List<string> { "var", "number", "string", "bool" };
            Compare = new List<string> { "end", "close-parenthesis", "logic" };
            Logic_Symbol = new List<string>();
            End = new List<string> ();
            Operation_Symbol = new List<string>();
            Bool = new List<string>();
            String = new List<string> { "quote" };
        }
    }
}
