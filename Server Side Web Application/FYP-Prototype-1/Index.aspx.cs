using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Prototype_1
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection sqlConn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\walee_000\Desktop\Web-Prototype\FYP-Prototype-1\FYP-Prototype-1\FYP-Prototype-1\App_Data\stats.mdf;Integrated Security=True");
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
            //if (TextBox1.Text == "RadioCab" && TextBox2.Text == "radiocab")
            //{
            //    Response.Redirect("dashboard.aspx");
            //}
        }
    }
}