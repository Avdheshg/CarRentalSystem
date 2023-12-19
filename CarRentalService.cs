using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    // This service is the parent of Service classes of this project bcoz it is using all the service classes and those service classes R using their respective Repository classes
    public class CarRentalService
    {

        private StationService _stationService;
        private BookingService _bookingService;
        private VehicleService _vehicleService;

        public CarRentalService(StationService stationService, BookingService bookingService, VehicleService vehicleService)
        {
            _stationService = stationService;
            _bookingService = bookingService;
            _vehicleService = vehicleService;
        }

        /*
            1. Each station is having it's own vehicles, so for adding a new station, 1st v will add all of it's vehicles
            2. Add the station
        */
        public async Task<Station> AddStation(Station newStation)
        {
            try
            {
                foreach (Vehicle vehicle in newStation.Vehicles)
                {
                    await _vehicleService.AddVehicle(vehicle);  
                }
                return await _stationService.OnBoardStation(newStation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
            1. Get the station, according to the give stationId
            2. Remove all the vehicles associated with that station
            3. Remove the station
        */
        public async Task RemoveStation(string stationId)
        {
            try
            {
                var station = await _stationService.GetStation(stationId);
                foreach (var vehicle in station.Vehicles)
                {
                    await _vehicleService.RemoveVehicle(vehicle.NumberPlate);
                }
                await _stationService.UpBoardStation(stationId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
            1. Get the station based on id
            2. Find the vehicle for the above station from the given id
            3. Create a new booking
            4. Mark the current vehicle of the current station as unavailable
        */
        public async Task<Booking> BookVehicle(string vehicleId, string stationId, string startTime, string endTime, string date, string userId)
        {
            try
            {
                var station = await _stationService.GetStation(stationId);
                var stationVehicle = station.Vehicles.FirstOrDefault(currVehicle => currVehicle.NumberPlate == vehicleId);

                if (stationVehicle == null)
                {
                    throw new Exception("Requested vehicle and stationId are incorrect");
                }

                var booking = await _bookingService.CreateBooking(vehicleId, stationId, startTime, date, endTime, userId, stationVehicle.Price);

                await _stationService.RemoveVehicle(stationVehicle, stationId);

                return booking;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
            1. Get the booking with the Id
            2. Get the vehicle associated with current booking
            3. End the booking
            4. Mark the vehicle for the current station as available 
        */
        public async Task EndBooking(string bookingId, string stationId)
        {
            try
            {
                var booking = await _bookingService.GetBooking(bookingId);
                var bookedVehicle = await _vehicleService.GetVehicle(booking.VehicleId);

                await _bookingService.EndBooking(bookingId, stationId);
                await _stationService.AddVehicle(bookedVehicle, stationId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
            1. Get list of stations according to the location
            2. Filter vehicles based on vehicleType
            3. Show the list of vehicles according to the price and 
                            nearest vehicles
        */
        public async Task<List<Station>> SearchVehicle(VehicleType vehicleType, double userLatitude, double userLongitude)
        {
            try
            {
                var stationsBasedOnLocation = await _stationService.FilterBasedOnLocation(userLatitude, userLongitude);

                List<Vehicle> vehiclesBasedOnType = await _vehicleService.FilterVehicles(vehicleType);

                if (vehiclesBasedOnType.Count > 0)
                {
                    var vehiclesByPrice = vehiclesBasedOnType.OrderBy(currVehicle => currVehicle.Price);
                    var nearestVehicles = vehiclesByPrice.ThenBy(currVehicle => Utility.DistanceBetween(userLatitude, userLongitude, currVehicle.Latitude, currVehicle.Longitude)).ToList();
                } 
                else
                {
                    throw new Exception("No vehicles found of this type");
                }

                return stationsBasedOnLocation;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
