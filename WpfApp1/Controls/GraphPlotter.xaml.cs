using OxyPlot;
using System;
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
using WpfApp1.Helpers;
using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp1.Controls
{
    /// <summary>
    /// Interaction logic for GraphPlotter.xaml
    /// </summary>
    public partial class GraphPlotter : UserControl
    {
        GraphVM VM;
        public GraphPlotter()
        {
            InitializeComponent();
        }


        // select items
        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ListBoxItem lbi = sender as ListBoxItem;
            VM.Switch(lbi.Content.ToString());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            VM = (Application.Current as App).Graph_VM;
            VM.addGraph(TimeChart.ActualModel);
            VM.addGraph(TimeCorrChart.ActualModel);
            VM.addGraph(RegLinear.ActualModel);
            DataContext = VM;
        }
    }
}
