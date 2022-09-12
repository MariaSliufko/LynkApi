using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using LynkApi;
using System.IO;


namespace LynkApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Startmenu start = new Startmenu();//Kallar på metoden för start meny.
            start.Start();//Kallar på metoden för att starta menyn.
        }
    }
}