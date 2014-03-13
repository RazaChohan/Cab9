using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

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

        private void AuthenticateReturnFunction(object sender, ServiceReference1.AuthenticateCustomerCompletedEventArgs e)
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

        private void AuthenticateDriverReturnFunction(object sender, ServiceReference1.AuthenticateDriverCompletedEventArgs e)
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