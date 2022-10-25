using Newtonsoft.Json;
using TestLynk;

namespace LynkApi
{
    public class AppointmentSummary
    // gör om data dirctory till en prperty som man kan anropa vartsom helst i prodjektet (public)
    {
        //Get the Path of the data/workshops folder
        static string dataDirectory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data/workshops");
        // Summary: Fetch the files and convert from json into the WorkshopModel
        public static void Sort() // get Ap by decending
        {
            var files = Directory.GetFiles(dataDirectory); // Get all the files from the directory

            List<WorkshopModel> workshops = new List<WorkshopModel>();

            foreach (var file in files)
            {
                string jsonString = File.ReadAllText(file); // Read the text from the file
               
                WorkshopModel obj = JsonConvert.DeserializeObject<WorkshopModel>(jsonString); // Convert the file into WorkshopModel
                workshops.Add(obj); // Adds into list
            }

            int numerOfAppoinments = 0; // starts at 0
            var workshopsOrdered = workshops.OrderByDescending(w => w.Appointments.Count()); // counts and orders

            foreach (var shop in workshopsOrdered)
            {
                numerOfAppoinments += shop.Appointments.Count();

                Console.WriteLine(shop.Appointments.Count() + " " + shop.DisplayName);
            }

            Console.WriteLine("Total numer of Appointments: " + numerOfAppoinments);
            
            Console.WriteLine("\nPress any key to return to menu");
            Console.ReadKey(true);
            Console.Clear();
            Startmenu.Menu();
        }
    }
}
