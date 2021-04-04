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
using WpfApp1.Models;
using WpfApp1.ViewModels;

namespace WpfApp1.Controls
{
    /// <summary>
    /// Interaction logic for JoystickBars.xaml
    /// </summary>
    public partial class JoystickBars : UserControl
    {
        public JoystickBarsVM vm;
        public JoystickBars()
        {
            InitializeComponent();
            vm = new JoystickBarsVM(new JoystickBarsModel());
            DataContext = vm;
        }
    }
}
