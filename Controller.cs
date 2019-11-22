using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    class Controller
    {
        Board board;
        Sudoku sudoku;
        Square square;
        Column column;
        Row row;
        IView view;

        public Controller(Board theBoard, Sudoku theSudoku, Square theSquare, Column theColumn, Row theRow, IView theView)
        {
            board = theBoard;
            sudoku = theSudoku;
            square = theSquare;
            column = theColumn;
            row = theRow;
            view = theView;
        }
        public void Setup()
        {
            view.Start();
            board.SetMaxValue(4);
            board.SetDifficulty(1);
            board.FromCSV(@"C:\board1.csv");
            board.Set(board.ToArray());

            view.Stop();

        }
        public void DisplaySudokuBoard()
        {
            view.Start();
            board.SetMaxValue(6);
            board.SetDifficulty(1);
            board.FromCSV(@"C:\board2.csv");
            board.Set(board.ToArray());
            view.Show(board.ToPrettyString());
            view.Show(sudoku.GetByColumn(1, 1));
            view.Show(row.IsRowCellValid(0));
            view.Show(row.IsRowComplete(0));
            view.Show(column.IsColumnComplete(0));
            view.Show(square.GetCellSquare(0));
            square.SetSubSquareIndex(0);
            view.Show(board.ToStringArray(square.GetSquareSubIndex()));
            view.Show("----------------------------------------------");
            //view.Show(square.IsSquareComplete(5));
            square.SetSquareSubArray(5);
            view.Show(board.ToStringArray(square.GetSquareSubArray()));
            view.Show(square.IsSquareComplete(5));
            
            view.Stop();

        }
    }
}
