using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication3
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "" && TextBox6.Text != "")
            {
                string fname = TextBox1.Text;
                string lname = TextBox2.Text;
                string uname = TextBox5.Text;
                string pass = TextBox6.Text;
                string ph = TextBox3.Text;
                string addr = TextBox4.Text;
                System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source= C:\Users\OK\Documents\Ecafe.accdb";
                conn.Open();

                String sql = "insert into Users ([Firstname], [Lastname], [Username], [Password],[Type],[Address],[PhoneNo]) values ('" + fname + "','" + lname + "','" + uname + "','" + pass + "','Customer','"+addr+"','"+ Convert.ToInt64(ph) + "')";
                System.Data.OleDb.OleDbCommand cmd1 = new System.Data.OleDb.OleDbCommand(sql, conn);

                var dr1 = cmd1.ExecuteNonQuery();

                MessageBox.Show("Successfully Registered.");

                Server.Transfer("Login.aspx");

            }
            else
            {
                MessageBox.Show("Fill in the form properly");
            }
        }

        
    }
}