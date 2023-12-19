using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem
{
    public class StationRepository
    {
        private List<Station> Stations = new List<Station>();

        public async Task<Station> AddStation(Station newStation)
        {
            try
            {
                int conflictingStations = Stations.Count(station =>
                                                station.Latitude == newStation.Latitude &&
                                                station.Longitude == newStation.Longitude
                                                );
                if (conflictingStations == 0)
                {
                    Station stationEntity = new Station();
                    stationEntity.Id = Utility.GenerateId();
                    Stations.Add(stationEntity);
                    return stationEntity;
                }
                else
                {
                    throw new Exception("Station already exists");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DiableStation(string stationId)
        {
            try
            {
                Stations = Stations.Select(currStation =>
                {
                    return currStation.Id != stationId ? currStation : new Station { Id = currStation.Id, Active = false };
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Station>> GetStations(double latitude, double longitide)
        {
            try
            {
                return Stations.OrderBy(station => Utility.DistanceBetween(latitude, longitide, station.Latitude, station.Longitude)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddVehicle(Vehicle vehicle, string stationId)
        {
            try
            {
                int stationIdx = Stations.FindIndex(station => station.Id == stationId);
                if (stationIdx >= 0)
                {
                    Stations[stationIdx].Vehicles = Stations[stationIdx].Vehicles.Append(vehicle).ToArray();   // might create problem because "ToArray()" will return a new array and V R not saving it
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RemoveVehicle(Vehicle vehicle, string stationId)
        {
            try
            {
                int stationIdx = Stations.FindIndex(station => station.Id == stationId);

                if (stationIdx >= 0)
                {
                    Stations[stationIdx].Vehicles = Stations[stationIdx].Vehicles.Where(v => v.NumberPlate != vehicle.NumberPlate).ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Station> GetStation(string stationId)
        {
            try
            {
                Station station = Stations.FirstOrDefault(station => station.Id == stationId);
                if (station != null && station.Active)
                {
                    return station;
                }
                else
                {
                    throw new Exception("No station registered");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
