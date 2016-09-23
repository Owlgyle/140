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
    public partial class PrintingBox : Form
    {
        public PrintingBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Print_Invoice();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Print_Order();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Print_Quote();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void invoiceNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Print_Invoice();
        }

        private void orderNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Print_Order();

        }

        private void quoteID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Print_Quote();

        }

        public void Print_Invoice()
        {
            Form1.printMsg.SetMsg("Printing invoice # " + invoiceNum.Text);
            Form1.printMsg.Show();
            util_functions.Print_Invoice(invoiceNum.Text.Trim(), Form1.p2, 1, false);
            Form1.printMsg.Hide();
        }

        public void Print_Order()
        {
            Form1.printMsg.SetMsg("Printing order # " + orderNum.Text);
            Form1.printMsg.Show();
            util_functions.Print_Order(orderNum.Text.Trim(), Form1.p1, 2);
            Form1.printMsg.Hide();
        }

        public void Print_Quote()
        {
            Form1.printMsg.SetMsg("Printing quote " + quoteID.Text);
            Form1.printMsg.Show();
            util_functions.Print_Quote(quoteID.Text.Trim(), Form1.p1, 2);
            Form1.printMsg.Hide();
        }
    }
}
