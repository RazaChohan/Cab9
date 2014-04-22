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
using System.Globalization;

namespace Prototype
{
    public partial class Cancel_Booking : PhoneApplicationPage
    {
        public string ApproximateFare;
        public int TimeElapsed;
        private void ReturnFunction(object sender, ServiceReference1.GetBookingTimeCompletedEventArgs e)
        {
            try
            {
                DateTime BookingDateTime = e.Result;
                DateTime CurrentDate = DateTime.Now;
                TimeSpan Difference = CurrentDate - BookingDateTime;
                TimeElapsed = Convert.ToInt32(Difference.TotalMinutes);
                TimeElapsedTextBox.Text = TimeElapsed.ToString()+" Minutes";

                // Reading logged in customer details
                IsolatedStorageFile loginFile = IsolatedStorageFile.GetUserStoreForApplication();
                StreamReader Reader = null;
                String Buffer = "";

                Reader = new StreamReader(new IsolatedStorageFileStream("LoginDetails.txt", FileMode.Open, loginFile));
                Buffer = Reader.ReadLine();
                if (Buffer.Equals("Customer Logged In"))
                {
                    // Reading logged in customer's ID
                    Buffer = Reader.ReadLine();
                    String[] Token = Buffer.Split(new char[] { ':' });
                    Buffer = Token[1];
                }

                Reader.Close();

                // Displaying booking status in the text box
                if (IsolatedStorageFile.GetUserStoreForApplication().FileExists("BookingDetails" + Buffer + ".txt"))  // Reading Booking Details from isolated storage file
                {
                    IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();

                    try
                    {
                        Reader = new StreamReader(new IsolatedStorageFileStream("BookingDetails" + Buffer + ".txt", FileMode.Open, fileStorage));
                        ApproximateFare= Reader.ReadLine();
                        BookingStatusTextBox.Text = Reader.ReadLine();

                        Reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    BookingStatusTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Cancel_Booking()
        {
            InitializeComponent();

            // Getting the time customer made the booking
            ServiceReference1.ServiceClient clientfortesting = new ServiceReference1.ServiceClient();
            clientfortesting.GetBookingTimeCompleted += new EventHandler<ServiceReference1.GetBookingTimeCompletedEventArgs>(ReturnFunction);
            clientfortesting.GetBookingTimeAsync(ForGlobalVariables.CutomerBookingDetails.BookingID);




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

        private void CancellationReturnFunction(object sender, ServiceReference1.CancelBookingCompletedEventArgs e)
        {
            MessageBox.Show(e.Result);

            // Deleting booking details file
            IsolatedStorageFile loginFile = IsolatedStorageFile.GetUserStoreForApplication();
            StreamReader Reader = null;
            String Buffer = "";
            try
            {
                Reader = new StreamReader(new IsolatedStorageFileStream("LoginDetails.txt", FileMode.Open, loginFile));
                Buffer = Reader.ReadLine();
                if (Buffer.Equals("Customer Logged In"))
                {
                    // Reading logged in customer's ID
                    Buffer = Reader.ReadLine();
                    String[] Token = Buffer.Split(new char[] { ':' });
                    Buffer = Token[1];
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            if (IsolatedStorageFile.GetUserStoreForApplication().FileExists("BookingDetails" + Buffer + ".txt"))  // Reading Booking Details from isolated storage file
            {
                IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();

                fileStorage.DeleteFile("BookingDetails" + Buffer + ".txt");
            }
            NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }

        private void CancelBookingButton_Click(object sender, RoutedEventArgs e)
        {
            String Fare;
            String[] token = ApproximateFare.Split(new char[] { ' ' });
            String[] token2 = token[2].Split(new char[] { '/' });
            Fare = token2[0];

            // Getting the time customer made the booking
            ServiceReference1.ServiceClient clientfortesting = new ServiceReference1.ServiceClient();
            clientfortesting.CancelBookingCompleted += new EventHandler<ServiceReference1.CancelBookingCompletedEventArgs>(CancellationReturnFunction);
            clientfortesting.CancelBookingAsync(ForGlobalVariables.CutomerBookingDetails.BookingID,TimeElapsed.ToString(),BookingStatusTextBox.Text,Convert.ToInt32(Fare));
        }

      
    }
}