using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace FYP_Prototype_1
{
    public partial class drivers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Driver", con);
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
            //    }
            //    else if (link_status == "Yes")
            //    {
            //        TableCellCollection myCells = e.Row.Cells;
            //        HyperLink planLink = (HyperLink)myCells[1].Controls[0];
            //        planLink.ImageUrl = "~/gifs/green.gif";
            //    }
            //}
            //else
            //{ }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "DCheck")
            //{
            //    int index = Convert.ToInt32(e.CommandArgument);
            //    string id = GridView1.Rows[index].Cells[2].Text;
            //    string name = GridView1.Rows[index].Cells[3].Text;
            //    string nic = GridView1.Rows[index].Cells[4].Text;
            //    string address = GridView1.Rows[index].Cells[5].Text;
            //    string phone = GridView1.Rows[index].Cells[6].Text;
            //    string dependant = GridView1.Rows[index].Cells[7].Text;
            //    Response.Redirect("ddetails.aspx?id="+id+"&name="+name+"&nic="+nic+"&address="+address+"&phone="+phone+"&dependant="+dependant);
            //}
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("cabs.aspx");
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