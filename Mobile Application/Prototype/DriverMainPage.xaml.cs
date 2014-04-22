using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Prototype
{
    public partial class DriverMainPage : PhoneApplicationPage
    {
        public DriverMainPage()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Panorama Driver Menu");
            NavigationService.Navigate(new Uri("/DriverMenu.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Press and hold map Position to Make Marker");
            NavigationService.Navigate(new Uri("/SimulateTracking.xaml", UriKind.Relative));
        }
    }
}