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
    public partial class SalesOrderView1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        string SO_Id2, UId;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            Int64 SO_Id = Convert.ToInt64(Request.QueryString["SO_ID"]);
            SO_Id2 = SO_Id.ToString();


            if (Request.QueryString["SO_ID"] != null)
            {
                if (!IsPostBack)
                {
                    BindDateID();
                    BindCustomerInfo();
                    BindSOTable();
                    BindGTotal();
                }
            }
            else
            {
                Response.Redirect("~/SalesOrderView.aspx");
            }
        }

        private void BindDateID()
        {
            cmd = new SqlCommand("select * from tblSalesOrder where SO_ID='" + SO_Id2 + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblSOId.Text = dr.GetValue(0).ToString();
                lblDate.Text = dr.GetValue(1).ToString();
                UId = dr.GetValue(2).ToString();
                dr.Close();
            }
        }

        private void BindCustomerInfo()
        {
            cmd = new SqlCommand("select * from tblUsers where Uid='" + UId + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblCustName.Text = dr.GetValue(5).ToString();
                lblAddress.Text = dr.GetValue(2).ToString();
                lblPhNo.Text = dr.GetValue(4).ToString();
                lblEmail.Text = dr.GetValue(3).ToString();                
                dr.Close();
            }
        }

        private void BindSOTable()
        {
            using (cmd = new SqlCommand("select tblSOProduct.*, tblProducts.*, CAST(tblSOProduct.SOItem_Price as money)*CAST(tblSOProduct.SOItem_Quantity as money) Total from tblSOProduct, tblProducts where tblSOProduct.PID = tblProducts.PID and tblSOProduct.SO_ID='" + SO_Id2 + "'", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrSODetails.DataSource = dt;
                    rptrSODetails.DataBind();
                    dt.Dispose();
                }
            }
        }

        private void BindGTotal()
        {
            cmd = new SqlCommand("select Sum(CAST(SOItem_Price as int)*CAST(SOItem_Quantity as int)) from tblSOProduct where SO_ID='" + SO_Id2 + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblGTotal.Text = dr.GetValue(0).ToString();
                dr.Close();
            }
        }

    }
}