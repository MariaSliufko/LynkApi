using System.Net.Http.Headers;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using LynkApi;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;

namespace LynkProject
{
    public class TestData
    {
        public static void ListData()
        {
            List<Workshop> workshopobj = new List<Workshop> {
                new Workshop { LocationId = "222", BackOfficeWorkshopId = "Shop1", DisplayName = "TestShop1", TimeZone = "LCC France, GMT+0" },
                new Workshop { LocationId = "1000", BackOfficeWorkshopId = "Shop2", DisplayName="TestShop2",TimeZone = "LCC SWE, GMT+0"},
                new Workshop { LocationId = "3000", BackOfficeWorkshopId = "Shop3", DisplayName="TestShop3", TimeZone = "LCC NORWAY, GMT+0"}
                // mockdata
            };


            foreach (var Workshopobj in workshopobj) // objekten
            {
                Console.WriteLine(Workshopobj.LocationId);
                Console.WriteLine(Workshopobj.BackOfficeWorkshopId);
                Console.WriteLine(Workshopobj.DisplayName);
                Console.WriteLine(Workshopobj.TimeZone);
            }// skriver ut mockdatan


            var Workshop = JsonConvert.SerializeObject(workshopobj); // serialiserar objekten till json
            Console.WriteLine(Workshop); // skriver ut json

        }
    }
}