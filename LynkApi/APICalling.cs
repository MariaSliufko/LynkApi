
using LynkApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace LynkApi
{
    public class GetByAPI
    {
        public static async Task<GetByAPI> Calling()
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://context-qa.lynkco.com/api/workshop/locations/");

                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, endpoint); //requestmesssage med endpoint 
                    var token = "y2TpY8nt029M~OC3NdK7tXnpF";
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var result = client.SendAsync(request).Result;
                    string json = result.Content.ReadAsStringAsync().Result;


                    GetByAPI getByAPI = JsonConvert.DeserializeObject<GetByAPI>(json);

                    return getByAPI;
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
}