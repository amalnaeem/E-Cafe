using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;

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
        @"Data source= C:\Users\OK\Documents\Ecafe.accdb";
            conn.Open();

            String my_querry1 = "Select* From Users where Username = '" + username + "'and Password = '" + password + "'";
            System.Data.OleDb.OleDbCommand cmd1 = new System.Data.OleDb.OleDbCommand(my_querry1 , conn);

            var dr1 = cmd1.ExecuteReader();

            if (dr1.Read())
            {
                string[] i = (string[])Session["items"];
                string[] q = (string[])Session["quants"];
                string[] p = (string[])Session["prices"];
                string ptime = (string)Session["picktime"];

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

                //cmd = new OleDbCommand("SELECT @@IDENTITY", con);
                //id = cmd.ExecuteNonQuery();
               String my_quer2 = "select * from Orders";
                String mq = "SELECT COUNT(*) FROM Orders";
                System.Data.OleDb.OleDbCommand cmd2 = new System.Data.OleDb.OleDbCommand(my_quer2 , conn);
                System.Data.OleDb.OleDbCommand cmd6 = new System.Data.OleDb.OleDbCommand(mq, conn);
                var dr2 = cmd2.ExecuteReader();
                int f = (int)cmd6.ExecuteScalar();
                var oid = "a"; //order id
                Int32 y = 0;
                var g = 1;
                //MessageBox.Show(f.ToString());
                if (dr2.Read() == false) { oid = "0"; }
                while (dr2.Read())
                {
                    y = Convert.ToInt32(dr2[11]);
                    MessageBox.Show(y.ToString());
                    g++;
                    //if((g-1)==f)
                    //break;
                }
               // MessageBox.Show(f.ToString());
               
                Int32 ooid = y + 1;
                //Int32 ooid = Convert.ToInt32(oid);
                //ooid += 1;
               // MessageBox.Show(oid.ToString());
                //MessageBox.Show(ooid.ToString());
                
                DateTime currentTime = DateTime.Now;
                DateTime x30MinsLater = currentTime.AddMinutes(30);
               // string pt = ptime.ToString("hh:mm tt");

                String dt =x30MinsLater.ToString("hh:mm tt");
               // DateTime dtime = Convert.ToDateTime(x30MinsLater);
                DateTime dtime = DateTime.Parse(dt, System.Globalization.CultureInfo.CurrentCulture);
                
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
                   // MessageBox.Show(ptime);
                    if (string.IsNullOrWhiteSpace(ptime))
                    {
                       // MessageBox.Show("hello");
                        String sql = "insert into Orders ([OrderID],[UserID],[OrderType],[Status],[ItemID],[OrderDate],[TotalBill],[Address],[CustomerNumber],[Quantity],[DTime]) values ('" + ooid + "','" + uid + "','Delivery','Incomplete','" + iid + "','" + current_date + "','" + total + "','" + ua + "','" + up + "','" + q[j] + "','" + dtime + "')";
                        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql, conn);
                        var dr4 = cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Order Has been Placed and it will be delivered around " + dtime.ToString("hh:mm tt"));

                    }
                    else
                    {
                        DateTime pitime = DateTime.Parse(ptime, System.Globalization.CultureInfo.CurrentCulture);
                        DateTime PTime = DateTime.ParseExact(ptime, "HH:mm", CultureInfo.InvariantCulture);
                        //MessageBox.Show(ptime);
                        String sql = "insert into Orders ([OrderID],[UserID],[OrderType],[Status],[ItemID],[OrderDate],[TotalBill],[Address],[CustomerNumber],[Quantity],[PTime]) values ('" + ooid + "','" + uid + "','Pickup','Incomplete','" + iid + "','" + current_date + "','" + total + "','" + ua + "','" + up + "','" + q[j] + "','" + PTime + "')";
                        System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(sql, conn);
                        var dr4 = cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Order Has been Placed. Please pick it up around " + PTime.ToString("HH:mm "));

                    }
                    Server.Transfer("WebForm1.aspx");
                }


// MessageBox.Show("Your Order Has been Placed and it will be delivered around "+ dtime.ToString("hh:mm tt"));

            }
            else
            {
                MessageBox.Show("Please Check Your Username and Password.");
                Server.Transfer("Login.aspx");
            }
        }
    }
}