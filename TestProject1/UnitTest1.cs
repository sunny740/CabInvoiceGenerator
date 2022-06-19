using CabinInvoiceProblems;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void InputInInteger_ShouldReturn_TotalFair()
        {
            CabInvoiceGenerator invoice = new CabInvoiceGenerator(RideType.NORMAL);
            double result = invoice.calculateFair(15, 5);
            Assert.AreEqual(result, 250);
        }
        [Test]
        public void InputInInteger_ShouldReturn_MultipleRides_TotalFair()
        {
            CabInvoiceGenerator invoice = new CabInvoiceGenerator(RideType.PREMIER);
            Ride[] rides = { new Ride(2, 3), new Ride(4, 5), new Ride(5, 6) };
            double result = invoice.CalculateMultipleRide(rides);
            Assert.AreEqual(result, 46);
        }
        [Test]
        public void InputInInteger_ShouldReturn_MultipleRides_TotalFair_InvoiceSummary()
        {
            CabInvoiceGenerator invoice = new CabInvoiceGenerator(RideType.NORMAL);
            Ride[] rides1 = { new Ride(15, 10), new Ride(35, 35), new Ride(25, 15) };
            InvoiceSummary result = invoice.CalculateMultipleRideSummery(rides1);
            Assert.AreEqual(result.totalNumberOfRides, 3);
        }
        [Test]
        public void InputInString_GivenUserId_ShouldReturn_MultipleRides_TotalFair_InvoiceSummary()
        {
            CabInvoiceGenerator invoice = new CabInvoiceGenerator(RideType.NORMAL);
            Ride[] ride = { new Ride(15, 10), new Ride(35, 35), new Ride(25, 15), new Ride(15, 15), new Ride(50, 60) };
            string userId = "2001abc";
            invoice.MapUserId(userId, ride);
            InvoiceSummary expectedInvoice = invoice.GetRideInvoiceSummary("2001abc");
            Assert.AreEqual(5, expectedInvoice.totalNumberOfRides);
        }
    }
}