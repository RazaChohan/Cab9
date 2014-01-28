using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace HCI_Prototype
{
    public partial class CheckStatus : PhoneApplicationPage
    {
        public CheckStatus()
        {
            InitializeComponent();
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