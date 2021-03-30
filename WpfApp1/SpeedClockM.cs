using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vector;

namespace WpfApp1
{
    public class SpeedClockM 
    {
        vector<float> data;
        public void printSpeed()
        {
            vector<float> data;
            var air_speed = File.ReadAllLines(@"C:\\Users\\lared\\Desktop\\reg_flight.csv");
            foreach (string line in air_speed)
            {
                var delimitedLine = line.Split(','); //set ur separator
                this.data = 
                //Console.WriteLine(delimitedLine[1]);
            }
           
        }
        public vector<float> getter()
        {
            return this.data;
        }
    }
}
