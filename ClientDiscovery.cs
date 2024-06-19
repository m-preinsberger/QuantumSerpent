using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class ClientDiscovery
{
    private const int DiscoveryPort = 27801;
    private UdpClient udpClient;
    private IPEndPoint endPoint;
    private bool isListening;

    public event Action<string, int> ServerDiscovered;

    public ClientDiscovery()
    {
        udpClient = new UdpClient(DiscoveryPort);
        endPoint = new IPEndPoint(IPAddress.Any, DiscoveryPort);
        isListening = true;

        Thread listenThread = new Thread(ListenForServers);
        listenThread.Start();
    }

    private void ListenForServers()
    {
        while (isListening)
        {
            byte[] data = udpClient.Receive(ref endPoint);
            string message = Encoding.ASCII.GetString(data);

            if (message.StartsWith("QuantumSerpentServer"))
            {
                string[] parts = message.Split(':');
                int port = int.Parse(parts[1]);
                ServerDiscovered?.Invoke(endPoint.Address.ToString(), port);
            }
        }
    }

    public void Stop()
    {
        isListening = false;
        udpClient.Close();
    }
}
