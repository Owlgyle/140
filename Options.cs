using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.contractEmailList = contractEmailList.Text;

            Form1.schedulingTemplatePath = schedulingTemplatePath.Text.Trim();
            Form1.contractUploadPath = contractPath.Text.Trim();

            while( Form1.schedulingTemplatePath.Contains("\\\\"))
                Form1.schedulingTemplatePath = Form1.schedulingTemplatePath.Replace("\\\\", "\\");

            while (Form1.contractUploadPath.Contains("\\\\"))
                Form1.contractUploadPath = Form1.contractUploadPath.Replace("\\\\", "\\");
            if (!Form1.contractUploadPath.EndsWith("\\"))
                Form1.contractUploadPath = Form1.contractUploadPath + "\\";


            Form1.printWaitTimePerPage = Convert.ToInt32(waitTimePerPage.Text);
            Form1.printWaitTimeMin = Convert.ToInt32(minWaitTime.Text);
            Form1.saveSettings();

            Form1.fontBCode1 = fontBarcode1.Text;
            Form1.fontBCode2 = fontBarcode2.Text;
            Form1.fontSizeBCode1 = fontSizeBarcode1.Text;
            Form1.fontSizeBCode2 = fontSizeBarcode2.Text;

            Form1.labelPrinter[0] = printer1.Text;
            Form1.labelPrinter[1] = printer2.Text;
            Form1.labelPrinter[2] = printer3.Text;

            Form1.saveSettings();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Load_Settings();

            this.Hide();
        }

        public void Load_Settings()
        {
            ushort x;

            SqlConnection conn = new SqlConnection("Data Source=Romeo;Initial Catalog=Royal;User ID=royal;password=wkjwuq");
            SqlCommand cmd;
            SqlDataReader rdr = null;

            contractEmailList.Text = Form1.contractEmailList;
            schedulingTemplatePath.Text = Form1.schedulingTemplatePath;
            contractPath.Text = Form1.contractUploadPath;
            waitTimePerPage.Text = Form1.printWaitTimePerPage.ToString();
            minWaitTime.Text = Form1.printWaitTimeMin.ToString();

            for (x = 0; x < Form1.ifc.Families.Length; x++)
            {
                fontBarcode1.Items.Add(Form1.ifc.Families[x].Name);
                fontBarcode2.Items.Add(Form1.ifc.Families[x].Name);
            }

            if (Form1.fontBCode1 != "")
            {
                for (x = 0; x < fontBarcode1.Items.Count; x++)
                    if (Form1.fontBCode1 == fontBarcode1.Items[x].ToString())
                        fontBarcode1.SelectedIndex = x;
            }
            else
                fontBarcode1.SelectedIndex = 0;

            if (Form1.fontBCode2 != "")
            {
                for (x = 0; x < fontBarcode2.Items.Count; x++)
                    if (Form1.fontBCode2 == fontBarcode2.Items[x].ToString())
                        fontBarcode2.SelectedIndex = x;
            }
            else
                fontBarcode2.SelectedIndex = 0;

            fontSizeBarcode1.Text = Form1.fontSizeBCode1;
            fontSizeBarcode2.Text = Form1.fontSizeBCode2;

            printer1.Items.Clear();
            printer2.Items.Clear();
            printer3.Items.Clear();

            for (x = 0; x < PrinterSettings.InstalledPrinters.Count; x++)
            {
                printer1.Items.Add(PrinterSettings.InstalledPrinters[x].ToString());
                printer2.Items.Add(PrinterSettings.InstalledPrinters[x].ToString());
                printer3.Items.Add(PrinterSettings.InstalledPrinters[x].ToString());
            }

            for (x = 0; x < printer1.Items.Count; x++)
            {
                if (printer1.Items[x].ToString() == Form1.labelPrinter[0])
                    printer1.SelectedIndex = x;
            }
            for (x = 0; x < printer2.Items.Count; x++)
            {
                if (printer2.Items[x].ToString() == Form1.labelPrinter[1])
                    printer2.SelectedIndex = x;
            }
            for (x = 0; x < printer3.Items.Count; x++)
            {
                if (printer3.Items[x].ToString() == Form1.labelPrinter[2])
                    printer3.SelectedIndex = x;
            }


            conn.Open();
            cmd = new SqlCommand("select labelName,labelIndex from Labels where active = 1 order by labelIndex asc", conn);
            rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
                while (rdr.Read())
                {
                    switch (Convert.ToInt32(rdr["labelIndex"].ToString()))
                    {
                        case 0:
                            printer0Label.Text = rdr["labelName"].ToString();
                            break;
                        case 1:
                            printer1Label.Text = rdr["labelName"].ToString();
                            break;
                        case 2:
                            printer2Label.Text = rdr["labelName"].ToString();
                            break;
                    }
                }
            if (rdr != null)
                rdr.Close();
            if (conn != null)
                conn.Close();
        }

        private void Options_Load(object sender, EventArgs e)
        {
        }
    }
}
