using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Game
{
    public class Board:IGame,ISerialize,IBoard
    {
        static int[] sudokuArray;
        static int globalSize;
        static int width;
        static int height;
        static int difficulty;
        public string[] resultCsv;
        public string DisplayBoard()
        {
            string result = "";
            for (int i = 0; i <= sudokuArray.Length - 1; i++)
            {

                if (i % globalSize == 0)
                {

                    result += "\n";
                }
                result += sudokuArray[i] + " ";
            }

            return result;

        }
        public void SetDifficulty(int newDifficulty)
        {
            difficulty = newDifficulty;
        }

        public int GetDifficulty()
        {
            return difficulty;
        }

        public int[] GetSudokuArray()
        {
            return sudokuArray;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetMaxValue()
        {
            return globalSize;
        }

        public int[] ToArray()
        {
            string[] resultCsv = GetResultCsv();
            int[] intResult = new int[globalSize * globalSize];
            for (int i = 0; i < resultCsv.Length; i++)
            {
                intResult[i] = int.Parse(resultCsv[i]);
            }
            return intResult;
        }

        public void Set(int[] cellValues)
        {
            sudokuArray = new int[globalSize * globalSize];
            sudokuArray = cellValues;
        }
        public void CellSet(int value, int gridIndex)
        {
            sudokuArray[gridIndex] = value;

        }
        public void SetSquareWidth(int squareWidth)
        {
            width = squareWidth;

        }

        public void SetSquareHeight(int squareHeight)
        {
            height = squareHeight;
        }

        public void Restart()
        {
            //think
        }

        public void SetMaxValue(int maximum)
        {
            globalSize = maximum;
        }
        public void FromCSV(string csv)
        {
            string boardFile = csv;
            StreamReader reader = new StreamReader(boardFile);
            string strResult = reader.ReadToEnd();
            resultCsv = strResult.Split(new string[] { "," }, StringSplitOptions.None);
        }



        public int GetCell(int gridIndex)
        {
            int[] sudokuArray = GetSudokuArray();
            int result = 0;
            result = sudokuArray[gridIndex];
            return result;
        }

        public string[] GetResultCsv()
        {
            return resultCsv;
        }

        public void SetCell(int value, int gridIndex)
        {
            CellSet(value, gridIndex);
        }

        public string ToCSV()
        {
            int difficulty = GetDifficulty();
            int[] sudokuArray = GetSudokuArray();
            string filename = "board" + difficulty;
            string filepath = @"C:\" + filename + ".csv";
            string strSeparator = ",";
            StringBuilder sbOutput = new StringBuilder();
            int sudokouLength = sudokuArray.GetLength(0);
            for (int i = 0; i < sudokouLength; i++)
            {
                sbOutput.AppendLine(string.Join(strSeparator, sudokuArray[i]));

            }
            File.WriteAllText(filepath, sbOutput.ToString());
            //File.AppendAllText(filepath, sbOutput.ToString());

            return filepath;
        }

        public string ToPrettyString()
        {
            int difficulty = GetDifficulty();
            string result = "";
            result += "Sudoku " + difficulty;
            result += "\n" + DisplayBoard();
            return result;
        }

        public string ToStringList(List<int> listArray)
        {
            string strReturn = null;
            if (listArray.Count != 0)
            {
                strReturn = listArray[0].ToString();
                for (int i = 1; i < listArray.Count; i++) strReturn += (" " + listArray[i].ToString());
            }
            return strReturn;
        }

        public string ToStringSArray(string[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i] + " ";
            }
            return result;
        }

        public string ToStringArray(int[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i] + " ";
            }
            return result;
        }

        public bool IsCellValid(int cellNumber)
        {
            Row row = new Row();
            Column col = new Column();
            Square square = new Square();
            bool result = false;
            if (row.IsRowCellValid(cellNumber) && col.IsColCellValid(cellNumber) && square.IsSquareCellValid(cellNumber))
            {
                result = true;
            }

            return result;

        }

        public int[] GetSudokuArrayIndex()
        {
            int[] sudokuArrayIndex = new int[globalSize * globalSize];
            int indexer = 0;
            foreach (int i in sudokuArray)
            {
                sudokuArrayIndex[indexer] = indexer;
                indexer++;
            }

            return sudokuArrayIndex;
        }
    }
}
