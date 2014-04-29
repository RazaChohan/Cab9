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
using Microsoft.Phone.Maps.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.IO.IsolatedStorage;
using System.IO;


namespace Prototype
{
    public partial class BookACab : PhoneApplicationPage
    {
        String[] cab_types = { "Economy", "Executive" };

        private void TestCallback(object sender, ServiceReference1.CabBookingCompletedEventArgs e)
        {
            if (e.Result.ToString().Contains(':'))
            {
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
                        String[] Token = Buffer.Split(new char[] {':'});
                        Buffer= Token[1];
                    }

                    Reader.Close();

                    // Storing most recent booking's details in isolated storage file
                    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        if (store.FileExists("BookingDetails" + Buffer + ".txt"))
                        {
                            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
                            storage.DeleteFile("BookingDetails" + Buffer + ".txt");
                        }
                    }
                    IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
                    StreamWriter Writer = new StreamWriter(new IsolatedStorageFileStream("BookingDetails" + Buffer + ".txt", FileMode.OpenOrCreate, fileStorage));



                    string[] token = e.Result.Split(new char[] { '\n' });
                    for (int i = 0; i < token.Length; i++)
                    {
                        if (token[i].Contains("Booking Status"))
                        {
                            String[] newToken = token[i].Split(new char[] { ':' });
                            ForGlobalVariables.CutomerBookingDetails.BookingStatus = newToken[1];
                            Writer.WriteLine(newToken[1]);
                        }
                        if (token[i].Contains("ETA for Cab"))
                        {
                            String[] newToken = token[i].Split(new char[] { ':' });
                            ForGlobalVariables.CutomerBookingDetails.ETA = newToken[1];
                            Writer.WriteLine(newToken[1]);
                        }
                        if (token[i].Contains("Estimated Fare"))
                        {
                            String[] newToken = token[i].Split(new char[] { ':' });
                            ForGlobalVariables.CutomerBookingDetails.ApproxFare = newToken[1];
                            Writer.WriteLine(newToken[1]);

                        }
                        if (token[i].Contains("Cab Registration Number"))
                        {
                            String[] newToken = token[i].Split(new char[] { ':' });
                            ForGlobalVariables.CutomerBookingDetails.CabRegNo = newToken[1];
                            Writer.WriteLine(newToken[1]);

                        }
                        if (token[i].Contains("Driver Rating"))
                        {
                            String[] newToken = token[i].Split(new char[] { ':' });
                            ForGlobalVariables.CutomerBookingDetails.DriverRating = Convert.ToInt32(newToken[1]);
                            Writer.WriteLine(newToken[1]);
                        }

                    }
                    Writer.Close();

                    MessageBox.Show(e.Result.ToString());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
                
            //NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }
       
        public BookACab()
        {
            InitializeComponent();
            this.cab_type.ItemsSource = cab_types;
            if (MainPage.bookingData.isLocGet == true)
            {
                currentLocationtxt.Text = MainPage.bookingData.current_location_address;
            }
            if (MainPage.bookingData.isDesSet == true)
            {
                DestinationLocationtxt.Text = MainPage.bookingData.destination_location_address;
            }

        }
        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string strItemIndex;
            if (NavigationContext.QueryString.TryGetValue("goto", out strItemIndex))
                PanoramaControl.DefaultItem = PanoramaControl.Items[Convert.ToInt32(strItemIndex)];

            base.OnNavigatedTo(e);
        }

        private void appBar_OnSave(object sender, EventArgs e)
        {

            try
            {
                if (DestinationLocationtxt.Text == "" && currentLocationtxt.Text == "")
                {
                    MessageBox.Show("Select Destination and Current Location.");
                    return;
                }
                else if (DestinationLocationtxt.Text == "")
                {
                    MessageBox.Show("Enter Destination Location");
                    return;
                }
                else if (currentLocationtxt.Text == "")
                {
                    MessageBox.Show("Acquire Current Location");
                    return;
                }
                string Type = cab_type.SelectedItem.ToString();
                DateTime objDate = Convert.ToDateTime(datePicker.Value);
                string Date = objDate.ToString("dd-MM-yyyy");
                DateTime objTime = Convert.ToDateTime(timePicker.Value);
                string Time = objTime.ToString("hh:mm tt");

                DateTime BookingDateTime = new DateTime(objDate.Year, objDate.Month, objDate.Day,
                              objTime.Hour, objTime.Minute, objTime.Second);
                //DateTime current = DateTime.Now;

                //MessageBox.Show(BookingDateTime.ToString("dd-MMM-yyy hh:mm:ss tt"));
                //MessageBox.Show(current.ToString());

                MainPage.bookingData.SetPreferences(Date, Time, Type);

                Booking bookingInstance = new Booking(currentLocationtxt.Text, DestinationLocationtxt.Text, BookingDateTime, Type);

                MessageBoxButton button = MessageBoxButton.OKCancel;   // ("Are you sure?");
                MessageBoxResult result = MessageBox.Show("Are you sure?", "", button);
                if (result == MessageBoxResult.OK)
                {
                    // ------------------------------- Remote call to web service (for booking) ----------------------------------
                    ServiceReference1.ServiceClient clientForTesting = new ServiceReference1.ServiceClient();
                    clientForTesting.CabBookingCompleted += new EventHandler<ServiceReference1.CabBookingCompletedEventArgs>(TestCallback);
                    clientForTesting.CabBookingAsync(bookingInstance.BookingStatus, bookingInstance.BookingDateTime, bookingInstance.BookingOrigin, bookingInstance.BookingDestination, bookingInstance.BookingCabType, Booking.SourceLat, Booking.SourceLong, Booking.DestinationLat, Booking.DestinationLong,ForGlobalVariables.LoginDetails.CustomerID.ToString());

                    //MessageBox.Show("Cab Booking Request Sent!" + "\n" + "Current Location: " + currentLocationtxt.Text + "\n" + "Destination: " + DestinationLocationtxt.Text + "\n" + "Cab Type: " + cab_type.SelectedItem.ToString());

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void appBar_OnCancel(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //currentLocationtxt.Text = "Default Location";
            NavigationService.Navigate(new Uri("/locateMeGps.xaml", UriKind.Relative));
        }
        private void setDestination(object sender, RoutedEventArgs e)
        {
            if (MainPage.bookingData.isLocGet == false)
            {
                MessageBox.Show("Current Location Not Set..First Acquire Location");
                NavigationService.Navigate(new Uri("/BookACab.xaml?goto=1", UriKind.Relative));
            }

            else
            {
                NavigationService.Navigate(new Uri("/SelectDestination.xaml", UriKind.Relative));
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        
    }
}