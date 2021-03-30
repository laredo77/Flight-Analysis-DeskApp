using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class SpeedClockVM
    {

        SpeedClockM scmodel = new SpeedClockM();
        public void notify(Object x)
        {
            scmodel.printSpeed();
        }

    }
}
