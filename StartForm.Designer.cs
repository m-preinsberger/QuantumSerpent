namespace QuantumSerpent
{
    partial class StartForm
    {
        private Label headerLabel;
        private Button singleplayerButton;
        private Button multiplayerButton;
        private Button modsAndTexturePacksButton;
        private Button optionsButton;
        private LinkLabel githubLinkLabel;

        private void InitializeComponent()
        {
            this.headerLabel = new Label();
            this.singleplayerButton = new Button();
            this.multiplayerButton = new Button();
            this.modsAndTexturePacksButton = new Button();
            this.optionsButton = new Button();
            this.githubLinkLabel = new LinkLabel();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new Point(12, 9);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new Size(360, 30);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Quantum Serpent";
            this.headerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // singleplayerButton
            // 
            this.singleplayerButton.Location = new Point(125, 60);
            this.singleplayerButton.Name = "singleplayerButton";
            this.singleplayerButton.Size = new Size(150, 40);
            this.singleplayerButton.TabIndex = 1;
            this.singleplayerButton.Text = "Singleplayer";
            this.singleplayerButton.UseVisualStyleBackColor = true;
            this.singleplayerButton.Click += new EventHandler(this.SingleplayerButton_Click);
            // 
            // multiplayerButton
            // 
            this.multiplayerButton.Location = new Point(125, 110);
            this.multiplayerButton.Name = "multiplayerButton";
            this.multiplayerButton.Size = new Size(150, 40);
            this.multiplayerButton.TabIndex = 2;
            this.multiplayerButton.Text = "Multiplayer";
            this.multiplayerButton.UseVisualStyleBackColor = true;
            this.multiplayerButton.Click += new EventHandler(this.MultiplayerButton_Click);
            // 
            // modsAndTexturePacksButton
            // 
            this.modsAndTexturePacksButton.Location = new Point(125, 160);
            this.modsAndTexturePacksButton.Name = "modsAndTexturePacksButton";
            this.modsAndTexturePacksButton.Size = new Size(150, 40);
            this.modsAndTexturePacksButton.TabIndex = 3;
            this.modsAndTexturePacksButton.Text = "Mods and Texture Packs";
            this.modsAndTexturePacksButton.UseVisualStyleBackColor = true;
            this.modsAndTexturePacksButton.Click += new EventHandler(this.ModsAndTexturePacksButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Location = new Point(125, 210);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new Size(150, 40);
            this.optionsButton.TabIndex = 4;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new EventHandler(this.OptionsButton_Click);
            // 
            // githubLinkLabel
            // 
            this.githubLinkLabel.AutoSize = true;
            this.githubLinkLabel.Location = new Point(170, 270);
            this.githubLinkLabel.Name = "githubLinkLabel";
            this.githubLinkLabel.Size = new Size(40, 13);
            this.githubLinkLabel.TabIndex = 5;
            this.githubLinkLabel.TabStop = true;
            this.githubLinkLabel.Text = "GitHub";
            this.githubLinkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(this.GithubLinkLabel_LinkClicked);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(384, 311);
            this.Controls.Add(this.githubLinkLabel);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.modsAndTexturePacksButton);
            this.Controls.Add(this.multiplayerButton);
            this.Controls.Add(this.singleplayerButton);
            this.Controls.Add(this.headerLabel);
            this.Name = "StartForm";
            this.Text = "Quantum Serpent";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
