using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LynkProject
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    //Root myDeserializedClass = JsonConvert.DeserializeObject<Workshop>(result);
    public class Workshop
    {
        [JsonProperty("location_id")]
        public string? LocationId { get; set; }

        [JsonProperty("back_office_workshop_id")]
        public string? BackOfficeWorkshopId { get; set; }

        [JsonProperty("display_name")]
        public string? DisplayName { get; set; }

        [JsonProperty("time_zone")]
        public string? TimeZone { get; set; }
    }

    //public class Root
    //{
    //    [JsonProperty("items")]
    //    public List<Workshop>? Workshops { get; set; }
    //}


}
