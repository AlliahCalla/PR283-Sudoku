using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Game
{
    public class Controller
    {
        protected IView view;
        protected Board board;
        protected Sudoku sudoku;
        protected Square square;
        protected Column column;
        protected Row row;

        public Controller(IView theView,Board theBoard, Sudoku theSudoku, Square theSquare, Column theColumn, Row theRow)
        {
            view = theView;
            view.SetController(this);
            board = theBoard;
            sudoku = theSudoku;
            square = theSquare;
            column = theColumn;
            row = theRow;
        }

        /*Board Functionalities*/
        public void SetCellValues(int newValue, int index)
        {
            //board in WhoClicked - Form1 - SetCell
            board.SetCell(newValue, index);
        }


        public int[] GetSudokuCells()
        {
            int size = this.GetSudokuSize();
            int[] cellsArray = new int[size];
            //board in WhoClicked - Form1 - GetSudokuArray
            cellsArray = board.GetSudokuArray();
            return cellsArray;


        }


        public int GetSudokuSize()
        {
            int size = 0;
            // board in Create Buttons. Form1 - GetMaxValue
            size = board.GetMaxValue();
            return size;

        }

        public int[] GetLoadedArray()
        {
            int size = this.GetSudokuSize();
            int[] loadedArray = new int[size];
            //board in CreateButtons - Form 1 - GetSudokuArray
            loadedArray = board.GetSudokuArray();
            return loadedArray;


        }

        public int[] GetArraySolution()
        {
            int size = this.GetSudokuSize();
            int[] solution = new int[size];
            //board inn CheckSudoku - Form1 - GetSudokuSolution
            solution = board.GetSudokuSolution();
            return solution;

        }

        

        /* Square Functionalities*/

        public int GetCellSquareNum(int cellNum)
        {
            int squareNum = 0;
            //In SquareToGreen - Form1 - GetCellSquare
            squareNum = square.GetCellSquare(cellNum);
            return squareNum;
        }

        public int[] GetSquareIndexes(int squareNumber)
        {
            int size = this.GetSudokuSize();
            int[] indexes = new int[size];
            //InSquare to Green, SquareToWhite - Form1 - SetSubSquareIndex();
            indexes = square.SetSubSquareIndex(squareNumber);
            return indexes;
           

        }

        public bool CheckSquareComplete(int squareNumber)
        {
            bool result = false;
            // In CheckStatus - Form1- IsSquareComplete
            result = square.IsSquareComplete(squareNumber);
            return result;

        }

        /*Column Functionalities*/

        public int GetCellColNum(int cellNum)
        {
            int colNum = 0;
            //In ToGreen - Form1 - GetCellCol
            colNum = column.GetCellCol(cellNum);
            return colNum;
        }

        public int[] GetColIndexes(int colNumber)
        {
            int size = this.GetSudokuSize();
            int[] indexes = new int[size];
            //InCol to Green, ColToWhite - Form1 - SetSubColIndex();
            indexes = column.SetSubColumnIndex(colNumber);
            return indexes;


        }

        public bool CheckColComplete(int colNumber)
        {
            bool result = false;
            // In CheckStatus - Form1- IsColComplete
            result = column.IsColumnComplete(colNumber);
            return result;

        }

        /*Row Functionalities*/

        public int GetCellRowNum(int cellNum)
        {
            int rowNum = 0;
            //In ToGreen - Form1 - GetCellRow
            rowNum = row.GetCellRow(cellNum);
            return rowNum;
        }

        public int[] GetRowIndexes(int rowNumber)
        {
            int size = this.GetSudokuSize();
            int[] indexes = new int[size];
            //InRow to Green, RowToWhite - Form1 - SetSubRowIndex();
            indexes = row.SetSubRowIndex(rowNumber);
            return indexes;


        }

        public bool CheckRowComplete(int rowNumber)
        {
            bool result = false;
            // In CheckStatus - Form1- IsRowComplete
            result = row.IsRowComplete(rowNumber);
            return result;

        }

        public string GetArrayString(int[] array)
        {
            string result = board.ToStringArray(array);
            return result;

        }


        public bool CheckSudoku()
        {
            string solution = board.ToStringArray(board.GetSudokuSolution());//GetArrayString and GetArraySolution
            string input = board.ToStringArray(board.GetSudokuArray());//GetArrayString and GetLoadedArray

            bool result = input.SequenceEqual(solution);

            return result;

        }



    }
}
