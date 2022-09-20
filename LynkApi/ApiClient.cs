﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using LynkApi;

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

        //public async Task<IEnumerable<Workshop>> GetWorkshops()
        //{
        //    string endpoint = "workshops/vsdflmövsd"
        //}

        //public async Task<IEnumerable<Appointment>> GetAppointments(string workshopId)
        //{
        //}

        //public static void ApplyHeaders(HttpRequestMessage request)
        //{
        //    ApiClient = new HttpClient();
        //    ApiClient.BaseAddress = new Uri("https://context-qa.lynkco.com/api/workshop");
        //    ApiClient.DefaultRequestHeaders.Accept.Clear();
        //    ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // To just look for the json in the app



        //}
    }
}
