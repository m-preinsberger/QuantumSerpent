using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuantumSerpent
{
    public partial class StartForm : Form
    {
        // Constructor: Initializes the form and loads highscores.
        public StartForm()
        {
            InitializeComponent();
            LoadAndDisplayHighscores();
        }

        // Starts a singleplayer game.
        private void SingleplayerButton_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm("Singleplayer", 0);
            this.Hide();
            mainForm.Show();
        }

        // Starts a multiplayer game.
        private void MultiplayerButton_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm("Multiplayer", 0);
            this.Hide();
            mainForm.Show();
        }

        // Displays a message for upcoming features.
        private void ModsAndTexturePacksButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mods and Texture Packs feature is coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Opens the settings form.
        private void OptionsButton_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            this.Hide();
            settingsForm.ShowDialog();
            this.Show();
        }

        // Opens the project's GitHub page.
        private void GithubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/m-preinsberger/QuantumSerpent",
                UseShellExecute = true
            });
        }

        // Updates the highscore list.
        private void UpdateHighscoreList()
        {
            var highscores = GameSettingsManager.LoadHighscores();
            topPlayersListBox.Items.Clear();

            foreach (var highscore in highscores.OrderByDescending(h => h.Score))
            {
                topPlayersListBox.Items.Add($"{highscore.PlayerName}: {highscore.Score}");
            }
        }

        // Updates highscores when the form is shown.
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            UpdateHighscoreList();
        }

        // Loads and displays highscores.
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
