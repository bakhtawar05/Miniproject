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


    public partial class Add_Rubric : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-I4RT4Q5\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");
         

        public Add_Rubric()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (updatesource.var != -1)
            {
                con.Open();
                string query = "INSERT INTO RUBRIC( Details , CLOId) VALUES('" + textBox1.Text.ToString() + "', '" + Convert.ToInt32(textBox2.Text) + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfull");
            }
            else
            {
                con.Open();
                string query = "INSERT INTO RUBRIC( Details , CLOId) Values('" + textBox1.Text.ToString() + "','" + Convert.ToInt32(textBox2.Text) + "' )";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfull");
            }

           

            Manage_Rubric juu = new Manage_Rubric();
            this.Hide();
            juu.Show();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1 yuu = new Form1();
            this.Hide();
            yuu.Show();
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Add_Rubric_Load(object sender, EventArgs e)
        {
            Button1.Text = "ADD";
            if (updatesource.var != -1)
            {
                Button1.Text = "Update";
                con.Open();
                string query = "Select * from RUBRIC WHERE Id=" + updatesource.var;
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader read = sqlCommand.ExecuteReader();
                while (read.Read())
                {
                    textBox1.Text = read["Details"].ToString();
                    textBox2.Text = read["CLOId"].ToString();
                   
                }
                con.Close();
            }
        }
    }
}
