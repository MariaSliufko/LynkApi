using LynkApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LynkApi
{
    public class VehicleModel 
    { 

            [JsonProperty("location_id")]
            public string? LocationId { get; set; }

            [JsonProperty("vehicle_id")]
            public string? VehicleId { get; set; }

            [JsonProperty("vehicle_registration_plate")]
            public string? VehicleRegistrationPlate { get; set; }

            [JsonProperty("last_ingestion_time")]
            public string? LastIgnestionTime { get; set; }
        
        public class VehicleJSON
        {
            [JsonProperty("vehicleList")] // //vehicleList innehåller en lista med propertys från klassen vehicle.
            public List<VehicleModel>? Vehicles { get; set; }
        }

       
    }
}

