﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuantumSerpent
{
    public partial class SettingsForm : Form
    {
        // Constructor: Initializes the form and loads saved settings.
        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        // Opens a color dialog for Player 1's head color and updates the label background.
        private void ChooseColorPlayer1Head(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                player1HeadColorLabel.BackColor = colorDialog.Color;
            }
        }

        // Opens a color dialog for Player 1's body color and updates the label background.
        private void ChooseColorPlayer1Body(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                player1BodyColorLabel.BackColor = colorDialog.Color;
            }
        }

        // Opens a color dialog for Player 2's head color and updates the label background.
        private void ChooseColorPlayer2Head(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                player2HeadColorLabel.BackColor = colorDialog.Color;
            }
        }

        // Opens a color dialog for Player 2's body color and updates the label background.
        private void ChooseColorPlayer2Body(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                player2BodyColorLabel.BackColor = colorDialog.Color;
            }
        }

        // Saves the current settings and displays a confirmation message.
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var settings = new GameSettings
            {
                Player1Name = player1NameTextBox.Text,
                Player1HeadColor = player1HeadColorLabel.BackColor,
                Player1BodyColor = player1BodyColorLabel.BackColor,
                Player2Name = player2NameTextBox.Text,
                Player2HeadColor = player2HeadColorLabel.BackColor,
                Player2BodyColor = player2BodyColorLabel.BackColor,
                InitialPlayerLength = (int)initialPlayerLengthNumericUpDown.Value,
                AIPlayers = (int)aiPlayersNumericUpDown.Value,
                FPS = (int)fpsNumericUpDown.Value,
                AppleCount = (int)appleCountNumericUpDown.Value,
                FoodGrowMultiplier = (int)foodGrowMultiplierNumericUpDown.Value,
                IsFatSerpentMode = fatSerpentCheckBox.Checked,
                FatSerpentTimeFrame = (int)countdownNumericUpDown.Value
            };

            GameSettingsManager.Save(settings);
            MessageBox.Show("Settings saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Closes the settings form.
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Loads settings and updates the form fields accordingly.
        private void LoadSettings()
        {
            var settings = GameSettingsManager.Load();
            player1NameTextBox.Text = settings.Player1Name;
            player1HeadColorLabel.BackColor = settings.Player1HeadColor;
            player1BodyColorLabel.BackColor = settings.Player1BodyColor;
            player2NameTextBox.Text = settings.Player2Name;
            player2HeadColorLabel.BackColor = settings.Player2HeadColor;
            player2BodyColorLabel.BackColor = settings.Player2BodyColor;
            initialPlayerLengthNumericUpDown.Value = settings.InitialPlayerLength;
            aiPlayersNumericUpDown.Value = settings.AIPlayers;
            fpsNumericUpDown.Value = settings.FPS;
            appleCountNumericUpDown.Value = settings.AppleCount;
            foodGrowMultiplierNumericUpDown.Value = settings.FoodGrowMultiplier;
        }

        // Placeholder for label click event.
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
