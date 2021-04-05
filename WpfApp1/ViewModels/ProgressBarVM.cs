using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Helpers;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class ProgressBarVM : INotifyPropertyChanged
    {
        private ProgressBarModel model;
        public ProgressBarVM(ProgressBarModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        // event handler
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public float VM_Pitch
        {
            get
            {
                return model.Pitch;
            }
        }
        public float VM_Roll
        {
            get
            {
                return model.Roll;
            }
        }
        public float VM_Yaw
        {
            get
            {
                return model.Yaw;
            }
        }

        // get my data by event
        public void Get_My_Data(object sender, StringEventArgs args)
        {
            string[] currentLine = args.Data.Split(',');
           /////????????
            model. Pitch= float.Parse(currentLine[18]);
            model.Roll = float.Parse(currentLine[17]);
            model.Yaw = float.Parse(currentLine[20]);
        }
    }
}

