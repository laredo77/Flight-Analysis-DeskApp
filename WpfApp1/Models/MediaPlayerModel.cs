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
        //
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
        private int isCurrentlyPlay;
        private int sleep;
        private string[] arrayOfLines;
        private Thread player;
        private Client client;
        private string csv_path;
        private bool playAlreadyPressed;
        private bool isPause;
        private bool isStop;
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

                for (; isCurrentlyPlay == 1 && Curr_Line < Num_Lines - 1; Curr_Line++) send();
                if (isCurrentlyPlay == 0) send();

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
            this.playAlreadyPressed = false;
            this.isPause = true;
            this.isStop = true;
            this.isCurrentlyPlay = 0;

        }

        // methods for the video player
        public void play()
        {
            CurrentSpeed = 1;
            if (playAlreadyPressed == false)
            {
                Curr_Line = 0;
            }
            playAlreadyPressed = true;
            isPause = false;
            isStop = false;
            if (player != null && player.IsAlive)
            {
                isCurrentlyPlay = 1;
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
                    player = new Thread(runner);
                    player.Start();
                }
            }
        }
        // jumps forward in the video
        public void jumpForward()
        {
            if (playAlreadyPressed)
            {
                if (currIndex + 5 < Num_Lines)
                {
                    Curr_Line += 5;
                }
            }
        }
        // jumps backward in the video
        public void jumpBackward()
        {
            if (playAlreadyPressed)
            {
                if (currIndex - 5 > 0)
                {
                    Curr_Line -= 5;
                }
            }
        }
        // pauses the video
        public void pause()
        {
            if (playAlreadyPressed)
            {
                isCurrentlyPlay = 0;
                CurrentSpeed = 0;
                isPause = true;
            }
        }
        // stops the video
        public void stop()
        {
            if (playAlreadyPressed)
            {
                isCurrentlyPlay = 0;
                Curr_Line = 0;
                CurrentSpeed = 0;
                isStop = true;
            }
        }
        // jumps double times backward in the video
        public void jumpForwardX2()
        {
            if (playAlreadyPressed)
            {

                if (currIndex + 10 < Num_Lines)
                {
                    Curr_Line += 10;
                }
            }
        }
        // jumps double times forward in the video
        public void jumpBackwardX2()
        {
            if (playAlreadyPressed)
            {
                if (currIndex - 10 > 0)
                {
                    Curr_Line -= 10;
                }
            }
        }
        // plays the video faster
        public void faster()
        {
            if (playAlreadyPressed && isCurrentlyPlay == 1)
            {
                if (sleep > 50)
                {
                    sleep -= 10;
                    CurrentSpeed += 0.1;
                }
            }
        }
        // plays the video slower
        public void slower()
        {
            if (playAlreadyPressed && isCurrentlyPlay == 1)
            {
                if (currentSpeed >= 0.2)
                {
                    sleep += 10;
                    CurrentSpeed -= 0.1;

                }
                else if (currentSpeed < 0.2)
                {
                    this.pause();
                }
            }

        }
        // helper methods
        private void send()
        {
            try
            {
                string line = arrayOfLines[currIndex];
                client.write(line);
                Shared?.Invoke(this, new StringEventArgs { Data = line, ID = currIndex });
                Time = TimeSpan.FromSeconds(currIndex * 0.1).ToString("hh':'mm':'ss");
                Thread.Sleep(sleep);
            }
            catch (Exception e) { isCurrentlyPlay = -10; MessageBox.Show(e.Message); player.Abort(); };
        }

    }
}