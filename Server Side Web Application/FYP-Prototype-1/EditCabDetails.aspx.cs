using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Prototype_1
{
    public partial class EditCabDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Cab where Cab_ID=" + Session["CabDetailsID"].ToString(), conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                RegistrationNumbertextBox.Text = dt.Rows[0]["Cab_RegNo"].ToString();
                ChassisNumTextBox.Text = dt.Rows[0]["Cab_ChassisNum"].ToString();
                MakeDropDown.Text = dt.Rows[0]["Cab_Make"].ToString();
                ModelTextBox.Text = dt.Rows[0]["Cab_Model"].ToString();
                StatusLabel.Text = dt.Rows[0]["Cab_Status"].ToString();
                ColorTextBox.Text = dt.Rows[0]["Cab_Color"].ToString();
                AssignedDriverLabel.Text = dt.Rows[0]["Cab_AssignedDriver"].ToString();
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(ChassisNumTextBox.Text.Length != 14)
                {
                    WarningLabel.Text = "ERROR! Chassis number should be 14 digits long.";
                    WarningLabel.Visible = true;

                }
                else
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = "Update Cab set Cab_RegNo='" + RegistrationNumbertextBox.Text + "', Cab_ChassisNum='" + ChassisNumTextBox.Text + "', Cab_Make='" + MakeDropDown.SelectedItem.ToString() + "', Cab_Model='" + ModelTextBox.Text + "', Cab_Color='" + ColorTextBox.Text + "' where Cab_ID=" + Session["CabDetailsID"].ToString();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        WarningLabel.Text = "Changes committed successfully.";
                        WarningLabel.Visible = true;
                    }
                    else
                    {
                        WarningLabel.Text = "ERROR! Changes not committed.";
                        WarningLabel.Visible = true;
                    }
                }
            }
            catch(Exception ex)
            {
                WarningLabel.Text = ex.Message;
                WarningLabel.Visible = true;

            }

        }

    }
}