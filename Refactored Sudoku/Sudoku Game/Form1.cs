using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Sudoku_Game
{
    public partial class Form1 : Form
    {
        string ClickedText;
        private int _ticks;
        Board board;
        Row row;
        Column col;
        Square square;
        private Controller theController;
        public Form1()
        {
            InitializeComponent();
            SetController(new Controller(this, new Board(), new Sudoku(), new Square(), new Column(), new Row()));
            this.CreateButtons();
            this.CreateEntries();
            this.DisableButtons();
          
        }


        public void MakeButtons(int size)
        {
            Button btnNew = new Button();
            btnNew.Name = "btn";
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = "#";
            btnNew.Visible = true;
            btnNew.Location = new Point(10, 80);
            

            Controls.Add(btnNew);
        }

        public void MakeButtons2(string name, string text, int row, int column, int size, int index)
        {
            Button btnNew = new Button();

            btnNew.Name = name + "_" + index;
            if (size == 6)
            {
                btnNew.Height = 70;
                btnNew.Width = 70;
                btnNew.Font = new Font("Arial", 15);
            }
            else if (size == 4)
            {
                btnNew.Height = 95;
                btnNew.Width = 95;
                btnNew.Font = new Font("Arial", 25);
            }
            else
            {
                btnNew.Height = 50;
                btnNew.Width = 50;
                btnNew.Font = new Font("Arial", 10);
            }


            //btnNew.Font = new Font("Arial", 20);
            btnNew.Text = text;
            btnNew.Visible = true;
            btnNew.BackColor = Color.White;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.FlatAppearance.BorderColor = Color.White;
            btnNew.FlatAppearance.BorderSize = 1;
            btnNew.Location = new Point(10 + btnNew.Height * column, 80 + btnNew.Width * row);

            this.Controls.Add(btnNew);
        }

        public void WhoClicked(object sender, EventArgs e)
        {
            Button btnWho = sender as Button;

            this.Text = btnWho.Name;

            if (btnWho.Name.StartsWith("btn"))
            {
                row = new Row();
                btnWho.Text = ClickedText;
                string resultString = string.Join(string.Empty, Regex.Matches(btnWho.Name, @"\d+").OfType<Match>().Select(m => m.Value));
                int index = Int32.Parse(resultString);
                int newValue = Int32.Parse(ClickedText);
                theController.SetCellValues(newValue, index);
                CheckStatus(btnWho.Name);

                if (theController.CheckSudoku() == true)
                {
                    this.Visible = false;
                    Complete complete = new Complete();
                    complete.StartPosition = this.StartPosition;
                    complete.Show();
                }
            }
            else if (btnWho.Name.StartsWith("iptBtn_"))
            {
                this.ClickedText = btnWho.Text;

            }
        }

        public void RowToGreen(int  cellNum)
        {
            string btnName;
            int rowNumber = theController.GetCellRowNum(cellNum);//GetCellRowNum
            int[] indexes = theController.GetRowIndexes(rowNumber);//GetRowIndexes

            foreach (int i in indexes)
            {
                btnName = GetButton(i);
                ToGreen(btnName);
            }
            

        }

        public void ColToGreen(int cellNum)
        {
            string btnName;
            int colNumber = theController.GetCellColNum(cellNum);//GetCellColNum
            int[] indexes = theController.GetColIndexes(colNumber);//GetColIndexes

            foreach (int i in indexes)
            {
                btnName = GetButton(i);
                ToGreen(btnName);
            }


        }

        public void SquareToGreen(int cellNum)
        {
            string btnName;
            int squareNumber = theController.GetCellSquareNum(cellNum);//GetCellSquareNum
            int[] indexes = theController.GetSquareIndexes(squareNumber);//GetSquareIndexes

            foreach (int i in indexes)
            {
                btnName = GetButton(i);
                ToGreen(btnName);
            }


        }

        public void RowToWhite(int cellNum)
        {
            string btnName;
            int rowNumber = theController.GetCellRowNum(cellNum);//GetCellRowNum
            int[] indexes = theController.GetRowIndexes(rowNumber);//GetRowIndexes

            foreach (int i in indexes)
            {
                btnName = GetButton(i);
                ToWhite(btnName);
            }


        }


        public void ColToWhite(int cellNum)
        {
            string btnName;
            int colNumber = theController.GetCellColNum(cellNum); //GetCellColNum
            int[] indexes = theController.GetColIndexes(colNumber);//GetColIndexes

            foreach (int i in indexes)
            {
                btnName = GetButton(i);
                ToWhite(btnName);
            }


        }

        public void SquareToWhite(int cellNum)
        {
            string btnName;
            int squareNumber = square.GetCellSquare(cellNum);
            int[] indexes = square.SetSubSquareIndex(squareNumber);

            foreach (int i in indexes)
            {
                btnName = GetButton(i);
                ToWhite(btnName);
            }


        }

        public void SetClicks()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    /*
                    if (c.Name.StartsWith("btn"))
                    {
                        Button who = c as Button;
                        who.Click += new EventHandler(WhoClicked);
                    } else if (c.Name.StartsWith("iptBtn_"))
                    {
                        this.ClickedText = c.Text;
                    }
                    */
                    Button who = c as Button;
                    who.Click += new EventHandler(WhoClicked);
                }
            }
        }


        public void CreateButtons()
        {
            //Set up Sudoku values
            board = new Board();
            int size = theController.GetSudokuSize(); //GETSUDOKUSIZE
            int indexer = 0;
            int[] entries = theController.GetLoadedArray(); //GETLOADEDARRAY
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    MakeButtons2("btn_", entries[indexer].ToString(), i, j, size, indexer);
                    indexer++;
                }
            }


        }

        public string GetButton(int buttonIndex)
        {
            
            int buttonNumber = buttonIndex+3;
            List<Control> list = new List<Control>();
            List<Control> buttons = new List<Control>();

            GetAllControl(this, list);

            foreach (Control control in list)
            {
                if (control.GetType() == typeof(Button))
                {
                    buttons.Add(control);
                    


                }
            }

            return buttons[buttonNumber].Name;
        }

        public void DisableButtons()
        {
            List<Control> list = new List<Control>();
            List<Control> buttons = new List<Control>();

            GetAllControl(this, list);

            foreach (Control control in list)
            {
                if (control.GetType() == typeof(Button))
                {
                    if (control.Name.StartsWith("btn") || control.Name.StartsWith("iptBtn_"))
                    {
                        control.Enabled = false;
                    }
                    
                    


                }
            }

        }
        public void EnableButtons()
        {
            List<Control> list = new List<Control>();
            List<Control> buttons = new List<Control>();

            GetAllControl(this, list);

            foreach (Control control in list)
            {
                if (control.GetType() == typeof(Button))
                {
                    if (control.Name.StartsWith("btn") || control.Name.StartsWith("iptBtn_"))
                    {
                        if(control.Text == "0" || control.Name.StartsWith("iptBtn_"))
                        {

                            control.Enabled = true;
                        }
                        
                    }




                }
            }

        }

        private void GetAllControl(Control c, List<Control> list)
        {
            foreach (Control control in c.Controls)
            {
                list.Add(control);

                if (control.GetType() == typeof(Panel))
                    GetAllControl(control, list);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = theController.GetArrayString(board.GetSudokuArray());
            //GETARRAYSTRING
        }

        public void CreateEntries()
        {
            int size = theController.GetSudokuSize(); //GetSudokuSize
            int[] entries = theController.GetSudokuCells(); //GetSudokuCells
            int indexer = 0;
            MakeButtons2("iptBtn_", "0", 0, size + 1, size, indexer);
            for (int i = 1; i <= size; ++i)
            {
                for (int j = size; j < size + 1; ++j)
                {
                    indexer++;
                    MakeButtons2("iptBtn_", i.ToString(), i, j + 1, size, indexer);
                }
            }

            SetClicks();

        }

        public void ToGreen(string btnName)
        {
            Control c = Controls.Find(btnName, true)[0];
            Button b = c as Button;
            b.BackColor = Color.PaleGreen;
        }

        public void ToWhite(string btnName)
        {
            Control c = Controls.Find(btnName, true)[0];
            Button b = c as Button;
            b.BackColor = Color.White;
        }

     


        public void CheckStatus(string btnName)
        {
            col = new Column();
            row = new Row();
            square = new Square();
            string resultString = string.Join(string.Empty, Regex.Matches(btnName, @"\d+").OfType<Match>().Select(m => m.Value));
            int index = Int32.Parse(resultString);
            bool colComplete = false;
            int colNumber = theController.GetCellColNum(index);//GetCellColNum
            bool rowComplete = false;
            int rowNumber = theController.GetCellRowNum(index);//GetCellRowNum
            bool squareComplete = false;
            int squareNumber = theController.GetCellSquareNum(index); //GetCellSquareNum


            if (theController.CheckRowComplete(rowNumber) == true)//CheckRowComplete
            {
                label1.Text = " Row " + (rowNumber + 1) + " Complete";
                rowComplete = true;
                RowToGreen(index);

            }
            if (theController.CheckColComplete(colNumber) == true)//CheckColComplete
            {
                label1.Text = " Column " + (colNumber + 1) + " Complete";
                colComplete = true;
                ColToGreen(index);

            }
            if (theController.CheckSquareComplete(squareNumber) == true) // CheckSquareComplete
            {
                label1.Text = " Square " + (squareNumber + 1) + " Complete";
                squareComplete = true;
                SquareToGreen(index);
                //SetSudokuValues();
            }

            else if (theController.CheckColComplete(colNumber) == false && theController.CheckRowComplete(rowNumber) == false && theController.CheckSquareComplete(squareNumber) == false)
            {
                label1.Text = " Column " + (colNumber + 1) + " Incomplete";
                colComplete = false;
                ColToWhite(index);
                //SetSudokuValues();
            }

            else if (theController.CheckRowComplete(rowNumber) == false && theController.CheckColComplete(colNumber) == false && theController.CheckSquareComplete(squareNumber) == false)
            {
                label1.Text = " Row " + (rowNumber + 1) + " Incomplete";
                rowComplete = false;
                RowToWhite(index);
                //SetSudokuValues();
            }
            else if (theController.CheckSquareComplete(squareNumber) == false && theController.CheckRowComplete(rowNumber) == false && theController.CheckColComplete(colNumber) == false)
            {
                label1.Text = " Square " + (squareNumber + 1) + " Incomplete";
                squareComplete = false;
                SquareToWhite(index);
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;
            lblTime.Text = _ticks.ToString();
            if (_ticks == 120 && theController.CheckSudoku() == false)
            {
                
                timer1.Stop();
                this.Visible = false;
                Fail fail = new Fail();
                fail.StartPosition = this.StartPosition;
                fail.Show();


            }
        }

        private void wbtn_start_Click(object sender, EventArgs e)
        {
            EnableButtons();
            timer1.Start();

        }

        private void wbtn_menu_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Main_Menu menu = new Main_Menu();
            menu.StartPosition = this.StartPosition;
            menu.Show();
        }

        

        
       

       
    }
}
