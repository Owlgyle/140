namespace WindowsFormsApplication1
{
    partial class Fax
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
            this.conf_fax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.conf_email = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.conf_contact = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.conf_notes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // conf_fax
            // 
            this.conf_fax.Location = new System.Drawing.Point(84, 6);
            this.conf_fax.Name = "conf_fax";
            this.conf_fax.Size = new System.Drawing.Size(137, 20);
            this.conf_fax.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fax #";
            // 
            // conf_email
            // 
            this.conf_email.Location = new System.Drawing.Point(84, 32);
            this.conf_email.Name = "conf_email";
            this.conf_email.Size = new System.Drawing.Size(137, 20);
            this.conf_email.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "E-mail";
            // 
            // conf_contact
            // 
            this.conf_contact.Location = new System.Drawing.Point(84, 58);
            this.conf_contact.Name = "conf_contact";
            this.conf_contact.Size = new System.Drawing.Size(137, 20);
            this.conf_contact.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Contact";
            // 
            // conf_notes
            // 
            this.conf_notes.Location = new System.Drawing.Point(12, 103);
            this.conf_notes.Multiline = true;
            this.conf_notes.Name = "conf_notes";
            this.conf_notes.Size = new System.Drawing.Size(410, 104);
            this.conf_notes.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Notes:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 219);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 25);
            this.button1.TabIndex = 9;
            this.button1.Text = "Send Now";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(313, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 25);
            this.button2.TabIndex = 10;
            this.button2.Text = "Send Later";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Fax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 256);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.conf_notes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.conf_contact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.conf_email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.conf_fax);
            this.Controls.Add(this.label1);
            this.Name = "Fax";
            this.Text = "Royal Metal Products";
            this.Load += new System.EventHandler(this.Fax_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox conf_fax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox conf_email;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox conf_contact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox conf_notes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}