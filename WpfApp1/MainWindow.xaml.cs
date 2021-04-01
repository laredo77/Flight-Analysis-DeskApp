using System.Windows;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Clocks;
using System.Windows.Media;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string xmlPath;
        public string csvPath;
        private Thread t = null;
        ITelnetClient telnetClient;
        FlightGearViewModel vm;
        SpeedClockViewModel speedClockViewModel;
        public MainWindow()
        {
            InitializeComponent();
            vm = new FlightGearViewModel(new FlightGearModel(new TelnetClient()));
            vm.start();
            DataContext = vm;
            speedClockViewModel = new SpeedClockViewModel(new SpeedClockModel());
            this.DataContext = speedClockViewModel;
        }

        // browse XML file
        private void openXMLButton_Click(object sender, RoutedEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "XML Files|*.xml";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == true)
            {
                xmlPath = dialog.FileName;
            }
        }

        private void openCSVButton_Click(object sender, RoutedEventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "CSV Files(*.csv)| *.csv";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == true)
            {
                speedClockViewModel.VM_CSV_Path = dialog.FileName;
                csvPath = dialog.FileName;
            }
        }
        // open FlightGear app
        private void openFlightGear_Click(object sender, RoutedEventArgs e)
        {
            string FG_ROOT = @"C:\Program Files\FlightGear 2020.3.5\data";
            var fileContent = string.Empty;
            var filePath = string.Empty;
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "EXE Files(*.exe)| *.exe";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == true)
            {
                
                ProcessStartInfo startInfo = new ProcessStartInfo(dialog.FileName);
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                startInfo.Arguments = $"--fg-root{FG_ROOT} --generic =socket,in,10,127.0.0.1,5400,tcp,playback_small --fdm=null";
                Process.Start(startInfo);
                System.Threading.Thread.Sleep(60000);
                playButton.IsEnabled = true;
            }
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            t = new Thread( delegate() {
                TcpClient client = new TcpClient("127.0.0.1", 5400);
                // Get a client stream for reading and writing.
                NetworkStream stream = client.GetStream();
                stream.Flush();
                var lines = File.ReadLines(@csvPath);
                foreach (string line in lines)
                {
                string abc = line + "\r\n";
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = ASCIIEncoding.ASCII.GetBytes(abc);
                stream.Write(data, 0, data.Length);
                stream.Flush();
                Thread.Sleep(250);
                }
                stream.Close();
                client.Close();
            });
            t.Start();
            speedClockViewModel.start();
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void doublePreviousButton_Click(object sender, RoutedEventArgs e)
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

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var lines = File.ReadAllLines(csvPath);
            var count = lines.Length;
            int i = 0;
            while(i < count)
            {
                
            }
        }

    }
}
