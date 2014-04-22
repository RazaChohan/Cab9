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

namespace HCI_Prototype
{
    public partial class CheckStatus : PhoneApplicationPage
    {
        public CheckStatus()
        {

            InitializeComponent();
            if(!ForGlobalVariables.CutomerBookingDetails.BookingStatus.Equals(""))
            {
                StatusTextBox.Text = ForGlobalVariables.CutomerBookingDetails.BookingStatus;
                ETATextBox.Text = ForGlobalVariables.CutomerBookingDetails.ETA;
                CabRegNoTextBox.Text = ForGlobalVariables.CutomerBookingDetails.CabRegNo;
                ApproxFareTextBox.Text = ForGlobalVariables.CutomerBookingDetails.ApproxFare;
                DriverRating.Value = ForGlobalVariables.CutomerBookingDetails.DriverRating;
            }
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


            if(IsolatedStorageFile.GetUserStoreForApplication().FileExists("BookingDetails"+Buffer+".txt"))  // Reading Booking Details from isolated storage file
            {
                IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
               
                try
                {
                    Reader = new StreamReader(new IsolatedStorageFileStream("BookingDetails" + Buffer + ".txt", FileMode.Open, fileStorage));
                    ApproxFareTextBox.Text = Reader.ReadLine();
                    StatusTextBox.Text = Reader.ReadLine();
                    CabRegNoTextBox.Text = Reader.ReadLine();
                    DriverRating.Value = Convert.ToInt32(Reader.ReadLine());
                    ETATextBox.Text = Reader.ReadLine();


                    Reader.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                StatusTextBox.Text = "";
                ETATextBox.Text = "";
                CabRegNoTextBox.Text = "";
                ApproxFareTextBox.Text = "";
                DriverRating.Value = 0;
            }
        }


        private void appBar_OnSave(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }

        private void appBar_OnCancel(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }
    }

}