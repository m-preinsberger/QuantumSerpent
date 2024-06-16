namespace QuantumSerpent
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
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
    }
}
