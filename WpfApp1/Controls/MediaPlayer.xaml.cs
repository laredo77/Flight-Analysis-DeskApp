using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using WpfApp1.Helpers;
using WpfApp1.Models;



namespace WpfApp1.Controls
{
    /// <summary>
    /// Interaction logic for MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : UserControl
    {
        public MediaPlayerVM vm;
        public MediaPlayer()
        {
            InitializeComponent();
            vm = new MediaPlayerVM(new MediaPlayerModel(new Client()));
            DataContext = vm;
        }
        // use events to get csv path
        public void Get_My_Paths(object sender, StringEventArgs args)
        {
            if (string.Equals("exe", args.ID))
            {
                // write code that check
                playButton.IsEnabled = true;
            }
            else if (string.Equals("csv", args.ID))
            {
                vm.add_CSV_Path(args.Data);
            }
            else return;
   
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            vm.play();
        }
    }
}
