using Blair.Compiler.Tokens;
using Blair.Compiler.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blair.Compiler.Run
{
    public class Semantic
    {
        public static Semantic semantic;

        public List<Variable> variables;
        public List<Error> errors;
        
        public Semantic ()
        {
            this.variables = new List<Variable>();
            this.errors = new List<Error>();
        }

        public void AddVariable(string name, string type, Token token)
        {
            if (!isVariable(name))
                this.variables.Add(new Variable(name, type, token));
            else
                this.errors.Add(new Error($"Variável '{name}' já existente!", token.Line, token.Column));
        }

        public void CheckCompare(object x, object y, int l, int c)
        {
            string f1 = x.GetType().ToString();
            string f2 = y.GetType().ToString();

            if (x.GetType() == typeof(Variable))
            {
                f1 = ((Variable)x).Type;
            }

            if (y.GetType() == typeof(Variable))
            {
                f2 = ((Variable)y).Type;
            }

            if ((f1 == "string" && (f2 == "integer" || f2 == "decimal")) || (f2 == "string" && (f1 == "integer" || f1 == "decimal")))
                semantic.errors.Add(new Error($"Não é possível comparar '{f1}' em '{f2}'", l, c));
            if ((f1 == "boolean" && f2 != "boolean") || (f2 == "boolean" && f1 != "boolean"))
                semantic.errors.Add(new Error($"Não é possível comparar '{f1}' em '{f2}'", l, c));

        }

        public bool isVariable (string name)
        {
            return this.GetVariable(name) != null;
        }

        public Variable GetVariable (string name)
        {
            foreach (Variable var in this.variables)
                if (var.Name == name)
                    return var;
            return null;
        }
    }

    public class Variable
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Initialized { get; set; }
        public Token Token { get; set; }
        public string TextValue { get; set; }
        public double NumericValue { get; set; }

        public string OpText { get; set; }

        public Variable(string name, string type, Token token, bool initialized = default, string text = default, double num = default)
        {
            this.Name = name;
            this.Type = type;
            this.Token = token;
            this.TextValue = text;
            this.NumericValue = num;
            this.Initialized = initialized;
        }
    }
}
