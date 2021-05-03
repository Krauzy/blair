namespace Blair
{
    partial class Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Head_Pane = new System.Windows.Forms.Panel();
            this.Minimize_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Close_Button = new System.Windows.Forms.Button();
            this.Git_Button = new System.Windows.Forms.Button();
            this.SaveFile_Button = new System.Windows.Forms.Button();
            this.OpenFile_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Run_Button = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Clear_Button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Code_Box = new System.Windows.Forms.RichTextBox();
            this.enumerate_column = new System.Windows.Forms.TextBox();
            this.Output_Label = new System.Windows.Forms.Label();
            this.Scroll_Bar = new System.Windows.Forms.VScrollBar();
            this.Id_Rows_Columns = new System.Windows.Forms.Label();
            this.Head_Pane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Head_Pane
            // 
            this.Head_Pane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(9)))), ((int)(((byte)(108)))));
            this.Head_Pane.Controls.Add(this.Minimize_Button);
            this.Head_Pane.Controls.Add(this.label2);
            this.Head_Pane.Controls.Add(this.Close_Button);
            this.Head_Pane.Controls.Add(this.Git_Button);
            this.Head_Pane.Controls.Add(this.SaveFile_Button);
            this.Head_Pane.Controls.Add(this.OpenFile_Button);
            this.Head_Pane.Controls.Add(this.label1);
            this.Head_Pane.Controls.Add(this.pictureBox1);
            this.Head_Pane.Location = new System.Drawing.Point(0, 0);
            this.Head_Pane.Name = "Head_Pane";
            this.Head_Pane.Size = new System.Drawing.Size(1022, 85);
            this.Head_Pane.TabIndex = 0;
            this.Head_Pane.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Head_Pane_MouseDown);
            this.Head_Pane.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Head_Pane_MouseMove);
            this.Head_Pane.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Head_Pane_MouseUp);
            // 
            // Minimize_Button
            // 
            this.Minimize_Button.FlatAppearance.BorderSize = 0;
            this.Minimize_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimize_Button.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Minimize_Button.ForeColor = System.Drawing.Color.White;
            this.Minimize_Button.Location = new System.Drawing.Point(905, 0);
            this.Minimize_Button.Name = "Minimize_Button";
            this.Minimize_Button.Size = new System.Drawing.Size(57, 33);
            this.Minimize_Button.TabIndex = 7;
            this.Minimize_Button.Text = "—";
            this.Minimize_Button.UseVisualStyleBackColor = true;
            this.Minimize_Button.Click += new System.EventHandler(this.Minimize_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Chiller", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(117, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "The Magic of Code";
            // 
            // Close_Button
            // 
            this.Close_Button.FlatAppearance.BorderSize = 0;
            this.Close_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_Button.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_Button.ForeColor = System.Drawing.Color.White;
            this.Close_Button.Location = new System.Drawing.Point(965, 0);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(57, 33);
            this.Close_Button.TabIndex = 5;
            this.Close_Button.Text = "✕";
            this.Close_Button.UseVisualStyleBackColor = true;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // Git_Button
            // 
            this.Git_Button.BackgroundImage = global::Blair.Properties.Resources.git_white;
            this.Git_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Git_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Git_Button.FlatAppearance.BorderSize = 0;
            this.Git_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Git_Button.ForeColor = System.Drawing.Color.White;
            this.Git_Button.Location = new System.Drawing.Point(857, 25);
            this.Git_Button.Name = "Git_Button";
            this.Git_Button.Size = new System.Drawing.Size(32, 32);
            this.Git_Button.TabIndex = 4;
            this.Git_Button.UseVisualStyleBackColor = false;
            this.Git_Button.Click += new System.EventHandler(this.Git_Button_Click);
            this.Git_Button.MouseEnter += new System.EventHandler(this.Op_Buttons_Mouse_Enter);
            this.Git_Button.MouseLeave += new System.EventHandler(this.Op_Buttons_Mouse_Leave);
            // 
            // SaveFile_Button
            // 
            this.SaveFile_Button.BackColor = System.Drawing.Color.Transparent;
            this.SaveFile_Button.BackgroundImage = global::Blair.Properties.Resources.save_white;
            this.SaveFile_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveFile_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveFile_Button.FlatAppearance.BorderSize = 0;
            this.SaveFile_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveFile_Button.ForeColor = System.Drawing.Color.White;
            this.SaveFile_Button.Location = new System.Drawing.Point(810, 25);
            this.SaveFile_Button.Name = "SaveFile_Button";
            this.SaveFile_Button.Size = new System.Drawing.Size(32, 32);
            this.SaveFile_Button.TabIndex = 3;
            this.SaveFile_Button.UseVisualStyleBackColor = false;
            this.SaveFile_Button.Click += new System.EventHandler(this.SaveFile_Button_Click);
            this.SaveFile_Button.MouseEnter += new System.EventHandler(this.Op_Buttons_Mouse_Enter);
            this.SaveFile_Button.MouseLeave += new System.EventHandler(this.Op_Buttons_Mouse_Leave);
            // 
            // OpenFile_Button
            // 
            this.OpenFile_Button.BackgroundImage = global::Blair.Properties.Resources.open_white;
            this.OpenFile_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenFile_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenFile_Button.FlatAppearance.BorderSize = 0;
            this.OpenFile_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenFile_Button.ForeColor = System.Drawing.Color.White;
            this.OpenFile_Button.Location = new System.Drawing.Point(761, 25);
            this.OpenFile_Button.Name = "OpenFile_Button";
            this.OpenFile_Button.Size = new System.Drawing.Size(32, 32);
            this.OpenFile_Button.TabIndex = 2;
            this.OpenFile_Button.UseVisualStyleBackColor = false;
            this.OpenFile_Button.Click += new System.EventHandler(this.OpenFile_Button_Click);
            this.OpenFile_Button.MouseEnter += new System.EventHandler(this.Op_Buttons_Mouse_Enter);
            this.OpenFile_Button.MouseLeave += new System.EventHandler(this.Op_Buttons_Mouse_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(113, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "B L A I R";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Blair.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(42, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 300F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(510, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 455);
            this.label3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.Run_Button);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(511, 50);
            this.panel2.TabIndex = 2;
            // 
            // Run_Button
            // 
            this.Run_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(9)))), ((int)(((byte)(108)))));
            this.Run_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Run_Button.FlatAppearance.BorderSize = 0;
            this.Run_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Run_Button.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Run_Button.ForeColor = System.Drawing.Color.White;
            this.Run_Button.Location = new System.Drawing.Point(449, 10);
            this.Run_Button.Name = "Run_Button";
            this.Run_Button.Size = new System.Drawing.Size(50, 30);
            this.Run_Button.TabIndex = 6;
            this.Run_Button.Text = "RUN";
            this.Run_Button.UseVisualStyleBackColor = false;
            this.Run_Button.Click += new System.EventHandler(this.Run_Button_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(104, 50);
            this.panel4.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(14, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "main.bla";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(-2, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(517, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "_________________________________________________________________________________" +
    "____";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(9)))), ((int)(((byte)(108)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(110, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.Clear_Button);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(511, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(511, 50);
            this.panel3.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(17, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Output";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::Blair.Properties.Resources.key_purple;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(404, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(19, 19);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // Clear_Button
            // 
            this.Clear_Button.BackColor = System.Drawing.Color.White;
            this.Clear_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Clear_Button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(9)))), ((int)(((byte)(108)))));
            this.Clear_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear_Button.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(9)))), ((int)(((byte)(108)))));
            this.Clear_Button.Location = new System.Drawing.Point(438, 10);
            this.Clear_Button.Name = "Clear_Button";
            this.Clear_Button.Size = new System.Drawing.Size(61, 30);
            this.Clear_Button.TabIndex = 7;
            this.Clear_Button.Text = "CLEAR";
            this.Clear_Button.UseVisualStyleBackColor = false;
            this.Clear_Button.Click += new System.EventHandler(this.Clear_Button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-3, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(523, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "_________________________________________________________________________________" +
    "_____";
            // 
            // Code_Box
            // 
            this.Code_Box.AcceptsTab = true;
            this.Code_Box.AutoWordSelection = true;
            this.Code_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.Code_Box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Code_Box.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Code_Box.Location = new System.Drawing.Point(32, 134);
            this.Code_Box.Name = "Code_Box";
            this.Code_Box.Size = new System.Drawing.Size(478, 404);
            this.Code_Box.TabIndex = 4;
            this.Code_Box.Text = "";
            this.Code_Box.Click += new System.EventHandler(this.Code_Box_Click);
            this.Code_Box.TextChanged += new System.EventHandler(this.Code_Box_TextChanged);
            this.Code_Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Code_Box_KeyDown);
            this.Code_Box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Code_Box_KeyPress);
            this.Code_Box.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Code_Box_KeyUp);
            // 
            // enumerate_column
            // 
            this.enumerate_column.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.enumerate_column.Enabled = false;
            this.enumerate_column.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enumerate_column.Location = new System.Drawing.Point(-7, 131);
            this.enumerate_column.Multiline = true;
            this.enumerate_column.Name = "enumerate_column";
            this.enumerate_column.ReadOnly = true;
            this.enumerate_column.Size = new System.Drawing.Size(41, 409);
            this.enumerate_column.TabIndex = 5;
            this.enumerate_column.Text = "0 ";
            this.enumerate_column.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Output_Label
            // 
            this.Output_Label.AutoSize = true;
            this.Output_Label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Output_Label.Location = new System.Drawing.Point(513, 136);
            this.Output_Label.Name = "Output_Label";
            this.Output_Label.Size = new System.Drawing.Size(21, 15);
            this.Output_Label.TabIndex = 6;
            this.Output_Label.Text = ">>";
            // 
            // Scroll_Bar
            // 
            this.Scroll_Bar.LargeChange = 1;
            this.Scroll_Bar.Location = new System.Drawing.Point(1002, 134);
            this.Scroll_Bar.Maximum = 1;
            this.Scroll_Bar.Name = "Scroll_Bar";
            this.Scroll_Bar.Size = new System.Drawing.Size(19, 404);
            this.Scroll_Bar.TabIndex = 8;
            this.Scroll_Bar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Scroll_Bar_Scroll);
            // 
            // Id_Rows_Columns
            // 
            this.Id_Rows_Columns.AutoSize = true;
            this.Id_Rows_Columns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.Id_Rows_Columns.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Id_Rows_Columns.Location = new System.Drawing.Point(6, 521);
            this.Id_Rows_Columns.Name = "Id_Rows_Columns";
            this.Id_Rows_Columns.Size = new System.Drawing.Size(112, 15);
            this.Id_Rows_Columns.TabIndex = 9;
            this.Id_Rows_Columns.Text = "Linha: 0 | Coluna: 0";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1022, 538);
            this.Controls.Add(this.Id_Rows_Columns);
            this.Controls.Add(this.Scroll_Bar);
            this.Controls.Add(this.Code_Box);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Head_Pane);
            this.Controls.Add(this.enumerate_column);
            this.Controls.Add(this.Output_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blair - The Magic of Code";
            this.Head_Pane.ResumeLayout(false);
            this.Head_Pane.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Head_Pane;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OpenFile_Button;
        private System.Windows.Forms.Button Git_Button;
        private System.Windows.Forms.Button SaveFile_Button;
        private System.Windows.Forms.Button Close_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox Code_Box;
        private System.Windows.Forms.TextBox enumerate_column;
        private System.Windows.Forms.Button Run_Button;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Clear_Button;
        private System.Windows.Forms.Label Output_Label;
        private System.Windows.Forms.Button Minimize_Button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.VScrollBar Scroll_Bar;
        private System.Windows.Forms.Label Id_Rows_Columns;
    }
}

