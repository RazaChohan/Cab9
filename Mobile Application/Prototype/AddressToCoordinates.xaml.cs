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
            MainPage.bookingData.isDesSet = false;
        }
        private async void AddresstoCoordinatesReturnFunction(object sender, ServiceReference1.AddresstoCoordinatesCompletedEventArgs e)
        {
            double lat = 0.00;
            double lng = 0.00;
            int count = 0;
            String latlngCoordinates = e.Result;
            string[] coordinates = latlngCoordinates.Split(':');
            count = 0;
            foreach (string singleCoordinate in coordinates)
            {
                if (count == 0)
                {
                    lat = Convert.ToDouble(singleCoordinate);
                    count++;
                }
                else if (count == 1)
                {
                    lng = Convert.ToDouble(singleCoordinate);
                }
            }

            MainPage.bookingData.lat = lat;
            MainPage.bookingData.lng = lng;
            //MainPage.bookingData.are.Set();

            GeoCoordinate geo = new GeoCoordinate(MainPage.bookingData.lat, MainPage.bookingData.lng);

            MainPage.bookingData.isDesSet = true;
            MainPage.bookingData.desitnation_location = geo;
            NavigationService.Navigate(new Uri("/SelectDestination.xaml", UriKind.Relative));
        }

        private async void appBar_OnChk(object sender, EventArgs e)
        {
            try
            {
                getCoordinatesFromLocation geocoding = new getCoordinatesFromLocation();
                string location = "";
                location = addressLocationtxt.Text + "+" + cityLocationtxt.Text + "+" + "Pakistan";

                ///////////////////////////////////////

                ServiceReference1.ServiceClient clientfortesting = new ServiceReference1.ServiceClient();
                clientfortesting.AddresstoCoordinatesCompleted += new EventHandler<ServiceReference1.AddresstoCoordinatesCompletedEventArgs>(AddresstoCoordinatesReturnFunction);
                clientfortesting.AddresstoCoordinatesAsync(location);

                ///////////////////////////////
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