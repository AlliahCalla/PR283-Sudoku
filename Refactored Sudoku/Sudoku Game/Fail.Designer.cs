namespace Sudoku_Game
{
    partial class Fail
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
            this.label1 = new System.Windows.Forms.Label();
            this.fbtn_menu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sudoku Incomplete. Replay?";
            // 
            // fbtn_menu
            // 
            this.fbtn_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.fbtn_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fbtn_menu.Location = new System.Drawing.Point(330, 360);
            this.fbtn_menu.Margin = new System.Windows.Forms.Padding(4);
            this.fbtn_menu.Name = "fbtn_menu";
            this.fbtn_menu.Size = new System.Drawing.Size(116, 38);
            this.fbtn_menu.TabIndex = 6;
            this.fbtn_menu.Text = "Menu";
            this.fbtn_menu.UseVisualStyleBackColor = false;
            this.fbtn_menu.Click += new System.EventHandler(this.fbtn_menu_Click);
            // 
            // Fail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(804, 609);
            this.Controls.Add(this.fbtn_menu);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Fail";
            this.Text = "Fail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button fbtn_menu;
    }
}