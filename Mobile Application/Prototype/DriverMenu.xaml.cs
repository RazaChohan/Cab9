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
using Microsoft.Phone.Tasks;

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
        


        private void appBar_OnSave(object sender, EventArgs e)
        {
            MessageBox.Show("Booking confirmed!" + "\n" + "Proceed to customer location!" + "\n" + "Navigation Started!!!");
            
        }

        private void appBar_OnCancel(object sender, EventArgs e)
        {
         //   MessageBox.Show("Booking Order Rejected! "+"\n" + "State Reason For Rejection!" + "\n" + "Navigation Started!!!");
           
        }

        private void navigate_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "https://maps.google.com/maps?saddr=G-11+Islamabad+Service+Road+West&daddr=g-10+Markaz+Islamabad&hl=en&z=25";
            task.Show();
        }

    }
}