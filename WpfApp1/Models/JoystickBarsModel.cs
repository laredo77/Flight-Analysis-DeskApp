using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class JoystickBarsModel : INotifyPropertyChanged
    {
        // properties
        private double rudder;
        public double Rudder
        {
            get { return 50 * rudder; }
            set
            {
                rudder = value;
                NotifyPropertyChanged("Rudder");
            }
        }
        private double throttle;
        public double Throttle
        {
            get { return -127 * throttle; }
            set
            {
                throttle = value;
                NotifyPropertyChanged("Throttle");
            }
        }
        private double aileron;
        public double Aileron
        {
            get { return 50 * aileron; }
            set
            {
                aileron = value;
                NotifyPropertyChanged("Aileron");
            }
        }
        private double elevator;
        public double Elevator
        {
            get { return -50 * elevator; }
            set
            {
                elevator = value;
                NotifyPropertyChanged("Elevator");
            }
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        //
        public JoystickBarsModel()
        {
            this.rudder = 0;
            this.aileron = 0;
            this.elevator = 0;
            this.throttle = 0;
        }
    }
}
