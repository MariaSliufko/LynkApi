using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using LynkApi;



//main ska vara static async Task Main(string[] args)?


using (var client = new HttpClient())
//Instansierar en ny HttpClient instans med syntaxen för objektinitieraren och som en användningsdeklaration.

{
    var endpoint = new Uri("https://context-qa.lynkco.com/api/workshop/locations/"); // gör om alla api anrop till en separat klass

    try
    {
        var request = new HttpRequestMessage(HttpMethod.Get, endpoint); //requestmesssage med endpoint 
        var token = "y2TpY8nt029M~OC3NdK7tXnpF";
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token); // en http har alltid en header, och den kan man fylla med värden, variabler med vad som helst, se headern som ett json objekt som man kan fylla med vad man vill

        var result = client.SendAsync(request).Result; //skicka med http //Ska vara await?
        
        string json = result.Content.ReadAsStringAsync().Result;
        
        var myWorkshops = JsonConvert.DeserializeObject<WorkshopJSON>(json); // 
        
        //skriv ut array med objecten med foreach loop
        foreach (var workshop in myWorkshops.workshops)
        {
            Console.WriteLine($"[{workshop.LocationId}, {workshop.BackOfficeWorkshopId}, {workshop.DisplayName}, {workshop.TimeZone} ");

        }

    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }

    finally
    {
        //disposa httpClient
        client.Dispose();
    }





}
