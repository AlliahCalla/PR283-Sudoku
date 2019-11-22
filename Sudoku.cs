using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    public class Sudoku:IGet,ISet
    {
        Board board = new Board();
        private int[] sudokuArray;
        private int globalSize;

        public int GetByColumn(int columnIndex, int rowIndex)
        {
            sudokuArray = board.GetSudokuArray();
            globalSize = board.GetMaxValue();
            int index = columnIndex + (rowIndex * globalSize);
            int result = sudokuArray[index];
            return result;
        }

        public int GetByRow(int rowIndex, int columnIndex)
        {
            globalSize = board.GetMaxValue();
            sudokuArray = board.GetSudokuArray();
            int index = (rowIndex * globalSize) + columnIndex;
            int result = sudokuArray[index];
            return result;
        }

        public int GetBySquare(int squareIndex, int positionIndex)
        {
            sudokuArray = board.GetSudokuArray();
            globalSize = board.GetMaxValue();
            int result = 0;
            int noToSkip = globalSize / 2;
            int inputSquareIndex = squareIndex;
            int firstToSkip = 0;
            List<int> firstSkippedArray;
            int assign = 0;
            int max = (globalSize + noToSkip) - 1;
            int[] squareArray;
            if (inputSquareIndex > 1)
            {
                inputSquareIndex += noToSkip;
            }
            firstToSkip = inputSquareIndex * 2;
            firstSkippedArray = new List<int>(sudokuArray.Skip(firstToSkip));
            squareArray = new int[globalSize + noToSkip];

            for (int j = 0; j <= max; j++)
            {

                if (j == noToSkip)
                {
                    j = j + 2;
                }

                squareArray[assign] = firstSkippedArray[j];
                assign++;


            }
            result = squareArray[positionIndex];
            return result;
        }


        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            sudokuArray = board.GetSudokuArray();
            globalSize = board.GetMaxValue();
            int result = columnIndex + (globalSize * rowIndex);
            sudokuArray[result] = value;
            
        }

        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            globalSize = board.GetMaxValue();
            sudokuArray = board.GetSudokuArray();
            int result = (rowIndex * globalSize) + columnIndex;
            sudokuArray[result] = value;
        }

        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            globalSize = board.GetMaxValue();
            sudokuArray = board.GetSudokuArray();
            int result = 0;
            int inputSquare = squareIndex;
            int half = globalSize / 2;
            int adder = 1;
            //int noToSkip = (globalSize / 2)+(globalSize*2);=10
            int noToSkip = (inputSquare * 2);
            int start = 0;
            int assign = 0;
            int max = (globalSize * half) - (half + adder);
            int[] indexArray;
            int sudokuIndex;
            if (inputSquare > 0)
            {
                start = noToSkip;
                max = max + squareIndex + adder;

            }
            if (inputSquare > 1)
            {
                start = (start + globalSize);

            }

            indexArray = new int[globalSize];
            for (int j = start; j <= start + (globalSize + 1); j++)
            {

                if (j == start + half)
                {
                    j = j + half;
                }

                indexArray[assign] = j;
                assign++;


            }
            sudokuIndex = indexArray[positionIndex];
            sudokuArray[sudokuIndex] = value;
        }

       
    }
}
