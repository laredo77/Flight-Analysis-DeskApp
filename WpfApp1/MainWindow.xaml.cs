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
            string first_command = "--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small";
            string second_command = "--fdm=null";

            var fileContent = string.Empty;
            var filePath = string.Empty;
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "EXE Files(*.exe)| *.exe";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == true)
            {
                //Process cmd = new Process();
                System.Diagnostics.Process.Start(dialog.FileName);
                //cmd.Start(dialog.FileName);
                System.Diagnostics.Process.StandardInput.WriteLine("--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small");
                System.Diagnostics.Process.StandardInput.WriteLine("--fdm=null");
                //System.Diagnostics.Process.StandardInput.Flush();
                //System.Diagnostics.Process.StandardInput.Close();
            }
 
            //Process cmd = new Process();
            //cmd.StartInfo.FileName = "cmd.exe";
            //cmd.StartInfo.RedirectStandardInput = true;
            //cmd.StartInfo.RedirectStandardOutput = true;
            //cmd.StartInfo.CreateNoWindow = true;
            //cmd.StartInfo.UseShellExecute = false;
            //cmd.Start();

            //cmd.StandardInput.WriteLine("echo Oscar");
            //cmd.StandardInput.Flush();
            //cmd.StandardInput.Close();
            //cmd.WaitForExit();
            //Console.WriteLine(cmd.StandardOutput.ReadToEnd());
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
