﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using WpfApp1.Clocks;

namespace WpfApp1.Controls
{
    /// <summary>
    /// Interaction logic for SpeedClock.xaml
    /// </summary>
    public partial class SpeedClock : UserControl
    {
        public ClockVM vm;
        public SpeedClock()
        {
            InitializeComponent();
            vm = new ClockVM(new ClockModel());
            DataContext = vm;
        }
    }
}
