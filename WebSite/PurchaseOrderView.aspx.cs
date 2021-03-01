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

namespace WebSite
{
    public partial class PurchaseOrderView : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (!IsPostBack)
            {
                BindPurchaseOrder();
            }
        }

        private void BindPurchaseOrder()
        {
            using (SqlCommand cmd = new SqlCommand("select tblPurchaseOrder.*, tblSupplier.SupName from tblPurchaseOrder, tblSupplier where tblPurchaseOrder.SupID = tblSupplier.SupID Order by PO_ID", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrPOView.DataSource = dt;
                    rptrPOView.DataBind();
                    dt.Dispose();
                }
            }
        }

        

    }
}