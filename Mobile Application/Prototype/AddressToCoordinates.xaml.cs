using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Device.Location;
using Newtonsoft.Json.Linq;

namespace Prototype
{
    public partial class AddressToCoordinates : PhoneApplicationPage
    {
        public AddressToCoordinates()
        {
            InitializeComponent();
        }

        private async void appBar_OnChk(object sender, EventArgs e)
        {
            try
            {
                GeoCoordinate geo = new GeoCoordinate();
                getCoordinatesFromLocation geocoding = new getCoordinatesFromLocation();
                string location = "";
                location = addressLocationtxt + "+" + cityLocationtxt + "+" + "Pakistan";
                geo = geocoding.corrdinatioes(location);
                if (geo == null)
                {
                    MessageBox.Show("Unable to Locate Your Desired Location..");
                }
                else
                {
                    //string url = "http://maps.googleapis.com/maps/api/geocode/json?latlng=" + geo.Latitude + "," + geo.Longitude + "&sensor=true";
                    //var client = new WebClient();

                    //string response = await client.DownloadStringTaskAsync(new Uri(url));
                    //JObject root = JObject.Parse(response);

                    //JArray items = (JArray)root["results"];
                    //JObject item;
                    //JToken jtoken;
                    //item = (JObject)items[0];
                    //JArray add_comp = (JArray)item["address_components"];
                    //string address = null;
                    //string[] add_types = { "street_number", "route", "neighborhood", "locality", "city", "country" };
                    //foreach (var comp in add_comp)
                    //{
                    //    if (add_types.Any(comp["types"].ToString().Contains))
                    //    {
                    //        address += comp["long_name"].ToString() + ", ";
                    //        if (comp["types"].ToString().Contains("city") | comp["types"].ToString().Contains("country"))
                    //        {
                    //            address += "\n";
                    //        }
                    //    }
                    //}
                    MainPage.bookingData.set_destination_attributes(null, geo);
                    MessageBox.Show(geo.Latitude.ToString());
                    MessageBox.Show(geo.Longitude.ToString());
                    NavigationService.Navigate(new Uri("/SelectDestination.xaml", UriKind.Relative));
 
                }
            }
            catch (Exception ed)
            {
                MessageBox.Show(ed.ToString());
            }
        }

        private void appBar_OnCancel(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SelectDestination.xaml", UriKind.Relative));
        }

    }
    
   
}