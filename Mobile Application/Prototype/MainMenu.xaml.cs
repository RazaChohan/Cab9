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
using System.IO;

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

        private void ReturnFunction(object sender, ServiceReference1.CheckCustomerBookingsCompletedEventArgs e)
        {
            if(e.Result == -1)
            {
                MessageBox.Show("You have not made any bookings yet!");
            }
            else if(e.Result == -2)
            {
                MessageBox.Show("Exception occurred while finding bookings of the customer.");
            }
            else
            {
                // If customer has made any booking then proceed to booking cancellation page
                ForGlobalVariables.CutomerBookingDetails.BookingID = e.Result;
                NavigationService.Navigate(new Uri("/Cancel Booking.xaml", UriKind.Relative));
            }
        }
        private void cancel_Booking_Button(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
            String LoggedInCustomerID = "";
            if(fileStorage.FileExists("LoginDetails.txt"))
            {
                String Buffer;
                try
                {
                    StreamReader Reader = new StreamReader(new IsolatedStorageFileStream("LoginDetails.txt", FileMode.Open, fileStorage));
                    Buffer = Reader.ReadLine();
                    if(Buffer.Equals("Customer Logged In"))
                    {
                        Buffer = Reader.ReadLine();
                        String[] Token = Buffer.Split(new char[] { ':' });
                        LoggedInCustomerID = Token[1];
                    }
                    Reader.Close();

                    // Checking if the logged in customer has made any bookings
                    ServiceReference1.ServiceClient clientfortesting = new ServiceReference1.ServiceClient();
                    clientfortesting.CheckCustomerBookingsCompleted += new EventHandler<ServiceReference1.CheckCustomerBookingsCompletedEventArgs>(ReturnFunction);
                    clientfortesting.CheckCustomerBookingsAsync(Convert.ToInt32(LoggedInCustomerID));

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Login file does not exist");
            }

            
        }

    }
}