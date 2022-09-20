using System.Net.Http.Headers;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using LynkApi;

namespace LynkProject
{
    static class TestData
    {

        static async void ListData()
        {
            HttpClient httpClient = new();
            {
                var endpoint = new Uri("https://context-qa.lynkco.com/api/workshop/locations/");
                var newPost = new Workshop()
                {
                    LocationId = "115",
                    BackOfficeWorkshopId = "Shop",
                    DisplayName = "GirlShop",
                    TimeZone = "LCC France, GMT+0"

                };


            }

            //StringContent httpContent = new StringContent(@"")
            var url = "https://context-qa.lynkco.com/api/workshop/locations/";
            var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var token = "y2TpY8nt029M~OC3NdK7tXnpF";
            _ = await httpClient.GetAsync("https://context-qa.lynkco.com/api/workshop/locations/, httpContent");

            // Save token for further requests
            //var token = await. response.Content.ReadAsStringAsync()

            //using var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            ////requestMessage.Headers.Add("Accept", "application/json"); // we want json back
            ////requestMessage.Headers.Add("Content-Type", "application/json");

            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //var response1 = await httpClient.SendAsync(requestMessage);
            //var workshops = JsonSerializer.Deserialize<Workshop<workshops>>(
            //    await response1.Content.ReadAsStringAsync());

            //Http requests och hämta ut vss info från api:t
            //https://docs.devexpress.com/eXpressAppFramework/403715/backend-web-api-service/use-odata-to-send-requests/use-http-client-to-access-web-api?p=net6
        }


    }
}