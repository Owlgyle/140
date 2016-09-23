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
    public partial class ContractImport : Form
    {
        bool fileSelected = false;
        string fileName, fullPathToFile;

        public ContractImport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Form1.selectFile.IsDisposed)
                Form1.selectFile = new OpenFile();

            Form1.selectFile.ShowDialog();

            if (Form1.selectFile.returnStatus)
            {
                fullPathToFile = Form1.selectFile.selectedFile.Trim();
                if (!File.Exists(fullPathToFile))
                {
                    MessageBox.Show("File not found.");
                    return;
                }
                fileName = Path.GetFileName(fullPathToFile);

                label1.Text = "File to upload: " + fileName;
                buttonImport.Enabled = true;
                fileSelected = true;
            }
        }

        void Display_Results(string results)
        {
        }

        private void ContractImport_Load(object sender, EventArgs e)
        {
            Clear_File_Selection();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            int x, y = 0;
            string results;

            if (!fileSelected)
            {
                MessageBox.Show("Please select a file.");
                return;
            }

            if (!File.Exists(fullPathToFile))
            {
                MessageBox.Show("File not found.");
                Clear_File_Selection();
                return;
            }

            while (File.Exists(Form1.contractUploadPath + fileName) && y < 20)
            {
                fileName = "a" + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.DayOfYear.ToString() + fileName;
                ++y;
            }
            if (File.Exists(Form1.contractUploadPath + fileName))
            {
                MessageBox.Show("Error: File exists on the server. Please delete before proceeding.\n\n" + Form1.contractUploadPath + fileName);
                return;
            }

            File.Copy(fullPathToFile, Form1.contractUploadPath + fileName);


            string strData = "Fname=" + util_functions.urlEncoded(fileName);

            results = util_functions.Post_Web_Form("/admin/vb_Contract_Load.cfm", strData);

            x = results.IndexOf("<>");
            if (x >= 0 && results.Length > x + 2)
            {
                results = results.Substring(x + 2, results.Length - x - 2);
                if (results.Trim().Length > 0)
                    Display_Results(results);
                else
                    MessageBox.Show("No data returned\n\n" + results);
            }
            else
                MessageBox.Show("Invalid response.  Please check the import file's content and try again.");

            Clear_File_Selection();
        }

        void Clear_File_Selection()
        {
            fileSelected = false;
            buttonImport.Enabled = false;
            label1.Text = "No File Selected.";
        }
    }
}
