using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blair.Compiler.Triggers
{
    public class Error
    {
        private string message;
        private int line;
        private int column;

        public string Message { get => this.message; set => this.message = value; }
        public int Line { get => this.line; set => this.line = value; }
        public int Column { get => this.column; set => this.column = value; }

        public Error (string message, int line, int column)
        {
            this.Message = message;
            this.Line = line;
            this.Column = column;
        }

        public override string ToString()
        {
            return $"ERROR: {this.message} ({this.line}, {this.column})";
        }
    }
}
