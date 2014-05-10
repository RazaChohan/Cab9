using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
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
                SqlConnection conn = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
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

        private void SendActivationEmail(int userId)
        {
            string constr = ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString;
            string activationCode = Guid.NewGuid().ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO DriverActivation VALUES(@Driver_ID, @ActivationCode)"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Driver_ID", userId);
                        cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            try
            {
                using (MailMessage mm = new MailMessage("cab9company@gmail.com",EmailTextBox.Text))
                {
                    mm.Subject = "Account Activation";
                    string body = "<br /><br />Dear " + NameTextBox.Text.Trim() + ",";
                    body += "<br /><br />Welcome to Cab9! We're glad to have you with us.";
                    body += "<br /><br />Please Confirm Your Driver Account Corresponding to following credentials: ";
                    body += "<br /><br />User ID:" + userId + "";
                    body += "<br /><br />Password:" + PasswordTextBox.Text.Trim() + "";
                    body += "<br /><br />";
                    body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("driverreg.aspx", "Driver_Activation.aspx?ActivationCode=" + activationCode) + "'>Click here to activate your account.</a>";
                    body += "<br /><br />Thank You.";
                    body += "<br /><br />";
                    body += "<br /><br />Regards,";
                    body += "<br /><br />Mr. Muhammad Raza";
                    body += "<br /><br />CEO- NitRoSol Pvt. Ltd .";
                    mm.Body = body;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("cab9company@gmail.com", "cab9.cmp");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("F:\\test.txt", ex.Message);
                Response.Write("<script>alert(" + ex.Message + ")</script>");
            }
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            if (Regex.Match(EmailTextBox.Text, "([a-zA-Z0-9])+@([a-zA-Z0-9])+.com.pk").Success || Regex.Match(EmailTextBox.Text, "([a-zA-Z0-9])+@([a-zA-Z0-9])+.com").Success || Regex.Match(EmailTextBox.Text, "([a-zA-Z0-9])+@([a-zA-Z0-9])+.edu.pk").Success || Regex.Match(EmailTextBox.Text, "([a-zA-Z0-9])+@([a-zA-Z0-9])+.org").Success || Regex.Match(EmailTextBox.Text, "([a-zA-Z0-9])+@([a-zA-Z0-9])+.pk").Success)
            {

                if ((Regex.Match(PhoneNumberTextBox.Text, "([0-9]){10}").Success || Regex.Match(PhoneNumberTextBox.Text, "([0-9]){11}").Success) && (PhoneNumberTextBox.Text.Length==10 || PhoneNumberTextBox.Text.Length==11))
                {
                    if(Regex.Match(NICTextBox.Text,"([0-9]){5}-([0-9]){7}-([0-9])").Success)
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

                            SqlConnection conn = new SqlConnection(@"Data Source=WALEED-PC;Initial Catalog=Cab9;Integrated Security=True");
                            conn.Open();
                            DataTable dt = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter("Select Cab_ID from cab where Cab_RegNo='" + CabDropDown.SelectedItem.ToString() + "'", conn);
                            da.Fill(dt);

                            int CabID = Convert.ToInt32(dt.Rows[0]["Cab_ID"]);


                            SqlDataAdapter Adapter = new SqlDataAdapter("Select * from CabLocations where Cab_ID=" + CabID.ToString(), conn);
                            DataTable Table = new DataTable();
                            Adapter.Fill(Table);
                            SqlCommand comm = conn.CreateCommand();

                            if (dt.Rows.Count > 0) //The record exists so location just needs to be updated
                            {
                                comm.CommandText = "Update CabLocations set Latitude='33.729388', Longitude='73.093146' where Cab_ID=" + CabID.ToString();
                                int result = comm.ExecuteNonQuery();
                                conn.Close();

                            }
                            else
                            {
                                // Setting default latlongs of the cab and setting default status to unavaiable until the driver changes it himself

                                comm.CommandText = "Insert into CabLocations (Cab_ID, Latitude, Longitude) VALUES(" + CabID + ",'33.729388','73.093146')";
                                comm.ExecuteNonQuery();
                            }

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
                                cmd.Parameters.Add(new SqlParameter("@DriverDOB", SqlDbType.Date));
                                cmd.Parameters.Add(new SqlParameter("@DriverPicture", SqlDbType.Image));
                                cmd.Parameters.Add(new SqlParameter("@DriverActivation", SqlDbType.VarChar, 500));
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
                                cmd.Parameters["@DriverDOB"].Value = DOB.SelectedDate;
                                cmd.Parameters["@DriverPicture"].Value = Image;
                                cmd.Parameters["@DriverActivation"].Value = "Unactivated";
                                cmd.ExecuteNonQuery();
                                int retVal = (int)cmd.Parameters["@pIntErrDescOut"].Value;

                            }
                            SqlCommand command = conn.CreateCommand();
                            command.CommandText = "Update Cab set Cab_AssignedDriver='Yes' where Cab_ID=" + CabID;
                            command.ExecuteNonQuery();

                            // Getting ID for the added driver
                            //da = new SqlDataAdapter("Select Driver_ID from Driver where Driver_Name='"+NameTextBox.Text+"' and driver_email = '"+EmailTextBox.Text+"' and driver_PhNum = '"+PhoneNumberTextBox.Text+"' and Driver_NIC='"+NICTextBox.Text+"'", conn);
                            //dt = new DataTable();
                            //da.Fill(dt);


                            //String DriverID = dt.Rows[0]["Driver_ID"].ToString();
                            //SendActivationEmail(Convert.ToInt32(DriverID));

                            conn.Close();
                            WarningLabel.Text = "Driver Successfully Added";
                            WarningLabel.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            WarningLabel.Text = "Driver Registration Failed";
                            WarningLabel.Visible = true;
                        }
                    }
                    else
                    {
                        WarningLabel.Text = "ERROR! Enter NIC in correct format.<br/>Correct format: *****-*******-*";
                        WarningLabel.Visible = true;
                    }
                }
                else
                {
                    WarningLabel.Text = "ERROR! Incorrect phone number format!<br/>Mobile: 0**********, Landline: 0**********";
                    WarningLabel.Visible = true;
                }
            }
            else
            {
                WarningLabel.Text = "ERROR! Email should be of the format xxx@xxxx.com";
                WarningLabel.Visible = true;
            }
            
            

        }

        protected void AgeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}