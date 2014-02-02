using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace FYP_Prototype_1
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString();
            SqlConnection sqlConn = new SqlConnection(ConnectionString);
            SqlDataAdapter ad = new SqlDataAdapter();
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from Admin where Admin_Name= '" + TextBox1.Text + "' And Admin_Password= '" + TextBox2.Text + "'", sqlConn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Session["uname"] = TextBox1.Text;
                Response.Redirect("dashboard.aspx");
            }
            else
            {
                Label3.Visible = true;
                Label3.Text = "Invalid Username or Password!!!";
            }
        }
    }
}