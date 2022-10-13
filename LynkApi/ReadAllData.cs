using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLynk;

namespace LynkApi
{
    public class ReadAllData
    {
        public static void ListWorkshops()
        {
            string dataDirectyory = Path.Combine(Path.GetDirectoryName((typeof(Program).Assembly.Location)) ?? string.Empty, @"data\workshops"); // skapar filvägen
            string[] path = Directory.GetFiles(dataDirectyory);

            foreach (string filename in path) //skapar en lista med varje filnamn till de workshops som finns i foldern
            {
                Console.WriteLine(filename);
            }

            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //a method that gets the path to specified folder
            StringBuilder sb = new StringBuilder(); //doesn’t create a new object in the memory but dynamically expands the needed memory to accommodate the modified or new string.
            //foreach path in folder do something
            foreach (string jsonName in Directory.GetFiles(dataDirectyory, "*.json")) //C:\Users\masl\source\repos\LynkApi\LynkApi\bin\Debug\net6.0\data\workshops\1.json
            {
                //initializez a new streamreader that takes in the construktor the file to open
                using (StreamReader sr = new StreamReader(jsonName)) //reader is for pullinf info out of the file and writer to put info in //using will dispose the stuff in the block
                {
                    sb.AppendLine(jsonName.ToString()); //reads the path in string format
                    sb.AppendLine("= = = = = ="); // writes out === between the path and content
                    sb.Append(sr.ReadToEnd()); // reads all content
                    sb.AppendLine(); //This method append(adds) the string with a newline at the end
                    sb.AppendLine();

                }
            }

            // var Workshop = JsonConvert.SerializeObject(sb);
           // var objResponse = JsonConvert.DeserializeObject<List<WorkshopModel>>(sb);
            using (StreamWriter outfile = new StreamWriter(mydocpath + @"\AllTxtFiles.json")) //puts my docpath and looks at all json files
            {
                outfile.Write(sb.ToString()); //StreamWriter.Write() method is responsible for writing text to a stream. 
                Console.WriteLine(sb.ToString());
            }

           

        }
    }
}











    

