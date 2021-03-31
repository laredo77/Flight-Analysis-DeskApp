using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class TelnetClient : ITelnetClient
    {
        TcpClient client;
        NetworkStream stream;

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
            stream.Flush();
            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(command);
            // Send the message to the connected TcpServer.
            stream.Write(data, 0, data.Length);
        }

        public void writeCsv(string csvFile)
        {
                stream.Flush();
                var lines = File.ReadLines(@csvFile);
                foreach (string line in lines)
                {
                    string abc = line + "\r\n";
                    // Translate the passed message into ASCII and store it as a Byte array.
                    Byte[] data = ASCIIEncoding.ASCII.GetBytes(abc);
                    //Console.WriteLine(line);
                    //Console.WriteLine("\n");
                    // Send the message to the connected TcpServer.
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                }
        }
    }
}