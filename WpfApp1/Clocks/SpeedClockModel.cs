using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1.Clocks
{
    class SpeedClockModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public SpeedClockModel()
        {
            this.Speed = 0;
            this.Angle = -50;
        }
        int angle;
        public int Angle
        {
            get
            {
                return this.angle;
            }
            set
            {
                angle = value;
                NotifyPropertyChanged("Angle");
            }
        }
        int speed;
        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                ///////////
                if (value >= 0 && value <= 100)
                {
                    speed = value;
                    Angle = value - 50;
                    NotifyPropertyChanged("Speed");
                }

            }
        }
        private string csv_path;
        public string csv_Path
        {
            get { return csv_path; }
            set { csv_path = value; }
        }
        string[] currentLine;
        public void start()
        {
            new Thread(delegate ()
            {
                var lines = File.ReadLines(csv_path);
                foreach (string line in lines)
                {
                    currentLine = line.Split(',');
                    Speed = (int)double.Parse(currentLine[21]);
                    Thread.Sleep(10);
                }
                return;
            }).Start();
        }
    }
}

