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
        public string Query { get; } //?
        
        public async Task<IEnumerable<WorkshopModel>?> GetWorkshops() //async makes sure that our website doesnt lock up. IEnumerable supports a simple iteration over a (non-generic) collection.
        {
            //variabel workshopUri
            var workshopUri = new Uri(BaseAddress, "locations/"); //puts together baseadress and endpoint
            
            using (HttpResponseMessage response = await Client.GetAsync(workshopUri)) //new call/request from our api client and wait for response
            {
                if (response.IsSuccessStatusCode) //If successfull do something with it (read the data that came back)
                {
                    string json = await response.Content.ReadAsStringAsync(); //awaits the response and content is the content of my request
                    var myWorkshops = JsonConvert.DeserializeObject<WorkshopJSON>(json); //deserialize 
                    return myWorkshops?.WorkshopList;
                   
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task<IEnumerable<VehicleModel>?> GetVehicles(string workshopId) // get V metoden 
        {

            var appointmentUri = new Uri(BaseAddress, "vehicles/?location=" + workshopId);


            using (HttpResponseMessage response = await Client.GetAsync(appointmentUri))
            {

                if (response.IsSuccessStatusCode)
                {
                    
                    string json = await response.Content.ReadAsStringAsync();
                    var myVechicles = JsonConvert.DeserializeObject<VehicleJSON>(json);
                    return myVechicles?.VehicleList; //returns list of vehicles
                }
                else
                {
                    throw new Exception(response.ReasonPhrase); //initializes a new instance of exception class with response phrase sent by server and statuscode.
                }
            }


        }
        public async Task<IEnumerable<AppointmentModel>?> GetAppointments(string workshopId)
        {

            var appointmentUri = new Uri(BaseAddress, "appointments/?location=" + workshopId);

            
            using (HttpResponseMessage response = await Client.GetAsync(appointmentUri))
            {
                
                    if (response.IsSuccessStatusCode)
                    {

                        string json = await response.Content.ReadAsStringAsync();
                        var myAppointments = JsonConvert.DeserializeObject<AppointmentJSON>(json);
                        return myAppointments?.AppointmentList;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
            }
               
              
            

        }

        public async Task<IEnumerable<AppointmentModel>?> GetAllAppointments()
        {

            var appointmentUri = new Uri(BaseAddress, "appointments/");

            //https://context-qa.lynkco.com/api/workshop/appointments?location=all

            using (HttpResponseMessage response = await Client.GetAsync(appointmentUri))
            {

                if (response.IsSuccessStatusCode)
                {

                    string json = await response.Content.ReadAsStringAsync();
                    var myAppointments = JsonConvert.DeserializeObject<AppointmentJSON>(json);
                    return myAppointments?.AppointmentList;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }




        }

    }
}
