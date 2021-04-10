using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Helpers;

namespace WpfApp1.Models
{
    public class MediaPlayerModel : INotifyPropertyChanged
    {
        // send data event to other models
        public delegate void MediaPlayerModelEventHandler(object sender, StringEventArgs args);
        public event MediaPlayerModelEventHandler Shared;
        
        // properties
        private string time;
        public string Time
        {
            get { return time; }
            set
            {
                time = value;
                NotifyPropertyChanged("Time");
            }
        }
        private double currentSpeed;
        public double CurrentSpeed
        {
            get { return currentSpeed; }
            set
            {
                currentSpeed = value;
                NotifyPropertyChanged("CurrentSpeed");
            }
        }
        private int currIndex;
        public int Curr_Line
        {
            get { return currIndex; }
            set
            {
                currIndex = value;
                NotifyPropertyChanged("Curr_Line");
            }
        }
        private int numberOfLines;
        public int Num_Lines
        {
            get { return numberOfLines - 1; }
            set
            {
                numberOfLines = value;
                NotifyPropertyChanged("Num_Lines");
            }
        }
        // variables
        private int isBackward;
        private int sleep;
        private string[] arrayOfLines;
        private Thread player;
        private Client client;
        private string csv_path;
        public string CSV_Path
        {
            get { return csv_path; }
            set
            {
                csv_path = value;
                arrayOfLines = File.ReadAllLines(csv_path);
                Num_Lines = arrayOfLines.Length;
                currIndex = 1;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void runner()
        {
            // csv path
            if (csv_path == null) return;
            // connect
            try { client.connect("127.0.0.1", 5400); }
            catch (Exception e) { MessageBox.Show(e.Message); return; };
            // loop of sending
            while (Curr_Line < Num_Lines || 0 < Curr_Line)
            {
                for (; isBackward == 0 && Curr_Line < Num_Lines - 1; Curr_Line++) send();
                for (; isBackward == 1 && 0 < Curr_Line; Curr_Line--) send();
                if (isBackward == -1) send();
            }
            // disconnect
            client.disconnect();
        }


        // constructor
        public MediaPlayerModel(Client client)
        {
            this.client = client;
            this.player = new Thread(runner);
            player.IsBackground = true;
            this.sleep = 100;
            this.CurrentSpeed = 0;
        }

        // methods
        public void playforward()
        {
            CurrentSpeed = 1;
            if (player != null && player.IsAlive)
            {
                isBackward = 0;
                sleep = 100;
                return;
            }
            else
            {
                try
                {
                    player.Start(); 
                }
                catch (System.Threading.ThreadStateException e)
                {
                    client.disconnect();
                    player = new Thread(runner);
                    player.Start();
                }
            }     
        }

        public void playbackward()
        {
            isBackward = 1;
            sleep = 100;
            CurrentSpeed = 1;
        }

        public void pause()
        {
            isBackward = -1;
            CurrentSpeed = 0;
        }

        public void stop()
        {
            isBackward = -1;
            currIndex = 0;
            CurrentSpeed = 0;
        }

        public void playforwardfaster()
        {
            isBackward = 0;
            sleep = 50;
            CurrentSpeed = 2;
        }

        public void playbackwardfaster()
        {
            isBackward = 1;
            sleep = 50;
            CurrentSpeed = 2;
        }

        // helper methods
        private void send()
        {
            try
            {
                string line = arrayOfLines[currIndex];
                client.write(line);
                Shared?.Invoke(this, new StringEventArgs { Data = line , ID = currIndex });
                Time = TimeSpan.FromSeconds(currIndex * 0.1).ToString("hh':'mm':'ss");
                Thread.Sleep(sleep);
            }
            catch (Exception e) { isBackward = -10; MessageBox.Show(e.Message); player.Abort(); };
        }

    }
}

