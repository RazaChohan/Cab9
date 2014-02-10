using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace FYP_Prototype_1
{
    public partial class cabs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] == null)
            {
                Response.Redirect("Index.aspx");
            }
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select [Cab_ID] as 'ID',[Cab_RegNo] as 'Registration Number',[Cab_ChassisNum] as 'Chassis Number',[Cab_Make] as 'Make',[Cab_Model] as 'Model',[Cab_Status] as 'Availability Status',[Cab_Color] as 'Color',[Cab_AssignedDriver] as 'Driver Assignment' from Cab", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                con.Close(); 
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.DataItem != null)
            //{
            //    DataRowView drv = (DataRowView)e.Row.DataItem;
            //    string link_status = drv["Availability"].ToString();

            //    if (link_status == "No")
            //    {
            //        TableCellCollection myCells = e.Row.Cells;
            //        HyperLink planLink = (HyperLink)myCells[1].Controls[0];
            //        planLink.ImageUrl = "~/gifs/red.gif";
            ////    }
            ////    else if (link_status == "Yes")
            ////    {
            ////        TableCellCollection myCells = e.Row.Cells;
            ////        HyperLink planLink = (HyperLink)myCells[1].Controls[0];
            ////        planLink.ImageUrl = "~/gifs/green.gif";
            ////    }
            //}
            //else
            //{ }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "DCheck")
            //{
            //    Response.Redirect("cdetails.aspx");
            //}
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("drivers.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("dashboard.aspx");
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


    }
}