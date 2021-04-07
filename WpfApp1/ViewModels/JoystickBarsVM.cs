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
    public class JoystickBarsVM : ViewModelBase
    {
        private JoystickBarsModel model;
        public JoystickBarsVM(JoystickBarsModel model)
        {
            this.model = model; //model.PropertyChanged+=...}
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public double VM_Aileron { get { return model.Aileron; } }
        public double VM_Elevator { get { return model.Elevator; } }
        public double VM_Throttle { get { return model.Throttle; } }
        public void Get_My_Data(object sender, StringEventArgs args)
        {
            string[] currentLine = args.Data.Split(',');
            model.Aileron = double.Parse(currentLine[0]);
            model.Elevator = double.Parse(currentLine[1]);
            model.Throttle = double.Parse(currentLine[6]);
        }
    }
}
