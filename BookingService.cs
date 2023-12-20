using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    public class BookingService
    {
        private BookingRespository bookingRespository;
        public BookingService(BookingRespository bookingRespository)
        {
            this.bookingRespository = bookingRespository;
        }
    
        public async Task<Booking> CreateBooking(string vehicleId, string stationId, string startTime, string date, string endTime, string userId, double vehicleChargePerHour)
        {
            try
            {
                return await bookingRespository.CreateBooking(vehicleId, stationId, startTime, date, endTime, userId, vehicleChargePerHour);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task EndBooking(string bookingId, string stationId)
        {
            try
            {
                await bookingRespository.EndBooking(bookingId, stationId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Booking> GetBooking(string bookingId)
        {
            try
            {
                return await bookingRespository.GetBooking(bookingId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
