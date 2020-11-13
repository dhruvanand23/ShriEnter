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
    public partial class AddProduct : System.Web.UI.Page
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
            SqlCommand cmd = new SqlCommand("sp_InsertProduct3", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PName", txtProductName.Text);
            cmd.Parameters.AddWithValue("@PPrice", txtPrice.Text);
            cmd.Parameters.AddWithValue("@PSelPrice", txtsellPrice.Text);            
            cmd.Parameters.AddWithValue("@PBrandID", ddlBrand.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@PCategoryID", ddlCategory.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@PSubCatID", ddlSubCategory.SelectedItem.Value);            
            cmd.Parameters.AddWithValue("@PDescription", txtDescription.Text);
            cmd.Parameters.AddWithValue("@PProductDetails", txtPDetail.Text);            
            if (chFD.Checked == true)
            {
                cmd.Parameters.AddWithValue("@FreeDelivery", "1");
            }
            else
            {
                cmd.Parameters.AddWithValue("@FreeDelivery", "0");
            }

            if (ch30Ret.Checked == true)
            {
                cmd.Parameters.AddWithValue("@30DayRet", "1");
            }
            else
            {
                cmd.Parameters.AddWithValue("@30DayRet", "0");
            }
            if (cbCOD.Checked == true)
            {
                cmd.Parameters.AddWithValue("@COD", "1");
            }
            else
            {
                cmd.Parameters.AddWithValue("@COD", "0");
            }

            Int64 PID = Convert.ToInt64(cmd.ExecuteScalar());

            //Insert and upload images
            if (fuImg01.HasFile)
            {
                string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);

                }
                string Extention = Path.GetExtension(fuImg01.PostedFile.FileName);
                fuImg01.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "01" + Extention);

                SqlCommand cmd3 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString().Trim() + "01" + "','" + Extention + "')", con);
                cmd3.ExecuteNonQuery();
            }
            //2nd fileupload
            if (fuImg02.HasFile)
            {
                string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);

                }
                string Extention = Path.GetExtension(fuImg02.PostedFile.FileName);
                fuImg02.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "02" + Extention);

                SqlCommand cmd4 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString().Trim() + "02" + "','" + Extention + "')", con);
                cmd4.ExecuteNonQuery();
            }

            //3rd file upload 
            if (fuImg03.HasFile)
            {
                string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);

                }
                string Extention = Path.GetExtension(fuImg03.PostedFile.FileName);
                fuImg03.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "03" + Extention);

                SqlCommand cmd5 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString().Trim() + "03" + "','" + Extention + "')", con);
                cmd5.ExecuteNonQuery();
            }
            //4th file upload control
            if (fuImg04.HasFile)
            {
                string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);

                }
                string Extention = Path.GetExtension(fuImg04.PostedFile.FileName);
                fuImg04.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "04" + Extention);

                SqlCommand cmd6 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString().Trim() + "04" + "','" + Extention + "')", con);
                cmd6.ExecuteNonQuery();
            }

            //5th file upload
            if (fuImg05.HasFile)
            {
                string SavePath = Server.MapPath("~/Images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);

                }
                string Extention = Path.GetExtension(fuImg05.PostedFile.FileName);
                fuImg05.SaveAs(SavePath + "\\" + txtProductName.Text.ToString().Trim() + "05" + Extention);

                SqlCommand cmd7 = new SqlCommand("insert into tblProductImages values('" + PID + "','" + txtProductName.Text.ToString().Trim() + "05" + "','" + Extention + "')", con);
                cmd7.ExecuteNonQuery();
            }


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
