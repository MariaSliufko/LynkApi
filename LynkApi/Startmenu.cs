using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LynkApi;

namespace LynkApi
{
        public class Startmenu
        {
            public static void Menu()//Metod
            {
                Console.WriteLine("test");
                int option = 0;//Börja med värde 0

                bool isInvalidInput = false;
                do
                {
                    Console.WriteLine(@"Main menu
1. Lista alla WS 
2. FLERA MENYVAL:
3. Exit program. ");
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
                    GetByAPI.Calling().Wait();
                        break;
                    case 2:
                        //SearchByTitle.SearchTitle().Wait();//Metod + wait
                        break;
                    case 3:
                        //ExitMovie.ExitProgram();//Metod för exit
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


        // lägg rätt senare
        //Console.WriteLine(json);

        ////Deserialize json response till c# array av typen Post[]
        //var myWorkshops = JsonConvert.DeserializeObject<Workshop[]>(json);
        ////skriv ut array med objecten med foreach loop
        //foreach (var workshop in myWorkshops)
        //{
        //    Console.WriteLine($"[{workshop.LocationId} {workshop.BackOfficeWorkshopId} {workshop.DisplayName} {workshop.TimeZone}");
        //    //Console.ReadLine();
        //}

}
    
}
