using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Prototype_1
{
    public partial class cabs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlCommand cmd;

            ///////////////////////////////////////////
            if (Session["uname"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            if(!IsPostBack)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\FYP-Prototype-1\FYP-Prototype-1\FYP-Prototype-1\App_Data\stats.mdf;Integrated Security=True");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Cab", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                con.Close(); 
            }
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
            Response.Redirect("dashboard.aspx");
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