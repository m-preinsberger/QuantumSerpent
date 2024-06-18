using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuantumSerpent
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            LoadAndDisplayHighscores();
        }

        private void SingleplayerButton_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm("Singleplayer", 0);
            this.Hide();
            mainForm.Show();
        }

        private void MultiplayerButton_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm("Multiplayer", 0);
            this.Hide();
            mainForm.Show();
        }

        private void ModsAndTexturePacksButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mods and Texture Packs feature is coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            this.Hide();
            settingsForm.ShowDialog();
            this.Show();
        }

        private void GithubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/m-preinsberger/QuantumSerpent",
                UseShellExecute = true
            });
        }
        // Add this method to update the highscore list
        private void UpdateHighscoreList()
        {
            var highscores = GameSettingsManager.LoadHighscores();
            topPlayersListBox.Items.Clear();

            foreach (var highscore in highscores.OrderByDescending(h => h.Score))
            {
                topPlayersListBox.Items.Add($"{highscore.PlayerName}: {highscore.Score}");
            }
        }

        // Override the OnActivated method to update highscores when the form is shown
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            UpdateHighscoreList();
        }
        private void LoadAndDisplayHighscores()
        {
            var highscores = GameSettingsManager.LoadHighscores();

            var sortedHighscores = highscores
                .OrderByDescending(h => h.Score)
                .Take(10)
                .ToList();

            topPlayersListBox.Items.Clear();

            foreach (var highscore in sortedHighscores)
            {
                topPlayersListBox.Items.Add($"{highscore.PlayerName}: {highscore.Score}");
            }
        }
    }
}
