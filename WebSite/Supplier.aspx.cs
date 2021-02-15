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

        
    }
}