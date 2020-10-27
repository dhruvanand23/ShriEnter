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
    public partial class AddSubCategory : System.Web.UI.Page
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
                BindMainCat();
                BindSubCatRptr(); 
            }
        }
        private void BindSubCatRptr()
        {
            cmd = new SqlCommand("select A.*,B.* from mydata1.dbo.tblSubCategory A inner join mydata1.dbo.tblCategory B on B.CatID = A.MainCatID", con);
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrSubCat.DataSource = dt;
                    rptrSubCat.DataBind();
                }
            } 
        }

        protected void btnAddSubCategory_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into mydata1.dbo.tblSubCategory(SubCatName,MainCatID) values('" + txtSubCategory.Text + "','" + ddlMainCatID.SelectedItem.Value + "')";
                cmd.ExecuteReader();
                cmd.Dispose();
                Response.Write("SubCategory Added Sucessfully");
                txtSubCategory.Text = "";

            }
            catch (Exception e1)
            {
                Response.Write(e1);
            }
            ddlMainCatID.ClearSelection();
            ddlMainCatID.Items.FindByValue("0").Selected = true;            
            
        }

        private void BindMainCat()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from tblCategory", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlMainCatID.DataSource = dt;
                    ddlMainCatID.DataTextField = "CatName";
                    ddlMainCatID.DataValueField = "CatID";
                    ddlMainCatID.DataBind();
                    ddlMainCatID.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
            catch (Exception e1)
            {
                Response.Write(e1);
            }

        }
    }
}