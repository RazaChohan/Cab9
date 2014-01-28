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
    public partial class Dashboard : PhoneApplicationPage
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BookACab.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CheckStatus.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EmergencyServices.xaml", UriKind.Relative));
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/History.xaml", UriKind.Relative));
        }
        private void cancel_Booking_Button(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Cancel Booking.xaml", UriKind.Relative));
        }

    }
}