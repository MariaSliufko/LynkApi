//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using System.Net.Http.Headers;
//using Newtonsoft.Json;
//using LynkApi;

//namespace LynkApi //https://www.youtube.com/watch?v=3GhKdDCvtKE
//{
//    internal class ReloadAndSaveApiData
//    {
//        //static void Update()
//        //{
//        //    string path = @"C:\Users\masl\source\repos\LynkProject\LynkProject task\task.txt";
//                  

//path to where data is stored: C:\Users\masl\source\repos\LynkApi\LynkApi\bin\Debug\net6.0\data
// or: C:\Users\masl\source\repos\LynkApi\LynkApi\bin\Debug\net6.0\data

//        //    using StreamWriter sw = new StreamWriter(path, false);
//        //    Writer.WriteLine($"{DateTime.Now.ToString()} - This is running from a task");

//        //}
//        public async Task<string> Update() //När vi brutit ut metoden kan vi anropa metoden för att skapa tasken
//        {
//            var client = new HttpClient();
//            //var content = await client.GetStringAsync("")
//            var endpoint = new Uri("https://context-qa.lynkco.com/api/workshop/locations/");
//            var request = new HttpRequestMessage(HttpMethod.Get, endpoint); //requestmesssage med endpoint 
//            var token = "y2TpY8nt029M~OC3NdK7tXnpF";
//            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token); // en http har alltid en header, och den kan man fylla med värden, variabler med vad som helst, se headern som ett json objekt som man kan fylla med vad man vill

//            var result = client.SendAsync(request).Result; //skicka med http //Ska vara await?

//            string json = result.Content.ReadAsStringAsync().Result;

//            var myWorkshops = JsonConvert.DeserializeObject<WorkshopJSON>(json);

//            var content = await client.GetStringAsync(endpoint)
//                .ConfigureAwait(false); //vi bryr oss inte om vilken thread som fortsätter exekvering
//            var workshop = JsonConvert.DeserializeObject<Workshop>(content);

//            //lägg in att uppdatringen sparas i en separat fil
//            // tex File.WriteAllText(@"C:\Users\masl\source\repos\LynkProject\LynkProject\ListData.json", json);

//            return content;
//        }

//        public Task UpdateC()
//        {
//            return Task.CompletedTask;
//        }

//        public static void StartUpdate()
//        {
//            var collect = Collect();
//            //.ToList();
//            var process = Process();
//            Task.WaitAll(new[] { collect, process });
//            //return Task.WhenAll(new[] { collect, process });
//        }

//        public static async Task Collect() //Ska vvara await!
//        {
//            while (true)
//            {
//                //Lägg in i en try catch
//                //doing some internet stuff
//            }

//        }

//        public static async Task Process()
//        {
//            while (true)
//            {
//                //doing some database stuff
//                if (true)
//                {
//                    Task.Run(() => Notify("something"));
//                }
//            }

//        }

//        public static async Task Notify(string data)
//        {
//            //some network stuff
//        }

//    }
//}

