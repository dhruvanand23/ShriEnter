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
    public partial class PurchaseOrderView1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        string PO_Id2, SupId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            Int64 PO_Id = Convert.ToInt64(Request.QueryString["PO_ID"]);
            PO_Id2 = PO_Id.ToString();
            Label1.Text = PO_Id2;

            if (Request.QueryString["PO_ID"] != null)
            {
                if (!IsPostBack)
                {
                    BindDateID();
                    BindSupInfo();
                }
            }
            else
            {
                Response.Redirect("~/PurchaseOrderView.aspx");
            }
        }

        

        private void BindDateID()
        {
            cmd = new SqlCommand("select * from tblPurchaseOrder where PO_ID='" + PO_Id2 + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblPOId.Text = dr.GetValue(0).ToString();
                lblDate.Text = dr.GetValue(1).ToString();
                SupId = dr.GetValue(2).ToString();
                dr.Close();
            }
        }

        private void BindSupInfo()
        {
            cmd = new SqlCommand("select * from tblSupplier where SupID='" + SupId + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblSupName.Text = dr.GetValue(1).ToString();
                lblAddress.Text = dr.GetValue(3).ToString();
                lblPhNo.Text = dr.GetValue(2).ToString();
                lblEmail.Text = dr.GetValue(4).ToString();
                lblGST.Text = dr.GetValue(5).ToString();
                dr.Close();
            }
        }

    }
}