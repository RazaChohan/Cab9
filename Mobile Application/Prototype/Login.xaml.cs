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

namespace Prototype
{
    public partial class Login : PhoneApplicationPage
    {
        String[] users = { "Customer","Driver"};
        public Login()
        {
            InitializeComponent();
            this.user.ItemsSource = users;
        }

        private void AuthenticateReturnFunction(object sender, ServRef.AuthenticateCustomerCompletedEventArgs e)
        {
            if (e.Result == "Allow")
            {
                MessageBox.Show("Welcome!");
                NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
            }
            else if (e.Result == "Reject")
            {
                MessageBox.Show("ERROR! Invalid username or password.");
            }
            else
                MessageBox.Show(e.Result.ToString());

        }

        private void AuthenticateDriverReturnFunction(object sender, ServRef.AuthenticateDriverCompletedEventArgs e)
        {
            if (e.Result == "Allow")
            {
                MessageBox.Show("Welcome!");
                NavigationService.Navigate(new Uri("/DriverMenu.xaml", UriKind.Relative));
            }
            else if (e.Result == "Reject")
            {
                MessageBox.Show("ERROR! Invalid username or password.");
            }
            else
                MessageBox.Show(e.Result.ToString());

        }

        private void appBar_OnSave(object sender, EventArgs e)
        {
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
                    ServRef.ServiceClient clientfortesting = new ServRef.ServiceClient();
                    clientfortesting.AuthenticateCustomerCompleted += new EventHandler<ServRef.AuthenticateCustomerCompletedEventArgs>(AuthenticateReturnFunction);
                    clientfortesting.AuthenticateCustomerAsync(usertxt.Text.ToString(), Password1.Password.ToString());
                    // Scheduled Agent
                    ScheduledActionService.Add(periodicTask);
                    ScheduledActionService.LaunchForTest("PeriodicTaskDemo", TimeSpan.FromSeconds(3));
                    MessageBox.Show("Open the background agent success");
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
                    ServRef.ServiceClient clientfortesting = new ServRef.ServiceClient();
                    clientfortesting.AuthenticateDriverCompleted += new EventHandler<ServRef.AuthenticateDriverCompletedEventArgs>(AuthenticateDriverReturnFunction);
                    clientfortesting.AuthenticateDriverAsync(usertxt.Text.ToString(), Password1.Password.ToString());
                    // Scheduled Agent
                    ScheduledActionService.Add(periodicTask);
                    ScheduledActionService.LaunchForTest("PeriodicTaskDemo", TimeSpan.FromSeconds(3));
                    MessageBox.Show("Open the background agent success");
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