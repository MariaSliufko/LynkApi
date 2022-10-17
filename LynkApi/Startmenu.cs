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
        public static void Menu()//Metod
        {
            int option = 0;//Börja med värde 0

            bool isInvalidInput = false;  // ändrat menyval
            do
            {
                Console.WriteLine(@"Main menu 
1. Update script
2. Search Workshop
3. Search Vehicle
4. Wilmas WS kod
5. Marias WS kod
6. Appointment summery
7. Vehicle summery
8. Read All Data
9. Exit program. ");
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
                    SearchVehicle.getVehicle(); // exakt samma kod, som Appointments 
                    break;
                case 4:
                    WorkshopData.GetWorkshopData(); // Wilmas ws kod
                    break;
                case 5:
                    //ReadAllData.ListWorkshops(); // marias WS kod
                    break;
                case 6:
                    AppointmentSummary.Sort();
                    break;
                case 7:
                    // lägg in kod här
                    break;
                case 8:
                    ReadAllData readAllDataObj = new ReadAllData();
                    readAllDataObj.ReadAllDataNow(".json");
                    break;
                case 9:
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
        public void Start()//Metod för att starta metod Menu
        {
            Menu();
        }

    }

}
