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
    public partial class PurcharseOrder : System.Web.UI.Page
    {
        string SearchName, poItemID;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlCommand cmd3 = new SqlCommand();
        string PO_Id, PO_Id2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (!IsPostBack)
            {
                BindSupplier();
                BindRMaterial();                
            }

            DateTime today = DateTime.Today;
            PO_Date.TodaysDate = today;
            PO_Date.SelectedDate = PO_Date.TodaysDate;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SearchName = TextBox1.Text;

            cmd2 = new SqlCommand("select POITEM_ID from tblPOItems where PO_ID = '"+SearchName+"' and RM_ID ='"+ PO_ItemName.SelectedItem.Value + "'", con);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                poItemID = dr.GetValue(0).ToString();
                dr.Close();
            }

            cmd = new SqlCommand("UPDATE tblPOItems SET POItem_Price = '" + PO_Amount.Text + "', POItem_Quantity = '" + PO_Quantity.Text + "'WHERE POItem_ID ='" + poItemID + "'", con);
            cmd.ExecuteNonQuery();

            Response.Write("<script> alert('Purchase Order Updated Successfully ');  </script>");

            BindPurchaseOrder1();
            PO_Quantity.Text = "";
            PO_Amount.Text = "";           
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SearchName = TextBox1.Text;

            cmd2 = new SqlCommand("select POITEM_ID from tblPOItems where PO_ID = '" + SearchName + "' and RM_ID ='" + PO_ItemName.SelectedItem.Value + "'", con);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                poItemID = dr.GetValue(0).ToString();
                dr.Close();
            }

            cmd = new SqlCommand("DELETE FROM tblPOItems WHERE POITEM_ID='"+ poItemID + "'", con);
            cmd.ExecuteNonQuery();

            Response.Write("<script> alert('Purchase Order Deleted Successfully ');  </script>");

            BindPurchaseOrder1();
            PO_Quantity.Text = "";
            PO_Amount.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            RadioButton1.Enabled = false;
            RadioButton2.Enabled = false;
            btnAdd.Enabled = false;

            SearchName = TextBox1.Text;

            BindPurchaseOrder1();

            cmd = new SqlCommand("select *  from tblPurchaseOrder  where PO_ID=@uname", con);
            cmd.Parameters.AddWithValue("@uname", SearchName);         
            SqlDataReader dr3 = cmd.ExecuteReader();
            if (dr3.Read())
            {
                string dateString = dr3.GetValue(1).ToString();
                DateTime date = Convert.ToDateTime(dateString);
                PO_Date.TodaysDate = date;
                PO_Date.SelectedDate = PO_Date.TodaysDate;
                PO_SupName.SelectedValue = dr3.GetValue(2).ToString();
                dr3.Close();
            }
            

            PO_ItemName.Enabled = true;
            PO_Quantity.Enabled = true;
            PO_Amount.Enabled = true;

            cmd3 = new SqlCommand("select tblPOItems.*, tblRMaterial.RM_Name from tblPOItems, tblRMaterial where tblPOItems.RM_ID = tblRMaterial.RM_ID and PO_ID=@uname", con);
            cmd3.Parameters.AddWithValue("@uname", SearchName);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd3);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            if (dt1.Rows.Count != 0)
            {
                PO_ItemName.DataSource = dt1;
                PO_ItemName.DataTextField = "RM_Name";
                PO_ItemName.DataValueField = "RM_ID";
                PO_ItemName.DataBind();
                PO_ItemName.Items.Insert(0, new ListItem("-Select-", "0"));
                dt1.Dispose();
            }

            lblMsg.Text = "Please re-enter the quantity.";
        }

        private void BindPurchaseOrder1()
        {
            SearchName = TextBox1.Text;

            try
            {
                cmd2 = new SqlCommand("select tblPurchaseOrder.*, tblSupplier.SupName from tblPurchaseOrder, tblSupplier where tblPurchaseOrder.SupID = tblSupplier.SupID and tblPurchaseOrder.PO_ID='" + SearchName + "'", con);
                SqlDataReader dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    lblPOId.Text = dr.GetValue(0).ToString();
                    lblDate.Text = dr.GetValue(1).ToString();
                    lblSupName.Text = dr.GetValue(4).ToString();
                    dr.Close();
                }
            }
            catch (Exception e1) { Response.Write(e1); }

            using (SqlCommand cmd = new SqlCommand("select tblPOItems.*, tblRMaterial.RM_Name from tblPOItems, tblRMaterial where tblPOItems.RM_ID = tblRMaterial.RM_ID and tblPOItems.PO_ID='" + SearchName + "'", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt8 = new DataTable();
                    sda.Fill(dt8);
                    rptrPO.DataSource = dt8;
                    rptrPO.DataBind();
                    dt8.Dispose();
                }
            }
        }

        private void BindPurchaseOrder()
        {
            try
            {
                cmd1 = new SqlCommand("SELECT TOP 1 PO_ID FROM tblPOItems ORDER BY POItem_ID DESC", con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    PO_Id2 = dr.GetValue(0).ToString();
                    dr.Close();
                }
            }
            catch (Exception e1) { Response.Write(e1); }

            try
            {
                cmd2 = new SqlCommand("select tblPurchaseOrder.*, tblSupplier.SupName from tblPurchaseOrder, tblSupplier where tblPurchaseOrder.SupID = tblSupplier.SupID and tblPurchaseOrder.PO_ID='" + PO_Id2+"'", con);
                SqlDataReader dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    lblPOId.Text = dr.GetValue(0).ToString();
                    lblDate.Text = dr.GetValue(1).ToString();
                    lblSupName.Text = dr.GetValue(4).ToString();
                    dr.Close();
                }
            }
            catch (Exception e1) { Response.Write(e1); }

            using (SqlCommand cmd = new SqlCommand("select tblPOItems.*, tblRMaterial.RM_Name from tblPOItems, tblRMaterial where tblPOItems.RM_ID = tblRMaterial.RM_ID and tblPOItems.PO_ID='" + PO_Id2 +"'", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrPO.DataSource = dt;
                    rptrPO.DataBind();
                    dt.Dispose();
                }
            }
        }

        protected void PO_SupName_SelectedIndexChanged(object sender, EventArgs e) 
        {
            BindRMaterial();
        }

        protected void PO_ItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            AmountFetch();

        }

        private void AmountFetch()
        {
            cmd = new SqlCommand("Select RM_Price from tblRMaterial where RM_ID=@uname", con);
            cmd.Parameters.AddWithValue("@uname", PO_ItemName.SelectedItem.Value);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                PO_Amount.Text = dr.GetValue(0).ToString();
                dr.Close();
            }
        }

        private void BindSupplier()
        {
            cmd = new SqlCommand("Select * from tblSupplier", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                PO_SupName.DataSource = dt;
                PO_SupName.DataTextField = "SupName";
                PO_SupName.DataValueField = "SupID";
                PO_SupName.DataBind();
                PO_SupName.Items.Insert(0, new ListItem("-Select-", "0"));
                dt.Dispose();
                
            }
        }

        private void BindRMaterial()
        {

            cmd = new SqlCommand("Select * from tblRMaterial where SupID=@uname ", con);
            cmd.Parameters.AddWithValue("@uname", PO_SupName.SelectedItem.Value);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                PO_ItemName.DataSource = dt;
                PO_ItemName.DataTextField = "RM_Name";
                PO_ItemName.DataValueField = "RM_ID";
                PO_ItemName.DataBind();
                PO_ItemName.Items.Insert(0, new ListItem("-Select-", "0"));
                dt.Dispose();

            }
        }

        protected void AddSelection_CheckedChanged(Object sender, EventArgs e)
        {
            TextBox1.Enabled = false;
            btnSearch.Enabled = false;
            if (RadioButton1.Checked == true)
            {
                PO_Date.Enabled = true;
                PO_SupName.Enabled = true;
                PO_ItemName.Enabled = true;
                PO_Quantity.Enabled = true;
                PO_Amount.Enabled = true;
                PO_SupName.SelectedIndex = 0;
            }
            else if (RadioButton2.Checked == true)
            {
                PO_Date.Enabled = false;
                PO_SupName.Enabled = false;
                PO_ItemName.Enabled = true;
                PO_Quantity.Enabled = true;
                PO_Amount.Enabled = true;
            }
         }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                try
                {
                    cmd = new SqlCommand("Insert into tblPurchaseOrder(PO_Date, SupID) Values('" + PO_Date.SelectedDate + "','" + PO_SupName.SelectedItem.Value + "')", con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1) { Response.Write(e1); }

                try
                {
                    cmd1 = new SqlCommand("SELECT TOP 1 PO_ID FROM tblPurchaseOrder ORDER BY PO_ID DESC", con);
                    SqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read())
                    {
                        PO_Id = dr.GetValue(0).ToString();
                        dr.Close();
                    }
                }
                catch (Exception exp) { Response.Write(exp); }

                try
                {
                    cmd2 = new SqlCommand("Insert into tblPOItems(RM_ID, POItem_Price, POItem_Quantity, PO_ID) Values('" + PO_ItemName.SelectedItem.Value + "','" + PO_Amount.Text + "','" + PO_Quantity.Text + "','" + PO_Id + "')", con);
                    cmd2.ExecuteNonQuery();
                }
                catch (Exception e1) { Response.Write(e1); }

                Response.Write("<script> alert('Purchase Order Added Successfully ');  </script>");
                BindPurchaseOrder();

                con.Close();
                PO_ItemName.SelectedIndex = 0;
                PO_Quantity.Text = "";
                PO_Amount.Text = "";
            }
            else if (RadioButton2.Checked == true)
            {

                try
                {
                    cmd1 = new SqlCommand("SELECT TOP 1 PO_ID FROM tblPurchaseOrder ORDER BY PO_ID DESC", con);
                    SqlDataReader dr = cmd1.ExecuteReader();
                    if (dr.Read())
                    {
                        PO_Id = dr.GetValue(0).ToString();
                        dr.Close();
                    }
                }
                catch (Exception e1) { Response.Write(e1); }

                try
                {
                    cmd2 = new SqlCommand("Insert into tblPOItems(RM_ID, POItem_Price, POItem_Quantity, PO_ID) Values('" + PO_ItemName.SelectedItem.Value + "','" + PO_Amount.Text + "','" + PO_Quantity.Text + "','" + PO_Id + "')", con);
                    cmd2.ExecuteNonQuery();
                }
                catch (Exception e1) { Response.Write(e1); }

                Response.Write("<script> alert('Item Added Successfully ');  </script>");
                BindPurchaseOrder();

                con.Close();
                PO_ItemName.SelectedIndex = 0;
                PO_Quantity.Text = "";
                PO_Amount.Text = "";
            }
        }
        

    }
}