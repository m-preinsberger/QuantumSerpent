using System;
using System.Windows.Forms;

namespace QuantumSerpent
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            // Load current game mode setting
            gameModeComboBox.SelectedIndex = 0; // Set default to Singleplayer
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Start the game based on the selected game mode
            string selectedMode = gameModeComboBox.SelectedItem?.ToString() ?? "Singleplayer";
            var gameForm = new MainForm(selectedMode, 0); // Assuming 0 AI players for now
            gameForm.Show();
            this.Hide();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void GithubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/your-repo",
                UseShellExecute = true
            });
        }

        private void SingleplayerButton_Click(object sender, EventArgs e)
        {
            gameModeComboBox.SelectedIndex = gameModeComboBox.Items.IndexOf("Singleplayer");
            StartButton_Click(sender, e);
        }

        private void MultiplayerButton_Click(object sender, EventArgs e)
        {
            gameModeComboBox.SelectedIndex = gameModeComboBox.Items.IndexOf("Multiplayer");
            StartButton_Click(sender, e);
        }

        private void ModsAndTexturePacksButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mods and Texture Packs feature is not implemented yet.");
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            SettingsButton_Click(sender, e);
        }

        private void GameModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle game mode selection
        }
    }
}
