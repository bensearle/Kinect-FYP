using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit.FaceTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceTrackingBasics.Models
{
    public class Unit3D
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }

        public Unit3D(Joint joint)
        {
            X = (decimal)joint.Position.X;
            Y = (decimal)joint.Position.Y;
            Z = (decimal)joint.Position.Z;
        }

        public Unit3D(Vector3DF vector)
        {
            X = (decimal)vector.X;
            Y = (decimal)vector.Y;
            Z = (decimal)vector.Z;
        }

        public Unit3D(decimal x, decimal y, decimal z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return String.Format("({0},{1},{2})", X, Y, Z);
        }

        public string ToJson()
        {
            return String.Format("{{\"x\":{0},\"y\":{1},\"z\":{2}}}", Maths.Round(X*100), Maths.Round(Y*100), Maths.Round(Z*100));
        }
    }




}
