using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net.Sockets;

namespace Bus_Reservation_Project
{
    public class BusReservation : IBusReservation
    {
        public static SqlConnection con;
        public static SqlCommand cmd;

        public void getCon()
        {
            con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=practice; Integrated Security=True");
            con.Open();
            Console.WriteLine("connection established");
        }

        public string Registration(string username, string password)
        {
            getCon();
            cmd = new SqlCommand("insert into BusCustomerDetails output INSERTED.UserId values(@username,@password)");
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Connection = con;
            //int counter=cmd.ExecuteNonQuery();
            int modified = (int)cmd.ExecuteScalar();

            if (modified != null)
            {
                Console.WriteLine("Your user id is {0}", modified);
                return "Registration Successfull";
            }
            else
            {
                return "Registration Failed";
            }
        }

        public string AdminLogin(string username, string password)
        {
            getCon();
            int i = 0;
            cmd = new SqlCommand("select Password from BusAdminDetails where UserName=@username");
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())        //looping the rows
            {
                if (dr[i].ToString() == password)
                {
                    dr.Close();
                    return "Login Successfull";
                    //Console.WriteLine();
                    //return true;
                    
                }
            }
            dr.Close();
            return "Login failed";
            //return false;
        }

        public string Login(string username, string password)
        {
            getCon();
            int i = 0;
            cmd = new SqlCommand("select Password from BusCustomerDetails where UserName=@username");
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())        //looping the rows
            {
                if (dr[i].ToString() == password)
                {
                    return "Login successfull";
                }
            }

