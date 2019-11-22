using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    public interface ISquare
    {
        List<int> GetInvalidSquare();
        bool IsSquareValid(int squareIndex);
        bool IsSquareComplete(int squareIndex);
        int[] SetSquareSubArray(int squareIndex);
        int[] SetSubSquareIndex(int squareNum);
        int GetCellSquare(int cellNumber);
        bool IsSquareCellValid(int cellNumber);
    }
}
