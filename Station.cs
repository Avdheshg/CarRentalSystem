﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    public class Station
    {
        public string Id { get; set; }
        public bool Active { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Vehicle[] Vehicles { get; set; }

        public Station()
        {
            Id = GenerateStationId();
        }

        private string GenerateStationId()
        {
            Random random = new Random();
            return random.Next(0, 99).ToString();
        }

    }
}
