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
    public partial class Email : Form
    {
        public bool returnValue;
        public string email;

        public Email()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            returnValue = true;
            email = emailAddress.Text.Trim();
            this.emailAddress.Text = "";
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            returnValue = false;
            this.Hide();
        }

        private void Email_Load(object sender, EventArgs e)
        {
            emailAddress.Text = email;
            returnValue = false;

        }
    }
}
