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
    public partial class QuotePricing : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Romeo;Initial Catalog=Royal;User ID=royal;password=wkjwuq");
        SqlDataReader rdr = null;
        SqlCommand cmd;
        int locID=0,quoteLocID=0;

        public QuotePricing()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (util_functions.isnumeric(quoteNum.Text))
            {
                if (locID != quoteLocID)
                {
                    var confirmResult = MessageBox.Show("Quote is not for the customer on the order. Do you wish to continue?", "Confirm", MessageBoxButtons.YesNo);
                    if (confirmResult != DialogResult.Yes)
                        return;
                }
                Form1.Orders.Set_Quote_Pricing(quoteNum.Text);
                this.Hide();
            }
            else
                MessageBox.Show("Error: The quote must be a numeric value.");
        }

        private void quoteNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                button2.Enabled = false;
                label1.Text = "";

                if (!util_functions.isnumeric(quoteNum.Text))
                    return;

                cmd = new SqlCommand("select * from quotes where ct = " + quoteNum.Text, conn);

                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();

                    if (util_functions.isnumeric(rdr["ct"].ToString()))
                    {
                        quoteLocID = Convert.ToInt32(rdr["locationID"].ToString());
                        button2.Enabled = true;
                        label1.Text = rdr["name"].ToString() + " (" + rdr["customerNum"].ToString() + ")\n" + rdr["quoteName"].ToString() + "\n" + rdr["quoteTotal"].ToString();
                    }
                }

                if (rdr != null)
                    rdr.Close();
            }
            catch( Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void QuotePricing_Load(object sender, EventArgs e)
        {
            conn.Open();

            button2.Enabled = false;
            quoteNum.Text = "";
            quoteLocID = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button2.Enabled = false;
                label1.Text = "";

                if (!util_functions.isnumeric(quoteNum.Text))
                {
                    MessageBox.Show("The quote must be numeric.");
                    return;
                }

                cmd = new SqlCommand("select * from quotes where ct = " + quoteNum.Text, conn);

                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    if (util_functions.isnumeric(rdr["ct"].ToString()))
                    {
                        quoteLocID = Convert.ToInt32(rdr["locationID"].ToString());
                        button2.Enabled = true;
                        label1.Text = rdr["name"].ToString() + " (" + rdr["customerNum"].ToString() + ")\n" + rdr["quoteName"].ToString() + "\n" + rdr["quoteTotal"].ToString();
                    }
                }

                if (rdr != null)
                    rdr.Close();

                if (!button2.Enabled)
                    MessageBox.Show("Quote not found.");
            }
            catch
            {
            }

        }

        public void Set_Location_ID(int location)
        {
            locID = location;
        }

        private void QuotePricing_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (conn == null || conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                {
                    if (conn != null && conn.State == ConnectionState.Broken)
                        conn.Close();
                    conn.Open();
                }
            }
            else
            {
                if ( conn != null)
                    conn.Close();
            }
        }

    }
}
