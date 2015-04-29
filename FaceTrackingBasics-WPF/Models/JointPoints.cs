using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectTrackerAndBroadcaster.Models
{
    class JointPoints
    {
        List<NamePointPair> joints = new List<NamePointPair>(); // list of joint names and coordinates

        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="skeleton">skeleton being processed</param>
        public JointPoints(Skeleton skeleton)
        {
            foreach (JointType joint in Enum.GetValues(typeof(JointType))) // iterate joint types
            {
                Unit3D joint_position = new Unit3D(skeleton.Joints[joint]); // create Unit3D of the joint coordinates
                joints.Add(new NamePointPair(joint.ToString(), joint_position)); // add joint name and coordinates to list
            }
        }

        /// <summary>
        /// structure to store joint name and coordinates
        /// </summary>
        private struct NamePointPair
        {
            public String Name; // name of joint
            public Unit3D Point; // coordinates of joint

            /// <summary>
            /// constructor for type
            /// </summary>
            /// <param name="s">name of joint</param>
            /// <param name="p">coordinates of joint</param>
            public NamePointPair(String s, Unit3D p)
            {
                // set local variables
                Name = s;
                Point = p;
            }
        }

        /// <summary>
        /// get readable string of all joint names and coordinates
        /// </summary>
        /// <returns>string of class data</returns
        public override string ToString()
        {
            String s = ""; // initialize string
            foreach (NamePointPair joint in joints) // iterate joints
            {
                // add string for joint to the return string
                s += String.Format("{0}:{1}, ", joint.Name, joint.Point.ToString());
            }
            return s; // return string
        }

        /// <summary>
        /// get a json string of all joint names and coordinates
        /// </summary>
        /// <returns>json string of class data</returns>
        public string ToJson()
        {
            String s = ""; // initialize string
            foreach (NamePointPair joint in joints) // iterate joints
            {
                // add string for joint to return string
                s += String.Format("\"{0}\":{1},", joint.Name, joint.Point.ToJson());
            }
            return s; // return string
        }
    }
}
