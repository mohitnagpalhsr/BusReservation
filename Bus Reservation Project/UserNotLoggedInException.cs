using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Reservation_Project
{
    internal class UserNotLoggedInException : Exception
    {
        public UserNotLoggedInException(string msg) : base(msg)
        {
            //do something
        }
    }
}
