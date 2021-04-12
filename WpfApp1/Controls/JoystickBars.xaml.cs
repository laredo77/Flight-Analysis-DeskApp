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
using WpfApp1.ViewModels;

namespace WpfApp1.Controls
{
    /// <summary>
    /// Interaction logic for JoystickBars.xaml
    /// </summary>
    public partial class JoystickBars : UserControl
    {
        public JoystickBarsVM VM;
        public JoystickBars()
        {
            InitializeComponent();
            DataContext = VM;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            VM = (Application.Current as App).JoystickBars_VM;
            DataContext = VM;
        }
    }
}
