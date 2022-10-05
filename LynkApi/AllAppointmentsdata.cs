using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLynk;

namespace LynkApi
{
    internal class AllAppointmentsdata
    {
        //GetAllAppointments


        static string dataDirectyory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data"); // skapar filvägen
        static string dataFile = Path.Combine(dataDirectyory, "allAppointmentData.json"); // skapar filen

        public static void AllAppointments()
        {

            var baseadress = "https://context-qa.lynkco.com/api/workshop/";
            var apiToken = "y2TpY8nt029M~OC3NdK7tXnpF";

            ApiClient api = new ApiClient(new Uri(baseadress), apiToken);
            api = new ApiClient(new Uri(baseadress), apiToken);

            var result = api.GetAllAppointments().Result;

            foreach (var appointments in result)
            {
                Console.WriteLine(appointments.LocationId);

            }


            var Appointments = JsonConvert.SerializeObject(result); // serialiserar objekten till json
            Console.WriteLine(Appointments); // skriver ut json

            if (!Directory.Exists(dataDirectyory)) // om directoryn inte finns
            {
                Directory.CreateDirectory(dataDirectyory); // skapa map
                File.WriteAllText(dataFile, Appointments); // skriver ut json till filen
            }
            else
            {
                if (!File.Exists(dataFile)) // om directoryn finns men inte filen
                {
                    File.WriteAllText(dataFile, Appointments);
                }
                else // om både directory och filen finns
                {
                    File.Delete(dataFile);
                    File.WriteAllText(dataFile, Appointments);
                }
            }
            // om man har en data fil gör såhäer
            string jsonString = File.ReadAllText(dataFile);

            var objResponse = JsonConvert.DeserializeObject<List<AppointmentModel>>(jsonString); //skriver om JSON till .NET objekt
            foreach (var obj in objResponse) // för varje obj i response skriv ut namnet på WS
            {
                Console.WriteLine(obj.LocationId); //DisplayName

            }

        }


    }
}
