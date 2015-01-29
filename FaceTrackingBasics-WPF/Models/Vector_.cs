using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceTrackingBasics.Models
{
    public class Vector_
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector_()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector_(double x)
        {
            X = x;
            Y = 0;
            Z = 0;
        }

        public Vector_(double x, double y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        public Vector_(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y + " Z: " + Z;
        }
    }
}
