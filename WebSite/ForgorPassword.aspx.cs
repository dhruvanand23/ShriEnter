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
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-U4214QS\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
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
                    String myGUID = Guid.NewGuid().ToString();
                    int Uid = Convert.ToInt32(dt.Rows[0][0]);

                    SqlCommand cmd1 = new SqlCommand("Insert into ForgotPass(Id,Uid,RequestDateTime) values('" + myGUID + "','" + Uid + "',GETDATE())", con);
                    cmd1.ExecuteNonQuery();

                    //sender resent link

                    String ToEmailAddress = dt.Rows[0][5].ToString();
                    String Username = dt.Rows[0][2].ToString();
                    String EmailBody = "Hi ,"+ Username + ",<br/><br/>Click the link below To Reset Your Password<br/><br/>http://localhost:56255/RecovePassword.aspx?Uid"+myGUID;
                    MailMessage PassRecMail = new MailMessage("your email",ToEmailAddress );
                    PassRecMail.Body = EmailBody;
                    PassRecMail.IsBodyHtml = true;
                    PassRecMail.Subject = "ResetPass Password";

                    SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 587);
                    SMTP.Credentials = new NetworkCredential();
                    {
                        UserName ="YourEmail@Gmail.com,
                        Password ="YourPassword"
                    };
                    SMTP.EnableSsl = true;
                    SMTP.Send(PassRecMail);

                    //------

                    lblResetPassMsg.Text = "Reset Link send | Please check Your Email";
                    lblResetPassMsg.ForeColor=System.Drawing.Color.Green;
                    txtEmailID.Text = string.Empty;
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