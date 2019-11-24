using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Game
{
    public partial class Main_Menu : Form
    {
        public static int sudokuSize;
      

        public Main_Menu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        

        private void BtnFourMain_Click(object sender, EventArgs e)
        {
            Board board = new Board();
            board.SetMaxValue(4);
            board.FromCSV(@"C:\board1.csv");
            board.Set(board.ToArray());
            board.FromCSV(@"C:\board1sol.csv");
            board.SetSolution(board.ToArray());
            this.Visible = false;
            Form1 form1 = new Form1();
            form1.StartPosition = this.StartPosition;
            form1.Show();


        }

        private void BtnSixMain_Click(object sender, EventArgs e)
        {
            Board board = new Board();
            board.SetMaxValue(6);
            board.FromCSV(@"C:\board2.csv");
            board.Set(board.ToArray());
            board.FromCSV(@"C:\board2sol.csv");
            board.SetSolution(board.ToArray());
            this.Visible = false;
            Form1 form1 = new Form1();
            form1.StartPosition = this.StartPosition;
            form1.Show();
        }

        
    }
}
