using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }
        // browse XML file
        private void openXMLButton_Click(object sender, RoutedEventArgs e)
        {

        }


        // open FlightGear app
        private void openFlightGear_Click(object sender, RoutedEventArgs e)
        {
            
            TcpClient client = new TcpClient("127.0.0.1", 5400);
            // Get a client stream for reading and writing.
            NetworkStream stream = client.GetStream();
            stream.Flush();
            var lines = File.ReadLines("C:\\Users\\lared\\Desktop\\reg_flight.csv");

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
                Thread.Sleep(100);
            }
            // Close everything.
            stream.Close();
            client.Close();
            //System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Notepad++\\notepad++.exe");
        }

        private void doublePreviousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void doubleNextButton_Click(object sender, RoutedEventArgs e)
        {

        }
        // browse CSV file button
        private void openCSVButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
