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
        private string name;
        private string type;
        private bool initialized;
        private bool casted;
        private string castType;
        private Token token;
        private string value;
        public string Name { get => this.name; set => this.name = value; }
        public string Type { get => this.type; set => this.type = value; }
        public bool Initialized { get => this.initialized; set => this.initialized = value; }
        public bool Casted { get => this.casted; set => this.casted = value; }
        public string CastType { get => this.castType; set => this.castType = value; }
        public Token Token { get => this.token; set => this.token = value; }
        public string Value { get => this.value; set => this.value = value; }

        public Variable(string name, string type, Token token, bool casted = false, string castType = "", bool initialized = false, string value = "")
        {
            this.name = name;
            this.type = type;
            this.token = token;
            this.casted = casted;
            this.castType = castType;
            this.value = value;
            this.initialized = initialized;
        }
    }
}
