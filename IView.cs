using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    interface IView
    {
        string Get(string prompt);
        void Show<T>(T message);
        void Start();
        void Stop();
    }
}
