using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	[OperationContract]
	string GetData(int value);

	[OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);

    [OperationContract]
    double CalculateRoadDistance(string Origin, string Destination);

    [OperationContract]
    string CabBooking(string BookingStatus, DateTime BookingDateTime, string BookingOrigin, string BookingDestination, string BookingCabType, string SourceLat, string SourceLong, string DestinationLat, string DestinationLong, string CustomerID);

    [OperationContract]
    int AuthenticateCustomer(string username, string password);

    [OperationContract]
    int AuthenticateDriver(string username, string password);

    [OperationContract]
    string CustomerRegistrationRequest(string name, string password, string email, string phNum, string NIC, string address, string gender, string age);

    [OperationContract]
    string UpdateLocation(string latitude, string longitude, int CabID);

    [OperationContract]
    int CabIDforDriver(int DriverID);

    [OperationContract]
    string CheckForDriverBooking(int CabID);

    [OperationContract]
    String AddresstoCoordinates(String location);

    [OperationContract]
    bool MakeAvailableIfReached(int CabID, string DestinationLat, string DestinationLong, int BookingID);

    [OperationContract]
    int CheckCustomerBookings(int CustomerID);

    [OperationContract]
    DateTime GetBookingTime(int BookingID);

    [OperationContract]
    String CancelBooking(int BookingID, String time, string BookingStatus, int ApproximateFare);
    //[OperationContract]
    //int DetermineNearestCab(string latitude, string longitude);
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}
}
