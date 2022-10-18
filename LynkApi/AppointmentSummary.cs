﻿using Newtonsoft.Json;
using TestLynk;

namespace LynkApi
{
    public class AppointmentSummary // gör om data dirctory till en prperty som man kan anropa vartsom helst i prodjektet (public)
    {
        //Get the Path of the data/workshops folder
        static string dataDirectory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data/workshops");
        /// <summary>
        /// Fetch the files and convert from json into the WorkshopModel
        /// </summary>
        public static void Sort() // get Ap by decending
        {
            var files = Directory.GetFiles(dataDirectory); // Get all the files from the directory
            // LÄGG OrderBy på Files

            //Console.WriteLine("Showing info about " + files.Count() + " total appointments:"); //skriver ut totala antl AP

            foreach (var file in files)
            {
                string jsonString = File.ReadAllText(file); // Read the text from the file

                var obj = JsonConvert.DeserializeObject<WorkshopModel>(jsonString); // Convert the file into WorkshopModel
                Console.WriteLine("* " + obj.DisplayName+ " has "+ obj.Appointments.Count() + " total appointments" ); ////CW the Obj display name and Count of Appointments
            }
        }
    }
}
