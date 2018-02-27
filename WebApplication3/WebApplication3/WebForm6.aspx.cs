using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sname = TextBox1.Text;
            string spass = TextBox2.Text;

            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

            conn.Open();

            String my_querry1 = "select  ID from Users where  Username = '" + sname + "'and Password = '" + spass + "' and Type = 'Admin'";
            //'" + LastName + "','"+Paswrd + "'
            OleDbCommand cmd1 = new OleDbCommand(my_querry1, conn);

            var dr1 = cmd1.ExecuteReader();

            // MessageBox.Show("Query executed");
            if (dr1.Read() != false)
            {
                Server.Transfer("WebForm5.aspx");

            }

        }
    }
}