using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class ClientDiscovery
{
    private const int DiscoveryPort = 27801; // Port for discovery messages.
    private UdpClient udpClient; // UDP client for receiving messages.
    private IPEndPoint endPoint; // Endpoint for receiving messages.
    private bool isListening; // Flag to control listening loop.

    // Event triggered when a server is discovered.
    public event Action<string, int> ServerDiscovered;

    // Constructor: Initializes UDP client and starts listening thread.
    public ClientDiscovery()
    {
        udpClient = new UdpClient(DiscoveryPort);
        endPoint = new IPEndPoint(IPAddress.Any, DiscoveryPort);
        isListening = true;

        Thread listenThread = new Thread(ListenForServers);
        listenThread.Start();
    }

    // Listens for discovery messages from servers.
    private void ListenForServers()
    {
        while (isListening)
        {
            byte[] data = udpClient.Receive(ref endPoint); // Block until data is received.
            string message = Encoding.ASCII.GetString(data); // Convert bytes to string.

            // Check if message is a server announcement.
            if (message.StartsWith("QuantumSerpentServer"))
            {
                string[] parts = message.Split(':');
                int port = int.Parse(parts[1]); // Extract server port.
                ServerDiscovered?.Invoke(endPoint.Address.ToString(), port); // Trigger event.
            }
        }
    }

    // Stops listening and closes UDP client.
    public void Stop()
    {
        isListening = false;
        udpClient.Close();
    }
}
