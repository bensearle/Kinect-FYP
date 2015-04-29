using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit.FaceTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectTrackerAndBroadcaster.Models
{
    public class Unit3D
    {
        public decimal X { get; set; } // x point for 3D data type
        public decimal Y { get; set; } // y point for 3D data type
        public decimal Z { get; set; } // z point for 3D data type

        /// <summary>
        /// constructor for type
        /// </summary>
        /// <param name="joint">3D joint</param>
        public Unit3D(Joint joint)
        {
            // set local variables
            X = (decimal)joint.Position.X;
            Y = (decimal)joint.Position.Y;
            Z = (decimal)joint.Position.Z;
        }

        /// <summary>
        /// constructor for type
        /// </summary>
        /// <param name="vector">3D vector</param>
        public Unit3D(Vector3DF vector)
        {
            // set local variables
            X = (decimal)vector.X;
            Y = (decimal)vector.Y;
            Z = (decimal)vector.Z;
        }

        /// <summary>
        /// constructor for type
        /// </summary>
        /// <param name="x">x point</param>
        /// <param name="y">y point</param>
        /// <param name="z">z point</param>
        public Unit3D(decimal x, decimal y, decimal z)
        {
            // set local variables
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// create readable string of 3D point
        /// </summary>
        /// <returns>string of 3D point</returns>
        public override string ToString()
        {
            return String.Format("({0},{1},{2})", X, Y, Z);
        }

        /// <summary>
        /// create json string of 3D point
        /// </summary>
        /// <returns>json string of 3D point</returns>
        public string ToJson()
        {
            return String.Format("{{\"x\":{0},\"y\":{1},\"z\":{2}}}", Maths.Round(X*100), Maths.Round(Y*100), Maths.Round(Z*100));
        }
    }




}
