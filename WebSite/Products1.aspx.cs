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
    public partial class Products1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        String Filter_Value;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductRepeater();
                BindCategory();

            }
        }

        protected void OnSelectIndexChanged(object sender, EventArgs e)
        {
            Filter_Value = ddlCategory.SelectedItem.Text;
            if(String.Equals(Filter_Value, "All"))
            {
                BindProductRepeater();
            }
            else
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("select A.*,B.*  ,B.Name as ImageName from tblProducts A cross apply(select top 1 * from tblProductImages B where B.PID = A.PID order by B.PID desc)B where PCategoryID = '"+ddlCategory.SelectedItem.Value + "' order by A.PID desc", con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            rptrProducts.DataSource = dt;
                            rptrProducts.DataBind();
                            dt.Dispose();
                        }
                    }
                }
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
                ddlCategory.Items.Insert(0, new ListItem("All", "0"));
            }

        }

        private void BindProductRepeater()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("procBindAllProducts1", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrProducts.DataSource = dt;
                        rptrProducts.DataBind();
                        dt.Dispose();
                    }
                }
            }
        }
    }
}