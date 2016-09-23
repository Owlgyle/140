using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class WebBrowser : Form
    {
        public WebBrowser()
        {
            InitializeComponent();
        }

        private void WebBrowser_Load(object sender, EventArgs e)
        {
            web1.Navigate("http://" + Form1.serverUrl + "/admin/index.cfm?f_username=" + Form1.un.Trim() + "&f_password=" + Form1.pw.Trim());
        }

        private void web1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            string str1,str2,str3;
            int x,y,z;

            str1 = web1.DocumentText;
            
            x = str1.IndexOf("cmd:", StringComparison.InvariantCultureIgnoreCase);
            if (x >= 0)
            {
                y = str1.IndexOf("=", x + 1, StringComparison.InvariantCultureIgnoreCase);
                if (y >= 0)
                {
                    str2 = str1.Substring(x + 4, y - x - 4);
                    if (string.Compare(str2, "printInv1") == 0)
                    {
                        z = str1.IndexOf(":", y + 1, StringComparison.InvariantCultureIgnoreCase);
                        if (z >= 0)
                        {
                            str2 = str1.Substring(y + 1, z - y - 1);
                            if (str2.StartsWith("\""))
                                str2 = str2.Substring(1);
                            if (str2.EndsWith("\""))
                                str2 = str2.Substring(0, str2.Length - 1);
                            util_functions.Print_Invoice(str2, Form1.p1, 1, false);
                            if (string.Compare(str1.Substring(z + 1, 4), "bill") == 0)
                                util_functions.Print_Invoice(str2, Form1.p3, 1, true);
                        }
                    }
                    else if (string.Compare(str2, "printInv2") == 0)
                    {
                        z = str1.IndexOf(":", y + 1, StringComparison.InvariantCultureIgnoreCase);
                        if (z >= 0)
                        {
                            str2 = str1.Substring(y + 1, z - y - 1);
                            if (str2.StartsWith("\""))
                                str2 = str2.Substring(1);
                            if (str2.EndsWith("\""))
                                str2 = str2.Substring(0, str2.Length - 1);
                            util_functions.Print_Invoice(str2, Form1.p1, 2, false);
                            if (string.Compare(str1.Substring(z + 1, 4), "bill") == 0)
                                util_functions.Print_Invoice(str2, Form1.p3, 1, true);
                        }
                    }
                    else if (string.Compare(str2, "printInv3") == 0)
                    {
                        z = str1.IndexOf(":", y + 1, StringComparison.InvariantCultureIgnoreCase);
                        if (z >= 0)
                        {
                            str2 = str1.Substring(y + 1, z - y - 1);
                            if (str2.StartsWith("\""))
                                str2 = str2.Substring(1);
                            if (str2.EndsWith("\""))
                                str2 = str2.Substring(0, str2.Length - 1);
                            util_functions.Print_Invoice(str2, Form1.p1, 3, false);
                            if (string.Compare(str1.Substring(z + 1, 4), "bill") == 0)
                                util_functions.Print_Invoice(str2, Form1.p3, 1, true);
                        }
                    }
                    else if (string.Compare(str2, "printInv1_2") == 0)
                    {
                        z = str1.IndexOf(":", y + 1, StringComparison.InvariantCultureIgnoreCase);
                        if (z >= 0)
                        {
                            str2 = str1.Substring(y + 1, z - y - 1);
                            if (str2.StartsWith("\""))
                                str2 = str2.Substring(1);
                            if (str2.EndsWith("\""))
                                str2 = str2.Substring(0, str2.Length - 1);
                            util_functions.Print_Invoice(str2, Form1.p1, 2, false);
                            if (string.Compare(str1.Substring(z + 1, 4), "bill") == 0)
                                util_functions.Print_Invoice(str2, Form1.p3, 1, true);
                        }
                    }
                    else if (string.Compare(str2, "printOrder") == 0)
                    {
                        z = str1.IndexOf(":", y + 1, StringComparison.InvariantCultureIgnoreCase);
                        if (z >= 0)
                        {
                            str2 = str1.Substring(y + 1, z - y - 1);
                            if (str2.StartsWith("\""))
                                str2 = str2.Substring(1);
                            if (str2.EndsWith("\""))
                                str2 = str2.Substring(0, str2.Length - 1);
                            util_functions.Print_Order(str2, Form1.p1, 2);
                        }
                    }
                    else if (string.Compare(str2, "EditQuote") == 0)
                    {
                        z = str1.IndexOf(":", y + 1, StringComparison.InvariantCultureIgnoreCase);
                        if (z >= 0)
                        {
                            str2 = str1.Substring(y + 1, z - y - 1);
                            if (str2.StartsWith("\""))
                                str2 = str2.Substring(1);
                            if (str2.EndsWith("\""))
                                str2 = str2.Substring(0, str2.Length - 1);

                            if (Form1.QuoteEntry.IsDisposed)
                                Form1.QuoteEntry = new QuoteEntry();
                            Form1.QuoteEntry.Show();
                            Form1.QuoteEntry.Set_Quote_ID(str2);
                            Form1.QuoteEntry.Update_Quote_Form();
                            Form1.QuoteEntry.Focus();
                        }
                    }
                    else if (string.Compare(str2, "CloneQuote") == 0)
                    {
                        z = str1.IndexOf(":", y + 1, StringComparison.InvariantCultureIgnoreCase);
                        if (z >= 0)
                        {
                            str2 = str1.Substring(y + 1, z - y - 1);
                            if (str2.StartsWith("\""))
                                str2 = str2.Substring(1);
                            if (str2.EndsWith("\""))
                                str2 = str2.Substring(0, str2.Length - 1);

                            if (Form1.QuoteEntry.IsDisposed)
                                Form1.QuoteEntry = new QuoteEntry();
                            Form1.QuoteEntry.Show();
                            Form1.QuoteEntry.Set_Quote_ID(str2);
                            Form1.QuoteEntry.Update_Quote_Form();
                            Form1.QuoteEntry.Clone_Quote();
                            Form1.QuoteEntry.Focus();
                        }
                    }
                    else if (string.Compare(str2, "EditContract") == 0)
                    {
                        z = str1.IndexOf(":", y + 1, StringComparison.InvariantCultureIgnoreCase);
                        if (z >= 0)
                        {
                            str2 = str1.Substring(y + 1, z - y - 1);
                            if (str2.StartsWith("\""))
                                str2 = str2.Substring(1);
                            if (str2.EndsWith("\""))
                                str2 = str2.Substring(0, str2.Length - 1);

                            if (Form1.ContractsEntry.IsDisposed)
                                Form1.ContractsEntry = new Contracts();
                            Form1.ContractsEntry.Show();
                            Form1.ContractsEntry.Set_Contract_ID(str2);
                            Form1.ContractsEntry.Update_Contract_Form();
                            Form1.ContractsEntry.Focus();
                        }
                    }
                    else if (string.Compare(str2, "PrintScheduling") == 0)
                    {
                        util_functions.Print_Labels();
                    }
                    else if (string.Compare(str2, "printOrderList") == 0)
                    {
                        z = str1.IndexOf(":", y + 1, StringComparison.InvariantCultureIgnoreCase);
                        if (z >= 0)
                        {
                            str2 = str1.Substring(y + 1, z - y - 1);

                            z = str2.IndexOf(",", StringComparison.InvariantCultureIgnoreCase);
                            if (z < 0)
                                util_functions.Print_Order(str2, Form1.p1, 2);  // Just one order to print
                            else
                            {
                                // Multipler orders separated by commas to print
                                
                                // str2 is now a string containing a list of comma separated orders with nothing else before or after the list
                                // z is the index of the first comma
                                while (str2.Length > 0)
                                {
                                    if (z != 0)    // Should always be true unless the list starts with a comma or has 2 commas in a row which would be an error cases. If z < 0, this is the last order in the list
                                    {
                                        if (z > 0)
                                            str3 = str2.Substring(0, z); // Next order
                                        else
                                            str3 = str2;    // Last order
                                        util_functions.Print_Order(str3, Form1.p1, 2);  // Just one order to print
                                    }
                                    // strip the order we just printed from the list and keep printing
                                    if (z < str2.Length - 1)
                                    {
                                        str2 = str2.Substring(z + 1, str2.Length - z - 1);
                                        z = str2.IndexOf(",", StringComparison.InvariantCultureIgnoreCase);
                                    }
                                    else
                                        str2 = "";  // List ended with a comma which shouldn't ever happen
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
