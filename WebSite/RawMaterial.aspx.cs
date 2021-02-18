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
    public partial class RawMaterial : System.Web.UI.Page
    {
        string SearchName;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindRMaterial();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (!IsPostBack)
            {
                BindSupplier();
                
            }

        }

        private void BindRMaterial()
        {
            using (cmd = new SqlCommand("Select tblRMaterial.*,tblSupplier.SupName from tblRMaterial, tblSupplier where tblRMaterial.SupID = tblSupplier.SupID ", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrRMaterial.DataSource = dt;
                    rptrRMaterial.DataBind();
                }
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
                RMSupplier.DataSource = dt;
                RMSupplier.DataTextField = "SupName";
                RMSupplier.DataValueField = "SupID";
                RMSupplier.DataBind();
                RMSupplier.Items.Insert(0, new ListItem("-Select-", "0"));

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Insert into tblRMaterial(RM_Name, RM_Price, RM_Unit, SupID) Values('" + RMName.Text + "','" + RMPrice.Text + "','" + RMUnit.Text + "','" + RMSupplier.SelectedItem.Value + "')", con);
                cmd.ExecuteNonQuery();

                Response.Write("<script> alert('Raw Material Added Successfully ');  </script>");

                BindRMaterial();
                con.Close();
                RMName.Text = "";
                RMPrice.Text = "";
                RMUnit.Text = "";
                RMSupplier.SelectedIndex = 0;
                RMName.Focus();
            }
            catch (Exception e1)
            {
                Response.Write(e1);
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchName = TextBox1.Text;
            cmd = new SqlCommand("Select * from tblRMaterial where RM_Name=@uname", con);
            cmd.Parameters.AddWithValue("@uname", SearchName);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                RMName.Text = dr.GetValue(1).ToString();
                RMPrice.Text = dr.GetValue(2).ToString();
                RMUnit.Text = dr.GetValue(3).ToString();
                string userID = dr.GetValue(4).ToString();
                RMSupplier.SelectedIndex = Convert.ToInt32(userID);                
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SearchName = TextBox1.Text;
            cmd = new SqlCommand("UPDATE tblRMaterial SET RM_Name = '" + RMName.Text + "', RM_Price = '" + RMPrice.Text + "', RM_Unit = '" + RMUnit.Text + "',SupID = '" + RMSupplier.SelectedItem.Value + "' WHERE RM_Name=@uname;", con);
            cmd.Parameters.AddWithValue("@uname", SearchName);
            cmd.ExecuteNonQuery();

            Response.Write("<script> alert('Supplier Updated Successfully ');  </script>");

            BindRMaterial();

            con.Close();
            RMName.Text = "";
            RMPrice.Text = "";
            RMUnit.Text = "";
            RMSupplier.SelectedIndex = 0;
            RMName.Focus();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SearchName = TextBox1.Text;
            cmd = new SqlCommand("DELETE FROM tblRMaterial WHERE RM_Name=@uname", con);
            cmd.Parameters.AddWithValue("@uname", SearchName);
            cmd.ExecuteNonQuery();

            Response.Write("<script> alert('Supplier Deleted Successfully ');  </script>");

            BindRMaterial();

            con.Close();
            RMName.Text = "";
            RMPrice.Text = "";
            RMUnit.Text = "";
            RMSupplier.SelectedIndex = 0;
            RMName.Focus();
        }
    }
}