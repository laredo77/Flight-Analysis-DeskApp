using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Helpers
{
    public class StringEventArgs : EventArgs
    {
        public string Data { get; set; }

        public string ID { get; set; }
    }
}
