using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLynk;

namespace LynkApi
{
    public class SearchVehicle
    {
        static string dataDirectyory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data"); // skapar filvägen
        public static void getVehicle()
        {

            Console.WriteLine("Type Vehicle ID:");
            string vId = Console.ReadLine();

            var dir = dataDirectyory + "/vehicles/" + vId + ".json";
            // variablen dir = är data pathen + viachles mappen +  Viachle id med matchade id + .json
            // aka sökvägen till filen som vi vill läsa in

            if (File.Exists(dir)) // om idt finns 
            {
                using (StreamReader sr = new StreamReader(dir)) // då läser den raden som finns i filen då vi vet att all data står på 1 rad 
                {
                    var line = sr.ReadLine();
                    var obj = JObject.Parse(line); //läser in denna linen som ett json objekt
                    Console.WriteLine(obj); // skruver ut det snyggt pga jobjekt classen
                }
            }
            else
            {
                Console.WriteLine("Vehicle ID not found");
            }

            Console.WriteLine("\nPress any key to return to menu");
            Console.ReadKey(true);
            Console.Clear();
            Startmenu.Menu();
        }
    }
}
