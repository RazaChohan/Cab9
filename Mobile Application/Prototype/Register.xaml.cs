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
        String[] genders = { "Male", "Female" };
        public Register()
        {
            InitializeComponent();
            this.Gender.ItemsSource = genders;

        }
        private void CustomerRegistrationRequestReturnFunction(object sender, ServiceReference1.CustomerRegistrationRequestCompletedEventArgs e)
        {
            
                MessageBox.Show(e.Result.ToString());

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
             if ((UserNametxt.Text == "") || (UserNametxt.Text == "") || (PasswordTxt.Password == "") || (adresstxt.Text == "") || (phnetxt.Text == "") || (emailtxt.Text == "") || (Nictxt.Text == ""))
             {
                 MessageBox.Show("Enter Complete Information");
             }
             else
             {
                 Customer cus = new Customer(UserNametxt.Text, PasswordTxt.Password, adresstxt.Text, phnetxt.Text, emailtxt.Text, Nictxt.Text, Gender.SelectedItem.ToString(), AgeTxt.Text);
                 ServiceReference1.ServiceClient clientfortesting = new ServiceReference1.ServiceClient();
                 clientfortesting.CustomerRegistrationRequestCompleted += new EventHandler<ServiceReference1.CustomerRegistrationRequestCompletedEventArgs>(CustomerRegistrationRequestReturnFunction);
                 clientfortesting.CustomerRegistrationRequestAsync(cus.username,cus.password,cus.email,cus.PhoneNumber,cus.NIC,cus.address,cus.Gender,cus.age);
             }
       
        }

    }
}