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
        /// <summary>
        /// broadcast udp message over given port
        /// </summary>
        /// <param name="message">message to be sent</param>
        /// <param name="portNumber">port number to be used</param>
        public static void UdpBroadcastMessage(string message, int portNumber)
        {
            string local_ip = getLocalIP(); // get the local ip address
            try
            {
                UdpClient udpClient = new UdpClient(portNumber); // initialize udp client with port number to be sent from
                udpClient.EnableBroadcast = true; // enable broadcast

                byte[] sendBytes = Encoding.ASCII.GetBytes(message); // convert message to bytes

                IPAddress broadcastIP = IPAddress.Parse(getBroadcastIP(local_ip)); // get the destination ip address
                IPEndPoint ep = new IPEndPoint(broadcastIP, portNumber); // set the desination ip address and port number

                udpClient.Send(sendBytes, sendBytes.Length, ep); // send the data

                udpClient.Close(); // close the udp client

                Console.WriteLine(":: "+message);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// get the ip address of the local machine
        /// </summary>
        /// <returns>ipv4 address</returns>
        private static string getLocalIP()
        {
            string ip; // initialize ip address

            // get list of ip addresses from dns
            IPAddress[] ipv4Addresses = Array.FindAll(
                Dns.GetHostEntry(string.Empty).AddressList,
                a => a.AddressFamily == AddressFamily.InterNetwork);

            ip = ipv4Addresses[ipv4Addresses.Length - 1].ToString(); // last ip address is local

            return ip; // return ip address
        }

        /// <summary>
        /// creates a desintation address by changing last part of ip to .255
        /// </summary>
        /// <param name="local_ip">ipv4 address</param>
        /// <returns>ipv4 address</returns>
        private static string getBroadcastIP(string local_ip)
        {
            string bIP; // initialize destination address
            string[] parts = local_ip.Split('.'); //  separate the ip address in to a list of parts
            bIP = parts[0] + "." + parts[1] + "." + parts[2] + ".255"; // chage the last part of address to .255
            return bIP; // return destination address
        }

    }
}
