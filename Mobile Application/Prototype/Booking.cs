using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Prototype
{
    public class Booking
    {
        public string BookingOrigin;
        public string BookingDestination;
        public DateTime BookingDateTime;
        public string BookingStatus;
        public string BookingCabType;
        //public static Geoposition SourceLatLong;
        public static string DestinationLat;
        public static string DestinationLong;
        public static string SourceLat;
        public static string SourceLong;
        //public static Geoposition DestinationLatLong;

        public Booking(string origin, string destination, DateTime dateTime, string type)
        {
            this.BookingOrigin = origin;
            this.BookingDestination = destination;
            this.BookingDateTime = dateTime;
            this.BookingStatus = "Uncatered";
            this.BookingCabType = type;
        }
    }
}
