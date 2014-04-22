using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Scheduler;
using System.IO.IsolatedStorage;
using System.IO;

namespace Prototype
{
    public partial class Login : PhoneApplicationPage
    {
        String[] users = { "Customer","Driver"};
        bool authenticated = false;
        public Login()
        {
            InitializeComponent();
            this.user.ItemsSource = users;
        }

        private void AuthenticateReturnFunction(object sender, ServiceReference1.AuthenticateCustomerCompletedEventArgs e)
        {
            if (e.Result == -1)
            {
                MessageBox.Show("ERROR! Invalid username or password.");
            }
            else if(e.Result==-2)
            {
                MessageBox.Show("ERROR! Sorry your registration request was rejected by the administrator after review.");
            }
            else if(e.Result==-3)
            {
                MessageBox.Show("ERROR! EXCEPTION IN WEB SERVICE FUNCTION");
            }
            else
            {
                //Deleting the isolated storage file first to avoid any duplications
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (store.FileExists("LoginDetails.txt"))
                    {
                        IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
                        storage.DeleteFile("LoginDetails.txt");
                    }
                }
                
                ForGlobalVariables.LoginDetails.CustomerLoggedIn = true;
                ForGlobalVariables.LoginDetails.CustomerID=e.Result;
                
                //Writing isolated storage file to access in background agent
                IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
                StreamWriter Writer = new StreamWriter(new IsolatedStorageFileStream("LoginDetails.txt", FileMode.OpenOrCreate, fileStorage));
                Writer.WriteLine("Customer Logged In");
                Writer.WriteLine("CustomerID:" + e.Result.ToString());
                Writer.Close();

                MessageBox.Show("Welcome!");
                NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
            }

        }
        private void CabIDForDriverReturnFunction(object sender, ServiceReference1.CabIDforDriverCompletedEventArgs e)
        {
            if(e.Result != -1)
            {
                //Storing the cab ID for driver to update locations in Background agent
                ForGlobalVariables.LoginDetails.CabID = e.Result;
                if (authenticated)
                {
                    authenticated = false;

                    //Deleting the isolated storage file first to avoid any duplications
                    using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        if (store.FileExists("LoginDetails.txt"))
                        {
                            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
                            storage.DeleteFile("LoginDetails.txt");
                        }
                    }

                    //Writing isolated storage file to access in background agent
                    IsolatedStorageFile fileStorage = IsolatedStorageFile.GetUserStoreForApplication();
                    StreamWriter Writer = new StreamWriter(new IsolatedStorageFileStream("LoginDetails.txt", FileMode.OpenOrCreate, fileStorage));
                    Writer.WriteLine("Driver Logged In");
                    Writer.WriteLine("DriverID:" + ForGlobalVariables.LoginDetails.DriverID);
                    Writer.WriteLine("CabID:" + ForGlobalVariables.LoginDetails.CabID);
                    Writer.Close();

                    MessageBox.Show("Welcome!\nDriverID = "+ForGlobalVariables.LoginDetails.DriverID.ToString() + "\nCabID = "+ForGlobalVariables.LoginDetails.CabID.ToString());
                    NavigationService.Navigate(new Uri("/DriverMainPage.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("ERROR!");
                }
            }
            else
            {

            }
        }

        private void AuthenticateDriverReturnFunction(object sender, ServiceReference1.AuthenticateDriverCompletedEventArgs e)
        {
            if (e.Result != -1)
            {
                try
                {
                    // Setting the global attributes sharable between mobile app and background agent
                    //Global_Library.Class1.DriverID = e.Result;
                    ForGlobalVariables.LoginDetails.DriverLoggedIn = true;
                    int DriverID = Convert.ToInt32(e.Result);
                    ForGlobalVariables.LoginDetails.DriverID = e.Result;
                    
                    //Calling service function to return the cab ID for this logged in Driver
                    ServiceReference1.ServiceClient clientfortesting = new ServiceReference1.ServiceClient();
                    clientfortesting.CabIDforDriverCompleted += new EventHandler<ServiceReference1.CabIDforDriverCompletedEventArgs>(CabIDForDriverReturnFunction);
                    clientfortesting.CabIDforDriverAsync(ForGlobalVariables.LoginDetails.DriverID);

                    //NavigationService.Navigate(new Uri("/DriverMainPage.xaml", UriKind.Relative));
                    //Launching the background task
                    //ScheduledActionService.Add(periodicTask);
                    //ScheduledActionService.LaunchForTest("DriverTask", TimeSpan.FromSeconds(60));

                    authenticated = true;
                   
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Exception in authenticate driver completed.\nException message: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("ERROR! Invalid username or password.");
            }

        }

        private void appBar_OnSave(object sender, EventArgs e)
        {
            authenticated = false;

            var periodicTask = new PeriodicTask("PeriodicTaskDemo") { Description = "Are presenting a periodic task" };
            //MessageBox.Show(listPicker.SelectedItem.ToString());
            if (usertxt.Text == "" || Password1.Password == "")
            {
                MessageBox.Show("Username or Password Missing");
                return;
            }

            if (user.SelectedItem.ToString() == "Customer")
            {
                try
                {
                    ServiceReference1.ServiceClient clientfortesting = new ServiceReference1.ServiceClient();
                    clientfortesting.AuthenticateCustomerCompleted += new EventHandler<ServiceReference1.AuthenticateCustomerCompletedEventArgs>(AuthenticateReturnFunction);
                    clientfortesting.AuthenticateCustomerAsync(usertxt.Text.ToString(), Password1.Password.ToString());
                    // Scheduled Agent
                    ScheduledActionService.Add(periodicTask);
                    ScheduledActionService.LaunchForTest("PeriodicTaskDemo", TimeSpan.FromSeconds(3));

                    //MessageBox.Show("Background agent started");
                    ScheduledActionService.LaunchForTest("PeriodicTaskDemo", TimeSpan.FromSeconds(60));
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                }

                //NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
            }
            else if (user.SelectedItem.ToString() == "Driver")
            {
                try
                {
                    ServiceReference1.ServiceClient clientfortesting = new ServiceReference1.ServiceClient();
                    clientfortesting.AuthenticateDriverCompleted += new EventHandler<ServiceReference1.AuthenticateDriverCompletedEventArgs>(AuthenticateDriverReturnFunction);
                    clientfortesting.AuthenticateDriverAsync(usertxt.Text.ToString(), Password1.Password.ToString());
                    // Scheduled Agent
                    ScheduledActionService.Add(periodicTask);
                    ScheduledActionService.LaunchForTest("PeriodicTaskDemo", TimeSpan.FromSeconds(3));

                    //MessageBox.Show("Background agent started");
                    ScheduledActionService.LaunchForTest("PeriodicTaskDemo", TimeSpan.FromSeconds(60));
                    
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.Message.ToString());
                }
                
            }

        }

        private void appBar_OnCancel(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
        
        
    }
}