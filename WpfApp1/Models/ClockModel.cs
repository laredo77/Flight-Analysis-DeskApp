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
        private float compassAngle;
        private float height;
        private float speed;
        public ClockModel()
        {
            this.Speed = 0;
            this.Height = 0;
            this.CompassAngle = 0;

        }
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
        public float Height
        {
            get
            {
                return this.height;
            }
            set
            {
                
                    height = value;
                    NotifyPropertyChanged("Height");
                
            }
        }
        public float Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
               
                    speed = value;
                    NotifyPropertyChanged("Speed");
                

            }
        }

    }
}

