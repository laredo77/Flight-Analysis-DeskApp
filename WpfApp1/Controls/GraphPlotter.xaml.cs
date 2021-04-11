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
        public GraphVM VM;
        private bool load = false;
        public GraphPlotter()
        {
            InitializeComponent();
            
            // vm.addGraph(TimeChart.ActualModel);
        }


        // select items
        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ListBoxItem lbi = sender as ListBoxItem;
            VM.Switch(lbi.Content.ToString());
        }

    }
}
