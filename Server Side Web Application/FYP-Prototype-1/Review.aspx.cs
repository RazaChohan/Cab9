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
    public partial class Review : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void YesButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from pendingCustomers where PCustomer_ID=" + Session["RegReqReviewID"].ToString(), conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "insert into Customer ([Customer_Name],[Customer_Password] ,[Customer_Email],[Customer_PhNum],[Customer_NIC],[Customer_Address],[Customer_Gender],[Customer_Age]) values ('" + dt.Rows[0]["PCustomer_Name"] + "', '" + dt.Rows[0]["PCustomer_Password"] + "','" + dt.Rows[0]["PCustomer_Email"] + "','" + dt.Rows[0]["PCustomer_PhNum"] + "','" + dt.Rows[0]["PCustomer_NIC"] + "', '" + dt.Rows[0]["PCustomer_Address"] + "','" + dt.Rows[0]["PCustomer_Gender"] + "'," + dt.Rows[0]["PCustomer_Age"] + ")";
                command.ExecuteNonQuery();
                command.CommandText="delete from pendingCustomers where PCustomer_ID="+Session["RegReqReviewID"].ToString();
                command.ExecuteNonQuery();
                conn.Close();
                Label1.Visible = false;
                noButton.Visible = false;
                YesButton.Visible = false;
                Label2.Visible = true;
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void noButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from pendingCustomers where PCustomer_ID=" + Session["RegReqReviewID"].ToString(), conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "insert into RejectedCustomers ([RCustomer_Name],[RCustomer_Password] ) values ('" + dt.Rows[0]["PCustomer_Name"] + "', '" + dt.Rows[0]["PCustomer_Password"] + "')";
                command.ExecuteNonQuery();
                command.CommandText = "delete from pendingCustomers where PCustomer_ID=" + Session["RegReqReviewID"].ToString();
                command.ExecuteNonQuery();
                conn.Close();
                Label1.Visible = false;
                noButton.Visible = false;
                YesButton.Visible = false;
                Label2.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}