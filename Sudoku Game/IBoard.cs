using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Game
{
    public interface IBoard
    {
        string ToStringList(List<int> listArray);
        string ToStringSArray(string[] array);
        string ToStringArray(int[] array);
        bool IsCellValid(int cellNumber);
    }
}
