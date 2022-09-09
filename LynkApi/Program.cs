using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using LynkProject;



//main ska vara static async Task Main(string[] args)?


using (var client = new HttpClient())
//Instansierar en ny HttpClient instans med syntaxen för objektinitieraren och som en användningsdeklaration.

{
    //string key = "y2TpY8nt029M~OC3NdK7tXnpF";
    //string key = Environment.GetEnvironmentVariable("API_KEY");
    //var endpoint = new Uri("https://context-qa.lynkco.com/api/workshop/locations?api_key={key}"); //posts


    var endpoint = new Uri("https://context-qa.lynkco.com/api/workshop/locations/"); // gör om alla api anrop till en separat klass

    try
    {
        var request = new HttpRequestMessage(HttpMethod.Get, endpoint); //requestmesssage med endpoint //Ska vara await?
        var token = "y2TpY8nt029M~OC3NdK7tXnpF";
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token); // en http har alltid en header, och den kan man fylla med värden, variabler med vad som helst, se headern som ett json objekt som man kan fylla med vad man vill

        var result = client.SendAsync(request).Result; //skicka med http //Ska vara await?
        Console.WriteLine(result);
        Console.ReadLine();

        var json = result.Content.ReadAsStringAsync().Result;
        Console.WriteLine(json);

        //Deserialize json response till c# array av typen Post[]
        var myWorkshops = JsonConvert.DeserializeObject<Workshop[]>(json);
        //skriv ut array med objecten med foreach loop
        foreach (var workshop in myWorkshops)
        {
            Console.WriteLine($"[{workshop.LocationId} {workshop.BackOfficeWorkshopId} {workshop.DisplayName} {workshop.TimeZone}");
            //Console.ReadLine();
        }


    }
    catch (Exception e)
    {
        Console.WriteLine(e);

    }
    //finally 
    //{
    //    //disposa httpClient
    //    httpClient.Dispose();
    //}





}


