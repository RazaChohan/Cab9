using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using Newtonsoft.Json.Linq;
using Microsoft.Phone.Controls.Maps;
using System.Globalization;
using System.Device.Location;


namespace _110012_SQA_Assignment_1
{
    class locateMeGps
    {
        public bool positionLoaded = false;
        private string Coordinates_address = null;
        public double dlat = 0;
        public double dlong = 0;
     
        public locateMeGps()
        {

        }
        
        public String CoordinatesToLocation(float lat, float lng)
        {
            Task<String> abc = CoordinatesToLocationConverter(lat, lng);
            Coordinates_address=Convert.ToString(abc.Result);
            return Coordinates_address;
        }

        //Function to be Tested/////////
        private async Task<String> CoordinatesToLocationConverter(float lat,float lng)
        {
            GeoCoordinate geo = new GeoCoordinate(lat,lng);

            string url = "http://maps.googleapis.com/maps/api/geocode/json?latlng=" + geo.Latitude + "," + geo.Longitude + "&sensor=true";
            var client = new WebClient();

            string response = await client.DownloadStringTaskAsync(new Uri(url));
            JObject root = JObject.Parse(response);

            JArray items = (JArray)root["results"];
            JObject item;
            JToken jtoken;
            item = (JObject)items[0];
            JArray add_comp = (JArray)item["address_components"];
            string address = null;
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
            return address;
        }

    }
}
