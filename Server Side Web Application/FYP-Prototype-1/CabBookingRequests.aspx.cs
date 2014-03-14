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
    public partial class CabBookingRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select Booking_Status as 'Status', Booking_DateTime as 'Time', Booking_Source as 'Origin', Booking_Destination as 'Destination', Booking_CabType as 'Type Of Cab' from Booking ORDER BY Booking_DateTime DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                BookingsGridView.DataSource = dt;
                BookingsGridView.DataBind();
                conn.Close();
            }

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select Booking_Status as 'Status', Booking_DateTime as 'Time', Booking_Source as 'Origin', Booking_Destination as 'Destination', Booking_CabType as 'Type Of Cab' from Booking ORDER BY Booking_DateTime DESC", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            BookingsGridView.DataSource = dt;
            BookingsGridView.DataBind();
            conn.Close();
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("drivers.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("farecalc.aspx");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Session["uname"] = null;
            Response.Redirect("Index.aspx");
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("roadblock.aspx");
        }

        protected void DashboardButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
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

    }
}