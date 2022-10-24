using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LynkApi
{
    public class ExitLynk
    {
        public static void ExitProgram()
        {
            Console.Write("Press any key to exit the program");
            Console.ReadKey(true);
            Console.Clear();
            Environment.Exit(0);
        }
    }
}
