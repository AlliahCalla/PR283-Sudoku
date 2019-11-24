using System;
using System.Windows.Forms;

namespace Sudoku_Game
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
            Controller controller = new Controller(form1, new Board(), new Sudoku(), new Square(), new Column(), new Row());
           
            Application.Run(new Main_Menu());
            
        }
    }
}
