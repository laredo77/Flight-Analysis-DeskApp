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
        public GraphVM vm;
        public GraphPlotter()
        {
            InitializeComponent();
            vm = new GraphVM(new GraphModel(TimeChart.ActualModel));
            DataContext = vm;
        }


        // select items
        public void Get_My_Paths(object sender, StringEventArgs args)
        {
            vm.add_CSV_Path(args.Data);

        }
        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ListBoxItem lbi = sender as ListBoxItem;
            vm.Switch(lbi.Content.ToString());
        }
    }
}
