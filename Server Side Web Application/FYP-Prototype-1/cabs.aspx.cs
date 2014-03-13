using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

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
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select [Cab_ID] as 'ID',[Cab_RegNo] as 'Registration Number',[Cab_Make] as 'Make',[Cab_Model] as 'Model', [Cab_Status] as 'Status' from Cab", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns.Add("StatusLight", typeof(Byte[]));
                GridView1.DataSource = dt;
                GridView1.DataBind();
                con.Close();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
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

        //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session["CabDetailsID"] = GridView1.SelectedRow.Cells[1].Text;
        //    Response.Redirect("cdetails.aspx");
        //}


        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["CabDetailsID"] = GridView1.SelectedRow.Cells[1].Text;
            Response.Redirect("cdetails.aspx");
        }

        private static byte[] ReadImage(string p_postedImageFileName, string[] p_fileType)
        {
            bool isValidFileType = false;
            try
            {
                FileInfo file = new FileInfo(p_postedImageFileName);

                foreach (string strExtensionType in p_fileType)
                {
                    if (strExtensionType == file.Extension)
                    {
                        isValidFileType = true;
                        break;
                    }
                }
                if (isValidFileType)
                {
                    FileStream fs = new FileStream(p_postedImageFileName, FileMode.Open, FileAccess.Read);

                    BinaryReader br = new BinaryReader(fs);

                    byte[] image = br.ReadBytes((int)fs.Length);

                    br.Close();

                    fs.Close();

                    return image;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItem != null)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string link_status = drv["Status"].ToString();

                if (link_status == "Unavailable")
                {
                    drv["StatusLight"] = ReadImage(@"C:\Users\walee_000\Documents\Cab9\Server Side Web Application\FYP-Prototype-1\gifs\red.gif",new string[]{".gif"});
                    //TableCellCollection myCells = e.Row.Cells;
                    //int count = e.Row.Cells.Count;
                    //HyperLink planLink = (HyperLink)myCells[count + 1].Controls[0];
                    //planLink.ImageUrl = "~/gifs/red.gif";
                }
                else if (link_status == "Available")
                {
                    drv["StatusLight"] = ReadImage(@"C:\Users\walee_000\Documents\Cab9\Server Side Web Application\FYP-Prototype-1\gifs\green.gif", new string[] { ".gif" });
                    //TableCellCollection myCells = e.Row.Cells;
                    //int count = e.Row.Cells.Count;
                    //HyperLink planLink = (HyperLink)myCells[count+1].Controls[0];
                    //planLink.ImageUrl = "~/gifs/green.gif";
                }
            }
            else
            { }
        }


    }
}