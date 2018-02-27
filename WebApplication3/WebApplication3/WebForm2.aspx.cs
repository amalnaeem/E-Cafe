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

                String my_querry1 = "select DISTINCT OrderID from Orders where  Status = 'Incomplete'";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<ListItem> toBeRemoved = new List<ListItem>();
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    toBeRemoved.Add(item);
                    System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
                    conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data source= C:\Users\OK\Documents\Ecafe.accdb";

                    conn.Open();
                    string st = item.Text;
                    
                   // Int32 id = Int32.Parse(item.Text);
                    String my_querry1 = "UPDATE Orders SET Status = 'Complete' where OrderID = "+Convert.ToInt32(st)+"";
                    OleDbCommand cmd1 = new OleDbCommand(my_querry1, conn);
                    cmd1.ExecuteNonQuery();
                }
            }
            for (int i = 0; i < toBeRemoved.Count; i++)
            {
                CheckBoxList1.Items.Remove(toBeRemoved[i]);
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm1.aspx");
        }
    }
}