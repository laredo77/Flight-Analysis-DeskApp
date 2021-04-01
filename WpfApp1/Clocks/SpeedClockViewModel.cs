using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1.Clocks
{
    class SpeedClockViewModel : INotifyPropertyChanged
    {
        private SpeedClockModel model;
        public SpeedClockViewModel(SpeedClockModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public string VM_CSV_Path
        {
            get { return model.csv_Path; }
            set { model.csv_Path = value; }
        }
        public int VM_Angle
        {
            get
            {
                return model.Angle;
            }
        }
        public int VM_Speed
        {
            get
            {
                return model.Speed;
            }
        }
        public void start()
        {
            model.start();
        }
    }
}
