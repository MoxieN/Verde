using System;
using System.Text;
using Cosmos.System.Network.IPv4;
using Cosmos.System.Network.IPv4.TCP;

namespace VerdeKernel.Libraries.Verde // Change this to where you store this file
{
    public class Manager
    {
        public string Install(string address, string port, string message, string chs) 
        {
            /* This features a TCP connection
             network initialization is needed*/

            // Parse arguments
            Address add = Address.Parse(address);
            int destPort = Int32.Parse(port);

            // Base local port = 4242
            Console.WriteLine("Connection to destination host");
            using var xClient = new TcpClient(destPort); // Ports should be corresponding
            xClient.Connect(add, destPort);

            // Send data
            Console.WriteLine("Sending request...");
            xClient.Send(Encoding.ASCII.GetBytes(message));

            // Receive data
            var endpoint = new EndPoint(Address.Zero, 0);
            Console.WriteLine("EndPoint set");
            
            var data = xClient.Receive(ref endpoint);  //set endpoint to remote machine IP:port
            Console.WriteLine("Received!");

            return Encoding.UTF8.GetString(data);
        }
    }
}
