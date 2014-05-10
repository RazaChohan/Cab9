using System.Diagnostics;
using System.Windows;
using Microsoft.Phone.Scheduler;
using System;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;
using Microsoft.Phone.Maps.Controls;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Maps.Services;
using System.Device.Location;
using System.Threading;
using System.IO;

namespace ScheduledTaskAgent1
{
    public class ScheduledAgent : ScheduledTaskAgent
    {

        AutoResetEvent ServiceWait = new AutoResetEvent(false);
        AutoResetEvent ServiceWati2 = new AutoResetEvent(false);
        AutoResetEvent GPSWait = new AutoResetEvent(false);

        public Geoposition gPos = null;
        public bool positionLoaded = false;
        public double dlat = 0;
        public double dlong = 0;
        MapLayer pushPinLayer = new MapLayer();

        string CabLatitude;
        string CabLongitude;

        int CabID = -1;
        int DriverID = -1;

        private static volatile bool _classInitialized;

        /// <remarks>
        /// ScheduledAgent constructor, initializes the UnhandledException handler
        /// </remarks>
        public ScheduledAgent()
        {
            if (!_classInitialized)
            {
                _classInitialized = true;
                // Subscribe to the managed exception handler
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    Application.Current.UnhandledException += ScheduledAgent_UnhandledException;
                });
            }
        }

        /// Code to execute on Unhandled Exceptions
        private void ScheduledAgent_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }
        private void TestCallback(object sender, ServiceReference1.UpdateLocationCompletedEventArgs e)
        {
            ServiceWait.Set();

        }
        private void CheckForCancelledBookingsReturnFunction(object sender, ServiceReference1.CheckForDriverCancelledBookingsCompletedEventArgs e)
        {
            if (e.Result != -1)
            {
                // Some booking has been cancelled
                IsolatedStorageFile storageFile = IsolatedStorageFile.GetUserStoreForApplication();
                if (storageFile.FileExists("BookingCancellation.txt"))
                {
                    storageFile.DeleteFile("BookingCancellation.txt");
                }
                StreamWriter Writer = new StreamWriter(new IsolatedStorageFileStream("BookingCancellation.txt", FileMode.OpenOrCreate, storageFile));
                Writer.WriteLine(e.Result.ToString());
                Writer.WriteLine(CabID.ToString());
                Writer.Close();

                // Generating toast notification
                var CancelledToast = new ShellToast { Title = DateTime.Now.ToShortTimeString(), Content = "Alert! A booking has been cancelled.", NavigationUri = new Uri("/NotifyCancelledBooking.xaml", UriKind.Relative) };
                CancelledToast.Show();
            }
            ServiceWati2.Set();

        }

        private void CheckForDriverBookingCompletedReturnFunction(object sender, ServiceReference1.CheckForDriverBookingCompletedEventArgs e)
        {
            // Add code here
            if (e.Result == "No Booking") { }
            else if (e.Result.Contains("EXCEPTION"))
            {
                var toast = new ShellToast { Title = DateTime.Now.ToShortTimeString(), Content = "ERROR! Exception while checking for driver's bookings" };
                toast.Show();
            }
            else
            {

                // Extract the individual details through tokenization and write on file
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (store.FileExists("Booking.txt"))
                    {
                        IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
                        storage.DeleteFile("Booking.txt");
                    }

                    String BookingDateTime;
                    String BookingDate;
                    String BookingTime;
                    String BookingSource;
                    String BookingDestination;
                    String CabType;
                    String SourceLat;
                    String SourceLong;
                    String DestinationLat;
                    String DestinationLong;

                    string[] token = e.Result.Split(new char[] { '+' });
                    BookingDateTime = token[0];
                    BookingSource = token[1];
                    BookingDestination = token[2];
                    CabType = token[3];
                    SourceLat = token[4];
                    SourceLong = token[5];
                    DestinationLat = token[6];
                    DestinationLong = token[7];

                    //Seperating date and time
                    token = BookingDateTime.Split(' ');
                    BookingDate = token[0];
                    BookingTime = token[1];

                    IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
                    StreamWriter Writer = new StreamWriter(new IsolatedStorageFileStream("Booking.txt", FileMode.OpenOrCreate, fileStorage));
                    Writer.WriteLine(BookingDate);
                    Writer.WriteLine(BookingTime);
                    Writer.WriteLine(BookingSource);
                    Writer.WriteLine(BookingDestination);
                    Writer.WriteLine(CabType);
                    Writer.WriteLine(SourceLat);
                    Writer.WriteLine(SourceLong);
                    Writer.WriteLine(DestinationLat);
                    Writer.WriteLine(DestinationLong);
                    Writer.Close();
                }


                // Show notification about new booking
                var NewBookingAlertToast = new ShellToast { Title = DateTime.Now.ToShortTimeString(), Content = "Alert! New Booking Request.", NavigationUri = new Uri("/DriverMenu.xaml", UriKind.Relative) };
                NewBookingAlertToast.Show();
            }
            ServiceWait.Set();

        }

        public async void getGpsLocation()
        {

            // **************************************** Getting location from GPS Sensor *******************************************************
            positionLoaded = false;


            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 10;

            try
            {
                gPos = await geolocator.GetGeopositionAsync(
                    maximumAge: TimeSpan.FromSeconds(5),
                    timeout: TimeSpan.FromSeconds(10)
                    );


                dlat = gPos.Coordinate.Latitude;
                dlong = gPos.Coordinate.Longitude;

                //Converting the GPS coordinates to string
                CabLatitude = gPos.Coordinate.Latitude.ToString("0.000000");
                CabLongitude = gPos.Coordinate.Longitude.ToString("0.000000");

                GPSWait.Set();
            }
            catch (Exception ex)
            {
                if ((uint)ex.HResult == 0x80004004)
                {
                    // the application does not have the right capability or the location master switch is off
                    
                }
            }
        }

        public string ReadLocationFromFile()
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.FileExists("track.txt"))
                {
                    IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
                    StreamReader Reader = null;

                    string ContentString = "";

                    try
                    {
                        Reader = new StreamReader(new IsolatedStorageFileStream("track.txt", FileMode.Open, fileStorage));
                        CabLatitude = Reader.ReadLine();
                        CabLongitude = Reader.ReadLine();

                        Reader.Close();
                        return CabLatitude + "," + CabLongitude;
                    }
                    catch
                    {
                        return "Exception";
                    }
                }
                else return "LocationNotUpdatedManually";
            }
        }
        protected override void OnInvoke(ScheduledTask task)
        {
            bool driverLoggedIn = false;

           ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(60));

            // Read manually updated driver location from file.
            string DriverLocation = ReadLocationFromFile();

            //getGpsLocation();   //Getting GPS location from GPS sensor
            //GPSWait.WaitOne();

            /* Reading isolated storage files for login details in main mobile application
             * if the logged in user is driver then update location using GPS
             */
            IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
            StreamReader Reader = null;

            string ReadText = "";

            try
            {
                Reader = new StreamReader(new IsolatedStorageFileStream("LoginDetails.txt", FileMode.Open, fileStorage));
                ReadText = Reader.ReadLine();

                if (ReadText.Equals("Customer Logged In"))
                {
                    driverLoggedIn = false;

                }
                else if (ReadText.Equals("Driver Logged In"))
                {
                    driverLoggedIn = true;

                    //  Storing Driver ID
                    ReadText = Reader.ReadLine();
                    string[] token = ReadText.Split(new char[] { ':' });
                    DriverID = Convert.ToInt32(token[1]);

                    //  Storing Cab ID
                    ReadText = Reader.ReadLine();
                    token = ReadText.Split(new char[] { ':' });
                    CabID = Convert.ToInt32(token[1]);


                }

                Reader.Close();
            }
            catch
            {
                MessageBox.Show("File it not created");
            }

            if (driverLoggedIn && DriverID != -1)
            {
                ServiceReference1.ServiceClient clientForTesting = new ServiceReference1.ServiceClient();
                if (DriverLocation != "LocationNotUpdatedManually" && DriverLocation != "Exception")
                {
                    // Calling web service function to update Cab Location

                    clientForTesting.UpdateLocationCompleted += new EventHandler<ServiceReference1.UpdateLocationCompletedEventArgs>(TestCallback);
                    clientForTesting.UpdateLocationAsync(CabLatitude, CabLongitude, CabID);

                    // lock the thread until web call is completed
                    ServiceWait.WaitOne();



                }
                ServiceWait = new AutoResetEvent(false);

                // Calling web service to check if there are any notifications regarding order
                clientForTesting.CheckForDriverBookingCompleted += new EventHandler<ServiceReference1.CheckForDriverBookingCompletedEventArgs>(CheckForDriverBookingCompletedReturnFunction);
                clientForTesting.CheckForDriverBookingAsync(CabID);
                ServiceWait.WaitOne();


                // Calling web service to check if there are any notifications regard booking cancellation
                clientForTesting.CheckForDriverCancelledBookingsCompleted += new EventHandler<ServiceReference1.CheckForDriverCancelledBookingsCompletedEventArgs>(CheckForCancelledBookingsReturnFunction);
                clientForTesting.CheckForDriverCancelledBookingsAsync(CabID);
                ServiceWati2.WaitOne();

            }

            //var toast = new ShellToast { Title = DateTime.Now.ToShortTimeString(), Content = "Background Agent Launched" };
            //toast.Show();
            NotifyComplete();

        }
    }

}