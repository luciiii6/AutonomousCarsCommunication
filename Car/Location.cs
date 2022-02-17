using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousCarsCommunication
{
    class Location
    {
        private double x;
        private double y;

        public Location(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        
        public Location(Location location)
        {
            this.x = location.x;
            this.y = location.y;
        }

        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { x = value; } }
    }
}
