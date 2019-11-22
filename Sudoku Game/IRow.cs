using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Game
{
    public interface IRow
    {
        List<int> GetInvalidRow();
        bool IsRowComplete(int rowNumber);
        bool IsRowValid(int rowNumber);
        int[] SetSubRowIndex(int rowNumber);
        bool IsRowCellValid(int cellNumber);
        int GetCellRow(int cellNumber);
        int[] SetRowSubArray(int rowNumber);
    }
}
