using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    public class Vehicle
    {
        public string Name { get; set; }
        public string NumberPlate {  get; private set; }
        public string Color { get; set; }
        public string Capacity { get; set; }
        public double Price { get; set; }
        public VehicleType Type { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Vehicle(string name)
        {
            NumberPlate = GenerateNumberPlate();
            Name = name;
        }

        private string GenerateNumberPlate()
        {
            Random random = new Random();
            return random.Next(10000, 99999).ToString();
        }

    }
}
