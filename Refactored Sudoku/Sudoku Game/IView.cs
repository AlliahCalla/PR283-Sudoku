using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Game
{
    public interface IView
    {
        string GetArrayString(int[] array);
        void SetController(Controller controller);
    }
}
