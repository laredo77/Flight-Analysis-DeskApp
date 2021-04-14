using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
        // dll import
        [DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
        static extern int LoadLibrary(
            [MarshalAs(UnmanagedType.LPStr)] string lpLibFileName);

        [DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
        static extern IntPtr GetProcAddress(int hModule,
            [MarshalAs(UnmanagedType.LPStr)] string lpProcName);

        [DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
        static extern bool FreeLibrary(int hModule);
        // methods
        delegate void Create();
        delegate void Run();
        delegate int Size();
        delegate IntPtr GetIndex();

        // vars
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
                (Application.Current as App).ProgressBar_VM.add_CSV_Path(dialog.FileName);
                runFlightGear.IsEnabled = csvFlag && exeFlag;
                // stream change the first row
                File.Copy(@"../../Helpers/old_flight.csv", AppDomain.CurrentDomain.BaseDirectory + "old.csv" , true);
                string line;
                // read from csv 
                using (var writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "new.csv"))
                {
                    using (var reader = new StreamReader(dialog.FileName))
                    {
                        List<string> firstrow = new List<string>();
                        for (int i = 0; i < 42; i++) firstrow.Add(i.ToString());
                        var result = string.Join(",", firstrow.ToArray());
                        writer.WriteLine(result);
                        // skip first line
                        reader.ReadLine();
                        // 
                        do
                        {
                            line = reader.ReadLine();
                            if (!reader.EndOfStream)
                                writer.WriteLine(line);
                        } while (line != null);
                    }
                }

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
        // load DLL
        private void loadDllButton_Click(object sender, RoutedEventArgs e)
        {
            if (!csvFlag)
            {
                MessageBox.Show("add csv path");
                return;
            }
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "DLL Files(*.dll)| *.dll";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == true)
            {
                int hModule = LoadLibrary(dialog.FileName);
                //delegate
                IntPtr func = GetProcAddress(hModule, "CreateAlgorithem");
                IntPtr func2 = GetProcAddress(hModule, "RunAlgorithem");
                IntPtr func3 = GetProcAddress(hModule, "GetVectorSize");
                IntPtr func4 = GetProcAddress(hModule, "GetByIndex");
                IntPtr func5 = GetProcAddress(hModule, "GetDataVectorSize"); // Mustly use for minCircle alg
                IntPtr func6 = GetProcAddress(hModule, "GetDataByIndex");

                // func 
                Create maker = (Create)Marshal.GetDelegateForFunctionPointer(func, typeof(Create));
                Run runner = (Run)Marshal.GetDelegateForFunctionPointer(func2, typeof(Run));
                Size sizer = (Size)Marshal.GetDelegateForFunctionPointer(func3, typeof(Size));
                GetIndex indexer = (GetIndex)Marshal.GetDelegateForFunctionPointer(func4, typeof(GetIndex));
                Size circle_sizer = (Size)Marshal.GetDelegateForFunctionPointer(func5, typeof(Size));
                GetIndex circle_indexer = (GetIndex)Marshal.GetDelegateForFunctionPointer(func6, typeof(GetIndex));
                // test
                maker();
                runner();
                int size = sizer();
                int circle_size = circle_sizer();
                List<string> list = new List<string>();
                List<string> circle_list = new List<string>();
                // test
                for (int i = 0; i < size; i++)
                {
                    string str = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(indexer());
                    list.Add(str);
                }

                if (circle_size > 0)
                {
                    for (int i = 0; i < circle_size; i++)
                    {
                        string str = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(circle_indexer());
                        circle_list.Add(str);
                        Console.WriteLine(str);
                    }
                }

                if ( list.Count > 0)
                    (Application.Current as App).Graph_VM.add_Algo_Detect(list);
                else if(circle_list.Count > 0)
                    (Application.Current as App).Graph_VM.add_Algo_Detect(circle_list);
            }
        }
        // Run FG
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
