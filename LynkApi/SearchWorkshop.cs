using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLynk;

namespace LynkApi
{
    public class SearchWorkshop
    {
        static string dataDirectyory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data"); // skapar filvägen

        public static void getWorkshop()
        {
            Console.WriteLine("Type Workshop ID:");
            string wId = Console.ReadLine(); // skriv in WS id,

            var dir = dataDirectyory + "/workshops/" + wId + ".json"; // så skapas sökvägen "dirr" döpa om till path, om vi söker på tex 1 så blir sökvägen Workshops.1.json


            if (File.Exists(dir)) // finns denna sökväg / finns denna fil?
            {
                using (StreamReader sr = new StreamReader(dir)) // då läser den raden som finns i filen då vi vet att all data står på 1 rad 
                {
                    var line = sr.ReadLine();
                    var obj = JObject.Parse(line); //läser in denna linen som ett json objekt, vi parsar den 
                    Console.WriteLine(obj); // skriver ut de objektet, har en inbygd to string metod så det blir så snyggt i  konsollen 
                }
            }
            else
            {
                Console.WriteLine("Workshop ID not found"); // om WS idt ej finns skrivs detta ut 
            }
        }

    }
}
