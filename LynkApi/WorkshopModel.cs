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

        public WorkshopModel(string aLocationId, string aBackOfficeWorkshopId, string aDisplayName, string aTimeZone)
        {
            LocationId = aLocationId;
            BackOfficeWorkshopId = aBackOfficeWorkshopId;
            DisplayName = aDisplayName;
            TimeZone = aTimeZone;
        }

        public WorkshopModel()
        {
        }

        public static implicit operator WorkshopModel(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class WorkshopJSON //i rooten av jSON har vi items.i denna klassen har vi en jsonproperty den items innehåller en lista på workshops. sen kommer vi i klassen där uppe.
    {
        [JsonProperty("items")]
        public List<WorkshopModel>? Workshops { get; set; }
    }
    //items innehåller en lista med propertys från klassen workshop.
    // döp om denna till workshopList

}
