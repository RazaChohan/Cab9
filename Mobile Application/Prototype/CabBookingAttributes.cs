using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Prototype
{
    public class CabBookingAttributes
    {
        public bool isLocGet = false;
        public bool isDesSet = false;
        public GeoCoordinate current_location = new GeoCoordinate();
        public string current_location_address;
        public string Date;
        public string Time;
        public string CabType;

        public GeoCoordinate desitnation_location = new GeoCoordinate();
        public string destination_location_address;

        public CabBookingAttributes()
        {
        isLocGet = false;
        isDesSet = false;
        current_location = new GeoCoordinate();
        current_location_address="";
        desitnation_location = new GeoCoordinate();
        destination_location_address="";
        }

        public void set_current_location_attributes(string address,GeoCoordinate coordinates)
        {
            current_location_address = address;
            current_location = coordinates;
            isLocGet = true;
        }

        public void set_destination_attributes(string address, GeoCoordinate coordinates)
        {
            destination_location_address = address;
            desitnation_location = coordinates;
            isDesSet = true;
 
        }
        public void SetPreferences(string date, string time, string cabType)
        {
            this.Date = date;
            this.Time = time;
            this.CabType = cabType;
        }


    }
}
