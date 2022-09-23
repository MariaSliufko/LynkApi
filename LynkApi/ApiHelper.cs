using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LynkApi
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; } = new HttpClient();
        //public static string ApiUrl { get; set; } = 

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://context-qa.lynkco.com/api/workshop/");
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer, ApiToken");
           // ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); //Header saying give me json. not exhtml

        }

    }
}
