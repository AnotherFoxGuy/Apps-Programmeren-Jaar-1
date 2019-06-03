using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace Week5
{
    class Connection
    {
        private Socket _connectionSocket;
        private IPAddress _iPAddress;
        private IPEndPoint _endPoint;
        private readonly byte[] bytes = new byte[1024];

        public bool CheckValidIpAddress(string ip)
        {
            if (ip != "")
            {
                //Check user input against regex (check if IP address is not empty).
                Regex regex = new Regex("\\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(\\.|$)){4}\\b");
                Match match = regex.Match(ip);
                return match.Success;
            }
            else return false;
        }
        public void SetConnection(string ip, int port)
        {
            _iPAddress = IPAddress.Parse(ip);
            _endPoint = new IPEndPoint(_iPAddress, port);
        }
        public void OpenConnection()
        {
            _connectionSocket = new Socket(_iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _connectionSocket.Connect(_endPoint);
        }
        public void CloseConnection()
        {
            _connectionSocket.Shutdown(SocketShutdown.Both);
            _connectionSocket.Close();
        }
        private void SendData(string data)
        {
            _connectionSocket.Send(Encoding.ASCII.GetBytes(data));
        }
        public string ReciveData(string dataToSend)
        {
            SendData(dataToSend);
            int dataRecived = _connectionSocket.Receive(bytes);
            return Encoding.ASCII.GetString(bytes, 0, dataRecived);
        }
    }
}
