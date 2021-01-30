using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebSite
{
    public partial class signin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)

        {
            if(!IsPostBack)
            {
                if(Request.Cookies["UNAME"]!=null && Request.Cookies["UPWD"] != null)
                {
                    txtUname.Text= Request.Cookies["UNAME"].Value;
                    txtPass.Text= Request.Cookies["UPWD"].Value;
                    CheckBox1.Checked = true;
                }
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "Select * from [tblUsers] where Email=@uname and Password= @pass";
                cmd.Parameters.AddWithValue("@uname", txtUname.Text);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                cmd.Connection = con;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                sda.Fill(ds);
                if (ds.Rows.Count != 0)
                {
                    if (CheckBox1.Checked)
                    {
                        Response.Cookies["UNAME"].Value = txtUname.Text;
                        Response.Cookies["UPWD"].Value = txtPass.Text;

                        Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(10);
                        Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(10);
                    }
                    else
                    {
                        Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);
                    }
                    string Utype;
                    Utype = ds.Rows[0][6].ToString();

                    if (Utype == "User")
                    {
                        Session["Username"] = txtUname.Text;
                        Response.Redirect("~/UserHome.aspx");
                    }

                    if (Utype == "Admin")
                    {
                        Session["Username"] = txtUname.Text;
                        Response.Redirect("~/AdminHome.aspx");
                    }
                }
                else
                {
                    lblError.Text = "Invalid UserName And Password";
                    Response.Write("\n\n\nInvalid Credentials");
                }

            }
            catch (Exception e1)
            {
                Response.Write(e1);
            }
        }
    }
}