using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    public class VehicleRepository
    {
        private List<Vehicle> Vehicles = new List<Vehicle>();

        public VehicleRepository() { }

        public async Task<Vehicle> AddVehicle(Vehicle vehicle)
        {
            try
            {
                int conflictingVehicles = Vehicles.Count(currVehicle => currVehicle.NumberPlate == vehicle.NumberPlate);
                if (conflictingVehicles == 0)
                {
                    Vehicles.Add(vehicle);
                    return vehicle;
                }
                else
                {
                    throw new Exception("Vehicle already registered");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Vehicle> GetVehicle(string vehicleNumberPlate)
        {
            try
            {
                var vehicle = Vehicles.FirstOrDefault(currVehicle => currVehicle.NumberPlate == vehicleNumberPlate);
                if (vehicle != null)
                {
                    return vehicle;
                }
                else
                {
                    throw new Exception("No vehicle found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveVehicle(string vehicleNumberPlate)
        {
            try
            {
                Vehicles = Vehicles.Where(currVehicle => currVehicle.NumberPlate != vehicleNumberPlate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Vehicle>> FilterVehicles(VehicleType vehicleType)
        {
            try
            {
                return Vehicles.Where(currVehicle => currVehicle.Type == vehicleType).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
