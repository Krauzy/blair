using Blair.Compiler.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blair
{
    public partial class TokenView : Form
    {
        private Label _ref;
        private Point last;
        
        public TokenView()
        {
            InitializeComponent();
            _ref = new Label();
            _ref.Text = label1.Text;
            _ref.Location = label1.Location;
            _ref.Font = label1.Font;
            _ref.Visible = false;
        }

        private Label GetLabel(string text)
        {
            Label lab = new Label();
            lab.Text = text;
            lab.Location = _ref.Location;
            lab.Font = _ref.Font;
            //_ref.Visible = false;
            return lab;
        }

        public void Load(List<Token> tokens, string code)
        {

        }
    }
}
