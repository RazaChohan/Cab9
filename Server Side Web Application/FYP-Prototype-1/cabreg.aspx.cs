using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace FYP_Prototype_1
{
    public partial class cabreg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] == null)
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string chassis = TextBox2.Text;
            int length = chassis.Length;
            if (length == 14)
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
                con.Open();
                cmd = new SqlCommand("Select Cab_ChassisNum,Cab_RegNo From Cab where Cab_ChassisNum='" + TextBox2.Text + "' AND Cab_RegNo='" + TextBox1.Text + "'", con);
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    Label8.Visible = true;
                    Label8.Text = "Duplicate Value Error!!!";
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO Cab VALUES('" + TextBox1.Text + "', '" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')", con);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                    }
                    con.Close();
                    Response.Redirect("cabs.aspx");
                }
            }
            else
            {
                Label8.Text = "Chassis Number should be 14 characters long";
                Label8.Visible = true;
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("drivers.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("farecalc.aspx");
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            Session["uname"] = null;
            Response.Redirect("Index.aspx");
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("roadblock.aspx");
        }

    }
}