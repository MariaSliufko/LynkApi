using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LynkApi
{
    internal class AppointmentData : PostData
    {
        private static string workshopId;

        public static void Appointments()
        {
            var baseadress = "https://context-qa.lynkco.com/api/workshop/";
            var apiToken = "y2TpY8nt029M~OC3NdK7tXnpF";

            ApiClient api = new ApiClient(new Uri(baseadress), apiToken);

            Console.WriteLine("Enter location id to view it's appointments: ");
            string workshopId = Console.ReadLine();
            //if (workshopId.Any(PostData => workshopId)
            if (workshopId != null)
            {
                api = new ApiClient(new Uri(baseadress + workshopId), apiToken);

                var result = api.GetAppointments(workshopId).Result;
                //var result = myWorkshop.Any(i => i == true);
                foreach (var appointment in result)
                {
                    Console.WriteLine(appointment.AppointmentId);
                    Console.WriteLine(appointment.LocationId);
                    Console.WriteLine(appointment.VehicleId);
                    Console.WriteLine(appointment.VehicleRegistrationPlate);
                    Console.WriteLine(appointment.ExpectedVehicleMilage);
                    Console.WriteLine(appointment.AssignmentTypes);
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
