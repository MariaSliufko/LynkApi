using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using LynkApi;
using System.IO;


namespace TestLynk
{
    class Program
    {
        static void Main(string[] args)
        {
                Startmenu start = new Startmenu();//Kallar på metoden för start meny.
                start.Start();//Kallar på metoden för att starta menyn.

        //    ApiClient api = new ApiClient(new Uri("https://context-qa.lynkco.com/api/workshop/"), "y2TpY8nt029M~OC3NdK7tXnpF"); //Skickar med urii till konstruktorn
        //    var result =  api.GetWorkshops().Result;
        //    foreach (var workshop in result ?? new List<Workshop>())
        //    {
        //        Console.WriteLine(workshop.DisplayName);
        //    }
            
        //}
    }
}