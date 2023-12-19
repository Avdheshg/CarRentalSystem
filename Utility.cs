using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    // Utility - helper functions
    public static class Utility
    {
        public static string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }   

        public static double GenerateInvoice (double chargePerHour, string startTime, string endTime)
        {
            var start = DateTime.Parse(startTime);
            var end = DateTime.Parse(endTime);
            var timeDifference = end - start;
            var hours = timeDifference.TotalHours;
            return Math.Max(
                            Math.Floor((hours * chargePerHour) / 60), 
                            chargePerHour
                            );
        }

        public static double ToRad (double value)
        {
            return (value * Math.PI) / 180;
        }

        public static double DistanceBetween (double userLatitude, double userLongitude, double vehicleLatitude, double vehicleLongitude)
        {
            var R = 6371;
            var dLat = ToRad(vehicleLatitude - userLatitude);
            var dLon = ToRad(vehicleLongitude - userLongitude);
            userLatitude = ToRad(userLatitude);
            vehicleLatitude = ToRad(vehicleLatitude);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(userLatitude) * Math.Cos(vehicleLatitude);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a));
            var d = R * c;
            return d;

        }


    }
}
