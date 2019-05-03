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
    public partial class Manage_Rubric : Form
    {
        SqlConnection con = new SqlConnection("Data Source= DESKTOP - I4RT4Q5\\SQLEXPRESS; Initial Catalog = ProjectB; Integrated Security = True");
        public Manage_Rubric()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Update")
            {

                updatesource.var = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                this.Hide();
                Add_Rubric add= new Add_Rubric();
                add.Show();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Delete")
            {
                int stdId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                if (MessageBox.Show("Do you want to delete " + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM RUBRIC WHERE Id  = '" + stdId + "'", con);
                    command.ExecuteNonQuery();
                    con.Close();
                    this.rubricTableAdapter.Fill(this.projectBDataSet1.Rubric);

                }
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Add_Rubric jee = new Add_Rubric();
            this.Hide();
            jee.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 tee = new Form1();
            this.Hide();
            tee.Show();
        }

        private void Manage_Rubric_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet1.Rubric' table. You can move, or remove it, as needed.
            this.rubricTableAdapter.Fill(this.projectBDataSet1.Rubric);

        }
    }
}
