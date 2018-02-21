using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Windows.Forms;

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
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListBox6.Visible = true;
        }
        protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("hi0");
            ListBox6.Visible = true;
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox6.Visible = true;
        }

        protected void ListBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox6.Visible = true;
        }

        protected void ListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox6.Visible = true;
        }

        protected void ListBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox6.Visible = true;
        }
    }
}