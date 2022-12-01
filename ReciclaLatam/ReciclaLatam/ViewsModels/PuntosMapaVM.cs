using System;
using System.Collections.Generic;
using System.Text;

namespace ReciclaLatam.ViewsModels
{
    public class PuntosMapaVM
    {
        public PuntosMapaVM()
        {
        }

        public class VehicleLocations
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string Reciclador { get; set; }
        }

        internal List<VehicleLocations> LoadVehicles()
        {
            //Call the api to get the vehicles nearby
  
            //This are the hardcoded data
            List<VehicleLocations> vehicleLocations = new List<VehicleLocations>
            {
                new VehicleLocations{Latitude = -12.12131227258283, Longitude = -77.03266840037251, Reciclador = "Roberto"},
                new VehicleLocations{Latitude = -12.118947054888404, Longitude = -77.03030184893797, Reciclador = "Juan"},
                new VehicleLocations{Latitude = -12.1214836643546, Longitude = -77.02672572677021, Reciclador = "Joel"},
                new VehicleLocations{Latitude = -12.123566011566407, Longitude = -77.02927976346524, Reciclador = "Luis"},
                new VehicleLocations{Latitude = -12.120223878214455, Longitude = -77.03201444517569, Reciclador = "Adrian"}
            };
            return vehicleLocations;
        }
    }
}
