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
    public partial class signup : System.Web.UI.Page
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
        }

        protected void txtsignup_Click(object sender, EventArgs e)
        {
            

            try
            {
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into user_Details(u_name,u_pass,u_add,u_mob,u_mail,u_type) values('" + txtUname.Text + "','" + txtPass.Text + "','" + txtadd.Text + "','" + txtmob.Text + "','" + txtEmail.Text + "','User')";
                cmd.ExecuteReader();
                cmd.Dispose();

                txtUname.Text = "";
                txtPass.Text = "";
                txtadd.Text = "";
                txtCPass.Text = "";
                txtEmail.Text = "";
                txtmob.Text = "";

            }
            catch (Exception e1)
            {
                Response.Write(e1);
            }
        }
    }
}