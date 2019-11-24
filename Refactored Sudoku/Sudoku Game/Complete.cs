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
    public partial class Complete : Form
    {
        public Complete()
        {
            InitializeComponent();
        }

        private void sbtn_Menu_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Main_Menu menu = new Main_Menu();
            menu.StartPosition = this.StartPosition;
            menu.Show();
        }
    }
}
