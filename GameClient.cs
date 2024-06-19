using System.Net.Sockets;

namespace QuantumSerpent
{
    public class GameClient
    {
        // Server IP and port for connection.
        private string serverIp;
        private int port;
        // TCP client for managing the connection.
        private TcpClient client;

        // Constructor: Initializes the client with server details.
        public GameClient(string serverIp, int port)
        {
            this.serverIp = serverIp;
            this.port = port;
            client = new TcpClient();
        }

        // Attempts to connect to the server. Returns true if successful.
        public bool Connect()
        {
            try
            {
                client.Connect(serverIp, port);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
