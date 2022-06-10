using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinInvoiceProblems 
{
    public class CabInvoiceGenerator
    {
        RideType rideType;
        private readonly int Min_Fair;
        private readonly int Fair_Per_Km;
        private readonly int Fair_Per_Min;

        public CabInvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            try
            {
                if (rideType.Equals(RideType.NORMAL))
                {
                    this.Min_Fair = 10;
                    this.Fair_Per_Km = 15;
                    this.Fair_Per_Min = 5;

                }
                else if (rideType.Equals(RideType.PREMIER))
                {
                    this.Min_Fair = 5;
                    this.Fair_Per_Km = 10;
                    this.Fair_Per_Min = 2;
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride");
            }
        }
        public double calculateFair(int distance, int time)
        {
            double Fair = 0.0d;
            try
            {
                Fair = Fair_Per_Km * distance + time * Fair_Per_Min;
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride");
                }
                if (distance == 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
                }
                if (time < 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid type");
                }
            }
            return Math.Max(Fair, Min_Fair);

        }
        public double CalculateMultipleRide(Ride[] rides)
        {
            double result = 0.0d;
            try
            {
                foreach (var data in rides)
                {
                    result += calculateFair((int)data.distance, (int)data.time);
                }
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
                }
            }
            return result / rides.Length;
        }
    }
}
