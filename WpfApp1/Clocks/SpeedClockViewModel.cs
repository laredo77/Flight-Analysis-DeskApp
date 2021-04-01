using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class SpeedClockViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        
        public SpeedClockViewModel()
        {
            this.Speed = 0;
            this.Angle = -50;
        }
        int angle;
        public int Angle
        {
            get
            {
                return this.angle;
            }
            set
            {
                angle = value;
                NotifyPropertyChanged("Angle");
            }
        }
        int speed;
        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                ///////////
                if (value >= 0 && value <= 100)
                {
                    speed = value;
                    Angle = value - 50;
                    NotifyPropertyChanged("Speed");
                }

            }
        }
    }

}
