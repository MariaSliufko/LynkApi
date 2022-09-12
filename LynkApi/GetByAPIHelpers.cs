using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LynkApi
{
    internal static class GetByAPIHelpers
    {
        public static async Task<Workshop> Calling()
        {
            //TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            //Task.Run(() =>
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
                //GetByAPI getByAPI = JsonConvert.DeserializeObject<GetByAPI>(json);
                var myWorkshops = JsonConvert.DeserializeObject<WorkshopJSON>(json);

                //skriv ut array med objecten med foreach loop
                foreach (var workshop in myWorkshops.Workshops)

                {
                    Console.WriteLine($"[{workshop.LocationId}, {workshop.BackOfficeWorkshopId}, {workshop.DisplayName}, {workshop.TimeZone} ");
                    //spara datan i txt fil workshopexamples
                    //File.WriteAllTextAsync(@"C:\Users\masl\source\repos\LynkProject\LynkProject\Workshopexamples.txt", json);
                    //File.WriteAllText(@"C:\Users\masl\source\repos\LynkProject\LynkProject\ListData.json", json);
                    await File.WriteAllTextAsync(@"C:\Users\masl\source\repos\ApiAnswers\Apit.txt", json);
                    return workshop;
                }

                foreach (var workshop in myWorkshops.Workshops)
                {
                    Console.WriteLine($"[{workshop.LocationId}, {workshop.BackOfficeWorkshopId}, {workshop.DisplayName}, {workshop.TimeZone} ");
                }

                //return workshop;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("\nPress any key to return to menu");
                Console.ReadKey(true);
                Console.Clear();
                Startmenu.Menu();
                return null;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}