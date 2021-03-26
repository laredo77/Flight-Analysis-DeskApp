﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Client 
    {
        private int currentLineNumber;
        private int sleepAmount;
        public Client()
        {
            currentLineNumber = 0;
            sleepAmount = 100;
        }
        public int getSleepAmount()
        {
            return this.sleepAmount;
        }
        public void setSleepAmount(int sleepAmount)
        {
            this.sleepAmount = sleepAmount;
        }
        public void start(string csvFilePath)
        {
            int counter = 0;
            TcpClient client = new TcpClient("127.0.0.1", 5400);
            // Get a client stream for reading and writing.
            NetworkStream stream = client.GetStream();
            stream.Flush();
            var lines = File.ReadLines(csvFilePath);

            foreach (string line in lines)
            {
                if (currentLineNumber <= counter)
                {
                    string abc = line + "\r\n";
                    // Translate the passed message into ASCII and store it as a Byte array.
                    Byte[] data = ASCIIEncoding.ASCII.GetBytes(abc);
                    //Console.WriteLine(line);
                    //Console.WriteLine("\n");
                    // Send the message to the connected TcpServer.
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                    Thread.Sleep(this.sleepAmount);
                    currentLineNumber++;
                }
                counter++;
            }
            // Close everything.
            stream.Close();
            client.Close();
            //System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Notepad++\\notepad++.exe");
        }
    }
}
