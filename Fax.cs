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
    public partial class Fax : Form
    {
        public Fax()
        {
            InitializeComponent();
        }

        private void Fax_Load(object sender, EventArgs e)
        {
        }

        public string get_Conf_Notes()
        {
            return conf_notes.Text;
        }

        public void set_Conf_Notes(string newvalue)
        {
            conf_notes.Text = newvalue;
        }

        public string get_Conf_Fax()
        {
            return conf_fax.Text;
        }

        public void set_Conf_Fax(string newvalue)
        {
            conf_fax.Text = newvalue;
        }

        public string get_Conf_Email()
        {
            return conf_email.Text;
        }

        public void set_Conf_Email(string newvalue)
        {
            conf_email.Text = newvalue;
        }

        public string get_Conf_Contact()
        {
            return conf_contact.Text;
        }

        public void set_Conf_Contact(string newvalue)
        {
            conf_contact.Text = newvalue;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Orders.poFaxNow = true;
            Orders.pofaxEmail = conf_email.Text;
            Orders.pofaxFaxNum = conf_fax.Text;
            Orders.pofaxNotes = conf_notes.Text;
            Orders.pofaxContact = conf_contact.Text;

            conf_email.Text = "";
            conf_fax.Text = "";
            conf_notes.Text = "";
            conf_contact.Text = "";

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Orders.poFaxNow = false;

            Orders.pofaxEmail = conf_email.Text;
            Orders.pofaxFaxNum = conf_fax.Text;
            Orders.pofaxNotes = conf_notes.Text;
            Orders.pofaxContact = conf_contact.Text;

            conf_email.Text = "";
            conf_fax.Text = "";
            conf_notes.Text = "";
            conf_contact.Text = "";

            this.Hide();
        }
    }
}
