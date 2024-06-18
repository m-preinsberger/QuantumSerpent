namespace QuantumSerpent
{
    partial class StartForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label headerLabel;
        private Button singleplayerButton;
        private Button multiplayerButton;
        private Button modsAndTexturePacksButton;
        private Button optionsButton;
        private LinkLabel githubLinkLabel;
        private Label topPlayersLabel;
        private ListBox topPlayersListBox;

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
            this.headerLabel = new System.Windows.Forms.Label();
            this.singleplayerButton = new System.Windows.Forms.Button();
            this.multiplayerButton = new System.Windows.Forms.Button();
            this.modsAndTexturePacksButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.githubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.topPlayersLabel = new System.Windows.Forms.Label();
            this.topPlayersListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(14, 10);
            this.headerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(420, 35);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Quantum Serpent";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // singleplayerButton
            // 
            this.singleplayerButton.Location = new System.Drawing.Point(146, 69);
            this.singleplayerButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.singleplayerButton.Name = "singleplayerButton";
            this.singleplayerButton.Size = new System.Drawing.Size(175, 46);
            this.singleplayerButton.TabIndex = 1;
            this.singleplayerButton.Text = "Singleplayer";
            this.singleplayerButton.UseVisualStyleBackColor = true;
            this.singleplayerButton.Click += new System.EventHandler(this.SingleplayerButton_Click);
            // 
            // multiplayerButton
            // 
            this.multiplayerButton.Location = new System.Drawing.Point(146, 127);
            this.multiplayerButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.multiplayerButton.Name = "multiplayerButton";
            this.multiplayerButton.Size = new System.Drawing.Size(175, 46);
            this.multiplayerButton.TabIndex = 2;
            this.multiplayerButton.Text = "Multiplayer";
            this.multiplayerButton.UseVisualStyleBackColor = true;
            this.multiplayerButton.Click += new System.EventHandler(this.MultiplayerButton_Click);
            // 
            // modsAndTexturePacksButton
            // 
            this.modsAndTexturePacksButton.Location = new System.Drawing.Point(146, 185);
            this.modsAndTexturePacksButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.modsAndTexturePacksButton.Name = "modsAndTexturePacksButton";
            this.modsAndTexturePacksButton.Size = new System.Drawing.Size(175, 46);
            this.modsAndTexturePacksButton.TabIndex = 3;
            this.modsAndTexturePacksButton.Text = "Mods and Texture Packs";
            this.modsAndTexturePacksButton.UseVisualStyleBackColor = true;
            this.modsAndTexturePacksButton.Click += new System.EventHandler(this.ModsAndTexturePacksButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Location = new System.Drawing.Point(146, 242);
            this.optionsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(175, 46);
            this.optionsButton.TabIndex = 4;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // githubLinkLabel
            // 
            this.githubLinkLabel.AutoSize = true;
            this.githubLinkLabel.Location = new System.Drawing.Point(198, 312);
            this.githubLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.githubLinkLabel.Name = "githubLinkLabel";
            this.githubLinkLabel.Size = new System.Drawing.Size(45, 15);
            this.githubLinkLabel.TabIndex = 5;
            this.githubLinkLabel.TabStop = true;
            this.githubLinkLabel.Text = "GitHub";
            this.githubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GithubLinkLabel_LinkClicked);
            // 
            // topPlayersLabel
            // 
            this.topPlayersLabel.AutoSize = true;
            this.topPlayersLabel.Location = new System.Drawing.Point(12, 54);
            this.topPlayersLabel.Name = "topPlayersLabel";
            this.topPlayersLabel.Size = new System.Drawing.Size(84, 15);
            this.topPlayersLabel.TabIndex = 6;
            this.topPlayersLabel.Text = "Top 10 Players:";
            // 
            // topPlayersListBox
            // 
            this.topPlayersListBox.FormattingEnabled = true;
            this.topPlayersListBox.ItemHeight = 15;
            this.topPlayersListBox.Location = new System.Drawing.Point(12, 72);
            this.topPlayersListBox.Name = "topPlayersListBox";
            this.topPlayersListBox.Size = new System.Drawing.Size(120, 229);
            this.topPlayersListBox.TabIndex = 7;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 359);
            this.Controls.Add(this.topPlayersListBox);
            this.Controls.Add(this.topPlayersLabel);
            this.Controls.Add(this.githubLinkLabel);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.modsAndTexturePacksButton);
            this.Controls.Add(this.multiplayerButton);
            this.Controls.Add(this.singleplayerButton);
            this.Controls.Add(this.headerLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "StartForm";
            this.Text = "Quantum Serpent";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
