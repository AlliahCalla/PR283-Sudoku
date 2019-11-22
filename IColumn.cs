using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame
{
    public interface IColumn
    {
        List<int> GetInvalidColumn();
        bool IsColumnValid(int colNumber);
        bool IsColumnComplete(int colNumber);
        int[] SetColSubArray(int colNumber);
        int[] SetSubColumnIndex(int colNumber);
        int GetCellCol(int cellNumber);
        bool IsColCellValid(int cellNumber);
    }
}
