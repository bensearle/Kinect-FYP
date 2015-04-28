using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KinectTrackerAndBroadcaster
{
    public class UdpSend
    {

        public static void Start()
        {

            byte[] data = new byte[1024];
            string input, stringData;
            IPEndPoint ipep = new IPEndPoint(
                            IPAddress.Parse("192.168.1.255"), 4);

            Socket server = new Socket(AddressFamily.InterNetwork,
                           SocketType.Dgram, ProtocolType.Udp);


            string welcome = "Hello, are you there?";
            data = Encoding.ASCII.GetBytes(welcome);
            server.SendTo(data, data.Length, SocketFlags.None, ipep);

            
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)sender;

            data = new byte[1024];
            int recv = server.ReceiveFrom(data, ref Remote);

            Console.WriteLine("Message received from {0}:", Remote.ToString());
            Console.WriteLine("!!!!!!!!!!!");
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
            Console.WriteLine("!!!!!!!!!!!");

            while (true)
            {
                input = Console.ReadLine();
                if (input == "exit")
                    break;
                server.SendTo(Encoding.ASCII.GetBytes(input), Remote);
                data = new byte[1024];
                recv = server.ReceiveFrom(data, ref Remote);
                Console.WriteLine("!!!!!!!!!!!***");
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine("!!!!!!!!!!!***");
                Console.WriteLine(stringData);
            }
            Console.WriteLine("Stopping client");
            server.Close();
        }

        /// <summary>
        /// Use this static method to broadcast UDP simple strings.
        /// </summary>
        /// <param name="message">String message to be broadcast as ASCII</param>
        /// <param name="portNum">Port number to transmist from and to</param>
        /// <param name="yourIP">please provide your IP address to broadcast on.</param>
        public static void UdpBroadcastMessage(string message, int portNumber)
        {
            string local_ip = getLocalIP();
            try
            {
                // This constructor arbitrarily assigns the local port number.
                UdpClient udpClient = new UdpClient(portNumber);
                // enable broadcast
                udpClient.EnableBroadcast = true;


                // Sends a message to the host to which you have connected.
                byte[] sendBytes = Encoding.ASCII.GetBytes(message);

                //IPAddress broadcast = IPAddress.Parse("172.18.160.255");
                IPAddress broadcastIP = IPAddress.Parse(getBroadcastIP(local_ip));
                IPEndPoint ep = new IPEndPoint(broadcastIP, portNumber);

                udpClient.Send(sendBytes, sendBytes.Length, ep);

                udpClient.Close();

                Console.WriteLine(":: "+message);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static string getLocalIP()
        {
            string ip;

            IPAddress[] ipv4Addresses = Array.FindAll(
                Dns.GetHostEntry(string.Empty).AddressList,
                a => a.AddressFamily == AddressFamily.InterNetwork);

            ip = ipv4Addresses[ipv4Addresses.Length - 1].ToString();
            return ip;


            string host_name = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(host_name);
            IPAddress[] ip_address = ipEntry.AddressList;
            ip = ip_address[ip_address.Length - 1].ToString();
            //Console.WriteLine(ip_address[ip_address.Length - 1].ToString());
            /*
            // if statement below return ipv6 if used - not wanted for this purpose
            if (addr[0].AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
                returnIP = addr[0].ToString();
                Console.WriteLine(addr[0].ToString()); //ipv6
            }*/
            return ip;
        }

        private static string getBroadcastIP(string local_ip)
        {
            string bIP;
            string[] parts = local_ip.Split('.'); //  separate the ip address in to a list of strings
            bIP = parts[0] + "." + parts[1] + "." + parts[2] + ".255";
            return bIP;
        }

    }
}
