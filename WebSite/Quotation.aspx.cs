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
    public partial class Quotation : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            
            //Getting userId using email id
            string username = (string)Session["Username"];
            try
            {
                cmd = new SqlCommand("Select Uid from [tblUsers] where Email=@uname", con);
                cmd.Parameters.AddWithValue("@uname", username);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string userID = dr.GetValue(0).ToString();
                    dr.Close();
                }
            }
            catch (Exception exp) { Response.Write(exp); }

        }

        protected void Submit_Details_Click(object sender, EventArgs e)
        {
            string value = "";
            bool isChecked = RadioButton1.Checked;
            if (isChecked)
                value = RadioButton1.Text;
            else
                value = RadioButton2.Text;
            
            Label1.Text = value;

        }
    }
}