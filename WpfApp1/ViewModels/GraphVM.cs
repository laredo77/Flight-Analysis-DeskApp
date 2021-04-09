using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.Helpers;
using OxyPlot;
using System.ComponentModel;
using System.Windows;

namespace WpfApp1.ViewModels
{
    public class GraphVM : ViewModelBase
    {
        public Dictionary<string, int> Dict_Params { get; set; }
        public List<string> Parameters { get; set; }
        private GraphModel model;
        private List<PlotModel> graphs;
        public GraphVM(GraphModel model) 
        {
            this.model = model;
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
            graphs = new List<PlotModel>();
        }
        public void addGraph(PlotModel model) => graphs.Add(model);
        public void add_CSV_Path(string path) => model.CSV_Path = path;
        public List<DataPoint> VM_Points { get { return model.Points; }  }
        public List<DataPoint> VM_Corr_Points { get { return model.Corr_Points; } }
        public void Get_My_Data(object sender, StringEventArgs args)
        {
            // update the graph
            model.update(args.ID);
            Application.Current.Dispatcher.Invoke(() => {
                foreach (PlotModel graph in graphs) graph.InvalidatePlot(true);
            });
        }
        public void Switch(string parameter)
        {
            // time of model 
            model.Param_Index = Dict_Params[parameter];
            // update the graph
            model.Points.Clear();
            model.Corr_Points.Clear();
            model.reset();
            Application.Current.Dispatcher.Invoke(() => { 
                foreach (PlotModel graph in graphs) graph.InvalidatePlot(true); 
            });
        }
    }
}
