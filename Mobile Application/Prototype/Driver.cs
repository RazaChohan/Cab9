using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Driver
    {
        private int ID;
        private string username;
        private string password;
        private string address;
        private string PhoneNumber;
        private string email;
        private string NIC;

        public Driver(int idd, String usernamee, String passwordd, String addresss, String phone, String emailID, String NICNo)
        {
            this.ID = idd;
            this.username = usernamee;
            this.password = passwordd;
            this.address = addresss;
            this.PhoneNumber = phone;
            this.email = emailID;
            this.NIC = NICNo;
        }
    }
}
