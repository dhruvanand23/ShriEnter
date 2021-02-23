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
    public partial class SalesOrder : System.Web.UI.Page
    {
        string SearchName, SO_ProDuctID;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlCommand cmd3 = new SqlCommand();
        string SO_Id, SO_Id2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (!IsPostBack)
            {
                BindCustomer();
                BindProduct();
            }

            DateTime today = DateTime.Today;
            SO_Date.TodaysDate = today;
            SO_Date.SelectedDate = SO_Date.TodaysDate;
        }

        protected void SO_ItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            AmountFetch();

        }

        private void AmountFetch()
        {
            cmd = new SqlCommand("Select PSelPrice from tblProducts where PID=@uname", con);
            cmd.Parameters.AddWithValue("@uname", SO_ProductName.SelectedItem.Value);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                SO_Amount.Text = dr.GetValue(0).ToString();
                dr.Close();
            }
        }

        private void BindCustomer()
        {
            cmd = new SqlCommand("Select * from tblUsers where Usertype='User'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                SO_CustomerName.DataSource = dt;
                SO_CustomerName.DataTextField = "Name";
                SO_CustomerName.DataValueField = "Uid";
                SO_CustomerName.DataBind();
                SO_CustomerName.Items.Insert(0, new ListItem("-Select-", "0"));
                dt.Dispose();

            }
        }

        private void BindProduct()
        {
            cmd = new SqlCommand("Select * from tblProducts", con);            
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                SO_ProductName.DataSource = dt;
                SO_ProductName.DataTextField = "PName";
                SO_ProductName.DataValueField = "PID";
                SO_ProductName.DataBind();
                SO_ProductName.Items.Insert(0, new ListItem("-Select-", "0"));
                dt.Dispose();
            }
        }

        protected void AddSales_CheckedChanged(Object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                SO_Date.Enabled = true;
                SO_CustomerName.Enabled = true;
                SO_ProductName.Enabled = true;
                SO_Quantity.Enabled = true;
                SO_Amount.Enabled = true;
               
            }
            else if (RadioButton2.Checked == true)
            {
                SO_Date.Enabled = false;
                SO_CustomerName.Enabled = false;
                SO_ProductName.Enabled = true;
                SO_Quantity.Enabled = true;
                SO_Amount.Enabled = true;
            }
        }

    }
}