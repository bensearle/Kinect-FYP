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


        public override string ToString()
        {
            return "X: " + X + " Y: " + Y + " Z: " + Z;
        }
    }




}
