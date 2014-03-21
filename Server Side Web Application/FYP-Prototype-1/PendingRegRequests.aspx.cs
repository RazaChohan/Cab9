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
    public partial class PendingRegRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT [PCustomer_ID] as 'ID',[PCustomer_Name] as 'Name',[PCustomer_Email] as 'Email',[PCustomer_PhNum] as 'Contact',[PCustomer_NIC] as 'NIC',[PCustomer_Address] as 'Address',[PCustomer_Gender] as 'Gender',[PCustomer_Age] as 'Age' FROM [Cab9].[dbo].[PendingCustomers]", conn);
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
            SqlDataAdapter da = new SqlDataAdapter("SELECT [PCustomer_ID] as 'ID',[PCustomer_Name] as 'Name',[PCustomer_Email] as 'Email',[PCustomer_PhNum] as 'Contact',[PCustomer_NIC] as 'NIC',[PCustomer_Address] as 'Address',[PCustomer_Gender] as 'Gender',[PCustomer_Age] as 'Age' FROM [Cab9].[dbo].[PendingCustomers]", conn);
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

        protected void BookingsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["RegReqReviewID"] = BookingsGridView.SelectedRow.Cells[1].Text;
        }

        protected void ReviewButton_Click(object sender, ImageClickEventArgs e)
        {
            string queryString = "Review.aspx";

            string newWin = "window.open('" + queryString + "');";

            ClientScript.RegisterStartupScript(this.GetType(), "pop", newWin, true);
        }
    }
}