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
                                                                                          // GÖR DENNA ASYNC MED AWAIT 
        static string baseadress = "https://context-qa.lynkco.com/api/workshop/";
        static string apiToken = "y2TpY8nt029M~OC3NdK7tXnpF"; // "API_TOKEN"; Not able to use API_TOKEN to replace api token

        static ApiClient api = new ApiClient(new Uri(baseadress), apiToken);
        static List<AppointmentModel> appointmentList = new List<AppointmentModel>(); // skapar en appointmentList
        static List<VehicleModel> vehicleList = new List<VehicleModel>(); // skapar en vehicleList

        public static void FetchDataFromDatabase()
        {

            Console.WriteLine("Confirm if you want to download and uppdate all data by typing Y: ");
            
            string key = Console.ReadLine().ToUpper();

            if (key == "Y")
            {
                var progressSimulator = new ConsoleLineUpdater();

                Task.Run(() =>
                {
                    progressSimulator.start("Connecting to API");
                });

                api = new ApiClient(new Uri(baseadress), apiToken);

                var workshops = api.GetWorkshops().Result; // hämtar alla WS

        

                // tanken är sen att vi ska lagra alla AP och alla V i dessa listor, kmr bli många rader långa 

                if (!Directory.Exists(dataDirectyory)) // om directoryn inte finns för workshops
                {
                    progressSimulator.setText("Creating directories");
                    Directory.CreateDirectory(dataDirectyory); // så sklapar den mappen för Workshops
                }

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



                progressSimulator.setText("Creating workshops");

                var tasks1 = workshops.Select(w => createWorkshopFiles(w));

               
                Task.WhenAll(tasks1).Wait();


                progressSimulator.setText("Creating appointments ");

                var tasks2 = appointmentList.Select(a => createAppointmentFiles(a));

                Task.WhenAll(tasks2).Wait();


                progressSimulator.setText("Creating vehicles");

                var tasks3 = vehicleList.Select(v => createVehicleFiles(v));

                Task.WhenAll(tasks3).Wait();


                progressSimulator.done();



            }
            else
            {
                Startmenu.Menu();
            }

        }

        private static async Task createVehicleFiles(VehicleModel vehicle)
        {
            await Task.Run(() =>
            {
                var file = dataDirectyory + "/vehicles/" + vehicle.VehicleId + ".json";

                try {
                    File.WriteAllText(file, JsonConvert.SerializeObject(vehicle)); // serialiserar objekten till json
                }
                catch (Exception e) // om en fil ändras av 2 Task samtidigt
                {
                    Console.Error.WriteLine(e.Message);
                    Console.Error.WriteLine(vehicle);
                }
            });

        }

        private static async Task createAppointmentFiles(AppointmentModel appointment)
        {
            await Task.Run(() =>
            {
                var file = dataDirectyory + "/appointments/" + appointment.AppointmentId + ".json"; // för varje AP lägger vi i AP mappen och AP id samma som ovan med idt och namnet som rad 58
                File.WriteAllText(file, JsonConvert.SerializeObject(appointment));
            });
        }

      

        private static async Task createWorkshopFiles(WorkshopModel workshop)
        {

            await Task.Run(() =>
            {
                
                var appointments = api.GetAppointments(workshop.LocationId).Result;   // hämtar alla AP från APIT med location id 

                lock (appointmentList)
                {
                    appointmentList.AddRange(appointments); // lägger till alla AP i listan, rage lägger till flera saker i listan ex om de kmr 100 st nya AP läggs det till i listan som vi skapade först
                }
                workshop.Appointments = appointments.Select(a => a.AppointmentId).ToList(); //lamda uttryck, i själva WS:s sträng lista så lägger vi till varje AP (för varje a i appointment så tar vi AP id bara och så gör vi det till en lista 
                                                                                            // denna raden skapar stränglistan med alla Ap ids, så om en AP har idt 23 och ligger på WS med id 1 så kmr den filen se ut såhär 1.23 . dvs wsid+APid blir namnet på filen

                var vehicles = api.GetVehicles(workshop.LocationId).Result; // samma på V, vi hämtar alla V för den WS 

                lock (vehicleList) { 
                    vehicleList.AddRange(vehicles); // lägger till varje V i den 1a listan vi skapade 
                }
                workshop.Vehicles = vehicles.Select(v => v.VehicleId).ToList(); // sen lägger vi till varje V id i WS som sträng, den tar v:t för vehicle och hämtar idt och gör det till en lista 

                
                var file = dataDirectyory + "/workshops/" + workshop.LocationId + ".json"; // vi skapar mappen WS, i denna sakapr vi filen workshop.LocationId.json så det vblir typ WS 1 etc som speglar idt på alla WS
                File.WriteAllText(file, JsonConvert.SerializeObject(workshop)); // ¨till den filen vi skapade ovan lägger vi till och serialisar objektet gör om den modellen vi har till JSON, det är drf vi får det utskrivet och formaterat finare
               
            });

        }
    }
}
