using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Driver_Activation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string constr = ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString;
            string activationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"]) ? Request.QueryString["ActivationCode"] : Guid.Empty.ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter("select Driver_ID from Driver_ActivationStatus where ActivationCode =" + activationCode, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                String DriverID = dt.Rows[0]["Driver_ID"].ToString();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM DriverActivation WHERE ActivationCode = @ActivationCode"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                        cmd.Connection = con;
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                        if (rowsAffected == 1)
                        {
                            ltMessage.Text = "Activation successful.";
                        }
                        else
                        {
                            ltMessage.Text = "Invalid Activation code.";
                        }
                    }
                }

                SqlCommand command = con.CreateCommand();
                command.CommandText = "Update driver set Driver_ActivationStatus='Activated' where Driver_ID =" + DriverID;
                command.ExecuteNonQuery();
            }
        }
    }
}