using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public const byte numLabelPrinters = 3;
        public static string cfid, cftoken, un, pw, contractEmailList="", priceChangeCode = "", fSize, fName, fSize2, fName2, fSize3, fName3, serverUrl, p1, p2, p3, schedulingTemplatePath, contractUploadPath;
        public static string[] labelPrinter = new string[numLabelPrinters];
        public static string fontBCode1, fontBCode2, fontSizeBCode1, fontSizeBCode2;
        public static int printWaitTimeMin = 5, printWaitTimePerPage = 1;
        public static bool checkForPoPermission = false, checkForPos, mouseDown;
        public static string EDIServer, EDIIN, EDIOut;

        public static Orders Orders = new Orders();
        public static WebBrowser Browser = new WebBrowser();
        public static PrintDocument pdoc1 = new PrintDocument();
        public static Fax fax = new Fax();
        public static MsgBox printMsg = new MsgBox();
        public static SetPriceForm SetPrice = new SetPriceForm();
        public static QuotePricing SetQuotePrice = new QuotePricing();
        public static EDI edi = new EDI();
        public static PrintingBox PrintingForm = new PrintingBox();
        public static QuoteEntry QuoteEntry = new QuoteEntry();
        public static Contracts ContractsEntry = new Contracts();
        public static Email EmailDialog = new Email();
        public static Options OptionsForm = new Options();
        public static OpenFile selectFile = new OpenFile();

        SqlConnection conn = new SqlConnection("Data Source=Romeo;Initial Catalog=Royal;User ID=royal;password=wkjwuq");
        SqlDataReader rdr = null;

        public static InstalledFontCollection ifc = new InstalledFontCollection();

        public Form1()
        {
            InitializeComponent();
            
            int x;

            try
            {
                this.DoubleClick += new EventHandler(Form1_DoubleClick);
                
                checkForPos = false;
                mouseDown = false;
                cfid = "";
                cftoken = "";
                loadSettings();
                OptionsForm.Load_Settings();

                username.Text = un;
                password.Text = pw;
                FontS.Text = fSize;

                fontN.Items.Clear();
                FontN2.Items.Clear();
                FontN3.Items.Clear();

                for (x = 0; x < ifc.Families.Length; x++)
                {
                    fontN.Items.Add(ifc.Families[x].Name);
                    FontN2.Items.Add(ifc.Families[x].Name);
                    FontN3.Items.Add(ifc.Families[x].Name);
                }

                for (x = 0; x < PrinterSettings.InstalledPrinters.Count; x++)
                {
                    printer1.Items.Add(PrinterSettings.InstalledPrinters[x].ToString());
                    printer2.Items.Add(PrinterSettings.InstalledPrinters[x].ToString());
                    printer3.Items.Add(PrinterSettings.InstalledPrinters[x].ToString());
                }

                if (fName != "")
                {
                    for (x = 0; x < fontN.Items.Count; x++)
                        if (fName == fontN.Items[x].ToString())
                            fontN.SelectedIndex = x;
                }
                else
                    fontN.SelectedIndex = 0;

                if (fName2 != "")
                {
                    for (x = 0; x < FontN2.Items.Count; x++)
                        if (fName2 == FontN2.Items[x].ToString())
                            FontN2.SelectedIndex = x;
                }
                else
                    FontN2.SelectedIndex = 0;

                if (fName3 != "")
                {
                    for (x = 0; x < FontN3.Items.Count; x++)
                        if (fName3 == FontN3.Items[x].ToString())
                            FontN3.SelectedIndex = x;
                }
                else
                    FontN3.SelectedIndex = 0;

                for (x = 0; x < printer1.Items.Count; x++)
                {
                    if (printer1.Items[x].ToString() == p1)
                        printer1.SelectedIndex = x;
                }
                for (x = 0; x < printer2.Items.Count; x++)
                {
                    if (printer2.Items[x].ToString() == p2)
                        printer2.SelectedIndex = x;
                }
                for (x = 0; x < printer3.Items.Count; x++)
                {
                    if (printer3.Items[x].ToString() == p3)
                        printer3.SelectedIndex = x;
                }

                FontS.Text = fSize;
                FontS2.Text = fSize2;
                FontS3.Text = fSize3;

                Get_User_Settings();

            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message);
            }
        }

        public void Get_User_Settings()
        {
            string results, strData;
            int x;

            try
            {
                checkForPoPermission = false;

                results = util_functions.Get_Web_Page("/admin/Get_User_Setttings.cfm");

                x = results.IndexOf("<>");
                if (x >= 0 && results.Length > x + 2)
                {
                    results = results.Substring(x + 2, results.Length - x - 2);
                    while (results.Length > 0)
                    {
                        x = results.IndexOf(",");
                        if (x >= 0)
                        {
                            strData = results.Substring(0, x);
                            if (results.Length > x + 1)
                                results = results.Substring(x + 1);
                            else
                                results = "";
                        }
                        else
                        {
                            strData = results;
                            results = "";
                        }

                        if (string.Compare(strData, "checkPos", true) == 0)
                        {
                            checkForPoPermission = true;
                        }
                    }
                }

                if (!checkForPoPermission)
                {
                    checkForPos = false;
                    AutoPOProcessing.Visible = false;
                }



                results = util_functions.Get_Web_Page("/admin/Get_User_Settings_PriceCode.cfm");

                x = results.IndexOf("<>");
                if (x >= 0 && results.Length > x + 2)
                {
                    priceChangeCode = results.Substring(x + 2, results.Length - x - 2).Trim();
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nAn Error Occured while loading the user settings.");
            }
        }

        public void loadSettings()
        {
            contractUploadPath = Properties.Settings.Default.contractUploadDirectory;
            schedulingTemplatePath = Properties.Settings.Default.SchedulingDirectory;
            printWaitTimeMin = Properties.Settings.Default.waitTimeMin;
            printWaitTimePerPage = Properties.Settings.Default.waitTimePerPage;

            contractEmailList = Properties.Settings.Default.contractEmailList;

            fName = Properties.Settings.Default.fName;
            fSize = Properties.Settings.Default.fSize;
            fName2 = Properties.Settings.Default.fName2;
            fSize2 = Properties.Settings.Default.fSize2;
            fName3 = Properties.Settings.Default.fName3;
            fSize3 = Properties.Settings.Default.fSize3;

            fontBCode1 = Properties.Settings.Default.fontNameBcode1;
            fontBCode2 = Properties.Settings.Default.fontNameBcode2;
            fontSizeBCode1 = Properties.Settings.Default.fontSizeBcode1;
            fontSizeBCode2 = Properties.Settings.Default.fontSizeBcode2;

            EDIServer = Properties.Settings.Default.EDIServer;
            EDIIN = Properties.Settings.Default.EDIIN;
            EDIOut = Properties.Settings.Default.EDIOut;

            checkForPos = Properties.Settings.Default.checkForPos;
            if (checkForPos)
                AutoPOProcessing.CheckState = CheckState.Checked;

            serverUrl = Properties.Settings.Default.servername;
            servername.Text = serverUrl;

            un = Properties.Settings.Default.un;
            pw = Properties.Settings.Default.pw;
            p1 = Properties.Settings.Default.p1;
            p2 = Properties.Settings.Default.p2;
            p3 = Properties.Settings.Default.p3;
            labelPrinter[0] = Properties.Settings.Default.labelPrinter1;
            labelPrinter[1] = Properties.Settings.Default.labelPrinter2;
            labelPrinter[2] = Properties.Settings.Default.labelPrinter3;

            Orders.Width = Properties.Settings.Default.owidth;
            Orders.Height = Properties.Settings.Default.oheight;
            Orders.Left = Properties.Settings.Default.oleft;
            Orders.Top = Properties.Settings.Default.otop;

            Browser.Width = Properties.Settings.Default.bwidth;
            Browser.Height = Properties.Settings.Default.bheight;
            Browser.Left = Properties.Settings.Default.bleft;
            Browser.Top = Properties.Settings.Default.btop;

            if (Browser.Width < 200)
                Browser.Width = 200;

            if (Browser.Height < 1050)
                Browser.Height = 1050;

            if (Browser.Left < 0)
                Browser.Left = 0;

            if (Browser.Top < 0)
                Browser.Top = 0;

        }

        public static void saveSettings()
        {
            Properties.Settings.Default.contractUploadDirectory = contractUploadPath;
            Properties.Settings.Default.SchedulingDirectory = schedulingTemplatePath;
            Properties.Settings.Default.waitTimeMin = printWaitTimeMin;
            Properties.Settings.Default.waitTimePerPage = printWaitTimePerPage;

            Properties.Settings.Default.contractEmailList = contractEmailList;

            Properties.Settings.Default.fName = fName;
            Properties.Settings.Default.fSize = fSize;
            Properties.Settings.Default.fName2 = fName2;
            Properties.Settings.Default.fSize2 = fSize2;
            Properties.Settings.Default.fName3 = fName3;
            Properties.Settings.Default.fSize3 = fSize3;

            Properties.Settings.Default.fontNameBcode1 = fontBCode1;
            Properties.Settings.Default.fontNameBcode2 = fontBCode2;
            Properties.Settings.Default.fontSizeBcode1 = fontSizeBCode1;
            Properties.Settings.Default.fontSizeBcode2 = fontSizeBCode2;

            Properties.Settings.Default.EDIServer = EDIServer;
            Properties.Settings.Default.EDIIN = EDIIN;
            Properties.Settings.Default.EDIOut = EDIOut;

            Properties.Settings.Default.checkForPos = checkForPos;

            Properties.Settings.Default.servername = serverUrl;

            Properties.Settings.Default.un = un;
            Properties.Settings.Default.pw = pw;
            Properties.Settings.Default.p1 = p1;
            Properties.Settings.Default.p2 = p2;
            Properties.Settings.Default.p3 = p3;
            Properties.Settings.Default.labelPrinter1 = labelPrinter[0];
            Properties.Settings.Default.labelPrinter2 = labelPrinter[1];
            Properties.Settings.Default.labelPrinter3 = labelPrinter[2];

            Properties.Settings.Default.owidth = Orders.Width;
            Properties.Settings.Default.oheight = Orders.Height;
            Properties.Settings.Default.oleft = Orders.Left;
            Properties.Settings.Default.otop = Orders.Top;

            Properties.Settings.Default.bwidth = Browser.Width;
            Properties.Settings.Default.bheight = Browser.Height;
            Properties.Settings.Default.bleft = Browser.Left;
            Properties.Settings.Default.btop = Browser.Top;

            Properties.Settings.Default.Save();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Quit();
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (rdr != null)
                rdr.Close();

            if (conn != null)
                conn.Close();

            saveSettings();
        }

        public void Quit()
        {
            this.Close();
        }

        public void Check_POs( bool manualMode )
        {
            string results;
            int x;

            try
            {
                if ( !manualMode && (!checkForPoPermission || !checkForPos))
                    return;

                results = util_functions.Get_Web_Page("/admin/Server_Process_PO.cfm");

                x = results.IndexOf("<>");
                if (x >= 0 && results.Length > x + 2)
                {
                    results = results.Substring(x + 2, results.Length - x - 2);
                    MessageBox.Show(results);
                }
                else
                    MessageBox.Show("No pos found to process.");

            }
            catch (Exception e1)
            {
                MessageBox.Show("An error has occured.\n\n" + e1.Message + "\n\nAn Error Occured while checking for scanned POs.");
            }
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            un = username.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (AutoPOProcessing.CheckState == CheckState.Checked)
            {
                timer1.Interval = 240000;
                Check_POs(false);
            }
            else
            {
                timer1.Interval = 240000;
            }
        }

        private void servername_TextChanged(object sender, EventArgs e)
        {
            serverUrl = servername.Text;
        }

        private void printer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1  = printer1.SelectedItem.ToString();
        }

        private void printer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2 = printer2.SelectedItem.ToString();
        }

        private void printer3_SelectedIndexChanged(object sender, EventArgs e)
        {
            p3 = printer3.SelectedItem.ToString();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            pw = password.Text;
        }

        private void FontS_TextChanged(object sender, EventArgs e)
        {
            fSize = FontS.Text;
        }

        private void FontS2_TextChanged(object sender, EventArgs e)
        {
            fSize2 = FontS2.Text;
        }

        private void fontN_SelectedIndexChanged(object sender, EventArgs e)
        {
            fName = fontN.Text;
        }

        private void FontN2_SelectedIndexChanged(object sender, EventArgs e)
        {
            fName2 = FontN2.Text;
        }

        private void AutoPOProcessing_CheckedChanged(object sender, EventArgs e)
        {
            checkForPos = false;
            if (AutoPOProcessing.CheckState == CheckState.Checked)
                checkForPos = true;
        }

        private void Button_Order_Click(object sender, EventArgs e)
        {
            if (!Orders.IsDisposed)
                Orders.Show();
            else
            {
                Orders = new Orders();
                Orders.Show();
            }
        }

        private void Button_Edi_Click(object sender, EventArgs e)
        {
            if (!edi.IsDisposed)
                edi.Show();
            else
            {
                edi = new EDI();
                edi.Show();
            }
        }

        private void Button_WebForms_Click(object sender, EventArgs e)
        {
            if (!Browser.IsDisposed)
                Browser.Show();
            else
            {
                Browser = new WebBrowser();
                Browser.Show();
            }
        }

        private void Button_Printing_Click(object sender, EventArgs e)
        {
            if (!PrintingForm.IsDisposed)
                PrintingForm.Show();
            else
            {
                PrintingForm = new PrintingBox();
                PrintingForm.Show();
            }
        }

        private void Button_Scanned_POs_Click(object sender, EventArgs e)
        {
            Check_POs(true);
        }

        private void Button_Quotes_Click(object sender, EventArgs e)
        {
            if (! QuoteEntry.IsDisposed)
                QuoteEntry.Show();
            else
            {
                QuoteEntry = new QuoteEntry();
                QuoteEntry.Show();
            }

        }

        private void FontN3_SelectedIndexChanged(object sender, EventArgs e)
        {
            fName3 = FontN3.Text;
        }

        private void FontS3_TextChanged(object sender, EventArgs e)
        {
            fSize3 = FontS3.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ContractsEntry.IsDisposed)
                ContractsEntry.Show();
            else
            {
                ContractsEntry = new Contracts();
                ContractsEntry.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (! OptionsForm.IsDisposed)
                OptionsForm.Show();
            else
            {
                OptionsForm = new Options();
                OptionsForm.Show();
            }
            OptionsForm.Load_Settings();
        }
    }
}

