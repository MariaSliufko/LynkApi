using System.Net.Http.Headers;
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
        //static string data= Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data.json");
        public static void ListData()
        {
            List<Workshop> workshopobj = new List<Workshop> { // mockdata
                new Workshop { LocationId = "222", BackOfficeWorkshopId = "Shop1", DisplayName = "TestShop1", TimeZone = "LCC France, GMT+0" },
                new Workshop { LocationId = "1000", BackOfficeWorkshopId = "Shop2", DisplayName="TestShop2",TimeZone = "LCC SWE, GMT+0"},
                new Workshop { LocationId = "3000", BackOfficeWorkshopId = "Shop3", DisplayName="TestShop3", TimeZone = "LCC NORWAY, GMT+0"}
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

            //if (File.Exists(data)) // kollar om filen finns, om den finns gör den nedan
            //    File.Delete(data); // tar bort filen om den finns
            ////Console.WriteLine(data);

            //using (StreamWriter sw = new StreamWriter(data))
            //{ // skapar och skiver filen
            //    sw.WriteLine(data);
            //}
            
            // om man har en data fil gör såhäer
            //string fileName = "WeatherForecast.json";
            //string jsonString = File.ReadAllText(fileName);
            //WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString)!;

            var objResponse = JsonConvert.DeserializeObject<List<Workshop>>(Workshop); //skriver om JSON till .NET objekt
            foreach (var obj in objResponse) // för varje obj i response skriv ut namnet på WS
            {
                //Console.WriteLine(obj.LocationId);
                //Console.WriteLine(obj.BackOfficeWorkshopId);
                Console.WriteLine(obj.DisplayName);
                //Console.WriteLine(obj.TimeZone);
            }
        }
    }
}