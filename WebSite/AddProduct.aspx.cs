﻿using System;
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
        string SearchName;
        string Pid1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (!IsPostBack)
            {                
                BindCategory();               
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
            cmd.Parameters.AddWithValue("@PSelPrice", txtsellPrice.Text); 
            cmd.Parameters.AddWithValue("@PCategoryID", ddlCategory.SelectedItem.Value);                        
            cmd.Parameters.AddWithValue("@PDescription", txtDescription.Text);
            cmd.Parameters.AddWithValue("@PProductDetails", txtPDetail.Text); 

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
            Response.Write("<script> alert('Product Added Successfully');  </script>");
            txtDescription.Text = " ";
            txtPDetail.Text = " ";            
            txtProductName.Text = " ";
            txtsellPrice.Text = " ";
            ddlCategory.SelectedIndex = 0;            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchName = Search.Text;
            cmd = new SqlCommand("Select * from tblProducts where PName=@uname", con);
            cmd.Parameters.AddWithValue("@uname", SearchName);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                txtProductName.Text = dr.GetValue(1).ToString();
                txtsellPrice.Text = dr.GetValue(2).ToString();
                ddlCategory.Text = dr.GetValue(3).ToString();
                txtDescription.Text = dr.GetValue(4).ToString();
                txtPDetail.Text = dr.GetValue(5).ToString();                
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SearchName = Search.Text;

            cmd = new SqlCommand("UPDATE tblProducts SET PName = '" + txtProductName.Text + "', PSelPrice = '" + txtsellPrice.Text + "', PCategoryID = '" + ddlCategory.SelectedItem.Value + "',PDescription = '" + txtDescription.Text + "',PProductDetails = '" + txtPDetail.Text + "' WHERE PName=@uname;", con);
            cmd.Parameters.AddWithValue("@uname", SearchName);
            cmd.ExecuteNonQuery();

            Response.Write("<script> alert('Product Updated Successfully ');  </script>");
            
            con.Close();
            txtProductName.Text = "";
            txtsellPrice.Text = "";
            txtPDetail.Text = "";
            txtDescription.Text = "";
            ddlCategory.SelectedIndex = 0;            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SearchName = Search.Text;

            cmd = new SqlCommand("select PID from tblProducts where PName = '" + Search.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Pid1 = dr.GetValue(0).ToString();
                dr.Close();
            }

            cmd = new SqlCommand("DELETE FROM tblProductImages WHERE PID='" + Pid1 + "'", con);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("DELETE FROM tblProducts WHERE PName=@uname", con);
            cmd.Parameters.AddWithValue("@uname", SearchName);
            cmd.ExecuteNonQuery();

            Response.Write("<script> alert('Product Deleted Successfully ');  </script>");            

            con.Close();
            txtProductName.Text = "";
            txtsellPrice.Text = "";
            txtPDetail.Text = "";
            txtDescription.Text = "";
            ddlCategory.SelectedIndex = 0;
            txtProductName.Focus();
        }

    }
}
