using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Clocks
{
    class ClockViewModel : INotifyPropertyChanged
    {
        private ClockModel model;
        public ClockViewModel(ClockModel model)
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
        public float VM_Height
        {
            get
            {
                return model.Height;
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

