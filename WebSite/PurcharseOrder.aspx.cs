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
    public partial class PurcharseOrder : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        string PO_Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (!IsPostBack)
            {
                BindSupplier();
                BindRMaterial();
            }
            DateTime today = DateTime.Today;
            PO_Date.TodaysDate = today;
            PO_Date.SelectedDate = PO_Date.TodaysDate;

        }

        private void BindSupplier()
        {

            cmd = new SqlCommand("Select * from tblSupplier", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                PO_SupName.DataSource = dt;
                PO_SupName.DataTextField = "SupName";
                PO_SupName.DataValueField = "SupID";
                PO_SupName.DataBind();
                PO_SupName.Items.Insert(0, new ListItem("-Select-", "0"));

            }
        }

        private void BindRMaterial()
        {

            cmd = new SqlCommand("Select * from tblRMaterial", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                PO_ItemName.DataSource = dt;
                PO_ItemName.DataTextField = "RM_Name";
                PO_ItemName.DataValueField = "RM_ID";
                PO_ItemName.DataBind();
                PO_ItemName.Items.Insert(0, new ListItem("-Select-", "0"));

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Insert into tblPurchaseOrder(PO_Date, SupID) Values('" + PO_Date.SelectedDate + "','" + PO_SupName.SelectedIndex + "')", con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e1){Response.Write(e1);}

            try
            {
                cmd1 = new SqlCommand("SELECT TOP 1 PO_ID FROM tblPurchaseOrder ORDER BY PO_ID DESC", con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    PO_Id = dr.GetValue(0).ToString();
                    dr.Close();
                }
            }
            catch (Exception exp) { Response.Write(exp); }

            try
            {
                cmd = new SqlCommand("Insert into tblPOItems(RM_ID, POItem_Price, POItem_Quantity, PO_ID) Values('" + PO_ItemName.SelectedIndex + "','" + PO_Quantity.Text + "','" + PO_Amount.Text + "','" + PO_Id + "')", con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e1) { Response.Write(e1); }

            Response.Write("<script> alert('Purchase Order Added Successfully ');  </script>");

            con.Close();
            PO_SupName.SelectedIndex = 0;
            PO_ItemName.SelectedIndex = 0;
            PO_Quantity.Text = "";
            PO_Amount.Text = "";
        }
    }
}