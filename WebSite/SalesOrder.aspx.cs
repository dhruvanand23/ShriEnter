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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                try
                {
                    cmd = new SqlCommand("Insert into tblSalesOrder(SO_Date, Uid) Values('" + SO_Date.SelectedDate + "','" + SO_CustomerName.SelectedItem.Value + "')", con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1) { Response.Write(e1); }

                try
                {
                    cmd1 = new SqlCommand("SELECT TOP 1 SO_ID FROM tblSalesOrder ORDER BY SO_ID DESC", con);
                    SqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read())
                    {
                        SO_Id = dr.GetValue(0).ToString();
                        dr.Close();
                    }
                }
                catch (Exception exp) { Response.Write(exp); }

                try
                {
                    cmd2 = new SqlCommand("Insert into tblSOProduct(SOPro_ID, SOItem_Price, SOItem_Quantity, SO_ID) Values('" + SO_ProductName.SelectedItem.Value + "','" + SO_Amount.Text + "','" + SO_Quantity.Text + "','" + SO_Id + "')", con);
                    cmd2.ExecuteNonQuery();
                }
                catch (Exception e1) { Response.Write(e1); }

                Response.Write("<script> alert('Purchase Order Added Successfully ');  </script>");
                //BindPurchaseOrder();

                con.Close();
                SO_ProductName.SelectedIndex = 0;
                SO_Quantity.Text = "";
                SO_Amount.Text = "";
            }
            else if (RadioButton2.Checked == true)
            {

                try
                {
                    cmd1 = new SqlCommand("SELECT TOP 1 SO_ID FROM tblPurchaseOrder ORDER BY PO_ID DESC", con);
                    SqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read())
                    {
                        SO_Id = dr.GetValue(0).ToString();
                        dr.Close();
                    }
                }
                catch (Exception e1) { Response.Write(e1); }

                try
                {
                    cmd2 = new SqlCommand("Insert into tblPOItems(SOPro_ID, SOItem_Price, SOItem_Quantity, SO_ID) Values('" + SO_ProductName.SelectedItem.Value + "','" + SO_Amount.Text + "','" + SO_Quantity.Text + "','" + SO_Id + "')", con);
                    cmd2.ExecuteNonQuery();
                }
                catch (Exception e1) { Response.Write(e1); }

                Response.Write("<script> alert('Item Added Successfully ');  </script>");
                //BindPurchaseOrder();

                con.Close();
                SO_ProductName.SelectedIndex = 0;
                SO_Quantity.Text = "";
                SO_Amount.Text = "";
            }


        }

    }
}