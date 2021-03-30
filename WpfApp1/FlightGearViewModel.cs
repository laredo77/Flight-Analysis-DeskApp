using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
   
    class FlightGearViewModel : INotifyPropertyChanged
    {
        private IFlightGearModel model;
        private float plainSpeed;
        private int az, elv1, elv2;
        private bool grip;
        public FlightGearViewModel(IFlightGearModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        // Properties
        public float VM_Speedometer
        {
            get
            {
                return model.Speedometer;
            }
        } // keep implementing...

        public float VM_PlainSpeed
        {
            get
            {
                return plainSpeed;
            }
            set
            {
                plainSpeed = value;
            }
        } // keep implementing...
        public int VM_azimuth
        {
            get
            {
                return az;
            }
            set
            {
                az = value;
                //model.moveArm(az, elv1, elv2, grip);
            }
        }
    }
}
