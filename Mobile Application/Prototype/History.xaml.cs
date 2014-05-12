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
    public partial class History : PhoneApplicationPage
    {
        public History()
        {
            InitializeComponent();
        }
        public void TestCallback(object sender, ServiceReference1.RateDriverCompletedEventArgs e)
        {

            MessageBox.Show("Rating submitted successfully!");

            NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string CabNo="";
            // Getting Cab Registration Number from Isolated Storage File

            // Reading logged in customer details
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

                try
                {
                    Reader = new StreamReader(new IsolatedStorageFileStream("BookingDetails" + Buffer + ".txt", FileMode.Open, fileStorage));
                    Reader.ReadLine();
                    Reader.ReadLine();
                    CabNo = Reader.ReadLine();


                    Reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                
            }



            ServiceReference1.ServiceClient clientForTesting = new ServiceReference1.ServiceClient();
            clientForTesting.RateDriverCompleted += new EventHandler<ServiceReference1.RateDriverCompletedEventArgs>(TestCallback);
            clientForTesting.RateDriverAsync(CabNo,Convert.ToInt32(DriverRating.Value));
        }
    }
}