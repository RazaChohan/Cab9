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
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
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
                SqlConnection conn0 = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
                conn0.Open();
                SqlDataAdapter da0 = new SqlDataAdapter("Select COUNT(Cab_ID) As Cabs from Cab", conn0);
                DataTable dt0 = new DataTable();
                da0.Fill(dt0);
                ASPxGaugeControl1.Value = dt0.Rows[0]["Cabs"].ToString();
                conn0.Close();
                SqlConnection conn1 = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
                conn1.Open();
                SqlDataAdapter da1 = new SqlDataAdapter("Select COUNT(Booking_ID) As Bookings from Booking WHERE Booking_Status='Catered'", conn1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                ASPxGaugeControl2.Value = dt1.Rows[0]["Bookings"].ToString();
                conn1.Close();
                SqlConnection conn2 = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
                conn2.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("Select COUNT(Driver_ID) As Drivers from Driver", conn2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                ASPxGaugeControl3.Value = dt2.Rows[0]["Drivers"].ToString();
                conn2.Close();

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
            SqlConnection conn = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
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

            //Label1.Text = Label1.Text + "<br/>" + Session["CurrentCabLocations"].ToString();
            //Label1.Visible = true;
        }
    }
}