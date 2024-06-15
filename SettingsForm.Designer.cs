namespace QuantumSerpent
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.player1NameTextBox = new System.Windows.Forms.TextBox();
            this.player2NameTextBox = new System.Windows.Forms.TextBox();
            this.player1HeadColorButton = new System.Windows.Forms.Button();
            this.player1BodyColorButton = new System.Windows.Forms.Button();
            this.player2HeadColorButton = new System.Windows.Forms.Button();
            this.player2BodyColorButton = new System.Windows.Forms.Button();
            this.aiPlayersNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.initialPlayerLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.fpsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.appleCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.foodGrowMultiplierNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.aiPlayersLabel = new System.Windows.Forms.Label();
            this.initialPlayerLengthLabel = new System.Windows.Forms.Label();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.appleCountLabel = new System.Windows.Forms.Label();
            this.foodGrowMultiplierLabel = new System.Windows.Forms.Label();
            this.player1HeadColorLabel = new System.Windows.Forms.Label();
            this.player1BodyColorLabel = new System.Windows.Forms.Label();
            this.player2HeadColorLabel = new System.Windows.Forms.Label();
            this.player2BodyColorLabel = new System.Windows.Forms.Label();
            this.player1NameLabel = new System.Windows.Forms.Label();
            this.player2NameLabel = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.aiPlayersNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialPlayerLengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appleCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodGrowMultiplierNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // player1NameTextBox
            // 
            this.player1NameTextBox.Location = new System.Drawing.Point(50, 40);
            this.player1NameTextBox.Name = "player1NameTextBox";
            this.player1NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.player1NameTextBox.TabIndex = 0;
            // 
            // player2NameTextBox
            // 
            this.player2NameTextBox.Location = new System.Drawing.Point(250, 40);
            this.player2NameTextBox.Name = "player2NameTextBox";
            this.player2NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.player2NameTextBox.TabIndex = 1;
            // 
            // player1HeadColorButton
            // 
            this.player1HeadColorButton.Location = new System.Drawing.Point(50, 70);
            this.player1HeadColorButton.Name = "player1HeadColorButton";
            this.player1HeadColorButton.Size = new System.Drawing.Size(100, 23);
            this.player1HeadColorButton.TabIndex = 2;
            this.player1HeadColorButton.Text = "Player 1 Head";
            this.player1HeadColorButton.UseVisualStyleBackColor = true;
            this.player1HeadColorButton.Click += new System.EventHandler(this.ChooseColorPlayer1Head);
            // 
            // player1BodyColorButton
            // 
            this.player1BodyColorButton.Location = new System.Drawing.Point(50, 100);
            this.player1BodyColorButton.Name = "player1BodyColorButton";
            this.player1BodyColorButton.Size = new System.Drawing.Size(100, 23);
            this.player1BodyColorButton.TabIndex = 3;
            this.player1BodyColorButton.Text = "Player 1 Body";
            this.player1BodyColorButton.UseVisualStyleBackColor = true;
            this.player1BodyColorButton.Click += new System.EventHandler(this.ChooseColorPlayer1Body);
            // 
            // player2HeadColorButton
            // 
            this.player2HeadColorButton.Location = new System.Drawing.Point(250, 70);
            this.player2HeadColorButton.Name = "player2HeadColorButton";
            this.player2HeadColorButton.Size = new System.Drawing.Size(100, 23);
            this.player2HeadColorButton.TabIndex = 4;
            this.player2HeadColorButton.Text = "Player 2 Head";
            this.player2HeadColorButton.UseVisualStyleBackColor = true;
            this.player2HeadColorButton.Click += new System.EventHandler(this.ChooseColorPlayer2Head);
            // 
            // player2BodyColorButton
            // 
            this.player2BodyColorButton.Location = new System.Drawing.Point(250, 100);
            this.player2BodyColorButton.Name = "player2BodyColorButton";
            this.player2BodyColorButton.Size = new System.Drawing.Size(100, 23);
            this.player2BodyColorButton.TabIndex = 5;
            this.player2BodyColorButton.Text = "Player 2 Body";
            this.player2BodyColorButton.UseVisualStyleBackColor = true;
            this.player2BodyColorButton.Click += new System.EventHandler(this.ChooseColorPlayer2Body);
            // 
            // aiPlayersNumericUpDown
            // 
            this.aiPlayersNumericUpDown.Location = new System.Drawing.Point(150, 170);
            this.aiPlayersNumericUpDown.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.aiPlayersNumericUpDown.Name = "aiPlayersNumericUpDown";
            this.aiPlayersNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.aiPlayersNumericUpDown.TabIndex = 6;
            // 
            // initialPlayerLengthNumericUpDown
            // 
            this.initialPlayerLengthNumericUpDown.Location = new System.Drawing.Point(150, 200);
            this.initialPlayerLengthNumericUpDown.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.initialPlayerLengthNumericUpDown.Name = "initialPlayerLengthNumericUpDown";
            this.initialPlayerLengthNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.initialPlayerLengthNumericUpDown.TabIndex = 7;
            // 
            // fpsNumericUpDown
            // 
            this.fpsNumericUpDown.Location = new System.Drawing.Point(150, 230);
            this.fpsNumericUpDown.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.fpsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fpsNumericUpDown.Name = "fpsNumericUpDown";
            this.fpsNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.fpsNumericUpDown.TabIndex = 8;
            this.fpsNumericUpDown.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // appleCountNumericUpDown
            // 
            this.appleCountNumericUpDown.Location = new System.Drawing.Point(150, 260);
            this.appleCountNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.appleCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.appleCountNumericUpDown.Name = "appleCountNumericUpDown";
            this.appleCountNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.appleCountNumericUpDown.TabIndex = 9;
            this.appleCountNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // foodGrowMultiplierNumericUpDown
            // 
            this.foodGrowMultiplierNumericUpDown.Location = new System.Drawing.Point(150, 290);
            this.foodGrowMultiplierNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.foodGrowMultiplierNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.foodGrowMultiplierNumericUpDown.Name = "foodGrowMultiplierNumericUpDown";
            this.foodGrowMultiplierNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.foodGrowMultiplierNumericUpDown.TabIndex = 10;
            this.foodGrowMultiplierNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(50, 330);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(250, 330);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 23);
            this.backButton.TabIndex = 12;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // aiPlayersLabel
            // 
            this.aiPlayersLabel.AutoSize = true;
            this.aiPlayersLabel.Location = new System.Drawing.Point(50, 172);
            this.aiPlayersLabel.Name = "aiPlayersLabel";
            this.aiPlayersLabel.Size = new System.Drawing.Size(55, 13);
            this.aiPlayersLabel.TabIndex = 13;
            this.aiPlayersLabel.Text = "AI Players";
            // 
            // initialPlayerLengthLabel
            // 
            this.initialPlayerLengthLabel.AutoSize = true;
            this.initialPlayerLengthLabel.Location = new System.Drawing.Point(50, 202);
            this.initialPlayerLengthLabel.Name = "initialPlayerLengthLabel";
            this.initialPlayerLengthLabel.Size = new System.Drawing.Size(94, 13);
            this.initialPlayerLengthLabel.TabIndex = 14;
            this.initialPlayerLengthLabel.Text = "Initial Player Length";
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Location = new System.Drawing.Point(50, 232);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(27, 13);
            this.fpsLabel.TabIndex = 15;
            this.fpsLabel.Text = "FPS";
            // 
            // appleCountLabel
            // 
            this.appleCountLabel.AutoSize = true;
            this.appleCountLabel.Location = new System.Drawing.Point(50, 262);
            this.appleCountLabel.Name = "appleCountLabel";
            this.appleCountLabel.Size = new System.Drawing.Size(65, 13);
            this.appleCountLabel.TabIndex = 16;
            this.appleCountLabel.Text = "Apple Count";
            // 
            // foodGrowMultiplierLabel
            // 
            this.foodGrowMultiplierLabel.AutoSize = true;
            this.foodGrowMultiplierLabel.Location = new System.Drawing.Point(50, 292);
            this.foodGrowMultiplierLabel.Name = "foodGrowMultiplierLabel";
            this.foodGrowMultiplierLabel.Size = new System.Drawing.Size(93, 13);
            this.foodGrowMultiplierLabel.TabIndex = 17;
            this.foodGrowMultiplierLabel.Text = "Food Grow Factor";
            // 
            // player1HeadColorLabel
            // 
            this.player1HeadColorLabel.AutoSize = true;
            this.player1HeadColorLabel.Location = new System.Drawing.Point(50, 130);
            this.player1HeadColorLabel.Name = "player1HeadColorLabel";
            this.player1HeadColorLabel.Size = new System.Drawing.Size(38, 13);
            this.player1HeadColorLabel.TabIndex = 18;
            this.player1HeadColorLabel.Text = "label1";
            // 
            // player1BodyColorLabel
            // 
            this.player1BodyColorLabel.AutoSize = true;
            this.player1BodyColorLabel.Location = new System.Drawing.Point(50, 160);
            this.player1BodyColorLabel.Name = "player1BodyColorLabel";
            this.player1BodyColorLabel.Size = new System.Drawing.Size(38, 13);
            this.player1BodyColorLabel.TabIndex = 19;
            this.player1BodyColorLabel.Text = "label2";
            // 
            // player2HeadColorLabel
            // 
            this.player2HeadColorLabel.AutoSize = true;
            this.player2HeadColorLabel.Location = new System.Drawing.Point(250, 130);
            this.player2HeadColorLabel.Name = "player2HeadColorLabel";
            this.player2HeadColorLabel.Size = new System.Drawing.Size(38, 13);
            this.player2HeadColorLabel.TabIndex = 20;
            this.player2HeadColorLabel.Text = "label3";
            // 
            // player2BodyColorLabel
            // 
            this.player2BodyColorLabel.AutoSize = true;
            this.player2BodyColorLabel.Location = new System.Drawing.Point(250, 160);
            this.player2BodyColorLabel.Name = "player2BodyColorLabel";
            this.player2BodyColorLabel.Size = new System.Drawing.Size(38, 13);
            this.player2BodyColorLabel.TabIndex = 21;
            this.player2BodyColorLabel.Text = "label4";
            // 
            // player1NameLabel
            // 
            this.player1NameLabel.AutoSize = true;
            this.player1NameLabel.Location = new System.Drawing.Point(50, 20);
            this.player1NameLabel.Name = "player1NameLabel";
            this.player1NameLabel.Size = new System.Drawing.Size(67, 13);
            this.player1NameLabel.TabIndex = 22;
            this.player1NameLabel.Text = "Player 1 Name";
            // 
            // player2NameLabel
            // 
            this.player2NameLabel.AutoSize = true;
            this.player2NameLabel.Location = new System.Drawing.Point(250, 20);
            this.player2NameLabel.Name = "player2NameLabel";
            this.player2NameLabel.Size = new System.Drawing.Size(67, 13);
            this.player2NameLabel.TabIndex = 23;
            this.player2NameLabel.Text = "Player 2 Name";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 380);
            this.Controls.Add(this.player2NameLabel);
            this.Controls.Add(this.player1NameLabel);
            this.Controls.Add(this.player2BodyColorLabel);
            this.Controls.Add(this.player2HeadColorLabel);
            this.Controls.Add(this.player1BodyColorLabel);
            this.Controls.Add(this.player1HeadColorLabel);
            this.Controls.Add(this.foodGrowMultiplierLabel);
            this.Controls.Add(this.appleCountLabel);
            this.Controls.Add(this.fpsLabel);
            this.Controls.Add(this.initialPlayerLengthLabel);
            this.Controls.Add(this.aiPlayersLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.foodGrowMultiplierNumericUpDown);
            this.Controls.Add(this.appleCountNumericUpDown);
            this.Controls.Add(this.fpsNumericUpDown);
            this.Controls.Add(this.initialPlayerLengthNumericUpDown);
            this.Controls.Add(this.aiPlayersNumericUpDown);
            this.Controls.Add(this.player2BodyColorButton);
            this.Controls.Add(this.player2HeadColorButton);
            this.Controls.Add(this.player1BodyColorButton);
            this.Controls.Add(this.player1HeadColorButton);
            this.Controls.Add(this.player2NameTextBox);
            this.Controls.Add(this.player1NameTextBox);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.aiPlayersNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialPlayerLengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appleCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foodGrowMultiplierNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox player1NameTextBox;
        private System.Windows.Forms.TextBox player2NameTextBox;
        private System.Windows.Forms.Button player1HeadColorButton;
        private System.Windows.Forms.Button player1BodyColorButton;
        private System.Windows.Forms.Button player2HeadColorButton;
        private System.Windows.Forms.Button player2BodyColorButton;
        private System.Windows.Forms.NumericUpDown aiPlayersNumericUpDown;
        private System.Windows.Forms.NumericUpDown initialPlayerLengthNumericUpDown;
        private System.Windows.Forms.NumericUpDown fpsNumericUpDown;
        private System.Windows.Forms.NumericUpDown appleCountNumericUpDown;
        private System.Windows.Forms.NumericUpDown foodGrowMultiplierNumericUpDown;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label aiPlayersLabel;
        private System.Windows.Forms.Label initialPlayerLengthLabel;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.Label appleCountLabel;
        private System.Windows.Forms.Label foodGrowMultiplierLabel;
        private System.Windows.Forms.Label player1HeadColorLabel;
        private System.Windows.Forms.Label player1BodyColorLabel;
        private System.Windows.Forms.Label player2HeadColorLabel;
        private System.Windows.Forms.Label player2BodyColorLabel;
        private System.Windows.Forms.Label player1NameLabel;
        private System.Windows.Forms.Label player2NameLabel;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}
