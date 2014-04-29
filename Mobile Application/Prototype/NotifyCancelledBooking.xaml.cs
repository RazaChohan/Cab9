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
using System.Threading;

namespace Prototype
{
    public partial class NotifyCancelledBooking : PhoneApplicationPage
    {
        int BookingID = -1;
        int CabID = -1;
        AutoResetEvent ServiceWait = new AutoResetEvent(false);

        private void CallBackFunction(object sender, ServiceReference1.DetailsForCancelledBookingCompletedEventArgs e)
        {
            if(!e.Result.Contains("No Booking"))
            {
                string[] token = e.Result.Split(new char[] { '+' });
                CustomerLocationText.Text = token[0];
                DestinationTextBox.Text = token[1];
                DateTextBox.Text = token[2];
            }
            else
            {
                MessageBox.Show(e.Result);
            }

            ServiceReference1.ServiceClient clientForTesting = new ServiceReference1.ServiceClient();
                   
            clientForTesting.UpdateBookingAndCabStatusCompleted += new EventHandler<ServiceReference1.UpdateBookingAndCabStatusCompletedEventArgs>(CallBackFunction2);
            clientForTesting.UpdateBookingAndCabStatusAsync(BookingID, CabID);
            //MessageBox.Show("At the end of return 1");
            

        }
        private void CallBackFunction2(object sender, ServiceReference1.UpdateBookingAndCabStatusCompletedEventArgs e)
        {
            //MessageBox.Show("At the start of return 2");
            if (e.Result == 0)
            {
                MessageBox.Show("Your availability status has been set to available");
            }
            //ServiceWait.Set();
            //MessageBox.Show("At the end of return 2");

        }
        public NotifyCancelledBooking()
        {
            InitializeComponent();
            //MessageBox.Show("Inside Constructor");
            IsolatedStorageFile storageFile = IsolatedStorageFile.GetUserStoreForApplication();
            if (storageFile.FileExists("BookingCancellation.txt"))
            {
                try
                {
                    StreamReader Reader = new StreamReader(new IsolatedStorageFileStream("BookingCancellation.txt", FileMode.Open, storageFile));
                    BookingID = Convert.ToInt32(Reader.ReadLine());
                    CabID = Convert.ToInt32(Reader.ReadLine());
                    Reader.Close();

                    // Getting Booking Details From DB
                    ServiceReference1.ServiceClient clientForTesting = new ServiceReference1.ServiceClient();
                    clientForTesting.DetailsForCancelledBookingCompleted += new EventHandler<ServiceReference1.DetailsForCancelledBookingCompletedEventArgs>(CallBackFunction);
                    clientForTesting.DetailsForCancelledBookingAsync(BookingID);
                    //ServiceWait.WaitOne();

                    //ServiceWait = new AutoResetEvent(false);
                    // Setting Booking and Cab Status
                    // Booking status to Cancel and Cab Status to Available
                   
                }
                catch
                {
                    MessageBox.Show("Unable to read booking cancellation file");
                }
            }
            else
            {
                MessageBox.Show("BookingCancellation.txt not found");
            }

            

        }

        private void CustomerLocationText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}