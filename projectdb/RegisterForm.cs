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
    public partial class RegisterForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-I4RT4Q5\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");
        
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(updatesource.var != -1)
            {
                con.Open();
                string query = "update Student  set FirstName = '" + textBox1.Text.ToString() + "', LastName= '" + textBox2.Text.ToString() + "' , Email='" + textBox6.Text.ToString() + "', Contact= '" + textBox3.Text.ToString() + "', RegistrationNumber= '" + textBox4.Text.ToString() + "'  where Id ='"+updatesource.var+"' " ;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfull");
            }
            else
            {
                con.Open();
                string query = "INSERT INTO Student(FirstName,LastName ,Email, Contact,RegistrationNumber,Status) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "', '" + Convert.ToInt32(textBox5.Text) + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfull");
            }

            ManageStudent frm = new ManageStudent();
            this.Hide();
           
            frm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            button1.Text = "Register";
            if (updatesource.var != -1)
            {
                button1.Text = "Update";
                con.Open();
                string query = "Select * from Student WHERE Id=" + updatesource.var;
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader read = sqlCommand.ExecuteReader();
                while (read.Read())
                {
                    textBox1.Text = read["FirstName"].ToString();
                    textBox2.Text = read["LastName"].ToString();
                    textBox6.Text = read["Email"].ToString();
                    textBox3.Text = read["Contact"].ToString();
                    textBox4.Text = read["RegistrationNumber"].ToString();
                }
                con.Close();
            }

        }
    }
}
