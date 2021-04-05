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
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BrowseControl.Updated += MediaPlayer.Get_My_Paths;
            MediaPlayer.vm.Shared += SpeedClock.vm.Get_My_Data;
            MediaPlayer.vm.Shared += HightClock.vm.Get_My_Data;
            MediaPlayer.vm.Shared += Compass.vm.Get_My_Data;

            MediaPlayer.vm.Shared += ProgressBars.vm.Get_My_Data;
        }
    }
 }

