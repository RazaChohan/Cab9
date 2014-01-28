﻿using System;
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
    public partial class BookACab : PhoneApplicationPage
    {
        String[] cab_types = { "Economy", "Executive" };
       
        public BookACab()
        {
            InitializeComponent();
            this.cab_type.ItemsSource = cab_types;
            if (MainPage.bookingData.isLocGet == true)
            {
                currentLocationtxt.Text = MainPage.bookingData.current_location_address;
            }
            if (MainPage.bookingData.isDesSet == true)
            {
                DestinationLocationtxt.Text = MainPage.bookingData.destination_location_address;
            }

        }
        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string strItemIndex;
            if (NavigationContext.QueryString.TryGetValue("goto", out strItemIndex))
                PanoramaControl.DefaultItem = PanoramaControl.Items[Convert.ToInt32(strItemIndex)];

            base.OnNavigatedTo(e);
        }

        private void appBar_OnSave(object sender, EventArgs e)
        {
            if (DestinationLocationtxt.Text =="" && currentLocationtxt.Text == "")
            {
                MessageBox.Show("Select Destination and Current Location.");
                return;
            }
            else if (DestinationLocationtxt.Text == "")
            {
                MessageBox.Show("Enter Destination Location");
                return;
            }
            else if(currentLocationtxt.Text=="")
            {
                MessageBox.Show("Acquire Current Location");
                return;
            }
            string Type = cab_type.SelectedItem.ToString();
            DateTime obj = Convert.ToDateTime(datePicker.Value);
            string Date = obj.ToString("dd-MM-yyyy");
            obj = Convert.ToDateTime(timePicker.Value);
            string Time = obj.ToString("hh:mm tt");
            MainPage.bookingData.SetPreferences(Date, Time, Type);

            MessageBoxButton button = MessageBoxButton.OKCancel;// ("Are you sure?");
            MessageBoxResult result = MessageBox.Show("Are you sure?", "", button);
            if (result == MessageBoxResult.OK)
            {
                MessageBox.Show("Cab Booking Request Sent!" + "\n" + "Current Location: " + currentLocationtxt.Text + "\n" + "Destination: " + DestinationLocationtxt.Text + "\n" + "Cab Type: " + cab_type.SelectedItem.ToString());
                NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));

            }
        }

        private void appBar_OnCancel(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //currentLocationtxt.Text = "Default Location";
            NavigationService.Navigate(new Uri("/locateMeGps.xaml", UriKind.Relative));
        }
        private void setDestination(object sender, RoutedEventArgs e)
        {
            if (MainPage.bookingData.isLocGet == false)
            {
                MessageBox.Show("Current Location Not Set..First Acquire Location");
                NavigationService.Navigate(new Uri("/BookACab.xaml?goto=1", UriKind.Relative));
            }

            else
            {
                NavigationService.Navigate(new Uri("/SelectDestination.xaml", UriKind.Relative));
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        
    }
}