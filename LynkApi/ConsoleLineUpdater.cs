using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LynkApi
{
    public class ConsoleLineUpdater
    {
        private readonly int _units;
        private readonly double _steps;
        private readonly int _milliSec;

        public ConsoleLineUpdater(int units, double steps, int milliSec) //constructer with parameters
        {
            _units = units;
            _steps = steps;
            _milliSec = milliSec;
        }


        public void RunSimulation() //method
        {
            double stepSize = _units / _steps;
            int sleepMillisec = (int)(0.4 * _milliSec / _steps);

            for (int i = 0; i <= _units; i++)
            {
                StringBuilder filledProgressSpace = new StringBuilder();

                int filledSteps = 0;
                for (double j = 0; j < i; j += stepSize)
                {
                    filledProgressSpace.Append("=");
                    filledSteps++;
                }

                StringBuilder emptyProgressSpace = new StringBuilder();

                double absDifference = Math.Abs(i / stepSize - _steps);
                if (absDifference >= 1)
                {
                    emptyProgressSpace.Append(">");
                    filledSteps++;
                }

                for (double j = 0; j < _steps - filledSteps; j++) emptyProgressSpace.Append(" ");


                Console.Write($"\rThe current progress: [{filledProgressSpace}{emptyProgressSpace}] {i}% ");
                Thread.Sleep(sleepMillisec);

            }
        }


    }
}
