using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    class ConsoleView :IView
    {
        public string Get(string prompt)
        {
            Console.WriteLine();
            return Console.ReadLine();
        }


        public void Show<T>(T message)
        {
            Console.WriteLine(message);
        }


        public void Start()
        {
            Console.Clear();
        }

        public void Stop()
        {
            Console.WriteLine("Press Enter to Exit");
            Console.ReadKey();
        }
    }
}
