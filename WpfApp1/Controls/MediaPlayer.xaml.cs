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
        private MediaPlayerVM VM;
        public MediaPlayer()
        {
            InitializeComponent();
            VM = (Application.Current as App).MediaPlayer_VM;
            this.DataContext = VM;
        }
        // use events to get csv path
        public void Get_My_Paths(object sender, StringEventArgs args)
        {
            VM.add_CSV_Path(args.Data);
        }
     
        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            VM.play();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            VM.stop();
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            VM.playback();
        }

        private void doublePreviousButton_Click(object sender, RoutedEventArgs e)
        {
            VM.playbackfaster();
        }

        private void doubleNextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            VM.playfaster();
        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            VM.pause();
        }

        private void doubleNextButton_Click_1(object sender, RoutedEventArgs e)
        {
            VM.playfarwardfaster();
        }
    }
}
