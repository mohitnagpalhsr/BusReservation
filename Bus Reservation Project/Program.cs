using System.Globalization;
using System.Net.Sockets;

namespace Bus_Reservation_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            Login login = new Login();
            do
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to Bus Reservation Portal. " +
                    "Please select appropritate option to proceed further :");
                Console.WriteLine();
                Console.WriteLine("1. Customer");
                Console.WriteLine("2. Admin");
                Console.WriteLine("3. Exit");
                choice=int.Parse(Console.ReadLine());

                BusReservation busReservation = new BusReservation();
                JourneyDetails journeyDetails = new JourneyDetails();
                string message;
                try
                {
                    switch(choice)
                    {

                        case 1:
                            int customerChoice;
                            
                            do
                            {
                                //int customerChoice;
                                Console.WriteLine();
                                Console.WriteLine("Welcome to Customer Module");
                                Console.WriteLine("1. Registraiton");
                                Console.WriteLine("2. Login");
                                Console.WriteLine("3. Bus Availability Enquiry");
                                Console.WriteLine("4. Make Reservation");
                                Console.WriteLine("5. Cancel Reservation");
                                Console.WriteLine("6. Print Ticket");
                                Console.WriteLine("7. Logout");
                                Console.WriteLine("8. Pay for ticket");
                                Console.WriteLine("9. Exit");
                                customerChoice = int.Parse(Console.ReadLine());
                                switch (customerChoice)
                                {
                                    case 1:
                                        Console.WriteLine("Enter Unique Username");
                                        login.Username = Console.ReadLine();
                                        Console.WriteLine("Enter password");
                                        login.Password = Console.ReadLine();
                                        message=busReservation.Registration(login.Username, login.Password);
                                        Console.WriteLine(message);
                                        //Console.WriteLine("Registration successfull. Login now to avail services.");
                                        break;

                                    case 2:
                                        Console.WriteLine("Enter Username");
                                        login.Username = Console.ReadLine();
                                        Console.WriteLine("Enter password");
                                        login.Password = Console.ReadLine();
                                        //login.LoggedIn = busReservation.Login(login.Username, login.Password);
                                        //if (login.LoggedIn)
                                            //Console.WriteLine("Login successfull");
                                        message=busReservation.Login(login.Username, login.Password);
                                        Console.WriteLine(message);
                                        break;

                                    case 3:
                                        Console.WriteLine("Enter Departure station");
                                        journeyDetails.DeptStation = Console.ReadLine();
                                        Console.WriteLine("Enter Destination Station");
                                        journeyDetails.DestStation = Console.ReadLine();
                                        Console.WriteLine("Enter deptarture date");
                                        journeyDetails.DeptDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                        Console.WriteLine("Enter return Date");
                                        journeyDetails.RetDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                        busReservation.BusAvailabilityEnquiry(journeyDetails);
                                        break;

                                    case 4:
                                        //if (login.LoggedIn)
                                        //{
                                            Console.WriteLine("Enter journey id for which you want to make booking for");
                                            int journeyId = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter your user id");
                                            int userId=int.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter no of passengers");
                                            int noOfPassengers = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter ticket type: one way or round trip");
                                            string ticketType=Console.ReadLine();
                                            
                                            message=busReservation.MakeReservation(journeyId, userId,noOfPassengers,ticketType);
                                            Console.WriteLine(message);
                                            break;
                                        //}
                                        //else
                                        //{
                                            Console.WriteLine("Please login first");
                                            break;
                                        //}
                                        

                                    case 5:
                                        //if (login.LoggedIn)
                                        //{
                                            Console.WriteLine("enter the ticket id which you want to cancel");
                                            message=busReservation.CancelReservaton(int.Parse(Console.ReadLine()));
                                            Console.WriteLine(message);
                                            break;
                                        //}

                                        //else
                                        //{
                                            Console.WriteLine("Please login first");
                                            break;
                                        //}
                                        

                                    case 6:
                                        //if(login.LoggedIn)
                                        //{
                                            Console.WriteLine("Enter your customer id to get a list of your tickets");
                                            int custId=int.Parse(Console.ReadLine());
                                            busReservation.PrintTicket(custId);
                                            break;
                                        //}

                                        //else
                                        //{
                                            Console.WriteLine("Please login first");
                                            break;
                                        //}
                                        

                                    case 7:
                                        login.LoggedIn = false;
                                        Console.WriteLine("You are now logged out.");
                                        break;

                                    case 8:

                                        //if (login.LoggedIn)
                                        //{
                                            Console.WriteLine("Enter the ticket id which you want to pay for");
                                            int ticketId = int.Parse(Console.ReadLine());
                                            message=busReservation.PaymentStatus(ticketId);
                                            Console.WriteLine(message);
                                            break;
                                        //}

                                        //else
                                        //{
                                            Console.WriteLine("Please login first");
                                            break;
                                        //}
                                        //login.LoggedIn = false;
                                        //break;

                                    case 9:
                                        Environment.Exit(0);
                                        break;

                                    default:
                                        Console.WriteLine("Invalid Choice");
                                        break;
                                }
                            } while (customerChoice != 9);

                            break;
                        
                        case 2:
                            int adminChoice;
                            
                            do
                            {
                                Console.WriteLine();
                                Console.WriteLine("Welcome to Admin Module");
                                Console.WriteLine("1. Login");
                                Console.WriteLine("2. Update Bus Route");
                                Console.WriteLine("3. Add Bus");
                                Console.WriteLine("4. Go back");
                                Console.WriteLine("5. Logout");
                                Console.WriteLine("6. Exit");
                                adminChoice = int.Parse(Console.ReadLine());
                                switch (adminChoice)
                                {
                                    case 1:
                                        Console.WriteLine("Enter Username");
                                        login.Username = Console.ReadLine();
                                        Console.WriteLine("Enter Password");
                                        login.Password = Console.ReadLine();
                                        //login.LoggedIn = busReservation.AdminLogin(login.Username, login.Password);
                                        //if (login.LoggedIn)
                                            //Console.WriteLine("Login successfull");
                                        message= busReservation.AdminLogin(login.Username, login.Password);
                                        Console.WriteLine(message);
                                        break;

                                    case 2:
                                        if (login.LoggedIn)
                                        {
                                            Console.WriteLine("Enter the bus id whose route you want to change");
                                            journeyDetails.BusId = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter the new departure station");
                                            journeyDetails.DeptStation = Console.ReadLine();
                                            Console.WriteLine("Enter the new destinatin station");
                                            journeyDetails.DestStation = Console.ReadLine();
                                            message = busReservation.UpdateRoute(journeyDetails.BusId,journeyDetails.DeptStation,journeyDetails.DestStation);
                                            Console.WriteLine(message);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please login first");
                                            break;
                                        }

                                    case 3:
                                        if (login.LoggedIn)
                                        {
                                            Console.WriteLine("Enter Bus Id");
                                            journeyDetails.BusId = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter no of seats");
                                            journeyDetails.NoOfSeats = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter Departure station");
                                            journeyDetails.DeptStation = Console.ReadLine();
                                            Console.WriteLine("Enter Destination Station");
                                            journeyDetails.DestStation = Console.ReadLine();
                                            Console.WriteLine("Enter deptarture date");
                                            journeyDetails.DeptDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                            Console.WriteLine("Enter return Date");
                                            journeyDetails.RetDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                            message = busReservation.AddUpdateBus(journeyDetails);
                                            Console.WriteLine(message);
                                            break;
                                        }

                                        else
                                        {
                                            Console.WriteLine("Please login first");
                                            break;
                                        }

                                    case 4:
                                        login.LoggedIn = false;
                                        break;

                                    case 5:
                                        login.LoggedIn = false;
                                        Console.WriteLine("You are now logged out.");
                                        break;

                                    case 6:
                                        Environment.Exit(0);
                                        break;

                                    default:
                                        Console.WriteLine("Invalid Choice");
                                        break;
                                }
                            } while (adminChoice !=6);
                            break;

                        case 3:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }

                catch(InvalidValueException ex)
                {
                    Console.WriteLine("Exception thrown : {0}", ex.Message);
                }

                catch(Exception ex) 
                {
                    Console.WriteLine("Exception thrown : {0}", ex.Message);
                }
            }
            while (choice != 3);
        }
    }
}