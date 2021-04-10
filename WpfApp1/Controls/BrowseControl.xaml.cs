using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        private string exePath;
        bool csvFlag, exeFlag;
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
                // invoke to mediaplayer and graph
                (Application.Current as App).MediaPlayer_VM.add_CSV_Path(dialog.FileName);
                (Application.Current as App).Graph_VM.add_CSV_Path(dialog.FileName);
                runFlightGear.IsEnabled = csvFlag && exeFlag;
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
            if (dialog.ShowDialog() == true && System.IO.Path.GetFileName(dialog.FileName).Equals("fgfs.exe"))
            {
                exeFlag = true;
                exePath = dialog.FileName;
                runFlightGear.IsEnabled = csvFlag && exeFlag;
                // copy xml to dst
                string xmlPath = exePath.Substring(0, exePath.Length - 12) + @"data\Protocol\playback_small.xml";
                File.Copy(@"../../Helpers/playback_small.xml", xmlPath, true);
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
               
            }
        }
    }
}
