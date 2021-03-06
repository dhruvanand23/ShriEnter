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
        string PO_Id3;
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("PurcharseOrder.aspx");
        }

        protected void btnUpdate1_Click(object sender, EventArgs e)
        {
            string PO_Id2 = ((Button)sender).CommandArgument.ToString();           
            try
            {
                cmd1 = new SqlCommand("SELECT PO_Status FROM tblPurchaseOrder where PO_ID='" + PO_Id2 + "'", con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    PO_Id3 = dr.GetValue(0).ToString();
                    dr.Close();
                }
            }
            catch (Exception e1) { Response.Write(e1); }

            if(PO_Id3 == "Dead")
            {
                cmd = new SqlCommand("UPDATE tblPurchaseOrder SET PO_Status = 'Live' where PO_ID='" + PO_Id2 + "'", con);
                cmd.ExecuteNonQuery();
            }
            else if (PO_Id3 == "Live")
            {
                cmd = new SqlCommand("UPDATE tblPurchaseOrder SET PO_Status = 'Dead' where PO_ID='" + PO_Id2 + "'", con);
                cmd.ExecuteNonQuery();
            }

            Response.Write("<script> alert('Purchase Order Status Updated Successfully ');  </script>");
            BindPurchaseOrder();

        }

        protected void FilterSelect_CheckedChanged(Object sender, EventArgs e)
        {
            if(btnAll.Checked==true)
            {
                BindPurchaseOrder();
            }
            else if(btnLive.Checked==true)
            {
                using (SqlCommand cmd = new SqlCommand("select tblPurchaseOrder.*, tblSupplier.SupName from tblPurchaseOrder, tblSupplier where tblPurchaseOrder.SupID = tblSupplier.SupID and PO_Status='Live' Order by PO_ID ", con))
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
            else if(btnDead.Checked==true)
            {
                using (SqlCommand cmd = new SqlCommand("select tblPurchaseOrder.*, tblSupplier.SupName from tblPurchaseOrder, tblSupplier where tblPurchaseOrder.SupID = tblSupplier.SupID and PO_Status='Dead' Order by PO_ID ", con))
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
}