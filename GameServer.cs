using System.Net.Sockets;
using System.Net;
using System.Text;

namespace QuantumSerpent
{
    public class GameServer
    {
        private int port; // Server port.
        private TcpListener listener; // Listens for TCP connections.
        private UdpClient broadcaster; // Broadcasts server presence.

        // Initializes server with specified port.
        public GameServer(int port)
        {
            this.port = port;
            listener = new TcpListener(IPAddress.Any, port);
            broadcaster = new UdpClient();
        }

        // Starts the server: begins listening and broadcasting.
        public void Start()
        {
            listener.Start(); // Start listening for TCP connections.
            StartBroadcasting(); // Start broadcasting server presence.
                                 // Additional server logic
        }

        // Broadcasts server presence over UDP.
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
