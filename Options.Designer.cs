namespace WindowsFormsApplication1
{
    partial class Options
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.waitTimePerPage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.minWaitTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.schedulingTemplatePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fontSizeBarcode2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fontBarcode2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fontSizeBarcode1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.fontBarcode1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Labels = new System.Windows.Forms.TabPage();
            this.printer3 = new System.Windows.Forms.ComboBox();
            this.printer2Label = new System.Windows.Forms.Label();
            this.printer2 = new System.Windows.Forms.ComboBox();
            this.printer1Label = new System.Windows.Forms.Label();
            this.printer1 = new System.Windows.Forms.ComboBox();
            this.printer0Label = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.contractEmailList = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contractPath = new System.Windows.Forms.TextBox();
            this.contractImport = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.Labels.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.Labels);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(492, 249);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.contractPath);
            this.tabPage1.Controls.Add(this.contractImport);
            this.tabPage1.Controls.Add(this.waitTimePerPage);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.minWaitTime);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.schedulingTemplatePath);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(484, 223);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Directories";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // waitTimePerPage
            // 
            this.waitTimePerPage.Location = new System.Drawing.Point(344, 35);
            this.waitTimePerPage.Name = "waitTimePerPage";
            this.waitTimePerPage.Size = new System.Drawing.Size(63, 20);
            this.waitTimePerPage.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(230, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Wait Time Per Page";
            // 
            // minWaitTime
            // 
            this.minWaitTime.Location = new System.Drawing.Point(120, 35);
            this.minWaitTime.Name = "minWaitTime";
            this.minWaitTime.Size = new System.Drawing.Size(63, 20);
            this.minWaitTime.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Min Print Wait Time";
            // 
            // schedulingTemplatePath
            // 
            this.schedulingTemplatePath.Location = new System.Drawing.Point(120, 9);
            this.schedulingTemplatePath.Name = "schedulingTemplatePath";
            this.schedulingTemplatePath.Size = new System.Drawing.Size(337, 20);
            this.schedulingTemplatePath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scheduling File";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.fontSizeBarcode2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.fontBarcode2);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.fontSizeBarcode1);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.fontBarcode1);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(484, 223);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fonts";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // fontSizeBarcode2
            // 
            this.fontSizeBarcode2.Location = new System.Drawing.Point(391, 41);
            this.fontSizeBarcode2.Name = "fontSizeBarcode2";
            this.fontSizeBarcode2.Size = new System.Drawing.Size(87, 20);
            this.fontSizeBarcode2.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Font Size";
            // 
            // fontBarcode2
            // 
            this.fontBarcode2.FormattingEnabled = true;
            this.fontBarcode2.Items.AddRange(new object[] {
            "testing",
            "testing2",
            "testing3"});
            this.fontBarcode2.Location = new System.Drawing.Point(91, 41);
            this.fontBarcode2.Name = "fontBarcode2";
            this.fontBarcode2.Size = new System.Drawing.Size(237, 21);
            this.fontBarcode2.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Labels UPC";
            // 
            // fontSizeBarcode1
            // 
            this.fontSizeBarcode1.Location = new System.Drawing.Point(391, 15);
            this.fontSizeBarcode1.Name = "fontSizeBarcode1";
            this.fontSizeBarcode1.Size = new System.Drawing.Size(87, 20);
            this.fontSizeBarcode1.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(334, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Font Size";
            // 
            // fontBarcode1
            // 
            this.fontBarcode1.FormattingEnabled = true;
            this.fontBarcode1.Items.AddRange(new object[] {
            "testing",
            "testing2",
            "testing3"});
            this.fontBarcode1.Location = new System.Drawing.Point(91, 15);
            this.fontBarcode1.Name = "fontBarcode1";
            this.fontBarcode1.Size = new System.Drawing.Size(237, 21);
            this.fontBarcode1.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Labels Barcode";
            // 
            // Labels
            // 
            this.Labels.Controls.Add(this.printer3);
            this.Labels.Controls.Add(this.printer2Label);
            this.Labels.Controls.Add(this.printer2);
            this.Labels.Controls.Add(this.printer1Label);
            this.Labels.Controls.Add(this.printer1);
            this.Labels.Controls.Add(this.printer0Label);
            this.Labels.Location = new System.Drawing.Point(4, 22);
            this.Labels.Name = "Labels";
            this.Labels.Size = new System.Drawing.Size(484, 223);
            this.Labels.TabIndex = 2;
            this.Labels.Text = "Labels";
            this.Labels.UseVisualStyleBackColor = true;
            // 
            // printer3
            // 
            this.printer3.FormattingEnabled = true;
            this.printer3.Location = new System.Drawing.Point(60, 64);
            this.printer3.Name = "printer3";
            this.printer3.Size = new System.Drawing.Size(260, 21);
            this.printer3.TabIndex = 25;
            // 
            // printer2Label
            // 
            this.printer2Label.AutoSize = true;
            this.printer2Label.Location = new System.Drawing.Point(3, 67);
            this.printer2Label.Name = "printer2Label";
            this.printer2Label.Size = new System.Drawing.Size(46, 13);
            this.printer2Label.TabIndex = 24;
            this.printer2Label.Text = "Printer 3";
            // 
            // printer2
            // 
            this.printer2.FormattingEnabled = true;
            this.printer2.Location = new System.Drawing.Point(60, 37);
            this.printer2.Name = "printer2";
            this.printer2.Size = new System.Drawing.Size(260, 21);
            this.printer2.TabIndex = 23;
            // 
            // printer1Label
            // 
            this.printer1Label.AutoSize = true;
            this.printer1Label.Location = new System.Drawing.Point(3, 40);
            this.printer1Label.Name = "printer1Label";
            this.printer1Label.Size = new System.Drawing.Size(46, 13);
            this.printer1Label.TabIndex = 22;
            this.printer1Label.Text = "Printer 2";
            // 
            // printer1
            // 
            this.printer1.FormattingEnabled = true;
            this.printer1.Location = new System.Drawing.Point(60, 10);
            this.printer1.Name = "printer1";
            this.printer1.Size = new System.Drawing.Size(260, 21);
            this.printer1.TabIndex = 21;
            // 
            // printer0Label
            // 
            this.printer0Label.AutoSize = true;
            this.printer0Label.Location = new System.Drawing.Point(3, 13);
            this.printer0Label.Name = "printer0Label";
            this.printer0Label.Size = new System.Drawing.Size(50, 13);
            this.printer0Label.TabIndex = 20;
            this.printer0Label.Text = "Standard";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.contractEmailList);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(484, 223);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "tabEmail";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // contractEmailList
            // 
            this.contractEmailList.Location = new System.Drawing.Point(150, 19);
            this.contractEmailList.Name = "contractEmailList";
            this.contractEmailList.Size = new System.Drawing.Size(320, 20);
            this.contractEmailList.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Contract E-mail List:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(425, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 267);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contractPath
            // 
            this.contractPath.Location = new System.Drawing.Point(120, 61);
            this.contractPath.Name = "contractPath";
            this.contractPath.Size = new System.Drawing.Size(337, 20);
            this.contractPath.TabIndex = 9;
            // 
            // contractImport
            // 
            this.contractImport.AutoSize = true;
            this.contractImport.Location = new System.Drawing.Point(6, 64);
            this.contractImport.Name = "contractImport";
            this.contractImport.Size = new System.Drawing.Size(84, 13);
            this.contractImport.TabIndex = 8;
            this.contractImport.Text = "Contract Upload";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 302);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.Labels.ResumeLayout(false);
            this.Labels.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox schedulingTemplatePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox waitTimePerPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox minWaitTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox fontBarcode1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox fontSizeBarcode2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox fontBarcode2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fontSizeBarcode1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage Labels;
        private System.Windows.Forms.ComboBox printer3;
        private System.Windows.Forms.Label printer2Label;
        private System.Windows.Forms.ComboBox printer2;
        private System.Windows.Forms.Label printer1Label;
        private System.Windows.Forms.ComboBox printer1;
        private System.Windows.Forms.Label printer0Label;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox contractEmailList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox contractPath;
        private System.Windows.Forms.Label contractImport;
    }
}