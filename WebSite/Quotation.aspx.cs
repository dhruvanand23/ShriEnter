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
            string value = "";
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
                cmd = new SqlCommand("Insert into tblQuotationHome(BedRoom,LivingRoom,Kitchen,WholeHouse,Others,QID) Values('" + bedroom + "','" + livingroom + "','" + kitchen + "','" + wholehouse + "','" + Text1.Text + "')", con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e1) { Response.Write(e1); }
        }
    }
}