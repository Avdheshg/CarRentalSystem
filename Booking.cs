using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    public class Booking
    {
        public string Id {  get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; } 
        public string PickUpStationId { get; set; }
        public string DropStationId { get; set; }
        public string UserId { get; set; }
        public double InvoiceAmt { get; set; }
        public string VehicleId { get; set; }
        public bool Status { get; set; }

    }
}
