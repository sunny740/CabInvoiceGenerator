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
    }
}