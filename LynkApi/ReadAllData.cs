using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLynk;
using System.IO;

namespace LynkApi
{
    public class ReadAllData
    {

       
        public bool ReadAllDataNow(string fileName) //method that takes in parameter string filename
        {
            string dataDirectory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, @"data\workshops"); // creates pathway
            string[] path = Directory.GetFiles(dataDirectory); // directory = method for enumering through directory. Returns array of full name + paths for files in directory

            //foreach (string filename in path) //Generates a list of pathwaynames for the files in folder workshop
            //{
            //    Console.WriteLine(filename);
            //}

            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //method to get specified folder
            
            foreach (var file in Directory.EnumerateFiles(dataDirectory, "*.json")) //foreach file in specified folder. Loops through all
            {
                var readFiles = File.ReadAllText(file); //opens textfile, reads it and closes it
                var serializedObj = JsonConvert.SerializeObject(readFiles); //Jsonconvert - method for converting between .NET types and json 
               //deserializes json to specefied .NET type and returns deserilaized object from json string
                WorkshopModel deserializedObj = JsonConvert.DeserializeObject<WorkshopModel>(readFiles);
                Console.WriteLine("Location - " + deserializedObj.LocationId);
                Console.WriteLine("Back Office Workshop ID ---" + deserializedObj.BackOfficeWorkshopId);
                Console.WriteLine("Timezone ---" + deserializedObj.TimeZone);
                Console.WriteLine("Display name ---" + deserializedObj.DisplayName);
                foreach (string obj in deserializedObj.Appointments)
                {
                    Console.WriteLine("Appointment ---" + obj); //writes out appointment id
                }
            }
           
            Console.ReadLine();
            return false;




        }
    }
}











    

