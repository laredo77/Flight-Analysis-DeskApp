using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Helpers;

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
 
        float pitchMax;
        public float PitchMax
        {
            get
            {
                return this.pitchMax;
            }
            set
            {
                pitchMax = value;
                NotifyPropertyChanged("PitchMax");
            }
        }
        float pitchMin;
        public float PitchMin
        {
            get
            {
                return this.pitchMin;
            }
            set
            {
                pitchMin = value;
                NotifyPropertyChanged("PitchMin");
            }
        }
        float rollMax;
        public float RollMax
        {
            get
            {
                return this.rollMax;
            }
            set
            {
                rollMax = value;
                NotifyPropertyChanged("RollMax");
            }
        }
        float rollMin;
        public float RollMin
        {
            get
            {
                return this.rollMin;
            }
            set
            {
                rollMin = value;
                NotifyPropertyChanged("RollMin");
            }
        }
        float yawMax;
        public float YawMax
        {
            get
            {
                return this.yawMax;
            }
            set
            {
                yawMax = value;
                NotifyPropertyChanged("YawMax");
            }
        }
        float yawMin;
        public float YawMin
        {
            get
            {
                return this.yawMin;
            }
            set
            {
                yawMin = value;
                NotifyPropertyChanged("YawMin");
            }
        }
        public Action<object, StringEventArgs> Shared { get; internal set; }
    }
}

