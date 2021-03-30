using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public partial class SpeedClockV
    {
        SpeedClockVM vm = new SpeedClockVM();
        public void abcd(Object x)
        {
            vm.notify(x);
        }

    }
   
}
