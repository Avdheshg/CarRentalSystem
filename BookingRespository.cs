using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    public class BookingRespository
    {
        private List<Booking> Bookings = new List<Booking>();

        public BookingRespository() { }

        public async Task<Booking> GetBooking (string bookingId)
        {
            try
            {
                Booking booking = Bookings.Find(booking =>  booking.Id == bookingId);
                if (booking == null)
                {
                    return booking;
                }
                throw new Exception("No booking found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Booking> CreateBooking(string vehicleId, string stationId, string startTime, string date, string endTime, string userId, double vehicleChargePerHour)
        {
            try
            {
                Booking newBooking = new Booking
                {
                    Id = Utility.GenerateId(),
                    Date = date,
                    StartTime = startTime,
                    EndTime = endTime,
                    PickUpStationId = stationId,
                    UserId = userId,
                    VehicleId = vehicleId,
                    InvoiceAmt = Utility.GenerateInvoice(vehicleChargePerHour, endTime, startTime),
                    Status = true
                };
                Bookings.Add(newBooking);
                return newBooking;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EndBooking (string bookingId, string stationId)
        {
            try
            {
                int bookingIdx = Bookings.FindIndex(booking => booking.Id == bookingId);
                if (bookingIdx >= 0)
                {
                    var booking = Bookings[bookingIdx];
                    booking.Status = false;
                    booking.DropStationId = stationId;


                    //Bookings[bookingIdx] = new Booking
                    //{
                    //    ...Bookings[bookingIdx],
                    //    status = false,
                    //    DropStationId = stationId
                    //};
                }
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
