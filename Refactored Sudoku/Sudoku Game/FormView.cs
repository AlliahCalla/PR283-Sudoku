using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Game
{
    partial class Form1 : IView
    {
        public string GetArrayString(int[] array)
        {

            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i] + " ";
            }
            return result;

        }

        public void SetController(Controller controller)
        {
            theController = controller;
        }
    }
}
