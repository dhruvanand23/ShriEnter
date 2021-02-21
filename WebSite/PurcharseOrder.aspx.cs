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

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd1 = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        string PO_Id;
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
                BindPurchaseOrder();
            }

            DateTime today = DateTime.Today;
            PO_Date.TodaysDate = today;
            PO_Date.SelectedDate = PO_Date.TodaysDate;
        }

        private void BindPurchaseOrder()
        {
            using (SqlCommand cmd = new SqlCommand("select tblPOItems.*, tblRMaterial.RM_Name from tblPOItems, tblRMaterial where tblPOItems.RM_ID = tblRMaterial.RM_ID", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrPO.DataSource = dt;
                    rptrPO.DataBind();
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

            }
        }

        protected void AddSelection_CheckedChanged(Object sender, EventArgs e)
        {
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

                con.Close();
                PO_ItemName.SelectedIndex = 0;
                PO_Quantity.Text = "";
                PO_Amount.Text = "";
            }


        }
    }
}