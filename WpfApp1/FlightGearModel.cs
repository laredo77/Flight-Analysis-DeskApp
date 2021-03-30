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
                while (!stop)
                {
                    telnetClient.write("h");
                    Speedometer = float.Parse(telnetClient.read());

                    Thread.Sleep(250);

                }
            }).Start();
        }
    }
}
