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
    public partial class Supplier : System.Web.UI.Page
    {
        string SearchName;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindSupplier();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("Insert into tblSupplier(SupName, SupPhNo, SupAdd, SupEmail, SupGST, SupBank, SupAccNo, SupIFSC) Values('" + SupName.Text + "','" + SupPhNumber.Text + "','" + SupAddress.Text + "','" + SupEmail.Text + "','" + SupGST.Text + "','" + SupBankName.Text + "','" + SupAccNo.Text + "','" + SupIFSC.Text + "')", con);
                cmd.ExecuteNonQuery();

                Response.Write("<script> alert('Supplier Added Successfully ');  </script>");
                BindSupplier();
                con.Close();
                SupName.Text = "";
                SupPhNumber.Text = "";
                SupAddress.Text = "";
                SupEmail.Text = "";
                SupGST.Text = "";
                SupBankName.Text = "";
                SupAccNo.Text = "";
                SupIFSC.Text = "";
                SupName.Focus();
            }
            catch (Exception e1)
            {
                Response.Write(e1);
            }
            
        }
        private void BindSupplier()
        {
            using (cmd = new SqlCommand("select * from tblSupplier", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrSupplier.DataSource = dt;
                    rptrSupplier.DataBind();
                }
            }
        }

        

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchName = TextBox1.Text ;
            cmd = new SqlCommand("Select * from tblSupplier where SupName=@uname", con);
            cmd.Parameters.AddWithValue("@uname", SearchName);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                 
                SupName.Text= dr.GetValue(1).ToString();
                SupPhNumber.Text = dr.GetValue(2).ToString();
                SupAddress.Text = dr.GetValue(3).ToString();
                SupEmail.Text = dr.GetValue(4).ToString();
                SupGST.Text = dr.GetValue(5).ToString();
                SupBankName.Text = dr.GetValue(6).ToString();
                SupAccNo.Text = dr.GetValue(7).ToString();
                SupIFSC.Text = dr.GetValue(8).ToString();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SearchName = TextBox1.Text;
            cmd = new SqlCommand("UPDATE tblSupplier SET SupName = '"+SupName.Text+"', SupPhNo = '"+SupPhNumber.Text+ "', SupAdd = '" + SupAddress.Text + "',SupEmail = '" + SupEmail.Text + "',SupGST = '" + SupGST.Text + "',SupBank = '" + SupBankName.Text + "',SupAccNo = '" + SupAccNo.Text + "',SupIFSC = '" + SupIFSC.Text + "' WHERE SupName=@uname;", con);
            cmd.Parameters.AddWithValue("@uname", SearchName);
            cmd.ExecuteNonQuery();

            Response.Write("<script> alert('Supplier Updated Successfully ');  </script>");
            BindSupplier();
            con.Close();
            SupName.Text = "";
            SupPhNumber.Text = "";
            SupAddress.Text = "";
            SupEmail.Text = "";
            SupGST.Text = "";
            SupBankName.Text = "";
            SupAccNo.Text = "";
            SupIFSC.Text = "";
            SupName.Focus();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SearchName = TextBox1.Text;
            cmd = new SqlCommand("DELETE FROM tblSupplier WHERE SupName=@uname", con);
            cmd.Parameters.AddWithValue("@uname", SearchName);
            cmd.ExecuteNonQuery();

            Response.Write("<script> alert('Supplier Deleted Successfully ');  </script>");
            BindSupplier();
            con.Close();
            SupName.Text = "";
            SupPhNumber.Text = "";
            SupAddress.Text = "";
            SupEmail.Text = "";
            SupGST.Text = "";
            SupBankName.Text = "";
            SupAccNo.Text = "";
            SupIFSC.Text = "";
            SupName.Focus();
        }
    }
}