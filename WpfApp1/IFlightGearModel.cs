using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    interface IFlightGearModel : INotifyPropertyChanged
    {
        void connect(string ip, int port);
        void disconnect();
        void start();

        float Speedometer
        {
            set; get;
        }
    }

}
