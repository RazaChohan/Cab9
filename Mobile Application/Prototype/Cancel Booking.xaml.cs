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
    public partial class Cancel_Booking : PhoneApplicationPage
    {
        public Cancel_Booking()
        {
            InitializeComponent();
        }
        private void appBarOkButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Booking Cancelled");
            NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }

        private void appBarCancelButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }

      
    }
}