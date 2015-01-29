using FaceTrackingBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceTrackingBasics
{
    class Maths
    {
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
    }
}
