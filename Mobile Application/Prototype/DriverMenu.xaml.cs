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
using System.IO.IsolatedStorage;
using System.IO;

namespace Prototype
{
    public partial class DriverMenu : PhoneApplicationPage
    {
        public DriverMenu()
        {
            InitializeComponent();
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.FileExists("Booking.txt"))
                {
                    IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
                    StreamReader Reader = null;

                    string ReadingString = "";

                    try
                    {
                        Reader = new StreamReader(new IsolatedStorageFileStream("Booking.txt", FileMode.Open, fileStorage));
                        ReadingString = Reader.ReadLine();
                        DateTextBox.Text = ReadingString;
                        //MessageBox.Show("Date: " + ReadingString);
                        ReadingString = "";
                        ReadingString = Reader.ReadLine();
                        TimeTextBox.Text = ReadingString;
                        //MessageBox.Show("Time: " + ReadingString);
                        ReadingString = "";
                        ReadingString = Reader.ReadLine();
                        CustomerLocationText.Text = ReadingString;
                        //MessageBox.Show("Customer Location: " + ReadingString);
                        ReadingString = "";
                        ReadingString = Reader.ReadLine();
                        ReadingString = Reader.ReadLine();
                        DestinationTextBox.Text = ReadingString;
                        //MessageBox.Show("Destination: " + ReadingString);
                        //ReadingString = "";
                        //MessageBox.Show("Cab Type: " + Reader.ReadLine());
                        //ReadingString = "";
                        //MessageBox.Show("Source lat: " + Reader.ReadLine());

                        Reader.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Network Error!");
                    }
                }
            }
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
            MessageBox.Show("Booking Order Rejected! " + "\n" + "State Reason For Rejection!" + "\n" + "Navigation Started!!!");

        }

        private void navigate_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "https://maps.google.com/maps?saddr="+CustomerLocationText.Text+"&daddr="+DestinationTextBox.Text+"&hl=en&z=25";
            task.Show();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Press and hold to Simulate Cab Location");
        //    NavigationService.Navigate(new Uri("/SimulateTracking.xaml", UriKind.Relative));
        //}


    
        
    }
}