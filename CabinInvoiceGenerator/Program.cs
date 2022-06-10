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
            Console.WriteLine("1. Display Fair Of Cab\n2. Display Fair Cab Of Multiple Rides");
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
                default:
                    Console.WriteLine("Enter The Correct Option");
                    break;
            }
        }
    }
}