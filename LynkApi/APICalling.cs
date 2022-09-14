
using LynkApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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

        static string dataDirectyory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, "data.json"); // vår fil skapas ej

        public static async void Calling()
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


                if (File.Exists(dataDirectyory)) // kollar om filen finns, om den finns gör den nedan
                    File.Delete(dataDirectyory); // tar bort filen om den finns


                using (StreamWriter sw = new StreamWriter(dataDirectyory))
                { // skapar och skiver filen
                    sw.WriteLine("["); // lägger till i början för att skapa en lista

                    if (myWorkshops != null && myWorkshops.Workshops != null) // kollar om den är null
                    {

                        for (int i = 0; i < myWorkshops.Workshops.Count; i++) //loopar igenom filen
                        {
                            var workshop = myWorkshops.Workshops[i];
                            sw.Write($"{{\"LocationId\" : \"{workshop.LocationId}\", \"BackOfficeWorkshopId\" : \"{workshop.BackOfficeWorkshopId}\", \"DisplayName\" : \"{workshop.DisplayName}\", \"TimeZone\" :  \"{workshop.TimeZone}\" }}"); // skriver ut och formaterar filen
                            if (i != myWorkshops.Workshops.Count - 1) // kollar om det är sista elementet i listan tar isf bort sista , tecknet
                                sw.WriteLine(","); // lägger till , tecknet
                        }

                        sw.WriteLine("\n]"); // skriver ut en ny rad med en hakparantes
                    }

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("\nPress any key to return to menu");
                Console.ReadKey(true);
                Console.Clear();
                //Startmenu.Menu();
            }
            finally
            {
                client.Dispose();
            }
        }

        //public static void List()
        //{
        //    string line = "";
        //    using (StreamReader sr = new StreamReader(dataDirectyory))
        //    { // skriver ut datan som finns i filen utan att upåpdatera den

        //        while ((line = sr.ReadLine()) != null)
        //        { // om den börjar med en måsvinge så körs det, då skriver den ut objekten fint, detta funkar bara nu när det är formaterat så fint
        //            if (!line.StartsWith("{"))
        //                continue;

        //            var obj = JObject.Parse(line.Substring(0, line.Length - 1)); //läser in denna linen som ett json objekt
        //            Console.WriteLine(obj); // skruver ut det snyggt pga jobjekt classen

        //        }
        //    }
        //}
    }
}