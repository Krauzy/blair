using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blair.Compiler.Tokens
{
    public class First
    {
        public List<string> Main { get; set; }
        public List<string> Var { get; set; }
        public List<string> Declaration { get; set; }
        public List<string> Command { get; set; }
        public List<string> Allocation { get; set; }
        public List<string> Type { get; set; }
        public List<string> Operation { get; set; }
        public List<string> Repetition { get; set; }
        public List<string> If { get; set; }
        public List<string> Else { get; set; }
        public List<string> Loop { get; set; }
        public List<string> While { get; set; }
        public List<string> Codition { get; set; }
        public List<string> Bool_Result { get; set; }
        public List<string> Compare_Symbol { get; set; }
        public List<string> Compare { get; set; }
        public List<string> Logic_Symbol { get; set; }
        public List<string> End { get; set; }
        public List<string> Operation_Symbol { get; set; }
        public List<string> Bool { get; set; }
        public List<string> String { get; set; }

        public First ()
        {
            Main = new List<string> { "main" };
            Var = new List<string> { "var" };
            Declaration = new List<string> { "type" };
            Command = new List<string> { "var", "if", "while", "loop" };
            Type = new List<string> { "int", "decimal", "string", "bool" };
            Allocation = new List<string> { "var" };
            Operation = new List<string> { "var", "number" };
            Repetition = new List<string> { "loop", "while" };
            If = new List<string> { "if" };
            Else = new List<string> { "else" };
            Loop = new List<string> { "loop" };
            While = new List<string> { "while" };
            Codition = new List<string> { "!", "var", "number", "bool", "string" };
            Bool_Result = new List<string> { "!", "var", "bool", "number", "string"};
            Compare_Symbol = new List<string> { "compare" };
            Compare = new List<string> { "var", "number", "bool", "string" };
            Logic_Symbol = new List<string> { "&&", "||" };
            End = new List<string> { ";" };
            Operation_Symbol = new List<string> { "logic" };
            Bool = new List<string> { "bool" };
            String = new List<string> { "'" };
        }
    }
}
