using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class ClockModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public ClockModel()
        {
            this.Speed = 0;
            this.Height = 0;
            
        }
        float compassAngle;
        public float CompassAngle
        {
            get
            {
                return this.compassAngle;
            }
            set
            {
               
                    compassAngle = value;
                    NotifyPropertyChanged("CompassAngle");
                
            }
        }
        float height;
        public float Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value >= 0 && value <= 999)
                {
                    height = value;
                    NotifyPropertyChanged("Height");
                }
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
                    NotifyPropertyChanged("Speed");
                }

            }
        }

    }
}

