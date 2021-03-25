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
    public partial class InventoryManagement : System.Web.UI.Page
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
                BindSupplier();
                BindRMaterial();
            }
        }

        private void BindSupplier()
        {
            cmd = new SqlCommand("Select * from tblSupplier", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlSupplier.DataSource = dt;
                ddlSupplier.DataTextField = "SupName";
                ddlSupplier.DataValueField = "SupID";
                ddlSupplier.DataBind();
                ddlSupplier.Items.Insert(0, new ListItem("-Select-", "0"));
                dt.Dispose();

            }
        }

        private void BindRMaterial()
        {
            cmd = new SqlCommand("Select * from tblRMaterial where SupID=@uname ", con);
            cmd.Parameters.AddWithValue("@uname", ddlSupplier.SelectedItem.Value);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlRawMaterial.DataSource = dt;
                ddlRawMaterial.DataTextField = "RM_Name";
                ddlRawMaterial.DataValueField = "RM_ID";
                ddlRawMaterial.DataBind();
                ddlRawMaterial.Items.Insert(0, new ListItem("-Select-", "0"));
                dt.Dispose();

            }
        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRMaterial();
        }

        protected void ddlRawMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetchQty();
        }

        protected void btnEditQty_Click(object sender, EventArgs e)
        {
            using ( con )
            {
                
                SqlCommand cmd = new SqlCommand("Insert into tblItemInventory(RM_ID, IQty, IDate) Values('" + ddlRawMaterial.SelectedItem.Value+ "','"+ quantity.Text + "','"+ date.Text + "')", con);
                cmd.ExecuteNonQuery();

                Response.Write("<script> alert('Inventory Updated Successfully ');  </script>");

                fetchQty();
                con.Close();


                quantity.Text = "";
                date.Text = "";
            }
        }

        private void fetchQty()
        {
            
            cmd = new SqlCommand("Select sum(IQty) from [tblItemInventory] where RM_ID = @uname", con);
            cmd.Parameters.AddWithValue("@uname", ddlRawMaterial.SelectedItem.Value);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                qtyDisplay.Text = dr.GetValue(0).ToString();
            }
        }
    }
}