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

namespace WpfApp1.ViewModels
{
    public class GraphVM : ViewModelBase
    {
        public Dictionary<string, int> Dict_Params { get; set; }
        public List<string> Parameters { get; set; }
        private GraphModel model;
        public GraphVM(GraphModel model) 
        {
            this.model = model;
        }
        public void add_CSV_Path(string path) => model.CSV_Path = path;
    }
}
