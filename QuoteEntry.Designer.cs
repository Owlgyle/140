namespace WindowsFormsApplication1
{
    partial class QuoteEntry
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
            this.cNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sAddr1 = new System.Windows.Forms.TextBox();
            this.sAddr2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sCity = new System.Windows.Forms.TextBox();
            this.sState = new System.Windows.Forms.TextBox();
            this.sZip = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mult = new System.Windows.Forms.TextBox();
            this.fax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.attention = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.QuoteName = new System.Windows.Forms.TextBox();
            this.labelfax = new System.Windows.Forms.Label();
            this.skudescrip = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.sku = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cost = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.qty = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.IndMultLabel = new System.Windows.Forms.Label();
            this.IndMult = new System.Windows.Forms.TextBox();
            this.skuLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.printOnSave = new System.Windows.Forms.CheckBox();
            this.oripricetotal = new System.Windows.Forms.Label();
            this.newpricetotal = new System.Windows.Forms.Label();
            this.costtotal = new System.Windows.Forms.Label();
            this.totalDiscount = new System.Windows.Forms.Label();
            this.totalDirectCost = new System.Windows.Forms.Label();
            this.grid1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.multiplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cubes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.quoteNotes = new System.Windows.Forms.TextBox();
            this.cubeCount = new System.Windows.Forms.Label();
            this.WeightCount = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Freight = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // cNum
            // 
            this.cNum.Location = new System.Drawing.Point(101, 12);
            this.cNum.Name = "cNum";
            this.cNum.Size = new System.Drawing.Size(104, 20);
            this.cNum.TabIndex = 0;
            this.cNum.TextChanged += new System.EventHandler(this.cNum_TextChanged);
            this.cNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cNum_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cust. #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // sName
            // 
            this.sName.Location = new System.Drawing.Point(101, 38);
            this.sName.Name = "sName";
            this.sName.Size = new System.Drawing.Size(104, 20);
            this.sName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Address";
            // 
            // sAddr1
            // 
            this.sAddr1.Location = new System.Drawing.Point(101, 64);
            this.sAddr1.Name = "sAddr1";
            this.sAddr1.Size = new System.Drawing.Size(104, 20);
            this.sAddr1.TabIndex = 4;
            // 
            // sAddr2
            // 
            this.sAddr2.Location = new System.Drawing.Point(101, 90);
            this.sAddr2.Name = "sAddr2";
            this.sAddr2.Size = new System.Drawing.Size(104, 20);
            this.sAddr2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "City - State - Zip";
            // 
            // sCity
            // 
            this.sCity.Location = new System.Drawing.Point(101, 116);
            this.sCity.Name = "sCity";
            this.sCity.Size = new System.Drawing.Size(104, 20);
            this.sCity.TabIndex = 8;
            // 
            // sState
            // 
            this.sState.Location = new System.Drawing.Point(211, 116);
            this.sState.Name = "sState";
            this.sState.Size = new System.Drawing.Size(37, 20);
            this.sState.TabIndex = 10;
            // 
            // sZip
            // 
            this.sZip.Location = new System.Drawing.Point(254, 116);
            this.sZip.Name = "sZip";
            this.sZip.Size = new System.Drawing.Size(54, 20);
            this.sZip.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Multiplier";
            // 
            // mult
            // 
            this.mult.Location = new System.Drawing.Point(421, 116);
            this.mult.Name = "mult";
            this.mult.Size = new System.Drawing.Size(104, 20);
            this.mult.TabIndex = 19;
            this.mult.TextChanged += new System.EventHandler(this.mult_TextChanged);
            this.mult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mult_KeyUp);
            // 
            // fax
            // 
            this.fax.Location = new System.Drawing.Point(421, 90);
            this.fax.Name = "fax";
            this.fax.Size = new System.Drawing.Size(104, 20);
            this.fax.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(333, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "E-mail";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(421, 64);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(104, 20);
            this.email.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(333, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Attention";
            // 
            // attention
            // 
            this.attention.Location = new System.Drawing.Point(421, 38);
            this.attention.Name = "attention";
            this.attention.Size = new System.Drawing.Size(104, 20);
            this.attention.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(333, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Quote Name";
            // 
            // QuoteName
            // 
            this.QuoteName.Location = new System.Drawing.Point(421, 12);
            this.QuoteName.Name = "QuoteName";
            this.QuoteName.Size = new System.Drawing.Size(104, 20);
            this.QuoteName.TabIndex = 12;
            this.QuoteName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.QuoteName_KeyUp);
            // 
            // labelfax
            // 
            this.labelfax.AutoSize = true;
            this.labelfax.Location = new System.Drawing.Point(333, 93);
            this.labelfax.Name = "labelfax";
            this.labelfax.Size = new System.Drawing.Size(24, 13);
            this.labelfax.TabIndex = 21;
            this.labelfax.Text = "Fax";
            // 
            // skudescrip
            // 
            this.skudescrip.Location = new System.Drawing.Point(168, 159);
            this.skudescrip.Name = "skudescrip";
            this.skudescrip.Size = new System.Drawing.Size(140, 20);
            this.skudescrip.TabIndex = 24;
            this.skudescrip.Visible = false;
            this.skudescrip.TextChanged += new System.EventHandler(this.skudescrip_TextChanged);
            this.skudescrip.KeyUp += new System.Windows.Forms.KeyEventHandler(this.skudescrip_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Unit Number";
            // 
            // sku
            // 
            this.sku.Location = new System.Drawing.Point(101, 159);
            this.sku.Name = "sku";
            this.sku.Size = new System.Drawing.Size(60, 20);
            this.sku.TabIndex = 22;
            this.sku.TextChanged += new System.EventHandler(this.sku_TextChanged);
            this.sku.KeyUp += new System.Windows.Forms.KeyEventHandler(this.sku_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Cost";
            // 
            // cost
            // 
            this.cost.Location = new System.Drawing.Point(47, 185);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(46, 20);
            this.cost.TabIndex = 25;
            this.cost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cost_KeyUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 214);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Qty";
            // 
            // qty
            // 
            this.qty.Location = new System.Drawing.Point(47, 211);
            this.qty.Name = "qty";
            this.qty.Size = new System.Drawing.Size(46, 20);
            this.qty.TabIndex = 27;
            this.qty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.qty_KeyUp);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(99, 214);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Price";
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(145, 211);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(46, 20);
            this.price.TabIndex = 29;
            this.price.KeyUp += new System.Windows.Forms.KeyEventHandler(this.price_KeyUp);
            // 
            // IndMultLabel
            // 
            this.IndMultLabel.AutoSize = true;
            this.IndMultLabel.Location = new System.Drawing.Point(197, 214);
            this.IndMultLabel.Name = "IndMultLabel";
            this.IndMultLabel.Size = new System.Drawing.Size(27, 13);
            this.IndMultLabel.TabIndex = 32;
            this.IndMultLabel.Text = "Mult";
            this.IndMultLabel.Visible = false;
            // 
            // IndMult
            // 
            this.IndMult.Location = new System.Drawing.Point(230, 211);
            this.IndMult.Name = "IndMult";
            this.IndMult.Size = new System.Drawing.Size(46, 20);
            this.IndMult.TabIndex = 31;
            this.IndMult.Visible = false;
            this.IndMult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IndMult_KeyUp);
            // 
            // skuLabel
            // 
            this.skuLabel.AutoSize = true;
            this.skuLabel.Location = new System.Drawing.Point(167, 162);
            this.skuLabel.Name = "skuLabel";
            this.skuLabel.Size = new System.Drawing.Size(66, 13);
            this.skuLabel.TabIndex = 33;
            this.skuLabel.Text = "Unit Number";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(442, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 25);
            this.button1.TabIndex = 34;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(442, 173);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 25);
            this.button2.TabIndex = 35;
            this.button2.Text = "Submit Only";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(442, 204);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 25);
            this.button3.TabIndex = 36;
            this.button3.Text = "Email / Fax";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(317, 204);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 25);
            this.button4.TabIndex = 37;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // printOnSave
            // 
            this.printOnSave.AutoSize = true;
            this.printOnSave.Checked = true;
            this.printOnSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.printOnSave.Location = new System.Drawing.Point(531, 147);
            this.printOnSave.Name = "printOnSave";
            this.printOnSave.Size = new System.Drawing.Size(72, 17);
            this.printOnSave.TabIndex = 38;
            this.printOnSave.Text = "Auto Print";
            this.printOnSave.UseVisualStyleBackColor = true;
            // 
            // oripricetotal
            // 
            this.oripricetotal.AutoSize = true;
            this.oripricetotal.Location = new System.Drawing.Point(455, 571);
            this.oripricetotal.Name = "oripricetotal";
            this.oripricetotal.Size = new System.Drawing.Size(47, 13);
            this.oripricetotal.TabIndex = 39;
            this.oripricetotal.Text = "Ori Price";
            // 
            // newpricetotal
            // 
            this.newpricetotal.AutoSize = true;
            this.newpricetotal.Location = new System.Drawing.Point(647, 571);
            this.newpricetotal.Name = "newpricetotal";
            this.newpricetotal.Size = new System.Drawing.Size(56, 13);
            this.newpricetotal.TabIndex = 40;
            this.newpricetotal.Text = "New Price";
            // 
            // costtotal
            // 
            this.costtotal.AutoSize = true;
            this.costtotal.Location = new System.Drawing.Point(816, 571);
            this.costtotal.Name = "costtotal";
            this.costtotal.Size = new System.Drawing.Size(55, 13);
            this.costtotal.TabIndex = 41;
            this.costtotal.Text = "Cost Total";
            // 
            // totalDiscount
            // 
            this.totalDiscount.AutoSize = true;
            this.totalDiscount.Location = new System.Drawing.Point(49, 593);
            this.totalDiscount.Name = "totalDiscount";
            this.totalDiscount.Size = new System.Drawing.Size(79, 13);
            this.totalDiscount.TabIndex = 42;
            this.totalDiscount.Text = "Total Discount:";
            // 
            // totalDirectCost
            // 
            this.totalDirectCost.AutoSize = true;
            this.totalDirectCost.Location = new System.Drawing.Point(292, 593);
            this.totalDirectCost.Name = "totalDirectCost";
            this.totalDirectCost.Size = new System.Drawing.Size(89, 13);
            this.totalDirectCost.TabIndex = 43;
            this.totalDirectCost.Text = "Total Direct Cost:";
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
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.multiplier,
            this.Cubes,
            this.Weight});
            this.grid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid1.Location = new System.Drawing.Point(12, 279);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(918, 291);
            this.grid1.TabIndex = 44;
            this.grid1.Click += new System.EventHandler(this.grid1_Click);
            this.grid1.DoubleClick += new System.EventHandler(this.grid1_DoubleClick);
            this.grid1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid1_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "id";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            this.Column1.Width = 5;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Sku";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Description";
            this.Column3.Name = "Column3";
            this.Column3.Width = 130;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Qty";
            this.Column4.Name = "Column4";
            this.Column4.Width = 60;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Original Price";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Original Ext Total";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Proposed Price";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Proposed Ext Total";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Actual DC";
            this.Column9.Name = "Column9";
            this.Column9.Width = 60;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "DC Ext Total";
            this.Column10.Name = "Column10";
            this.Column10.Width = 75;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "dc%";
            this.Column11.Name = "Column11";
            this.Column11.Width = 50;
            // 
            // multiplier
            // 
            this.multiplier.HeaderText = "Multiplier";
            this.multiplier.Name = "multiplier";
            this.multiplier.Visible = false;
            // 
            // Cubes
            // 
            this.Cubes.HeaderText = "Cubes";
            this.Cubes.Name = "Cubes";
            this.Cubes.Visible = false;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.Visible = false;
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(13, 242);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(0, 13);
            this.total.TabIndex = 45;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(227, 242);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(0, 13);
            this.Label9.TabIndex = 46;
            // 
            // quoteNotes
            // 
            this.quoteNotes.Location = new System.Drawing.Point(531, 12);
            this.quoteNotes.Multiline = true;
            this.quoteNotes.Name = "quoteNotes";
            this.quoteNotes.Size = new System.Drawing.Size(384, 120);
            this.quoteNotes.TabIndex = 47;
            // 
            // cubeCount
            // 
            this.cubeCount.Location = new System.Drawing.Point(105, 263);
            this.cubeCount.Name = "cubeCount";
            this.cubeCount.Size = new System.Drawing.Size(100, 13);
            this.cubeCount.TabIndex = 48;
            // 
            // WeightCount
            // 
            this.WeightCount.Location = new System.Drawing.Point(314, 263);
            this.WeightCount.Name = "WeightCount";
            this.WeightCount.Size = new System.Drawing.Size(100, 13);
            this.WeightCount.TabIndex = 49;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 263);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 50;
            this.label15.Text = "Cube Count";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(267, 263);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 51;
            this.label14.Text = "Weight";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(675, 593);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 13);
            this.label16.TabIndex = 53;
            this.label16.Text = "Freight Charges";
            // 
            // Freight
            // 
            this.Freight.Location = new System.Drawing.Point(762, 590);
            this.Freight.Name = "Freight";
            this.Freight.Size = new System.Drawing.Size(87, 20);
            this.Freight.TabIndex = 52;
            // 
            // QuoteEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 615);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.Freight);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.WeightCount);
            this.Controls.Add(this.cubeCount);
            this.Controls.Add(this.quoteNotes);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.total);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.totalDirectCost);
            this.Controls.Add(this.totalDiscount);
            this.Controls.Add(this.costtotal);
            this.Controls.Add(this.newpricetotal);
            this.Controls.Add(this.oripricetotal);
            this.Controls.Add(this.printOnSave);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.skuLabel);
            this.Controls.Add(this.IndMultLabel);
            this.Controls.Add(this.IndMult);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.price);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.qty);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.skudescrip);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.sku);
            this.Controls.Add(this.labelfax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mult);
            this.Controls.Add(this.fax);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.attention);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.QuoteName);
            this.Controls.Add(this.sZip);
            this.Controls.Add(this.sState);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sCity);
            this.Controls.Add(this.sAddr2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sAddr1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cNum);
            this.Name = "QuoteEntry";
            this.Text = "QuoteEntry";
            this.Activated += new System.EventHandler(this.QuoteEntry_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuoteEntry_FormClosing);
            this.Load += new System.EventHandler(this.QuoteEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sAddr1;
        private System.Windows.Forms.TextBox sAddr2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox sCity;
        private System.Windows.Forms.TextBox sState;
        private System.Windows.Forms.TextBox sZip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mult;
        private System.Windows.Forms.TextBox fax;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox attention;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox QuoteName;
        private System.Windows.Forms.Label labelfax;
        private System.Windows.Forms.TextBox skudescrip;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox sku;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox cost;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox qty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label IndMultLabel;
        private System.Windows.Forms.TextBox IndMult;
        private System.Windows.Forms.Label skuLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox printOnSave;
        private System.Windows.Forms.Label oripricetotal;
        private System.Windows.Forms.Label newpricetotal;
        private System.Windows.Forms.Label costtotal;
        private System.Windows.Forms.Label totalDiscount;
        private System.Windows.Forms.Label totalDirectCost;
        private System.Windows.Forms.DataGridView grid1;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label Label9;
        private System.Windows.Forms.TextBox quoteNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn multiplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cubes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.Label cubeCount;
        private System.Windows.Forms.Label WeightCount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox Freight;
    }
}