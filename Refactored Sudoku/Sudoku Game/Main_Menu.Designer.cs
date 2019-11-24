namespace Sudoku_Game
{
    partial class Main_Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSudokuMain = new System.Windows.Forms.Label();
            this.btnFourMain = new System.Windows.Forms.Button();
            this.btnSixMain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSudokuMain
            // 
            this.lblSudokuMain.AutoSize = true;
            this.lblSudokuMain.Location = new System.Drawing.Point(362, 157);
            this.lblSudokuMain.Name = "lblSudokuMain";
            this.lblSudokuMain.Size = new System.Drawing.Size(56, 17);
            this.lblSudokuMain.TabIndex = 0;
            this.lblSudokuMain.Text = "Sudoku";
            // 
            // btnFourMain
            // 
            this.btnFourMain.Location = new System.Drawing.Point(98, 426);
            this.btnFourMain.Name = "btnFourMain";
            this.btnFourMain.Size = new System.Drawing.Size(75, 23);
            this.btnFourMain.TabIndex = 1;
            this.btnFourMain.Text = "4x4";
            this.btnFourMain.UseVisualStyleBackColor = true;
            this.btnFourMain.Click += new System.EventHandler(this.BtnFourMain_Click);
            // 
            // btnSixMain
            // 
            this.btnSixMain.Location = new System.Drawing.Point(343, 426);
            this.btnSixMain.Name = "btnSixMain";
            this.btnSixMain.Size = new System.Drawing.Size(75, 23);
            this.btnSixMain.TabIndex = 2;
            this.btnSixMain.Text = "6x6";
            this.btnSixMain.UseVisualStyleBackColor = true;
            this.btnSixMain.Click += new System.EventHandler(this.BtnSixMain_Click);
            // 
            // Main_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 609);
            this.Controls.Add(this.btnSixMain);
            this.Controls.Add(this.btnFourMain);
            this.Controls.Add(this.lblSudokuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main_Menu";
            this.Text = "Sudoku";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSudokuMain;
        private System.Windows.Forms.Button btnFourMain;
        private System.Windows.Forms.Button btnSixMain;
    }
}