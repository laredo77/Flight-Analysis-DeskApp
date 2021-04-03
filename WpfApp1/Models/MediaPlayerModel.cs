using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp1.Helpers;

namespace WpfApp1.Models
{
    public class MediaPlayerModel : INotifyPropertyChanged
    {
        public delegate void MediaPlayerModelEventHandler(object sender, StringEventArgs args);
        public event MediaPlayerModelEventHandler Shared;


        private Client client;
        private string csv_path;
        public string CSV_Path
        {
            get { return csv_path; }
            set { csv_path = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public MediaPlayerModel(Client client)
        {
            this.client = client;
        }
        public void play()
        {
            new Thread(delegate ()
            {
                client.connect("127.0.0.1",5400);
                var lines = File.ReadLines(csv_path);
                foreach (string line in lines)
                {
                    client.write(line);
                    Shared?.Invoke(this, new StringEventArgs { Data = line, ID = null });
                    Thread.Sleep(100);
                }
                client.disconnect();
                return;
            }).Start();
        }
    }
}
