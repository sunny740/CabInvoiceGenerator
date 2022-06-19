using System;
using CabinInvoiceProblems;

public class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine(" ***** Welcome To The Program *****\n ");
        bool check = true;
        while (check)
        {
            Console.WriteLine("1. Display Fair Of Cab\n2. Display Fair Cab Of Multiple Rides\n3. Display Invoice Summary\n4. Get the list of Rides From The RideRepository\n5. Premium Rides(Bonus)\n");
            Console.WriteLine("\nEnter The Above Option");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    CabInvoiceGenerator generator = new CabInvoiceGenerator(RideType.NORMAL);
                    double result = generator.calculateFair(15, 5);
                    Console.WriteLine("Fare Of Cab" + result);
                    break;

                case 2:
                    CabInvoiceGenerator invoice = new CabInvoiceGenerator(RideType.PREMIER);
                    Ride[] rides = { new Ride(15, 5), new Ride(25, 10), new Ride(20, 20) };
                    double result1 = invoice.CalculateMultipleRide(rides);
                    Console.WriteLine("Fare Of Cab Multiple Rides" + result1);
                    break;
                case 3:
                    CabInvoiceGenerator cabInvoice = new CabInvoiceGenerator(RideType.NORMAL);
                    Ride[] rides1 = { new Ride(15, 10), new Ride(35, 35), new Ride(25, 15), new Ride(15, 15), new Ride(50, 60) };
                    InvoiceSummary results = cabInvoice.CalculateMultipleRideSummery(rides1);
                    Console.WriteLine("Total Number Of Rides:->" + results.totalNumberOfRides + "\n" + "Total Fare of Cab:-> " + results.totalFair + "\n" + "Average Fare Of Cab :-> " + results.averageFair);
                    break;
                case 4:
                    CabInvoiceGenerator invoiceSummary = new CabInvoiceGenerator(RideType.NORMAL);
                    Ride[] ride = { new Ride(15, 10), new Ride(35, 35), new Ride(25, 15), new Ride(15, 15), new Ride(50, 60) };
                    string userId = "2001abc";
                    invoiceSummary.MapUserId(userId, ride);

                    InvoiceSummary summary = invoiceSummary.GetRideInvoiceSummary("2001abc");
                    Console.WriteLine("Total Number of rides" + summary.totalNumberOfRides + "\n" + "Total Fare" + summary.totalFair + "\n" + "Average fare:->" + summary.averageFair);
                    break;
                case 5:
                    CabInvoiceGenerator preInvoice = new CabInvoiceGenerator(RideType.PREMIER);
                    Ride[] preRides = { new Ride(15, 10), new Ride(35, 35), new Ride(25, 15), new Ride(15, 15), new Ride(50, 60) };
                    InvoiceSummary preInvoSummary = preInvoice.InvoiceSummaryForPremiumRides(preRides);
                    Console.WriteLine("Total Number of Rides:->" + preInvoSummary.totalNumberOfRides + "\n" + "Total Fare:->" + preInvoSummary.totalFair + "\n" + "Average Fare:->" + preInvoSummary.averageFair);

                    break;
                default:
                    Console.WriteLine("Enter Correct Option\n");
                    break;
            }
        }
    }
}