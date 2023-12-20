
using CarRentalSystem;

namespace CarRentalSyatem
{
    /*
        * V can use the live map and according to the real location shared by the user V can filter the cars and integrate real world map in the app

        *** Station ***
        * A station have it's own vehicles
        
            = new Vehicle() { 
                Capacity = "", 
                Color = "", 
                Type = VehicleType., 
                Latitude = , 
                Longitude = , 
                Price = 
            };

            = new Station()
            {
                Latitude = ,
                Longitude = ,
                Vehicles = 
            }

    */
    public class Program
    {

        public static void Main(string[] args)
        {
            /* ===   Station : Gurgaon   === */

            // ** Vehicle Service
            VehicleService gurgaonVehicleService = new VehicleService(new VehicleRepository());

            // ** Vehicles
            Vehicle gurgaon_xuv700 = new Vehicle("XUV700") { 
                Capacity = "7", 
                Color = "Black", 
                Type = VehicleType.SUV, 
                Latitude = 28.45, 
                Longitude = 77.02, 
                Price = 500 
            };

            Vehicle gurgaon_apache160 = new Vehicle("Apache 160") { 
                Capacity = "2", 
                Color = "Blue", 
                Type = VehicleType.BIKE, 
                Latitude = 28.45, 
                Longitude = 77.02, 
                Price = 50 
            };

            Vehicle gurgaon_dzire = new Vehicle("Dzire")
            {
                Capacity = "5",
                Color = "Green",
                Type = VehicleType.SEDAN,
                Latitude = 28.45,
                Longitude = 77.02,
                Price = 300
            };

            Vehicle gurgaon_scorpio = new Vehicle("Scorpio")
            {
                Capacity = "7",
                Color = "Burgundy",
                Type = VehicleType.SUV,
                Latitude = 28.45,
                Longitude = 77.03,
                Price = 700
            };

            Vehicle gurgaon_thar = new Vehicle("Thar")
            {
                Capacity = "4",
                Color = "Black",
                Type = VehicleType.SUV,
                Latitude = 28.45,
                Longitude = 77.01,
                Price = 550
            };

            Vehicle gurgaon_SClass = new Vehicle("S Class")
            {
                Capacity = "5",
                Color = "Blue",
                Type = VehicleType.SEDAN,
                Latitude = 28.45,
                Longitude = 76.03,
                Price = 1500
            };

            //gurgaonVehicleService.AddVehicle(gurgaon_dzire);
            //gurgaonVehicleService.AddVehicle(gurgaon_apache160);
            //gurgaonVehicleService.AddVehicle(gurgaon_xuv700);

            // Station Service
            StationService gurgaonStationService = new StationService(new StationRepository());

            // Creating multiple stations for Gurgaon
            Station gurgaonSector22Station = new Station()
            {
                Latitude = 28.51,
                Longitude = 77.06,
                Vehicles = new Vehicle[] {gurgaon_apache160, gurgaon_dzire}
            };

            Station gurgaonCyberhub = new Station()
            {
                Latitude = 28.5,
                Longitude = 77.09,
                Vehicles = new Vehicle[] {gurgaon_SClass, gurgaon_scorpio}
            };

            Station gurgaonSikandarpurMetro = new Station()
            {
                Latitude = 28.48,
                Longitude = 77.09,
                Vehicles = new Vehicle[] {gurgaon_xuv700, gurgaon_thar, gurgaon_xuv700}
            };

            //gurgaonStationService.OnBoardStation(gurgaonSector22Station);
            //gurgaonStationService.OnBoardStation(gurgaonCyberhub);
            //gurgaonStationService.OnBoardStation(gurgaonSikandarpurMetro);

            // Booking Service
            BookingService bookingService = new BookingService(new BookingRespository());

            CarRentalService gurgaonCarReantalService = new CarRentalService(gurgaonStationService, bookingService, gurgaonVehicleService);

            gurgaonCarReantalService.AddStation(gurgaonSikandarpurMetro);
            gurgaonCarReantalService.AddStation(gurgaonCyberhub);
            gurgaonCarReantalService.AddStation(gurgaonSector22Station);


        }



    }
}


