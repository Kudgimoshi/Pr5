using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pp20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void openChild(Panel pen, Form emptyF)
        {
            emptyF.TopLevel = false;
            emptyF.FormBorderStyle = FormBorderStyle.None;
            emptyF.Dock = DockStyle.Fill;
            pen.Controls.Add(emptyF);
            emptyF.BringToFront();
            emptyF.Show();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChild(panel2, new Form2());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChild(panel2, new Form3());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChild(panel2, new Form4());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChild(panel2, new Form5());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChild(panel2, new Form6());
        }
    }
}
