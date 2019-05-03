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
    public partial class AddClo1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-I4RT4Q5\\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True");
      
        
        public AddClo1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (updatesource.var != -1)
            {
                con.Open();
                string query = "update clo  set Name = '" + textBox1.Text.ToString() + "' where Id = '"+updatesource.var+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfull");
            }
            else
            {
                con.Open();
                string query = "INSERT INTO Clo(Name, DateCreated, DateUpdated) VALUES ('" + textBox1.Text.ToString() + "','" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + "','" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt") + "')";
                SqlCommand com = new SqlCommand(query, con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfull!");
                Manage_Clo gree = new Manage_Clo();
                this.Hide();
                gree.Show();
            }
        }

        private void AddClo1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Manage_Clo vree = new Manage_Clo();
            this.Hide();
            vree.Show();        }
    }
}
