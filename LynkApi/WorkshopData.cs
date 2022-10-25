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
using System.Configuration;


namespace LynkApi
{
    public class WorkshopData
    {
        static string dataDirectyory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data"); // skapar filvägen
        static string dataFile = Path.Combine(dataDirectyory, "data.json"); // skapar filen
        public static void GetWorkshopData()
        {
            var baseadress = "https://context-qa.lynkco.com/api/workshop/";
            var apiToken = ConfigurationManager.AppSettings["api_key"]; //https://www.c-sharpcorner.com/blogs/how-to-encrypt-a-appsettings-key-in-webconfig

            ApiClient api = new ApiClient(new Uri(baseadress), apiToken);
            var result =  api.GetWorkshops().Result;

            var Workshop = JsonConvert.SerializeObject(result); // serialiserar objekten till json

            //if (!Directory.Exists(dataDirectyory)) // om directoryn inte finns
            //{
            //    Directory.CreateDirectory(dataDirectyory); // skapa map
            //    File.WriteAllText(dataFile, Workshop); // skriver ut json till filen
            //}
            //else
            //{
            //    if (!File.Exists(dataFile)) // om directoryn finns men inte filen
            //    {
            //        File.WriteAllText(dataFile, Workshop);
            //    }
            //    else // om både directory och filen finns
            //    {
            //        File.Delete(dataFile);
            //        File.WriteAllText(dataFile, Workshop);
            //    }
            //}
            string jsonString = File.ReadAllText(dataFile); // datafilen
            var objResponse = JsonConvert.DeserializeObject<List<WorkshopModel>>(jsonString); //skriver om JSON till .NET objekt

            // ?? "STR"  <=>  (str == null) ? "STR" : str;
            var WorkshopGroupedByTimeZone = objResponse.GroupBy(objResponse => objResponse.TimeZone ?? "no registerd") // grupperar efter tidszon, om det inte finns så läggs dem tsm i "No Time Zone"
                .OrderByDescending(group => group.Count()); // sorterar desc efter hur många det finns i varje gruppering

            Console.WriteLine("Showing info about " + objResponse.Count + " total workshops:"); //skriver ut totala antl WS
            
            foreach (var group in WorkshopGroupedByTimeZone)
            {
                Console.WriteLine(group.Count() + " workshops has " + group.Key + " Timezone"); //skriver ut tidzonen och hur många WS som finns i varje tidzon
                foreach (var WS in group)
                    Console.WriteLine("* " + " " + WS.DisplayName);
            }

            Console.WriteLine("\nPress any key to return to menu");
            Console.ReadKey(true);
            Console.Clear();
            Startmenu.Menu();
        }
    }
}