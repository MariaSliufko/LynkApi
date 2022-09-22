
using System.Net.Http;
using System.Threading.Tasks;
using System;
using LynkApi;
using System.Text.Json;
using Newtonsoft.Json;
using TestLynk;
using System.IO;

namespace LynkProject
{
    public class TestData
    {
        static string dataDirectyory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data"); // skapar filvägen
        static string dataFile = Path.Combine(dataDirectyory, "data.json"); // skapar filen
        public static void ListData()
        {
            

            List<Workshop> Workshops = new List<Workshop> { // mockdata
                new Workshop { LocationId = "222", BackOfficeWorkshopId = "Shop1", DisplayName = "TestShop1", TimeZone = "LCC France, GMT+0" },
                new Workshop { LocationId = "1000", BackOfficeWorkshopId = "Shop2", DisplayName="TestShop2",TimeZone = "LCC SWE, GMT+0"},
                new Workshop { LocationId = "3000", BackOfficeWorkshopId = "Shop3", DisplayName="TestShop3", TimeZone = "LCC NORWAY, GMT+0"}
            };

            foreach (var workshop in Workshops) // objekten
            {
                Console.WriteLine(workshop.LocationId);
                Console.WriteLine(workshop.BackOfficeWorkshopId);
                Console.WriteLine(workshop.DisplayName);
                Console.WriteLine(workshop.TimeZone);
            }// skriver ut mockdatan

            var Workshop = JsonConvert.SerializeObject(Workshops); // serialiserar objekten till json
            Console.WriteLine(Workshop); // skriver ut json

            if (!Directory.Exists(dataDirectyory)) // om directoryn inte finns
            {
                Directory.CreateDirectory(dataDirectyory); // skapa map
                File.WriteAllText(dataFile, Workshop); // skriver ut json till filen
            }
            else
            {
                if (!File.Exists(dataFile)) // om directoryn finns men inte filen
                {
                    File.WriteAllText(dataFile, Workshop);
                } 
                else // om både directory och filen finns
                {
                    File.Delete(dataFile);
                    File.WriteAllText(dataFile, Workshop);
                }
            }
            // om man har en data fil gör såhäer
            string jsonString = File.ReadAllText(dataFile);


            var objResponse = JsonConvert.DeserializeObject<List<Workshop>>(jsonString); //skriver om JSON till .NET objekt
            foreach (var obj in objResponse) // för varje obj i response skriv ut namnet på WS
            {
                //Console.WriteLine(obj.LocationId); //Console.WriteLine(obj.BackOfficeWorkshopId);
                Console.WriteLine(obj.DisplayName);
                //Console.WriteLine(obj.TimeZone);
            }
        }
    }
}