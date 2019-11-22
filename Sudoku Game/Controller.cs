using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Game
{
    class Controller
    {
        Board board;
        Sudoku sudoku;
        Square square;
        Column column;
        Row row;
        public Controller(Board theBoard, Sudoku theSudoku, Square theSquare, Column theColumn, Row theRow)
        {
            board = theBoard;
            sudoku = theSudoku;
            square = theSquare;
            column = theColumn;
            row = theRow;
        }

        public void Setup()
        {
            

        }


    }
}
