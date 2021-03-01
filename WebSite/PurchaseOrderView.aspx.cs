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
    public partial class PurchaseOrderView : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();

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
                BindStatus();
            }


        }

        private void BindStatus()
        {
            cmd = new SqlCommand("select PO_Status from tblPurchaseOrder", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string Po_status = dr.GetValue(0).ToString();
                
                if(Po_status == "live")
                {
                    Button btnStatus = (Button)FindControl("btnStatus");

                    btnStatus.Text = "Dead";
                }
                else if(Po_status == "dead")
                {
                    Button btnStatus = (Button)FindControl("btnStatus");
                    btnStatus.Text = "Live";
                }

                dr.Close();
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string PO_Id2 = ((Button)sender).CommandArgument.ToString();

            cmd = new SqlCommand("DELETE FROM tblPOItems WHERE PO_ID='" + PO_Id2 + "'", con);
            cmd.ExecuteNonQuery();

            cmd1 = new SqlCommand("DELETE FROM tblPurchaseOrder WHERE PO_ID='" + PO_Id2 + "'", con);
            cmd1.ExecuteNonQuery();

            Response.Write("<script> alert('Purchase Order Deleted Successfully ');  </script>");
            BindPurchaseOrder();
        }


    }
}