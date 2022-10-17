using Newtonsoft.Json;
using TestLynk;

namespace LynkApi
{
    public class AppointmentSummary
    {
        //Get the Path of the data/workshops folder
        static string dataDirectory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data/workshops");
        /// <summary>
        /// Fetch the files and convert from json into the WorkshopModel
        /// </summary>
        public static void Sort()
        {
            var files = Directory.GetFiles(dataDirectory); // Get all the files from the directory
            // LÄGG OrderBy på Files MVH
            foreach (var file in files)
            {
                string jsonString = File.ReadAllText(file); // Read the text from the file

                var obj = JsonConvert.DeserializeObject<WorkshopModel>(jsonString); // Convert the file into WorkshopModel
                Console.WriteLine(obj.DisplayName + " " + obj.Appointments.Count()); //CW the Obj display name and Count of Appointments
            }
        }
    }
}
