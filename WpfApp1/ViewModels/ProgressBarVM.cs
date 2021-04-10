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
    public class ProgressBarVM : ViewModelBase
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
        public float VM_Pitch
        { get { return model.Pitch; } }
        public float VM_Roll
        { get { return model.Roll; } }
        public float VM_Yaw 
        { get { return model.Yaw; } }
        public float VM_PitchMax
        { get { return model.PitchMax; } }
        public float VM_PitchMin
        { get { return model.PitchMin; } }
        public float VM_RollMax
        { get { return model.RollMax; } }
        public float VM_RollMin
        { get { return model.RollMin; } }
        public float VM_YawMax
        { get { return model.YawMax; } }
        public float VM_YawMin
        { get { return model.YawMin; } }
        //public void add_CSV_Path(string path) => model.CSV_Path = path;

        // get my data by event
        public void Get_My_Data(object sender, StringEventArgs args)
        {
            string[] currentLine = args.Data.Split(',');
            /////????????
            model.Pitch = float.Parse(currentLine[18]);
            model.Roll = float.Parse(currentLine[17]);
            model.Yaw = float.Parse(currentLine[20]);
        }
    }
}

