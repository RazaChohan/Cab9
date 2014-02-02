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
            DbOperations obj = new DbOperations();

            if (obj.AuthenticateUser(TextBox1.Text,TextBox2.Text))
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