﻿using System;
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
        private string[] arrayOfLines;
        private string csv_path;
        private float pitch;
        private float roll;
        private float yaw;
        private float pitchMax;
        private float pitchMin;
        private float rollMax;
        private float rollMin;
        private float yawMax;
        private float yawMin;
        public ProgressBarModel()
        {
            this.Pitch = 0;
            this.Roll = 0;
            this.Yaw = 0;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public string CSV_Path
        {
            get { return csv_path; }
            set
            {
                csv_path = value;
                arrayOfLines = File.ReadAllLines(csv_path);
                int startLineNumber = 0;
                if (arrayOfLines[0] != null)
                {
                    string[] Line0 = arrayOfLines[0].Split(',');
                    if (Line0[0] is string) startLineNumber = 1;
                }
                if (arrayOfLines[startLineNumber] != null)
                {
                    string[] Line1 = arrayOfLines[startLineNumber].Split(',');
                    this.RollMax = float.Parse(Line1[17]);
                    this.RollMin = float.Parse(Line1[17]);
                    this.PitchMax = float.Parse(Line1[18]);
                    this.PitchMin = float.Parse(Line1[18]);
                    this.YawMax = float.Parse(Line1[20]);
                    this.YawMin = float.Parse(Line1[20]);
                    for (int i = startLineNumber+1; i < arrayOfLines.Length; i++)
                    {
                        string[] currentLine = arrayOfLines[i].Split(',');
                        RollMax = Math.Max(RollMax, float.Parse(currentLine[17]));
                        RollMin = Math.Min(RollMin, float.Parse(currentLine[17]));
                        PitchMax = Math.Max(PitchMax, float.Parse(currentLine[18]));
                        PitchMin = Math.Min(PitchMin, float.Parse(currentLine[18]));
                        YawMax = Math.Max(YawMax, float.Parse(currentLine[20]));
                        YawMin = Math.Min(YawMin, float.Parse(currentLine[20]));
                    }
                }
            }
        }
        public float Pitch
        {
            get
            {
                return this.pitch;
            }
            set
            {
                if (value >= pitchMin && value <= pitchMax)
                {
                    pitch = value;
                    NotifyPropertyChanged("Pitch");
                }
            }
        }
        public float Roll
        {
            get
            {
                return this.roll;
            }
            set
            {
                if (value >= rollMin && value <= rollMax)
                {
                    roll = value;
                    NotifyPropertyChanged("Roll");
                }
            }
        }
        public float Yaw
        {
            get
            {
                return this.yaw;
            }
            set
            {
                if (value >= yawMin && value <= yawMax)
                {
                    yaw = value;
                    NotifyPropertyChanged("Yaw");
                }
            }
        } 
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

