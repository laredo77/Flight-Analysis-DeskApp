using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Models
{
    public class GraphModel : INotifyPropertyChanged
    {
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        // props
        private string csv_path;
        public string CSV_Path
        {
            get { return csv_path; }
            set
            {
                csv_path = value;
                // add data for graph
                var lines = File.ReadAllLines(csv_path);
                int i_line = 0, skip = 0;
                foreach (string line in lines)
                {
                    string[] currentLine = line.Split(',');
                    // skip first line
                     if (skip == 0) { skip++; continue; }
                    // number of lines * 0.1 = time
                    for (int i = 0; i < 42; i++)
                    {    // point  ( time, value )
                        double time = 0.1 * i_line;
                        double parameter = double.Parse(currentLine[i]);
                        DataPoint point = new DataPoint(time, parameter);
                        set_points[i].Add(point);
                    }
                    i_line++;
                }

            }
        }
        // 2d array of points
        private List<DataPoint>[] set_points;
        // binding these points
        private List<DataPoint> points;
        public List<DataPoint> Points
        {
            get { return points; }
            set
            {
                points = value;
                NotifyPropertyChanged("Points");
            }
        }
        // param index for switching
        private int param_index;
        public int Param_Index
        {
            get { return param_index; }
            set { param_index = value; }
        }
        // curr line index of csv
        private int curr_line;
        private PlotModel graph;
        public GraphModel(PlotModel copygraph)
        {
            set_points = new List<DataPoint>[42];
            for (int i = 0; i < 42; i++) set_points[i] = new List<DataPoint>();
            Points = new List<DataPoint>();
            this.graph = copygraph;
        }
        // update 1
        public void update() => curr_line = 0;
        // update
        public void update2(int i_line)
        {
            // index of line 
            if (curr_line < i_line)
            {
                Points.AddRange(set_points[param_index].GetRange(curr_line, i_line - curr_line));
            }
            else if (curr_line > i_line)
            {
                Points.RemoveRange(i_line, curr_line - i_line);;
            }
            NotifyPropertyChanged("Points");
            Application.Current.Dispatcher.Invoke(() => { graph.InvalidatePlot(true); });
            curr_line = i_line;
        }
    }
}
