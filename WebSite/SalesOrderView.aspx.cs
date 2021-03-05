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
using System.Drawing;

namespace WebSite
{
    public partial class SalesOrderView : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        string SO_Id3;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (!IsPostBack)
            {
                BindSalesOrder();
            }
        }

        private void BindSalesOrder()
        {
            using (SqlCommand cmd = new SqlCommand("select tblSalesOrder.*, tblUsers.Name from tblSalesOrder, tblUsers where tblSalesOrder.Uid = tblUsers.Uid Order by SO_ID", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrSOView.DataSource = dt;
                    rptrSOView.DataBind();
                    dt.Dispose();
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string SO_Id2 = ((Button)sender).CommandArgument.ToString();


            cmd = new SqlCommand("DELETE FROM tblSOProduct WHERE SO_ID='" + SO_Id2 + "'", con);
            cmd.ExecuteNonQuery();


            cmd1 = new SqlCommand("DELETE FROM tblSalesOrder WHERE SO_ID='" + SO_Id2 + "'", con);
            cmd1.ExecuteNonQuery();

            Response.Write("<script> alert('Sales Order Deleted Successfully ');  </script>");
            BindSalesOrder();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            Response.Redirect("SalesOrder.aspx");
        }

        protected void btnUpdate1_Click(object sender, EventArgs e)
        {
            string SO_Id2 = ((Button)sender).CommandArgument.ToString();
            try
            {
                cmd1 = new SqlCommand("SELECT SO_Status FROM tblSalesOrder where SO_ID='" + SO_Id2 + "'", con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    SO_Id3 = dr.GetValue(0).ToString();
                    dr.Close();
                }
            }
            catch (Exception e1) { Response.Write(e1); }

            if (SO_Id3 == "Dead")
            {
                cmd = new SqlCommand("UPDATE tblSalesOrder SET SO_Status = 'Live' where SO_ID='" + SO_Id2 + "'", con);
                cmd.ExecuteNonQuery();
            }
            else if (SO_Id3 == "Live")
            {
                cmd = new SqlCommand("UPDATE tblSalesOrder SET SO_Status = 'Dead' where SO_ID='" + SO_Id2 + "'", con);
                cmd.ExecuteNonQuery();
            }

            Response.Write("<script> alert('Sales Order Status Updated Successfully ');  </script>");
            BindSalesOrder();

        }


    }
}