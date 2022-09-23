using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using LynkApi;
using System.Net;
using Newtonsoft.Json;
using TestLynk;

namespace LynkApi
{
    public class ApiClient
    {
        public ApiClient(Uri baseAddress, string apiToken)
        {
            if (string.IsNullOrEmpty(apiToken))
            {
                throw new ArgumentException($"'{nameof(apiToken)}' cannot be null or empty.", nameof(apiToken));
            }

            this.BaseAddress = baseAddress ?? throw new ArgumentNullException(nameof(baseAddress));
            this.ApiToken = apiToken;

            this.Client = new HttpClient();
        }

        public HttpClient Client { get; }

        public Uri BaseAddress { get; }

        public string ApiToken { get; }

        
        public async Task<IEnumerable<Workshop>?> GetWorkshops()
        {
            //var response = await this.Client.GetAsync(ApiToken);
            //var workshops = new List<Workshop>();
            

            ////}
            //var workshopUri = this.BaseAddress.ToString();
            //var apiToken = this.ApiToken;
            //var request = new HttpRequestMessage(HttpMethod.Get, workshopUri);
            
            
                var workshopUri = new Uri(BaseAddress, "api/workshop/locations/");
                var request = new HttpRequestMessage(HttpMethod.Get, workshopUri);
                var result = Client.SendAsync(request).Result;
                string json = result.Content.ReadAsStringAsync().Result;
                var html = await result.Content.ReadAsStringAsync();
                var myWorkshops = JsonConvert.DeserializeObject<WorkshopJSON>(json);
                return (IEnumerable<Workshop>?)result;




            //var workshop = await this.Client.GetAsync(workshopUri);

            //return Workshop;
            // return await Task.FromResult(Workshop);
            //string endpoint = "api/workshop/locations/"; //https://api-qa.sigmaorigo.com/workshop/tags/workshops/get-location-list
        }

        public async Task<IEnumerable<Appointment>> GetAppointments(string workshopId)
        {
            var appointmentUri = new Uri(BaseAddress, "api/workshop/locations/");
            var appointment = await this.Client.GetAsync(appointmentUri);
            return (IEnumerable<Appointment>)appointment;



           // string endpoint = "api/workshop/appointments/"; // https://api-qa.sigmaorigo.com/workshop/tags/appointments/get-appointment-list
        }

        public static async void ApplyHeaders(HttpRequestMessage request)
        {
            var baseAddress = new Uri("https://context-qa.lynkco.com/api/workshop/");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer, ApiToken");
            



           // private const string ApiToken = "y2TpY8nt029M~OC3NdK7tXnpF"; Vart ska nyckelmn finnas?
           


        //    ApiClient = new HttpClient();
        //    ApiClient.BaseAddress = new Uri("https://context-qa.lynkco.com/api/workshop");
        //    ApiClient.DefaultRequestHeaders.Accept.Clear();
        //    ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // To just look for the json in the app

        //Här är basur och i metoderna ska vi lägga till bas + det specifika för tex get workshop, get apoinment

    }
    }
}
