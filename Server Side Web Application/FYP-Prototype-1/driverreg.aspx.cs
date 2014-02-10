using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Prototype_1
{
    public partial class driverreg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                WarningLabel.Visible = false;
            }
           
            if (Session["uname"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select Cab_RegNo from Cab where Cab_AssignedDriver='No'",conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                CabDropDown.Items.Clear();
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    CabDropDown.Items.Add(dt.Rows[i]["Cab_RegNo"].ToString());
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("drivers.aspx");
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

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            try
            {
                // ~~~~~~~~~~~~~~~~~~~~~~ Code for image upload ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                string ImageName = string.Empty;
                byte[] Image = null;
                if (ImageUploadToDB.PostedFile != null && ImageUploadToDB.PostedFile.FileName != "")
                {
                    ImageName = Path.GetFileName(ImageUploadToDB.FileName);
                    Image = new byte[ImageUploadToDB.PostedFile.ContentLength];
                    HttpPostedFile UploadedImage = ImageUploadToDB.PostedFile;
                    UploadedImage.InputStream.Read(Image, 0, (int)ImageUploadToDB.PostedFile.ContentLength);
                }
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString.ToString());
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select Cab_ID from cab where Cab_RegNo='" + CabDropDown.SelectedItem.ToString() + "'", conn);
                da.Fill(dt);

                int CabID = Convert.ToInt32(dt.Rows[0]["Cab_ID"]);
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AddDriver";
                    cmd.Parameters.Add(new SqlParameter("@pvchAction", SqlDbType.VarChar, 50));
                    cmd.Parameters.Add(new SqlParameter("@CabID", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@DriverName", SqlDbType.VarChar, 500));
                    cmd.Parameters.Add(new SqlParameter("@DriverPassword", SqlDbType.VarChar, 500));
                    cmd.Parameters.Add(new SqlParameter("@DriverEmail", SqlDbType.VarChar, 500));
                    cmd.Parameters.Add(new SqlParameter("@DriverPhNum", SqlDbType.VarChar, 500));
                    cmd.Parameters.Add(new SqlParameter("@DriverNIC", SqlDbType.VarChar, 500));
                    cmd.Parameters.Add(new SqlParameter("@DriverAddress", SqlDbType.VarChar, 500));
                    cmd.Parameters.Add(new SqlParameter("@DriverGender", SqlDbType.VarChar, 500));
                    cmd.Parameters.Add(new SqlParameter("@DriverAge", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@DriverPicture", SqlDbType.Image));
                    cmd.Parameters.Add("@pIntErrDescOut", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters["@pvchAction"].Value = "insert";
                    cmd.Parameters["@CabID"].Value = CabID;
                    cmd.Parameters["@DriverName"].Value = NameTextBox.Text;
                    cmd.Parameters["@DriverPassword"].Value = PasswordTextBox.Text;
                    cmd.Parameters["@DriverEmail"].Value = EmailTextBox.Text;
                    cmd.Parameters["@DriverPhNum"].Value = PhoneNumberTextBox.Text;
                    cmd.Parameters["@DriverNIC"].Value = NICTextBox.Text;
                    cmd.Parameters["@DriverAddress"].Value = AddressTextBox.Text;
                    cmd.Parameters["@DriverGender"].Value = GenderDropDown.SelectedItem.ToString();
                    cmd.Parameters["@DriverAge"].Value = Convert.ToInt32(AgeTextBox.Text);
                    cmd.Parameters["@DriverPicture"].Value = Image;
                    cmd.ExecuteNonQuery();
                    int retVal = (int)cmd.Parameters["@pIntErrDescOut"].Value;
                    
                }
                SqlCommand command = conn.CreateCommand();
                command.CommandText = "Update Cab set Cab_AssignedDriver='Yes' where Cab_ID=" + CabID;
                command.ExecuteNonQuery();
                conn.Close();
                WarningLabel.Text = "Driver Successfully Added";
                WarningLabel.Visible = true;
            }
            catch(Exception ex)
            {
                WarningLabel.Text = "Driver Registration Failed";
                WarningLabel.Visible = true;
            }

        }

        protected void AgeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}