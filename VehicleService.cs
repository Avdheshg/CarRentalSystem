using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
/*What if I wodn't use await in this class methods when they R calling VehicleRepository
 */
    public class VehicleService
    {
        private VehicleRepository _vehicleRepository;

        public VehicleService(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<Vehicle> GetVehicle(string vehicleNumberPlte)
        {
            try
            {
                return await _vehicleRepository.GetVehicle(vehicleNumberPlte);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddVehicle(Vehicle vehicle)
        {
            try
            {
                await _vehicleRepository.AddVehicle(vehicle);
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
                await _vehicleRepository.RemoveVehicle(vehicleNumberPlate);
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
                return await _vehicleRepository.FilterVehicles(vehicleType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
