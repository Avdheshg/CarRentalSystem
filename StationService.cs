using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
/*
    V R using await in Service class bcoz Service class is using the Repository class which is dealing with the DB and so using "await", Service class is allowing time to Repository class to perform the operation on the DB 
*/
    public class StationService
    {
        private StationRepository _stationRepository;

        public StationService(StationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<Station> OnBoardStation(Station newStation)
        {
            try
            {
                return await _stationRepository.AddStation(newStation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddVehicle(Vehicle vehicle, string stationId)
        {
            try
            {
                await _stationRepository.AddVehicle(vehicle, stationId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveVehicle(Vehicle vehicle, string stationId)
        {
            try
            {
                await _stationRepository.RemoveVehicle(vehicle, stationId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpBoardStation(string stationId)
        {
            try
            {
                await _stationRepository.DiableStation(stationId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Station>> FilterBasedOnLocation(double userLatitude, double userLongitude)
        {
            try
            {
                return await _stationRepository.GetStations(userLatitude, userLongitude);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Station> GetStation(string stationId)
        {
            try
            {
                return await _stationRepository.GetStation(stationId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
