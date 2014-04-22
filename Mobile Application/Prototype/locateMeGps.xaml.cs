using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using Windows.Devices.Geolocation;
using Microsoft.Phone.Maps.Services;
using Newtonsoft.Json.Linq;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;

namespace Prototype
{
    public partial class locateMeGps : PhoneApplicationPage
    {
        public Geoposition gPos = null;
        public bool positionLoaded = false;
        
        //CabBookingAttributes bookingData = new CabBookingAttributes();
        public double dlat = 0;
        public double dlong = 0;
        MapLayer pushPinLayer = new MapLayer();
    
        public locateMeGps()
        {
            InitializeComponent();
            street.Visibility = Visibility.Visible;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (IsolatedStorageSettings.ApplicationSettings.Contains("LocationConsent"))
            {
                // User has opted in or out of Location
                return;
            }
            else
            {
                MessageBoxResult result =
                    MessageBox.Show("This App accesses your phone's location. Is that Ok?",
                    "Location",
                    MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                    IsolatedStorageSettings.ApplicationSettings["LocationConsent"] = true;
                }
                else
                {
                    IsolatedStorageSettings.ApplicationSettings["LocationConsent"] = false;
                }

                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }

        private async void LocateMEDone(object sender, EventArgs e)
        {
            MessageBoxResult result =
                MessageBox.Show("Confirm GPS Location?",
                "",
                MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                NavigationService.Navigate(new Uri("/BookACab.xaml?goto=1", UriKind.Relative));
            }
            else
            {
            }
        }

        private async void AskHelp(object sender, EventArgs e)
        {
            string message="";
            message = "Tap Hold For 3 to Select Location on Map\nOk Button -> Confirm Location. \nMessage Button -> Send Location Through Text Message. \nLocation Button -> Get Current Location Through GPS.";
            MessageBox.Show(message);   
        }
       

        private async void Locate_Click(object sender, EventArgs e)
        {
            positionLoaded = false;
            if ((bool)IsolatedStorageSettings.ApplicationSettings["LocationConsent"] != true)
            {
                // The user has opted out of Location.
                return;
            }

            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 10;

            try
            {
                gPos = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromSeconds(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );


                dlat = gPos.Coordinate.Latitude;
                dlong = gPos.Coordinate.Longitude;
                LatitudeTextBlock.Text = "Latitude:  " + gPos.Coordinate.Latitude.ToString("0.000000");     //geoposition.Coordinate.Latitude.ToString("0.00"); //
                LongitudeTextBlock.Text = "Longitude: " + gPos.Coordinate.Longitude.ToString("0.000000");   //geoposition.Coordinate.Longitude.ToString("0.00"); //

                //Storing in static variables for access in other pages of app
                Booking.SourceLat = gPos.Coordinate.Latitude.ToString("0.000000");
                Booking.SourceLong = gPos.Coordinate.Longitude.ToString("0.000000");

                ReverseGeocodeQuery getAddress = new ReverseGeocodeQuery();
                
                GeoCoordinate geo = new GeoCoordinate();
                geo.Latitude = gPos.Coordinate.Latitude;
                geo.Longitude = gPos.Coordinate.Longitude;
                googlemap.Center = geo;
                googlemap.ZoomLevel = 16;

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

                /////////////////////////////////////////////////////////////////////////////////////////
                // Address From Google
                

                /////////////////////////////////////////////////////////////End Google Code

                (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = true;
                (ApplicationBar.Buttons[1] as ApplicationBarIconButton).IsEnabled = true;
                (ApplicationBar.Buttons[2] as ApplicationBarIconButton).IsEnabled = true;
                (ApplicationBar.Buttons[3] as ApplicationBarIconButton).IsEnabled = true;

                zzoom.IsEnabled = true;
                positionLoaded = true;

                Microsoft.Phone.Controls.Maps.Pushpin new_pushpin = new Microsoft.Phone.Controls.Maps.Pushpin();
                new_pushpin.Location = geo;

                googlemap.Children.Remove(pushPinLayer);
                pushPinLayer = new MapLayer();

                
                new_pushpin.Content = address;
                Address.Text = address;
                new_pushpin.Visibility = Visibility.Visible;

                googlemap.Children.Add(pushPinLayer);
                pushPinLayer.AddChild(new_pushpin, geo, PositionOrigin.BottomLeft);

                MainPage.bookingData.set_current_location_attributes(address,geo);
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x80004004)
                {
                    // the application does not have the right capability or the location master switch is off
                    MessageBox.Show("location  is disabled in phone settings");
                }
                //else
                {
                    // something else happened acquring the location
                }
            }

        }

        private void Email_Click(object sender, EventArgs e)
        {
            EmailComposeTask newmail = new EmailComposeTask();
            newmail.Body = LatitudeTextBlock.Text + "\n" + LongitudeTextBlock.Text;
            newmail.Show();
        }

        private void Sms_Click_1(object sender, EventArgs e)
        {
            SmsComposeTask newsms = new SmsComposeTask();
            newsms.Body = LatitudeTextBlock.Text + "\n" + LongitudeTextBlock.Text; ;// +"\n " + myadd.ToString();
            newsms.Show();
        }

        private void zzoom_ValueChanged(object sender, Telerik.Windows.Controls.ValueChangedEventArgs<double> e)
        {
            if (positionLoaded)
            {
                 googlemap.ZoomLevel=zzoom.Value;
            }  
        }

        private async void mapOnhold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            googlemap.Children.Remove(pushPinLayer);
            pushPinLayer = new MapLayer();
            
            try
            {
                Point p = e.GetPosition(this.googlemap);
                GeoCoordinate geo = new GeoCoordinate();
                geo = googlemap.ViewportPointToLocation(p);

                Microsoft.Phone.Controls.Maps.Pushpin new_pushpin = new Microsoft.Phone.Controls.Maps.Pushpin();
                new_pushpin.Location = geo;

                // Storing in static variables
                Booking.SourceLat = geo.Latitude.ToString("0.000000");
                Booking.SourceLong = geo.Longitude.ToString("0.000000");

                // Translating geocoordinates into address
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

                new_pushpin.Content = address;
                Address.Text = address;
                new_pushpin.Visibility = Visibility.Visible;

               // gPos.Coordinate.Latitude = geo.Latitude;
               // gPos.Coordinate.Longitude=geo.Longitude;
                googlemap.Children.Add(pushPinLayer);
                pushPinLayer.AddChild(new_pushpin, geo, PositionOrigin.BottomLeft);
                MainPage.bookingData.set_current_location_attributes(address, geo);

                LatitudeTextBlock.Text = "Latitude:  " + geo.Latitude.ToString("0.000000"); //geoposition.Coordinate.Latitude.ToString("0.00"); //
                LongitudeTextBlock.Text = "Longitude: " + geo.Longitude.ToString("0.000000");//geoposition.Coordinate.Longitude.ToString("0.00"); //
                
            }
            catch (Exception ed)
            {
                MessageBox.Show("Unable to Get Coordinates of Current Point");
            }
        }
    }
}