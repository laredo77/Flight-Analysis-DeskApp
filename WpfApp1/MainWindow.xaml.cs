using System.Windows;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string xmlPath;
        public string csvPath;
        Client client = new Client();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }
        // browse XML file
        private void openXMLButton_Click(object sender, RoutedEventArgs e)
        {
            xmlPath = XMLPathTextBox.Text; 
        }

        // open FlightGear app
        private void openFlightGear_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            client.start(csvPath, 100);
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            client.start(csvPath, 150);
        }
        private void doublePreviousButton_Click(object sender, RoutedEventArgs e)
        {
            client.start(csvPath, 200);
        }
        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            //dd
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            client.start(csvPath, 70);
        }

        private void doubleNextButton_Click(object sender, RoutedEventArgs e)
        {
            client.start(csvPath, 50);
        }
        // browse CSV file button
        private void openCSVButton_Click(object sender, RoutedEventArgs e)
        {
            csvPath = CSVPathTextBox.Text;
        }
    }
}
