using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LynkApi
{
    public class Workshop
    {
        public int Id { get; set; } //guid ger ett unikt id
        public int LocationId { get; set; }
        public string? BackOfficeWorkshopId { get; set; }
        public string? DisplayName { get; set; }
        public string? Time_Zone { get; set; } // lade till timezone
    }
}
