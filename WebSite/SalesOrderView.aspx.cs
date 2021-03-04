using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Drawing;

namespace WebSite
{
    public partial class SalesOrderView : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        string SO_Id3;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (!IsPostBack)
            {
                BindSalesOrder();
            }
        }

        private void BindSalesOrder()
        {
            using (SqlCommand cmd = new SqlCommand("select tblSalesOrder.*, tblUsers.Name from tblSalesOrder, tblUsers where tblSalesOrder.Uid = tblUsers.Uid Order by SO_ID", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrSOView.DataSource = dt;
                    rptrSOView.DataBind();
                    dt.Dispose();
                }
            }
        }

    }
}