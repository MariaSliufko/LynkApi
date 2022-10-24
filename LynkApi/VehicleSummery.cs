using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLynk;


namespace LynkApi
{
    public class VehicleSummery
    {
        static string dataDirectory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data/vehicles");
        public static void Sort()
        {
            var files = Directory.GetFiles(dataDirectory); // Get all the files from the directory

            Console.WriteLine("Total number of Vehicles: " + files.Count()); // Print length of files
            Console.WriteLine("\nPress any key to return to menu");
            Console.ReadKey(true);
            Console.Clear();
            Startmenu.Menu();
        }
    }
}
