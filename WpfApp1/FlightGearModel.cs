using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1
{
    class FlightGearModel : IFlightGearModel
    {
        ITelnetClient telnetClient;
        volatile Boolean stop;
        private float speedometer;

        public event PropertyChangedEventHandler PropertyChanged;
        public FlightGearModel(ITelnetClient telnetClient)
        {
            this.telnetClient = telnetClient;
            stop = false;
        }

        /*
         * Need to add all the features of the csv insted of Speedometer
         * should features.
         * the features changed 4 times per second.
         */
        public float Speedometer
        {
            get
            {
                return speedometer;
            }
            set
            {
                speedometer = value;
                NotifyPropertyChanged("Speedometer");
            }
        }

      public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public void connect(string ip, int port)
        {
            telnetClient.connect(ip, port);
        }

        public void disconnect()
        {
            stop = true;
            telnetClient.disconnect();
        }

        public void start()
        {
            new Thread(delegate ()
            {
                int i = 20;
                while (!stop)
                {
                   //telnetClient.write("h");
                    //Speedometer = float.Parse(telnetClient.read());
                    //var lines = File.ReadAllLines(@"C:\\Users\\lared\\Desktop\\reg_flight.csv");
                    //var delimitedLine = line.Split(',');
                    //var value = delimitedLine[14];
                    //int i = 20;
                    Speedometer = i + 10;
                    i++;

                    //Speedometer = float.Parse(value);
                    //foreach (string line in lines)
                    //{
                        //var delimitedLine = line.Split(',');
                        //var value = delimitedLine[22];
                        //Speedometer = float.Parse(value);
                        //Thread.Sleep(250);
                    //}
                    Thread.Sleep(250);
                    //Thread.Sleep(250);

                }
            }).Start();
        }
    }
}
