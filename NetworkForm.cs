using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections.Generic;

namespace QuantumSerpent
{
    public partial class NetworkForm : Form
    {
        // Discovery port for UDP communication.
        private const int discoveryPort = 5001;
        // UDP client for server discovery.
        private UdpClient discoveryClient;
        // List of discovered servers.
        private List<DiscoveredServer> discoveredServers = new List<DiscoveredServer>();

        public NetworkForm()
        {
            InitializeComponent();
            StartServerDiscovery();
        }

        // Initializes server discovery.
        private void StartServerDiscovery()
        {
            discoveryClient = new UdpClient(discoveryPort);
            discoveryClient.EnableBroadcast = true;
            discoveryClient.BeginReceive(new AsyncCallback(OnDiscoveryMessageReceived), null);
        }

        // Handles received discovery messages.
        private void OnDiscoveryMessageReceived(IAsyncResult ar)
        {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, discoveryPort);
            byte[] data = discoveryClient.EndReceive(ar, ref endpoint);
            string message = System.Text.Encoding.ASCII.GetString(data);
            string[] messageParts = message.Split(':');
            if (messageParts.Length == 2 && messageParts[0] == "QuantumSerpentServer")
            {
                string serverIp = endpoint.Address.ToString();
                int serverPort;
                if (int.TryParse(messageParts[1], out serverPort))
                {
                    discoveredServers.Add(new DiscoveredServer { IP = serverIp, Port = serverPort, ServerInfo = $"{serverIp}:{serverPort}" });
                    Invoke(new Action(() => UpdateServerListBox()));
                }
            }

            discoveryClient.BeginReceive(new AsyncCallback(OnDiscoveryMessageReceived), null);
        }

        // Updates the server list box with discovered servers.
        private void UpdateServerListBox()
        {
            serverListBox.DataSource = null;
            serverListBox.DataSource = discoveredServers;
            serverListBox.DisplayMember = "ServerInfo";
        }

        // Hosts a new game.
        private void HostGameButton_Click(object sender, EventArgs e)
        {
            int gamePort = 5000;
            GameServer server = new GameServer(gamePort);
            MainForm mainForm = new MainForm("LAN", 0);
            this.Hide();
            mainForm.Show();
        }

        // Joins a selected game.
        private void JoinGameButton_Click(object sender, EventArgs e)
        {
            if (serverListBox.SelectedItem is DiscoveredServer selectedServer)
            {
                GameClient client = new GameClient(selectedServer.IP, selectedServer.Port);
                if (client.Connect())
                {
                    MainForm mainForm = new MainForm("LAN", 0);
                    this.Hide();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Failed to connect to the server.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a server to join.", "No Server Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Refreshes the list of discovered servers.
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            discoveredServers.Clear();
            UpdateServerListBox();

            UdpClient broadcastClient = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, discoveryPort);
            byte[] message = System.Text.Encoding.ASCII.GetBytes("QuantumSerpentClient:LookingForServer");
            broadcastClient.Send(message, message.Length, endPoint);
        }

        // Represents a discovered server.
        private class DiscoveredServer
        {
            public string IP { get; set; }
            public int Port { get; set; }
            public string ServerInfo { get; set; }
        }
    }
}
