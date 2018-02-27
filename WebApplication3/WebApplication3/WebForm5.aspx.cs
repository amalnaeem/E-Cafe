using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication3
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                this.BindListView();
                this.Bind_Today_Order();
                this.Bind_Today_Yesterday();
                this.total_orders();

                Label1.Visible = false;
                TextBox1.Visible = false;
                Button4.Visible = false;
                Label2.Visible = false;
                Label3.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                TextBox2.Visible = false;
                TextBox3.Visible = false;
                TextBox4.Visible = false;
                TextBox5.Visible = false;
                Button5.Visible = false;

                TextBox6.Attributes.Add("readonly", "readonly");


            }
        }

        private void Bind_Today_Order()
        {
            var dateAndTime = DateTime.Now;
            var current_date = dateAndTime.Date;


            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

            conn.Open();
            using (OleDbCommand cmd = new OleDbCommand())
            {
                //cmd.CommandText = "SELECT CustomerNumber, OrderType, Status, TotalBill FROM Orders where OrderDate";
                string query = "SELECT CustomerNumber, OrderType, Status, TotalBill FROM Orders  ";
                query += "WHERE OrderDate = @date;";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@date", current_date);
                cmd.Connection = conn;
                using (OleDbDataAdapter sda = new OleDbDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    //lvCustomers.DataSource = dt;
                    T_Order.DataSource = dt;
                    T_Order.DataBind();
                }
            }
            conn.Close();

        }

        private void Bind_Today_Yesterday()
        {
            var dateAndTime = DateTime.Now;
            var current_date = dateAndTime.Date;
            var yesterday = current_date.AddDays(-1);
            //ListBox1.Items.Add(yesterday.ToString());

            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

            conn.Open();
            using (OleDbCommand cmd = new OleDbCommand())
            {
                //cmd.CommandText = "SELECT CustomerNumber, OrderType, Status, TotalBill FROM Orders where OrderDate";
                string query = "SELECT CustomerNumber, OrderType, Status, TotalBill FROM Orders  ";
                query += "WHERE OrderDate = @date;";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@date", yesterday);
                cmd.Connection = conn;
                using (OleDbDataAdapter sda = new OleDbDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    Y_Order.DataSource = dt;
                    Y_Order.DataBind();
                }
            }
            conn.Close();

        }

        private void total_orders()
        {
            var count = 0;
            var dateAndTime = DateTime.Now;
            var current_date = dateAndTime.Date;
            var month = current_date.Month;
            //TextBox6.Text = month.ToString();
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

            conn.Open();
            String my_querry1 = "select OrderDate from Orders";
            OleDbCommand cmd = new OleDbCommand(my_querry1, conn);
            var da = cmd.ExecuteReader();
            while (da.Read())
            {
                //DateTime x = da[0];
                if (da.GetDateTime(0).Month == month)
                {
                    count++;
                }
            }
            TextBox6.Text = count.ToString();
        }

        private void BindListView()
        {

            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

            conn.Open();
            using (OleDbCommand cmd = new OleDbCommand())
            {
                cmd.CommandText = "SELECT ID, Item, Price FROM Items";
                cmd.Connection = conn;
                using (OleDbDataAdapter sda = new OleDbDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    lvCustomers.DataSource = dt;
                    lvCustomers.DataBind();
                }
            }
            conn.Close();

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            Button5.Visible = true;
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            TextBox1.Visible = true;
            Button4.Visible = true;
        }


        protected void Button5_Click1(object sender, EventArgs e)
        {
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

            conn.Open();
            String sql = "insert into Items ([Item], [Price], [Type], [Category]) values ('" + TextBox3.Text.ToString() + "','" + TextBox2.Text.ToString() + "' ,'" + TextBox5.Text.ToString() + "' ,'" + TextBox4.Text.ToString() + "')";
            System.Data.OleDb.OleDbCommand cmd1 = new System.Data.OleDb.OleDbCommand(sql, conn);

            var dr1 = cmd1.ExecuteNonQuery();
            //MessageBox.Show(dr1.ToString());
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            Button5.Visible = false;


            MessageBox.Show("Successfully Added.");
            BindListView();

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

            conn.Open();
            string query = "DELETE FROM Items ";
            query += "WHERE ID = @id;";
            OleDbCommand cmd1 = new OleDbCommand(query, conn);
            cmd1.Parameters.AddWithValue("@id", Convert.ToInt16(TextBox1.Text));

            cmd1.ExecuteNonQuery();

            Label1.Visible = false;
            TextBox1.Visible = false;
            Button4.Visible = false;

            conn.Close();
            MessageBox.Show("Successfully Deleted.");
            BindListView();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm1.aspx");
        }
    }
    }