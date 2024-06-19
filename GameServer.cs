using System.Net.Sockets;
using System.Net;
using System.Text;

namespace QuantumSerpent
{
    public class GameServer
    {
        private int port;
        private TcpListener listener;
        private UdpClient broadcaster;

        public GameServer(int port)
        {
            this.port = port;
            listener = new TcpListener(IPAddress.Any, port);
            broadcaster = new UdpClient();
        }

        public void Start()
        {
            listener.Start();
            StartBroadcasting();
            // Additional server logic
        }

        private void StartBroadcasting()
        {
            IPEndPoint broadcastEndpoint = new IPEndPoint(IPAddress.Broadcast, 5001);
            string message = $"QuantumSerpentServer:{port}";
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            broadcaster.Send(messageBytes, messageBytes.Length, broadcastEndpoint);
        }

        // Additional server methods
    }
}
