using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Helpers;


namespace WpfApp1.Controls
{
    /// <summary>
    /// Interaction logic for BrowseControl.xaml
    /// </summary>
    /// 
    
    public partial class BrowseControl : UserControl
    {
        public delegate void BrowseControlEventHandler(BrowseControl sender, StringEventArgs args);
        public event BrowseControlEventHandler Updated;
        private string exePath;
        bool csvFlag, exeFlag, xmlFlag;
        public BrowseControl()
        {
            InitializeComponent();
            
        }

        // browse CSV file
        private void openCSVButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "CSV Files(*.csv)| *.csv";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == true)
            {
                csvFlag = true;
                // invoke to mediaplayer
                Updated?.Invoke(this, new StringEventArgs { Data = dialog.FileName, ID = "csv" });
                runFlightGear.IsEnabled = csvFlag && exeFlag && xmlFlag;
            }
        }
        // browse XML file
        private void openXMLButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "XML Files|*.xml";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == true)
            {
                xmlFlag = true;
                // need to write here code that copy xml file to exe path
                runFlightGear.IsEnabled = csvFlag && exeFlag && xmlFlag;

            }
        }
        // open FlightGear app
        private void openFlightGear_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "EXE Files(*.exe)| *.exe";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == true)
            {
                exeFlag = true;
                exePath = dialog.FileName;
                runFlightGear.IsEnabled = csvFlag && exeFlag && xmlFlag;
            }
        }

        private void runFlightGear_Click(object sender, RoutedEventArgs e)
        {
            if (runFlightGear.IsEnabled)
            {
                string pathOnly = System.IO.Path.GetDirectoryName(exePath);
                string filenameOnly = System.IO.Path.GetFileName(exePath);
                string command = " --generic=socket,in,10,127.0.0.1,5400,tcp,playback_small --fdm=null";

                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine("cd " + pathOnly);
                cmd.StandardInput.Flush();
                cmd.StandardInput.WriteLine(filenameOnly + command);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();

                // write code that wait for this goddamned app
                // end 
                
                cmd.WaitForExit();
                Updated?.Invoke(this, new Helpers.StringEventArgs { Data = null, ID = "exe" });
            }
        }
    }
}
