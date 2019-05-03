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
    public partial class ManageStudent : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-I4RT4Q5\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");
        public ManageStudent()
        {
            InitializeComponent();
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Update")
            {
              
                updatesource.var = Convert.ToInt32(DataGridView1.Rows[e.RowIndex].Cells[0].Value);
                this.Hide();
                RegisterForm registerStudent = new RegisterForm();
                registerStudent.Show();
            }
            if (DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Delete")
            {
                int stdId = Convert.ToInt32(DataGridView1.Rows[e.RowIndex].Cells[0].Value);
                if (MessageBox.Show("Do you want to delete " + DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM Student WHERE Id  = '" + stdId + "'", con);
                    command.ExecuteNonQuery();
                    con.Close();
                    this.studentTableAdapter.Fill(this.projectBDataSet1.Student);
                }
            }



             
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            this.Hide();
            register.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void ManageStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet1.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.projectBDataSet1.Student);
            // TODO: This line of code loads data into the 'projectBDataSet.Lookup' table. You can move, or remove it, as needed.
            this.lookupTableAdapter.Fill(this.projectBDataSet.Lookup);

        }

        private void TableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
