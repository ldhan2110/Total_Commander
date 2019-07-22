using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalCommander
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }


        public void button1_Click(object sender, EventArgs e)
        {
            button1.Tag = false;
            this.Close();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            button2.Tag = false;
            this.Close();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            button3.Tag = false;
            this.Close();
        }

        public void button4_Click(object sender, EventArgs e)
        {
            button4.Tag = false;
            this.Close();
        }

        public void button5_Click(object sender, EventArgs e)
        {
            button5.Tag = false;
            this.Close();
        }
    }
}
