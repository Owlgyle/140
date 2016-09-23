namespace WindowsFormsApplication1
{
    partial class PrintingBox
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
            this.invoiceNum = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.orderNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.quoteID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice Number";
            // 
            // invoiceNum
            // 
            this.invoiceNum.Location = new System.Drawing.Point(106, 16);
            this.invoiceNum.Name = "invoiceNum";
            this.invoiceNum.Size = new System.Drawing.Size(124, 20);
            this.invoiceNum.TabIndex = 1;
            this.invoiceNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.invoiceNum_KeyUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Print Invoice";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(236, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 27);
            this.button2.TabIndex = 5;
            this.button2.Text = "Print Order";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // orderNum
            // 
            this.orderNum.Location = new System.Drawing.Point(106, 49);
            this.orderNum.Name = "orderNum";
            this.orderNum.Size = new System.Drawing.Size(124, 20);
            this.orderNum.TabIndex = 4;
            this.orderNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.orderNum_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Order Number";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(236, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 27);
            this.button3.TabIndex = 8;
            this.button3.Text = "Print Quote";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // quoteID
            // 
            this.quoteID.Location = new System.Drawing.Point(106, 82);
            this.quoteID.Name = "quoteID";
            this.quoteID.Size = new System.Drawing.Size(124, 20);
            this.quoteID.TabIndex = 7;
            this.quoteID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.quoteID_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Quote ID";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(378, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 27);
            this.button4.TabIndex = 9;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // PrintingBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 123);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.quoteID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.orderNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.invoiceNum);
            this.Controls.Add(this.label1);
            this.Name = "PrintingBox";
            this.Text = "Royal Metal Products";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox invoiceNum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox orderNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox quoteID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
    }
}