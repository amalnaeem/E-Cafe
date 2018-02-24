using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WebApplication3
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Register.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string password = TextBox2.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\Dell\Documents\Ecafe.accdb";
            conn.Open();

            String my_querry1 = "Select* From Users where Username = '" + username + "'and Password = '" + password + "'";
            System.Data.OleDb.OleDbCommand cmd1 = new System.Data.OleDb.OleDbCommand(my_querry1 , conn);

            var dr1 = cmd1.ExecuteReader();

            if (dr1.Read())
            {
                string[] i = (string[])Session["items"];
                string[] q = (string[])Session["quants"];
                string[] p = (string[])Session["prices"];

                int total = 0;
                for (int j = 0; j < p.Length; ++j)
                {
                    Int32 tpr = Convert.ToInt32(p[j]);
                    total += tpr;
                }

                   
                //MessageBox.Show(dr1[0].ToString());
                String uid = dr1[0].ToString();
                String up= dr1[7].ToString();
                String ua = dr1[6].ToString();
                var dateAndTime = DateTime.Now;
                var current_date = dateAndTime.Date;

                String my_quer2 = "select OrderID from Orders";
                System.Data.OleDb.OleDbCommand cmd2 = new System.Data.OleDb.OleDbCommand(my_quer2 , conn);
                var dr2 = cmd2.ExecuteReader();
                var oid = "a"; //order id
                while (dr2.Read())
                {
                    oid = dr2[0].ToString();
                }

                Int32 ooid = Convert.ToInt32(oid);
                ooid += 1;
                MessageBox.Show(ooid.ToString());

                for (int j = 0; j < i.Length; ++j)
                {
                    
                    String my_quer = "select ID from Items where Item = '" + i[j] + "'";
                    OleDbCommand cmd3 = new OleDbCommand(@"select ID from Items where Item = @x1 ", conn);
                    cmd3.Parameters.AddWithValue("@x1", i[j]);
                    var dr3 = cmd3.ExecuteReader();
                    var iid = "a"; //item id
                    while (dr3.Read())
                    {
                        iid = dr3[0].ToString();
                    }  
                    
                    String sql = "insert into Orders ([OrderID],[UserID],[OrderType],[DTime],[Status],[ItemID],[OrderDate],[TotalBill],[Address],[CustomerNumber],[Quantity]) values ('"+ooid+"','" + uid + "','Delivery','18/5/15','Incomplete','"+iid+"','"+current_date+"','"+total+"','"+ua+"','"+up+"','"+ q[j] + "')";
                    System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql, conn);
                    var dr4 = cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Your Order Has been Placed");

            }
            else
            {
                MessageBox.Show("Please Check Your Username and Password.");
                Server.Transfer("Login.aspx");
            }
        }
    }
}