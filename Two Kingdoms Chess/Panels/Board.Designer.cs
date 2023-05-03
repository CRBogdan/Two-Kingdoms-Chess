using System.Runtime.CompilerServices;

namespace Two_Kingdoms_Chess
{
    partial class Board
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Board
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 64, 0);
            Name = "Board";
            Size = new Size(1008, 555);
            ResumeLayout(false);
        }

        #endregion

        public void InitializeBoard()
        {
            int buttonSize = 70;
            Button[,] board = new Button[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = new Button()
                    {
                        Parent = this,
                        Padding = new Padding(0,0,0,0),
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(i * buttonSize, j * buttonSize),
                        BackColor = Color.Black,
                    };

                    if ((i + j) % 2 == 0)
                    {
                        board[i, j].BackColor = Color.White;
                    }

                    this.Controls.Add(board[i, j]);
                }
            }
        }
    }
}
