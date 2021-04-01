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
    class ClockModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public ClockModel()
        {
            this.Speed = 0;
            this.Height = 0;
        }
        float height;
        public float Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value >= 0 && value <= 999)
                {
                    height = value;
                    NotifyPropertyChanged("Height");
                }
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
                    Height = float.Parse(currentLine[16]);
                    Thread.Sleep(100);
                }
                return;
            }).Start();
        }
    }
}

