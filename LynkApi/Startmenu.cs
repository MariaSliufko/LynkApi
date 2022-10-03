using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LynkApi;
//using LynkProject;

namespace LynkApi
{
        public class Startmenu
        {
            public static void Menu()//Metod
            {
                int option = 0;//Börja med värde 0

                bool isInvalidInput = false;
                do
                {
                    Console.WriteLine(@"Main menu
1. Update alla WS
2. List all appointments.
3. Testdata cs
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
                    //GetByAPI.Calling();
                    break;
                case 2:
                    //GetByAPI.List();
                    AppointmentData.Appointments();
                    break;
                case 3:
                    //TestData.ListData();
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

            public void Start()//Metod för att starta metod Menu
            {
                Menu();
            }

        }
    
}
