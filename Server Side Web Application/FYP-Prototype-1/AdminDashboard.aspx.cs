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
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();  
            if (Session["uname"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            if(!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select Cab.Cab_Status as 'Status', Driver.Driver_Name as 'Driver Name', CabLocations.Latitude as 'Lat', CabLocations.Longitude as 'Long', Cab.Cab_RegNo from Cab,CabLocations, Driver where Cab.Cab_ID=CabLocations.Cab_ID AND Cab.Cab_ID = Driver.Cab_ID", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();

                String Details = String.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Details += dt.Rows[i]["Status"].ToString() + "," + dt.Rows[i]["Driver Name"].ToString() + "," + dt.Rows[i]["Lat"].ToString() + "," + dt.Rows[i]["Long"].ToString() + "," + dt.Rows[i]["Cab_RegNo"].ToString() + "_";
                }
                Session["CurrentCabLocations"] = Details;
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("roadblock.aspx");
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CabBookingRequests.aspx");
        }

        protected void DriversButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("drivers.aspx");
        }

        protected void CabsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("cabs.aspx");
        }

        protected void BookingRequestsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CabBookingRequests.aspx");
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session["uname"] = null;
            Response.Redirect("Index.aspx");
        }

        protected void PendingRegReqButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendingRegRequests.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //Label1.Text = "Page updated at: " + DateTime.Now.ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select Cab.Cab_Status as 'Status', Driver.Driver_Name as 'Driver Name', CabLocations.Latitude as 'Lat', CabLocations.Longitude as 'Long', Cab.Cab_RegNo from Cab,CabLocations, Driver where Cab.Cab_ID=CabLocations.Cab_ID AND Cab.Cab_ID = Driver.Cab_ID", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            String Details = String.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Details += dt.Rows[i]["Status"].ToString() + "," + dt.Rows[i]["Driver Name"].ToString() + "," + dt.Rows[i]["Lat"].ToString() + "," + dt.Rows[i]["Long"].ToString() + ","+dt.Rows[i]["Cab_RegNo"].ToString()+"_";
            }
            Session["CurrentCabLocations"] = Details;
            //Label1.Text = Label1.Text + "<br/>" + Session["CurrentCabLocations"].ToString();
            //Label1.Visible = true;
        }
    }
}