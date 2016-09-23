using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class SetPriceForm : Form
    {
        public int priceID, unitID;

        public SetPriceForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Set_Price();
        }

        private void price_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Set_Price();
        }

        public void Set_Price()
        {
            string results;

            if (unitID > 0 && priceID > 0 && util_functions.isnumeric(price.Text))
            {
                Form1.Orders.Set_Price(price.Text);

                results = util_functions.Get_Web_Page("/admin/vb_UpdatePrice.cfm", "f_priceID=" + priceID.ToString() + "&f_unitid=" + unitID.ToString() + "&f_price=" + util_functions.urlEncoded(price.Text.Trim()));

                if (!results.Contains("success"))
                    MessageBox.Show("Error occured during price update with the server.  The price was updated locally but not on the server.\n\n" + results);
            }
            else if (!util_functions.isnumeric(price.Text))
                MessageBox.Show("Error: The price must be a valid number without any non numeric characters (i.e. $)");
            else
                MessageBox.Show("Error: The price could not be updated due to missing information passed to this update section.  This is an abnormal circumstance and should not occur during normal operation.  Try cancelling this window, deleting the unit, and re-entering the sku before attempting to set the price again.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
