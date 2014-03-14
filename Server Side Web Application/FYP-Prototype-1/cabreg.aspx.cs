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
            string chassis = ChassisNumberTextBox.Text;
            int length = chassis.Length;
            if (length == 14)
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
                con.Open();
                cmd = new SqlCommand("Select Cab_ChassisNum,Cab_RegNo From Cab where Cab_ChassisNum='" + ChassisNumberTextBox.Text + "' AND Cab_RegNo='" + RegistrationNumberTextBox.Text + "'", con);
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    Label8.Visible = true;
                    Label8.Text = "Duplicate Value Error!";
                    
                }
                else
                {
                    read.Close();
                    cmd = new SqlCommand("INSERT INTO Cab ( Cab_RegNo, Cab_ChassisNum, Cab_Make, Cab_Model, Cab_Status, Cab_Color, Cab_AssignedDriver) VALUES('" + RegistrationNumberTextBox.Text + "', '" + ChassisNumberTextBox.Text + "','" + MakeDropDown.SelectedItem.ToString() + "','" + ModelTextBox.Text + "','Available','"+ColorTextBox.Text+"','No')", con);
                    try
                    {
                        int rows=cmd.ExecuteNonQuery();
                        if(rows>=1)
                        {
                            Label8.Text = "Cab Successfully Added";
                            Label8.Visible = true;
                            RegistrationNumberTextBox.Text = "";
                            ChassisNumberTextBox.Text = "";
                            ModelTextBox.Text = "";
                            ColorTextBox.Text = "";                        
                            

                        }
                        else
                        {
                            Label8.Text = "Cab Not Added";
                            Label8.Visible = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                        Label8.Text = error;
                        Label8.Visible = true;
                    }
                    con.Close();
                }
            }
            else
            {
                Label8.Text = "Chassis Number should be 14 characters long";
                Label8.Visible = true;
            }
        }

    }
}