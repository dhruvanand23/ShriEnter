using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebSite
{
    public partial class Quotation : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-GQMSKCM\SQLEXPRESS;Initial Catalog=mydata1;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        int UserID1;
        int bedroom, livingroom, kitchen, wholehouse, office, restaurant, hospital, lobbies;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            
            //Getting userId using email id
            string username = (string)Session["Username"];
            try
            {
                cmd = new SqlCommand("Select Uid from [tblUsers] where Email=@uname", con);
                cmd.Parameters.AddWithValue("@uname", username);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string userID = dr.GetValue(0).ToString();
                    UserID1 = Convert.ToInt32(userID);
                    dr.Close();
                }
            }
            catch (Exception exp) { Response.Write(exp); }

        }

        protected void Submit_Details_Click(object sender, EventArgs e)
        {
            string value = "", Qid="";
            //int QuoteId;
            bool isChecked = RadioButton1.Checked;
            if (isChecked)
            {
                value = RadioButton1.Text;

                if (CheckBox1.Checked == true)
                    bedroom = 1;
                else
                    bedroom = 0;

                if (CheckBox2.Checked == true)
                    livingroom = 1;
                else
                    livingroom = 0;

                if (CheckBox3.Checked == true)
                    kitchen = 1;
                else
                    kitchen = 0;

                if (CheckBox4.Checked == true)
                    wholehouse = 1;
                else
                    wholehouse = 0;

            }
            else
            {
                value = RadioButton2.Text;

                if (CheckBox6.Checked == true)
                    office = 1;
                else
                    office = 0;

                if (CheckBox7.Checked == true)
                    restaurant = 1;
                else
                    restaurant = 0;

                if (CheckBox8.Checked == true)
                    hospital = 1;
                else
                    hospital = 0;

                if (CheckBox9.Checked == true)
                    lobbies = 1;
                else
                    lobbies = 0;
            }

            try
            {
                cmd = new SqlCommand("Insert into tblQuotationType(QType,Uid) Values('"+value+"','"+UserID1+"')", con);
                cmd.ExecuteNonQuery();
            }
            catch(Exception e1) { Response.Write(e1); }

            try
            {
                cmd = new SqlCommand("SELECT TOP 1 Qid FROM [tblQuotationType] ORDER BY Qid DESC", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Qid = dr.GetValue(0).ToString();
                    //QuoteId = Convert.ToInt32(Qid);
                    dr.Close();
                }
            }
            catch (Exception exp) { Response.Write(exp); }

            try
            {
                cmd = new SqlCommand("Insert into tblQuotationHome(BedRoom,LivingRoom,Kitchen,WholeHouse,Others,QID) Values('" + bedroom + "','" + livingroom + "','" + kitchen + "','" + wholehouse + "','" + TextBox1.Text + "','" + Qid + "')", con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e1) { Response.Write(e1); }

            try
            {
                cmd = new SqlCommand("Insert into tblQuotationCom(Office,Restaurant,Hospital,Lobbies,Others,QID) Values('" + office + "','" + restaurant + "','" + hospital + "','" + lobbies + "','" + TextBox2.Text + "','" + Qid + "')", con);
                cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e1) { Response.Write(e1); }

        }

        protected void InteriorType_CheckedChanged(Object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                CheckBox1.Enabled = true;
                CheckBox2.Enabled = true;
                CheckBox3.Enabled = true;
                CheckBox4.Enabled = true;
                TextBox1.Enabled = true;
                CheckBox6.Enabled = false;
                CheckBox7.Enabled = false;
                CheckBox8.Enabled = false;
                CheckBox9.Enabled = false;
                TextBox2.Enabled = false;
            }

            if (RadioButton2.Checked)
            {
                CheckBox6.Enabled = true;
                CheckBox7.Enabled = true;
                CheckBox8.Enabled = true;
                CheckBox9.Enabled = true;
                TextBox2.Enabled = true;
                CheckBox1.Enabled = false;
                CheckBox2.Enabled = false;
                CheckBox3.Enabled = false;
                CheckBox4.Enabled = false;
                TextBox1.Enabled = false;
            }
        }
    }
}