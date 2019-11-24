using System;

namespace Sudoku_Game
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.wbtn_start = new System.Windows.Forms.Button();
            this.wbtn_menu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(688, 569);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(698, 66);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(62, 25);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Timer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 727);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Status:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // wbtn_start
            // 
            this.wbtn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wbtn_start.Location = new System.Drawing.Point(547, 13);
            this.wbtn_start.Margin = new System.Windows.Forms.Padding(4);
            this.wbtn_start.Name = "wbtn_start";
            this.wbtn_start.Size = new System.Drawing.Size(116, 38);
            this.wbtn_start.TabIndex = 4;
            this.wbtn_start.Text = "Start";
            this.wbtn_start.UseVisualStyleBackColor = true;
            this.wbtn_start.Click += new System.EventHandler(this.wbtn_start_Click);
            // 
            // wbtn_menu
            // 
            this.wbtn_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wbtn_menu.Location = new System.Drawing.Point(672, 13);
            this.wbtn_menu.Margin = new System.Windows.Forms.Padding(4);
            this.wbtn_menu.Name = "wbtn_menu";
            this.wbtn_menu.Size = new System.Drawing.Size(116, 38);
            this.wbtn_menu.TabIndex = 5;
            this.wbtn_menu.Text = "Menu";
            this.wbtn_menu.UseVisualStyleBackColor = true;
            this.wbtn_menu.Click += new System.EventHandler(this.wbtn_menu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 753);
            this.Controls.Add(this.wbtn_menu);
            this.Controls.Add(this.wbtn_start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Main_Menu main_menu = new Main_Menu();
            main_menu.StartPosition = this.StartPosition;
            main_menu.Show();
        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button wbtn_start;
        private System.Windows.Forms.Button wbtn_menu;
    }
}

