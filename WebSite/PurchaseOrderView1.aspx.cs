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
            

            if (Request.QueryString["PO_ID"] != null)
            {
                if (!IsPostBack)
                {
                    BindDateID();
                    BindSupInfo();
                    BindPOTable();
                    BindGTotal();
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

        private void BindPOTable()
        {
            using (cmd = new SqlCommand("select tblPOItems.*, tblRMaterial.*, CAST(tblPOItems.POItem_Price as int)*CAST(tblPOItems.POItem_Quantity as int) Total from tblPOItems, tblRMaterial where tblPOItems.RM_ID = tblRMaterial.RM_ID and tblPOItems.PO_ID='" + PO_Id2 + "'", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrPODetails.DataSource = dt;
                    rptrPODetails.DataBind();
                    dt.Dispose();
                }
            }
        }

        private void BindGTotal()
        {
            cmd = new SqlCommand("select Sum(CAST(POItem_Price as int)*CAST(POItem_Quantity as int)) from tblPOItems where PO_ID='" + PO_Id2 + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblGTotal.Text = dr.GetValue(0).ToString();
                dr.Close();
            }
        }
    }
}