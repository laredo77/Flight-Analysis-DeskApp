﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class Client : IClient
    {
        TcpClient client;
        NetworkStream stream;


        public Client()
        {
            client = new TcpClient();
        }
        public Client(string ip, int port)
        {
            client = new TcpClient(ip, port);
            stream = client.GetStream();
            stream.Flush();
        }
        public void connect(string ip, int port)
        {
            client = new TcpClient(ip, port);
            // Get a client stream for reading and writing.
            stream = client.GetStream();
        }
        public void disconnect()
        {
            // Close everything.
            stream.Close();
            client.Close();
        }

        public string read()
        {
            // Translate the passed message into ASCII and store it as a Byte array.
            //Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            // Buffer to store the response bytes.
            Byte[] data = new Byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            return responseData;
        }

        public void write(string command)
        {
            Byte[] data = ASCIIEncoding.ASCII.GetBytes(command + "\r\n");
            stream.Write(data, 0, data.Length);
            stream.Flush();
        }
    }
}