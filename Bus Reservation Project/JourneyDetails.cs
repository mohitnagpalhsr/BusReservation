using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Reservation_Project
{
    public class JourneyDetails
    {
        public int BusId { get; set; }
        public int NoOfSeats { get; set; }
        public string DeptStation { get; set; }
        public string DestStation { get; set; }
        public DateTime DeptDate { get; set; }
        public DateTime RetDate { get; set;}
    }
}
