using System.Net.Sockets;

namespace QuantumSerpent
{
    public class GameClient
    {
        private string serverIp;
        private int port;
        private TcpClient client;

        public GameClient(string serverIp, int port)
        {
            this.serverIp = serverIp;
            this.port = port;
            client = new TcpClient();
        }

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

        // Additional client methods
    }
}
