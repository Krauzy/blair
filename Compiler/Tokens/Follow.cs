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

        public Follow ()
        {
            Main = new List<string> { "}" };
            Var = new List<string> { " ", ";" };
            Declaration = new List<string> { ";" };
            Command = new List<string> { ";", "}" };
            Type = new List<string> { "var" };
            Allocation = new List<string> { ";" };
            Operation = new List<string> { ";" };
            Repetition = new List<string> { "}" };
            If = new List<string> { "}" };
            Else = new List<string> { "}" };
            Loop = new List<string> { "}" };
            While = new List<string> { "}" };
            Codition = new List<string> { ")", ";" };
            Bool_Result = new List<string> { ")", ";" };
            Compare_Symbol = new List<string> { "var", "number", "string", "bool" };
            Compare = new List<string> { ";", ")" };
            Logic_Symbol = new List<string> { "&&", "||" };
            End = new List<string> { ";" };
            Operation_Symbol = new List<string> { "logic" };
            Bool = new List<string> { "bool" };
            String = new List<string> { "'" };
        }
    }
}
