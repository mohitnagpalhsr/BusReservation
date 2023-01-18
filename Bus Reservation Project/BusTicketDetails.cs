using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Reservation_Project
{
    //public enum TicketStatus { Active, Cancelled };

    internal class BusTicketDetails
    {
        public int TicketId { get; set; }
        public int BusId { get; set; }
        public int CustomerId { get; set; }
        public string DeptStation { get; set; }
        public string DestStation { get; set; }
        public DateTime DeptDate { get; set; }
        public DateTime RetDate { get; set; } 
        public int NoOfPassesngers { get; set; }
        public string TicketType { get; set; }
        public DateTime BookingDate { get; set; }
        public string TicketStatus { get; set; }

    }
}
