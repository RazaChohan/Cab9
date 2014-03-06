using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Booking
    {
        public string BookingOrigin;
        public string BookingDestination;
        public DateTime BookingDateTime;
        public string BookingStatus;
        public string BookingCabType;

        public Booking(string origin, string destination, DateTime dateTime, string type)
        {
            this.BookingOrigin = origin;
            this.BookingDestination = destination;
            this.BookingDateTime = dateTime;
            this.BookingStatus = "Uncatered";
            this.BookingCabType = type;
        }
    }
}
