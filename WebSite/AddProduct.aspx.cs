using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebSite
{
    public partial class AddProduct : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-U4214QS\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
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
                BindBrand();
                BindCategory();
                ddlSubCategory.Enabled = false;
            }
        }

        private void BindBrand()
        {
                cmd = new SqlCommand("Select * from tblBrands", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlBrand.DataSource = dt;
                ddlBrand.DataTextField = "Name";
                ddlBrand.DataValueField = "BrandID";
                ddlBrand.DataBind();
                ddlBrand.Items.Insert(0, new ListItem("-Select-", "0"));

            }
        }

        private void BindCategory()
        {
             cmd = new SqlCommand("Select * from tblCategory", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlCategory.DataSource = dt;
                    ddlCategory.DataTextField = "CatName";
                    ddlCategory.DataValueField = "CatID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));

                }
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_InsertProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PName", txtProductName.Text);
            cmd.Parameters.AddWithValue("@PPrice", txtPrice.Text);
            cmd.Parameters.AddWithValue("@PSelPrice", txtsellPrice.Text);
            cmd.Parameters.AddWithValue("@PQuantity", txtquantity.Text);
            cmd.Parameters.AddWithValue("@PBrandID", ddlBrand.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@PCategoryID", ddlCategory.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@PSubCatID", ddlSubCategory.SelectedItem.Value);            
            cmd.Parameters.AddWithValue("@PDescription", txtDescription.Text);
            cmd.Parameters.AddWithValue("@PProductDetails", txtPDetail.Text);
            cmd.Parameters.AddWithValue("@PMaterialCare", txtMatCare.Text);
            if (chFD.Checked == true)
            {
                cmd.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@FreeDelivery", 0.ToString());
            }

            if (ch30Ret.Checked == true)
            {
                cmd.Parameters.AddWithValue("@30DayRet", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@30DayRet", 0.ToString());
            }
            if (cbCOD.Checked == true)
            {
                cmd.Parameters.AddWithValue("@COD", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@COD", 0.ToString());
            }

            Int64 PID = Convert.ToInt64(cmd.ExecuteScalar());

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSubCategory.Enabled = true;
            int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            
            SqlCommand cmd = new SqlCommand("Select * from tblSubCategory where MainCatID='" + ddlCategory.SelectedItem.Value + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                ddlSubCategory.DataSource = dt;
                ddlSubCategory.DataTextField = "SubCatName";
                ddlSubCategory.DataValueField = "SubCatID";
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, new ListItem("-Select-", "0"));
            }
        }
    }
}
