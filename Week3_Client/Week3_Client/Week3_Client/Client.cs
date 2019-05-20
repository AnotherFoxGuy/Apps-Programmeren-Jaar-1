using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Week3_Client
{
    class Client
    {
        private Socket socket_Sender;
        private IPAddress iPAddress;
        private IPEndPoint endPoint;
        private readonly string dataToSend = "<TEMP>";        
        public Client()
        {
            SetConnection("192.168.1.5", 11000);
            //OpenConnection();
        }

        public void SetConnection(string ip, int port)
        {
            iPAddress = IPAddress.Parse(ip);
            endPoint = new IPEndPoint(iPAddress, port);
        }
        public void OpenConnection()
        {
            socket_Sender = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket_Sender.Connect(endPoint);
        }
        public void CloseConnection()
        {
            socket_Sender.Shutdown(SocketShutdown.Both);
            socket_Sender.Close();
        }
        private void SendData(string data)
        {
            byte[] message = Encoding.ASCII.GetBytes(data);
            socket_Sender.Send(message);
        }
        public string ReciveData()
        {
            SendData(dataToSend);
            var bytes = new byte[1024];
            int dataRecived = socket_Sender.Receive(bytes);
            return Encoding.ASCII.GetString(bytes, 0, dataRecived).Split('>')[1] + "°C";
        }
    }
}
