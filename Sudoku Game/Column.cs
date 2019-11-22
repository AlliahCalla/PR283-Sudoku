using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Game
{
    class Column:IColumn
    {
        private int[] colSubArray;
        private int[] colSubIndex;
        Board board = new Board();
        Sudoku sudoku = new Sudoku();
        public int GetCellCol(int cellNumber)
        {
            int globalSize = board.GetMaxValue();
            int cellCol = 0;
            for (int i = 0; i < globalSize; i++)
            {
                SetSubColumnIndex(i);
                if (colSubIndex.Contains(cellNumber))
                {
                    cellCol = i;

                }

            }
            return cellCol;
        }

        public List<int> GetInvalidColumn()
        {
            int globalSize = board.GetMaxValue();
            int max = globalSize - 1;
            int index = 0;
            List<int> invalidCol = new List<int>();
            for (int i = 0; i <= max; i++)
            {


                if (IsColumnValid(i) == false)
                {
                    invalidCol.Add(i);
                }
            }

            return invalidCol;

        }

        public bool IsColCellValid(int cellNumber)
        {
            int[] sudokuArray = board.GetSudokuArray();
            int globalSize = board.GetMaxValue();
            int col = GetCellCol(cellNumber);
            SetColSubArray(col);
            int count = 0;
            bool result = true;
            for (int i = 0; i < colSubArray.Length; i++)
            {
                if (colSubArray[i] == sudokuArray[cellNumber])
                {

                    count++;
                }
            }
            if (count > 1 || sudokuArray[cellNumber] == 0 || sudokuArray[cellNumber] > globalSize)
            {
                result = false;
            }

            return result;
        }

        public bool IsColumnComplete(int colNumber)
        {
            int globalSize = board.GetMaxValue();
            SetColSubArray(colNumber);
            List<int> arr_list = colSubArray.OfType<int>().ToList();

            bool isOutOfRange = false;
            bool isNotBlank = true;

            for (int i = 0; i < globalSize; i++)
            {
                if (colSubArray[i] > globalSize)
                {

                    isOutOfRange = true;

                }
                if (colSubArray[i] == 0)
                {
                    isNotBlank = false;

                }



            }
            bool isUnique = arr_list.Distinct().Count() == arr_list.Count();
            bool result = isUnique && isNotBlank && !isOutOfRange;
            return result;
        }

        public bool IsColumnValid(int colNumber)
        {
            int globalSize = board.GetMaxValue();
            SetColSubArray(colNumber);
            List<int> arr_list = colSubArray.OfType<int>().ToList();

            bool isOutOfRange = false;
            bool isNotBlank = IsColumnComplete(colNumber);
            for (int i = 0; i < globalSize; i++)
            {
                if (colSubArray[i] > globalSize)
                {

                    isOutOfRange = true;

                }



            }
            bool isUnique = arr_list.Distinct().Count() == arr_list.Count();
            bool result = isUnique && isNotBlank && !isOutOfRange;
            return result;
        }

        public int[] SetColSubArray(int colNumber)
        {
            int globalSize = board.GetMaxValue();
            colSubArray = new int[globalSize];
            int max = globalSize - 1;

            for (int i = 0; i <= max; i++)
            {

                colSubArray[i] = sudoku.GetByColumn(colNumber, i);
            }
            return colSubArray;
        }

        public int[] SetSubColumnIndex(int colNumber)
        {
            int globalSize = board.GetMaxValue();
            colSubIndex = new int[globalSize];
            int skipper = colNumber;
            for (int i = 0; i < globalSize; i++, skipper += globalSize)
            {
                colSubIndex[i] = skipper;

            }
            return colSubIndex;

        }
    }
}
