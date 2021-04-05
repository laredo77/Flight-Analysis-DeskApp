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
        private double rudder;
        public double Rudder
        {
            get { return throttle; }
            set
            {
                throttle = 50 * value;
                NotifyPropertyChanged("Throttle");
            }
        }
        private double throttle;
        public double Throttle
        {
            get { return throttle; }
            set
            {
                throttle = -127 * value;
                NotifyPropertyChanged("Throttle");
            }
        }
        private double aileron;
        public double Aileron
        {
            get { return aileron; }
            set
            {
                aileron = 50 * value;
                NotifyPropertyChanged("Aileron");
            }
        }
        private double elevator;
        public double Elevator
        {
            get { return elevator; }
            set
            {
                elevator = -50 * value;
                NotifyPropertyChanged("Elevator");
            }
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public JoystickBarsModel()
        {
            this.aileron = 0;
            this.elevator = 0;
            this.throttle = 0;
        }
    }
}
