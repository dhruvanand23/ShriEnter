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
            TextBox1.Enabled = false;
            btnSearch.Enabled = false;
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

        private void BindSalesOrder1()
        {
            SearchName = TextBox1.Text;

            try
            {
                cmd2 = new SqlCommand("select tblSalesOrder.*, tblUsers.Name from tblSalesOrder, tblUsers where tblSalesOrder.Uid = tblSalesOrder.Uid and tblSalesOrder.SO_ID='" + SearchName + "'", con);
                SqlDataReader dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    lblSOId.Text = dr.GetValue(0).ToString();
                    lblDate.Text = dr.GetValue(1).ToString();
                    lblCustomerName.Text = dr.GetValue(3).ToString();
                    dr.Close();
                }
            }
            catch (Exception e1) { Response.Write(e1); }

            using (SqlCommand cmd = new SqlCommand("select tblSOProduct.*, tblProducts.PName from tblSOProduct, tblProducts where tblSOProduct.PID = tblProducts.PID and tblSOProduct.SO_ID='" + SearchName + "'", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt9 = new DataTable();
                    sda.Fill(dt9);
                    rptrSO.DataSource = dt9;
                    rptrSO.DataBind();
                    dt9.Dispose();
                }
            }
        }

        private void BindSalesOrder()
        {
            try
            {
                cmd1 = new SqlCommand("SELECT TOP 1 SO_ID FROM tblSOProduct ORDER BY SOPro_ID DESC", con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    SO_Id2 = dr.GetValue(0).ToString();
                    dr.Close();
                }
            }
            catch (Exception e1) { Response.Write(e1); }

            try
            {
                cmd2 = new SqlCommand("select tblSalesOrder.*, tblUsers.Name from tblUsers, tblSalesOrder where tblSalesOrder.Uid = tblUsers.Uid and tblSalesOrder.SO_ID='" + SO_Id2 + "'", con);
                SqlDataReader dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    lblSOId.Text = dr.GetValue(0).ToString();
                    lblDate.Text = dr.GetValue(1).ToString();
                    lblCustomerName.Text = dr.GetValue(3).ToString();
                    dr.Close();
                }
            }
            catch (Exception e1) { Response.Write(e1); }

            using (SqlCommand cmd = new SqlCommand("select tblSOProduct.*, tblProducts.PName from tblSOProduct, tblProducts where tblSOProduct.PID = tblProducts.PID and tblSOProduct.SO_ID='" + SO_Id2 + "'", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrSO.DataSource = dt;
                    rptrSO.DataBind();
                    dt.Dispose();
                }
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
                    cmd2 = new SqlCommand("Insert into tblSOProduct(PID, SOItem_Price, SOItem_Quantity, SO_ID) Values('" + SO_ProductName.SelectedItem.Value + "','" + SO_Amount.Text + "','" + SO_Quantity.Text + "','" + SO_Id + "')", con);
                    cmd2.ExecuteNonQuery();
                }
                catch (Exception e1) { Response.Write(e1); }

                Response.Write("<script> alert('Sales Order Added Successfully ');  </script>");
                BindSalesOrder();

                con.Close();
                SO_ProductName.SelectedIndex = 0;
                SO_Quantity.Text = "";
                SO_Amount.Text = "";
            }
            else if (RadioButton2.Checked == true)
            {

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
                catch (Exception e1) { Response.Write(e1); }

                try
                {
                    cmd2 = new SqlCommand("Insert into tblSOProduct(PID, SOItem_Price, SOItem_Quantity, SO_ID) Values('" + SO_ProductName.SelectedItem.Value + "','" + SO_Amount.Text + "','" + SO_Quantity.Text + "','" + SO_Id + "')", con);
                    cmd2.ExecuteNonQuery();
                }
                catch (Exception e1) { Response.Write(e1); }

                Response.Write("<script> alert('Item Added Successfully ');  </script>");
                BindSalesOrder();

                con.Close();
                SO_ProductName.SelectedIndex = 0;
                SO_Quantity.Text = "";
                SO_Amount.Text = "";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            RadioButton1.Enabled = false;
            RadioButton2.Enabled = false;
            btnAdd.Enabled = false;

            SearchName = TextBox1.Text;

            BindSalesOrder1();

            cmd = new SqlCommand("select *  from tblSalesOrder  where SO_ID=@uname", con);
            cmd.Parameters.AddWithValue("@uname", SearchName);
            SqlDataReader dr3 = cmd.ExecuteReader();
            if (dr3.Read())
            {
                string dateString = dr3.GetValue(1).ToString();
                DateTime date = Convert.ToDateTime(dateString);
                SO_Date.TodaysDate = date;
                SO_Date.SelectedDate = SO_Date.TodaysDate;
                SO_CustomerName.SelectedValue = dr3.GetValue(2).ToString();
                dr3.Close();
            }


            SO_ProductName.Enabled = true;
            SO_Quantity.Enabled = true;
            SO_Amount.Enabled = true;
            
            cmd3 = new SqlCommand("select tblSOProduct.*, tblProducts.PName from tblSOProduct, tblProducts where tblSOProduct.PID = tblProducts.PID and SO_ID=@uname", con);
            cmd3.Parameters.AddWithValue("@uname", SearchName);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd3);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            if (dt1.Rows.Count != 0)
            {
                SO_ProductName.DataSource = dt1;
                SO_ProductName.DataTextField = "PName";
                SO_ProductName.DataValueField = "PID";
                SO_ProductName.DataBind();
                SO_ProductName.Items.Insert(0, new ListItem("-Select-", "0"));
                dt1.Dispose();
            }

            lblMsg.Text = "Please re-enter the quantity.";
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SearchName = TextBox1.Text;

            cmd2 = new SqlCommand("select SOPro_ID from tblSOProduct where SO_ID = '" + SearchName + "' and PID ='" + SO_ProductName.SelectedItem.Value + "'", con);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                SO_ProDuctID = dr.GetValue(0).ToString();
                dr.Close();
            }

            cmd = new SqlCommand("UPDATE tblSOProduct SET SOItem_Price = '" + SO_Amount.Text + "', SOItem_Quantity = '" + SO_Quantity.Text + "'WHERE SOPro_ID ='" + SO_ProDuctID + "'", con);
            cmd.ExecuteNonQuery();

            Response.Write("<script> alert('Sales Order Updated Successfully ');  </script>");

            BindSalesOrder1();
            SO_Quantity.Text = "";
            SO_Amount.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SearchName = TextBox1.Text;

            cmd2 = new SqlCommand("select SOPro_ID from tblSOProduct where SO_ID = '" + SearchName + "' and PID ='" + SO_ProductName.SelectedItem.Value + "'", con);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                SO_ProDuctID = dr.GetValue(0).ToString();
                dr.Close();
            }

            cmd = new SqlCommand("DELETE FROM tblSOProduct WHERE SOPro_ID='" + SO_ProDuctID + "'", con);
            cmd.ExecuteNonQuery();

            Response.Write("<script> alert('Sales Order Item Deleted Successfully ');  </script>");

            BindSalesOrder1();
            SO_Quantity.Text = "";
            SO_Amount.Text = "";
        }
    }
}