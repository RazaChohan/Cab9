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
            if (Session["uname"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            if(!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select Customer.Customer_Name as 'Customer Name', Booking_Status as 'Status', Booking_DateTime as 'Time', Booking_Source as 'Origin', Booking_Destination as 'Destination', Booking_CabType as 'Type Of Cab' from Booking,Customer where Booking.Customer_ID=Customer.Customer_ID ORDER BY Booking_DateTime DESC", conn);
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
            SqlDataAdapter da = new SqlDataAdapter("Select Customer.Customer_Name as 'Customer Name', Booking_Status as 'Status', Booking_DateTime as 'Time', Booking_Source as 'Origin', Booking_Destination as 'Destination', Booking_CabType as 'Type Of Cab' from Booking,Customer where Booking.Customer_ID=Customer.Customer_ID ORDER BY Booking_DateTime DESC", conn);
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

        protected void BookingsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string link_status = drv["Status"].ToString();

                if (link_status == "Uncatered")
                {
                    //drv["StatusLight"] = ReadImage(@"C:\Users\walee_000\Documents\Cab9\Server Side Web Application\FYP-Prototype-1\gifs\red.gif",new string[]{".gif"});
                    TableCellCollection myCells = e.Row.Cells;
                    int count = e.Row.Cells.Count;
                    HyperLink planLink = (HyperLink)myCells[0].Controls[0];
                    planLink.ImageUrl = "~/gifs/red.gif";
                }
                else if (link_status == "Catered")
                {
                    //drv["StatusLight"] = ReadImage(@"C:\Users\walee_000\Documents\Cab9\Server Side Web Application\FYP-Prototype-1\gifs\green.gif", new string[] { ".gif" });
                    TableCellCollection myCells = e.Row.Cells;
                    int count = e.Row.Cells.Count;
                    HyperLink planLink = (HyperLink)myCells[0].Controls[0];
                    planLink.ImageUrl = "~/gifs/green.gif";
                }
            }
            else
            { }
        }

    }
}