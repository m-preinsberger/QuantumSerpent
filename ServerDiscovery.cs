using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace QuantumSerpent
{
    public class ServerDiscovery
    {
        // Interval between server broadcast messages in milliseconds.
        private const int BroadcastInterval = 2000;
        // Message prefix for server discovery.
        private const string BroadcastMessage = "QuantumSerpentServer";
        // UDP client for sending and receiving broadcast messages.
        private UdpClient udpClient;
        // Endpoint for broadcasting messages.
        private IPEndPoint broadcastEndPoint;

        // Constructor: Initializes UDP client and broadcast endpoint.
        public ServerDiscovery()
        {
            udpClient = new UdpClient();
            udpClient.EnableBroadcast = true;
            broadcastEndPoint = new IPEndPoint(IPAddress.Broadcast, 27800);
        }

        // Continuously broadcasts server information at a set interval.
        public async void BroadcastServerInfo(int port)
        {
            var message = Encoding.UTF8.GetBytes($"{BroadcastMessage}:{port}");
            while (true)
            {
                await udpClient.SendAsync(message, message.Length, broadcastEndPoint);
                await Task.Delay(BroadcastInterval);
            }
        }

        // Listens for server broadcast messages and returns the server's IP address.
        public async Task<string?> DiscoverServer(int port)
        {
            using (UdpClient udpClient = new UdpClient(port))
            {
                var endPoint = new IPEndPoint(IPAddress.Any, port);

                try
                {
                    UdpReceiveResult receiveResult = await udpClient.ReceiveAsync();
                    string message = Encoding.UTF8.GetString(receiveResult.Buffer);

                    if (message.StartsWith(BroadcastMessage))
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

        // Stops the broadcast by closing the UDP client.
        public void StopBroadcast()
        {
            udpClient.Close();
        }
    }
}
