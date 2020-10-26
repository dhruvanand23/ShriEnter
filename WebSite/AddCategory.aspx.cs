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
    public partial class AddCategory : System.Web.UI.Page
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
            BindCategoryRepeater();
        }

        private void BindCategoryRepeater()
        {
            cmd = new SqlCommand("select * from mydata1.dbo.tblCategory", con);
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
            protected void btnAddCategory_Click(object Sender, EventArgs e)
        {
            try
            {
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into tblCategory(CatName) values('" + txtCategory.Text + "')";
                cmd.ExecuteReader();
                cmd.Dispose();
                Response.Write("Category Added Sucessfully");
                txtCategory.Text = "";

            }
            catch (Exception e1)
            {
                Response.Write(e1);
            }
            txtCategory.Focus();

        }
    }
}