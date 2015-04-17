using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Animator
{
    class UdpReader
    {

        private static Thread threadSend = new Thread(send);
        private static Thread threadReceive = new Thread(receive);


        public static void Initialize()
        {
            //threadReceive.Start(); 
            threadSend.Start();

        }

        public static void send()
        {
            //jsonSendThread.Start(); // commented for testing

            udpBroadcastMessage("helloooooo", 4);
        }

        public static void receive()
        {
            Console.WriteLine("recccc");
            int portNumber = 4;
            string local_ip = getLocalIP();
            try
            {
                // This constructor arbitrarily assigns the local port number.
                UdpClient udpClient = new UdpClient(portNumber);
                // enable broadcast
                udpClient.EnableBroadcast = true;

                //IPAddress broadcast = IPAddress.Parse("172.18.160.255");
                IPAddress broadcastIP = IPAddress.Parse(getBroadcastIP(local_ip));
                IPEndPoint ep = new IPEndPoint(broadcastIP, portNumber);

                while (true)
                {
                    byte[] receivedBytes = udpClient.Receive(ref ep);

                    Console.WriteLine(" @@@@@@@@@@@@@ " + receivedBytes);
                }
                udpClient.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Use this static method to broadcast UDP simple strings.
        /// </summary>
        /// <param name="message">String message to be broadcast as ASCII</param>
        /// <param name="portNum">Port number to transmist from and to</param>
        /// <param name="yourIP">please provide your IP address to broadcast on.</param>
        public static void udpBroadcastMessage(string message, int portNumber)
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

                while (true)
                {
                    //udpClient.Send(sendBytes, sendBytes.Length, ep);
                    byte[] receivedBytes = udpClient.Receive(ref ep);
                    string returnData = Encoding.ASCII.GetString(receivedBytes);

                    Console.WriteLine(" @@@@@@@@@@@@@ " + returnData);

                }



                udpClient.Close();

                Console.WriteLine(":: " + message);

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
