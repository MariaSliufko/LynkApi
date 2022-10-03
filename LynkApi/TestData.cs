
using System.Net.Http;
using System.Threading.Tasks;
using System;
using LynkApi;
using System.Text.Json;
using Newtonsoft.Json;
using TestLynk;
using System.IO;
using System.Drawing;

namespace LynkProject
{
    public class TestData
    {
        static string dataDirectyory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data"); // skapar filvägen
        static string dataFile = Path.Combine(dataDirectyory, "data.json"); // skapar filen
        public static void ListData()
        {


            var baseadress = "https://context-qa.lynkco.com/api/workshop/";
            var apiToken = "y2TpY8nt029M~OC3NdK7tXnpF";
            
            ApiClient api = new ApiClient(new Uri("https://context-qa.lynkco.com/api/workshop/"), "y2TpY8nt029M~OC3NdK7tXnpF"); //Skickar med urii till konstruktorn
            var result = api.GetAppointments("1506").Result;
            foreach (var appointment in result ?? new List<Appointment>())
            {
               Console.WriteLine(appointment.AppointmentId);
            }

            //List<Workshop> Workshops = new List<Workshop> { // mockdata
            //    new Workshop { LocationId = "222", BackOfficeWorkshopId = "Shop1", DisplayName = "TestShop1", TimeZone = "LCC France, GMT+0" },
            //    new Workshop { LocationId = "1000", BackOfficeWorkshopId = "Shop2", DisplayName="TestShop2",TimeZone = "LCC SWE, GMT+0"},
            //    new Workshop { LocationId = "3000", BackOfficeWorkshopId = "Shop3", DisplayName="TestShop3", TimeZone = "LCC NORWAY, GMT+0"}
            //};

            foreach (var apont in result) // objekten
            {
                Console.WriteLine(apont.AppointmentId);
                //Console.WriteLine(apont.LocationId);
                //Console.WriteLine(apont.VehicleId);
                //Console.WriteLine(apont.VehicleRegistrationPlate);

                //Console.WriteLine(apont.ExpectedVehicleMilage);
                
                //Console.WriteLine(apont.AssignmentTypes);
                //Console.WriteLine(apont.VehicleColorId);
                //Console.WriteLine(apont.ScheduledVehicleArrivalTime);
                //Console.WriteLine(apont.ScheduledVehiclePickupTime);
                //Console.WriteLine(apont.Status);
                //Console.WriteLine(apont.ScheduledWorkStartTime);
                //Console.WriteLine(apont.ScheduledWorkEndTime);

            }// skriver ut datan

            var Appointment = JsonConvert.SerializeObject(result); // serialiserar objekten till json
            Console.WriteLine(Appointment); // skriver ut json

            if (!Directory.Exists(dataDirectyory)) // om directoryn inte finns
            {
                Directory.CreateDirectory(dataDirectyory); // skapa map
                File.WriteAllText(dataFile, Appointment); // skriver ut json till filen
            }
            else
            {
                if (!File.Exists(dataFile)) // om directoryn finns men inte filen
                {
                    File.WriteAllText(dataFile, Appointment);
                } 
                else // om både directory och filen finns
                {
                    File.Delete(dataFile);
                    File.WriteAllText(dataFile, Appointment);
                }
            }
            // om man har en data fil gör såhäer
            string jsonString = File.ReadAllText(dataFile);


            var objResponse = JsonConvert.DeserializeObject<List<Appointment>>(jsonString); //skriver om JSON till .NET objekt
            foreach (var obj in objResponse) // för varje obj i response skriv ut namnet på WS
            {
                Console.WriteLine(obj.AppointmentId);
            }
        }
    }
}