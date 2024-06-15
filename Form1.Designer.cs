namespace QuantumSerpent
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        /// 


        private void InitializeComponent()
        {
            this.gameBoard = new PictureBox()
            {
                Location = new Point(10, 10),
                Size = new Size(800, 600),
                BackColor = Color.LightGray
            };
            this.gameBoard.Paint += new PaintEventHandler(this.GameBoard_Paint);

            this.gameTimer = new System.Windows.Forms.Timer();
            this.gameTimer.Tick += new EventHandler(this.GameTimer_Tick);

            this.statusLabel = new Label()
            {
                Location = new Point(820, 170),
                Size = new Size(100, 23),
                Text = "Status: Ready"
            };

            this.ClientSize = new Size(940, 620);
            this.Controls.Add(this.gameBoard);
            this.Controls.Add(this.statusLabel);
            this.Name = "MainForm";
            this.Text = "Quantum Serpent: Multiplayer Mayhem";
            this.KeyDown += new KeyEventHandler(this.MainForm_KeyDown);
            this.KeyPreview = true;

            this.offscreenBitmap = new Bitmap(gameBoard.Width, gameBoard.Height);
            this.offscreenGraphics = Graphics.FromImage(offscreenBitmap);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

    }
}
#endregion
