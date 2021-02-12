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
    public partial class QuotationDispaly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindQuotationHomeRepeater();
            BindQuotationComRepeater();
        }

        private void BindQuotationHomeRepeater()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("select tblQuotationHome.*, tblUsers.mobile, tblUsers.Name from tblQuotationHome, tblUsers, tblQuotationType where  tblQuotationHome.QID = tblQuotationType.QID and tblQuotationType.Uid = tblUsers.Uid", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrQuoteHome.DataSource = dt;
                        rptrQuoteHome.DataBind();
                    }
                }
            }
        }

        private void BindQuotationComRepeater()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("select tblQuotationCom.*, tblUsers.mobile, tblUsers.Name from tblQuotationCom, tblUsers, tblQuotationType where  tblQuotationCom.QID = tblQuotationType.QID and tblQuotationType.Uid = tblUsers.Uid", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrCommQuote.DataSource = dt;
                        rptrCommQuote.DataBind();
                    }
                }
            }
        }
    }
}