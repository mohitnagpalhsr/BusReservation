using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Reservation_Project
{
    internal interface IBusReservation
    {
        public string AdminLogin(string username, string password);

        public string Registration(string username, string password);
        public string Login(string username, string password);
        public void BusAvailabilityEnquiry(JourneyDetails journeyDetails);
        public string MakeReservation(int journeyId, int userId, int noOfPassengers, string ticketType);
        public string PaymentStatus(int ticketId);
        public string CancelReservaton(int ticketId);
        //public List<BusTicketDetails> PrintTicket(int ticketID);
        public void PrintTicket(int customerId);

        public string UpdateRoute(int busId, string deptStation, string destStation);
        public string AddUpdateBus(JourneyDetails journeyDetails);
    }
}
