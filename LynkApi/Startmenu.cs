using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LynkApi;
using TestLynk;
using Newtonsoft.Json.Linq;
//using LynkProject;

namespace LynkApi
{
    public class Startmenu
    {

        static string dataDirectyory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data"); // skapar filvägen

        public static void Menu()//Metod
        {
            int option = 0;//Börja med värde 0

            bool isInvalidInput = false;
            do
            {
                Console.WriteLine(@"Main menu
1. Update script
2. Lookup Workshop
3. Lookup Vehicle
4. List and save all Workshops.
5. Exit program. ");
                try
                {
                    option = int.Parse(Console.ReadLine());
                    isInvalidInput = false;
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid input, try again...");
                    isInvalidInput = true;//True = skrev bokstav, ska vara siffror.
                }
            } while (isInvalidInput);//Kör sålänge = false

            switch (option)
            {
                case 1:
                    AllAppointmentsdata.AllAppointments();
                    break;
                case 2:

                    Console.WriteLine("Type Workshop ID:");
                    string wId = Console.ReadLine();

                    var dir = dataDirectyory + "/workshops/" + wId + ".json";


                    if (File.Exists(dir))
                    {
                        using (StreamReader sr = new StreamReader(dir))
                        {
                            var line = sr.ReadLine();
                            var obj = JObject.Parse(line); //läser in denna linen som ett json objekt
                            Console.WriteLine(obj); // skruver ut det snyggt pga jobjekt classen
                        }
                    }
                    else
                    {
                        Console.WriteLine("Workshop ID not found");
                    }
                    break;
                case 3:
                    getVehicle();
                   
                    break;
                case 4:
                    //SearchByTitle.SearchTitle().Wait();//Metod + wait
                    WorkshopData.GetWorkshopData();
                    break;
                case 5:
                    ExitLynk.ExitProgram();//Metod för exit
                    break;
                default:
                    Console.WriteLine("Invalid input, try again!");
                    Console.WriteLine("\nPress any key to return to menu");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;
            }
        }


        public static void getVehicle()
        {

            Console.WriteLine("Type Vehicle ID:");
            string vId = Console.ReadLine();

            var dir = dataDirectyory + "/vehicles/" + vId + ".json";


            if (File.Exists(dir))
            {
                using (StreamReader sr = new StreamReader(dir))
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
        }
        public void Start()//Metod för att starta metod Menu
        {
            Menu();
        }

    }

}
