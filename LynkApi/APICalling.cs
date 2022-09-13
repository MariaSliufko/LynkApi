
using LynkApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestLynk;
using static LynkApi.Workshop;



namespace LynkApi
{
    public class GetByAPI
    {
        public static async Task<Workshop?> Calling()
        {
            using var client = new HttpClient();
            var endpoint = new Uri("https://context-qa.lynkco.com/api/workshop/locations/");
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, endpoint); //requestmesssage med endpoint 
                var token = "y2TpY8nt029M~OC3NdK7tXnpF";
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var result = client.SendAsync(request).Result;
                string json = result.Content.ReadAsStringAsync().Result;
                var html = await result.Content.ReadAsStringAsync();
                var myWorkshops = JsonConvert.DeserializeObject<WorkshopJSON>(json);

                if (myWorkshops != null && myWorkshops.Workshops != null)
                {
                    foreach (var workshop in myWorkshops.Workshops)

                    {
                        Console.WriteLine($"[{workshop.LocationId}, {workshop.BackOfficeWorkshopId}, {workshop.DisplayName}, {workshop.TimeZone} ");
                        var exeDirectory = Path.GetDirectoryName((typeof(Program).Assembly.Location)); //Läs på om detta
                        var dataDirectyory = Path.Combine(exeDirectory ?? string.Empty, "data");
                    }

                    foreach (var workshop in myWorkshops.Workshops)
                    {
                        Console.WriteLine($"[{workshop!.LocationId}, {workshop!.BackOfficeWorkshopId}, {workshop!.DisplayName}, {workshop!.TimeZone} ");
                        return workshop;
                    }
                }

                else
                {
                    IEnumerable<string> workshops = new List<string>();
                }


                throw new ArgumentNullException("workshop");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("\nPress any key to return to menu");
                Console.ReadKey(true);
                Console.Clear();
                //Startmenu.Menu();
                return null;
            }
            finally
            {
                client.Dispose();
            }
        }



    }
}