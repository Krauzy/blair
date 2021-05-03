using Blair.Properties;
using Blair.Compiler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blair.Compiler.Util;
using System.Threading;

namespace Blair
{
    public partial class Main : Form
    {
        private int lines = 0;
        //
        private bool move = false;
        private Point mouse;
        private string PATH = string.Empty;
        private int fixed_y_label = 126;
        //
        private string code1 = "init: {\n" +
            "\tinteger: a, b, i;\n" +
            "\tdecimal: x;\n" +
            "\tstring: z;\n" +
            "\ta = 1;\n" +
            "\tb = 2;\n" +
            "\tz = a + b;\n" +
            "\tx = 'Hello World!';\n" +
            "\n" +
            "\tif (a > b): {\n" +
            "\t\tz++;\n" +
            "\t}\n" +
            "\telse: {\n" +
            "\t\twhile(z > -10 && z < 10): {\n" +
            "\t\t\tz--;\n" +
            "\t\t}\n" +
            "\t}\n" +
            "\n" +
            "\tloop(i = 0; i < z; i++): {\n" +
            "\t\ta = a + i;\n" +
            "\t}\n" +
            "}\n";
        public Main()
        {
            InitializeComponent();
            this.ActiveControl = Code_Box;
            /*Code_Box.Text = "init:{\n" +
                "\tinteger: a;\n" +
                "\ta = 0;\n" +
                "\twhile (a < 10): {\n" +
                "\t\ta++;\n" +
                "\t}\n" +
                "}";*/
            Code_Box.Text = code1;
            Code_Box_TextChanged(Code_Box, null);
            Scroll_Bar.Visible = false;
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Close();
        }

        private void Op_Buttons_Mouse_Enter(object sender, EventArgs e)
        {
            switch(((Button)sender).Name)
            {
                case "OpenFile_Button":
                    OpenFile_Button.BackColor = Color.White;
                    OpenFile_Button.BackgroundImage = Resources.open_purple;
                    break;

                case "SaveFile_Button":
                    SaveFile_Button.BackColor = Color.White;
                    SaveFile_Button.BackgroundImage = Resources.save_purple;
                    break;

                default:
                    Git_Button.BackColor = Color.White;
                    Git_Button.BackgroundImage = Resources.git_purple;
                    break;
            }
        }

        private void Op_Buttons_Mouse_Leave(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "OpenFile_Button":
                    OpenFile_Button.BackColor = Color.FromArgb(60, 9, 108);
                    OpenFile_Button.BackgroundImage = Resources.open_white;
                    break;

                case "SaveFile_Button":
                    SaveFile_Button.BackColor = Color.FromArgb(60, 9, 108);
                    SaveFile_Button.BackgroundImage = Resources.save_white;
                    break;

                default:
                    Git_Button.BackColor = Color.FromArgb(60, 9, 108);
                    Git_Button.BackgroundImage = Resources.git_white;
                    break;
            }
        }

        private int Get_Lines(string text)
        {
            return text.Split('\n').Length;
        }

        private void Code_Box_TextChanged(object sender, EventArgs e)
        {
            this.lines = Get_Lines(Code_Box.Text);
            enumerate_column.Text = "";
            for (int i = 0; i < this.lines; i++)
                enumerate_column.Text += i + " \r\n";

            string[] words = { "while", "init", "if", "loop", "else", "true", "false" };
            string[] types = { "integer", "decimal", "string", "bool"};
            string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "." };
            string[] symbol = { ":", "&&", "||", "!", "+", "-", "/", "%", "=", "<", ">" };

