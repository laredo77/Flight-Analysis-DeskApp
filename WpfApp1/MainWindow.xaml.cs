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
using WpfApp1.Models;
using System.Windows.Media;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Load_Names();
            BrowseControl.Updated += MediaPlayer.Get_My_Paths;
            BrowseControl.Updated += GraphPlotter.Get_My_Paths;
            MediaPlayer.vm.Shared += SpeedClock.vm.Get_My_Data;
            MediaPlayer.vm.Shared += HeightClock.vm.Get_My_Data;
            MediaPlayer.vm.Shared += JoystickBars.vm.Get_My_Data;
            MediaPlayer.vm.Shared += Compass.vm.Get_My_Data;
            MediaPlayer.vm.Shared += ProgressBars.vm.Get_My_Data;
        }

        // loading names from here because of technical problems
        private void Load_Names()
        {
            Dictionary<string, int> Dict_params = new Dictionary<string,int>();
            // find file path
            string[] lines = File.ReadAllLines(@"../../Helpers/playback_small.xml");
            string[] info = lines.Where(s => s.StartsWith("    <name>")).ToArray();
            // change different params with same name
            string no_repeat = "test";
            // xml
            for (int i = 0; i < 42; i++)
            {
                string read_params = info[i].Substring(10, info[i].Length - 17);
                if (no_repeat.Equals(read_params)) read_params = read_params + " 2";
                no_repeat = read_params;
                Dict_params.Add(read_params, i);
            };
            GraphPlotter.vm.Dict_Params = Dict_params;
            GraphPlotter.vm.Parameters = Dict_params.Keys.ToList();
        }

    }
}



