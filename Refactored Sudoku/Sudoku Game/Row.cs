using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Game
{
    public class Row:IRow
    {
        private int[] rowSubArray;
        private int[] rowSubIndex;

        Board board = new Board();

        public int GetCellRow(int cellNumber)
        {
            int globalSize = board.GetMaxValue();
            int cellRow = 0;
            for (int i = 0; i < globalSize; i++)
            {
                SetSubRowIndex(i);
                if (rowSubIndex.Contains(cellNumber))
                {
                    cellRow = i;

                }

            }
            return cellRow;

        }

        public List<int> GetInvalidRow()
        {
            int globalSize = board.GetMaxValue();
            int max = globalSize - 1;
            int index = 0;
            List<int> invalidRow = new List<int>();
            for (int i = 0; i <= max; i++)
            {


                if (IsRowValid(i) == false)
                {
                    invalidRow.Add(i);
                }
            }

            return invalidRow;
        }

        public bool IsRowCellValid(int cellNumber)
        {
            int[] sudokuArray = board.GetSudokuArray();
            int globalSize = board.GetMaxValue();
            int row = GetCellRow(cellNumber);
            SetRowSubArray(row);
            int count = 0;
            bool result = true;
            for (int i = 0; i < rowSubArray.Length; i++)
            {
                if (rowSubArray[i] == sudokuArray[cellNumber])
                {

                    count++;
                }
            }
            if (count > 1 || sudokuArray[cellNumber] == 0 || sudokuArray[cellNumber] > globalSize)
            {
                result = false;
            }
            Console.WriteLine(sudokuArray[cellNumber]);
            Console.WriteLine(globalSize);

            return result;
        }

        public bool IsRowComplete(int rowNumber)
        {
            int globalSize = board.GetMaxValue();
            SetRowSubArray(rowNumber);
            List<int> arr_list = rowSubArray.OfType<int>().ToList();

            bool isOutOfRange = false;
            bool isNotBlank = true;
            for (int i = 0; i < globalSize; i++)
            {
                if (rowSubArray[i] > globalSize)
                {

                    isOutOfRange = true;

                }
                if (rowSubArray[i] == 0)
                {
                    isNotBlank = false;

                }



            }
            bool isUnique = arr_list.Distinct().Count() == arr_list.Count();
            bool result = isUnique && isNotBlank && !isOutOfRange;
            return result;
        }

        public bool IsRowValid(int rowNumber)
        {
            int globalSize = board.GetMaxValue();
            SetRowSubArray(rowNumber);
            List<int> arr_list = rowSubArray.OfType<int>().ToList();

            bool isOutOfRange = false;
            bool isNotBlank = IsRowComplete(rowNumber);
            for (int i = 0; i < globalSize; i++)
            {
                if (rowSubArray[i] > globalSize)
                {

                    isOutOfRange = true;

                }



            }
            bool isUnique = arr_list.Distinct().Count() == arr_list.Count();
            bool result = isUnique && isNotBlank && !isOutOfRange;
            return result;
        }

        public int[] SetRowSubArray(int rowNumber)
        {
            int[] sudokuArray = board.GetSudokuArray();
            int globalSize = board.GetMaxValue();
            rowSubArray = new int[globalSize];
            int start = 0;
            int finish = 0;
            int digit = 0;

            int product = (rowNumber + 1) * globalSize;
            finish = product - 1;

            start = finish - (globalSize - 1);

            int count = 0;
            for (int i = 0; i < globalSize; i++)
            {
                rowSubArray[i] = sudokuArray[start];

                start++;


            }
            return rowSubArray;
        }

        public int[] SetSubRowIndex(int rowNumber)
        {
            int globalSize = board.GetMaxValue();
            rowSubIndex = new int[globalSize];
            int end = ((rowNumber + 1) * globalSize) - 1;
            int start = end - (globalSize - 1);

            for (int i = 0; i < globalSize; i++)
            {
                rowSubIndex[i] = start;
                start++;

            }
            return rowSubIndex;

        }

        public int[] GetSubIndex(int rowNumber)
        {
            SetSubRowIndex(rowNumber);
            return rowSubIndex;

        }
    }
}
