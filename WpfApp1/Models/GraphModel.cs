using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<string> Algo_Detect
        {
            set
            {
                foreach (string str1 in value)
                {
                    string[] split1 = str1.Split('-');
                    string[] split2 = split1[0].Split(' ');
                    // split 2
                    int index = int.Parse(split2[0]);
                    // contradiction
                    if ((param_index != int.Parse(split2[1]) || corrIndexes[param_index] != int.Parse(split1[1])) &&
                        (param_index != int.Parse(split1[1]) || corrIndexes[param_index] != int.Parse(split2[1])))
                    { continue; }
                    double x = set_values[param_index][index];
                    double y = set_values[corrIndexes[param_index]][index];
                    DataPoint p = new DataPoint(x,y);
                    algo_points.Add(p);
                }
                NotifyPropertyChanged("Algo_Points");
            }
        }

        // Display min circle
        //public List<string> Display_MinCircle
        //{
        //    set
        //    {
        //        foreach (string str1 in value)
        //        {
        //            string[] split1 = str1.Split('-');
        //            string[] split2 = split1[0].Split(' ');
        //            // split 2
        //            int index = int.Parse(split2[0]);
        //            int center_x = int.Parse(split2[1].Split('.')[0]);
        //            int center_y = int.Parse(split2[2].Split('.')[0]);
        //            int radius = int.Parse(split2[3].Split('.')[0]);
        //            // contradiction
        //            if ((param_index != int.Parse(split2[1]) || corrIndexes[param_index] != int.Parse(split1[1])) &&
        //                (param_index != int.Parse(split1[1]) || corrIndexes[param_index] != int.Parse(split2[1])))
        //            { continue; }
        //            double x = set_values[param_index][index];
        //            double y = set_values[corrIndexes[param_index]][index];

        //            DataPoint p = new DataPoint(x, y);
        //            center_points.Add(p);
        //            c_radius.Add(radius);
        //        }
        //        NotifyPropertyChanged("Center_Point");
        //        NotifyPropertyChanged("Radius");
        //    }
        //}



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
                        set_values[i].Add(parameter);
                    }
                    i_line++;
                }
                corrlection();
            }
        }
        // 2d array of parameters
        private List<double>[] set_values;
        // 2d array of points time,parameter
        private List<DataPoint>[] set_points;
        // binding these points
        private List<DataPoint> points;
        public List<DataPoint> Points
        {
            get { return points; }
            set { points = value; }
        }
        // binding these corr_Points
        private List<DataPoint> corr_points;
        public List<DataPoint> Corr_Points
        {
            get { return corr_points; }
            set { corr_points = value; }
        }
        private List<DataPoint> scatter_points;
        public List<DataPoint> Scatter_Points
        {
            get { return scatter_points; }
            set
            {
                scatter_points = value;
                NotifyPropertyChanged("Scatter_Points");
            }
        }
        private List<DataPoint> algo_points;
        public List<DataPoint> Algo_Points
        {
            get { return algo_points; }
        }

        //private List<DataPoint> center_points;
        //public List<DataPoint> Center_Points
        //{
        //    get { return center_points; }
        //}

        //private List<double> c_radius;
        //public List<double> Radius
        //{
        //    get { return c_radius; }
        //}


        private List<DataPoint> line;
        public List<DataPoint> Line
        {
            get { return line; }
            set
            {
                line = value;
                NotifyPropertyChanged("Line");
            }
        }
        // param index for switching
        private int param_index;
        public int Param_Index
        {
            get { return param_index; }
            set
            {
                param_index = value;
                // update line_reg of param and his corr_param
                if (corrIndexes.Count > 0)
                {
                    Line = linear_reg(set_values[param_index], set_values[corrIndexes[param_index]]);
                }
            }
        }
        // curr line index of csv
        private int curr_line;
        // Constructor
        public GraphModel()
        {
            set_points = new List<DataPoint>[42];
            set_values = new List<double>[42];
            for (int i = 0; i < 42; i++)
            {
                set_points[i] = new List<DataPoint>();
                set_values[i] = new List<double>();
            }
            Points = new List<DataPoint>();
            Corr_Points = new List<DataPoint>();
            algo_points = new List<DataPoint>();
            corrIndexes = new Dictionary<int, int>();
        }
        // reset 1
        public void reset() => curr_line = 0;
        // update 2
        public void update(int i_line)
        {
            // scatter points
            int i = 0;
            List<DataPoint> test = new List<DataPoint>();
            if (i_line > 300) i = i_line - 300; else i = 0;
            for (; i < i_line; i++)
            {
                double x = set_values[param_index][i], y = set_values[corrIndexes[param_index]][i];
                DataPoint p = new DataPoint(x, y);
                test.Add(p);
            }
            Scatter_Points = test;


            // index of second parameter 
            int param2 = corrIndexes[param_index];
            // update graphs efficently
            if (curr_line < i_line)
            {
                // add points
                Points.AddRange(set_points[param_index].GetRange(curr_line, i_line - curr_line));
                Corr_Points.AddRange(set_points[param2].GetRange(curr_line, i_line - curr_line));
            }
            else if (curr_line > i_line)
            {
                // remove points
                Points.RemoveRange(i_line, curr_line - i_line);
                Corr_Points.RemoveRange(i_line, curr_line - i_line);
            }
            // notify after the update
            NotifyPropertyChanged("Points");
            NotifyPropertyChanged("Corr_Points");
            // curr line
            curr_line = i_line;
        }

        // get param index
        public int param2()
        {
            if (corrIndexes.Count != 0) return corrIndexes[param_index];
            else return 0;
        }


        // cpu cant deal with slow cpp calcs of dll
        // calculations of graph because its faster than dll file

        // E(W) Avg it can be everything
        private double Avg(List<double> list)
        {
            double avg = 0;
            foreach (double w in list) avg += w;
            return avg / list.Count;
        }
        // Cov = E(XY) - E(X)E(Y)
        private double Var(List<double> list) => Cov(list, list);
        private double Cov(List<double> list1, List<double> list2)
        {
            List<double> mixed = new List<double>();
            for (int i = 0; i < list1.Count; i++) mixed.Add(list1[i] * list2[i]);
            return Avg(mixed) - Avg(list1) * Avg(list2);
        }
        // pearson
        private double Pearson(List<double> list1, List<double> list2)
        {
            // find cov
            double covxy = Cov(list1, list2);
            // find sx and sy and var is cove of same list 
            double sx = Math.Sqrt(Var(list1));
            double sy = Math.Sqrt(Var(list2));
            return covxy / (sx * sy);
        }
        // reg 
        private List<DataPoint> linear_reg(List<double> list1, List<double> list2)
        {
            List<DataPoint> test = new List<DataPoint>();
            // cov xy
            double covxy = Cov(list1, list2);
            double varx = Var(list1);
            // y = a * x + b
            double a = covxy / varx;
            // E(Y) - a * E(X)
            double b = Avg(list2) - a * Avg(list1);
            // Create Line 
            test.Add(new DataPoint(list1.Min(), a * list1.Min() + b));
            test.Add(new DataPoint(list1.Max(), a * list1.Max() + b));
            return test;
        }

        // corr indexes
        private Dictionary<int, int> corrIndexes;
        private void corrlection()
        {
            if (corrIndexes.Count > 0) corrIndexes.Clear();
            int k;
            double max_pearson, test = 0;
            for (int i = 0; i < set_values.Length; i++)
            {
                max_pearson = -1;
                k = 0;
                for (int j = 0; j < set_values.Length; j++)
                {
                    if (i == j) continue;
                    test = Pearson(set_values[i], set_values[j]);
                    if (max_pearson < test) { max_pearson = test; k = j; }
                }
                corrIndexes.Add(i, k);
            }
        }
    }
}
