namespace WindowsFormsApplication1
{
    partial class Orders
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
            this.cNum = new System.Windows.Forms.TextBox();
            this.oDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.poNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sAddr2 = new System.Windows.Forms.TextBox();
            this.sAddr1 = new System.Windows.Forms.TextBox();
            this.sName = new System.Windows.Forms.TextBox();
            this.sCity = new System.Windows.Forms.TextBox();
            this.sState = new System.Windows.Forms.TextBox();
            this.sZip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.shipping = new System.Windows.Forms.ComboBox();
            this.sku = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.qty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nstock = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label9a = new System.Windows.Forms.Label();
            this.orderTotal = new System.Windows.Forms.Label();
            this.cubeCount = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lastOrder = new System.Windows.Forms.Label();
            this.grid1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locNotes = new System.Windows.Forms.TextBox();
            this.temp = new System.Windows.Forms.ComboBox();
            this.quoteNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cust. #";
            // 
            // cNum
            // 
            this.cNum.Location = new System.Drawing.Point(84, 6);
            this.cNum.Name = "cNum";
            this.cNum.Size = new System.Drawing.Size(137, 20);
            this.cNum.TabIndex = 0;
            this.cNum.TextChanged += new System.EventHandler(this.cNum_Change);
            this.cNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cNum_KeyUp);
            // 
            // oDate
            // 
            this.oDate.Location = new System.Drawing.Point(84, 32);
            this.oDate.Name = "oDate";
            this.oDate.Size = new System.Drawing.Size(137, 20);
            this.oDate.TabIndex = 7;
            this.oDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.oDate_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Order Date";
            // 
            // poNum
            // 
            this.poNum.Location = new System.Drawing.Point(84, 58);
            this.poNum.Name = "poNum";
            this.poNum.Size = new System.Drawing.Size(137, 20);
            this.poNum.TabIndex = 8;
            this.poNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.poNum_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "PO Number";
            // 
            // sAddr2
            // 
            this.sAddr2.Location = new System.Drawing.Point(265, 58);
            this.sAddr2.Name = "sAddr2";
            this.sAddr2.Size = new System.Drawing.Size(201, 20);
            this.sAddr2.TabIndex = 3;
            // 
            // sAddr1
            // 
            this.sAddr1.Location = new System.Drawing.Point(265, 32);
            this.sAddr1.Name = "sAddr1";
            this.sAddr1.Size = new System.Drawing.Size(201, 20);
            this.sAddr1.TabIndex = 2;
            // 
            // sName
            // 
            this.sName.Location = new System.Drawing.Point(265, 6);
            this.sName.Name = "sName";
            this.sName.Size = new System.Drawing.Size(201, 20);
            this.sName.TabIndex = 1;
            // 
            // sCity
            // 
            this.sCity.Location = new System.Drawing.Point(265, 84);
            this.sCity.Name = "sCity";
            this.sCity.Size = new System.Drawing.Size(106, 20);
            this.sCity.TabIndex = 4;
            // 
            // sState
            // 
            this.sState.Location = new System.Drawing.Point(377, 84);
            this.sState.Name = "sState";
            this.sState.Size = new System.Drawing.Size(33, 20);
            this.sState.TabIndex = 5;
            // 
            // sZip
            // 
            this.sZip.Location = new System.Drawing.Point(416, 84);
            this.sZip.Name = "sZip";
            this.sZip.Size = new System.Drawing.Size(50, 20);
            this.sZip.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Shipping";
            // 
            // shipping
            // 
            this.shipping.FormattingEnabled = true;
            this.shipping.Location = new System.Drawing.Point(84, 84);
            this.shipping.Name = "shipping";
            this.shipping.Size = new System.Drawing.Size(137, 21);
            this.shipping.TabIndex = 9;
            this.shipping.KeyUp += new System.Windows.Forms.KeyEventHandler(this.shipping_KeyUp);
            // 
            // sku
            // 
            this.sku.Location = new System.Drawing.Point(84, 138);
            this.sku.Name = "sku";
            this.sku.Size = new System.Drawing.Size(137, 20);
            this.sku.TabIndex = 10;
            this.sku.TextChanged += new System.EventHandler(this.sku_TextChanged);
            this.sku.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Sku_Key_Up);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Unit Number";
            // 
            // qty
            // 
            this.qty.Location = new System.Drawing.Point(294, 138);
            this.qty.Name = "qty";
            this.qty.Size = new System.Drawing.Size(47, 20);
            this.qty.TabIndex = 11;
            this.qty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.qty_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Qty.";
            // 
            // price
            // 
            this.price.Enabled = false;
            this.price.Location = new System.Drawing.Point(384, 138);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(47, 20);
            this.price.TabIndex = 12;
            this.price.KeyUp += new System.Windows.Forms.KeyEventHandler(this.price_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(347, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Price";
            // 
            // nstock
            // 
            this.nstock.Enabled = false;
            this.nstock.Location = new System.Drawing.Point(84, 164);
            this.nstock.Name = "nstock";
            this.nstock.Size = new System.Drawing.Size(347, 20);
            this.nstock.TabIndex = 13;
            this.nstock.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nstock_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Non Stock";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(589, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 29);
            this.button1.TabIndex = 22;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(589, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 29);
            this.button2.TabIndex = 14;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(589, 125);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 29);
            this.button3.TabIndex = 24;
            this.button3.Text = "Don\'t Print";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label9a
            // 
            this.label9a.AutoSize = true;
            this.label9a.Location = new System.Drawing.Point(12, 200);
            this.label9a.Name = "label9a";
            this.label9a.Size = new System.Drawing.Size(60, 13);
            this.label9a.TabIndex = 25;
            this.label9a.Text = "Order Total";
            // 
            // orderTotal
            // 
            this.orderTotal.Location = new System.Drawing.Point(81, 200);
            this.orderTotal.Name = "orderTotal";
            this.orderTotal.Size = new System.Drawing.Size(140, 13);
            this.orderTotal.TabIndex = 26;
            // 
            // cubeCount
            // 
            this.cubeCount.Location = new System.Drawing.Point(331, 200);
            this.cubeCount.Name = "cubeCount";
            this.cubeCount.Size = new System.Drawing.Size(100, 13);
            this.cubeCount.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(262, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Cube Count";
            // 
            // Label9
            // 
            this.Label9.Location = new System.Drawing.Point(457, 125);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(126, 42);
            this.Label9.TabIndex = 29;
            this.Label9.Click += new System.EventHandler(this.Label9_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(472, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Last Order";
            // 
            // lastOrder
            // 
            this.lastOrder.Location = new System.Drawing.Point(472, 39);
            this.lastOrder.Name = "lastOrder";
            this.lastOrder.Size = new System.Drawing.Size(100, 13);
            this.lastOrder.TabIndex = 31;
            // 
            // grid1
            // 
            this.grid1.AllowUserToAddRows = false;
            this.grid1.AllowUserToDeleteRows = false;
            this.grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.grid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid1.Location = new System.Drawing.Point(15, 216);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(671, 296);
            this.grid1.TabIndex = 32;
            this.grid1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid1_RowsAdded);
            this.grid1.Click += new System.EventHandler(this.grid1_Click);
            this.grid1.DoubleClick += new System.EventHandler(this.grid1_DoubleClick);
            this.grid1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid1_KeyDown);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 1F;
            this.Column1.HeaderText = "id";
            this.Column1.MinimumWidth = 2;
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 2;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Sku";
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Description";
            this.Column3.Name = "Column3";
            this.Column3.Width = 320;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Qty";
            this.Column4.Name = "Column4";
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Price";
            this.Column5.Name = "Column5";
            // 
            // locNotes
            // 
            this.locNotes.Location = new System.Drawing.Point(12, 518);
            this.locNotes.Multiline = true;
            this.locNotes.Name = "locNotes";
            this.locNotes.Size = new System.Drawing.Size(671, 65);
            this.locNotes.TabIndex = 33;
            // 
            // temp
            // 
            this.temp.FormattingEnabled = true;
            this.temp.Location = new System.Drawing.Point(84, 111);
            this.temp.Name = "temp";
            this.temp.Size = new System.Drawing.Size(29, 21);
            this.temp.TabIndex = 34;
            this.temp.Visible = false;
            // 
            // quoteNum
            // 
            this.quoteNum.Location = new System.Drawing.Point(589, 167);
            this.quoteNum.Name = "quoteNum";
            this.quoteNum.Size = new System.Drawing.Size(94, 20);
            this.quoteNum.TabIndex = 35;
            this.quoteNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.quoteNum_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(515, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 36;
            this.label10.Text = "Import Quote";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(589, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 29);
            this.button4.TabIndex = 37;
            this.button4.Text = "Quote Pricing";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 595);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.quoteNum);
            this.Controls.Add(this.temp);
            this.Controls.Add(this.locNotes);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.lastOrder);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.cubeCount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.orderTotal);
            this.Controls.Add(this.label9a);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nstock);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.price);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.qty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sku);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.shipping);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sZip);
            this.Controls.Add(this.sState);
            this.Controls.Add(this.sCity);
            this.Controls.Add(this.sAddr2);
            this.Controls.Add(this.sAddr1);
            this.Controls.Add(this.sName);
            this.Controls.Add(this.poNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.oDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cNum);
            this.Controls.Add(this.label1);
            this.Name = "Orders";
            this.Text = "Royal Metal Products";
            this.Activated += new System.EventHandler(this.Orders_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Orders_FormClosing);
            this.Load += new System.EventHandler(this.Orders_Load);
            this.Resize += new System.EventHandler(this.Orders_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cNum;
        private System.Windows.Forms.TextBox oDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox poNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sAddr2;
        private System.Windows.Forms.TextBox sAddr1;
        private System.Windows.Forms.TextBox sName;
        private System.Windows.Forms.TextBox sCity;
        private System.Windows.Forms.TextBox sState;
        private System.Windows.Forms.TextBox sZip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox shipping;
        private System.Windows.Forms.TextBox sku;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox qty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox nstock;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9a;
        private System.Windows.Forms.Label orderTotal;
        private System.Windows.Forms.Label cubeCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label Label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lastOrder;
        private System.Windows.Forms.DataGridView grid1;
        private System.Windows.Forms.TextBox locNotes;
        private System.Windows.Forms.ComboBox temp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.TextBox quoteNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button4;
    }
}