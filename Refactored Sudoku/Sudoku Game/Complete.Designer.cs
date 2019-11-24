namespace Sudoku_Game
{
    partial class Complete
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
            this.lblComplete = new System.Windows.Forms.Label();
            this.sbtn_Menu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblComplete
            // 
            this.lblComplete.AutoSize = true;
            this.lblComplete.Location = new System.Drawing.Point(354, 259);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(119, 17);
            this.lblComplete.TabIndex = 0;
            this.lblComplete.Text = "Sudoku Complete";
            // 
            // sbtn_Menu
            // 
            this.sbtn_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.sbtn_Menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sbtn_Menu.Location = new System.Drawing.Point(357, 373);
            this.sbtn_Menu.Name = "sbtn_Menu";
            this.sbtn_Menu.Size = new System.Drawing.Size(83, 35);
            this.sbtn_Menu.TabIndex = 1;
            this.sbtn_Menu.Text = "Menu";
            this.sbtn_Menu.UseVisualStyleBackColor = false;
            this.sbtn_Menu.Click += new System.EventHandler(this.sbtn_Menu_Click);
            // 
            // Complete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(782, 706);
            this.Controls.Add(this.sbtn_Menu);
            this.Controls.Add(this.lblComplete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Complete";
            this.Text = "Complete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblComplete;
        private System.Windows.Forms.Button sbtn_Menu;
    }
}