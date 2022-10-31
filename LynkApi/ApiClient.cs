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
using static LynkApi.AppointmentModel;
using System.Reflection.Metadata;
using static LynkApi.VehicleModel;

namespace LynkApi
{
    public class ApiClient
    {
        public ApiClient(Uri baseAddress, string apiToken) //konstruktor
        {
            if (string.IsNullOrEmpty(apiToken))
            {
                throw new ArgumentException($"'{nameof(apiToken)}' cannot be null or empty.", nameof(apiToken));
            }

            this.BaseAddress = baseAddress ?? throw new ArgumentNullException(nameof(baseAddress));
            this.Client = new HttpClient();
            this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);  //authentication header
        }

        public HttpClient Client { get; } //properties
        public Uri BaseAddress { get; }
        public string Query { get; }
        public string Next { get; set; } = string.Empty;
        string? next = null;

        public async Task<IEnumerable<WorkshopModel>?> GetWorkshops() //async makes sure that our website doesnt lock up. IEnumerable supports a simple iteration over a (non-generic) collection.
        {
            var list = new List<WorkshopModel>();
            //string? next = null;

            do
            {
                //variabel workshopUri
                // var workshopUri = new Uri(BaseAddress, "locations/?all"); //puts together baseadress and endpoint
                var relative = "locations/?all";
                if (next != null)
                {
                    relative += "next" + next;
                }

                var workshopUri = new Uri(BaseAddress, relative);
                using (HttpResponseMessage response = await Client.GetAsync(workshopUri)) //new call/request from our api client and wait for response
                {
                    if (response.IsSuccessStatusCode) //If successfull do something with it (read the data that came back)
                    {
                        string json = await response.Content.ReadAsStringAsync(); //awaits the response and content is the content of my request
                        var myWorkshops = JsonConvert.DeserializeObject<WorkshopJSON>(json); //deserialize 
                        //return myWorkshops?.WorkshopList;

                        list.AddRange(myWorkshops.WorkshopList);
                        next = myWorkshops.Next;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            } while (next != null);
        

            return list;
            
        }

        public async Task<IEnumerable<VehicleModel>?> GetVehicles(string workshopId) // get V metoden 
        {
            var list = new List<VehicleModel>();

            do
            {
                var relative ="vehicles/?location=" + workshopId + "&all";
                if (next != null)
                {
                    relative += "&next" + next;
                }

                var appointmentUri = new Uri(BaseAddress, relative);
                using (HttpResponseMessage response = await Client.GetAsync(appointmentUri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var myVechicles = JsonConvert.DeserializeObject<VehicleJSON>(json);
                        // return myVechicles?.VehicleList; //returns list of vehicles

                        list.AddRange(myVechicles.VehicleList);
                        next = myVechicles.Next;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase); //initializes a new instance of exception class with response phrase sent by server and statuscode.
                    }
                }
            } while (next != null);
            return list;
        }
        
        public async Task<IEnumerable<AppointmentModel>?> GetAppointments(string workshopId)
        {
            var list = new List<AppointmentModel>(); //adds empty list
           // string? next = null;

            do
            {
                var relative = "appointments/?location=" + workshopId + "&all";
                if (next != null)
                {
                    relative += "&next=" + next;
                }

                var appointmentUri = new Uri(BaseAddress, relative); //
                using (HttpResponseMessage response = await Client.GetAsync(appointmentUri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var myAppointments = JsonConvert.DeserializeObject<AppointmentJSON>(json);

                        list.AddRange(myAppointments.AppointmentList);
                        next = myAppointments.Next;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            } while (next != null);

            return list;
        }
    }
}
