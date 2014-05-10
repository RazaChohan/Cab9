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
    public partial class cdetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            if(!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Cab where Cab_ID=" + Session["CabDetailsID"].ToString(), conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                RegNumberLabel.Text = dt.Rows[0]["Cab_RegNo"].ToString();
                ChassisNumLabel.Text = dt.Rows[0]["Cab_ChassisNum"].ToString();
                MakeLabel.Text = dt.Rows[0]["Cab_Make"].ToString();
                ModelLabel.Text = dt.Rows[0]["Cab_Model"].ToString();
                StatusLabel.Text = dt.Rows[0]["Cab_Status"].ToString();
                ColorLabel.Text = dt.Rows[0]["Cab_Color"].ToString();
                AssignedDriverLabel.Text = dt.Rows[0]["Cab_AssignedDriver"].ToString();
                conn.Close();
            }
        }

        protected void EditCabDetailsButtons_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCabDetails.aspx");
        }

        protected void DeleteCabButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Driver where Cab_ID=" + Session["CabDetailsID"].ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count>0)
            {
                DeleteWarningLabel.Text = "ERROR! Can not delete cab. It is alloted to Driver " + dt.Rows[0]["Driver_Name"].ToString();
                DeleteWarningLabel.Visible = true;
            }
            else
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Delete from Cab where Cab_ID=" + Session["CabDetailsID"].ToString();
                int result = command.ExecuteNonQuery();
                if(result>0)
                {
                    Response.Redirect("cabs.aspx");

                }
                else
                {
                    DeleteWarningLabel.Text = "ERROR! Can not delete cab.";
                    DeleteWarningLabel.Visible = true;
                }
            }
        }



        protected void DashboardButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }

        protected void DriversButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Drivers.aspx");
        }

        protected void CabsButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Cabs.aspx");
        }

        protected void BookingRequestsButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CabBookingRequests.aspx");
        }

        protected void LogoutButton_Click1(object sender, EventArgs e)
        {
            Session["uname"] = null;
            Response.Redirect("index.aspx");
        }
    }
}