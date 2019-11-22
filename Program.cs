using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    class Program
    {
        static void Main(string[] args)
        {
            new Controller(new Board(), new Sudoku(), new Square(), new Column(), new Row(), new ConsoleView()).DisplaySudokuBoard();

        }
    }
}