            return "Login failed";
        }
        
        
        public void BusAvailabilityEnquiry(JourneyDetails journeyDetails)
        {
            getCon();
            //cmd.Parameters.Clear();
            cmd = new SqlCommand("select * from JourneyDetails where DeptStation=@deptstation AND DestStation=@deststation AND DeptDate=@deptdate AND RetDate=@retdate");
            
            cmd.Parameters.AddWithValue("@deptstation", journeyDetails.DeptStation);
            cmd.Parameters.AddWithValue("@deststation", journeyDetails.DestStation);
            cmd.Parameters.AddWithValue("@deptdate", journeyDetails.DeptDate);
            cmd.Parameters.AddWithValue("@retdate", journeyDetails.RetDate);
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);    //execute the command
            DataSet ds = new DataSet();
            da.Fill(ds);                        //ds is a collection of tables and da fills data into ds
            DataTable dt = ds.Tables[0];         //DataTable is a collection and is storing the first object(table) of ds in dt
            foreach (DataRow dr in dt.Rows)
            {
                foreach (var item in dr.ItemArray)
                {
                    Console.WriteLine(item);
                }
                
                Console.WriteLine();
            }

        }
        
        public string MakeReservation(int journeyId, int userId, int noOfPassengers, string ticketType)
        {

            getCon();
            cmd = new SqlCommand("select * from JourneyDetails where JourneyId=@journeyId");
            cmd.Parameters.AddWithValue("@journeyId", journeyId);
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);    //execute the command
            DataSet ds = new DataSet();
            da.Fill(ds);                        //ds is a collection of tables and da fills data into ds
            DataTable dt = ds.Tables[0];

            var dr = dt.Rows[0];

                int i = 0;

                int BusId = Convert.ToInt32(dr.ItemArray[i + 1]);
                string DeptStation = Convert.ToString(dr.ItemArray[i + 3]);
                string DestStation = Convert.ToString(dr.ItemArray[i + 4]);
                DateTime DeptDate = Convert.ToDateTime(dr.ItemArray[i + 5]);
                DateTime RetDate = Convert.ToDateTime(dr.ItemArray[i + 6]);
                DateTime BookingDate = DateTime.Now.Date;
                string TicketStatus = "Active";
                string PaymentStatus = "Not Paid";

                Console.WriteLine("hello {0}", dr.ItemArray[i + 1]);     //testing

                cmd = new SqlCommand("insert into BusTicketDetails output INSERTED.TicketId values(@BusId,@userId,@DeptStation,@DestStation,@DeptDate,@RetDate,@NoOfPassengers,@TicketType,@BookingDate,@TicketStatus,@PaymentStatus)");
                cmd.Parameters.AddWithValue("@BusId", BusId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@DeptStation", DeptStation);
                cmd.Parameters.AddWithValue("@DestStation", DestStation);
                cmd.Parameters.AddWithValue("@DeptDate", DeptDate);
                cmd.Parameters.AddWithValue("@RetDate", RetDate);
                cmd.Parameters.AddWithValue("@NoOfPassengers", noOfPassengers);
                cmd.Parameters.AddWithValue("@TicketType", ticketType);
                cmd.Parameters.AddWithValue("@BookingDate", BookingDate);
                cmd.Parameters.AddWithValue("@TicketStatus", TicketStatus);
                cmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);

                cmd.Connection = con;
                //cmd.ExecuteNonQuery();

                int modified = (int)cmd.ExecuteScalar();
                //Console.WriteLine(modified);

                if (modified != null)
                {
                    Console.WriteLine($"ticket booked with ticket id {modified}");
                    return "Reservation Successfull";
                }
                else
                {
                    return "Reservation Failed";
                }
            
        }

        public string PaymentStatus(int ticketId)
        {
            getCon();
            cmd = new SqlCommand("Update BusTicketDetails set PaymentStatus='Paid' where TicketId=@ticketId");
            cmd.Parameters.AddWithValue("@ticketId", ticketId);
            cmd.Connection = con;
            int change=cmd.ExecuteNonQuery();
            if (change > 0)
            {
                Console.WriteLine($"Paid for ticket id {ticketId}");
                return "Payment successfull";
            }
            else
            {
                return "Payment Failed";
            }
        }

        public string CancelReservaton(int ticketId)
        {
            getCon();
            cmd = new SqlCommand("Update BusTicketDetails set TicketStatus='cancelled' where TicketId=@ticketId");
            cmd.Parameters.AddWithValue("@ticketId", ticketId);
            cmd.Connection = con;
            int change = cmd.ExecuteNonQuery();
            if (change > 0)
            {
                Console.WriteLine($"ticket booked with ticket id {change}");
                return "Ticket Cancelled";
            }
            else
            {
                return "Ticket does not exist";
            }
        }

        public void PrintTicket(int customerId)
        {
            getCon();
            cmd = new SqlCommand("select * from BusTicketDetails where CustomerId=@customerId");
            cmd.Parameters.AddWithValue("@customerId", customerId);
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);    //execute the command
            DataSet ds = new DataSet();
            da.Fill(ds);                        //ds is a collection of tables and da fills data into ds
            DataTable dt = ds.Tables[0];         //DataTable is a collection and is storing the first object(table) of ds in dt
            foreach (DataRow dr in dt.Rows)
            {
                foreach (var item in dr.ItemArray)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
        }

        public string UpdateRoute(int busId, string deptStation,string destStation)
        {
            getCon();
            cmd = new SqlCommand("Update JourneyDetails set DeptStation=@deptStation, DestStation=@destStation where BusId=@busId");
            cmd.Parameters.AddWithValue("@busId", busId);
            cmd.Parameters.AddWithValue("@deptStation", deptStation);
            cmd.Parameters.AddWithValue("@destStation", destStation);
            cmd.Connection = con;
            int change=cmd.ExecuteNonQuery();       //Executenonquery returns an integer value of the rows affected
            
            if(change > 0)
                return "Bus route changed";
            else
                return "Bus route not changed/No bus exist for this route";
        }

        public string AddUpdateBus(JourneyDetails journeyDetails)
        {
            cmd = new SqlCommand("insert into JourneyDetails values(@busid,@noofseats,@deptstation,@deststation,@deptdate,@retdate)");
            cmd.Parameters.AddWithValue("@busid", journeyDetails.BusId);
            cmd.Parameters.AddWithValue("@noofseats", journeyDetails.NoOfSeats);
            cmd.Parameters.AddWithValue("@deptstation", journeyDetails.DeptStation);
            cmd.Parameters.AddWithValue("@deststation", journeyDetails.DestStation);
            cmd.Parameters.AddWithValue("@deptdate", journeyDetails.DeptDate);
            cmd.Parameters.AddWithValue("@retdate", journeyDetails.RetDate);
            cmd.Connection = con;
            int change = cmd.ExecuteNonQuery();       //Executenonquery returns an integer value of the rows affected

            if (change > 0)
                return "Bus journey added successfully";
            else
                return "Bus journey adding failed";
        }
    }
}
