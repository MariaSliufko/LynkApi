using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLynk;

namespace LynkApi
{
    public class AppointmentData : WorkshopData
    {
        static string dataDirectyory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "appointmentData"); // skapar filvägen
        static string dataFile = Path.Combine(dataDirectyory, "appointmentData.json"); // skapar filen
       // private static string workshopId;
        public static void Appointments()
        {
            var baseadress = "https://context-qa.lynkco.com/api/workshop/";
            var apiToken = "y2TpY8nt029M~OC3NdK7tXnpF";
            ApiClient api = new ApiClient(new Uri(baseadress), apiToken);

            Console.WriteLine("Enter location id to view it's appointments: ");
            string workshopId = Console.ReadLine();
            
            if (workshopId != null)
            {
                api = new ApiClient(new Uri(baseadress + workshopId), apiToken);
                var result = api.GetAppointments(workshopId).Result;
                
                foreach (var appointment in result)
                {
                    Console.WriteLine("Appointment Id: " + appointment.AppointmentId);
                    Console.WriteLine("Location Id: " + appointment.LocationId);
                    Console.WriteLine("Vehicle Id: " + appointment.VehicleId);
                    Console.WriteLine("Vehicle Registration Plate: " + appointment.VehicleRegistrationPlate);
                    Console.WriteLine("Expected Vehicle Milage: " + appointment.ExpectedVehicleMilage);
                    Console.WriteLine("Assignment Types: " + appointment.AssignmentTypes);
                    Console.WriteLine("Vehicle ColorId: " + appointment.VehicleColorId);
                    Console.WriteLine("Scheduled Vehicle Arrival Time: " + appointment.ScheduledVehicleArrivalTime);
                    Console.WriteLine("Scheduled Vehicle Pickup Time: " + appointment.ScheduledVehiclePickupTime);
                    Console.WriteLine("Status: " + appointment.Status);
                    Console.WriteLine("Scheduled Work Start Time: " + appointment.ScheduledWorkStartTime);
                    Console.WriteLine("Scheduled Work End Time: " + appointment.ScheduledWorkEndTime);
                }

                var Appointment = JsonConvert.SerializeObject(result); // serialiserar objekten till json
                Console.WriteLine(Appointments); // skriver ut json

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
                string jsonString = File.ReadAllText(dataFile);

                var objResponse = JsonConvert.DeserializeObject<List<AppointmentModel>>(jsonString); //skriver om JSON till .NET objekt
                foreach (var obj in objResponse) // för varje obj i response skriv ut namnet på WS
                {
                    Console.WriteLine(obj.LocationId); //DisplayName
                }
            }
            else
            {
                Console.WriteLine("No matching workshop id was found");
            }
        }
    }
}
