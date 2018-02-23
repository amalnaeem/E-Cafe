using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace WebApplication3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

                String my_querry1 = "select ID from Orders where OrderType = 'Delivery'";
                OleDbCommand cmd1 = new OleDbCommand(my_querry1, conn);

                var dr1 = cmd1.ExecuteReader();

                // MessageBox.Show("Query executed");
                while (dr1.Read())
                {
                    CheckBoxList1.Items.Add(dr1[0].ToString());
                    //MessageBox.Show(dr1[1].ToString());
                }

            }
        }

                protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}