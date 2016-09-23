using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class EDI : Form
    {
        public static string resetTextBox;

        public EDI()
        {
            InitializeComponent();
        }

        private void EDI_Load(object sender, EventArgs e)
        {

            DateTime date1;

            EDIIN.Text = Form1.EDIIN;
            EDIServer.Text = Form1.EDIServer;
            EDIOut.Text = Form1.EDIOut;

            date1 = DateTime.Now;
            curDate.Text = date1.ToShortDateString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OrderNum_TextChanged(object sender, EventArgs e)
        {

            if (String.Compare(resetTextBox, "curdate") != 0)
            {
                resetTextBox = "ordernum";
                curDate.Text = "";
            }

            resetTextBox = "";
        }

        private void EDIServer_KeyUp(object sender, KeyEventArgs e)
        {
            Form1.EDIServer = EDIServer.Text;
        }

        private void EDIIN_KeyUp(object sender, KeyEventArgs e)
        {
            Form1.EDIIN = EDIIN.Text;
        }

        private void EDIOut_KeyUp(object sender, KeyEventArgs e)
        {
            Form1.EDIOut = EDIOut.Text;
        }

        private void curDate_TextChanged(object sender, EventArgs e)
        {

            if (string.Compare(resetTextBox, "ordernum") != 0)
            {
                resetTextBox = "curdate";
                OrderNum.Text = "";
            }

            resetTextBox = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string orderErr = "", f_id;
            string[] fname, str2;
            int x, y, z = 0, pStart;

            button1.Enabled = false;
            Text1.Text = "";

            if (String.Compare(EDIIN.Text.Substring(EDIIN.Text.Length - 1), "\\") != 0)
            {
                EDIIN.Text = EDIIN.Text + "\\";
                Form1.EDIIN = EDIIN.Text;
            }
            if (String.Compare(EDIServer.Text.Substring(EDIServer.Text.Length - 1), "\\") != 0)
            {
                EDIServer.Text = EDIServer.Text + "\\";
                Form1.EDIServer = EDIServer.Text;
            }

            ICollection<string> fileList = Directory.GetFiles(EDIIN.Text, "*.csv");
            fname = (string[])fileList;

            for (x = 0; x < fname.Length; x++)
            {
                str2 = fname[x].Split(new char[] { '\\' });

                for (y = str2.Length - 1; y >= 0; y--)
                    if (str2[y].Length > 0)
                    {
                        fname[x] = str2[y];

                        if (fname[x].IndexOf(".csv", StringComparison.InvariantCultureIgnoreCase) > -1)
                        {
                            if (File.Exists(EDIServer.Text + fname[x]))
                                fileList.Remove(EDIServer.Text + fname[x]);

                            File.Copy(EDIIN.Text + fname[x], EDIServer.Text + fname[x]);

                            Text1.Text = Text1.Text + util_functions.Get_Web_Page("/admin/vb_EDI_import.cfm", "&ediFname=" + util_functions.urlEncoded(fname[x])) + "\n\n";

                            File.Delete(EDIIN.Text + fname[x]);

                        }
                        break;
                    }
            }

            Text1.Text = Text1.Text + "\n\nEdi Import Complete\n\n";

            pStart = 0;

            x = Text1.Text.IndexOf("<<<", StringComparison.InvariantCultureIgnoreCase);

            while (x > -1)
            {
                y = Text1.Text.IndexOf(":", x + 1, StringComparison.InvariantCultureIgnoreCase);

                if (y > -1)
                {
                    f_id = Text1.Text.Substring(x + 3, y - x - 3);
                    z = Text1.Text.IndexOf(">>>", y + 1, StringComparison.InvariantCultureIgnoreCase);
                    if (z > 0)
                        orderErr = Text1.Text.Substring(y + 1, z - y - 1);
                    else
                        orderErr = "";

                    if (util_functions.isnumeric(f_id))
                    {
                        Form1.printMsg.SetMsg("Printing order # " + f_id);
                        Form1.printMsg.Show();
                        if (string.Compare(orderErr, "no", true) == 0)
                            util_functions.Print_Order(f_id, Form1.p1, 1);
                        if (pStart < x)
                            util_functions.printErrText(Text1.Text.Substring(pStart, x - pStart), Form1.p2);
                        Form1.printMsg.Hide();

                    }
                    else
                        MessageBox.Show("Error: Unable to print order due to insufficient response information.");

                }

                if (z > x)
                    pStart = z + 3;
                else
                    pStart = x + 3;

                x = Text1.Text.IndexOf("<<<", x + 3, StringComparison.InvariantCultureIgnoreCase);
            }

            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str1, fName;
            int x, y;
            DateTime ediDate;
            StreamWriter file1;

            button2.Enabled = false;
            if (DateTime.TryParse(curDate.Text, out ediDate))
            {
                str1 = util_functions.Get_Web_Page("/admin/vb_EDI_Export.cfm", "curDate=" + util_functions.urlEncoded(curDate.Text.Trim()));
                fName = ediDate.ToString("MMddyyyy");
            }
            else if (OrderNum.Text.Trim() != "")
            {
                str1 = util_functions.Get_Web_Page("/admin/vb_EDI_Export.cfm", "ordernum=" + util_functions.urlEncoded(OrderNum.Text.Trim()));
                fName = OrderNum.Text.Trim();
            }
            else
            {
                MessageBox.Show("Please enter either a valid date or a valid order number.");
                button2.Enabled = true;
                return;
            }

            x = str1.IndexOf("<>", StringComparison.InvariantCultureIgnoreCase);
            if (x < 0)
            {
                x = str1.IndexOf("nr", StringComparison.InvariantCultureIgnoreCase);
                if (x > -1)
                    MessageBox.Show("There were no invoices found for that date.");
                else
                {
                    x = str1.IndexOf("err", StringComparison.InvariantCultureIgnoreCase);
                    if (x > -1)
                        MessageBox.Show("Error: Invoice(s) were found but one ore more matching orders were not located.  This indicates an invoice exists without a corresponding order.");
                    else
                        MessageBox.Show("Error: Export file has an invalid format and cannot be written out.");
                }
            }
            else
            {
                Form1.cfid = str1.Substring(0, x);
                str1 = str1.Substring(x + 4);
                x = Form1.cfid.IndexOf(":", StringComparison.InvariantCultureIgnoreCase);
                if (x > -1)
                {
                    Form1.cftoken = Form1.cfid.Substring(x + 1);
                    Form1.cfid = Form1.cfid.Substring(0, x);
                }

                Text1.Text = str1;

                if (String.Compare(EDIOut.Text.Substring(EDIOut.Text.Length - 1), "\\") != 0)
                {
                    EDIOut.Text = EDIOut.Text + "\\";
                    Form1.EDIOut = EDIOut.Text;
                }

                try
                {
                    file1 = File.CreateText(EDIOut.Text + fName + ".csv");
                    file1.WriteLine(str1);
                    file1.Close();
                }
                catch
                {
                    MessageBox.Show("Error: Unable to open file " + EDIOut.Text + fName + ".csv\n\nThe export process was not successful.");
                }

            }

            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str1, fName;
            int x;
            StreamWriter file1;

            button3.Enabled = false;

            if (string.Compare(Text1.Text.Trim(), "") == 0)
            {
                MessageBox.Show("Please enter a list of order numbers one per line in the main text field.");
                button3.Enabled = true;
                return;
            }

            x = Text1.Text.IndexOf("\n", StringComparison.InvariantCultureIgnoreCase);
            if (x < 0)
                fName = Text1.Text;
            else
                fName = Text1.Text.Substring(0, x);

            str1 = util_functions.Get_Web_Page("/admin/vb_EDI_ASN_Export.cfm", "ordernum=" + util_functions.urlEncoded(Text1.Text.Trim()));

            x = str1.IndexOf("<>", StringComparison.InvariantCultureIgnoreCase);
            if (x < 0)
            {
                x = str1.IndexOf("nr", StringComparison.InvariantCultureIgnoreCase);
                if (x > -1)
                    MessageBox.Show("There were no orders found for that date.");
                else
                {
                    x = str1.IndexOf("err", StringComparison.InvariantCultureIgnoreCase);
                    if (x > -1)
                        MessageBox.Show("Error: An unkown error occured.");
                    else
                        MessageBox.Show("Error: Export file has an invalid format and cannot be written out.");
                }
            }
            else
            {
                Form1.cfid = str1.Substring(0, x);
                str1 = str1.Substring(x + 4);
                x = Form1.cfid.IndexOf(":", StringComparison.InvariantCultureIgnoreCase);
                if (x > -1)
                {
                    Form1.cftoken = Form1.cfid.Substring(x + 1);
                    Form1.cfid = Form1.cfid.Substring(0, x);
                }

                Text1.Text = str1;

                if (String.Compare(EDIOut.Text.Substring(EDIOut.Text.Length - 1), "\\") != 0)
                {
                    EDIOut.Text = EDIOut.Text + "\\";
                    Form1.EDIOut = EDIOut.Text;
                }

                try
                {
                    file1 = File.CreateText(EDIOut.Text + "shipping\\" + fName + ".csv");
                    file1.WriteLine(str1);
                    file1.Close();
                }
                catch
                {
                    MessageBox.Show("Error: Unable to open file " + EDIOut.Text + "shipping\\" + fName + ".csv\n\nThe export process was not successful.");
                }
            }

            button3.Enabled = true;
        }
    }
}
