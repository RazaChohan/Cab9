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
    public partial class EditDriverDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            if(!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("Select * from driver where Driver_Name='" + Session["DriverDetailsName"].ToString() + "'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Session["DriverEditID"] = dt.Rows[0]["Driver_ID"].ToString();      //Which driver ID to update
                NameTextBox.Text = dt.Rows[0]["Driver_Name"].ToString();
                PasswordTextBox.Text = dt.Rows[0]["Driver_Password"].ToString();
                EmailTextBox.Text = dt.Rows[0]["Driver_Email"].ToString();
                PhoneNumberTextBox.Text = dt.Rows[0]["Driver_PhNum"].ToString();
                NICTextBox.Text = dt.Rows[0]["Driver_NIC"].ToString();
                TextBox1.Text = dt.Rows[0]["Driver_Address"].ToString();
                GenderLabel.Text = dt.Rows[0]["Driver_Gender"].ToString();

                // To view the driver picture
                Session["Image"] = (byte[])dt.Rows[0]["Driver_Picture"];
                byte[] imgSrc = (byte[])Session["image"];
                string imgSrcStr = Convert.ToBase64String(imgSrc);
                string imageSrc = string.Format("data:image/gif;base64,{0}", imgSrcStr);
                DriverImage.ImageUrl = imageSrc;

                da = new SqlDataAdapter("Select Cab_RegNo from cab where Cab_ID=" + dt.Rows[0]["Cab_ID"].ToString(), conn);
                dt = new DataTable();
                da.Fill(dt);
                conn.Close();
            }
        }

        protected void CommitChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "Update Driver set Driver_Name='" + NameTextBox.Text + "', Driver_Password='" + PasswordTextBox.Text + "', Driver_Email='" + EmailTextBox.Text + "', Driver_PhNum='" + PhoneNumberTextBox.Text + "', Driver_NIC='" + NICTextBox.Text + "', Driver_Address='" + TextBox1.Text + "' where Driver_ID=" + Session["DriverEditID"].ToString();
                int result = command.ExecuteNonQuery();
                if(result>0)
                {
                    WarningLabel.Text = "Changes updated successfully!";
                    WarningLabel.Visible = true;
                }
                else
                {
                    WarningLabel.Text = "ERROR! Changes not committed";
                    WarningLabel.Visible = true;
                }
                conn.Close();
            }   
            catch(Exception ex)
            {
                WarningLabel.Text = ex.Message.ToString();
                WarningLabel.Visible = true;
            }
        }
    }
}