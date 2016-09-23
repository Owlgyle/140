using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Orders : Form
    {
        public struct orderItem
        {
            public byte discrepancy;
            public ushort rowID;
        }

        public static int priceCode, ns, curRow, boxCount, qtyAdjustment, boxesPerPallet, pipeLen, locationID, companyID, unitID, numItems;
        public static int[] shippingArray = new int[1] { 0 };
        public static float curCube, totalCubes, totalAmount, palletCubes, qtyConversion, tempCubes, tempAmount, skuPrice, palletPrice;
        public static bool alteredCubes, PipeUnitPricing, printNewOrder, poFaxNow;
        public static string pofaxEmail, pofaxFaxNum, pofaxNotes, pofaxContact;
        public static byte currentDiscrepancy = 0;
        public static orderItem currentItem;
        List<orderItem> itemsList = new List<orderItem>();

        SqlConnection conn = new SqlConnection("Data Source=Romeo;Initial Catalog=Royal;User ID=royal;password=wkjwuq");
        SqlConnection conn2 = new SqlConnection("Data Source=Romeo;Initial Catalog=Royal;User ID=royal;password=wkjwuq");
        SqlDataReader rdr = null;

        public Orders()
        {
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            int x = 0, y = 0;

            conn.Open();
            conn2.Open();
            SqlCommand cmd = new SqlCommand("select * from shipping order by name asc", conn);
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    shipping.Items.Add(rdr["Name"].ToString());
                    temp.Items.Add(rdr["ct"].ToString());
                    if (rdr["defaultmethod"].Equals(true))
                        x = y;
                    y++;
                }
            }

            if (shipping.Items.Count > 0)
            {
                shipping.SelectedIndex = x;
                shippingArray = new int[shipping.Items.Count];
                for (x = 0; x < shipping.Items.Count; x++)
                    shippingArray[x] = Convert.ToInt32(temp.Items[x]);
            }

            if (rdr != null)
                rdr.Close();

            grid1.Rows.Clear();
            curRow = -1;

            Set_Order_Date();

            Set_Grid_Column_Sizes();

        }

        public void Set_Window_Size(int x, int y)
        {
            this.Width = x;
            this.Height = y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetForm();
            this.Hide();
        }

        private void Orders_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (rdr != null)
                rdr.Close();

            if (conn != null)
                conn.Close();

            if (conn2 != null)
                conn2.Close();
        }

        public void resetForm()
        {

            cubeCount.Text = "0";
            orderTotal.Text = "0";

            totalCubes = 0;
            totalAmount = 0;


            cNum.Text = "";
            poNum.Text = "";
            sku.Text = "";
            qty.Text = "";
            Label9.Text = "";
            quoteNum.Text = "";

            grid1.Rows.Clear();
            curRow = -1;

            Set_Order_Date();
        }

        public void Set_Order_Date()
        {
            DateTime curDate;

            if (DateTime.Now.Hour >= 14)
                curDate = DateTime.Now.AddDays(1);
            else
                curDate = DateTime.Now;

            if (curDate.DayOfWeek == DayOfWeek.Sunday)
                curDate = curDate.AddDays(1);
            else if (curDate.DayOfWeek == DayOfWeek.Saturday)
                curDate = curDate.AddDays(2);

            oDate.Text = curDate.ToShortDateString();
        }

        public void faxConfirmation(string orderID)
        {
            int x;
            string results, strData;

            try
            {
                strData = "&fax=" + util_functions.urlEncoded(pofaxFaxNum);
                strData = strData + "&email=" + util_functions.urlEncoded(pofaxEmail.Trim());
                strData = strData + "&notes=" + util_functions.urlEncoded(pofaxNotes.Trim());
                strData = strData + "&orderID=" + util_functions.urlEncoded(orderID.Trim());
                strData = strData + "&companyID=" + util_functions.urlEncoded(companyID.ToString().Trim());
                strData = strData + "&locationID=" + util_functions.urlEncoded(locationID.ToString().Trim());
                strData = strData + "&custname=" + util_functions.urlEncoded(sName.Text.Trim());
                strData = strData + "&custcontact=" + util_functions.urlEncoded(pofaxContact.Trim());
                if (poFaxNow)
                    strData = strData + "&status=1";
                else
                    strData = strData + "&status=0";

                results = util_functions.Post_Web_Form("/admin/VB_Fax_POConfirmation.cfm", strData);

                x = results.IndexOf("fax received");
                if (x < 0)
                    MessageBox.Show("Error: PO Fax Confirmation was not successfully sent.");

            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nAn Error Occured while sending a po fax confirmation.");
            }
        }

        public void submitOrder()
        {
            int x, y, currentDiscrepancy;
            string results, strData, unitList, priceList, qtyList, descList, discrepancyList;

            try
            {
                if (grid1.Rows.Count < 1)
                {
                    MessageBox.Show("Error: No units on order.");
                    return;
                }

                poFaxNow = true;
                if (Form1.fax.IsDisposed)
                    Form1.fax = new Fax();
                Form1.fax.set_Conf_Email(pofaxEmail);
                Form1.fax.set_Conf_Fax(pofaxFaxNum);
                Form1.fax.set_Conf_Contact(pofaxContact);
                Form1.fax.ShowDialog();

                numItems = 0;
                unitList = "";
                descList = "";
                qtyList = "";
                priceList = "";
                discrepancyList = "";

                for (x = 0; x < grid1.Rows.Count; x++)
                {
                    if ((int)grid1.Rows[x].Cells[0].Value == 0)
                        unitList = unitList + ",-" + grid1.Rows[x].Cells[1].Value.ToString().Trim().Replace(",", Convert.ToChar(25).ToString());
                    else
                        unitList = unitList + "," + grid1.Rows[x].Cells[0].Value.ToString().Trim().Replace(",", Convert.ToChar(25).ToString());
                    descList = descList + "," + grid1.Rows[x].Cells[2].Value.ToString().Trim().Replace(",", Convert.ToChar(25).ToString());
                    qtyList = qtyList + "," + grid1.Rows[x].Cells[3].Value.ToString().Trim().Replace(",", Convert.ToChar(25).ToString());
                    priceList = priceList + "," + grid1.Rows[x].Cells[4].Value.ToString().Trim().Replace(",", Convert.ToChar(25).ToString());

                    for (y = 0, currentDiscrepancy = 0; y < itemsList.Count; ++y)
                        if (itemsList[y].rowID == x)
                        {
                            currentDiscrepancy = itemsList[y].discrepancy;
                            break;
                        }
                    discrepancyList = discrepancyList + "," + currentDiscrepancy;

                    numItems = numItems + 1;

                }

                unitList = unitList.Substring(1, unitList.Length - 1);
                descList = descList.Substring(1, descList.Length - 1);
                qtyList = qtyList.Substring(1, qtyList.Length - 1);
                priceList = priceList.Substring(1, priceList.Length - 1);
                discrepancyList = discrepancyList.Substring(1, discrepancyList.Length - 1);

                strData = "f_shippingId=" + shippingArray[shipping.SelectedIndex];
                strData = strData + "&f_poNum=" + util_functions.urlEncoded(poNum.Text);
                strData = strData + "&f_companyID=" + companyID.ToString();
                strData = strData + "&f_locationID=" + locationID.ToString();
                strData = strData + "&f_orderDate=" + util_functions.urlEncoded(oDate.Text);
                strData = strData + "&f_unitList=" + util_functions.urlEncoded(unitList);
                strData = strData + "&f_priceList=" + util_functions.urlEncoded(priceList);
                strData = strData + "&f_qtyList=" + util_functions.urlEncoded(qtyList);
                strData = strData + "&f_descList=" + util_functions.urlEncoded(descList);
                strData = strData + "&f_discrepancyList=" + util_functions.urlEncoded(discrepancyList);
                strData = strData + "&f_shipto=" + util_functions.urlEncoded(sName.Text);
                strData = strData + "&f_addr1=" + util_functions.urlEncoded(sAddr1.Text);
                strData = strData + "&f_addr2=" + util_functions.urlEncoded(sAddr2.Text);
                strData = strData + "&f_city=" + util_functions.urlEncoded(sCity.Text);
                strData = strData + "&f_State=" + util_functions.urlEncoded(sState.Text);
                strData = strData + "&f_zip=" + util_functions.urlEncoded(sZip.Text);

                // These 4 are used for submitting a PO Confirmation entry in case the order has a 0 price error. If the order is submitted with a 0 price, an error is returned and the desktop app does not try to submit a PO conf.
                strData = strData + "&f_fax=" + util_functions.urlEncoded(pofaxFaxNum); 
                strData = strData + "&f_email=" + util_functions.urlEncoded(pofaxEmail.Trim());
                strData = strData + "&f_notes=" + util_functions.urlEncoded(pofaxNotes.Trim());
                strData = strData + "&f_custname=" + util_functions.urlEncoded(sName.Text.Trim());
                strData = strData + "&f_custcontact=" + util_functions.urlEncoded(pofaxContact.Trim());


                results = util_functions.Post_Web_Form("/admin/vb_Order_Submit5.cfm", strData);

                x = results.IndexOf("<>");
                if (x >= 0 && results.Length > x + 2)
                {
                    results = results.Substring(x + 2, results.Length - x - 2);
                    if (util_functions.isnumeric(results))
                    {
                        lastOrder.Text = results;
                        if (printNewOrder)
                        {
                            Form1.printMsg.SetMsg("Printing order # " + results + " with " + numItems.ToString() + " items.");
                            Form1.printMsg.Show();
                            util_functions.Print_Order(results, Form1.p1, 2);
                            Form1.printMsg.Hide();
                        }

                        faxConfirmation(results);
                        resetForm();
                    }
                    else
                        MessageBox.Show("Error occured during order submission. " + results);
                }
                else
                    MessageBox.Show("Invalid order number in response code.  Please verify the order was submitted correctly.");
            }
            catch (Exception e)
            {
                MessageBox.Show("An error has occured.\n\n" + e.Message + "\n\nThis order may have been submitted to the system before the error occured.  Please verify the order was not received before submitting again.");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printNewOrder = true;
            submitOrder();
            cNum.Focus();
        }

        private void Sku_Key_Up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                qty.Focus();
        }

        private void sku_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("select Units.*, unit_price.price, unit_price.palletprice, Unit_Qty_Conversions.multiplier from (Units inner join  Unit_Price on Units.ct = Unit_Price.unitID) left outer join  Unit_Qty_Conversions on Units.ct = Unit_Qty_Conversions.unitID where sku='" + sku.Text + "' And unit_price.priceID = " + priceCode.ToString() + " and ( Unit_Qty_Conversions.locationID = " + locationID.ToString() + " or Unit_Qty_Conversions.locationID = NULL )", conn);
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    if (util_functions.isnumeric(rdr["multiplier"].ToString()))
                    {
                        qtyConversion = Convert.ToSingle(rdr["multiplier"].ToString());
                    }
                    else
                        qtyConversion = 1;

                    rdr.Close();
                    rdr = cmd.ExecuteReader();
                }
                else
                {
                    cmd = new SqlCommand("select Units.*, unit_price.price, unit_price.palletprice from Units inner join  Unit_Price on Units.ct = Unit_Price.unitID where sku='" + sku.Text + "' And unit_price.priceID = " + priceCode.ToString(), conn);
                    rdr.Close();
                    rdr = cmd.ExecuteReader();
                    qtyConversion = 1;
                }

                qty.Enabled = true;

                if (rdr.HasRows)
                {
                    rdr.Read();
                    if (rdr["active"].Equals(false))
                    {
                        qty.Enabled = false;
                        MessageBox.Show("The sku you selected has been marked inactive and cannot be entered.");
                        if (rdr != null)
                            rdr.Close();
                        return;
                    }

                    unitID = Convert.ToInt32(rdr["ct"].ToString());
                    nstock.Text = rdr["descrip"].ToString();

                    qtyAdjustment = Convert.ToInt32(rdr["qtyAdjustment"]);
                    boxCount = Convert.ToInt32(rdr["box"]);
                    boxesPerPallet = Convert.ToInt32(rdr["pallets"]);
                    pipeLen = Convert.ToInt32(rdr["Len"]);

                    if (PipeUnitPricing && pipeLen > 0)
                    {
                        skuPrice = Convert.ToSingle(rdr["price"]) * pipeLen;
                        price.Text = skuPrice.ToString();
                        palletPrice = Convert.ToSingle(rdr["palletprice"]) * pipeLen;
                    }
                    else
                    {
                        skuPrice = Convert.ToSingle(rdr["price"]);
                        price.Text = skuPrice.ToString();
                        palletPrice = Convert.ToSingle(rdr["palletprice"]);
                    }

                    if (!alteredCubes)
                    {
                        curCube = Convert.ToSingle(rdr["cubes"]);
                        palletCubes = Convert.ToInt32(rdr["palletCubes"]);
                    }
                    else
                    {
                        curCube = Convert.ToSingle(rdr["cubes2"]);
                        palletCubes = 0;
                    }

                    nstock.Enabled = false;
                    price.Enabled = false;
                    ns = 0;
                    nstock.TabStop = false;
                    price.TabStop = false;
                }
                else
                {
                    unitID = 0;
                    boxCount = 1;
                    curCube = 0;
                    nstock.Text = "";
                    price.Text = "";
                    nstock.Enabled = true;
                    price.Enabled = true;
                    ns = 1;
                    nstock.TabStop = true;
                    price.TabStop = true;
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nPlease delete this sku and re-enter.");
            }

            if (rdr != null)
                rdr.Close();
        }

        private void cNum_Change(object sender, EventArgs e)
        {
            SqlCommand cmd;

            try
            {
                if (util_functions.isnumeric(cNum.Text))
                {
                    cmd = new SqlCommand("select * from location where customernum='" + cNum.Text.Trim() + "' and active<>0", conn);
                    rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        rdr.Read();

                        locationID = Convert.ToInt32(rdr["ct"]);
                        companyID = Convert.ToInt32(rdr["companyID"]);
                        sName.Text = rdr["Name"].ToString() + " ";
                        sAddr1.Text = rdr["addr1"].ToString() + " ";
                        sAddr2.Text = rdr["addr2"].ToString() + " ";
                        sCity.Text = rdr["city"].ToString() + " ";
                        sState.Text = rdr["State"].ToString() + " ";
                        sZip.Text = rdr["zip"].ToString() + " ";
                        pofaxEmail = rdr["POConf_email"].ToString() + " ";
                        pofaxFaxNum = rdr["POConf_Fax"].ToString() + " ";
                        pofaxContact = rdr["contact"].ToString() + " ";
                        PipeUnitPricing = rdr["PipeUnitPricing"].Equals(true);

                        locNotes.Text = rdr["orderNotes"].ToString().Trim();
                        locNotes.Visible = true;
                        if (locNotes.Text.Length == 0)
                            locNotes.Visible = false;

                        if (util_functions.isnumeric(rdr["priceID"].ToString()))
                            priceCode = Convert.ToInt32(rdr["priceID"].ToString());
                        else
                            priceCode = 0;

                        if (rdr["alteredCubes"].Equals(0))
                            alteredCubes = false;
                        else
                            alteredCubes = true;

                        sku.Enabled = true;
                        price.Enabled = true;
                        qty.Enabled = true;
                        nstock.Enabled = true;

                        if (rdr != null)
                            rdr.Close();
                        return;
                    }
                }

                locationID = 0;
                companyID = 0;
                sName.Text = "";
                sAddr1.Text = "";
                sAddr2.Text = "";
                sCity.Text = "";
                sState.Text = "";
                sZip.Text = "";
                sku.Enabled = false;
                price.Enabled = false;
                qty.Enabled = false;
                nstock.Enabled = false;
                alteredCubes = false;
                locNotes.Visible = false;
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured while loading the customer information.\n\n" + e1.Message);
            }

            if (rdr != null)
                rdr.Close();
        }

        public void Set_Price(string newPrice)
        {
            price.Text = newPrice;
        }

        public void Set_Quote_Pricing(string quoteNum)
        {
            int x,unitID;
            string sku;


            SqlCommand cmd = new SqlCommand("select * from QuoteSkus where quoteID = " + quoteNum, conn);

            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    sku = rdr["sku"].ToString();
                    unitID = Convert.ToInt32(rdr["unitID"].ToString());

                    for (x = 0; x < grid1.Rows.Count; x++)
                    {
                        // Check to see if it's a non stock or stock item
                        if ((int)grid1.Rows[x].Cells[0].Value == 0)
                        {
                            // Non stock item - match on the sku
                            if (sku == grid1.Rows[x].Cells[1].Value.ToString().Trim().Replace(",", Convert.ToChar(25).ToString()))
                            {
                                grid1.Rows[x].Cells[4].Value = rdr["price"].ToString();
                            }

                        }   // Stock Item - match on the unitID/ct values
                        else if (unitID == Convert.ToInt32(grid1.Rows[x].Cells[0].Value.ToString()))
                        {                            
                            grid1.Rows[x].Cells[4].Value = rdr["price"].ToString();
                        }
                    }                    
                }
            }
            else
            {
                MessageBox.Show("Error Retrieving Quote (" + quoteNum + ")");
            }

            if (rdr != null)
                rdr.Close();
        }

        private void Label9_Click(object sender, EventArgs e)
        {
            Label9.Text = "";
            curRow = -1;
            sku.Text = "";

            totalCubes = totalCubes + tempCubes;
            totalAmount = totalAmount + tempAmount;

            cubeCount.Text = totalCubes.ToString();
            orderTotal.Text = totalAmount.ToString();

            tempCubes = 0;
            tempAmount = 0;
        }

        private void grid1_KeyDown(object sender, KeyEventArgs e)
        {
            int x;

            try
            {
                if (e.KeyCode == Keys.Delete && grid1.CurrentRow.Index >= 0)
                {
                    Edit_Row();

                    grid1.Rows.RemoveAt(curRow);

                    unitID = 0;
                    qty.Text = "";
                    price.Text = "";
                    sku.Text = "";
                    curRow = -1;
                    tempCubes = 0;
                    tempAmount = 0;
                    Label9.Text = "";
                    cubeCount.Text = totalCubes.ToString();
                    orderTotal.Text = totalAmount.ToString();

                }
                else if (e.KeyCode == Keys.I && grid1.CurrentRow.Index >= 0)
                {
                    if (grid1.CurrentRow.Index < grid1.Rows.Count)
                    {
                        x = grid1.CurrentRow.Index;
                        grid1.Rows.Insert(x, 1);
                        grid1.Rows[x].Cells[0].Value = grid1.Rows[x + 1].Cells[0].Value;
                        grid1.Rows[x].Cells[1].Value = grid1.Rows[x + 1].Cells[1].Value;
                        grid1.Rows[x].Cells[2].Value = grid1.Rows[x + 1].Cells[2].Value;
                        grid1.Rows[x].Cells[3].Value = grid1.Rows[x + 1].Cells[3].Value;
                        grid1.Rows[x].Cells[4].Value = grid1.Rows[x + 1].Cells[4].Value;

                        sku.Text = grid1.Rows[x].Cells[1].Value.ToString();
                        qty.Text = grid1.Rows[x].Cells[3].Value.ToString();
                        price.Text = grid1.Rows[x].Cells[4].Value.ToString();
                        nstock.Text = grid1.Rows[x].Cells[2].Value.ToString();
                        Label9.Text = "Edit Mode";
                        curRow = x + 1;

                        x = Convert.ToInt32(qty.Text);
                        if (PipeUnitPricing && pipeLen > 0)
                            x = x * pipeLen;

                        if (x > 0)
                        {
                            if (x < boxCount)
                                x = boxCount;
                            if (x > boxCount)
                            {
                                x = ((int)(x / boxCount) * boxCount);
                                if (x < Convert.ToInt32(qty.Text))
                                    x = x + boxCount;
                            }
                        }

                        tempCubes = curCube * (x / boxCount);
                        if (boxesPerPallet > 0 && boxCount > boxesPerPallet)
                            tempCubes = tempCubes + (int)(boxCount / boxesPerPallet) * palletCubes;
                        tempAmount = x * Convert.ToSingle(price.Text);

                        sku.SelectAll();
                        sku.Focus();
                    }
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
            int x;

            try
            {
                if (grid1.CurrentRow.Index >= 0 && grid1.CurrentRow.Index < grid1.Rows.Count)
                {
                    x = grid1.CurrentRow.Index;
                    sku.Text = grid1.Rows[x].Cells[1].Value.ToString();
                    qty.Text = grid1.Rows[x].Cells[3].Value.ToString();
                    price.Text = grid1.Rows[x].Cells[4].Value.ToString();
                    nstock.Text = grid1.Rows[x].Cells[2].Value.ToString();
                    Label9.Text = "Edit Mode";
                    curRow = x;

                    x = Convert.ToInt32(qty.Text);
                    if (PipeUnitPricing && pipeLen > 0)
                        x = x * pipeLen;

                    if (x > 0)
                    {
                        if (x < boxCount)
                            x = boxCount;
                        if (x > boxCount)
                        {
                            x = ((int)(x / boxCount) * boxCount);
                            if (x < Convert.ToInt32(qty.Text))
                                x = x + boxCount;
                        }
                    }

                    tempCubes = curCube * (x / boxCount);

                    if (boxesPerPallet > 0 && boxCount > boxesPerPallet)
                        tempCubes = tempCubes + (int)(boxCount / boxesPerPallet) * palletCubes;

                    tempAmount = x * Convert.ToSingle(price.Text);
                    totalCubes = totalCubes - tempCubes;
                    totalAmount = totalAmount - tempAmount;

                    Clear_Row_Selection();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nPlease delete this description and re-enter.");
            }
        }

        public void Clear_Row_Selection()
        {
            if (grid1.CurrentRow.Index >= 0 && grid1.CurrentRow.Index < grid1.Rows.Count)
            {
                grid1.Rows[grid1.CurrentRow.Index].Cells[1].Selected = false;
                grid1.Rows[grid1.CurrentRow.Index].Cells[2].Selected = false;
                grid1.Rows[grid1.CurrentRow.Index].Cells[3].Selected = false;
                grid1.Rows[grid1.CurrentRow.Index].Cells[4].Selected = false;
            }
        }

        private void grid1_Click(object sender, EventArgs e)
        {
            try
            {
                unitID = 0;
                Label9.Text = "";
                qty.Text = "";
                price.Text = "";
                sku.Text = "";
                curRow = -1;

                totalCubes = totalCubes + tempCubes;
                totalAmount = totalAmount + tempAmount;

                cubeCount.Text = totalCubes.ToString();
                orderTotal.Text = totalAmount.ToString();

                tempCubes = 0;
                tempAmount = 0;
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printNewOrder = false;
            submitOrder();
            cNum.Focus();
        }

        private void shipping_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sku.Focus();
        }

        private void poNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                shipping.Focus();
        }

        private void oDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                poNum.Focus();
        }

        private void cNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                oDate.Focus();
        }

        private void qty_KeyUp(object sender, KeyEventArgs e)
        {
            bool palletPricing = false, itemNeedsAttention;
            int x, y, a, b;

            try
            {
                if (e.KeyCode == Keys.Enter && util_functions.isnumeric(qty.Text))
                {
                    if (ns == 0)
                    {
                        palletPricing = false;
                        itemNeedsAttention = false;

                        //if ( util_functions.isnumeric(price.Text) && skuPrice == 0.0f)
                        //{
                        //    if (MessageBox.Show("This sku has a zero price, continue?", "Zero Price", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        //        return;

                        //    if (Form1.SetPrice.IsDisposed)
                        //        Form1.SetPrice = new SetPriceForm();

                        //    Form1.SetPrice.priceID = priceCode;
                        //    Form1.SetPrice.unitID = unitID;
                        //    Form1.SetPrice.ShowDialog();
                        //}

                        x = (int)(float.Parse(qty.Text) / qtyConversion);
                        if (PipeUnitPricing && pipeLen > 0)
                            x = x * pipeLen;

                        // Clear the bit field for the quantity discrepancy bit
                        currentDiscrepancy &= 254;

                        y = x;
                        if (x > 0)
                        {
                            if (qtyAdjustment > 0)
                            {
                                if (x < qtyAdjustment)
                                {
                                    x = qtyAdjustment;
                                    currentDiscrepancy |= 1;
                                }
                                else if (x > qtyAdjustment)
                                {
                                    x = ((int)(x / qtyAdjustment) * qtyAdjustment);
                                    if (x < y)
                                    {
                                        x += qtyAdjustment;
                                        currentDiscrepancy |= 1;
                                    }
                                }
                            }

                            if (x < boxCount)
                            {
                                currentDiscrepancy |= 1;
                                x = boxCount;
                            }
                            else if (x > boxCount)
                            {
                                x = (int)(x / boxCount) * boxCount;
                                if (x < y)
                                {
                                    currentDiscrepancy |= 1;
                                    x += boxCount;
                                }
                            }
                        }

                        price.Text = skuPrice.ToString();
                        // Disabld per Alecia on 9/20/16. Indicated pallet pricing is no longer used
                        //if (palletPrice > 0 && boxesPerPallet > 0 && boxCount > 0 && skuPrice != palletPrice)
                        //{
                        //    if (((int)(((int)(x / boxCount)) / boxesPerPallet)) * boxesPerPallet != (int)(x / boxCount))
                        //        palletPricing = true;
                        //    else
                        //        price.Text = palletPrice.ToString();
                        //}

                        if (PipeUnitPricing && pipeLen > 0)
                            x /= pipeLen;

                        if (curRow < 0)
                        {
                            a = grid1.Rows.Add();
                            currentItem.rowID = (ushort)a;
                            currentItem.discrepancy = currentDiscrepancy;
                            itemsList.Add(currentItem);
                        }
                        else
                        {
                            a = curRow;
                            currentItem.rowID = (ushort)a;
                            currentItem.discrepancy = currentDiscrepancy;
                            for (b = 0; b < itemsList.Count; ++b)
                                if (itemsList[b].rowID == (ushort)a)
                                    itemsList[b] = currentItem;
                        }

                        grid1.Rows[a].Cells[0].Value = unitID;
                        grid1.Rows[a].Cells[1].Value = sku.Text;
                        grid1.Rows[a].Cells[2].Value = nstock.Text;
                        grid1.Rows[a].Cells[3].Value = x;
                        // Disabld per Alecia on 9/20/16. Indicated box qty adjustments do not need to be flagged.
                        //if ((currentDiscrepancy & 1) == 1)
                        //{
                        //    grid1.Rows[a].Cells[3].Style.ForeColor = Color.Red;
                        //    itemNeedsAttention = true;
                        //}
                        //else
                            grid1.Rows[a].Cells[3].Style.ForeColor = Color.Black;
                        // Disabld per Alecia on 9/20/16. Indicated pallet pricing is no longer used
                        //if (palletPricing)
                        //{
                        //    grid1.Rows[a].Cells[4].Style.ForeColor = Color.Red;
                        //    itemNeedsAttention = true;
                        //}
                        //else
                            grid1.Rows[a].Cells[4].Style.ForeColor = Color.Black;

                        if (itemNeedsAttention)
                            grid1.Rows[a].Cells[1].Style.ForeColor = Color.Red;
                        else
                            grid1.Rows[a].Cells[1].Style.ForeColor = Color.Black;

                        grid1.Rows[a].Cells[4].Value = price.Text;
                        if (grid1.Rows.Count > 11)
                            grid1.FirstDisplayedScrollingRowIndex = grid1.Rows.Count - 12;

                        Clear_Row_Selection();

                        totalAmount = totalAmount + (x * float.Parse(price.Text));

                        if (PipeUnitPricing && pipeLen > 0)
                            x *= pipeLen;

                        totalCubes = totalCubes + (curCube * (x / boxCount));
                        if (boxesPerPallet > 0 && boxCount > boxesPerPallet)
                            totalCubes = totalCubes + (int)(boxCount / boxesPerPallet) * palletCubes;

                        cubeCount.Text = totalCubes.ToString();
                        orderTotal.Text = totalAmount.ToString();
                        tempCubes = 0;
                        tempAmount = 0;

                        Label9.Text = "";
                        unitID = 0;
                        qty.Text = "";
                        price.Text = "";
                        sku.Text = "";
                        sku.Focus();
                        curRow = -1;

                    }
                    else
                    {
                        price.Focus();
                        System.Media.SystemSounds.Beep.Play();
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nPlease delete this quantity and re-enter.");
            }
        }

        private void price_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                nstock.Focus();
            else if ( util_functions.isnumeric(price.Text) )
            {
                skuPrice = Convert.ToSingle(price.Text);
                palletPrice = skuPrice;
            }
        }

        private void nstock_KeyUp(object sender, KeyEventArgs e)
        {
            int a;
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (curRow < 0)
                        a = grid1.Rows.Add();
                    else
                        a = curRow;

                    grid1.Rows[a].Cells[0].Value = 0;
                    grid1.Rows[a].Cells[1].Value = sku.Text;
                    grid1.Rows[a].Cells[2].Value = nstock.Text;
                    grid1.Rows[a].Cells[3].Value = qty.Text;
                    grid1.Rows[a].Cells[4].Value = price.Text;
                    if (grid1.Rows.Count > 11)
                        grid1.FirstDisplayedScrollingRowIndex = grid1.Rows.Count - 12;

                    totalAmount = totalAmount + (Convert.ToInt32(qty.Text) * Convert.ToSingle(price.Text));
                    orderTotal.Text = totalAmount.ToString();
                    tempCubes = 0;
                    tempAmount = 0;

                    unitID = 0;
                    Label9.Text = "";
                    qty.Text = "";
                    price.Text = "";
                    sku.Text = "";
                    sku.Focus();
                    curRow = -1;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nPlease delete this description and re-enter.");
            }

        }

        private void Orders_ResizeEnd(object sender, EventArgs e)
        {
            Set_Grid_Column_Sizes();
        }

        public void Set_Grid_Column_Sizes()
        {
            float size;

            grid1.Width = this.Width - 45;

            size = (float)(grid1.Width - 2) * 0.2f;
            grid1.Columns[0].Width = 2;
            grid1.Columns[1].Width = (int)size;
            grid1.Columns[3].Width = (int)size;
            grid1.Columns[4].Width = (int)size;

            size = grid1.Width - 2 - 3.0f * size;
            grid1.Columns[2].Width = (int)size;

            locNotes.Width = this.Width - 45;
        }

        private void Orders_Activated(object sender, EventArgs e)
        {
            Set_Grid_Column_Sizes();
        }

        private void grid1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            grid1.FirstDisplayedScrollingRowIndex = grid1.Rows.Count - 1;
        }

        private void quoteNum_KeyUp(object sender, KeyEventArgs e)
        {
            bool addQuote = true;
            int a, x, unitLen;
            string temp = "";
            SqlCommand cmd;

            if (e.KeyCode == Keys.Enter)
            {
                if (grid1.Rows.Count > 0)
                {
                    var confirmResult = MessageBox.Show("The order is not blank, do you want to merge with the quote?",
                            "Confirm Merge",
                            MessageBoxButtons.YesNo);
                    if (confirmResult != DialogResult.Yes)
                        addQuote = false;
                }

                if (addQuote)
                {
                    cmd = new SqlCommand("select * from QuoteSkus where quoteid = " + quoteNum.Text.Trim(), conn);
                    rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        cmd = new SqlCommand("SELECT customerNum from Location where ct = " + rdr["LocationID"].ToString(), conn);
                        rdr.Close();

                        rdr = cmd.ExecuteReader();
                        if (rdr.HasRows && rdr.Read())
                            temp = rdr["customerNum"].ToString();
                        rdr.Close();

                        if (cNum.Text.Trim().Length == 0)
                        {
                            // Since changing cNum.text fires an event handler that will do a database query, store the rdr in a temp string and close it out before channging cNum.text
                            cNum.Text = temp;
                        }
                        else if (cNum.Text.Trim() != temp.Trim())
                            MessageBox.Show("Warning: Customer Number on Quote Doesn't Match Current Customer Number.");

                        cmd = new SqlCommand("select QuoteSkus.*, Units.len, Units.box,Units.pallets,Units.cubes,Units.palletCubes,Units.cubes2 from QuoteSkus left join units on QuoteSkus.unitID = Units.ct where QuoteSkus.active = 1 and quoteid = " + quoteNum.Text.Trim(), conn);
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            if (util_functions.isnumeric(rdr["qty"].ToString()) && util_functions.isnumeric(rdr["price"].ToString()) && util_functions.isnumeric(rdr["multiplier"].ToString()))
                            {
                                a = grid1.Rows.Add();
                                currentItem.rowID = (ushort)a;
                                currentItem.discrepancy = 0;
                                itemsList.Add(currentItem);

                                x = Convert.ToInt32(rdr["qty"]);
                                skuPrice = util_functions.roundNumber(Convert.ToSingle(rdr["price"]) * Convert.ToSingle(rdr["multiplier"]), 2);
                                palletPrice = skuPrice;

                                unitLen = 0;
                                if (PipeUnitPricing && util_functions.isnumeric(rdr["len"].ToString()))
                                {
                                    unitLen = Convert.ToInt32(rdr["len"]);
                                    if (unitLen > 0)
                                    {
                                        x /= unitLen;
                                        skuPrice *= unitLen;
                                        palletPrice *= unitLen;
                                    }
                                }
                                grid1.Rows[a].Cells[0].Value = rdr["unitID"].ToString();
                                grid1.Rows[a].Cells[1].Value = rdr["Sku"].ToString();
                                grid1.Rows[a].Cells[2].Value = rdr["Descrip"].ToString();
                                grid1.Rows[a].Cells[3].Value = x.ToString();
                                grid1.Rows[a].Cells[3].Style.ForeColor = Color.Black;
                                grid1.Rows[a].Cells[4].Value = Convert.ToString(skuPrice);
                                if (grid1.Rows.Count > 11)
                                    grid1.FirstDisplayedScrollingRowIndex = grid1.Rows.Count - 12;



                                if (Convert.ToInt32(rdr["unitid"]) > 0)
                                {
                                //    unitRdr.Read();
                                boxCount = Convert.ToInt32(rdr["box"]);
                                boxesPerPallet = Convert.ToInt32(rdr["pallets"]);

                                    if (!alteredCubes)
                                    {
                                        curCube = Convert.ToSingle(rdr["cubes"]);
                                        palletCubes = Convert.ToInt32(rdr["palletCubes"]);
                                    }
                                    else
                                    {
                                        curCube = Convert.ToSingle(rdr["cubes2"]);
                                        palletCubes = 0;
                                    }

                                    if (PipeUnitPricing && unitLen > 0)
                                        x *= unitLen;

                                    totalAmount = totalAmount + (x * skuPrice);

                                    if (boxCount > 0)
                                        totalCubes = totalCubes + (curCube * (x / boxCount));

                                    if (boxesPerPallet > 0 && boxCount > boxesPerPallet)
                                        totalCubes = totalCubes + (int)(boxCount / boxesPerPallet) * palletCubes;
                                }
                            }
                        }

                        cubeCount.Text = totalCubes.ToString();
                        orderTotal.Text = totalAmount.ToString();
                        tempCubes = 0;
                        tempAmount = 0;
                    }

                    if (rdr != null)
                        rdr.Close();


                    Label9.Text = "";
                    unitID = 0;
                    qty.Text = "";
                    price.Text = "";
                    sku.Text = "";
                    sku.Focus();
                    curRow = -1;

                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Form1.SetQuotePrice.IsDisposed)
                Form1.SetQuotePrice = new QuotePricing();

            Form1.SetQuotePrice.Set_Location_ID(locationID);
            Form1.SetQuotePrice.ShowDialog();
        }

    }
}
