using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    public class Document:ISerialize
    {
        public string[] resultCsv;
       
        Board board = new Board();

        public void FromCSV(string csv)
        {
            string boardFile = csv;
            StreamReader reader = new StreamReader(boardFile);
            string strResult = reader.ReadToEnd();
            resultCsv = strResult.Split(new string[] { "," }, StringSplitOptions.None);
        }

        public int GetCell(int gridIndex)
        {
            int[] sudokuArray = board.GetSudokuArray();
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
            board.CellSet(value, gridIndex);
        }

        public string ToCSV()
        {
            int difficulty = board.GetDifficulty();
            int[] sudokuArray = board.GetSudokuArray();
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
            int difficulty = board.GetDifficulty();
            string result = "";
            result += "Sudoku " + difficulty;
            result += "\n" + board.DisplayBoard();
            return result;
        }
    }
}
