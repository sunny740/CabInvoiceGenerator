using System;
using CabinInvoiceProblems;

public class Program
{
    public static void Main(String[] args)
    {
        //CabInvoiceGenerator problem = new CabInvoiceGenerator(RideType.NORMAL);
        //double Result = problem.calculateFair(15, 5);
        //Console.WriteLine(Result);

        CabInvoiceGenerator problem = new CabInvoiceGenerator(RideType.PREMIER);
        double Result = problem.calculateFair(15, 5);
        Console.WriteLine(Result);
    }
}