using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLynk;



namespace LynkApi
{
    internal class FileCreator // här var det mkt hade hänt 
    {

        //GetAllAppointments

        // C:\Users\masl\source\repos\LynkApi\LynkApi\bin\Debug\net6.0\data
        static string dataDirectyory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data"); // skapar filvägen C:/documents/maria/github/lykapi/bin + /data
        static string dataFile = Path.Combine(dataDirectyory, "allAppointmentData.json"); // skapar filen

        public static void FetchDataFromDatabase()
        {

            Console.WriteLine("Confirm if you want to download and uppdate all data by typing Y: ");
            
            string key = Console.ReadLine().ToUpper();

            if (key == "Y")
            {

                Console.WriteLine("Progress bar console simulation");

                var progressBarSimulator = new ConsoleLineUpdater(units: 100, steps: 50, milliSec: 5000);
                progressBarSimulator.RunSimulation();

                var baseadress = "https://context-qa.lynkco.com/api/workshop/";
                var apiToken = "y2TpY8nt029M~OC3NdK7tXnpF"; // "API_TOKEN"; Not able to use API_TOKEN to replace api token

                ApiClient api = new ApiClient(new Uri(baseadress), apiToken);
                api = new ApiClient(new Uri(baseadress), apiToken);

                var result = api.GetWorkshops().Result; // hämtar alla WS
                List<AppointmentModel> appointmentList = new List<AppointmentModel>(); // skapar en appointmentList
                List<VehicleModel> vehicleList = new List<VehicleModel>(); // skapar en vehicleList


                // tanken är sen att vi ska lagra alla AP och alla V i dessa listor, kmr bli många rader långa 


                if (!Directory.Exists(dataDirectyory + "/workshops")) // om directoryn inte finns för workshops
                {
                    Directory.CreateDirectory(dataDirectyory + "/workshops"); // så sklapar den mappen för Workshops
                }

                if (!Directory.Exists(dataDirectyory + "/appointments")) // om directoryn inte finns för appointments 
                {
                    Directory.CreateDirectory(dataDirectyory + "/appointments"); // så sklapar den mappen för appointments
                }


                if (!Directory.Exists(dataDirectyory + "/vehicles")) // om directoryn inte finns för vehicles
                {
                    Directory.CreateDirectory(dataDirectyory + "/vehicles"); // så skapar den en map för vehicles
                }

                foreach (var workshop in result) // när vi hittar alla WS går vi igenom varje WS, först skapar vi alla mappar se ovan om de ej finns. 
                {

                    var appointments = api.GetAppointments(workshop.LocationId).Result;   // hämtar alla AP från APIT med location id 
                    appointmentList.AddRange(appointments); // lägger till alla AP i listan, rage lägger till flera saker i listan ex om de kmr 100 st nya AP läggs det till i listan som vi skapade först
                    workshop.Appointments = appointments.Select(a => a.AppointmentId).ToList(); //lamda uttryck, i själva WS:s sträng lista så lägger vi till varje AP (för varje a i appointment så tar vi AP id bara och så gör vi det till en lista 
                                                                                                // denna raden skapar stränglistan med alla Ap ids, så om en AP har idt 23 och ligger på WS med id 1 så kmr den filen se ut såhär 1.23 . dvs wsid+APid blir namnet på filen


                    var vehicles = api.GetVehicles(workshop.LocationId).Result; // samma på V, vi hämtar alla V för den WS 
                    vehicleList.AddRange(vehicles); // lägger till varje V i den 1a listan vi skapade 
                    workshop.Vehicles = vehicles.Select(v => v.VehicleId).ToList(); // sen lägger vi till varje V id i WS som sträng, den tar v:t för vehicle och hämtar idt och gör det till en lista 

                    var file = dataDirectyory + "/workshops/" + workshop.LocationId + ".json"; // vi skapar mappen WS, i denna sakapr vi filen workshop.LocationId.json så det vblir typ WS 1 etc som speglar idt på alla WS
                    File.WriteAllText(file, JsonConvert.SerializeObject(workshop)); // ¨till den filen vi skapade ovan lägger vi till och serialisar objektet gör om den modellen vi har till JSON, det är drf vi får det utskrivet och formaterat finare

                    // så för varje WS hämtar vi alla AP och lägger till i listan och hämtar alla V och lägger till i listan 
                }

                foreach (var appointment in appointmentList) // när vi gått igenom alla WS så går vi igenom alla AP i den listan, så alla AP vi gått igenom och lagt till idn på då går vi igenom varje objekt
                {

                    var file = dataDirectyory + "/appointments/" + appointment.AppointmentId + ".json"; // för varje AP lägger vi i AP mappen och AP id samma som ovan med idt och namnet som rad 58
                    File.WriteAllText(file, JsonConvert.SerializeObject(appointment));
                }

                foreach (var vehicle in vehicleList)
                {

                    var file = dataDirectyory + "/vehicles/" + vehicle.VehicleId + ".json";

                    File.WriteAllText(file, JsonConvert.SerializeObject(vehicle)); // serialiserar objekten till json
                }
            }
            else
            {
                Startmenu.Menu();
            }

            Console.WriteLine("\nThe simulation completed successfully.");
            Console.ReadKey();
        }
    }
}
            /*
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

*/