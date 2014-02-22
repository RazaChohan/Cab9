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
    public partial class Register : PhoneApplicationPage
    {
        String[] users = { "Customer", "Driver" };
        String[] genders = { "Male", "Female" };
        public Register()
        {
            InitializeComponent();
           
            this.user.ItemsSource = users;
            this.Gender.ItemsSource = genders;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        //    if (user.SelectedItem == "Customer")
        //    {
        //        if ((UserNametxt.Text == "") || (UserNametxt.Text == "") || (PasswordTxt.Password == "") || (adresstxt.Text == "") || (phnetxt.Text == "") || (emailtxt.Text == "") || (Nictxt.Text == ""))
        //        {
        //            MessageBox.Show("Enter Complete Information");
        //        }
        //        else
        //        {
        //            Customer cust1 = new Customer(Convert.ToInt32(UserIdtxt.Text.ToString()), UserNametxt.Text.ToString(), Passwordtxt.Text.ToString(), adresstxt.Text.ToString(), phnetxt.Text.ToString(), emailtxt.Text.ToString(), Nictxt.Text.ToString());
        //            MessageBox.Show("New Customer Created");
        //        }

        //    }
        //    else if (user.SelectedItem == "Driver")
        //    {
        //        if ((UserIdtxt.Text == "") || (UserNametxt.Text == "") || (Passwordtxt.Text == "") || (adresstxt.Text == "") || (phnetxt.Text == "") || (emailtxt.Text == "") || (Nictxt.Text == ""))
        //        {
        //            MessageBox.Show("Enter Complete Information");
        //        }
        //        else
        //        {
        //            Driver driver = new Driver(Convert.ToInt32(UserIdtxt.Text.ToString()), UserNametxt.Text.ToString(), Passwordtxt.Text.ToString(), adresstxt.Text.ToString(), phnetxt.Text.ToString(), emailtxt.Text.ToString(), Nictxt.Text.ToString());
        //            MessageBox.Show("New Driver Created");
        //        }

        //    }

        //    MessageBox.Show("Registration Request Sent to Admin Panel");

        //    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        //
        }

    }
}