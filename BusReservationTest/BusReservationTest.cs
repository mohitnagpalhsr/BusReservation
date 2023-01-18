using Bus_Reservation_Project;
using System.Diagnostics;
using System.Xml.Linq;

namespace BusReservationTest
{
    [TestFixture]
    public class BusReservationTests
    {
        BusReservation busReservation;
        [SetUp]
        public void Setup()
        {
            busReservation = new BusReservation();
        }

        [Test]
        [TestCase("username","password")]
        public void RegistrtionPassTest(string username, string password)
        {
            Assert.AreEqual("Registration Successfull",busReservation.Registration(username,password));
        }

        [Test]
        [TestCase("mohit", "mohithello")]
        public void RegistrationFailTest(string username, string password)
        {
            Assert.Throws<System.Data.SqlClient.SqlException>(() => busReservation.Registration(username, password));
        }

        [Test]
        [TestCase("mohit", "mohithello")]
        public void LoginPassTest(string username, string password)
        {
            Assert.AreEqual("Login successfull", busReservation.Login(username, password));
        }

        [Test]
        [TestCase("username", "password")]
        public void LoginFailTest(string username, string password)
        {
            Assert.AreEqual("Login failed", busReservation.Login(username, password));
        }

        [Test]
        [TestCase(6001, 1001, 5, "one way")]
        public void JourneyIdReservationFailTest(int journeyId, int userId, int noOfPassengers, string ticketType)
        {
            Assert.Throws<System.IndexOutOfRangeException>(() => busReservation.MakeReservation(journeyId, userId, noOfPassengers, ticketType));
        }
    }
}