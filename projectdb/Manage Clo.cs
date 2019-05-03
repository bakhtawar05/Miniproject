using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace projectdb
{
    public partial class Manage_Clo : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-I4RT4Q5\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");
        public Manage_Clo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {




            AddClo1 add = new AddClo1();
            this.Hide();
            add.Show();
       
            

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Manage_Clo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet1.Clo' table. You can move, or remove it, as needed.
            this.cloTableAdapter.Fill(this.projectBDataSet1.Clo);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fuu = new Form1();
            this.Hide();
            fuu.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Update")
            {

                updatesource.var = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                this.Hide();
                AddClo1 clo = new AddClo1();
                clo.Show();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Delete")
            {
                int stdId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                if (MessageBox.Show("Do you want to delete " + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM Clo WHERE Id  = '" + stdId + "'", con);
                    command.ExecuteNonQuery();
                    con.Close();
                    this.cloTableAdapter.Fill(this.projectBDataSet1.Clo);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
