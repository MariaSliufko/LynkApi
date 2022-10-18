using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLynk;


namespace LynkApi
{
    public class VehicleSummery // Lägg till vehicle summery. Räkna ihop totalt antal vehicles.
    {
        static string dataDirectory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data/workshops");

        public static void Sort()
        {
            var files = Directory.GetFiles(dataDirectory); // Get all the files from the directory
            // LÄGG OrderBy på Files

            //Console.WriteLine("Showing info about " + files. + " total appointments:"); //skriver ut totala antl AP

            foreach (var file in files)
            {
                string jsonString = File.ReadAllText(file); // Read the text from the file

                var obj = JsonConvert.DeserializeObject<WorkshopModel>(jsonString); // Convert the file into WorkshopModel
                Console.WriteLine("* " +obj.DisplayName + " "+ obj.Vehicles.Count()); ////CW the Obj display name and Count of Cars
            }
        }
    }
}
