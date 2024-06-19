using System.Windows.Forms;

namespace QuantumSerpent
{
    partial class NetworkForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button hostButton;
        private Button joinButton;
        private Button refreshButton;
        private ListBox serverListBox;

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
            this.hostButton = new System.Windows.Forms.Button();
            this.joinButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.serverListBox = new System.Windows.Forms.ListBox();

            // 
            // hostButton
            // 
            this.hostButton.Location = new System.Drawing.Point(10, 10);
            this.hostButton.Name = "hostButton";
            this.hostButton.Size = new System.Drawing.Size(100, 30);
            this.hostButton.TabIndex = 0;
            this.hostButton.Text = "Host Game";
            this.hostButton.UseVisualStyleBackColor = true;
            this.hostButton.Click += new System.EventHandler(this.HostGameButton_Click);

            // 
            // joinButton
            // 
            this.joinButton.Location = new System.Drawing.Point(10, 50);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(100, 30);
            this.joinButton.TabIndex = 1;
            this.joinButton.Text = "Join Game";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.JoinGameButton_Click);

            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(10, 90);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 30);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);

            // 
            // serverListBox
            // 
            this.serverListBox.FormattingEnabled = true;
            this.serverListBox.Location = new System.Drawing.Point(120, 10);
            this.serverListBox.Name = "serverListBox";
            this.serverListBox.Size = new System.Drawing.Size(150, 200);
            this.serverListBox.TabIndex = 3;

            // 
            // NetworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.serverListBox);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.hostButton);
            this.Name = "NetworkForm";
            this.Text = "Network Game Setup";
            this.ResumeLayout(false);
        }
    }
}
