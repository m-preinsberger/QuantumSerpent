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
            player1NameTextBox = new TextBox();
            player2NameTextBox = new TextBox();
            player1HeadColorButton = new Button();
            player1BodyColorButton = new Button();
            player2HeadColorButton = new Button();
            player2BodyColorButton = new Button();
            aiPlayersNumericUpDown = new NumericUpDown();
            initialPlayerLengthNumericUpDown = new NumericUpDown();
            fpsNumericUpDown = new NumericUpDown();
            appleCountNumericUpDown = new NumericUpDown();
            foodGrowMultiplierNumericUpDown = new NumericUpDown();
            saveButton = new Button();
            backButton = new Button();
            aiPlayersLabel = new Label();
            initialPlayerLengthLabel = new Label();
            fpsLabel = new Label();
            appleCountLabel = new Label();
            foodGrowMultiplierLabel = new Label();
            player1HeadColorLabel = new Label();
            player1BodyColorLabel = new Label();
            player2HeadColorLabel = new Label();
            player2BodyColorLabel = new Label();
            player1NameLabel = new Label();
            player2NameLabel = new Label();
            colorDialog = new ColorDialog();
            DifficultyLabel = new Label();
            dificultyCBox = new ComboBox();
            fatSerpentCheckBox = new CheckBox();
            countdownNumericUpDown = new NumericUpDown();
            label1 = new Label();
            fatserpentlabel = new Label();
            ((System.ComponentModel.ISupportInitialize)aiPlayersNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)initialPlayerLengthNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fpsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)appleCountNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)foodGrowMultiplierNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)countdownNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // player1NameTextBox
            // 
            player1NameTextBox.Location = new Point(58, 46);
            player1NameTextBox.Margin = new Padding(4, 3, 4, 3);
            player1NameTextBox.Name = "player1NameTextBox";
            player1NameTextBox.Size = new Size(116, 23);
            player1NameTextBox.TabIndex = 0;
            // 
            // player2NameTextBox
            // 
            player2NameTextBox.Location = new Point(292, 46);
            player2NameTextBox.Margin = new Padding(4, 3, 4, 3);
            player2NameTextBox.Name = "player2NameTextBox";
            player2NameTextBox.Size = new Size(116, 23);
            player2NameTextBox.TabIndex = 1;
            // 
            // player1HeadColorButton
            // 
            player1HeadColorButton.Location = new Point(58, 81);
            player1HeadColorButton.Margin = new Padding(4, 3, 4, 3);
            player1HeadColorButton.Name = "player1HeadColorButton";
            player1HeadColorButton.Size = new Size(117, 27);
            player1HeadColorButton.TabIndex = 2;
            player1HeadColorButton.Text = "Player 1 Head";
            player1HeadColorButton.UseVisualStyleBackColor = true;
            player1HeadColorButton.Click += ChooseColorPlayer1Head;
            // 
            // player1BodyColorButton
            // 
            player1BodyColorButton.Location = new Point(58, 115);
            player1BodyColorButton.Margin = new Padding(4, 3, 4, 3);
            player1BodyColorButton.Name = "player1BodyColorButton";
            player1BodyColorButton.Size = new Size(117, 27);
            player1BodyColorButton.TabIndex = 3;
            player1BodyColorButton.Text = "Player 1 Body";
            player1BodyColorButton.UseVisualStyleBackColor = true;
            player1BodyColorButton.Click += ChooseColorPlayer1Body;
            // 
            // player2HeadColorButton
            // 
            player2HeadColorButton.Location = new Point(292, 81);
            player2HeadColorButton.Margin = new Padding(4, 3, 4, 3);
            player2HeadColorButton.Name = "player2HeadColorButton";
            player2HeadColorButton.Size = new Size(117, 27);
            player2HeadColorButton.TabIndex = 4;
            player2HeadColorButton.Text = "Player 2 Head";
            player2HeadColorButton.UseVisualStyleBackColor = true;
            player2HeadColorButton.Click += ChooseColorPlayer2Head;
            // 
            // player2BodyColorButton
            // 
            player2BodyColorButton.Location = new Point(292, 115);
            player2BodyColorButton.Margin = new Padding(4, 3, 4, 3);
            player2BodyColorButton.Name = "player2BodyColorButton";
            player2BodyColorButton.Size = new Size(117, 27);
            player2BodyColorButton.TabIndex = 5;
            player2BodyColorButton.Text = "Player 2 Body";
            player2BodyColorButton.UseVisualStyleBackColor = true;
            player2BodyColorButton.Click += ChooseColorPlayer2Body;
            // 
            // aiPlayersNumericUpDown
            // 
            aiPlayersNumericUpDown.Location = new Point(175, 196);
            aiPlayersNumericUpDown.Margin = new Padding(4, 3, 4, 3);
            aiPlayersNumericUpDown.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            aiPlayersNumericUpDown.Name = "aiPlayersNumericUpDown";
            aiPlayersNumericUpDown.Size = new Size(70, 23);
            aiPlayersNumericUpDown.TabIndex = 6;
            // 
            // initialPlayerLengthNumericUpDown
            // 
            initialPlayerLengthNumericUpDown.Location = new Point(175, 231);
            initialPlayerLengthNumericUpDown.Margin = new Padding(4, 3, 4, 3);
            initialPlayerLengthNumericUpDown.Name = "initialPlayerLengthNumericUpDown";
            initialPlayerLengthNumericUpDown.Size = new Size(70, 23);
            initialPlayerLengthNumericUpDown.TabIndex = 7;
            // 
            // fpsNumericUpDown
            // 
            fpsNumericUpDown.Location = new Point(175, 265);
            fpsNumericUpDown.Margin = new Padding(4, 3, 4, 3);
            fpsNumericUpDown.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            fpsNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            fpsNumericUpDown.Name = "fpsNumericUpDown";
            fpsNumericUpDown.Size = new Size(70, 23);
            fpsNumericUpDown.TabIndex = 8;
            fpsNumericUpDown.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // appleCountNumericUpDown
            // 
            appleCountNumericUpDown.Location = new Point(175, 300);
            appleCountNumericUpDown.Margin = new Padding(4, 3, 4, 3);
            appleCountNumericUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            appleCountNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            appleCountNumericUpDown.Name = "appleCountNumericUpDown";
            appleCountNumericUpDown.Size = new Size(70, 23);
            appleCountNumericUpDown.TabIndex = 9;
            appleCountNumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // foodGrowMultiplierNumericUpDown
            // 
            foodGrowMultiplierNumericUpDown.Location = new Point(175, 335);
            foodGrowMultiplierNumericUpDown.Margin = new Padding(4, 3, 4, 3);
            foodGrowMultiplierNumericUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            foodGrowMultiplierNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            foodGrowMultiplierNumericUpDown.Name = "foodGrowMultiplierNumericUpDown";
            foodGrowMultiplierNumericUpDown.Size = new Size(70, 23);
            foodGrowMultiplierNumericUpDown.TabIndex = 10;
            foodGrowMultiplierNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // saveButton
            // 
            saveButton.Location = new Point(58, 475);
            saveButton.Margin = new Padding(4, 3, 4, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(117, 27);
            saveButton.TabIndex = 11;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(291, 475);
            backButton.Margin = new Padding(4, 3, 4, 3);
            backButton.Name = "backButton";
            backButton.Size = new Size(117, 27);
            backButton.TabIndex = 12;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += BackButton_Click;
            // 
            // aiPlayersLabel
            // 
            aiPlayersLabel.AutoSize = true;
            aiPlayersLabel.Location = new Point(58, 198);
            aiPlayersLabel.Margin = new Padding(4, 0, 4, 0);
            aiPlayersLabel.Name = "aiPlayersLabel";
            aiPlayersLabel.Size = new Size(58, 15);
            aiPlayersLabel.TabIndex = 13;
            aiPlayersLabel.Text = "AI Players";
            // 
            // initialPlayerLengthLabel
            // 
            initialPlayerLengthLabel.AutoSize = true;
            initialPlayerLengthLabel.Location = new Point(58, 233);
            initialPlayerLengthLabel.Margin = new Padding(4, 0, 4, 0);
            initialPlayerLengthLabel.Name = "initialPlayerLengthLabel";
            initialPlayerLengthLabel.Size = new Size(111, 15);
            initialPlayerLengthLabel.TabIndex = 14;
            initialPlayerLengthLabel.Text = "Initial Player Length";
            // 
            // fpsLabel
            // 
            fpsLabel.AutoSize = true;
            fpsLabel.Location = new Point(58, 268);
            fpsLabel.Margin = new Padding(4, 0, 4, 0);
            fpsLabel.Name = "fpsLabel";
            fpsLabel.Size = new Size(26, 15);
            fpsLabel.TabIndex = 15;
            fpsLabel.Text = "FPS";
            // 
            // appleCountLabel
            // 
            appleCountLabel.AutoSize = true;
            appleCountLabel.Location = new Point(58, 302);
            appleCountLabel.Margin = new Padding(4, 0, 4, 0);
            appleCountLabel.Name = "appleCountLabel";
            appleCountLabel.Size = new Size(74, 15);
            appleCountLabel.TabIndex = 16;
            appleCountLabel.Text = "Apple Count";
            // 
            // foodGrowMultiplierLabel
            // 
            foodGrowMultiplierLabel.AutoSize = true;
            foodGrowMultiplierLabel.Location = new Point(58, 337);
            foodGrowMultiplierLabel.Margin = new Padding(4, 0, 4, 0);
            foodGrowMultiplierLabel.Name = "foodGrowMultiplierLabel";
            foodGrowMultiplierLabel.Size = new Size(101, 15);
            foodGrowMultiplierLabel.TabIndex = 17;
            foodGrowMultiplierLabel.Text = "Food Grow Factor";
            // 
            // player1HeadColorLabel
            // 
            player1HeadColorLabel.AutoSize = true;
            player1HeadColorLabel.Location = new Point(58, 150);
            player1HeadColorLabel.Margin = new Padding(4, 0, 4, 0);
            player1HeadColorLabel.Name = "player1HeadColorLabel";
            player1HeadColorLabel.Size = new Size(38, 15);
            player1HeadColorLabel.TabIndex = 18;
            player1HeadColorLabel.Text = "label1";
            // 
            // player1BodyColorLabel
            // 
            player1BodyColorLabel.AutoSize = true;
            player1BodyColorLabel.Location = new Point(58, 174);
            player1BodyColorLabel.Margin = new Padding(4, 0, 4, 0);
            player1BodyColorLabel.Name = "player1BodyColorLabel";
            player1BodyColorLabel.Size = new Size(38, 15);
            player1BodyColorLabel.TabIndex = 19;
            player1BodyColorLabel.Text = "label2";
            // 
            // player2HeadColorLabel
            // 
            player2HeadColorLabel.AutoSize = true;
            player2HeadColorLabel.Location = new Point(292, 150);
            player2HeadColorLabel.Margin = new Padding(4, 0, 4, 0);
            player2HeadColorLabel.Name = "player2HeadColorLabel";
            player2HeadColorLabel.Size = new Size(38, 15);
            player2HeadColorLabel.TabIndex = 20;
            player2HeadColorLabel.Text = "label3";
            // 
            // player2BodyColorLabel
            // 
            player2BodyColorLabel.AutoSize = true;
            player2BodyColorLabel.Location = new Point(292, 174);
            player2BodyColorLabel.Margin = new Padding(4, 0, 4, 0);
            player2BodyColorLabel.Name = "player2BodyColorLabel";
            player2BodyColorLabel.Size = new Size(38, 15);
            player2BodyColorLabel.TabIndex = 21;
            player2BodyColorLabel.Text = "label4";
            // 
            // player1NameLabel
            // 
            player1NameLabel.AutoSize = true;
            player1NameLabel.Location = new Point(58, 23);
            player1NameLabel.Margin = new Padding(4, 0, 4, 0);
            player1NameLabel.Name = "player1NameLabel";
            player1NameLabel.Size = new Size(83, 15);
            player1NameLabel.TabIndex = 22;
            player1NameLabel.Text = "Player 1 Name";
            // 
            // player2NameLabel
            // 
            player2NameLabel.AutoSize = true;
            player2NameLabel.Location = new Point(292, 23);
            player2NameLabel.Margin = new Padding(4, 0, 4, 0);
            player2NameLabel.Name = "player2NameLabel";
            player2NameLabel.Size = new Size(83, 15);
            player2NameLabel.TabIndex = 23;
            player2NameLabel.Text = "Player 2 Name";
            // 
            // DifficultyLabel
            // 
            DifficultyLabel.AutoSize = true;
            DifficultyLabel.Location = new Point(58, 372);
            DifficultyLabel.Margin = new Padding(4, 0, 4, 0);
            DifficultyLabel.Name = "DifficultyLabel";
            DifficultyLabel.Size = new Size(55, 15);
            DifficultyLabel.TabIndex = 25;
            DifficultyLabel.Text = "Difficulty";
            DifficultyLabel.Click += label1_Click;
            // 
            // dificultyCBox
            // 
            dificultyCBox.FormattingEnabled = true;
            dificultyCBox.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            dificultyCBox.Location = new Point(175, 369);
            dificultyCBox.Name = "dificultyCBox";
            dificultyCBox.Size = new Size(121, 23);
            dificultyCBox.TabIndex = 26;
            // 
            // fatSerpentCheckBox
            // 
            fatSerpentCheckBox.AutoSize = true;
            fatSerpentCheckBox.Location = new Point(175, 407);
            fatSerpentCheckBox.Name = "fatSerpentCheckBox";
            fatSerpentCheckBox.Size = new Size(15, 14);
            fatSerpentCheckBox.TabIndex = 27;
            fatSerpentCheckBox.UseVisualStyleBackColor = true;
            // 
            // countdownNumericUpDown
            // 
            countdownNumericUpDown.Location = new Point(175, 441);
            countdownNumericUpDown.Name = "countdownNumericUpDown";
            countdownNumericUpDown.Size = new Size(47, 23);
            countdownNumericUpDown.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 443);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 29;
            label1.Text = "Count Down:";
            // 
            // fatserpentlabel
            // 
            fatserpentlabel.AutoSize = true;
            fatserpentlabel.Location = new Point(58, 406);
            fatserpentlabel.Name = "fatserpentlabel";
            fatserpentlabel.Size = new Size(68, 15);
            fatserpentlabel.TabIndex = 30;
            fatserpentlabel.Text = "Fat-Serpent";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 514);
            Controls.Add(fatserpentlabel);
            Controls.Add(label1);
            Controls.Add(countdownNumericUpDown);
            Controls.Add(fatSerpentCheckBox);
            Controls.Add(dificultyCBox);
            Controls.Add(DifficultyLabel);
            Controls.Add(player2NameLabel);
            Controls.Add(player1NameLabel);
            Controls.Add(player2BodyColorLabel);
            Controls.Add(player2HeadColorLabel);
            Controls.Add(player1BodyColorLabel);
            Controls.Add(player1HeadColorLabel);
            Controls.Add(foodGrowMultiplierLabel);
            Controls.Add(appleCountLabel);
            Controls.Add(fpsLabel);
            Controls.Add(initialPlayerLengthLabel);
            Controls.Add(aiPlayersLabel);
            Controls.Add(backButton);
            Controls.Add(saveButton);
            Controls.Add(foodGrowMultiplierNumericUpDown);
            Controls.Add(appleCountNumericUpDown);
            Controls.Add(fpsNumericUpDown);
            Controls.Add(initialPlayerLengthNumericUpDown);
            Controls.Add(aiPlayersNumericUpDown);
            Controls.Add(player2BodyColorButton);
            Controls.Add(player2HeadColorButton);
            Controls.Add(player1BodyColorButton);
            Controls.Add(player1HeadColorButton);
            Controls.Add(player2NameTextBox);
            Controls.Add(player1NameTextBox);
            Margin = new Padding(4, 3, 4, 3);
            Name = "SettingsForm";
            Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)aiPlayersNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)initialPlayerLengthNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)fpsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)appleCountNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)foodGrowMultiplierNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)countdownNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Label DifficultyLabel;
        private ComboBox dificultyCBox;
        private CheckBox fatSerpentCheckBox;
        private NumericUpDown countdownNumericUpDown;
        private Label label1;
        private Label fatserpentlabel;
    }
}
