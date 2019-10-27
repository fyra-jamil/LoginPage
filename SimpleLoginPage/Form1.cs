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
    public partial class Form1 : Form
    {
       SqlConnection login = new SqlConnection();
        public Form1()
        {
            SqlConnection login = new SqlConnection();
            login.ConnectionString = "Data Source =SYSCODE-SGT01;Initial Catalog=dummydummydb;Integrated Security=True";
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection login = new SqlConnection();
            //connect to the database
            login.ConnectionString = "Data Source =SYSCODE-SGT01;Initial Catalog=dummydummydb;Integrated Security=True";
            login.Open();
            
            //command to the SQL
            SqlCommand ins = new SqlCommand("SELECT UserID,PasswordUser from Ayam WHERE UserID = @UserID and PasswordUser=@PasswordUser", login);

            //set up on what to check
            SqlParameter UserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            SqlParameter PasswordUser = new SqlParameter("@PasswordUser", SqlDbType.VarChar);

            //link to the textbox
            UserID.Value = textBox1.Text;
            PasswordUser.Value = textBox2.Text;

            ins.Parameters.Add(UserID);
            ins.Parameters.Add(PasswordUser);

            SqlDataReader myReader = ins.ExecuteReader(CommandBehavior.CloseConnection);
            //if success
            if (myReader.Read()==true)
            {
                MessageBox.Show("Login sucess Welcome to Homepage http://dafierralicious.blogspot.com");
                System.Diagnostics.Process.Start("http://dafierralicious.blogspot.com");
                
            }
            //if fail
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
            this.Hide();
        }
    }
}
