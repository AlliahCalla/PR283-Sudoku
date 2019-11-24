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
    public partial class Fail : Form
    {
        public Fail()
        {
            InitializeComponent();
        }

        private void fbtn_menu_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Main_Menu menu = new Main_Menu();
            menu.StartPosition = this.StartPosition;
            menu.Show();
        }
    }
}
