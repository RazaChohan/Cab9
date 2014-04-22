using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForGlobalVariables
{
    public static class LoginDetails
    {
        public static bool DriverLoggedIn = false;
        public static bool CustomerLoggedIn = false;
        public static int DriverID=-1;  //In case if driver is logged in
        public static int CustomerID = -1;  //In case if customer is logged in
        public static int CabID;

    }
}
