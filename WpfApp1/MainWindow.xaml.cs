﻿using System.Windows;
using System;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using WpfApp1.Controls;

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
            Initializer();
        }

        // cant copy viewmodels to usercontrols ( breaking the xaml designer of mainwindow )
        private void Initializer()
        {
            Media.VM = (Application.Current as App).MediaPlayer_VM;
            Media.DataContext = Media.VM;
            Joystick.VM = (Application.Current as App).JoystickBars_VM;
            Joystick.DataContext = Joystick.VM;
            Speed.VM = (Application.Current as App).Clock_VM;
            Speed.DataContext = Speed.VM;
            Compass.VM = Speed.VM;
            Compass.DataContext = Compass.VM;
            Height.VM = Speed.VM;
            Height.DataContext = Height.VM;
            // update views of graph
            Graph.VM = (Application.Current as App).Graph_VM;
            Graph.VM.addGraph(Graph.TimeChart.ActualModel);
            Graph.VM.addGraph(Graph.TimeCorrChart.ActualModel);
            Graph.VM.addGraph(Graph.RegLinear.ActualModel);
            Graph.DataContext = Graph.VM;
            // setting
            ProgressBar.VM = (Application.Current as App).ProgressBar_VM;
            ProgressBar.DataContext = ProgressBar.VM;
        }

    }
}



