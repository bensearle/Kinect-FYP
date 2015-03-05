using FaceTrackingBasics.Models;
using Microsoft.Kinect.Toolkit.FaceTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceTrackingBasics
{
    //public static class Maths: System.Math // cannot derive from static class System.Math
    public static class Maths
    {

        public static XYZCoord rotate_vector(XYZCoord vector, Vector3DF rotation)
        {
            // XYZ of vector
            double x = vector.X;
            double y = vector.Y;
            double z = vector.Z;

            // rotation around XYZ axis the face has taken, flipped and then converted to radians
            double rotX = Math.PI * (-rotation.X / 180);
            double rotY = Math.PI * (-rotation.Y / 180);
            double rotZ = Math.PI * (-rotation.Z / 180);
            
            // rotate around X-axis
            double x1 = x;
            double y1 = (y * Math.Cos(rotX)) - (z * Math.Sin(rotX));
            double z1 = (y * Math.Sin(rotX)) + (z * Math.Cos(rotX));

            // rotate around Y-axis
            double x2 = (x1 * Math.Cos(rotY)) + (z1 * Math.Sin(rotY));
            double y2 = y1;
            double z2 = (-x1 * Math.Sin(rotY)) + (z1 * Math.Cos(rotY));

            // rotate around Z-axis
            double x3 = (x2 * Math.Cos(rotZ)) - (y2 * Math.Sin(rotZ));
            double y3 = (x2 * Math.Sin(rotZ)) + (y2 * Math.Cos(rotZ));
            double z3 = z2;

  
            // return rotated vector
            return new XYZCoord(x3, y3, z3);
        }

        public static double angle_from_coords(XYZCoord a, XYZCoord b, XYZCoord c)
        {
            return angle(
                       coords_to_vector(a, b),
                       coords_to_vector(b, c));
        }

        public static Vector_ coords_to_vector(XYZCoord a, XYZCoord b)
        {
            return new Vector_(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static double lenth_ratio()
        {
            return 0;
        }

        public static double angle_ratio()
        {
            return 0;
        }

        /*
         * ratio methods
         * ratio(XYZCoord a1, XYZCoord a2, XYZCoord b1, XYZCoord b2)
         * ratio(Vector_ v1, Vector_ v2)
         * ratio(double d1, double d2)
         */

        // ratio of 2 lines (a1, a2) and (b1, b2)
        public static double ratio(XYZCoord a1, XYZCoord a2, XYZCoord b1, XYZCoord b2)
        {
            // if 0 then... throw new DivideByZeroException;
            return magnitude(a1, a2) / magnitude(b1, b2);
        }

        // ratio of 2 vectors
        public static double ratio(Vector_ v1, Vector_ v2)
        {
            return magnitude(v1) / magnitude(v2);
        }

        // ratio of 2 doubles
        public static double ratio(double d1, double d2)
        {
            // deal with 0
            return d1 / d2;
        }

        /*
         * magnitude methods
         * magnitude(XYZCoord a, XYZCoord b)
         * magnitude(Vector_ v)
         */

        // calculate the magnitude (distance) between 2 points
        public static double magnitude(XYZCoord a, XYZCoord b)
        {
            // Math.Abs not needed as it is squared
            double x = Math.Abs(a.X - b.X); // distance beween X's
            double y = Math.Abs(a.Y - b.Y); // distance beween Y's
            double z = Math.Abs(a.Z - b.Z); // distance beween Z's
            return Math.Sqrt(x * x + y * y + z * z);
        }

        // calculate the magnitude (distance) of a vector
        public static double magnitude(Vector_ v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
        }

        // calculate the magnitude (distance) of a vector
        public static double magnitude(XYZCoord v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
        }

        public static double angle(Vector_ v1, Vector_ v2)
        {
            double v1_magnitude;
            double v2_magnitude;
            Vector_ v1_normalized;
            Vector_ v2_normalized;
            double dot_product;
            double angle_radians;
            double angle_degrees;

            // get the magnitude of each vector
            v1_magnitude = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z);
            v2_magnitude = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);

            // normalize the vectors
            v1_normalized = new Vector_(v1.X / v1_magnitude, v1.Y / v1_magnitude, v1.Z / v1_magnitude);
            v2_normalized = new Vector_(v2.X / v2_magnitude, v2.Y / v2_magnitude, v2.Z / v2_magnitude);

            // calculate the dot product
            dot_product = v1_normalized.X * v2_normalized.X + v1_normalized.Y * v2_normalized.Y + v1_normalized.Z * v2_normalized.Z;

            // calculate the angle
            angle_radians = Math.Acos(dot_product);

            // convert angle to degrees
            angle_degrees = angle_radians * (180.0 / Math.PI);

            return angle_degrees;
        }

        /*
         * methods from Math class
         * Acos(double d)
         * Asin(double d)
         */

        public static double Acos(double d)
        {
            return Math.Acos(d);
        }

        public static double Asin(double d)
        {
            return Math.Asin(d);
        }
    }
}