            Run_String_Code_Box();
            this.Check_Keyword(words, Color.FromArgb(60, 9, 108));
            this.Check_Keyword(types, Color.DarkGoldenrod);
            this.Check_Keyword(numbers, Color.OliveDrab);
            this.Check_Keyword(symbol, Color.FromArgb(217, 4, 41));
            Run_Comment_Code_Box();
        }

        private void Check_Keyword(string[] words, Color color, int start = 0)
        {
            foreach(string word in words)
            {
                if (this.Code_Box.Text.Contains(word))
                {
                    int index = -1;
                    int select = this.Code_Box.SelectionStart;
                    while ((index = this.Code_Box.Text.IndexOf(word, (index + 1))) != -1)
                    {
                        this.Code_Box.Select((index + start), word.Length);
                        this.Code_Box.SelectionColor = color;
                        this.Code_Box.Select(select, 0);
                        this.Code_Box.SelectionColor = Color.Black;
                    }
                }
            }
        }

        private void Run_String_Code_Box()
        {
            int start_state = Code_Box.SelectionStart;
            bool tilde = false;
            for (int i = 0; i < Code_Box.Text.Length; i++)
            {
                Code_Box.Select(i, 1);
                Code_Box.SelectionColor = (tilde) ? Color.Brown : Color.Black;
                if (Code_Box.Text[i] == '\'')
                {
                    Code_Box.Select(i, 1);
                    Code_Box.SelectionColor = Color.Brown;
                    tilde = !tilde;
                }
            }
            Code_Box.SelectionStart = start_state;
        }

        private void Run_Comment_Code_Box()
        {
            int start_index = Code_Box.SelectionStart;
            int len = 0;
            foreach(string l in Code_Box.Text.Split('\n'))
            {
                if(l.Contains("#"))
                {
                    Code_Box.Select(len + l.IndexOf('#') + 1, l.Split('#')[1].Length + 1);
                    Code_Box.SelectionColor = Color.Gray;
                    Code_Box.SelectionStart = start_index;
                    Code_Box.SelectionLength = 0;
                    Code_Box.SelectionColor = Color.Black;
                }
                len += l.Length;
            }
        }

        private void Code_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && this.Get_Lines(Code_Box.Text) == 26)
            {
                e.Handled = true;
            }


            /*if (e.KeyData == Keys.Tab)
            {
                int start = Code_Box.SelectionStart;
                string pt1 = this.Code_Box.Text.Substring(0, start);
                string pt2 = this.Code_Box.Text.Substring(start);
                this.Code_Box.Text = pt1 + "    " + pt2;
                e.Handled = true;
            }*/
        }

        private void AutoCloseSymbols(char open, char close)
        {
            string pack = open.ToString() + close.ToString();
            int start = Code_Box.SelectionStart;
            string pt1 = this.Code_Box.Text.Substring(0, start);
            string pt2 = this.Code_Box.Text.Substring(start);
            this.Code_Box.Text = pt1 + pack + pt2;
            this.Code_Box.SelectionStart = start + 1;
            this.Code_Box.SelectionLength = 0;
        }

        private void Code_Box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '{')
            {
                AutoCloseSymbols('{', '}');
                e.Handled = true;
            }
            if (e.KeyChar == '(')
            {
                AutoCloseSymbols('(', ')');
                e.Handled = true;
            }
            if (e.KeyChar == '[')
            {
                AutoCloseSymbols('[', ']');
                e.Handled = true;
            }
        }

        private void Head_Pane_MouseDown(object sender, MouseEventArgs e)
        {
            this.move = true;
            mouse = new Point(e.X, e.Y);
        }

        private void Head_Pane_MouseUp(object sender, MouseEventArgs e)
        {
            this.move = false;
        }

        private void Head_Pane_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.move)
                this.Location = new Point(this.Location.X + (e.X - mouse.X), this.Location.Y + (e.Y - mouse.Y));
        }

        private void Git_Button_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Krauzy/blair");
            this.ActiveControl = null;
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            Output_Label.Text = ">";
            this.ActiveControl = null;
        }

        private void Minimize_Button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ActiveControl = null;
        }

        private void Run_Button_Click(object sender, EventArgs e)
        {
            Output_Label.Text = Compiler.Compiler.Run(Code_Box.Text.Replace("\t", string.Empty));
            int rows = Get_Lines(Output_Label.Text);
            if (rows <= 26)
                Scroll_Bar.Visible = false;
            else
            {
                Scroll_Bar.Visible = true;
                Scroll_Bar.Maximum = rows - 26;
            }
            this.ActiveControl = null;
        }

        private void OpenFile_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Title = "Abrir Arquivo",
                InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                Filter = "Arquivos BLAIR (*.bla)|*.bla|Todos os arquivos (*.*)|*.*",
                RestoreDirectory = true
            };

            if(open.ShowDialog() == DialogResult.OK)
            {
                this.PATH = open.FileName;
                string code = null;
                Thread t = new Thread(() =>
                {
                    code = Files.Read(PATH);                    
                });
                t.Start();
                t.Join();
                Code_Box.Text = code;
                Code_Box_TextChanged(Code_Box, null);
            }
        }

        private void Scroll_Bar_Scroll(object sender, ScrollEventArgs e)
        {
            int y = fixed_y_label;
            for (int i = 0; i < e.NewValue; i++)
            {
                y -= 20;
            }
            if (e.NewValue == 0)
                y = fixed_y_label + 10;
            Output_Label.Location = new Point(Output_Label.Location.X, y);
        }

        private void SaveFile_Button_Click(object sender, EventArgs e)
        {
            if (PATH == string.Empty)
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    Title = "Salvar Arquivo",
                    DefaultExt = "bla",
                    Filter = "Arquivos BLAIR (*.bla)|*.bla|Todos os arquivos (*.*)|*.*",
                    InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                    RestoreDirectory = true
                };

                if(save.ShowDialog() == DialogResult.OK)
                {
                    this.PATH = save.FileName;
                    Files.Write(PATH, Code_Box.Text);
                }
            }
            else
            {
                Files.Write(PATH, Code_Box.Text);
            }
        }

        private void Code_Box_Click(object sender, EventArgs e)
        {
            int pos = Code_Box.SelectionStart;
            int row = Code_Box.GetLineFromCharIndex(pos);
            int col = pos - Code_Box.GetFirstCharIndexOfCurrentLine();
            if (Code_Box.SelectionLength > 0)
                Id_Rows_Columns.Text = $"Linha: {row} | Coluna: {col} | Seleção: {Code_Box.SelectionLength}";
            else
                Id_Rows_Columns.Text = $"Linha: {row} | Coluna: {col}";
        }

        private void Code_Box_KeyUp(object sender, KeyEventArgs e)
        {
            int pos = Code_Box.SelectionStart;
            int row = Code_Box.GetLineFromCharIndex(pos);
            int col = pos - Code_Box.GetFirstCharIndexOfCurrentLine();
            if (Code_Box.SelectionLength > 0)
                Id_Rows_Columns.Text = $"Linha: {row} | Coluna: {col} | Seleção: {Code_Box.SelectionLength}";
            else
                Id_Rows_Columns.Text = $"Linha: {row} | Coluna: {col}";
        }
    }
}
