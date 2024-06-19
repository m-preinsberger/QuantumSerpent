using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace QuantumSerpent
{
    public class ServerDiscovery
    {
        private const int BroadcastInterval = 2000; // milliseconds
        private const string BroadcastMessage = "QuantumSerpentServer";
        private UdpClient udpClient;
        private IPEndPoint broadcastEndPoint;

        public ServerDiscovery()
        {
            udpClient = new UdpClient();
            udpClient.EnableBroadcast = true;
            broadcastEndPoint = new IPEndPoint(IPAddress.Broadcast, 27800);
        }

        public async void BroadcastServerInfo(int port)
        {
            var message = Encoding.UTF8.GetBytes($"{BroadcastMessage}:{port}");
            while (true)
            {
                await udpClient.SendAsync(message, message.Length, broadcastEndPoint);
                await Task.Delay(BroadcastInterval);
            }
        }
        public async Task<string?> DiscoverServer(int port)
        {
            using (UdpClient udpClient = new UdpClient(port))
            {
                var endPoint = new IPEndPoint(IPAddress.Any, port);

                try
                {
                    UdpReceiveResult receiveResult = await udpClient.ReceiveAsync();
                    string message = Encoding.UTF8.GetString(receiveResult.Buffer);

                    if (message.StartsWith("QuantumSerpentServer"))
                    {
                        string[] parts = message.Split(':');
                        if (parts.Length == 2 && int.TryParse(parts[1], out int serverPort))
                        {
                            return receiveResult.RemoteEndPoint.Address.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error discovering server: {ex.Message}");
                }
            }
            return null;
        }

        public void StopBroadcast()
        {
            udpClient.Close();
        }
    }
}
