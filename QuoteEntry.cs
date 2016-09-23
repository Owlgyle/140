using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class QuoteEntry : Form
    {
        bool alteredCubes, autoUpdateCustomerInfo, skuMarkedInactive, showedSkuWarning, PipeUnitPricing;
        int quoteNum, priceCode, curRow, locationID, companyID, unitID, boxCount, pipeLen, boxesPerPallet;
        float curCube, totalCubes, totalWeight, tempWeight, tempCubes, palletCubes;
        string quote_ID;

        SqlConnection conn = new SqlConnection("Data Source=Romeo;Initial Catalog=Royal;User ID=royal;password=wkjwuq");
        SqlDataReader rdr = null;

        public QuoteEntry()
        {
            InitializeComponent();
        }

        private void QuoteEntry_Load(object sender, EventArgs e)
        {

            resetForm();


            conn.Open();
        }

        public void Update_Quote_Form()
        {
            quoteNum = 0;

            if (string.Compare(quote_ID, "") != 0)
            {
                Load_Quote(quote_ID);
                button2.Text = "Update Only";
                button1.Visible = true;
                button1.Enabled = true;
            }
            else
            {
                button2.Text = "Submit Only";
                button1.Visible = false;
                button1.Enabled = false;
            }

            Calculate_Quote_Totals();
        }

        private void QuoteEntry_Activated(object sender, EventArgs e)
        {
            //Update_Quote_Form();
        }

        private void QuoteEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rdr != null)
                rdr.Close();

            if (conn != null)
                conn.Close();
        }

        public void Add_Item_To_Quote()
        {
            float x, y, z, a, b, cubes;
            int c, d;

            try
            {
                if (!util_functions.isnumeric(qty.Text))
                {
                    qty.Focus();
                    System.Media.SystemSounds.Beep.Play();
                    return;
                }
                if (!util_functions.isnumeric(price.Text) || Convert.ToSingle(price.Text) == 0)
                {
                    price.Focus();
                    System.Media.SystemSounds.Beep.Play();
                    return;
                }
                if (!util_functions.isnumeric(mult.Text))
                {
                    mult.Focus();
                    System.Media.SystemSounds.Beep.Play();
                    return;
                }
                if (!util_functions.isnumeric(cost.Text) || Convert.ToSingle(cost.Text) == 0)
                {
                    cost.Focus();
                    System.Media.SystemSounds.Beep.Play();
                    return;
                }
                if (curRow > -1 && !util_functions.isnumeric(IndMult.Text))
                {
                    IndMult.Focus();
                    System.Media.SystemSounds.Beep.Play();
                    return;
                }
                if (unitID == 0 && string.Compare(skudescrip.Text.Trim(), "") == 0)
                {
                    IndMult.Focus();
                    System.Media.SystemSounds.Beep.Play();
                    return;
                }

                x = util_functions.roundNumber(Convert.ToSingle(qty.Text) * Convert.ToSingle(price.Text), 2);
                if (curRow < 0)
                    y = util_functions.roundNumber(Convert.ToSingle(price.Text) * Convert.ToSingle(mult.Text), 2);
                else
                    y = util_functions.roundNumber(Convert.ToSingle(price.Text) * Convert.ToSingle(IndMult.Text), 2);

                z = util_functions.roundNumber(Convert.ToSingle(qty.Text) * y, 2);
                a = util_functions.roundNumber(Convert.ToSingle(cost.Text) * Convert.ToSingle(qty.Text), 2);
                b = util_functions.roundNumber(Convert.ToSingle(cost.Text) / y, 2);

                if (curRow < 0)
                    c = grid1.Rows.Add();
                else
                    c = curRow;

                grid1.Rows[c].Cells[0].Value = unitID;
                grid1.Rows[c].Cells[1].Value = sku.Text;
                if (unitID > 0)
                    grid1.Rows[c].Cells[2].Value = skuLabel.Text;
                else
                    grid1.Rows[c].Cells[2].Value = skudescrip.Text;
                grid1.Rows[c].Cells[3].Value = qty.Text;
                grid1.Rows[c].Cells[4].Value = price.Text;
                grid1.Rows[c].Cells[5].Value = x;
                grid1.Rows[c].Cells[6].Value = y;
                grid1.Rows[c].Cells[7].Value = z;
                grid1.Rows[c].Cells[8].Value = cost.Text;
                grid1.Rows[c].Cells[9].Value = a.ToString();
                grid1.Rows[c].Cells[10].Value = b.ToString();
                if (curRow < 0)
                    grid1.Rows[c].Cells[11].Value = mult.Text;
                else
                    grid1.Rows[c].Cells[11].Value = IndMult.Text;

                if (grid1.FirstDisplayedScrollingRowIndex > 12)
                    grid1.FirstDisplayedScrollingRowIndex = grid1.Rows.Count - 12;

                d = Convert.ToInt32(qty.Text);
                if (PipeUnitPricing && pipeLen > 0)
                    d *= pipeLen;

                if (boxCount > 0)
                {
                    cubes = curCube * (int)(d / boxCount);
                    if (boxesPerPallet > 0 && boxCount > boxesPerPallet)
                        cubes += (int)(boxCount / boxesPerPallet) * palletCubes;
                }
                else
                    cubes = 0;
                grid1.Rows[c].Cells[12].Value = cubes;

                if (util_functions.isnumeric(WeightCount.Text))
                    grid1.Rows[c].Cells[13].Value = WeightCount.Text;
                else
                    grid1.Rows[c].Cells[13].Value = "0";

                Calculate_Quote_Totals();

                Label9.Text = "";
                unitID = 0;
                qty.Text = "";
                price.Text = "";
                sku.Text = "";
                sku.Focus();
                curRow = -1;
                IndMult.Text = mult.Text;
                IndMult.Visible = false;
                IndMultLabel.Visible = false;
                skudescrip.Text = "";
                skudescrip.Visible = false;
                tempCubes = 0;

            }
            catch (Exception e)
            {
                MessageBox.Show("An error has occured.\n\n" + e.Message + "\n\nPlease delete this quantity and re-enter.");
            }

        }

        public void Calculate_Quote_Totals()
        {
            float x, y, z, a, b;
            int c;

            a = 0;
            b = 0;
            x = 0;
            y = 0;
            z = 0;
            totalCubes = 0;
            totalWeight = 0;

            if (grid1.Rows.Count > 0)
            {
                for (c = 0; c < grid1.Rows.Count; c++)
                {
                    x = x + Convert.ToSingle(grid1.Rows[c].Cells[7].Value.ToString());
                    y = y + Convert.ToSingle(grid1.Rows[c].Cells[5].Value.ToString());
                    z = z + Convert.ToSingle(grid1.Rows[c].Cells[9].Value.ToString());
                    totalCubes = totalCubes + Convert.ToSingle(grid1.Rows[c].Cells[12].Value.ToString());
                    totalWeight = totalWeight + Convert.ToSingle(grid1.Rows[c].Cells[13].Value.ToString()) * Convert.ToInt32(grid1.Rows[c].Cells[3].Value.ToString());
                }
            }

            newpricetotal.Text = x.ToString();
            oripricetotal.Text = y.ToString();
            costtotal.Text = z.ToString();

            if (y != 0.0f)
                a = util_functions.roundNumber(x / y, 3);
            if (x != 0.0f)
                b = util_functions.roundNumber(z / x, 2);
            totalDiscount.Text = "Total Discount: " + String.Format("{0:0,0.000}", a.ToString());
            totalDirectCost.Text = "Total Direct Cost: " + b.ToString();
            total.Text = "Quote Total: " + x.ToString();

            totalCubes = util_functions.roundNumber(totalCubes, 2);
            totalWeight = util_functions.roundNumber(totalWeight, 2);
            cubeCount.Text = totalCubes.ToString();
            WeightCount.Text = totalWeight.ToString();
        }

        public void Load_Quote(string quoteID)
        {
            float x, y, z, a, b, cost = 0.0f, cubes = 0.0f, weight = 0.0f;
            int c, d;
            bool errorLoading;
            string errMsg;

            errMsg = "";
            errorLoading = false;
            autoUpdateCustomerInfo = false;

            SqlCommand cmd = new SqlCommand("select quotes.*,quotes.ct as quoteID,location.PipeUnitPricing,location.alteredCubes,location.customernum,location.priceID from quotes left outer join location on quotes.locationid = location.ct where quotes.ct = " + quoteID, conn);
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows && rdr.Read())
            {
                quoteNotes.Text = rdr["notes"].ToString();
                quoteNum = Convert.ToInt16(rdr["quoteID"].ToString());
                mult.Text = rdr["mult"].ToString();
                cNum.Text = rdr["customerNum"].ToString();
                locationID = Convert.ToInt16(rdr["locationID"].ToString());
                companyID = Convert.ToInt16(rdr["companyID"].ToString());
                sName.Text = rdr["Name"].ToString();
                sAddr1.Text = rdr["addr1"].ToString();
                sAddr2.Text = rdr["addr2"].ToString();
                sCity.Text = rdr["city"].ToString();
                sState.Text = rdr["State"].ToString();
                sZip.Text = rdr["zip"].ToString();
                attention.Text = rdr["contact"].ToString();
                QuoteName.Text = rdr["QuoteName"].ToString();
                email.Text = rdr["email"].ToString();
                fax.Text = rdr["fax"].ToString();
                PipeUnitPricing = rdr["PipeUnitPricing"].Equals(true);
                Freight.Text = rdr["freight"].ToString();

                if (util_functions.isnumeric(rdr["priceID"].ToString()))
                    priceCode = Convert.ToInt16(rdr["priceID"].ToString());
                else
                    priceCode = 0;

                if (rdr["alteredCubes"].Equals(0))
                    alteredCubes = false;
                else
                    alteredCubes = true;

                rdr.Close();
            }
            autoUpdateCustomerInfo = true;


            cmd = new SqlCommand("select quoteSkus.*,units.ct as unitsCt,units.cubes,units.cubes2,units.palletCubes,units.Len,units.box,units.pallets, units.weight, units.cost as ucost from QuoteSkus left outer join units on QuoteSkus.unitid = units.ct where QuoteSkus.active=1 and QuoteSkus.quoteid = " + quoteID, conn);
            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
                while (rdr.Read())
                {
                    try
                    {
                        cost = 0;
                        pipeLen = 0;
                        boxCount = 0;
                        boxesPerPallet = 0;
                        curCube = 0;
                        palletCubes = 0;
                        weight = 0.0f;

                        if (util_functions.isnumeric(rdr["unitsCt"].ToString()))
                        {
                            if (util_functions.isnumeric(rdr["cost"].ToString()))
                                cost = Convert.ToSingle(rdr["cost"].ToString());
                            else if (util_functions.isnumeric(rdr["ucost"].ToString()))
                                cost = Convert.ToSingle(rdr["ucost"].ToString());

                            pipeLen = Convert.ToInt32(rdr["Len"]);
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
                            weight = Convert.ToSingle(rdr["weight"].ToString());
                        }

                        x = util_functions.roundNumber(Convert.ToSingle(rdr["qty"].ToString()) * Convert.ToSingle(rdr["price"].ToString()), 2);
                        y = util_functions.roundNumber(Convert.ToSingle(rdr["price"].ToString()) * Convert.ToSingle(rdr["multiplier"].ToString()), 2);
                        z = util_functions.roundNumber(Convert.ToSingle(rdr["qty"].ToString()) * y, 2);

                        a = util_functions.roundNumber(cost * Convert.ToSingle(rdr["qty"].ToString()), 2);
                        if (y != 0)
                            b = util_functions.roundNumber(cost / y, 2);
                        else
                            b = 0;

                        c = grid1.Rows.Add();

                        grid1.Rows[c].Cells[0].Value = Convert.ToInt16(rdr["unitID"].ToString());
                        grid1.Rows[c].Cells[1].Value = rdr["sku"].ToString();
                        grid1.Rows[c].Cells[2].Value = rdr["descrip"].ToString();
                        grid1.Rows[c].Cells[3].Value = Convert.ToInt32(rdr["qty"].ToString());
                        grid1.Rows[c].Cells[4].Value = Convert.ToSingle(rdr["price"].ToString());
                        grid1.Rows[c].Cells[5].Value = x;
                        grid1.Rows[c].Cells[6].Value = y;
                        grid1.Rows[c].Cells[7].Value = z;
                        grid1.Rows[c].Cells[8].Value = cost;
                        grid1.Rows[c].Cells[9].Value = a.ToString();
                        grid1.Rows[c].Cells[10].Value = b.ToString();
                        grid1.Rows[c].Cells[11].Value = Convert.ToSingle(rdr["multiplier"].ToString());
                        grid1.Rows[c].Cells[13].Value = weight;


                        d = Convert.ToInt32(rdr["qty"].ToString());
                        if (PipeUnitPricing && pipeLen > 0)
                            d *= pipeLen;

                        if (boxCount > 0)
                        {
                            cubes = curCube * (int)(d / boxCount);
                            if (boxesPerPallet > 0 && boxCount > boxesPerPallet)
                                cubes += (int)(boxCount / boxesPerPallet) * palletCubes;

                            grid1.Rows[c].Cells[12].Value = cubes;
                        }
                        else
                            grid1.Rows[c].Cells[12].Value = 0;
                    }
                    catch (Exception e)
                    {
                        errMsg = e.Message;
                        errorLoading = true;
                    }
                }

            if (errorLoading)
                MessageBox.Show("An error was encountered while loading this quote. Not all items were loaded correctly.\r\n" + errMsg);

            if (grid1.Rows.Count > 11)
                grid1.FirstDisplayedScrollingRowIndex = grid1.Rows.Count - 12;

            rdr.Close();

            Calculate_Quote_Totals();

        }

        public void resetForm()
        {
            totalCubes = 0;
            totalWeight = 0;
            Freight.Text = "";
            alteredCubes = false;
            PipeUnitPricing = false;
            showedSkuWarning = false;
            skuMarkedInactive = false;
            quoteNotes.Text = "";
            total.Text = "";
            quoteNum = 0;
            quote_ID = "";
            cNum.Text = "";
            QuoteName.Text = "";
            sku.Text = "";
            qty.Text = "";
            price.Text = "";
            mult.Text = "";
            grid1.Rows.Clear();
            attention.Text = "";
            IndMult.Visible = false;
            IndMultLabel.Visible = false;
            skudescrip.Visible = false;
            skudescrip.Text = "";
            curRow = -1;
            button1.Visible = false;

            autoUpdateCustomerInfo = true;
            grid1.Rows.Clear();
        }

        public void Set_Quote_ID(string quoteID)
        {
            quote_ID = quoteID;
        }

        /// <summary>
        /// sendEmailFax = false
        /// </summary>
        public void submitQuote(bool sendEmailFax, bool clone)
        {
            string results, strData, unitList, priceList, qtyList, multList, costList, descList, skuList, charCode;
            char[] c1;
            int x;

            c1 = new char[1];
            c1[0] = (char)25;
            charCode = new string(c1);

            try
            {
                if (grid1.Rows.Count < 1)
                {
                    MessageBox.Show("Error: No units on quote.");
                    return;
                }

                unitList = "";
                descList = "";
                qtyList = "";
                priceList = "";
                multList = "";
                costList = "";
                descList = "";
                skuList = "";

                for (x = 0; x < grid1.Rows.Count; x++)
                {
                    unitList = unitList + "," + grid1.Rows[x].Cells[0].Value.ToString().Replace(",", charCode);
                    qtyList = qtyList + "," + grid1.Rows[x].Cells[3].Value.ToString().Replace(",", charCode);
                    priceList = priceList + "," + grid1.Rows[x].Cells[4].Value.ToString().Replace(",", charCode);
                    multList = multList + "," + grid1.Rows[x].Cells[11].Value.ToString().Replace(",", charCode);
                    costList = costList + "," + grid1.Rows[x].Cells[8].Value.ToString().Replace(",", charCode);
                    descList = descList + "," + grid1.Rows[x].Cells[2].Value.ToString().Replace(",", charCode);
                    skuList = skuList + "," + grid1.Rows[x].Cells[1].Value.ToString().Replace(",", charCode);
                }

                unitList = unitList.Substring(1, unitList.Length - 1);
                qtyList = qtyList.Substring(1, qtyList.Length - 1);
                priceList = priceList.Substring(1, priceList.Length - 1);
                multList = multList.Substring(1, multList.Length - 1);
                costList = costList.Substring(1, costList.Length - 1);
                descList = descList.Substring(1, descList.Length - 1);
                skuList = skuList.Substring(1, skuList.Length - 1);

                strData = "f_companyID=" + companyID.ToString();
                strData = strData + "&f_locationID=" + locationID.ToString();
                strData = strData + "&f_mult=" + util_functions.urlEncoded(mult.Text);
                strData = strData + "&f_quoteID=" + quoteNum.ToString();
                strData = strData + "&f_quoteName=" + util_functions.urlEncoded(QuoteName.Text);
                strData = strData + "&f_contact=" + util_functions.urlEncoded(attention.Text);
                strData = strData + "&f_customerNum=" + util_functions.urlEncoded(cNum.Text);
                strData = strData + "&f_unitList=" + util_functions.urlEncoded(unitList);
                strData = strData + "&f_priceList=" + util_functions.urlEncoded(priceList);
                strData = strData + "&f_descList=" + util_functions.urlEncoded(descList);
                strData = strData + "&f_skuList=" + util_functions.urlEncoded(skuList);
                strData = strData + "&f_qtyList=" + util_functions.urlEncoded(qtyList);
                strData = strData + "&f_multList=" + util_functions.urlEncoded(multList);
                strData = strData + "&f_costList=" + util_functions.urlEncoded(costList);
                strData = strData + "&f_name=" + util_functions.urlEncoded(sName.Text);
                strData = strData + "&f_addr1=" + util_functions.urlEncoded(sAddr1.Text);
                strData = strData + "&f_addr2=" + util_functions.urlEncoded(sAddr2.Text);
                strData = strData + "&f_city=" + util_functions.urlEncoded(sCity.Text);
                strData = strData + "&f_State=" + util_functions.urlEncoded(sState.Text);
                strData = strData + "&f_zip=" + util_functions.urlEncoded(sZip.Text);
                strData = strData + "&f_email=" + util_functions.urlEncoded(email.Text);
                strData = strData + "&f_fax=" + util_functions.urlEncoded(fax.Text);
                strData = strData + "&f_notes=" + util_functions.urlEncoded(quoteNotes.Text);
                strData = strData + "&f_totalCubes=" + util_functions.urlEncoded(totalCubes.ToString());
                strData = strData + "&f_totalWeight=" + util_functions.urlEncoded(totalWeight.ToString());
                strData = strData + "&f_freight=" + Freight.Text;

                if (sendEmailFax)
                    strData = strData + "&f_print=yes";


                if (quoteNum > 0 && clone == false)
                    results = util_functions.Post_Web_Form("/admin/vb_Quote_Update.cfm", strData);
                else
                    results = util_functions.Post_Web_Form("/admin/vb_Quote_Submit.cfm", strData);


                //   *****************************
                //   Check result for order status
                //   *****************************

                x = results.IndexOf("<>");
                if (x > -1)
                {
                    results = results.Substring(x + 2);
                    if (!clone)
                    {
                        if (util_functions.isnumeric(results))
                        {
                            if (string.Compare(quote_ID, "") == 0)
                                util_functions.Print_Quote(results, Form1.p2, 1);
                            else if (printOnSave.Checked)
                                util_functions.Print_Quote(quote_ID, Form1.p2, 1);

                            resetForm();

                        }
                        else
                            MessageBox.Show("Error occured during the quote submission. - " + results);
                    }
                    else
                    {
                        Set_Quote_ID(results);
                        Update_Quote_Form();
                    }
                }
                else
                    MessageBox.Show("Invalid quote number in response code.  Please verify the quote was submitted correctly.");

            }
            catch (Exception e)
            {
                MessageBox.Show("An error has occured.\n\n" + e.Message + "\n\nThis order may have been submitted to the system before the error occured.  Please verify the order was not received before submitting again.");

            }
        }

        private void skudescrip_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Add_Item_To_Quote();
        }

        private void skudescrip_TextChanged(object sender, EventArgs e)
        {
            if (skudescrip.Text.Trim().Length > 0)
            {
                qty.Enabled = true;
                price.Enabled = true;
            }
        }

        private void sku_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (skuMarkedInactive)
                {
                    if (!showedSkuWarning)
                        MessageBox.Show("The sku you selected has been marked inactive and cannot be entered.");
                    showedSkuWarning = true;
                }
                else if (qty.Enabled)
                    qty.Focus();
                else if (skudescrip.Visible)
                    skudescrip.Focus();
            }
        }

        private void sku_TextChanged(object sender, EventArgs e)
        {
            int pipeLen;
            SqlCommand cmd;

            try
            {
                showedSkuWarning = false;

                if (priceCode > 0)
                    cmd = new SqlCommand("select units.*, unit_price.price from units inner join unit_price on units.ct=unit_price.unitID where sku='" + sku.Text + "' And unit_price.priceID = " + priceCode.ToString(), conn);
                else
                    cmd = new SqlCommand("select * from Units where sku='" + sku.Text + "'", conn);

                rdr = cmd.ExecuteReader();
                if (rdr.HasRows && rdr.Read())
                {
                    skuMarkedInactive = false;
                    if (!Convert.ToBoolean(rdr["active"]))
                    {

                        skuMarkedInactive = true;
                        skudescrip.Visible = true;
                        cost.Text = "";
                        price.Text = "";
                        skuLabel.Text = "";
                        unitID = 0;
                        qty.Enabled = false;
                        price.Enabled = false;
                        cubeCount.Text = "0";
                        WeightCount.Text = "0";

                        if (rdr != null)
                            rdr.Close();
                        return;

                        //qty.Text = "";
                        //qty.Enabled = false;
                        //MessageBox.Show("The sku you selected has been marked inactive and cannot be entered.");

                        //if (rdr != null)
                        //    rdr.Close();

                        //return;
                    }


                    WeightCount.Text = rdr["weight"].ToString();
                    unitID = Convert.ToInt16(rdr["ct"]);
                    skuLabel.Text = rdr["descrip"].ToString();
                    qty.Text = "";
                    if (util_functions.isnumeric(rdr["cost"].ToString()))
                        cost.Text = rdr["cost"].ToString();
                    else
                        cost.Text = "0";
                    if (priceCode > 0)
                        price.Text = rdr["price"].ToString();
                    else
                        price.Text = "0";

                    if (!util_functions.isnumeric(price.Text) || Convert.ToSingle(price.Text) == 0 || !util_functions.isnumeric(cost.Text) || Convert.ToSingle(cost.Text) == 0)

                        System.Media.SystemSounds.Beep.Play();

                    skudescrip.Visible = false;
                    qty.Enabled = true;
                    price.Enabled = true;

                    pipeLen = Convert.ToInt32(rdr["Len"]);
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

                }
                else
                {
                    skudescrip.Visible = true;
                    cost.Text = "";
                    price.Text = "";
                    skuLabel.Text = "";
                    unitID = 0;
                    qty.Enabled = false;
                    price.Enabled = false;
                    curCube = 0;
                    boxCount = 1;
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nPlease delete this sku and re-enter.");

            }

            if (rdr != null)
                rdr.Close();

        }

        private void QuoteName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                mult.Focus();
        }

        private void qty_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Add_Item_To_Quote();
        }

        private void price_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Add_Item_To_Quote();
        }

        private void mult_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sku.Focus();
        }

        private void mult_TextChanged(object sender, EventArgs e)
        {
            float x, y, z;
            int c;

            if (util_functions.isnumeric(mult.Text) && Convert.ToSingle(mult.Text) != 0.0f && grid1.Rows.Count > 0)
            {
                for (c = 0; c < grid1.Rows.Count; c++)
                {
                    y = util_functions.roundNumber(Convert.ToSingle(grid1.Rows[c].Cells[4].Value.ToString()) * Convert.ToSingle(mult.Text), 2);
                    z = util_functions.roundNumber(Convert.ToSingle(grid1.Rows[c].Cells[3].Value.ToString()) * y, 2);
                    x = util_functions.roundNumber(Convert.ToSingle(grid1.Rows[c].Cells[8].Value.ToString()) / y, 2);
                    grid1.Rows[c].Cells[11].Value = " " + mult.Text;
                    grid1.Rows[c].Cells[6].Value = " " + y.ToString();
                    grid1.Rows[c].Cells[7].Value = " " + z.ToString();
                    grid1.Rows[c].Cells[10].Value = " " + x.ToString();
                }
                Calculate_Quote_Totals();
            }
        }

        private void IndMult_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Add_Item_To_Quote();
        }

        private void grid1_KeyDown(object sender, KeyEventArgs e)
        {
            int x;

            try
            {
                if (grid1.CurrentRow.Index < 0)
                    return;
                if (e.KeyCode == Keys.Delete)
                {
                    Edit_Row();
                    if (curRow > -1)
                    {
                        grid1.Rows.RemoveAt(curRow);

                        unitID = 0;
                        qty.Text = "";
                        price.Text = "";
                        sku.Text = "";
                        skudescrip.Text = "";
                        skudescrip.Visible = false;
                        curRow = -1;
                        IndMult.Visible = false;
                        IndMultLabel.Visible = false;
                    }
                }
                else if (e.KeyCode == Keys.I)
                {
                    x = grid1.CurrentRow.Index;

                    grid1.Rows.Insert(x, 1);
                    grid1.Rows[x].Cells[0].Value = grid1.Rows[x + 1].Cells[0].Value;
                    grid1.Rows[x].Cells[1].Value = grid1.Rows[x + 1].Cells[1].Value;
                    grid1.Rows[x].Cells[2].Value = grid1.Rows[x + 1].Cells[2].Value;
                    grid1.Rows[x].Cells[3].Value = grid1.Rows[x + 1].Cells[3].Value;
                    grid1.Rows[x].Cells[4].Value = grid1.Rows[x + 1].Cells[4].Value;
                    grid1.Rows[x].Cells[5].Value = grid1.Rows[x + 1].Cells[5].Value;
                    grid1.Rows[x].Cells[6].Value = grid1.Rows[x + 1].Cells[6].Value;
                    grid1.Rows[x].Cells[7].Value = grid1.Rows[x + 1].Cells[7].Value;
                    grid1.Rows[x].Cells[8].Value = grid1.Rows[x + 1].Cells[8].Value;
                    grid1.Rows[x].Cells[9].Value = grid1.Rows[x + 1].Cells[9].Value;
                    grid1.Rows[x].Cells[10].Value = grid1.Rows[x + 1].Cells[10].Value;
                    grid1.Rows[x].Cells[11].Value = grid1.Rows[x + 1].Cells[11].Value;
                    grid1.Rows[x].Cells[12].Value = grid1.Rows[x + 1].Cells[12].Value;
                    grid1.Rows[x].Cells[13].Value = grid1.Rows[x + 1].Cells[13].Value;

                    sku.Text = grid1.Rows[x].Cells[1].Value.ToString();
                    skudescrip.Text = grid1.Rows[x].Cells[2].Value.ToString();
                    price.Text = grid1.Rows[x].Cells[4].Value.ToString();
                    qty.Text = grid1.Rows[x].Cells[3].Value.ToString();
                    IndMult.Text = grid1.Rows[x].Cells[11].Value.ToString();
                    cost.Text = grid1.Rows[x].Cells[8].Value.ToString();
                    cubeCount.Text = grid1.Rows[x].Cells[12].Value.ToString();
                    WeightCount.Text = grid1.Rows[x].Cells[13].Value.ToString();

                    IndMult.Visible = true;
                    IndMultLabel.Visible = true;
                    Label9.Text = "Edit Mode";
                    curRow = x + 1;


                    sku.Select(0, sku.Text.Length);
                    sku.Focus();

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
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nPlease delete this abc description and re-enter.");
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
                    skudescrip.Text = grid1.Rows[x].Cells[2].Value.ToString();
                    price.Text = grid1.Rows[x].Cells[4].Value.ToString();
                    qty.Text = grid1.Rows[x].Cells[3].Value.ToString();
                    cost.Text = grid1.Rows[x].Cells[8].Value.ToString();
                    IndMult.Text = grid1.Rows[x].Cells[11].Value.ToString();
                    cubeCount.Text = grid1.Rows[x].Cells[12].Value.ToString();
                    WeightCount.Text = grid1.Rows[x].Cells[13].Value.ToString();


                    IndMult.Visible = true;
                    IndMultLabel.Visible = true;

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
                    tempWeight = Convert.ToSingle(WeightCount.Text);

                    if (boxesPerPallet > 0 && boxCount > boxesPerPallet)
                        tempCubes = tempCubes + (int)(boxCount / boxesPerPallet) * palletCubes;

                    totalCubes -= tempCubes;
                    totalWeight -= tempWeight;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("An error has occured.\n\n" + e.Message + "\n\nPlease delete this def description and re-enter.");
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
                IndMult.Visible = false;
                IndMultLabel.Visible = false;
                totalCubes += tempCubes;
                totalWeight += tempWeight;

                cubeCount.Text = totalCubes.ToString();
                WeightCount.Text = totalWeight.ToString();
                tempCubes = 0;
            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message);
            }
        }

        private void cost_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Add_Item_To_Quote();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            submitQuote(true, false);

            cNum.Focus();

            button1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            resetForm();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            util_functions.Print_Quote(quote_ID, Form1.p2, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            submitQuote(false, false);

            cNum.Focus();

            button1.Enabled = false;
        }

        private void cNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                QuoteName.Focus();
        }

        private void cNum_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd;

            try
            {
                if (!autoUpdateCustomerInfo)
                    return;

                if (util_functions.isnumeric(cNum.Text))
                {
                    cmd = new SqlCommand("select * from location where customernum='" + cNum.Text + "' and active<>0", conn);
                    rdr = cmd.ExecuteReader();
                    if (rdr.HasRows && rdr.Read())
                    {
                        locationID = Convert.ToInt16(rdr["ct"].ToString());
                        companyID = Convert.ToInt16(rdr["companyID"].ToString());
                        sName.Text = rdr["Name"].ToString().Trim();
                        sAddr1.Text = rdr["addr1"].ToString().Trim();
                        sAddr2.Text = rdr["addr2"].ToString().Trim();
                        sCity.Text = rdr["city"].ToString().Trim();
                        sState.Text = rdr["State"].ToString().Trim();
                        sZip.Text = rdr["zip"].ToString().Trim();
                        attention.Text = rdr["contact"].ToString().Trim();
                        email.Text = rdr["email"].ToString().Trim();
                        fax.Text = rdr["fax"].ToString().Trim();
                        PipeUnitPricing = rdr["PipeUnitPricing"].Equals(true);

                        if (util_functions.isnumeric(rdr["priceID"].ToString()))
                            priceCode = Convert.ToInt16(rdr["priceID"].ToString());
                        else
                            priceCode = 0;

                        if (rdr["alteredCubes"].Equals(0))
                            alteredCubes = false;
                        else
                            alteredCubes = true;
                    }
                    else
                    {
                        PipeUnitPricing = false;
                        priceCode = 0;
                        locationID = 0;
                        companyID = 0;
                        sName.Text = "";
                        sAddr1.Text = "";
                        sAddr2.Text = "";
                        sCity.Text = "";
                        sState.Text = "";
                        sZip.Text = "";
                        attention.Text = "";
                        email.Text = "";
                        fax.Text = "";
                    }
                }
                else
                {
                    PipeUnitPricing = false;
                    priceCode = 0;
                    locationID = 0;
                    companyID = 0;
                    sName.Text = "";
                    sAddr1.Text = "";
                    sAddr2.Text = "";
                    sCity.Text = "";
                    sState.Text = "";
                    sZip.Text = "";
                    attention.Text = "";
                    email.Text = "";
                    fax.Text = "";
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured while loading the customer information.\n\n" + e1.Message);
            }
            if (rdr != null)
                rdr.Close();
        }

        public void Clone_Quote()
        {
            submitQuote(false, true);

            cNum.Focus();

            button1.Enabled = false;
        }

    }
}
