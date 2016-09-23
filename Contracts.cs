using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Contracts : Form
    {
        public struct contractItem
        {
            public bool multiplierOverriden;
            public float productCost, warehousePrice, multiplier;
            public ushort rowID;
            public int unitID;
        }

        public static contractItem currentItem;
        List<contractItem> itemsList = new List<contractItem>();

        bool cMultiplierOverriden = false;
        public static string contract_ID;
        public static bool autoUpdateCustomerInfo;
        public static int contractNum = 0, curRow, unitID, ns, locationID, companyID, priceCode, pallets;
        public static float productCost, warehousePrice, multiplier_c = 1.0f, multiplier_wh = 1.0f, itemMultiplier = 1.0f;

        SqlConnection conn = new SqlConnection("Data Source=Romeo;Initial Catalog=Royal;User ID=royal;password=wkjwuq");
        SqlConnection conn2 = new SqlConnection("Data Source=Romeo;Initial Catalog=Royal;User ID=royal;password=wkjwuq");
        SqlDataReader rdr = null;

        public Contracts()
        {
            InitializeComponent();
        }

        private void sku_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd;

            if (sku.Text.Trim().Length > 0)
            {
                if (!Validate_Multipliers())
                {
                    sku.Text = "";
                    return;
                }
            }
            else
            {
                nstock.Enabled = false;
                nstock.TabStop = false;
                whPrice.Enabled = false;
                whPrice.TabStop = false;
                productCost = 0.0f;
                warehousePrice = 0.0f;
                unitID = 0;
                ns = 0;
                return;
            }

            try
            {
                cmd = new SqlCommand("select units.*, unit_price.price from units inner join unit_price on units.ct=unit_price.unitID where sku='" + sku.Text + "' And unit_price.priceID = " + priceCode.ToString(), conn);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    if (rdr["active"].Equals(false))
                    {
                        MessageBox.Show("The sku you selected has been marked inactive and cannot be entered.");
                        if (rdr != null)
                            rdr.Close();
                        return;
                    }

                    unitID = Convert.ToInt32(rdr["ct"].ToString());
                    nstock.Text = rdr["descrip"].ToString();

                    if (util_functions.isnumeric(rdr["cost"].ToString()))
                        productCost = Convert.ToSingle(rdr["cost"].ToString());
                    else
                        productCost = 0.0f;

                    if (priceCode > 0 && util_functions.isnumeric(rdr["price"].ToString()))
                        warehousePrice = Convert.ToSingle(rdr["price"].ToString());
                    else
                        warehousePrice = 0;

                    whPrice.Text = warehousePrice.ToString();
                    nstock.Enabled = false;
                    nstock.TabStop = false;
                    whPrice.Enabled = false;
                    whPrice.TabStop = false;
                    ns = 0;
                }
                else
                {
                    nstock.Text = "";
                    nstock.Enabled = true;
                    nstock.TabStop = true;
                    whPrice.Text = "";
                    whPrice.Enabled = true;
                    whPrice.TabStop = true;
                    productCost = 0.0f;
                    warehousePrice = 0.0f;
                    unitID = 0;
                    ns = 1;
                }

                directCost.Text = productCost.ToString();
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nPlease delete this sku and re-enter.");
            }


            if (rdr != null)
                rdr.Close();
        }

        private void Contracts_Load(object sender, EventArgs e)
        {
            conn.Open();
            conn2.Open();

            grid1.Rows.Clear();
            curRow = -1;

            Set_Grid_Column_Sizes();

            resetForm();
            cNum.Focus();
        }

        public void Set_Grid_Column_Sizes()
        {
            byte b1;
            float size;

            grid1.Width = this.Width - 45;

            size = (float)grid1.Width * (1.0f / (grid1.Columns.Count + 1)); // column 2 is twice the width of the other columns so size needs to add one more in

            for (b1 = 0; b1 < grid1.Columns.Count; ++b1)
                grid1.Columns[b1].Width = (int)size;

            grid1.Columns[2].Width = (int)(2 * size);

            dcExtGrandTotal.Left = (int)(grid1.Left + size * 11.0f);
            contractExtGrandTotal.Left = (int)(grid1.Left + size * 13.0f);
            whExtGrandTotal.Left = (int)(grid1.Left + size * 14.0f);

            locNotes.Width = this.Width - 45;
        }

        public void resetForm()
        {
            cNum.Text = "";
            sku.Text = "";
            monthlyQty.Text = "";
            contractPrice.Text = "";
            sellPrice.Text = "";
            contract_ID = "";

            salesMgr.Text = "";
            accountRep.Text = "";
            contractorsName.Text = "";
            contractorsLocation.Text = "";
            royalVolume.Text = "";
            newContract.Text = "";
            contractEffDate.Text = "";
            distribBranch.Text = "";
            contractorsAct.Text = "";
            competingWholesaler.Text = "";
            competingMfgr.Text = "";
            contractLen.Text = "";

            materialShipping.SelectedIndex = 0;
            yesNoBusiness.SelectedIndex = 0;
            yesNoBuy.SelectedIndex = 0;

            locationID = 0;
            companyID = 0;
            priceCode = 0;
            contractNum = 0;

            grid1.Rows.Clear();
            curRow = -1;

            sku.Enabled = false;
            monthlyQty.Enabled = false;
            sellPrice.Enabled = false;
            nstock.Enabled = false;
            whPrice.Enabled = false;

            if (itemsList.Count > 0)
                itemsList.RemoveRange(0, itemsList.Count);

            autoUpdateCustomerInfo = true;

            button3.Text = "Save Only";
            button4.Text = "Save and E-mail";

        }

        public void resetEntryFields()
        {
            Label9.Text = "";
            sku.Text = "";
            nstock.Text = "";
            whPrice.Text = "";
            monthlyQty.Text = "";
            sellPrice.Text = "";
            contractPrice.Text = "";
            directCost.Text = "";

            nstock.Enabled = false;
            nstock.TabStop = false;
            whPrice.Enabled = false;
            whPrice.TabStop = false;
            productCost = 0.0f;
            warehousePrice = 0.0f;
            unitID = 0;
            ns = 0;

            cMultiplierOverriden = false;

            sku.Enabled = true;
        }

        private void Contracts_Activated(object sender, EventArgs e)
        {
            Set_Grid_Column_Sizes();
            if (cNum.Text.Trim() == "")
                cNum.Focus();
        }

        public bool Add_Item_To_Grid()
        {
            int a, b, qty;
            float sPrice, cPrice, margin, rebate, productCostPerc;

            try
            {
                if (!util_functions.isnumeric(directCost.Text))
                {
                    MessageBox.Show("The Direct Cost must be numeric.");
                    directCost.Focus();
                    return false;
                }

                if (!util_functions.isnumeric(monthlyQty.Text))
                {
                    MessageBox.Show("The monthly quantity must be numeric.");
                    monthlyQty.Focus();
                    return false;
                }

                if (!util_functions.isnumeric(sellPrice.Text))
                {
                    MessageBox.Show("The sell price must be numeric.");
                    sellPrice.Focus();
                    return false;
                }

                if (!util_functions.isnumeric(contractPrice.Text))
                {
                    MessageBox.Show("The contract price must be numeric.");
                    contractPrice.Focus();
                    return false;
                }

                if (!util_functions.isnumeric(directCost.Text))
                {
                    MessageBox.Show("The direct cost must be numeric.");
                    directCost.Focus();
                    return false;
                }

                if (!util_functions.isnumeric(whPrice.Text))
                {
                    MessageBox.Show("The warehouse price must be numeric.");
                    whPrice.Focus();
                    return false;
                }

                qty = Convert.ToInt32(monthlyQty.Text);
                sPrice = Convert.ToSingle(sellPrice.Text);
                cPrice = Convert.ToSingle(contractPrice.Text);

                if (sPrice != 0.0f)
                    margin = cPrice / sPrice;
                else
                    margin = 0.0f;
                rebate = warehousePrice - cPrice;
                if (cPrice != 0.0f)
                    productCostPerc = productCost / cPrice;
                else
                    productCostPerc = 0.0f;

                currentItem.unitID = unitID;
                currentItem.productCost = productCost;
                currentItem.warehousePrice = warehousePrice;
                currentItem.multiplier = itemMultiplier;
                currentItem.multiplierOverriden = cMultiplierOverriden;

                if (curRow < 0)
                {
                    a = grid1.Rows.Add();
                    currentItem.rowID = (ushort)a;
                    itemsList.Add(currentItem);
                }
                else
                {
                    a = curRow;
                    currentItem.rowID = (ushort)a;
                    for (b = 0; b < itemsList.Count; ++b)
                        if (itemsList[b].rowID == (ushort)a)
                            itemsList[b] = currentItem;

                    // Reset these in case one of the multipliers was changed during edit mode.
                    multiplier.Text = multiplier_c.ToString();
                    whMultiplier.Text = multiplier_wh.ToString();
                }

                grid1.Rows[a].Cells[0].Value = sku.Text;
                grid1.Rows[a].Cells[1].Value = sku.Text;
                grid1.Rows[a].Cells[2].Value = nstock.Text;
                grid1.Rows[a].Cells[3].Value = monthlyQty.Text;
                grid1.Rows[a].Cells[4].Value = util_functions.roundNumber(Convert.ToSingle(sellPrice.Text), 2).ToString();
                grid1.Rows[a].Cells[5].Value = margin.ToString();
                grid1.Rows[a].Cells[6].Value = util_functions.roundNumber(Convert.ToSingle(contractPrice.Text), 2).ToString();
                grid1.Rows[a].Cells[7].Value = util_functions.roundNumber(Convert.ToSingle(warehousePrice), 2).ToString();
                grid1.Rows[a].Cells[8].Value = util_functions.roundNumber(Convert.ToSingle(rebate), 2).ToString();
                grid1.Rows[a].Cells[9].Value = productCost.ToString();
                grid1.Rows[a].Cells[10].Value = util_functions.roundNumber(productCost * Convert.ToSingle(monthlyQty.Text), 2).ToString();
                grid1.Rows[a].Cells[11].Value = util_functions.roundNumber(productCost / cPrice, 2).ToString();
                grid1.Rows[a].Cells[12].Value = util_functions.roundNumber(Convert.ToSingle(contractPrice.Text) * Convert.ToSingle(monthlyQty.Text), 2).ToString();
                grid1.Rows[a].Cells[13].Value = util_functions.roundNumber(Convert.ToSingle(whPrice.Text) * Convert.ToSingle(monthlyQty.Text), 2).ToString();
                if (grid1.Rows.Count > 11)
                    grid1.FirstDisplayedScrollingRowIndex = grid1.Rows.Count - 12;

                Calculate_Contract_Totals();

                resetEntryFields();
                sku.Focus();
                curRow = -1;

                sku.Enabled = true;
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nPlease delete this item and re-enter.");
                sku.Enabled = true;
                return false;
            }


            return true;
        }

        private void nstock_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    whPrice.Focus();
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nPlease delete this description and re-enter.");
            }
        }

        private void cNum_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd;

            if (!autoUpdateCustomerInfo)
                return;

            customerNumberChanged(false);

            try
            {
                if (util_functions.isnumeric(cNum.Text))
                {
                    cmd = new SqlCommand("select * from location where customernum='" + cNum.Text + "' and active<>0", conn);
                    rdr = cmd.ExecuteReader();
                    if (rdr.HasRows && rdr.Read())
                    {
                        locationID = Convert.ToInt16(rdr["ct"].ToString());
                        companyID = Convert.ToInt16(rdr["companyID"].ToString());
                        if (util_functions.isnumeric(rdr["priceID"].ToString()))
                            priceCode = Convert.ToInt16(rdr["priceID"].ToString());
                        else
                            priceCode = 0;

                        customerNumberChanged(true);
                    }
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured while loading the customer information.\n\n" + e1.Message);
            }

            if (rdr != null)
                rdr.Close();
        }

        public void customerNumberChanged(bool isValid)
        {
            if (isValid)
            {
                sku.Enabled = true;
                monthlyQty.Enabled = true;
                sellPrice.Enabled = true;
                if (ns == 1)
                {
                    nstock.Enabled = true;
                    whPrice.Enabled = true;
                }
            }
            else
            {
                sku.Enabled = false;
                monthlyQty.Enabled = false;
                sellPrice.Enabled = false;
                nstock.Enabled = false;
                whPrice.Enabled = false;

                locationID = 0;
                companyID = 0;
                priceCode = 0;
            }
        }

        private void sku_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!Validate_Multipliers())
                    return;

                if (ns == 0)
                    monthlyQty.Focus();
                else
                    nstock.Focus();
            }
        }

        private void sellPrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (util_functions.isnumeric(monthlyQty.Text) && util_functions.isnumeric(sellPrice.Text))
                    Add_Item_To_Grid();
            }
            else
            {
                Update_Contract_Price(true);
            }
        }

        private void monthlyQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && util_functions.isnumeric(sellPrice.Text))
                sellPrice.Focus();

        }

        private void Export_Click(object sender, EventArgs e)
        {
            int x, y;
            float whExt, contractExt, productCost, extProductCost, costPerc, cPrice;
            StreamWriter file1;

            if (grid1.Rows.Count < 1)
            {
                MessageBox.Show("Error: No units on contract.");
                return;
            }

            //file1 = File.CreateText("c:\\contracts.csv");
            file1 = File.CreateText("c:\\contracts.txt");
            file1.WriteLine("ROYAL METAL PRODUCT'S PRICING CONTRACT" + Create_Tab_List(13));
            file1.WriteLine(Create_Tab_List(14));
            file1.WriteLine("Distributor's Sales Manager:\t \t" + salesMgr.Text + "\t \tContract Effective Date:\t" + contractEffDate.Text + Create_Tab_List(8));
            file1.WriteLine(Create_Tab_List(14));
            file1.WriteLine("Distributor's Account Rep:\t \t" + accountRep.Text + "\t \tDistriburtor's Branch:\t" + distribBranch.Text + Create_Tab_List(8));
            file1.WriteLine(Create_Tab_List(14));
            file1.WriteLine("Contractor's Name:\t \t" + contractorsName.Text + "\t \tContractor's Acct#:\t" + contractorsAct.Text + Create_Tab_List(8));
            file1.WriteLine(Create_Tab_List(14));
            file1.WriteLine("Contractor's Location:\t \t" + contractorsLocation.Text + "\t \tCompeting Wholesaler:\t" + competingWholesaler.Text + Create_Tab_List(8));
            file1.WriteLine(Create_Tab_List(14));
            file1.WriteLine("Potential Annual Royal Volume:\t \t" + royalVolume.Text + "\t \tCompeting Manufacturer:\t" + competingMfgr.Text + Create_Tab_List(8));
            file1.WriteLine(Create_Tab_List(14));
            file1.WriteLine("Existing or New Contract:\t \t" + newContract.Text + "\t \tLength of Contract:\t" + contractLen.Text + Create_Tab_List(8));
            file1.WriteLine(Create_Tab_List(14));
            file1.WriteLine("Will this material be shipped out of Warehouse or Direct from Royal?\t \t \t \t" + materialShipping.GetItemText(materialShipping.Items[materialShipping.SelectedIndex]) + Create_Tab_List(9));
            file1.WriteLine(Create_Tab_List(14));
            file1.WriteLine("If Contract is secured, has contracator agreed to give you the business?\t \t \t \t" + yesNoBusiness.Text + Create_Tab_List(9));
            file1.WriteLine(Create_Tab_List(14));
            file1.WriteLine("Has contractor agreed to buy full line of Royal products, not just contracted items?\t \t \t \t" + yesNoBuy.Text + Create_Tab_List(9));
            file1.WriteLine(Create_Tab_List(14));
            file1.WriteLine("Royal Sku#\tCustomer Part #\tProduct Description\tMonthly Quantity\tSell Price\tMargin\tContract Price\tWH Price\tRebate\tWH Ext\tContract Ext\tProduct Cost\tExt Product Cost\tProduct Cost %");

            for (x = 0; x < grid1.Rows.Count; x++)
            {
                for (y = 0; y < 9; ++y)
                    file1.Write(grid1.Rows[x].Cells[y].Value.ToString().Trim() + "\t");

                for (y = 0, productCost = 0; y < itemsList.Count; ++y)
                    if (itemsList[y].rowID == x)
                    {
                        productCost = itemsList[y].productCost;
                        break;
                    }

                whExt = Convert.ToSingle(grid1.Rows[x].Cells[7].Value) * Convert.ToInt16(grid1.Rows[x].Cells[3].Value);
                contractExt = Convert.ToSingle(grid1.Rows[x].Cells[6].Value) * Convert.ToInt16(grid1.Rows[x].Cells[3].Value);
                extProductCost = productCost * Convert.ToInt16(grid1.Rows[x].Cells[3].Value);
                cPrice = Convert.ToSingle(grid1.Rows[x].Cells[6].Value);
                if (cPrice != 0.0f)
                    costPerc = productCost / cPrice;
                else
                    costPerc = 0.0f;

                file1.WriteLine(whExt.ToString() + "\t" + contractExt.ToString() + "\t" + productCost.ToString() + "\t" + extProductCost.ToString() + "\t" + costPerc.ToString());
            }

            file1.Close();

        }

        public string Create_Tab_List(byte number)
        {
            string str1 = "";

            for (; number > 0; --number)
                str1 = str1 + "\t";

            return str1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Discard all work to this contract?",
                        "Confirm",
                        MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    resetForm();
                    this.Hide();
                }
            }
            else
            {
                resetForm();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grid1.Rows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Discard all work to this contract?",
                        "Confirm",
                        MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    resetForm();
                    cNum.Focus();
                }
            }
            else
            {
                resetForm();
                cNum.Focus();
            }

        }

        #region Movement Between Fields

        private void cNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                salesMgr.Focus();
        }

        private void salesMgr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                accountRep.Focus();

        }

        private void accountRep_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                contractorsName.Focus();

        }

        private void contractorsName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                contractorsLocation.Focus();

        }

        private void contractorsLocation_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                royalVolume.Focus();

        }

        private void royalVolume_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                newContract.Focus();

        }

        private void newContract_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                contractEffDate.Focus();

        }

        private void contractEffDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                distribBranch.Focus();

        }

        private void distribBranch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                contractorsAct.Focus();

        }

        private void contractorsAct_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                competingWholesaler.Focus();

        }

        private void competingWholesaler_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                competingMfgr.Focus();

        }

        private void competingMfgr_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                contractLen.Focus();

        }

        private void contractLen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                materialShipping.Focus();

        }

        private void materialShipping_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                yesNoBusiness.Focus();

        }

        private void yesNoBusiness_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                yesNoBuy.Focus();

        }

        private void yesNoBuy_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                multiplier.Focus();

        }
        #endregion

        private void grid1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            grid1.FirstDisplayedScrollingRowIndex = grid1.Rows.Count - 1;
        }

        private void grid1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete && grid1.CurrentRow.Index >= 0)
                {
                    Edit_Row();

                    grid1.Rows.RemoveAt(curRow);

                    resetEntryFields();
                    curRow = -1;

                    Calculate_Contract_Totals();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nPlease delete this description and re-enter.");
            }
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            Edit_Row();
        }

        public void Edit_Row()
        {
            int b;
            float qty, cPrice;

            try
            {
                if (grid1.CurrentRow.Index >= 0 && grid1.CurrentRow.Index < grid1.Rows.Count)
                {
                    curRow = grid1.CurrentRow.Index;
                    monthlyQty.Text = grid1.Rows[curRow].Cells[3].Value.ToString();
                    sellPrice.Text = grid1.Rows[curRow].Cells[4].Value.ToString();
                    contractPrice.Text = grid1.Rows[curRow].Cells[6].Value.ToString();
                    whPrice.Text = grid1.Rows[curRow].Cells[7].Value.ToString();
                    warehousePrice = Convert.ToSingle(grid1.Rows[curRow].Cells[7].Value.ToString());
                    sku.Text = grid1.Rows[curRow].Cells[0].Value.ToString();
                    nstock.Text = grid1.Rows[curRow].Cells[2].Value.ToString();

                    Label9.Text = "Edit Mode";

                    qty = Convert.ToInt32(monthlyQty.Text);
                    cPrice = Convert.ToSingle(contractPrice.Text);

                    multiplier.Text = multiplier_c.ToString();
                    whMultiplier.Text = multiplier_wh.ToString();

                    cMultiplierOverriden = false;
                    itemMultiplier = 1.0f;
                    productCost = 0.0f;
                    for (b = 0; b < itemsList.Count; ++b)
                        if (itemsList[b].rowID == (ushort)curRow)
                        {
                            productCost = itemsList[b].productCost;
                            cMultiplierOverriden = itemsList[b].multiplierOverriden;
                            itemMultiplier = itemsList[b].multiplier;
                            if (cMultiplierOverriden)
                            {
                                if (util_functions.isnumeric(sellPrice.Text) && Convert.ToSingle(sellPrice.Text) > 0)
                                    multiplier.Text = itemMultiplier.ToString();
                                else
                                    whMultiplier.Text = itemMultiplier.ToString();
                            }
                            break;
                        }
                    directCost.Text = productCost.ToString();

                    Calculate_Contract_Totals();

                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nPlease delete this sku and re-enter.");
            }
        }

        private void grid1_Click(object sender, EventArgs e)
        {
            try
            {
                resetEntryFields();

                curRow = -1;

                multiplier.Text = multiplier_c.ToString();
                whMultiplier.Text = multiplier_wh.ToString();

                Calculate_Contract_Totals();
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            submit_Contract(false);
        }

        public void submit_Contract(bool email)
        {
            string results, strData, marginList, cPriceList, rebateList, unitList, warehousePriceList, qtyList, sPriceList, costList, descList, skuList, multList, multOverList, charCode;
            char[] c1;
            int x, y, currentUnitID, currentMultOverride;
            float currentWHPrice, currentCost, currentMult;
            string emailAddressSeparator = "";

            c1 = new char[1];
            c1[0] = (char)25;
            charCode = new string(c1);

            try
            {
                if (grid1.Rows.Count < 1)
                {
                    MessageBox.Show("Error: No units on contract.");
                    return;
                }

                unitList = "";
                costList = "";
                warehousePriceList = "";
                qtyList = "";
                sPriceList = "";
                descList = "";
                skuList = "";
                marginList = "";
                cPriceList = "";
                rebateList = "";
                multList = "";
                multOverList = "";

                for (x = 0; x < grid1.Rows.Count; x++)
                {
                    currentUnitID = 0;
                    currentWHPrice = 0.0f;
                    currentCost = 0.0f;
                    currentMult = 1.0f;
                    currentMultOverride = 0;

                    for (y = 0; y < itemsList.Count; ++y)
                        if (itemsList[y].rowID == x)
                        {
                            currentUnitID = itemsList[y].unitID;
                            currentWHPrice = itemsList[y].warehousePrice;
                            currentCost = itemsList[y].productCost;
                            currentMult = itemsList[y].multiplier;
                            currentMultOverride = itemsList[y].multiplierOverriden ? 1 : 0;
                            break;
                        }

                    unitList = unitList + "," + currentUnitID.ToString();
                    costList = costList + "," + currentCost;
                    warehousePriceList = warehousePriceList + "," + currentWHPrice.ToString();
                    skuList = skuList + "," + grid1.Rows[x].Cells[1].Value.ToString().Replace(",", charCode);
                    descList = descList + "," + grid1.Rows[x].Cells[2].Value.ToString().Replace(",", charCode);
                    qtyList = qtyList + "," + grid1.Rows[x].Cells[3].Value.ToString().Replace(",", charCode);
                    sPriceList = sPriceList + "," + grid1.Rows[x].Cells[4].Value.ToString().Replace(",", charCode);
                    marginList = marginList + "," + grid1.Rows[x].Cells[5].Value.ToString().Replace(",", charCode);
                    cPriceList = cPriceList + "," + grid1.Rows[x].Cells[6].Value.ToString().Replace(",", charCode);
                    rebateList = rebateList + "," + grid1.Rows[x].Cells[8].Value.ToString().Replace(",", charCode);
                    multList = multList + "," + currentMult;
                    multOverList = multOverList + "," + currentMultOverride;
                }

                unitList = unitList.Substring(1, unitList.Length - 1);
                costList = costList.Substring(1, costList.Length - 1);
                warehousePriceList = warehousePriceList.Substring(1, warehousePriceList.Length - 1);
                qtyList = qtyList.Substring(1, qtyList.Length - 1);
                sPriceList = sPriceList.Substring(1, sPriceList.Length - 1);
                descList = descList.Substring(1, descList.Length - 1);
                skuList = skuList.Substring(1, skuList.Length - 1);
                marginList = marginList.Substring(1, marginList.Length - 1);
                cPriceList = cPriceList.Substring(1, cPriceList.Length - 1);
                rebateList = rebateList.Substring(1, rebateList.Length - 1);
                multList = multList.Substring(1, multList.Length - 1);
                multOverList = multOverList.Substring(1, multOverList.Length - 1);

                strData = "f_companyID=" + companyID.ToString();
                strData = strData + "&f_multiplier_c=" + util_functions.urlEncoded(multiplier_c.ToString());
                strData = strData + "&f_multiplier_wh=" + util_functions.urlEncoded(multiplier_wh.ToString());
                strData = strData + "&f_contractTotal=" + orderTotal.Text;
                strData = strData + "&f_totalDiscount=" + DiscountTotal.Text;
                strData = strData + "&f_totalDirectCost=" + DirectCostTotal.Text;
                strData = strData + "&f_locationID=" + locationID.ToString();
                strData = strData + "&f_contractID=" + contractNum.ToString();
                strData = strData + "&f_customerNum=" + util_functions.urlEncoded(cNum.Text);
                strData = strData + "&f_unitList=" + util_functions.urlEncoded(unitList);
                strData = strData + "&f_costList=" + util_functions.urlEncoded(costList);
                strData = strData + "&f_warehousePriceList=" + util_functions.urlEncoded(warehousePriceList);
                strData = strData + "&f_qtyList=" + util_functions.urlEncoded(qtyList);
                strData = strData + "&f_sPriceList=" + util_functions.urlEncoded(sPriceList);
                strData = strData + "&f_descList=" + util_functions.urlEncoded(descList);
                strData = strData + "&f_skuList=" + util_functions.urlEncoded(skuList);
                strData = strData + "&f_marginList=" + util_functions.urlEncoded(marginList);
                strData = strData + "&f_cPriceList=" + util_functions.urlEncoded(cPriceList);
                strData = strData + "&f_rebateList=" + util_functions.urlEncoded(rebateList);
                strData = strData + "&f_multiplier=" + util_functions.urlEncoded(multList);
                strData = strData + "&f_multiplierOverridden=" + util_functions.urlEncoded(multOverList);
                strData = strData + "&f_notes=" + util_functions.urlEncoded(locNotes.Text);

                strData = strData + "&f_salesMgr=" + util_functions.urlEncoded(salesMgr.Text);
                strData = strData + "&f_accountRep=" + util_functions.urlEncoded(accountRep.Text);
                strData = strData + "&f_cName=" + util_functions.urlEncoded(contractorsName.Text);
                strData = strData + "&f_cLocation=" + util_functions.urlEncoded(contractorsLocation.Text);
                strData = strData + "&f_royalVolume=" + util_functions.urlEncoded(royalVolume.Text);
                strData = strData + "&f_existingContract=" + util_functions.urlEncoded(newContract.Text);

                strData = strData + "&f_effectiveDate=" + util_functions.urlEncoded(contractEffDate.Text);
                strData = strData + "&f_branch=" + util_functions.urlEncoded(distribBranch.Text);
                strData = strData + "&f_accountNum=" + util_functions.urlEncoded(contractorsAct.Text);
                strData = strData + "&f_wholesaler=" + util_functions.urlEncoded(competingWholesaler.Text);
                strData = strData + "&f_manufacturer=" + util_functions.urlEncoded(competingMfgr.Text);
                strData = strData + "&f_contractLength=" + util_functions.urlEncoded(contractLen.Text);

                strData = strData + "&f_shipping=" + util_functions.urlEncoded(materialShipping.Items[materialShipping.SelectedIndex].ToString());
                strData = strData + "&f_secured=" + util_functions.urlEncoded(yesNoBusiness.Items[yesNoBusiness.SelectedIndex].ToString());
                strData = strData + "&f_fullLine=" + util_functions.urlEncoded(yesNoBuy.Items[yesNoBuy.SelectedIndex].ToString());


                if (contractNum > 0)
                    results = util_functions.Post_Web_Form("/admin/vb_Contract_Update.cfm", strData);
                else
                    results = util_functions.Post_Web_Form("/admin/vb_Contract_Submit.cfm", strData);


                //   *****************************
                //   Check result for order status
                //   *****************************

                x = results.IndexOf("<>");
                if (x > -1)
                {
                    results = results.Substring(x + 2);

                    if (util_functions.isnumeric(results))
                    {
                        if (email)
                        {
                            if (Form1.EmailDialog.IsDisposed)
                                Form1.EmailDialog = new Email();

                            Form1.EmailDialog.email = contractEmail.Text;
                            if (Form1.EmailDialog.email.Trim().Length > 0 && Form1.contractEmailList.Trim().Length > 0)
                                emailAddressSeparator = ",";
                            Form1.EmailDialog.email = Form1.EmailDialog.email + emailAddressSeparator + Form1.contractEmailList;

                            Form1.EmailDialog.ShowDialog();

                            if (Form1.EmailDialog.returnValue)
                            {
                                strData = "f_email=" + util_functions.urlEncoded(Form1.EmailDialog.email.Trim());
                                strData = strData + "&f_contractID=" + results.ToString();
                                util_functions.Post_Web_Form("/admin/vb_Contract_Email.cfm", strData);
                            }
                        }

                        resetForm();
                    }
                    else
                        MessageBox.Show("Error occured during the contract submission. - " + results);
                }
                else
                    MessageBox.Show("Invalid contract number in response code.  Please verify the contract was submitted correctly.");

            }
            catch (Exception e)
            {
                MessageBox.Show("An error has occured.\n\n" + e.Message + "\n\nThis contract may have been submitted to the system before the error occured.  Please verify the contract was not received before submitting again.");

            }
        }

        public void Load_Contract(string contractID)
        {
            int a, monthlyTempQty;
            float contractTempPrice, whTempPrice;
            bool errorLoading;
            string errMsg;

            SqlDataReader rdr2 = null;

            if (itemsList.Count > 0)
                itemsList.RemoveRange(0, itemsList.Count);

            errMsg = "";
            errorLoading = false;

            SqlCommand cmd = new SqlCommand("select contracts.*,contracts.ct as contractID,location.customernum,location.priceID from contracts left outer join location on contracts.locationid = location.ct where contracts.ct = " + contractID, conn);

            rdr2 = cmd.ExecuteReader();
            if (rdr2.HasRows && rdr2.Read())
            {
                resetForm();
                autoUpdateCustomerInfo = false;
                locNotes.Text = rdr2["notes"].ToString();
                contractNum = Convert.ToInt16(rdr2["contractID"].ToString());
                cNum.Text = rdr2["customerNum"].ToString();
                locationID = Convert.ToInt16(rdr2["locationID"].ToString());
                companyID = Convert.ToInt16(rdr2["companyID"].ToString());

                orderTotal.Text = rdr2["contractTotal"].ToString();
                DiscountTotal.Text = rdr2["totalDiscount"].ToString();
                DirectCostTotal.Text = rdr2["totalDirectCost"].ToString();

                salesMgr.Text = rdr2["salesMgr"].ToString();
                accountRep.Text = rdr2["accountRep"].ToString();
                contractorsName.Text = rdr2["cName"].ToString();
                contractorsLocation.Text = rdr2["cLocation"].ToString();
                royalVolume.Text = rdr2["royalVolume"].ToString();
                newContract.Text = rdr2["existingContract"].ToString();

                contractEffDate.Text = rdr2["effectiveDate"].ToString();
                distribBranch.Text = rdr2["branch"].ToString();
                contractorsAct.Text = rdr2["accountNum"].ToString();
                competingWholesaler.Text = rdr2["wholesaler"].ToString();
                competingMfgr.Text = rdr2["manufacturer"].ToString();
                contractLen.Text = rdr2["contractLength"].ToString();

                multiplier.Text = rdr2["multiplier_c"].ToString();
                whMultiplier.Text = rdr2["multiplier_wh"].ToString();

                if (util_functions.isnumeric(multiplier.Text))
                    multiplier_c = Convert.ToSingle(multiplier.Text);
                if (util_functions.isnumeric(whMultiplier.Text))
                    multiplier_wh = Convert.ToSingle(whMultiplier.Text);

                materialShipping.SelectedIndex = 0;
                for (a = 0; a < materialShipping.Items.Count; ++a)
                    if (string.Compare(materialShipping.Items[a].ToString(), rdr2["shipping"].ToString()) == 0)
                    {
                        materialShipping.SelectedIndex = a;
                        break;
                    }
                yesNoBusiness.SelectedIndex = 0;
                for (a = 0; a < yesNoBusiness.Items.Count; ++a)
                    if (string.Compare(yesNoBusiness.Items[a].ToString(), rdr2["secured"].ToString()) == 0)
                    {
                        yesNoBusiness.SelectedIndex = a;
                        break;
                    }
                yesNoBuy.SelectedIndex = 0;
                for (a = 0; a < yesNoBuy.Items.Count; ++a)
                    if (string.Compare(yesNoBuy.Items[a].ToString(), rdr2["fullLine"].ToString()) == 0)
                    {
                        yesNoBuy.SelectedIndex = a;
                        break;
                    }

                if (util_functions.isnumeric(rdr2["priceID"].ToString()))
                    priceCode = Convert.ToInt16(rdr2["priceID"].ToString());
                else
                    priceCode = 0;

                customerNumberChanged(true);

                autoUpdateCustomerInfo = true;

                rdr2.Close();
            }
            else
            {
                MessageBox.Show("An error was encountered while loading this contract. The contract was not found.\r\n");
                return;
            }


            cmd = new SqlCommand("select contractSkus.*,units.ct as unitsCt, units.cost as ucost from contractSkus left outer join units on contractSkus.unitid = units.ct where contractSkus.active=1 and contractSkus.contractid = " + contractID, conn);
            rdr2 = cmd.ExecuteReader();

            if (rdr2.HasRows)
                while (rdr2.Read())
                {
                    try
                    {
                        productCost = 0.0f;
                        unitID = 0;
                        if (util_functions.isnumeric(rdr2["unitsCt"].ToString()))
                        {
                            unitID = Convert.ToInt16(rdr2["unitsCt"].ToString());
                            if (util_functions.isnumeric(rdr2["cost"].ToString()))
                                productCost = Convert.ToSingle(rdr2["cost"].ToString());
                            else if (util_functions.isnumeric(rdr2["ucost"].ToString()))
                                productCost = Convert.ToSingle(rdr2["ucost"].ToString());
                        }

                        warehousePrice = Convert.ToSingle(rdr2["warehousePrice"].ToString());

                        a = grid1.Rows.Add();
                        currentItem.rowID = (ushort)a;
                        currentItem.unitID = unitID;
                        currentItem.multiplierOverriden = false;
                        currentItem.productCost = productCost;
                        currentItem.warehousePrice = warehousePrice;
                        currentItem.multiplierOverriden = Convert.ToBoolean(rdr2["multiplierOverridden"].ToString());
                        currentItem.multiplier = Convert.ToSingle(rdr2["multiplier"].ToString());

                        monthlyTempQty = Convert.ToInt32(rdr2["qty"].ToString());
                        contractTempPrice = Convert.ToSingle(rdr2["contractPrice"].ToString());
                        whTempPrice = Convert.ToSingle(rdr2["warehousePrice"].ToString());

                        itemsList.Add(currentItem);

                        grid1.Rows[a].Cells[0].Value = rdr2["sku"].ToString();
                        grid1.Rows[a].Cells[1].Value = rdr2["sku"].ToString();
                        grid1.Rows[a].Cells[2].Value = rdr2["descrip"].ToString();
                        grid1.Rows[a].Cells[3].Value = monthlyTempQty.ToString();
                        grid1.Rows[a].Cells[4].Value = rdr2["sellPrice"].ToString();
                        grid1.Rows[a].Cells[5].Value = rdr2["margin"].ToString();
                        grid1.Rows[a].Cells[6].Value = rdr2["contractPrice"].ToString();
                        grid1.Rows[a].Cells[7].Value = warehousePrice.ToString();
                        grid1.Rows[a].Cells[8].Value = rdr2["rebate"].ToString();
                        grid1.Rows[a].Cells[9].Value = productCost.ToString();
                        grid1.Rows[a].Cells[10].Value = util_functions.roundNumber(productCost * monthlyTempQty, 2).ToString();
                        grid1.Rows[a].Cells[11].Value = util_functions.roundNumber(productCost / contractTempPrice, 2).ToString();
                        grid1.Rows[a].Cells[12].Value = util_functions.roundNumber(contractTempPrice * monthlyTempQty, 2).ToString();
                        grid1.Rows[a].Cells[13].Value = util_functions.roundNumber(whTempPrice * monthlyTempQty, 2).ToString();

                    }
                    catch (Exception e)
                    {
                        errMsg = e.Message;
                        errorLoading = true;
                    }
                }

            if (grid1.Rows.Count > 11)
                grid1.FirstDisplayedScrollingRowIndex = grid1.Rows.Count - 12;

            if (errorLoading)
                MessageBox.Show("An error was encountered while loading this contract. Not all items were loaded correctly.\r\n" + errMsg);

            if (grid1.Rows.Count > 11)
                grid1.FirstDisplayedScrollingRowIndex = grid1.Rows.Count - 12;

            rdr2.Close();

            Calculate_Contract_Totals();

        }

        public void Calculate_Contract_Totals()
        {
            int a, b, qty;
            float sPrice, cPrice, wPrice, pCost;
            float totalAmount, Contract_Ext_Total = 0.0f, WH_Ext_Total = 0.0f, DC_Ext_Total = 0.0f, Total_Discount = 0.0f, totalDirectCost = 0.0f;

            totalAmount = 0.0f;

            for (a = 0; a < grid1.Rows.Count; a++)
            {
                wPrice = 0.0f;
                pCost = 0.0f;
                for (b = 0; b < itemsList.Count; ++b)
                    if (itemsList[b].rowID == a)
                    {
                        wPrice = itemsList[b].warehousePrice;
                        pCost = itemsList[b].productCost;
                        break;
                    }

                qty = Convert.ToInt16(grid1.Rows[a].Cells[3].Value.ToString());
                cPrice = Convert.ToSingle(grid1.Rows[a].Cells[6].Value.ToString());
                sPrice = Convert.ToSingle(grid1.Rows[a].Cells[4].Value.ToString());

                if (grid1.Rows[a].Cells[10].Value != null && util_functions.isnumeric(grid1.Rows[a].Cells[10].Value.ToString()))
                    DC_Ext_Total = DC_Ext_Total + Convert.ToSingle(grid1.Rows[a].Cells[10].Value.ToString());
                if (grid1.Rows[a].Cells[12].Value != null && util_functions.isnumeric(grid1.Rows[a].Cells[12].Value.ToString()))
                    Contract_Ext_Total = Contract_Ext_Total + Convert.ToSingle(grid1.Rows[a].Cells[12].Value.ToString());
                if (grid1.Rows[a].Cells[13].Value != null && util_functions.isnumeric(grid1.Rows[a].Cells[13].Value.ToString()))
                    WH_Ext_Total = WH_Ext_Total + Convert.ToSingle(grid1.Rows[a].Cells[13].Value.ToString());

                totalDirectCost = totalDirectCost + (pCost * qty) / (cPrice * qty);
                totalAmount = totalAmount + qty * sPrice;
            }

            DirectCostTotal.Text = totalDirectCost.ToString();
            orderTotal.Text = totalAmount.ToString();

            if (WH_Ext_Total != 0.0f)
                Total_Discount = Contract_Ext_Total / WH_Ext_Total;
            else
                Total_Discount = 0.0f;
            DiscountTotal.Text = Total_Discount.ToString();

            dcExtGrandTotal.Text = "DC Ext Total:\n" + util_functions.roundNumber(DC_Ext_Total, 2).ToString();
            contractExtGrandTotal.Text = "Contract Ext:\n" + util_functions.roundNumber(Contract_Ext_Total, 2).ToString();
            whExtGrandTotal.Text = "WH Ext:\n" + util_functions.roundNumber(WH_Ext_Total, 2).ToString();

        }

        public void Set_Contract_ID(string contractID)
        {
            contract_ID = contractID;
        }

        public void Update_Contract_Form()
        {
            contractNum = 0;

            if (string.Compare(contract_ID, "") != 0)
            {
                Load_Contract(contract_ID);
                button3.Text = "Update Only";
                button4.Text = "Update and E-mail";
            }
            else
            {
                button3.Text = "Save Only";
                button4.Text = "Save and E-mail";
            }

            Calculate_Contract_Totals();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            submit_Contract(true);

        }

        private void multiplier_KeyUp(object sender, KeyEventArgs e)
        {
            // When entering a number, there may be points where the value is not numeric such as when entering 0.5 and you have just entered 0. but not the final 5
            if (!util_functions.isnumeric(multiplier.Text))
                return;

            if (e.KeyCode == Keys.Enter)
            {
                whMultiplier.Focus();
                return;
            }

            Update_Contract_Price(false);
            if (curRow < 0)   // Only update the contract skus if we're not in edit mode
            {
                multiplier_c = Convert.ToSingle(multiplier.Text);
                Update_Skus_For_New_Multiplier();
            }
        }

        public void Update_Contract_Price(bool showError)
        {
            float f1;

            if (util_functions.isnumeric(sellPrice.Text) && Convert.ToSingle(sellPrice.Text) > 0)
            {
                if (util_functions.isnumeric(multiplier.Text))
                {
                    itemMultiplier = Convert.ToSingle(multiplier.Text);
                    if (curRow > -1 && itemMultiplier != multiplier_c)
                        cMultiplierOverriden = true;
                    f1 = Convert.ToSingle(sellPrice.Text) * itemMultiplier;
                    f1 = (float)Math.Round(f1, 2);
                    contractPrice.Text = String.Format("{0:0.00}", f1);
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                    multiplier.Focus();
                }
            }
            else if (util_functions.isnumeric(whMultiplier.Text) && warehousePrice > 0)
            {
                itemMultiplier = Convert.ToSingle(whMultiplier.Text);
                if (curRow > -1 && itemMultiplier != multiplier_wh)
                    cMultiplierOverriden = true;
                f1 = warehousePrice * itemMultiplier;

                f1 = (float)Math.Round(f1, 2);
                contractPrice.Text = String.Format("{0:0.00}", f1);
            }
            else if (showError)
                MessageBox.Show("Either the sell price must be non zero with a valid contract multiplier or the warehouse price must be non zero with a valid warehouse multiplier.");

        }

        private void whMultiplier_KeyUp(object sender, KeyEventArgs e)
        {
            // When entering a number, there may be points where the value is not numeric such as when entering 0.5 and you have just entered 0. but not the final 5
            if (!util_functions.isnumeric(whMultiplier.Text))
                return;

            if (e.KeyCode == Keys.Enter)
            {
                sku.Focus();
                return;
            }

            Update_Contract_Price(false);

            if (curRow < 0)   // Only update the contract skus if we're not in edit mode
            {
                multiplier_c = Convert.ToSingle(whMultiplier.Text);
                Update_Skus_For_New_Multiplier();
            }
        }

        public void Update_Skus_For_New_Multiplier()
        {
            int x, y;
            string tempSellPrice;

            for (x = 0; x < grid1.Rows.Count; x++)
            {
                for (y = 0; y < itemsList.Count; ++y)
                    if (itemsList[y].rowID == x)
                    {
                        if (!itemsList[y].multiplierOverriden)
                        {
                            tempSellPrice = grid1.Rows[x].Cells[4].Value.ToString();
                            if (util_functions.isnumeric(tempSellPrice) && Convert.ToSingle(tempSellPrice) > 0)
                                grid1.Rows[x].Cells[6].Value = Convert.ToSingle(tempSellPrice) * Convert.ToSingle(multiplier.Text);
                            else
                                grid1.Rows[x].Cells[6].Value = itemsList[y].warehousePrice * Convert.ToSingle(whMultiplier.Text);
                        }
                        break;
                    }
            }
        }

        public bool Validate_Multipliers()
        {
            if (!util_functions.isnumeric(multiplier.Text))
            {
                MessageBox.Show("Please enter a valid multiplier.");
                multiplier.Focus();
                return false;
            }

            if (!util_functions.isnumeric(whMultiplier.Text))
            {
                MessageBox.Show("Please enter a valid warehouse multiplier.");
                whMultiplier.Focus();
                return false;
            }

            return true;
        }

        private void contractPrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && util_functions.isnumeric(monthlyQty.Text) && util_functions.isnumeric(sellPrice.Text))
                Add_Item_To_Grid();
        }

        private void directCost_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (util_functions.isnumeric(directCost.Text))
                {
                    productCost = Convert.ToSingle(directCost.Text);

                    if (util_functions.isnumeric(monthlyQty.Text) && util_functions.isnumeric(sellPrice.Text))
                        Add_Item_To_Grid();
                }
            }
        }

        private void whPrice_KeyUp(object sender, KeyEventArgs e)
        {
            if (!util_functions.isnumeric(whPrice.Text))
                return;

            warehousePrice = Convert.ToSingle(whPrice.Text);
            Update_Contract_Price(true);

            if (e.KeyCode == Keys.Enter)
            {
                monthlyQty.Focus();
            }
        }

        private void Contracts_Resize(object sender, EventArgs e)
        {
            Set_Grid_Column_Sizes();
        }

    }
}
