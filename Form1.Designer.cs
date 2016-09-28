namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Button_Edi = new System.Windows.Forms.Button();
            this.Button_Printing = new System.Windows.Forms.Button();
            this.Button_Order = new System.Windows.Forms.Button();
            this.Button_Exit = new System.Windows.Forms.Button();
            this.Button_Scanned_POs = new System.Windows.Forms.Button();
            this.Button_WebForms = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fontN = new System.Windows.Forms.ComboBox();
            this.FontS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FontN2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FontS2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.printer1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.printer2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.printer3 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.servername = new System.Windows.Forms.TextBox();
            this.Button_Quotes = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.AutoPOProcessing = new System.Windows.Forms.CheckBox();
            this.FontS3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.FontN3 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Button_Edi
            // 
            this.Button_Edi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_Edi.BackgroundImage")));
            this.Button_Edi.FlatAppearance.BorderSize = 0;
            this.Button_Edi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Edi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Edi.Location = new System.Drawing.Point(213, 105);
            this.Button_Edi.Name = "Button_Edi";
            this.Button_Edi.Size = new System.Drawing.Size(123, 38);
            this.Button_Edi.TabIndex = 0;
            this.Button_Edi.UseVisualStyleBackColor = true;
            this.Button_Edi.Click += new System.EventHandler(this.Button_Edi_Click);
            // 
            // Button_Printing
            // 
            this.Button_Printing.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_Printing.BackgroundImage")));
            this.Button_Printing.FlatAppearance.BorderSize = 0;
            this.Button_Printing.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Printing.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Printing.Location = new System.Drawing.Point(386, 105);
            this.Button_Printing.Name = "Button_Printing";
            this.Button_Printing.Size = new System.Drawing.Size(123, 38);
            this.Button_Printing.TabIndex = 1;
            this.Button_Printing.UseVisualStyleBackColor = true;
            this.Button_Printing.Click += new System.EventHandler(this.Button_Printing_Click);
            // 
            // Button_Order
            // 
            this.Button_Order.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_Order.BackgroundImage")));
            this.Button_Order.FlatAppearance.BorderSize = 0;
            this.Button_Order.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Order.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Order.Location = new System.Drawing.Point(561, 105);
            this.Button_Order.Name = "Button_Order";
            this.Button_Order.Size = new System.Drawing.Size(123, 38);
            this.Button_Order.TabIndex = 2;
            this.Button_Order.UseVisualStyleBackColor = true;
            this.Button_Order.Click += new System.EventHandler(this.Button_Order_Click);
            // 
            // Button_Exit
            // 
            this.Button_Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_Exit.BackgroundImage")));
            this.Button_Exit.FlatAppearance.BorderSize = 0;
            this.Button_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Exit.Location = new System.Drawing.Point(561, 149);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(123, 38);
            this.Button_Exit.TabIndex = 5;
            this.Button_Exit.UseVisualStyleBackColor = true;
            this.Button_Exit.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Button_Scanned_POs
            // 
            this.Button_Scanned_POs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_Scanned_POs.BackgroundImage")));
            this.Button_Scanned_POs.FlatAppearance.BorderSize = 0;
            this.Button_Scanned_POs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Scanned_POs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Scanned_POs.Location = new System.Drawing.Point(386, 149);
            this.Button_Scanned_POs.Name = "Button_Scanned_POs";
            this.Button_Scanned_POs.Size = new System.Drawing.Size(123, 38);
            this.Button_Scanned_POs.TabIndex = 4;
            this.Button_Scanned_POs.UseVisualStyleBackColor = true;
            this.Button_Scanned_POs.Click += new System.EventHandler(this.Button_Scanned_POs_Click);
            // 
            // Button_WebForms
            // 
            this.Button_WebForms.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_WebForms.BackgroundImage")));
            this.Button_WebForms.FlatAppearance.BorderSize = 0;
            this.Button_WebForms.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_WebForms.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_WebForms.Location = new System.Drawing.Point(213, 149);
            this.Button_WebForms.Name = "Button_WebForms";
            this.Button_WebForms.Size = new System.Drawing.Size(123, 38);
            this.Button_WebForms.TabIndex = 3;
            this.Button_WebForms.UseVisualStyleBackColor = true;
            this.Button_WebForms.Click += new System.EventHandler(this.Button_WebForms_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Login";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(249, 259);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(87, 20);
            this.username.TabIndex = 7;
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(412, 259);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(97, 20);
            this.password.TabIndex = 9;
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Font";
            // 
            // fontN
            // 
            this.fontN.FormattingEnabled = true;
            this.fontN.Items.AddRange(new object[] {
            "test",
            "test2",
            "test3"});
            this.fontN.Location = new System.Drawing.Point(249, 285);
            this.fontN.Name = "fontN";
            this.fontN.Size = new System.Drawing.Size(127, 21);
            this.fontN.TabIndex = 11;
            this.fontN.SelectedIndexChanged += new System.EventHandler(this.fontN_SelectedIndexChanged);
            // 
            // FontS
            // 
            this.FontS.Location = new System.Drawing.Point(249, 312);
            this.FontS.Name = "FontS";
            this.FontS.Size = new System.Drawing.Size(87, 20);
            this.FontS.TabIndex = 13;
            this.FontS.TextChanged += new System.EventHandler(this.FontS_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Font Size";
            // 
            // FontN2
            // 
            this.FontN2.FormattingEnabled = true;
            this.FontN2.Items.AddRange(new object[] {
            "testing",
            "testing2",
            "testing3"});
            this.FontN2.Location = new System.Drawing.Point(249, 338);
            this.FontN2.Name = "FontN2";
            this.FontN2.Size = new System.Drawing.Size(127, 21);
            this.FontN2.TabIndex = 15;
            this.FontN2.SelectedIndexChanged += new System.EventHandler(this.FontN2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Font";
            // 
            // FontS2
            // 
            this.FontS2.Location = new System.Drawing.Point(249, 365);
            this.FontS2.Name = "FontS2";
            this.FontS2.Size = new System.Drawing.Size(87, 20);
            this.FontS2.TabIndex = 17;
            this.FontS2.TextChanged += new System.EventHandler(this.FontS2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(192, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Font Size";
            // 
            // printer1
            // 
            this.printer1.FormattingEnabled = true;
            this.printer1.Location = new System.Drawing.Point(249, 391);
            this.printer1.Name = "printer1";
            this.printer1.Size = new System.Drawing.Size(260, 21);
            this.printer1.TabIndex = 19;
            this.printer1.SelectedIndexChanged += new System.EventHandler(this.printer1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(192, 394);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Printer 1";
            // 
            // printer2
            // 
            this.printer2.FormattingEnabled = true;
            this.printer2.Location = new System.Drawing.Point(249, 418);
            this.printer2.Name = "printer2";
            this.printer2.Size = new System.Drawing.Size(260, 21);
            this.printer2.TabIndex = 21;
            this.printer2.SelectedIndexChanged += new System.EventHandler(this.printer2_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(192, 421);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Printer 2";
            // 
            // printer3
            // 
            this.printer3.FormattingEnabled = true;
            this.printer3.Location = new System.Drawing.Point(249, 445);
            this.printer3.Name = "printer3";
            this.printer3.Size = new System.Drawing.Size(260, 21);
            this.printer3.TabIndex = 23;
            this.printer3.SelectedIndexChanged += new System.EventHandler(this.printer3_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(192, 448);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Printer 3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(517, 448);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Server";
            // 
            // servername
            // 
            this.servername.Location = new System.Drawing.Point(561, 445);
            this.servername.Name = "servername";
            this.servername.Size = new System.Drawing.Size(97, 20);
            this.servername.TabIndex = 25;
            this.servername.TextChanged += new System.EventHandler(this.servername_TextChanged);
            // 
            // Button_Quotes
            // 
            this.Button_Quotes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_Quotes.BackgroundImage")));
            this.Button_Quotes.FlatAppearance.BorderSize = 0;
            this.Button_Quotes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Button_Quotes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Button_Quotes.Location = new System.Drawing.Point(561, 193);
            this.Button_Quotes.Name = "Button_Quotes";
            this.Button_Quotes.Size = new System.Drawing.Size(123, 38);
            this.Button_Quotes.TabIndex = 26;
            this.Button_Quotes.UseVisualStyleBackColor = true;
            this.Button_Quotes.Click += new System.EventHandler(this.Button_Quotes_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 240000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AutoPOProcessing
            // 
            this.AutoPOProcessing.AutoSize = true;
            this.AutoPOProcessing.Location = new System.Drawing.Point(515, 173);
            this.AutoPOProcessing.Name = "AutoPOProcessing";
            this.AutoPOProcessing.Size = new System.Drawing.Size(15, 14);
            this.AutoPOProcessing.TabIndex = 27;
            this.AutoPOProcessing.UseVisualStyleBackColor = true;
            this.AutoPOProcessing.CheckedChanged += new System.EventHandler(this.AutoPOProcessing_CheckedChanged);
            // 
            // FontS3
            // 
            this.FontS3.Location = new System.Drawing.Point(466, 365);
            this.FontS3.Name = "FontS3";
            this.FontS3.Size = new System.Drawing.Size(87, 20);
            this.FontS3.TabIndex = 31;
            this.FontS3.TextChanged += new System.EventHandler(this.FontS3_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(409, 368);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Font Size";
            // 
            // FontN3
            // 
            this.FontN3.FormattingEnabled = true;
            this.FontN3.Items.AddRange(new object[] {
            "testing",
            "testing2",
            "testing3"});
            this.FontN3.Location = new System.Drawing.Point(466, 338);
            this.FontN3.Name = "FontN3";
            this.FontN3.Size = new System.Drawing.Size(127, 21);
            this.FontN3.TabIndex = 29;
            this.FontN3.SelectedIndexChanged += new System.EventHandler(this.FontN3_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(409, 341);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Font";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(213, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 38);
            this.button1.TabIndex = 32;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(386, 193);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 38);
            this.button2.TabIndex = 33;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(655, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "V140.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(730, 501);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FontS3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.FontN3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.AutoPOProcessing);
            this.Controls.Add(this.Button_Quotes);
            this.Controls.Add(this.servername);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.printer3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.printer2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.printer1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.FontS2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FontN2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FontS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fontN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_Exit);
            this.Controls.Add(this.Button_Scanned_POs);
            this.Controls.Add(this.Button_WebForms);
            this.Controls.Add(this.Button_Order);
            this.Controls.Add(this.Button_Printing);
            this.Controls.Add(this.Button_Edi);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Royal Metals";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Edi;
        private System.Windows.Forms.Button Button_Printing;
        private System.Windows.Forms.Button Button_Order;
        private System.Windows.Forms.Button Button_Exit;
        private System.Windows.Forms.Button Button_Scanned_POs;
        private System.Windows.Forms.Button Button_WebForms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox fontN;
        private System.Windows.Forms.TextBox FontS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox FontN2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FontS2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox printer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox printer2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox printer3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox servername;
        private System.Windows.Forms.Button Button_Quotes;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox AutoPOProcessing;
        private System.Windows.Forms.TextBox FontS3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox FontN3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label13;
    }
}

