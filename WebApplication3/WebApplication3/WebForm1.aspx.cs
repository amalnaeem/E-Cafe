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

        DataTable dt = new DataTable();

        private void gridVIEWData()
        {
            dt.Columns.Add("Item", typeof(string));
            dt.Columns.Add("Quantity", typeof(Int32));
            dt.Columns.Add("Price", typeof(Int32));
            
            
        }

        protected override void OnLoad(EventArgs e)
        {
           
            base.OnLoad(e);

            if (!IsPostBack)
            {

                System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

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
                gridVIEWData();
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Session["dt"] = dt;
           
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
            ListBox7.Items.Clear();
            String selection = ListBox3.SelectedItem.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

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

            ListBox6.Visible = true;
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox3.ClearSelection();
            ListBox2.ClearSelection();
            ListBox4.ClearSelection();
            ListBox5.ClearSelection();
            ListBox6.Items.Clear();
            ListBox7.Items.Clear();
            String selection = ListBox1.SelectedItem.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

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

            ListBox6.Visible = true;
        }
       
        protected void ListBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox7.Items.Clear();
            ListBox7.Visible = true;
            String selection = ListBox6.SelectedItem.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

            conn.Open();

            String my_querry1 = "select Price from Items where Item = '" + selection + "'";
            OleDbCommand cmd1 = new OleDbCommand(@"select Price from Items where Item = @x1 ", conn);
            cmd1.Parameters.AddWithValue("@x1", selection);

            var dr1 = cmd1.ExecuteReader();

            //MessageBox.Show("Query executed");
            while (dr1.Read())
            {
                //MessageBox.Show(dr1[0].ToString());
                ListBox7.Items.Add(dr1[0].ToString());

            }



        }
       
        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1.ClearSelection();
            ListBox3.ClearSelection();
            ListBox4.ClearSelection();
            ListBox5.ClearSelection();
            ListBox6.Items.Clear();
            ListBox7.Items.Clear();
            String selection = ListBox2.SelectedItem.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

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

            ListBox6.Visible = true;
        }

        protected void ListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1.ClearSelection();
            ListBox2.ClearSelection();
            ListBox3.ClearSelection();
            ListBox5.ClearSelection();
            ListBox6.Items.Clear();
            ListBox7.Items.Clear();
            String selection = ListBox4.SelectedItem.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

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

            ListBox6.Visible = true;
        }

        protected void ListBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox1.ClearSelection();
            ListBox2.ClearSelection();
            ListBox4.ClearSelection();
            ListBox3.ClearSelection();
            ListBox6.Items.Clear();
            ListBox7.Items.Clear();
            String selection = ListBox5.SelectedItem.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

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

            ListBox6.Visible = true;
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Set the hand mouse cursor for the selected row.
                e.Row.Attributes.Add("OnMouseOver", "this.style.cursor = 'hand';");

                // The seelctButton exists for ensuring the selection functionality
                // and bind it with the appropriate event hanlder.
                LinkButton selectButton = new LinkButton()
                {
                    CommandName = "Select",
                    Text = e.Row.Cells[0].Text
                };
                selectButton.Font.Underline = false;
                selectButton.ForeColor = Color.Black;

                e.Row.Cells[0].Controls.Add(selectButton);
                //e.Row.Attributes["OnClick"] =
                //     Page.ClientScript.GetPostBackClientHyperlink(selectButton, "");
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["dt"] != null) dt = (DataTable)Session["dt"];
            //Int32 p = Convert.ToInt32(ListBox7.Text) * Convert.ToInt32(txt_price.Text);

            String selection = ListBox6.SelectedItem.Text;
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
        @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

            conn.Open();

            String my_querry1 = "select Price from Items where Item = '" + selection + "'";
            OleDbCommand cmd1 = new OleDbCommand(@"select Price from Items where Item = @x1 ", conn);
            cmd1.Parameters.AddWithValue("@x1", selection);

            var dr1 = cmd1.ExecuteReader();
            var p = "a";
           // MessageBox.Show(dr1.GetString(0));
            while (dr1.Read())
            {
                MessageBox.Show(dr1[0].ToString());
                p = dr1[0].ToString();
                //ListBox7.Items.Add(dr1[0].ToString());

            }

            DataRow dr = dt.NewRow();
           
            dr["Item"] = ListBox6.SelectedItem.Text;
            dr["Price"] = p;
            dr["Quantity"] = TextBox2.Text;
            
            dt.Rows.Add(dr);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}