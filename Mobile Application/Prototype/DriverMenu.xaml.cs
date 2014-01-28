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
using System.Windows.Shapes;
using System.Windows.Media;
using Microsoft.Phone.Maps.Controls;

namespace Prototype
{
    public partial class DriverMenu : PhoneApplicationPage
    {
        public DriverMenu()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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



        private void appBar_OnSave(object sender, EventArgs e)
        {
            MessageBox.Show("Booking confirmed!" + "\n" + "Proceed to customer location!" + "\n" + "Navigation Started!!!");
            
        }

        private void appBar_OnCancel(object sender, EventArgs e)
        {
         //   MessageBox.Show("Booking Order Rejected! "+"\n" + "State Reason For Rejection!" + "\n" + "Navigation Started!!!");
           
        }

    }
}