using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LynkApi
{
    public class ConsoleLineUpdater
    {
        private string _text = ""; //Empty string
        private string _dots = "";
        private bool _done = false;
        public void start(string text)
        {
            Console.Clear(); //used to clear screen and console buffer
            _text = text;
            _dots = "";
            while (!_done)
            {
                _dots += ". ";
                Console.Write($"\rCurrent process: {_text}{_dots}");
                Thread.Sleep(500); //temporarily suspends the current execution of the thread for specified milliseconds,
                                   //so that other threads can get the chance to start the execution
            }
        }
        public void setText(string text)
        {
            _dots = "";
            Console.Clear();
            updateText(text);
        }

        public void updateText(string text) // added so it dosent clear just uppdates the dots
        {
            _text = text;
            Console.Write($"\rCurrent process: {_text}{_dots}");
        }
        public void done()
        {
            _done = true;
            Console.Clear();
            Console.Write($"\rCurrent process: DONE!"); // \moves cursor back to beginning of line to overwrite with new content
            Console.WriteLine();

            Console.WriteLine("\nPress any key to return to menu");
            Console.ReadKey(true);
            Console.Clear();
            Startmenu.Menu();
        }
    }
}
