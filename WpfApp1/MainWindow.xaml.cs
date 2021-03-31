using System.Windows;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string xmlPath;
        public string csvPath;
        ITelnetClient telnetClient;
        FlightGearViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new FlightGearViewModel(new FlightGearModel(new TelnetClient()));
            vm.start();
            DataContext = vm;    
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
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
                csvPath = dialog.FileName;
            }
        }
        // open FlightGear app
        private void openFlightGear_Click(object sender, RoutedEventArgs e)
        { 

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
                startInfo.Arguments = "--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small --fdm=null";
                                        
                Process.Start(startInfo);
                //System.Diagnostics.Process.Start(dialog.FileName);
                //telnetClient.connect("127.0.0.1", 5400);
                //var lines = File.ReadLines(@csvPath);

                //foreach (string line in lines)
                //{
                //    string abc = line + "\r\n";
                //    telnetClient.write(abc);
                //}
            }

        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            
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
    }
}
