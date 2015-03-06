using Microsoft.Kinect.Toolkit.FaceTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceTrackingBasics.Models
{
/*    [Serializable]
    public struct NamePointPair<String, Unit3D>
    {
        public abstract NamePointPair(String name, Unit3D point);

        public String Name { get; }

        public Unit3D Point { get; }

        public override string ToString()
        {
            string ss = string.Format("{0} : {1}",
                Name, Point.ToString());
            return ss;
        }
    }
*/
    class NamePointPair
    {
        public String Name { get; set; }
        public Unit3D Point { get; set; }

        public NamePointPair(String s, Unit3D p)
        {
            Name = s;
            Point = p;
        }


        public override string ToString()
        {
            String ss = String.Format("{0} : x = {1}, y = {2}, z = {3}",
                Name, Point.X, Point.Y, Point.Z);
            return ss;
        }

    }
}
