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

        private void appBar_OnSave(object sender, EventArgs e)
        {
            //MessageBox.Show(listPicker.SelectedItem.ToString());
           if (user.SelectedItem.ToString() == "Customer")
            {
                NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
            }
          else if (user.SelectedItem.ToString() == "Driver")
            {
                NavigationService.Navigate(new Uri("/DriverMenu.xaml", UriKind.Relative));
            }

            //NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }

        private void appBar_OnCancel(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
        
        
    }
}