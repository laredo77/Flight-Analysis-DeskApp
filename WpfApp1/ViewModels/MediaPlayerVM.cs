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
    public class MediaPlayerVM : INotifyPropertyChanged
    {
        private MediaPlayerModel model;


        public MediaPlayerVM(MediaPlayerModel model)
        {
            this.model = model; //model.PropertyChanged+=...}
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
            // event 2th
            model.Shared += delegate (object sender, StringEventArgs e)
            {
                Shared?.Invoke(this, new StringEventArgs { Data = e.Data, ID = e.ID });
            };
        }
        // event handler 2th
        public delegate void MediaPlayerModelEventHandler(object sender, StringEventArgs args);
        public event MediaPlayerModelEventHandler Shared;

        // event handler 1th
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null) this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        //methods
        public void play()
        {
            this.model.play();
        }

        public void add_CSV_Path(string path)
        {
            model.CSV_Path = path;
        }
    }
}
