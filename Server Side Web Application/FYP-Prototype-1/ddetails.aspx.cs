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
    public partial class ddetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            SqlConnection conn= new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
            SqlDataAdapter da = new SqlDataAdapter("Select * from driver where Driver_Name='" + Session["DriverDetailsName"].ToString() + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            NameLabel.Text = dt.Rows[0]["Driver_Name"].ToString();
            PasswordLabel.Text = dt.Rows[0]["Driver_Password"].ToString();
            EmailLabel.Text = dt.Rows[0]["Driver_Email"].ToString();
            PhoneNumberLabel.Text = dt.Rows[0]["Driver_PhNum"].ToString();
            NICLabel.Text = dt.Rows[0]["Driver_NIC"].ToString();
            TextBox1.Text = dt.Rows[0]["Driver_Address"].ToString();
            GenderLabel.Text = dt.Rows[0]["Driver_Gender"].ToString();
            AgeLabel.Text = dt.Rows[0]["Driver_Age"].ToString();

            // To view the driver picture
            Session["Image"] = (byte[])dt.Rows[0]["Driver_Picture"];
            byte[] imgSrc = (byte[])Session["image"];
            string imgSrcStr = Convert.ToBase64String(imgSrc);
            string imageSrc = string.Format("data:image/gif;base64,{0}", imgSrcStr);
            DriverImage.ImageUrl = imageSrc;

            da = new SqlDataAdapter("Select Cab_RegNo from cab where Cab_ID=" + dt.Rows[0]["Cab_ID"].ToString(), conn);
            dt = new DataTable();
            da.Fill(dt);
            CabNoLabel.Text = dt.Rows[0]["Cab_RegNo"].ToString();
            conn.Close();
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditDriverDetails.aspx");
        }
    }
}