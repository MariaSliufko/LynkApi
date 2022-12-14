using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LynkApi
{
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

        [JsonProperty("Appointments")]
        public List<string> Appointments { get; set; } // lagt till dessa 2 listor str?ngar
        public List<string> Vehicles { get; set; } // string listor
        public WorkshopModel(string aLocationId, string aBackOfficeWorkshopId, string aDisplayName, string aTimeZone)
        {
            this.LocationId = aLocationId;
            this.BackOfficeWorkshopId = aBackOfficeWorkshopId;
            this.DisplayName = aDisplayName;
            this.TimeZone = aTimeZone;
            this.Appointments = new List<string>(); // string listor som anges ovan skapar tomma nya listor, f?r att vi ska kunna l?gga till f?r att vi ska kunna h?mta alla V och alla AP f?r varje location id och l?gga till de i en WS
            this.Vehicles = new List<string>(); // string listor
        }
        public WorkshopModel()
        {
        }

        public static implicit operator WorkshopModel(string v ) // kolla igen
        {
            throw new NotImplementedException();
        }
    }
    public class WorkshopJSON //i rooten av jSON har vi items.i denna klassen har vi en jsonproperty den items inneh?ller en lista p? workshops. sen kommer vi i klassen d?r uppe.
    {
        [JsonProperty("items")] //workshopList inneh?ller en lista med propertys fr?n klassen workshop.
        public List<WorkshopModel>? WorkshopList { get; set; }
        public string Next { get; set; }
        public WorkshopJSON(List<WorkshopModel>? workshopList, string next)
        {
            WorkshopList = workshopList;
            Next = next;
        }
    }
    

}
