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
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-U4214QS\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
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
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                cmd.CommandText = "Select * from [user_Details] where u_mail=@uname and u_pass = @pass";
                cmd.Parameters.AddWithValue("@uname", txtUname.Text);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text);
                cmd.Connection = con;
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    if(CheckBox1.Checked)
                    {
                        Response.Cookies["UNAME"].Value = txtUname.Text;
                        Response.Cookies["UPWD"].Value = txtPass.Text;

                        Response.Cookies["UNAME"].Expires= DateTime.Now.AddDays(10);
                        Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(10);
                    }
                    else
                    {
                        Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Session["Username"] = txtUname.Text;
                    Response.Redirect("UserHome.aspx");
                }
                else
                {
                    lblError.Text = "Invalid UserName And Password";
                    Response.Write("Invalid Credentials");
                }

            }
            catch (Exception e1)
            {
                Response.Write(e1);
            }
        }
    }
}