namespace QuantumSerpent
{
    partial class StartForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button singleplayerButton;
        private System.Windows.Forms.Button multiplayerButton;
        private System.Windows.Forms.Button modsAndTexturePacksButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.LinkLabel githubLink;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            headerLabel = new Label();
            githubLink = new LinkLabel();
            singleplayerButton = new Button();
            multiplayerButton = new Button();
            modsAndTexturePacksButton = new Button();
            optionsButton = new Button();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(100, 10);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(192, 26);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Quantum Serpent";
            headerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // githubLink
            // 
            githubLink.AutoSize = true;
            githubLink.Location = new Point(172, 230);
            githubLink.Name = "githubLink";
            githubLink.Size = new Size(45, 15);
            githubLink.TabIndex = 4;
            githubLink.TabStop = true;
            githubLink.Text = "GitHub";
            githubLink.TextAlign = ContentAlignment.MiddleCenter;
            githubLink.LinkClicked += GithubLink_LinkClicked;
            // 
            // singleplayerButton
            // 
            singleplayerButton.Location = new Point(100, 62);
            singleplayerButton.Name = "singleplayerButton";
            singleplayerButton.Size = new Size(192, 34);
            singleplayerButton.TabIndex = 5;
            singleplayerButton.Text = "Singleplayer";
            singleplayerButton.UseVisualStyleBackColor = true;
            singleplayerButton.Click += SingleplayerButton_Click;
            // 
            // multiplayerButton
            // 
            multiplayerButton.Location = new Point(100, 102);
            multiplayerButton.Name = "multiplayerButton";
            multiplayerButton.Size = new Size(192, 34);
            multiplayerButton.TabIndex = 6;
            multiplayerButton.Text = "Multiplayer";
            multiplayerButton.UseVisualStyleBackColor = true;
            multiplayerButton.Click += MultiplayerButton_Click;
            // 
            // modsAndTexturePacksButton
            // 
            modsAndTexturePacksButton.Location = new Point(100, 142);
            modsAndTexturePacksButton.Name = "modsAndTexturePacksButton";
            modsAndTexturePacksButton.Size = new Size(192, 34);
            modsAndTexturePacksButton.TabIndex = 7;
            modsAndTexturePacksButton.Text = "Mods and Texture Packs";
            modsAndTexturePacksButton.UseVisualStyleBackColor = true;
            modsAndTexturePacksButton.Click += ModsAndTexturePacksButton_Click;
            // 
            // optionsButton
            // 
            optionsButton.Location = new Point(100, 182);
            optionsButton.Name = "optionsButton";
            optionsButton.Size = new Size(192, 34);
            optionsButton.TabIndex = 8;
            optionsButton.Text = "Options";
            optionsButton.UseVisualStyleBackColor = true;
            optionsButton.Click += OptionsButton_Click;
            // 
            // StartForm
            // 
            ClientSize = new Size(400, 253);
            Controls.Add(headerLabel);
            Controls.Add(githubLink);
            Controls.Add(singleplayerButton);
            Controls.Add(multiplayerButton);
            Controls.Add(modsAndTexturePacksButton);
            Controls.Add(optionsButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "StartForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quantum Serpent";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
