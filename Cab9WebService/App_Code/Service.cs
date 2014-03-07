using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

    public double CalculateRoadDistance(string Origin, string Destination)
    {
        // ********************************** Road distance calculation code *****************************************************************
        XmlDocument ApiReturnedXML = new XmlDocument();
        ApiReturnedXML.Load("https://maps.googleapis.com/maps/api/directions/xml?origin="+Origin+"&destination="+Destination+"&OK&sensor=false&optimizeWaypoints=true");
        XmlNodeList addlst = ApiReturnedXML.SelectNodes("DirectionsResponse/route/leg/distance");
        String Distances = "";

        foreach (XmlNode Step in addlst)
        {
            Distances = Distances + Step["text"].InnerText.ToString() + ",  ";
        }
        string[] token = Distances.Split(new string[] { " " }, StringSplitOptions.None);  // Parsing the seperator from unit (m/km)
        double DistanceInDoube = Convert.ToDouble(token[0]);    //Getting a double value for fare computation

        return DistanceInDoube;
        // ***********************************************************************************************************************************

    }

    public int CalculateFare(string Origin, string Destination, string cabType, DateTime Time)
    {
        double roadDistance = CalculateRoadDistance(Origin, Destination);
        if (cabType == "Economy")
        {
            // If between 1 pm to 3pm, charge more

            DateTime OnePM = DateTime.Parse("2012/12/12 13:00:00.000");
            DateTime ThreePM = DateTime.Parse("2012/12/12 15:00:00.000");
            DateTime FivePM = DateTime.Parse("2012/12/12 17:00:00.000");
            DateTime SixThirtyPM = DateTime.Parse("2012/12/12 18:30:00.000");
           

            if ((TimeSpan.Compare(OnePM.TimeOfDay, Time.TimeOfDay) == 0 || TimeSpan.Compare(OnePM.TimeOfDay, Time.TimeOfDay) == 1) && (TimeSpan.Compare(ThreePM.TimeOfDay, Time.TimeOfDay) == 0 || TimeSpan.Compare(ThreePM.TimeOfDay, Time.TimeOfDay) == -1))
            {
                return (int)(roadDistance * 30);
            }
            else if((TimeSpan.Compare(FivePM.TimeOfDay, Time.TimeOfDay) == 0 || TimeSpan.Compare(FivePM.TimeOfDay, Time.TimeOfDay) == 1) && (TimeSpan.Compare(SixThirtyPM.TimeOfDay, Time.TimeOfDay) == 0 || TimeSpan.Compare(SixThirtyPM.TimeOfDay, Time.TimeOfDay) == -1))       //If between 5pm to 6:30pm, charge more
            {
                return (int)(roadDistance * 30);
            }
            else
                return (int)(roadDistance * 26);
        }
        else
        {
            // If between 1 pm to 3pm, charge more

            DateTime OnePM = DateTime.Parse("2012/12/12 13:00:00.000");
            DateTime ThreePM = DateTime.Parse("2012/12/12 15:00:00.000");
            DateTime FivePM = DateTime.Parse("2012/12/12 17:00:00.000");
            DateTime SixThirtyPM = DateTime.Parse("2012/12/12 18:30:00.000");


            if ((TimeSpan.Compare(OnePM.TimeOfDay, Time.TimeOfDay) == 0 || TimeSpan.Compare(OnePM.TimeOfDay, Time.TimeOfDay) == 1) && (TimeSpan.Compare(ThreePM.TimeOfDay, Time.TimeOfDay) == 0 || TimeSpan.Compare(ThreePM.TimeOfDay, Time.TimeOfDay) == -1))
            {
                return (int)(roadDistance * 36);
            }
            else if ((TimeSpan.Compare(FivePM.TimeOfDay, Time.TimeOfDay) == 0 || TimeSpan.Compare(FivePM.TimeOfDay, Time.TimeOfDay) == 1) && (TimeSpan.Compare(SixThirtyPM.TimeOfDay, Time.TimeOfDay) == 0 || TimeSpan.Compare(SixThirtyPM.TimeOfDay, Time.TimeOfDay) == -1))       //If between 5pm to 6:30pm, charge more
            {
                return (int)(roadDistance * 36);
            }
            else
                return (int)(roadDistance * 32);
        }
            
    }

    public string CabBooking(string BookingStatus, DateTime BookingDateTime, string BookingOrigin, string BookingDestination, string BookingCabType)
    {

        try
        {
            SqlConnection connection = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "Insert into Booking (Booking_Status, Booking_DateTime, Booking_Source, Booking_Destination, Booking_CabType) VALUES ('" + BookingStatus + "',convert(datetime,'" + BookingDateTime.ToString("dd-MMM-yyy hh:mm:ss tt") + "',5), '"+BookingOrigin+"', '"+BookingDestination+"', '"+BookingCabType+"')";
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                connection.Close();
                string returnMessage = "Origin: " + BookingOrigin + "\nDestination: " + BookingDestination +"\nApproximate Distance: "+CalculateRoadDistance(BookingOrigin,BookingDestination)+ "km\nEstimated Fare: PKR. " + CalculateFare(BookingOrigin,BookingDestination,BookingCabType,BookingDateTime).ToString() +"/-\nCab Type: "+BookingCabType+"\nBooking Time: "+BookingDateTime.ToString()+"\nBooking Status: Received!";
                return returnMessage;
            }
            else
            {
                connection.Close();
                return "Error storing request into database";
            }
            
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }

    public string AuthenticateCustomer(string username, string password)
    {
        try
        {
            SqlConnection connection = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Customer where Customer_Name='" + username + "' and Customer_Password='" + password + "'", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            if (dt.Rows.Count > 0)
            {
                return "Allow";
            }
            else
                return "Reject";


        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }

    public string AuthenticateDriver(string username, string password)
    {
        try
        {
            SqlConnection connection = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Driver where Driver_Name='" + username + "' and Driver_Password='" + password + "'", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            if (dt.Rows.Count > 0)
            {
                return "Allow";
            }
            else
                return "Reject";


        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }
}
