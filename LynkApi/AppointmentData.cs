using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LynkApi
{
    internal class AppointmentData : WorkshopData
    {
        private static string workshopId;

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
            }
            else
            {
                Console.WriteLine("No matching workshop id was found");
            }







        }












    }
}
