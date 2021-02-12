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
        string bedroom, livingroom, kitchen, wholehouse, office, restaurant, hospital, lobbies;
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
                    bedroom = "Yes";
                else
                    bedroom = "No";

                if (CheckBox2.Checked == true)
                    livingroom = "Yes";
                else
                    livingroom = "No";

                if (CheckBox3.Checked == true)
                    kitchen = "Yes";
                else
                    kitchen = "No";

                if (CheckBox4.Checked == true)
                    wholehouse = "Yes";
                else
                    wholehouse = "No";

            }
            else
            {
                value = RadioButton2.Text;

                if (CheckBox6.Checked == true)
                    office = "Yes";
                else
                    office = "No";

                if (CheckBox7.Checked == true)
                    restaurant = "Yes";
                else
                    restaurant = "No";

                if (CheckBox8.Checked == true)
                    hospital = "Yes";
                else
                    hospital = "No";

                if (CheckBox9.Checked == true)
                    lobbies = "Yes";
                else
                    lobbies = "No";
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
                    dr.Close();
                }
            }
            catch (Exception exp) { Response.Write(exp); }

            if (RadioButton1.Checked == true)
            {
                try
                {
                    cmd = new SqlCommand("Insert into tblQuotationHome(BedRoom,LivingRoom,Kitchen,WholeHouse,Others,QID) Values('" + bedroom + "','" + livingroom + "','" + kitchen + "','" + wholehouse + "','" + TextBox1.Text + "','" + Qid + "')", con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1) { Response.Write(e1); }

            }
            else if(RadioButton2.Checked == true)
            {
                try
                {
                    cmd = new SqlCommand("Insert into tblQuotationCom(Office,Restaurant,Hospital,Lobbies,Others,QID) Values('" + office + "','" + restaurant + "','" + hospital + "','" + lobbies + "','" + TextBox2.Text + "','" + Qid + "')", con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e1) { Response.Write(e1); }
            }


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
                CheckBox6.Checked = false;
                CheckBox7.Enabled = false;
                CheckBox7.Checked = false;
                CheckBox8.Enabled = false;
                CheckBox8.Checked = false;
                CheckBox9.Enabled = false;
                CheckBox9.Checked = false;
                TextBox2.Enabled = false;
                TextBox2.Text = "";
            }

            if (RadioButton2.Checked)
            {
                CheckBox6.Enabled = true;
                CheckBox7.Enabled = true;
                CheckBox8.Enabled = true;
                CheckBox9.Enabled = true;
                TextBox2.Enabled = true;
                CheckBox1.Enabled = false;
                CheckBox1.Checked = false;
                CheckBox2.Enabled = false;
                CheckBox2.Checked = false;
                CheckBox3.Enabled = false;
                CheckBox3.Checked = false;
                CheckBox4.Enabled = false;
                CheckBox4.Checked = false;
                TextBox1.Enabled = false;
                TextBox1.Text= "";
            }
        }
    }
}