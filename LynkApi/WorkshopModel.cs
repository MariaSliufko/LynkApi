using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LynkApi
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    //Root myDeserializedClass = JsonConvert.DeserializeObject<Workshop>(result);
    public class WorkshopModel
    {
        [JsonProperty("location_id")]
        public string? LocationId { get; set; }

        [JsonProperty("back_office_workshop_id")]
        public string? BackOfficeWorkshopId { get; set; }

        [JsonProperty("display_name")]
        public string? DisplayName { get; set; }

        [JsonProperty("time_zone")]
        public string? TimeZone { get; set; }

        public List<string> Appointments { get; set; } // lagt till dessa 2 listor strängar
        public List<string> Vehicles { get; set; } // string listor

        public WorkshopModel(string aLocationId, string aBackOfficeWorkshopId, string aDisplayName, string aTimeZone)
        {
            LocationId = aLocationId;
            BackOfficeWorkshopId = aBackOfficeWorkshopId;
            DisplayName = aDisplayName;
            TimeZone = aTimeZone;
            Appointments = new List<string>(); // string listor som anges ovan skapar tomma nya listor, för att vi ska kunna lägga till för att vi ska kunna hämta alla V och alla AP för varje location id och lägga till de i en WS
            Vehicles = new List<string>(); // string listor
        }

        public WorkshopModel()
        {
        }

        public static implicit operator WorkshopModel(string v ) // kolla igen
        {
            throw new NotImplementedException();
        }
    }

    public class WorkshopJSON //i rooten av jSON har vi items.i denna klassen har vi en jsonproperty den items innehåller en lista på workshops. sen kommer vi i klassen där uppe.
    {
        [JsonProperty("items")] //workshopList innehåller en lista med propertys från klassen workshop.
        public List<WorkshopModel>? WorkshopList { get; set; }
    }
   
}
