using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected override void OnLoad(EventArgs e)
        {
           
            base.OnLoad(e);

            if (!IsPostBack)
            {

                System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source= C:\Users\Dell\Documents\Ecafe.accdb";

                conn.Open();

                String my_querry1 = "select DISTINCT Type from Items where Category = 'Starter'";
                String my_querry2 = "select DISTINCT Type from Items where Category = 'Main'";
                String my_querry3 = "select DISTINCT Type from Items where Category = 'Deserts'";
                String my_querry4 = "select DISTINCT Type from Items where Category = 'Salad'";
                String my_querry5 = "select DISTINCT Type from Items where Category = 'Drinks'";
                OleDbCommand cmd1 = new OleDbCommand(my_querry1, conn);
                OleDbCommand cmd2 = new OleDbCommand(my_querry2, conn);
                OleDbCommand cmd3 = new OleDbCommand(my_querry3, conn);
                OleDbCommand cmd4 = new OleDbCommand(my_querry4, conn);
                OleDbCommand cmd5 = new OleDbCommand(my_querry5, conn);

                //OleDbCommand cmd2 = new OleDbCommand(my_querry2, conn);
                //OleDbCommand cmd3 = new OleDbCommand(my_querry3, conn);
                //OleDbDataReader dr = cmd.ExecuteReader();
                var dr1 = cmd1.ExecuteReader();

                // MessageBox.Show("Query executed");
                while (dr1.Read())
                {
                    ListBox1.Items.Add(dr1[0].ToString());
                    //MessageBox.Show(dr1[1].ToString());
                }

                dr1 = cmd2.ExecuteReader();

                // MessageBox.Show("Query executed");
                while (dr1.Read())
                {
                    ListBox2.Items.Add(dr1[0].ToString());
                    //MessageBox.Show(dr1[1].ToString());
                }

                dr1 = cmd3.ExecuteReader();

                // MessageBox.Show("Query executed");
                while (dr1.Read())
                {
                    ListBox3.Items.Add(dr1[0].ToString());
                    //MessageBox.Show(dr1[1].ToString());
                }

                dr1 = cmd4.ExecuteReader();

                // MessageBox.Show("Query executed");
                while (dr1.Read())
                {
                    ListBox4.Items.Add(dr1[0].ToString());
                    //MessageBox.Show(dr1[1].ToString());
                }

                dr1 = cmd5.ExecuteReader();

                // MessageBox.Show("Query executed");
                while (dr1.Read())
                {
                    ListBox5.Items.Add(dr1[0].ToString());
                    //MessageBox.Show(dr1[1].ToString());
                }
             
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListBox6.Visible = true;
        }
        protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductName", System.Type.GetType("System.String"));
            dt.Columns.Add("CategoryName", System.Type.GetType("System.String"));
            dt.Columns.Add("SupplierName", System.Type.GetType("System.String"));
            ListBox1.ClearSelection();
            ListBox2.ClearSelection();
            ListBox4.ClearSelection();
            ListBox5.ClearSelection();
            ListBox6.Items.Clear();
           // ListBox7.Items.Clear();
            String selection = ListBox3.SelectedItem.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\Dell\Documents\Ecafe.accdb";

            conn.Open();

            String my_querry1 = "select Item from Items where Type = '" + selection + "'";
            OleDbCommand cmd1 = new OleDbCommand(my_querry1, conn);

            var dr1 = cmd1.ExecuteReader();

            // MessageBox.Show("Query executed");
            while (dr1.Read())
            {
                ListBox6.Items.Add(dr1[0].ToString());
                //MessageBox.Show(dr1[1].ToString());
            }
            Label2.Text = selection;
            ListBox6.Visible = true;
            ListBox7.Visible = true;
            ListBox8.Visible = true;
            ListBox9.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;
            TextBox2.Visible = true;
            Button1.Visible = true;
            Button2.Visible = true;
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox3.ClearSelection();
            ListBox2.ClearSelection();
            ListBox4.ClearSelection();
            ListBox5.ClearSelection();
            ListBox6.Items.Clear();
           // ListBox7.Items.Clear();
            String selection = ListBox1.SelectedItem.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\Dell\Documents\Ecafe.accdb";

            conn.Open();

            String my_querry1 = "select Item from Items where Type = '"+selection+"'";
            OleDbCommand cmd1 = new OleDbCommand(my_querry1, conn);
          
            var dr1 = cmd1.ExecuteReader();

            // MessageBox.Show("Query executed");
            while (dr1.Read())
            {
                ListBox6.Items.Add(dr1[0].ToString());
                //MessageBox.Show(dr1[1].ToString());
            }

            Label2.Text = selection;
            ListBox6.Visible = true;
            ListBox7.Visible = true;
            ListBox8.Visible = true;
            ListBox9.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;
            TextBox2.Visible = true;
            Button1.Visible = true;
            Button2.Visible = true;
        }
       
        protected void ListBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ListBox7.Items.Clear();
            //ListBox7.Visible = true;
            String selection = ListBox6.SelectedItem.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\Dell\Documents\Ecafe.accdb";

            conn.Open();

            String my_querry1 = "select Price from Items where Item = '" + selection + "'";
            OleDbCommand cmd1 = new OleDbCommand(@"select Price from Items where Item = @x1 ", conn);
            cmd1.Parameters.AddWithValue("@x1", selection);

            var dr1 = cmd1.ExecuteReader();

            //MessageBox.Show("Query executed");
            while (dr1.Read())
            {
                //MessageBox.Show(dr1[0].ToString());
                //ListBox7.Items.Add(dr1[0].ToString());
                Label3.Text = dr1[0].ToString();
            }
            var o = 1;
            TextBox2.Text = o.ToString();

        }
       
        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1.ClearSelection();
            ListBox3.ClearSelection();
            ListBox4.ClearSelection();
            ListBox5.ClearSelection();
            ListBox6.Items.Clear();
           // ListBox7.Items.Clear();
            String selection = ListBox2.SelectedItem.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\Dell\Documents\Ecafe.accdb";

            conn.Open();

            String my_querry1 = "select Item from Items where Type = '" + selection + "'";
            OleDbCommand cmd1 = new OleDbCommand(my_querry1, conn);

            var dr1 = cmd1.ExecuteReader();

            // MessageBox.Show("Query executed");
            while (dr1.Read())
            {
                ListBox6.Items.Add(dr1[0].ToString());
                //MessageBox.Show(dr1[1].ToString());
            }
            Label2.Text = selection;
            ListBox6.Visible = true;
            ListBox7.Visible = true;
            ListBox8.Visible = true;
            ListBox9.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;
            TextBox2.Visible = true;
            Button1.Visible = true;
            Button2.Visible = true;
        }

        protected void ListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1.ClearSelection();
            ListBox2.ClearSelection();
            ListBox3.ClearSelection();
            ListBox5.ClearSelection();
            ListBox6.Items.Clear();
            
            String selection = ListBox4.SelectedItem.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\Dell\Documents\Ecafe.accdb";

            conn.Open();

            String my_querry1 = "select Item from Items where Type = '" + selection + "'";
            OleDbCommand cmd1 = new OleDbCommand(my_querry1, conn);

            var dr1 = cmd1.ExecuteReader();

            // MessageBox.Show("Query executed");
            while (dr1.Read())
            {
                ListBox6.Items.Add(dr1[0].ToString());
                //MessageBox.Show(dr1[1].ToString());
            }
            Label2.Text = selection;

            ListBox6.Visible = true;
            ListBox7.Visible = true;
            ListBox8.Visible = true;
            ListBox9.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;
            TextBox2.Visible = true;
            Button1.Visible = true;
            Button2.Visible = true;
        }

        protected void ListBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1.ClearSelection();
            ListBox2.ClearSelection();
            ListBox4.ClearSelection();
            ListBox3.ClearSelection();
            ListBox6.Items.Clear();
           // ListBox7.Items.Clear();
            String selection = ListBox5.SelectedItem.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\Dell\Documents\Ecafe.accdb";

            conn.Open();

            String my_querry1 = "select Item from Items where Type = '" + selection + "'";
            OleDbCommand cmd1 = new OleDbCommand(my_querry1, conn);

            var dr1 = cmd1.ExecuteReader();

            // MessageBox.Show("Query executed");
            while (dr1.Read())
            {
                ListBox6.Items.Add(dr1[0].ToString());
                //MessageBox.Show(dr1[1].ToString());
            }
            Label2.Text = selection;
            ListBox6.Visible = true;
            ListBox7.Visible = true;
            ListBox8.Visible = true;
            ListBox9.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;
            TextBox2.Visible = true;
            Button1.Visible = true;
            Button2.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
        static int x = 0;
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Int32 p = Convert.ToInt32(ListBox7.Text) * Convert.ToInt32(txt_price.Text);

            String selection = ListBox6.SelectedItem.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\Dell\Documents\Ecafe.accdb";

            conn.Open();

            String my_querry1 = "select Price from Items where Item = '" + selection + "'";
            OleDbCommand cmd1 = new OleDbCommand(@"select Price from Items where Item = @x1 ", conn);
            cmd1.Parameters.AddWithValue("@x1", selection);

            var dr1 = cmd1.ExecuteReader();
            var p = "a";
           // MessageBox.Show(dr1.GetString(0));
            while (dr1.Read())
            {
               // MessageBox.Show(dr1[0].ToString());
                p = dr1[0].ToString();
                //ListBox7.Items.Add(dr1[0].ToString());

            }
            
            var ip= Convert.ToInt32(p);
            var q = 1;
            q=Convert.ToInt32(TextBox2.Text); 
                        
            var qpr = ip * q;
            x += qpr;
            ListBox7.Items.Add(ListBox6.SelectedItem.Text);
            ListBox8.Items.Add(TextBox2.Text);
            ListBox9.Items.Add(qpr.ToString());

            Label1.Text = x.ToString();
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            int r = ListBox7.SelectedIndex;
            ListBox7.Items.RemoveAt(r);
            ListBox8.Items.RemoveAt(r);
            int p = Convert.ToInt32(ListBox9.Items[r].Text);
            ListBox9.Items.RemoveAt(r);
            x -= p;
            Label1.Text = x.ToString();
            ListBox6.ClearSelection();
        }

        protected void ListBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string[] item = new string[ListBox7.Items.Count];
            string[] quant = new string[ListBox8.Items.Count];
            string[] price = new string[ListBox9.Items.Count];
            // place all your values into that string array.
           
            for (int i = 0; i < ListBox7.Items.Count; ++i)
            {
                item[i] = ListBox7.Items[i].Value;

            }
            Session["items"] = item;

            for (int i = 0; i < ListBox8.Items.Count; ++i)
            {
                quant[i] = ListBox8.Items[i].Value;
            }
            Session["quants"] = quant;

            for (int i = 0; i < ListBox9.Items.Count; ++i)
            {
                price[i] = ListBox9.Items[i].Value;
            }
            Session["prices"] = price;

            Response.Redirect("Login.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string[] item = new string[ListBox7.Items.Count ];
            string[] quant = new string[ListBox8.Items.Count];
            string[] price = new string[ListBox9.Items.Count];
            // place all your values into that string array.
            //Server.Transfer("Login.aspx");
            for (int i = 0; i < ListBox7.Items.Count; ++i)
            {
                    item[i] = ListBox7.Items[i].Value;
               
            }
            Session["items"] = item;

            for (int i = 0; i < ListBox8.Items.Count; ++i)
            {
                quant[i] = ListBox8.Items[i].Value;
            }
            Session["quants"] = quant;

            for (int i = 0; i < ListBox9.Items.Count; ++i)
            {
                price[i] = ListBox9.Items[i].Value;
            }
            Session["prices"] = price;
            Response.Redirect("Login.aspx");
        }
    }
}