using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;
using System.Device.Location;
using Microsoft.Phone.Maps.Controls;
using System.Device.Location; // Provides the GeoCoordinate class.
using Windows.Devices.Geolocation; //Provides the Geocoordinate class.
using System.Windows.Media;
using System.Windows.Shapes;

namespace Prototype
{
    public partial class EmergencyServices : PhoneApplicationPage
    {
        public EmergencyServices()
        {
            InitializeComponent();
            ShowMyLocationOnTheMap();

        }
        private async void ShowMyLocationOnTheMap()
        {
            var geoLocator = new Geolocator();
            var geoloc = await geoLocator.GetGeopositionAsync();
            Geolocator myGeolocator = new Geolocator();
            Geoposition myGeoposition = await myGeolocator.GetGeopositionAsync();
            Geocoordinate myGeocoordinate = myGeoposition.Coordinate;
            GeoCoordinate myGeoCoordinate = CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);
            this.mapWithMyLocation.Center = myGeoCoordinate;
            this.mapWithMyLocation.ZoomLevel = 2;


            Ellipse myCircle = new Ellipse();
            myCircle.Fill = new SolidColorBrush(Colors.Blue);
            myCircle.Height = 20;
            myCircle.Width = 20;
            myCircle.Opacity = 50;

            MapOverlay myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = myCircle;
            myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
            myLocationOverlay.GeoCoordinate = myGeoCoordinate;
            MapLayer myLocationLayer = new MapLayer();
            myLocationLayer.Add(myLocationOverlay);

            mapWithMyLocation.Layers.Add(myLocationLayer);
        }


        private void appBarOkButton_Click(object sender, EventArgs e)
        {
            if (currentLocation.Text == "")
            {
                MessageBox.Show("First Acquire Current Location");
                return;
            }
            MessageBox.Show("Emergency Service Request Sent");
            NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }

        private void appBarCancelButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            currentLocation.Text = "Default Location";
        }
    }
}