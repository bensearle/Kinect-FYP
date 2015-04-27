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
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Unit3D(Joint joint)
        {
            X = joint.Position.X;
            Y = joint.Position.Y;
            Z = joint.Position.Z;
        }

        public Unit3D(Vector3DF vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        public Unit3D(double x, double y, double z)
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
            return String.Format("{{\"x\":{0},\"y\":{1},\"z\":{2}}}", Maths.Round(X), Maths.Round(Y), Maths.Round(Z));
        }
    }




}
