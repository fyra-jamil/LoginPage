using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace SimpleLoginPage
{
    public partial class Form2 : Form

  
    {
        public Form2()
        {
            SqlConnection login = new SqlConnection();
            login.ConnectionString = "Data Source =SYSCODE-SGT01;Initial Catalog=dummydummydb;Integrated Security=True";
            InitializeComponent();
            button1.Enabled = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            SqlConnection login = new SqlConnection();
            //connect to the database
            login.ConnectionString = "Data Source =SYSCODE-SGT01;Initial Catalog=dummydummydb;Integrated Security=True";
            login.Open();
            string sql = "";

            //command to the SQ
            sql="INSERT INTO Ayam(UserID,PasswordUser) values (@UserID,@Password)";

            
            SqlCommand ins = new SqlCommand(sql, login);
            ins.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = textBox1.Text;
            ins.Parameters.Add("@Password", SqlDbType.NVarChar).Value = textBox2.Text;
            ins.ExecuteNonQuery();
            MessageBox.Show("Success and Please Log In Back");
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Hide();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            string passwordcheck = textBox2.Text;
        }

       public void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
            string passwordcheck = textBox2.Text;
            string recheckpassword = textBox3.Text;
            if (recheckpassword.Equals(passwordcheck))
            {
                button1.Enabled = true;
            }
           

        }
    }
}
