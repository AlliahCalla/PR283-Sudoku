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
        Board board;
        Row row;
        Column col;
        Square square;
        public Form1()
        {
            InitializeComponent();
            this.CreateButtons();
            this.CreateEntries();



            // MakeButtons();
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
                board.SetCell(newValue, index);
                CheckStatus(btnWho.Name);
                //CheckRowStatus(btnWho.Name);
                //CheckColStatus(btnWho.Name);
                //CheckSquareStatus(btnWho.Name);
                
                
                
                
                
                






            }
            else if (btnWho.Name.StartsWith("iptBtn_"))
            {
                this.ClickedText = btnWho.Text;

            }
        }

        public void RowToGreen(int  cellNum)
        {
            string btnName;
            int rowNumber = row.GetCellRow(cellNum);
            int[] indexes = row.SetSubRowIndex(rowNumber);

            foreach (int i in indexes)
            {
                btnName = GetButton(i);
                ToGreen(btnName);
            }
            

        }

        public void ColToGreen(int cellNum)
        {
            string btnName;
            int colNumber = col.GetCellCol(cellNum);
            int[] indexes = col.SetSubColumnIndex(colNumber);

            foreach (int i in indexes)
            {
                btnName = GetButton(i);
                ToGreen(btnName);
            }


        }

        public void SquareToGreen(int cellNum)
        {
            string btnName;
            int squareNumber = square.GetCellSquare(cellNum);
            int[] indexes = square.SetSubSquareIndex(squareNumber);

            foreach (int i in indexes)
            {
                btnName = GetButton(i);
                ToGreen(btnName);
            }


        }

        public void RowToWhite(int cellNum)
        {
            string btnName;
            int rowNumber = row.GetCellRow(cellNum);
            int[] indexes = row.SetSubRowIndex(rowNumber);

            foreach (int i in indexes)
            {
                btnName = GetButton(i);
                ToWhite(btnName);
            }


        }


        public void ColToWhite(int cellNum)
        {
            string btnName;
            int colNumber = col.GetCellCol(cellNum);
            int[] indexes = col.SetSubColumnIndex(colNumber);

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
            int size = board.GetMaxValue();
            int indexer = 0;
            int[] entries = board.GetSudokuArray();
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
            
            int buttonNumber = buttonIndex+2;
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

            /*foreach (Control button in buttons)
            {
                label1.Text += button.Name;
            }*/
            
            return buttons[buttonNumber].Name;
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
            label1.Text = board.ToStringArray(board.GetSudokuArray());
        }

        public void CreateEntries()
        {
            int size = board.GetMaxValue();
            int[] entries = board.GetSudokuArray();
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

        public bool CheckRowStatus(string btnName)
        {
           
            row = new Row();
            string resultString = string.Join(string.Empty, Regex.Matches(btnName, @"\d+").OfType<Match>().Select(m => m.Value));
            int index = Int32.Parse(resultString);
            bool rowComplete = false;

            int rowNumber = row.GetCellRow(index);
            if (row.IsRowComplete(rowNumber) == true)
            {
                label1.Text = " Row " + (rowNumber + 1) + " Complete";
                rowComplete = true;
                RowToGreen(index);
                //SetSudokuValues();
            }
            if (row.IsRowComplete(rowNumber) == false)
            {
                label1.Text = " Row " + (rowNumber + 1) + " Incomplete";
                rowComplete = false;
                RowToWhite(index);
                //SetSudokuValues();
            }

            return rowComplete;

        }

        public bool CheckColStatus(string btnName)
        {

            col = new Column();
            string resultString = string.Join(string.Empty, Regex.Matches(btnName, @"\d+").OfType<Match>().Select(m => m.Value));
            int index = Int32.Parse(resultString);
            bool colComplete = false;

            int colNumber = col.GetCellCol(index);
            if (col.IsColumnComplete(colNumber) == true)
            {
                label1.Text += " Column " + (colNumber + 1) + " Complete";
                colComplete = true;
                ColToGreen(index);
                //SetSudokuValues();
            }
            if (col.IsColumnComplete(colNumber) == false)
            {
                label1.Text += " Column " + (colNumber + 1) + " Incomplete";
                colComplete = false;
                ColToWhite(index);
                //SetSudokuValues();
            }

            return colComplete;

        }

        public bool CheckSquareStatus(string btnName)
        {

            square = new Square();
            string resultString = string.Join(string.Empty, Regex.Matches(btnName, @"\d+").OfType<Match>().Select(m => m.Value));
            int index = Int32.Parse(resultString);
            bool squareComplete = false;

            int squareNumber = square.GetCellSquare(index);
            if (square.IsSquareComplete(squareNumber) == true)
            {
                label1.Text += " Square " + (squareNumber + 1) + " Complete";
                squareComplete = true;
                SquareToGreen(index);
                //SetSudokuValues();
            }
            if (square.IsSquareComplete(squareNumber) == false)
            {
                label1.Text += " Square " + (squareNumber + 1) + " Incomplete";
                squareComplete = false;
                SquareToWhite(index);
                //SetSudokuValues();
            }

            return squareComplete;

        }



        public void CheckStatus(string btnName)
        {
            col = new Column();
            row = new Row();
            square = new Square();
            string resultString = string.Join(string.Empty, Regex.Matches(btnName, @"\d+").OfType<Match>().Select(m => m.Value));
            int index = Int32.Parse(resultString);
            bool colComplete = false;
            int colNumber = col.GetCellCol(index);
            bool rowComplete = false;
            int rowNumber = row.GetCellRow(index);
            bool squareComplete = false;
            int squareNumber = square.GetCellSquare(index);

            
            if (row.IsRowComplete(rowNumber) == true)
            {
                label1.Text = " Row " + (rowNumber + 1) + " Complete";
                rowComplete = true;
                RowToGreen(index);
                
                //SetSudokuValues();
            }
            if (col.IsColumnComplete(colNumber) == true)
            {
                label1.Text = " Column " + (colNumber + 1) + " Complete";
                colComplete = true;
                ColToGreen(index);
                //SetSudokuValues();
            }
            if (square.IsSquareComplete(squareNumber) == true)
            {
                label1.Text = " Square " + (squareNumber + 1) + " Complete";
                squareComplete = true;
                SquareToGreen(index);
                //SetSudokuValues();
            }

            else if (col.IsColumnComplete(colNumber) == false && row.IsRowComplete(rowNumber) == false && square.IsSquareComplete(squareNumber) == false)
            {
                label1.Text = " Column " + (colNumber + 1) + " Incomplete";
                colComplete = false;
                ColToWhite(index);
                //SetSudokuValues();
            }

            else if (row.IsRowComplete(rowNumber) == false && col.IsColumnComplete(colNumber) == false && square.IsSquareComplete(squareNumber) == false)
            {
                label1.Text = " Row " + (rowNumber + 1) + " Incomplete";
                rowComplete = false;
                RowToWhite(index);
                //SetSudokuValues();
            }
            else if (square.IsSquareComplete(squareNumber) == false && row.IsRowComplete(rowNumber) == false && col.IsColumnComplete(colNumber) == false)
            {
                label1.Text = " Square " + (squareNumber + 1) + " Incomplete";
                squareComplete = false;
                SquareToWhite(index);
                //SetSudokuValues();
            }


        }


    }
}
