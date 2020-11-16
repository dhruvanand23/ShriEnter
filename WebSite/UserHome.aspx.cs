using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class UserHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCartNumber();
            if (Session["Username"]!=null)
            {
                btnlogout.Visible = true;
                btnLogin.Visible = false;
                lblsuccess.Text = "Login Success,Welcome" + Session["Username"].ToString();
            }
            else
            {
                btnlogout.Visible = false;
                btnLogin.Visible = true;
                //Response.Redirect("signin.aspx");
            } 

        }
        protected void btnlogout_Click(object sender,EventArgs e)
        {
            //Response.Redirect("~/signin.aspx");
            Session["Username"] = null;
            Response.Redirect("~/first.aspx");
        }

        public void BindCartNumber()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] ProductArray = CookiePID.Split(',');
                int ProductCount = ProductArray.Length;
                pCount.InnerText = ProductCount.ToString();
            }
            else
            {
                pCount.InnerText = 0.ToString();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/signin.aspx");
        }
    }
}