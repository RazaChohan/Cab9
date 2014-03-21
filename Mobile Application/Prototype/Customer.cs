using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Customer
    {
        public string username;
        public string password;
        public string address;
        public string PhoneNumber;
        public string email;
        public string NIC;
        public string Gender;
        public string age;

        public Customer(String usernamee, String passwordd, String addresss, String phone, String emailID, String NICNo, String Gender, String Age)
        {
            this.username = usernamee;
            this.password = passwordd;
            this.address = addresss;
            this.PhoneNumber = phone;
            this.email = emailID;
            this.NIC = NICNo;
            this.Gender = Gender;
            this.age = Age;
        }
    }
}
