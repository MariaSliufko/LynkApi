using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LynkApi;
using Newtonsoft.Json;
using TestLynk;

namespace LynkApi
{
    public class PostData
    {

        static string dataDirectyory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data"); // skapar filvägen
        static string dataFile = Path.Combine(dataDirectyory, "data.json"); // skapar filen
        public static void Something()
        {
            var baseadress = "https://context-qa.lynkco.com/api/workshop/";
            var apiToken = "y2TpY8nt029M~OC3NdK7tXnpF";

            /*ApiClient api = new ApiClient(new Uri("https://context-qa.lynkco.com/api/workshop/"), "y2TpY8nt029M~OC3NdK7tXnpF");*/ //Skickar med uri till konstruktorn
            ApiClient api = new ApiClient(new Uri(baseadress), apiToken);
            var result =  api.GetWorkshops().Result;
             //foreach (var workshop in result ?? new List<Workshop>())
             //{
             //    Console.WriteLine(workshop.DisplayName);
             //}

            foreach (var workshop in result) // objekten
            {
                Console.WriteLine(workshop.LocationId);
                Console.WriteLine(workshop.BackOfficeWorkshopId);
                Console.WriteLine(workshop.DisplayName);
                Console.WriteLine(workshop.TimeZone);
            }// skriver ut mockdatan

            var Workshop = JsonConvert.SerializeObject(result); // serialiserar objekten till json
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
