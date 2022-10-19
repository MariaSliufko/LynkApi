using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LynkApi
{
    public class ConsoleLineUpdater
    {

        private string _text = "";
        private string _dots = "";
        private bool _done = false;
        public void start(string text)
        {
            Console.Clear();
            _text = text;
            _dots = "";
            while (!_done)
            {
                _dots += ". ";
                Console.Write($"\rCurrent process: {_text}{_dots}");
                Thread.Sleep(500);
            }
        }
        public void setText(string text)
        {
            _text = text;
            _dots = "";
            Console.Clear();
            Console.Write($"\rCurrent process: {_text}{_dots}");
        }
        public void done()
        {
            _done = true;
            Console.Clear();
            Console.Write($"\rCurrent process: DONE!");
            Console.WriteLine();
        }
    }
}
