using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    public class Vehicle
    {
        public string NumberPlate {  get; set; }
        public string Color { get; set; }
        public string Capacity { get; set; }
        public double Price { get; set; }
        public VehicleType Type { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
