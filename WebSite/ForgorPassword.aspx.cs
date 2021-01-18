using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace WebSite
{
    public partial class ForgorPassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

        }

        
        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            try
            {
                 SqlCommand cmd = new SqlCommand("Select * from user_Details where u_mail=@Email", con);
                 cmd.Parameters.AddWithValue("@Email", txtEmailID.Text);
                 SqlDataAdapter sda = new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 sda.Fill(dt);
                 if (dt.Rows.Count != 0)
                 {
                    SqlCommand SqlComm = new SqlCommand("UPDATE user_Details SET u_pass = '"+ txtPassFP.Text + "' WHERE u_mail = '"+ txtEmailID.Text + "'", con);
                    SqlComm.ExecuteReader();
                    Response.Write("Successful");
                    lblResetPassMsg.Text = "Password Changed";
                    lblResetPassMsg.ForeColor = System.Drawing.Color.Green;
                    txtEmailID.Text = string.Empty;
                    txtConPassFP.Text = string.Empty;
                    txtPassFP.Text = string.Empty;

                }
                else
                {
                    lblResetPassMsg.Text = "Oops ! This Email Does not Exist...Try Again";
                    lblResetPassMsg.ForeColor = System.Drawing.Color.Red;
                    txtEmailID.Text = string.Empty;
                    txtEmailID.Focus();
                }
            }
            catch (Exception e1)
            {
                Response.Write(e1);
            }
        }
     }
    
}