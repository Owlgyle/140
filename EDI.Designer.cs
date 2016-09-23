namespace WindowsFormsApplication1
{
    partial class EDI
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EDIIN = new System.Windows.Forms.TextBox();
            this.EDIServer = new System.Windows.Forms.TextBox();
            this.EDIOut = new System.Windows.Forms.TextBox();
            this.curDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.OrderNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Text1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "EDI Import Location";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "EDI Import Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "EDI Export Location";
            // 
            // EDIIN
            // 
            this.EDIIN.Location = new System.Drawing.Point(119, 12);
            this.EDIIN.Name = "EDIIN";
            this.EDIIN.Size = new System.Drawing.Size(218, 20);
            this.EDIIN.TabIndex = 3;
            this.EDIIN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EDIIN_KeyUp);
            // 
            // EDIServer
            // 
            this.EDIServer.Location = new System.Drawing.Point(119, 38);
            this.EDIServer.Name = "EDIServer";
            this.EDIServer.Size = new System.Drawing.Size(218, 20);
            this.EDIServer.TabIndex = 4;
            this.EDIServer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EDIServer_KeyUp);
            // 
            // EDIOut
            // 
            this.EDIOut.Location = new System.Drawing.Point(119, 64);
            this.EDIOut.Name = "EDIOut";
            this.EDIOut.Size = new System.Drawing.Size(218, 20);
            this.EDIOut.TabIndex = 5;
            this.EDIOut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EDIOut_KeyUp);
            // 
            // curDate
            // 
            this.curDate.Location = new System.Drawing.Point(48, 105);
            this.curDate.Name = "curDate";
            this.curDate.Size = new System.Drawing.Size(77, 20);
            this.curDate.TabIndex = 7;
            this.curDate.TextChanged += new System.EventHandler(this.curDate_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date";
            // 
            // OrderNum
            // 
            this.OrderNum.Location = new System.Drawing.Point(230, 105);
            this.OrderNum.Name = "OrderNum";
            this.OrderNum.Size = new System.Drawing.Size(77, 20);
            this.OrderNum.TabIndex = 9;
            this.OrderNum.TextChanged += new System.EventHandler(this.OrderNum_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Order Number";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 26);
            this.button1.TabIndex = 10;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(355, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 26);
            this.button2.TabIndex = 11;
            this.button2.Text = "Export";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(516, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 26);
            this.button3.TabIndex = 13;
            this.button3.Text = "ASN";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(516, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 26);
            this.button4.TabIndex = 12;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Text1
            // 
            this.Text1.Location = new System.Drawing.Point(20, 148);
            this.Text1.Multiline = true;
            this.Text1.Name = "Text1";
            this.Text1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Text1.Size = new System.Drawing.Size(600, 213);
            this.Text1.TabIndex = 14;
            // 
            // EDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 373);
            this.Controls.Add(this.Text1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OrderNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.curDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EDIOut);
            this.Controls.Add(this.EDIServer);
            this.Controls.Add(this.EDIIN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EDI";
            this.Text = "Royal Metal Products";
            this.Load += new System.EventHandler(this.EDI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EDIIN;
        private System.Windows.Forms.TextBox EDIServer;
        private System.Windows.Forms.TextBox EDIOut;
        private System.Windows.Forms.TextBox curDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox OrderNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox Text1;
    }
}