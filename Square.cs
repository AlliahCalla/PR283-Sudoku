using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    public class Square : ISquare
    {
        private int[] squareSubArray;
        private int[] squareSubIndex;
        Board board = new Board();
        Sudoku sudoku = new Sudoku();
        public int GetCellSquare(int cellNumber)
        {
            int globalSize = board.GetMaxValue();
            int cellSquare = 0;
            for (int i = 0; i < globalSize; i++)
            {
                SetSubSquareIndex(i);
                if (squareSubIndex.Contains(cellNumber))
                {
                    cellSquare = i;

                }

            }
            return cellSquare;
        }

        public List<int> GetInvalidSquare()
        {
            int globalSize = board.GetMaxValue();
            int max = globalSize - 1;
            int index = 0;
            List<int> invalidSquare = new List<int>();
            for (int i = 0; i <= max; i++)
            {


                if (IsSquareValid(i) == false)
                {
                    invalidSquare.Add(i);
                }
            }

            return invalidSquare;

        }

        public bool IsSquareCellValid(int cellNumber)
        {
            int[] sudokuArray = board.GetSudokuArray();
            int globalSize = board.GetMaxValue();
            int square = GetCellSquare(cellNumber);
            SetSquareSubArray(square);
            int count = 0;
            bool result = true;
            for (int i = 0; i < squareSubArray.Length; i++)
            {
                if (squareSubArray[i] == sudokuArray[cellNumber])
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


        public bool IsSquareComplete(int squareIndex)
        {
            int globalSize = board.GetMaxValue();
            SetSquareSubArray(squareIndex);
            List<int> arr_list = squareSubArray.OfType<int>().ToList();
            bool inRange = true;
            bool isNotBlank = true;

            for (int i = 0; i < globalSize; i++)
            {
                if (squareSubArray[i] > globalSize)
                {

                    inRange = false;

                }
                if (squareSubArray[i] == 0)
                {
                    isNotBlank = false;

                }



            }

            bool isUnique = arr_list.Distinct().Count() == arr_list.Count();
            bool result = isUnique && isNotBlank && inRange;
            return result;
        }
        public bool IsSquareValid(int squareIndex)
        {
            int globalSize = board.GetMaxValue();
            SetSquareSubArray(squareIndex);
            List<int> arr_list = squareSubArray.OfType<int>().ToList();

            bool isOutOfRange = false;
            bool isNotBlank = IsSquareComplete(squareIndex);
            for (int i = 0; i < globalSize; i++)
            {
                if (squareSubArray[i] > globalSize)
                {

                    isOutOfRange = true;

                }



            }
            bool isUnique = arr_list.Distinct().Count() == arr_list.Count();
            bool result = isUnique && isNotBlank && !isOutOfRange;
            return result;
        }

        public int[] SetSquareSubArray(int squareIndex)
        {
            int globalSize = board.GetMaxValue();
            /*int max = globalSize - 1;
            squareSubArray = new int[globalSize];
            for (int i = 0; i <= max; i++)
            {
                squareSubArray[i] = sudoku.GetBySquare(squareIndex, i);
            }*/



            int[] sudokuArray = board.GetSudokuArray();
            
            /*int globalSize = board.GetMaxValue();
            int half = globalSize / 2;
            squareSubArray = new int[globalSize+3];
            int[] subArray = SubArray(sudokuArray, 0, 9);
            int indexer = 0;
            for (int i = 0; i < subArray.Length; i++)
            {
                squareSubArray[indexer] = subArray[i];
                indexer++;
        

            }*/

            int[] subIndex = SetSubSquareIndex(squareIndex);
            squareSubArray = new int[globalSize];
            for (int i = 0; i < globalSize; i++)
            {
                squareSubArray[i] = sudokuArray[subIndex[i]];
            }


            return squareSubArray;
        }

        public int[] SetSubSquareIndex(int squareNum)
        {
            int globalSize = board.GetMaxValue();

            if (globalSize == 4)
            {
                int half = globalSize / 2;
                squareSubIndex = new int[globalSize];
                int indexer = 0;
                int j = 0;
                int start = 0;
                int end = 0;
                int tempSquareNum = squareNum + 1;

                int product = tempSquareNum * 4;

                if (tempSquareNum % half == 0)
                {
                    start = (product - 1) - (globalSize + 1);
                    end = product - 1;
                }
                else
                {
                    start = (product + 1) - (globalSize + 1);
                    end = product + 1;
                }

                for (int i = start; i <= end; i++, j++)
                {
                    if (j == half)
                    {
                        i += half;
                    }
                    squareSubIndex[indexer] = i;
                    indexer++;

                }
            }

            if (globalSize == 6)
            {

                int[] sudokuArrayIndex = board.GetSudokuArrayIndex();
                int half = globalSize / 2;
                int skipper = half;
                int indexer = 0;
                squareSubIndex = new int[globalSize];



                int start = 0;
                if (squareNum % 2 == 1)
                {
                    start = (squareNum * globalSize) - half;

                }

                else if (squareNum % 2 == 0)
                {

                    start = (squareNum * globalSize);
                }

                int[] subArray = SubArray(sudokuArrayIndex, start, globalSize + half);



                for (int i = 0; i < subArray.Length; i++)

                {

                    if (subArray[i] == start + half)
                    {
                        i += 3;
                    }
                    squareSubIndex[indexer] = subArray[i];
                    indexer++;

                }
            }
            return squareSubIndex;
        }
        public T[] SubArray<T>(T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public int[] GetSquareSubIndex()
        {
            return squareSubIndex;

        }

        public int[] GetSquareSubArray()
        {
            return squareSubArray;

        }
    }
}
