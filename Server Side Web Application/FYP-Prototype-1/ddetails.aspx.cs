using System;
using System.Collections.Generic;
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

            string id = Request.QueryString["id"];
            string name = Request.QueryString["name"];
            string nic = Request.QueryString["nic"];
            string address = Request.QueryString["address"];
            string phone = Request.QueryString["phone"];
            string dependant = Request.QueryString["dependant"];
            Label2.Text = "ID: " + id;
            Label2.ForeColor = System.Drawing.Color.White ;
            Label3.ForeColor = System.Drawing.Color.White;
            Label4.ForeColor = System.Drawing.Color.White;
            Label5.ForeColor = System.Drawing.Color.White;
            Label6.ForeColor = System.Drawing.Color.White;
            Label7.ForeColor = System.Drawing.Color.White;
            Label3.Text = "Name: " + name;
            Label4.Text = "NIC: " + nic;
            Label5.Text = "Address: " + address;
            Label6.Text = "Phone: " + phone;
            Label7.Text = "Dependant: " + dependant;
            Label8.Visible = false;

        }
    }
}