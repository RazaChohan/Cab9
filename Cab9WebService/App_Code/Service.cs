using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    public string address;
    public static AutoResetEvent AddressCalculateWait = new AutoResetEvent(false);
    public static AutoResetEvent wait1 = new AutoResetEvent(false);
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}
    // For Distances list 
    public struct DistanceNode
    {
        public DistanceNode(double dist, string ID)
        {
            distance = dist;
            CabID = ID;
        }
        public double distance;
        public string CabID;
    }

    public string CustomerRegistrationRequest(string name, string password, string email, string phNum, string NIC, string address, string gender, string age)
    {
        try
        {
            SqlConnection conn = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            conn.Open();
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "insert into PendingCustomers ([PCustomer_Name],[PCustomer_Password] ,[PCustomer_Email],[PCustomer_PhNum],[PCustomer_NIC],[PCustomer_Address],[PCustomer_Gender],[PCustomer_Age]) values ('" + name + "', '" + password + "','" + email + "','" + phNum + "','" + NIC + "', '" + address + "','" + gender + "'," + age + ")";
            int result=command.ExecuteNonQuery();
            if(result>0)
            {
                return "Your registration request has been forwarded to the Administrator. It will be reviewed in one day. Thankyou!";
            }
            else
            {
                return "Error forwarding the request to Administrator";
            }
        }
        catch(Exception ex)
        {
            return ex.Message;
        }
    }
	
    public int CheckCustomerBookings(int CustomerID)
    {
        try
        {
            SqlConnection conn = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Booking where Customer_ID=" + CustomerID.ToString()+" and (Booking_Status ='Uncatered' OR Booking_Status='Being Catered')", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["Booking_ID"]);
            }
            else
            {
                return -1;
            }
        }
        catch (Exception ex)
        {
            return -2;  //Exception code
        }
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

    public async void CalculateAddress(string latitude, string longitude)
    {
        address = "";
        string url = "http://maps.googleapis.com/maps/api/geocode/json?latlng=" + latitude + "," + longitude + "&sensor=true";
        var client = new WebClient();

        string response = await client.DownloadStringTaskAsync(new Uri(url));
        JObject root = JObject.Parse(response);

        JArray items = (JArray)root["results"];
        JObject item;
        JToken jtoken;
        item = (JObject)items[0];
        JArray add_comp = (JArray)item["address_components"];
        string[] add_types = { "street_number", "route", "neighborhood", "locality", "city", "country" };
        foreach (var comp in add_comp)
        {
            if (add_types.Any(comp["types"].ToString().Contains))
            {
                address += comp["long_name"].ToString() + ", ";
                if (comp["types"].ToString().Contains("city") | comp["types"].ToString().Contains("country"))
                {
                    address += "\n";
                }
            }
        }
        AddressCalculateWait.Set();
    }

    //  Function to calculate and allot nearest cab for the booking according to booking source
    public int AllotNearestCab(string BookingSource)
    {
        try
        {
            SqlConnection connection = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("select CabLocations.* from CabLocations, Cab where CabLocations.Cab_ID=Cab.Cab_ID and Cab.Cab_Status='Available'",connection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if(dt.Rows.Count > 0)      // If there are any available cabs for the booking
            {
                string cabAddress = "";
                List<DistanceNode> DistancesList = new List<DistanceNode>();  //  To store distances from all the cabs

                foreach (DataRow row in dt.Rows)
                {
                    cabAddress = "";
                    CalculateAddress(row["Latitude"].ToString(), row["Longitude"].ToString());  //Converting LatLong to String address
                    AddressCalculateWait.WaitOne(); //Waiting until the address is calculated
                    cabAddress = address;   //Saving the calculated address locally
                    address = null;
                    DistancesList.Add(new DistanceNode(CalculateRoadDistance(cabAddress, BookingSource), row["Cab_ID"].ToString()));
                    AddressCalculateWait = new AutoResetEvent(false);

                }

                //Sorting List to find nearest cab
                List<DistanceNode> SortedList = DistancesList.OrderBy(x => x.distance).ToList();
                DistanceNode nearestCab = SortedList.ElementAt(0);

                connection.Close();
                // Return nearest cab ID
                return Convert.ToInt32(nearestCab.CabID);
            }
            else
            {
                return -1;
            }
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public string DriverNameforCabID(int CabID)
    {
        try
        {
            SqlConnection connection = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("select Driver_Name from Driver where Cab_ID=" + CabID.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Driver_Name"].ToString();
            }
            else
                return "Error";
        }
        catch(Exception ex)
        {
            return "Exception";
        }

    }

    public string CheckForDriverBooking(int CabID)
    {
        try
        {
            SqlConnection connection = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Booking where Cab_ID="+CabID.ToString()+" and Booking_Status = 'Uncatered' or Booking_Status='Being Catered'",connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string toReturn="No Booking";
            if(dt.Rows.Count>0)
            {
                toReturn = dt.Rows[0]["Booking_DateTime"].ToString() + "+" + dt.Rows[0]["Booking_Source"].ToString() + "+" + dt.Rows[0]["Booking_Destination"].ToString() + "+" + dt.Rows[0]["Booking_CabType"].ToString() + "+" + dt.Rows[0]["Booking_SourceLatitude"].ToString() + "+" + dt.Rows[0]["Booking_SourceLongitude"].ToString() + "+" + dt.Rows[0]["Booking_DestinationLatitude"].ToString() + "+" + dt.Rows[0]["Booking_DestinationLongitude"].ToString()+"+"+dt.Rows[0]["Booking_ID"].ToString();
            }
            connection.Close();
            return toReturn;
        }
        catch (Exception ex)
        {
            return "EXCEPTION::" + ex.Message;
        }
    }
    public int FindETA(String CabID, String BookingSource)
    {
        try
        {
            SqlConnection conn = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from CabLocations where Cab_ID=" + CabID,conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string CabLat = dt.Rows[0]["Latitude"].ToString();
            string CabLong = dt.Rows[0]["Longitude"].ToString();

            AddressCalculateWait = new AutoResetEvent(false);
            CalculateAddress(CabLat, CabLong);
            AddressCalculateWait.WaitOne();
            string CabAddress = address;
            Double Distance = CalculateRoadDistance(CabAddress, BookingSource);
            return Convert.ToInt32((Distance / 2) + 10); //Time in minutes to reach
            conn.Close();

        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public string RegistrationNumForCabID(int cabID)
    {
        SqlConnection conn = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter("Select Cab_RegNo from Cab where Cab_ID=" + cabID.ToString(), conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0]["Cab_RegNo"].ToString();
        }
        else
            return "No Cab Found";
        

    }

    public int FindDriverRating(int cabID)
    {
        SqlConnection conn = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter("Select Driver_Rating from Driver where Cab_ID=" + cabID.ToString(), conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        if (dt.Rows.Count > 0)
            return Convert.ToInt32(dt.Rows[0]["Driver_Rating"]);
        else
            return -1;
    }


    public string CabBooking(string BookingStatus, DateTime BookingDateTime, string BookingOrigin, string BookingDestination, string BookingCabType, string SourceLat, string SourceLong, string DestinationLat, string DestinationLong, string CustomerID)
    {

        try
        {
            //  Call calculate nearest cab
            int nearestCabID = AllotNearestCab(BookingOrigin);
            if(nearestCabID<0)
            {
                SqlConnection cntn = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
                SqlCommand cmnd = cntn.CreateCommand();
                cntn.Open();

                // Inserting the booking details in db
                cmnd.CommandText = "Insert into Booking (Customer_ID,Booking_Status, Booking_DateTime, Booking_Source, Booking_Destination, Booking_CabType, Booking_SourceLatitude, Booking_SourceLongitude, Booking_DestinationLatitude, Booking_DestinationLongitude, Booking_ReceiveTime)  VALUES (" + CustomerID + ", '" + BookingStatus + "',convert(datetime,'" + BookingDateTime.ToString("dd-MMM-yyy hh:mm:ss tt") + "',5), '" + BookingOrigin + "', '" + BookingDestination + "', '" + BookingCabType + "'," + SourceLat + "," + SourceLong + "," + DestinationLat + "," + DestinationLong + ",convert(datetime,'" + DateTime.Now.ToString("dd-MMM-yyy hh:mm:ss tt") + "',5))";
                int result = cmnd.ExecuteNonQuery();
                if (result > 0)
                {
                    cntn.Close();

                    string returnMessage = "Origin: " + BookingOrigin + "\nDestination: " + BookingDestination + "\nApproximate Distance: " + CalculateRoadDistance(BookingOrigin, BookingDestination) + "km\nEstimated Fare: PKR. " + CalculateFare(BookingOrigin, BookingDestination, BookingCabType, BookingDateTime).ToString() + "/-\nCab Type: " + BookingCabType + "\nBooking Time: " + BookingDateTime.ToString() + "\nBooking Status: Received!";
                    return returnMessage;
                }
                else
                {
                    cntn.Close();
                    return "Error storing request into database";
                }
            }
            // Query registration number against cab ID
            String CabRegistrationNumber = RegistrationNumForCabID(nearestCabID);

            // Finding driver rating to show to customer
            int DriverRating = FindDriverRating(nearestCabID);
            if(DriverRating<0)
            {
                return "Exception in Driver Rating";
            }

            SqlConnection connection = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select Booking_ID from Booking where Booking_DateTime = convert(datetime,'" + BookingDateTime.ToString("dd-MMM-yyy hh:mm:ss tt") + "',5) AND Booking_Source = '" + BookingOrigin + "' And Booking_Destination= '" + BookingDestination + "' AND Customer_ID=" + CustomerID.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                return "Your request with same preferences has already been booked";
            }
            else
            {
                SqlCommand cmd = connection.CreateCommand();

                if (nearestCabID != -1)  // If an available cab has been found for the booking and been alloted to it
                {
                    // For ETA
                    String DriverName = DriverNameforCabID(nearestCabID);
                    int ETA = FindETA(nearestCabID.ToString(), BookingOrigin);

                    // Setting cab status to unavailable
                    cmd.CommandText = "Update Cab set Cab_Status='Booked' where Cab_ID=" + nearestCabID.ToString();
                    cmd.ExecuteNonQuery();
                    cmd = connection.CreateCommand();

                    // Calculating approximate fare for the cab driver
                    int ApproximateFare = CalculateFare(BookingOrigin, BookingDestination, BookingCabType, BookingDateTime);

                    // Inserting the booking details in db
                    cmd.CommandText = "Insert into Booking (Cab_ID,Customer_ID,Booking_Status, Booking_DateTime, Booking_Source, Booking_Destination, Booking_CabType, Booking_SourceLatitude, Booking_SourceLongitude, Booking_DestinationLatitude, Booking_DestinationLongitude, Booking_ReceiveTime, Booking_Fare) VALUES (" + nearestCabID.ToString() + "," + CustomerID + ", 'Being Catered',convert(datetime,'" + BookingDateTime.ToString("dd-MMM-yyy hh:mm:ss tt") + "',5), '" + BookingOrigin + "', '" + BookingDestination + "', '" + BookingCabType + "'," + SourceLat + "," + SourceLong + "," + DestinationLat + "," + DestinationLong + ",convert(datetime,'" + DateTime.Now.ToString("dd-MMM-yyy hh:mm:ss tt") + "',5), " + ApproximateFare.ToString() + ")";
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        connection.Close();

                        string returnMessage = "Origin: " + BookingOrigin + "\nDestination: " + BookingDestination + "\nApproximate Distance: " + CalculateRoadDistance(BookingOrigin, BookingDestination) + "km\nEstimated Fare: PKR. " + ApproximateFare.ToString() + "/-\nCab Type: " + BookingCabType + "\nBooking Time: " + BookingDateTime.ToString() + "\nBooking Status: Being Catered!\nCab Registration Number: " + CabRegistrationNumber + "\nDriver Assigned: " + DriverName + "\nDriver Rating: " + DriverRating.ToString() + "\nETA for Cab: " + ETA.ToString() + " Minutes";
                        return returnMessage;
                    }
                    else
                    {
                        connection.Close();
                        return "Error storing request into database";
                    }
                    //return "Service Returned";
                }
                else
                {
                    // Inserting the booking details in db
                    cmd.CommandText = "Insert into Booking (Customer_ID,Booking_Status, Booking_DateTime, Booking_Source, Booking_Destination, Booking_CabType, Booking_SourceLatitude, Booking_SourceLongitude, Booking_DestinationLatitude, Booking_DestinationLongitude, Booking_ReceiveTime)  VALUES (" + CustomerID + ", '" + BookingStatus + "',convert(datetime,'" + BookingDateTime.ToString("dd-MMM-yyy hh:mm:ss tt") + "',5), '" + BookingOrigin + "', '" + BookingDestination + "', '" + BookingCabType + "'," + SourceLat + "," + SourceLong + "," + DestinationLat + "," + DestinationLong + ",convert(datetime,'" + DateTime.Now.ToString("dd-MMM-yyy hh:mm:ss tt") + "',5))";
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        connection.Close();

                        string returnMessage = "Origin: " + BookingOrigin + "\nDestination: " + BookingDestination + "\nApproximate Distance: " + CalculateRoadDistance(BookingOrigin, BookingDestination) + "km\nEstimated Fare: PKR. " + CalculateFare(BookingOrigin, BookingDestination, BookingCabType, BookingDateTime).ToString() + "/-\nCab Type: " + BookingCabType + "\nBooking Time: " + BookingDateTime.ToString() + "\nBooking Status: Received!";
                        return returnMessage;
                    }
                    else
                    {
                        connection.Close();
                        return "Error storing request into database";
                    }
                }
            }
            
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }

    public int AuthenticateCustomer(string username, string password)
    {
        try
        {
            SqlConnection connection = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            connection.Open();
            SqlDataAdapter daa = new SqlDataAdapter("select RCustomer_ID from RejectedCustomers where RCustomer_name='"+username+"' AND RCustomer_Password='"+password+"'", connection);
            DataTable dt2 = new DataTable();
            daa.Fill(dt2);
            if(dt2.Rows.Count>0)
            {
                return -2;  //Error code for rejected customer registrations
            }

            else
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Customer where Customer_Name='" + username + "' and Customer_Password='" + password + "'", connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                connection.Close();
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["Customer_ID"]);  //Allow the user to login
                }
                else
                    return -1;  //Error code for invalid username or password
            }


        }
        catch (Exception ex)
        {
            return -3;  //Error code for exception
        }
    }

    public int AuthenticateDriver(string username, string password)
    {
        try
        {
            SqlConnection connection = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Driver where Driver_Name='" + username + "' and Driver_Password='" + password + "'", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if(dt.Rows[0]["Driver_ActivationStatus"].ToString().Equals("Unactivated"))
                {
                    return -1;
                }
                else
                {
                    String CabID = dt.Rows[0]["Cab_ID"].ToString();
                    int DriverID = Convert.ToInt32(dt.Rows[0]["Driver_ID"]);
                    // Setting the cab status to live if unavailable
                    da = new SqlDataAdapter("select Cab_Status from Cab where Cab_ID=" + CabID, connection);
                    dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows[0]["Cab_Status"].ToString().Equals("Unavailable"))
                    {
                        // Set the cab status to available
                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = "Update Cab set Cab_Status='Available' where Cab_ID=" + CabID;
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                    return DriverID;
                }                
                
            }
            else
            {
                connection.Close();
                return -1;
            }
                


        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public string UpdateLocation(string latitude, string longitude, int CabID)
    {
        try
        {
            SqlConnection connection = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select * from CabLocations where Cab_ID=" + CabID.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt); 
            
            if(dt.Rows.Count>0) //The record exists so location just needs to be updated
            {
                command.CommandText = "Update CabLocations set Latitude=" + latitude + ", Longitude=" + longitude + " where Cab_ID=" + CabID.ToString();
                int result = command.ExecuteNonQuery();
                connection.Close();
                if (result > 0)
                {
                    return "Success";
                }
                else
                    return "Unsuccessful";

            }
            else
            {
                command.CommandText = "Insert into CabLocations (Cab_ID,Latitude,Longitude) VALUES("+CabID.ToString()+"," + latitude + "," + longitude + ")";
                int result = command.ExecuteNonQuery();
                connection.Close();
                if (result > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Unsuccessful";
                }
            }
            
            


        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
    }

    public int CabIDforDriver(int DriverID)
    {
        try
        {
            SqlConnection connection = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select Cab_ID from Driver where Driver_ID=" + DriverID ,connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["Cab_ID"]);
            }
            else
                return -1;

        }
        catch(Exception ex)
        {
            return -1;
        }
    }
    public String AddresstoCoordinates(String location)
    {
        var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(location));

        var request = WebRequest.Create(requestUri);
        var response = request.GetResponse();
        var xdoc = XDocument.Load(response.GetResponseStream());

        var result = xdoc.Element("GeocodeResponse").Element("result");
        var locationElement = result.Element("geometry").Element("location");
        var lat = locationElement.Element("lat");
        var lng = locationElement.Element("lng");

        String stringLatitude;
        String stringLongitude;
        // Extracting concrete latitude value
        String[] token = lat.ToString().Split(new char[] { '>' });
        String[] token2 = token[1].Split(new char[] { '<' });
        stringLatitude = token2[0];

        // Extracting concrete longitude value
        token = lng.ToString().Split(new char[] { '>' });
        token2 = token[1].Split(new char[] { '<' });
        stringLongitude = token2[0];

        String Coordinates = stringLatitude + ":" + stringLongitude;
        return Coordinates;

    }

    public bool MakeAvailableIfReached(int CabID, string DestinationLat, string DestinationLong, int BookingID)
    {
        SqlConnection conn = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter("Select * from CabLocations where Cab_ID=" + CabID.ToString(), conn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if((dt.Rows[0]["Latitude"].ToString() == DestinationLat) && (dt.Rows[0]["Longitude"].ToString()==DestinationLong))
        {
            // Set the cab status to free and booking status to catered
            SqlCommand command = conn.CreateCommand();
            command.CommandText = "Update Booking Set Booking_Status = 'Catered' where Booking_ID= " + BookingID.ToString();
            command.ExecuteNonQuery();

            command.CommandText = "Update Cab set Cab_Status ='Available' where Cab_ID=" + CabID.ToString();
            command.ExecuteNonQuery();

            return true;
        }
        else
        {
            // Still being catered
            return false;
        }
    }
    public DateTime GetBookingTime(int BookingID)
    {
        SqlConnection conn = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter("Select Booking_ReceiveTime from Booking where Booking_ID=" + BookingID.ToString(), conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        
        conn.Close();
        return Convert.ToDateTime(dt.Rows[0]["Booking_ReceiveTime"].ToString());
    }

    public String CancelBooking(int BookingID, string time, string BookingStatus, int ApproximateFare)
    {
        int TimeElapsed = Convert.ToInt32(time);
        if(TimeElapsed > 10 && BookingStatus.Contains("Being Catered"))
        {
            // Have to inform the driver and charge the customer
 
            SqlConnection conn = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            conn.Open();
            
            //Getting customer ID for this booking
            SqlDataAdapter da = new SqlDataAdapter("select Customer_ID from Booking where Booking_ID="+BookingID,conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int customerID = Convert.ToInt32(dt.Rows[0]["Customer_ID"]);

            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "Update Booking set Booking_Status='Cancelled_Unnotified' where Booking_ID=" + BookingID;
            int result = comm.ExecuteNonQuery();
            if (result > 0)
            {
                float duePayment = ApproximateFare/2;

                comm.CommandText = "Insert into CustomerDuePayments (Customer_ID, DuePayment) VALUES(" + customerID.ToString() + ", " + duePayment.ToString() + ")";
                comm.ExecuteNonQuery();
                return "Booking Cancelled. Due Payment: PKR. "+duePayment.ToString()+"/-";
            }
            return "No booking found";
        }
        else if(TimeElapsed < 10 && BookingStatus.Contains("Being Catered"))
        {
            // Have to inform the driver but dont charge customer
            SqlConnection conn = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "Update Booking set Booking_Status='Cancelled_Unnotified' where Booking_ID=" + BookingID;
            int result = comm.ExecuteNonQuery();
            return "Booking Cancelled";
        }
        else
        {
            // Neither have to inform the driver nor charge the customer
            SqlConnection conn = new SqlConnection("Data Source = WALEED-PC; Inital Catalog = cab9; Integrated Security=True;");
            conn.Open();
            SqlCommand comm = conn.CreateCommand();
            comm.CommandText = "Updated Booking set Booking_Status = 'Cancelled' where Booking_ID=" + BookingID;
            comm.ExecuteNonQuery();
            return "Booking Cancelled";

        }
        
    }

    public int CheckForDriverCancelledBookings(int CabID)
    {
        // Checking for driver's unnotified bookings to generate toast
        SqlConnection conn = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter("select Booking_ID From Booking where Cab_ID=" + CabID.ToString() + " and Booking_Status='Cancelled_Unnotified'", conn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if(dt.Rows.Count > 0 )
        {
            return Convert.ToInt32(dt.Rows[0]["Booking_ID"]);
        }
        else
        {
            return -1;
        }
    }

    public String DetailsForCancelledBooking(int BookingID)
    {
        SqlConnection conn = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
        conn.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * From Booking where Booking_ID=" + BookingID.ToString(), conn);
        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0]["Booking_Source"].ToString() +"+"+ dt.Rows[0]["Booking_Destination"].ToString() +"+"+dt.Rows[0]["Booking_DateTime"].ToString();
        }
        else
        {
            return "No booking corresponding to Booking ID: "+BookingID.ToString();
        }
    }

    public int UpdateBookingAndCabStatus(int BookingID, int CabID)
    {
        SqlConnection conn = new SqlConnection("Data Source=WALEED-PC; Initial Catalog=Cab9; Integrated Security=True;");
        conn.Open();
        SqlCommand command = conn.CreateCommand();
        command.CommandText = "Update Booking set Booking_Status='Cancelled' where Booking_ID=" + BookingID.ToString();
        command.ExecuteNonQuery();

        command.CommandText = "Update Cab set Cab_Status='Available' where CabID=" + CabID.ToString();
        command.ExecuteNonQuery();

        return 0;
    }
}
