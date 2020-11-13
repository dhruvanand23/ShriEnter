﻿using System;
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

    public partial class AddCategory1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCategoryReapter();

        }

        private void BindCategoryReapter()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("select * from tblCategory", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrCategory.DataSource = dt;
                        rptrCategory.DataBind();
                    }
                }
            }
        }

        protected void btnAddtxtCategory_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into tblCategory(CatName) Values('" + txtCategory.Text + "')", con);
                cmd.ExecuteNonQuery();

                Response.Write("<script> alert('Category Added Successfully ');  </script>");
                txtCategory.Text = string.Empty;

                con.Close();
                //lblMsg.Text = "Registration Successfully done";
                //lblMsg.ForeColor = System.Drawing.Color.Green;
                txtCategory.Focus();


            }
        }
    }
}