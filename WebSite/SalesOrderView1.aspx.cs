using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace WebSite
{
    public partial class SalesOrderView1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        string SO_Id2, UId;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            Int64 PO_Id = Convert.ToInt64(Request.QueryString["SO_ID"]);
            SO_Id2 = PO_Id.ToString();


            if (Request.QueryString["SO_ID"] != null)
            {
                if (!IsPostBack)
                {
                    BindDateID();
                    BindSupInfo();
                    BindPOTable();
                    BindGTotal();
                }
            }
            else
            {
                Response.Redirect("~/SalesOrderView.aspx");
            }
        }


    }
}
}