using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Controls;
using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public GraphVM Graph_VM { get; internal set; }
        public ClockVM Clock_VM { get; internal set; }
        public MediaPlayerVM MediaPlayer_VM { get; internal set; }
        public ProgressBarVM ProgressBar_VM { get; internal set; }
        public JoystickBarsVM JoystickBars_VM { get; internal set; }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Graph_VM = new GraphVM(new GraphModel());
            Clock_VM = new ClockVM(new ClockModel());
            MediaPlayer_VM = new MediaPlayerVM(new MediaPlayerModel(new Client()));
            ProgressBar_VM = new ProgressBarVM(new ProgressBarModel());
            JoystickBars_VM = new JoystickBarsVM(new JoystickBarsModel());
            // load names
            Load_Names();
            // event - observer pattern
            Load_Communication();
        }

        private void Load_Names()
        {
            // find file path
            string[] lines = File.ReadAllLines(@"../../Helpers/playback_small.xml");
            string[] info = lines.Where(s => s.StartsWith("    <name>")).ToArray();
            // change different params with same name
            string no_repeat = "test";
            // xml
            Dictionary<string, int> Dict_params = new Dictionary<string, int>();
            Dictionary<int, string> Reverse_Dict_Params = new Dictionary<int, string>();
            for (int i = 0; i < 42; i++)
            {
                string read_params = info[i].Substring(10, info[i].Length - 17);
                if (no_repeat.Equals(read_params)) read_params = read_params + " 2";
                no_repeat = read_params;
                Dict_params.Add(read_params, i);
                Reverse_Dict_Params.Add(i, read_params);
            };
            // update list and dict of vm
            Graph_VM.Dict_Params = Dict_params;
            Graph_VM.Reverse_Dict_Params = Reverse_Dict_Params;
            Graph_VM.Parameters = Dict_params.Keys.ToList();
        }

        private void Load_Communication()
        {
            MediaPlayer_VM.Shared += Graph_VM.Get_My_Data;
            MediaPlayer_VM.Shared += ProgressBar_VM.Get_My_Data;
            MediaPlayer_VM.Shared += Clock_VM.Get_My_Data;
            MediaPlayer_VM.Shared += JoystickBars_VM.Get_My_Data;
        }
    }
}
