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
    public class MediaPlayerVM : ViewModelBase
    {
        private MediaPlayerModel model;

        public MediaPlayerVM(MediaPlayerModel model)
        {
            this.model = model; //model.PropertyChanged+=...}
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
            // event 
            model.Shared += delegate (object sender, StringEventArgs e)
            {
                Shared?.Invoke(this, new StringEventArgs { Data = e.Data, ID = e.ID });
            };
        }
        // event handler
        public delegate void MediaPlayerModelEventHandler(object sender, StringEventArgs args);
        public event MediaPlayerModelEventHandler Shared;

        //methods
        public void play() => this.model.playforward();
        public void playfaster() => this.model.playforwardfaster();
        public void playback() => this.model.playbackward();
        public void playbackfaster() => this.model.playbackwardfaster(); 
        public void playfarwardfaster() => this.model.playforwardfaster();
        public void pause() => this.model.pause();
        public void stop() => this.model.stop();
        public void add_CSV_Path(string path) => model.CSV_Path = path;


        // Properties
        public string VM_Time { get { return model.Time; }  }
        public int VM_Curr_Line { get { return model.Curr_Line; } set { model.Curr_Line = value; } }
        public int VM_Num_Lines { get { return model.Num_Lines; } }
    }
}
