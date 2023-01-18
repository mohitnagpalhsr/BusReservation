using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Reservation_Project
{
    //public enum TicketType { OneWay, RoundTrip };

    internal class MakeReservation
    {
        public int JourneyId { get; set; }
        public int NoOfPassesngers { get; set; }
        public string TicketType { get; set;}
    }
}
