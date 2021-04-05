using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class ProgressBarModel : INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public ProgressBarModel()
        {
            this.Pitch = 0;
            this.Roll = 0;
            this.Yaw = 0;

        }
        float pitch;
        public float Pitch
        {
            get
            {
                return this.pitch;
            }
            set
            {

                pitch = value;
                NotifyPropertyChanged("Pitch");

            }
        }
        float roll;
        public float Roll
        {
            get
            {
                return this.roll;
            }
            set
            {
                
                    roll = value;
                    NotifyPropertyChanged("Roll");
                
            }
        }

        private float yaw;
        public float Yaw
        {
            get
            {
                return this.yaw;
            }
            set
            {
                    yaw = value;
                    NotifyPropertyChanged("Yaw");
            }
        }

    }
}

