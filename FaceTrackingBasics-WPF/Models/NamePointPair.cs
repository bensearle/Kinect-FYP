using Microsoft.Kinect.Toolkit.FaceTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceTrackingBasics.Models
{
    class NamePointPair
    {
        public String Name { get; set; }
        public Point Point { get; set; }

        public NamePointPair(String s, Point p)
        {
            Name = s;
            Point = p;
        }


        public override string ToString()
        {
            String ss = String.Format("{0} : x = {1}, y = {2}",
                Name, Point.X, Point.Y);
            return ss;
        }

    }
}
