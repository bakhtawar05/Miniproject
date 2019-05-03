using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectdb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manage_Clo tru = new Manage_Clo();
            this.Hide();
            tru.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manage_Rubric gre = new Manage_Rubric();
            this.Hide();
            gre.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageStudent gre = new ManageStudent();
            this.Hide();
            gre.Show();
        }
    }
}
