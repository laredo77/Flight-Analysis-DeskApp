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
        public Dictionary<int, string> Reverse_Dict_Params { get; set; }
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
        // add graphs
        public void addGraph(PlotModel model) => graphs.Add(model);
        // add csv for model
        public void add_CSV_Path(string path) => model.CSV_Path = path;
        // add algorithm detection
        public void add_Algo_Detect(List<string> data) => model.Algo_Detect = data;
        // display min circle
        //public void add_min_circle(List<string> data) => model.Display_MinCircle = data;
        // points
        public List<DataPoint> VM_Points { get { return model.Points; }  }
        // Algo Points
        public List<DataPoint> VM_Algo_Points { get { return model.Algo_Points; } }
        // points of corr
        public List<DataPoint> VM_Corr_Points { get { return model.Corr_Points; } }
        // create scatter points
        public List<DataPoint> VM_Scatter_Points { get { return model.Scatter_Points; } }
        // create line
        public List<DataPoint> VM_Line { get { return model.Line; } }
        // get data from mediaplayer
        public void Get_My_Data(object sender, StringEventArgs args)
        {
            // update the graph
            model.update(args.ID);
            Application.Current.Dispatcher.Invoke(() => {
                foreach (PlotModel graph in graphs) graph.InvalidatePlot(true);
            });
        }
        // corr_param
        public string Corr_Param { get { return Reverse_Dict_Params[model.param2()]; } }
        // switch between params
        public void Switch(string parameter)
        {
            // time of model 
            model.Param_Index = Dict_Params[parameter];
            // update name of corr graph
            NotifyPropertyChanged("Corr_Param");
            // update the graph
            model.Points.Clear();
            model.Corr_Points.Clear();
            model.Algo_Points.Clear();
            model.reset();
            Application.Current.Dispatcher.Invoke(() => {
                foreach (PlotModel graph in graphs) graph.InvalidatePlot(true);
            });
        }
    }
}
