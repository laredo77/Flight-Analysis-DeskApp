﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Helpers;

namespace WpfApp1.Clocks
{
    public class ClockVM : INotifyPropertyChanged
    {

        private ClockModel model;
        public ClockVM(ClockModel model)
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
        public float VM_CompassAngle
        {
            get
            {
                return model.CompassAngle;
            }
        }

        // get my data by event
        public void Get_My_Data(object sender, StringEventArgs args)
        {
            string[] currentLine = args.Data.Split(',');
            model.Speed = (int)double.Parse(currentLine[21]);
            model.Height = float.Parse(currentLine[16]);
            ///////????????????????????????????????
            model.CompassAngle = float.Parse(currentLine[19]);
        }
    }
}

