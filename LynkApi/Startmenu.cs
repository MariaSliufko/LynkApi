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
        public static void Menu()
        {
            int option = 0;

            bool isInvalidInput = false;
            do
            {
                Console.WriteLine(@"Main menu 
1. Update script
2. Search Workshop
3. Search Vehicle
4. Workshop summery
5. Appointment summery
6. Vehicle summery
7. Exit program. ");
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
                    FileCreator.FetchDataFromDatabase(); 
                    break;
                case 2:
                    SearchWorkshop.getWorkshop();
                    break;
                case 3:
                    SearchVehicle.getVehicle(); // exakt samma kod som Appointments 
                    break;
                case 4:
                    WorkshopData.GetWorkshopData();
                    break;
                case 5:
                    AppointmentSummary.Sort();
                    break;
                case 6:
                    VehicleSummery.Sort();
                    break;
                //case 7:
                //    ReadAllData readAllDataObj = new ReadAllData();
                //    readAllDataObj.ReadAllDataNow(".json");
                //    break;
                case 7:
                    ExitLynk.ExitProgram();
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
        public void Start()//Metod för att starta metod Menu
        {
            Menu();
        }
    }
}
