using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceTrackingBasics.Models
{
    class JointPoints
    {
        List<NamePointPair1> joints = new List<NamePointPair1>();

        public JointPoints(Skeleton skeleton)
        {
            foreach (JointType joint in Enum.GetValues(typeof(JointType)))
            {
                Unit3D joint_position = new Unit3D(skeleton.Joints[joint]);
                joints.Add(new NamePointPair1(joint.ToString(), joint_position));
            }
        }

        private struct NamePointPair1
        {
            public String Name;
            public Unit3D Point;

            public NamePointPair1(String s, Unit3D p)
            {
                Name = s;
                Point = p;
            }
        }

        /*public override string ToString()
        {
            String s = "";

            foreach (NamePointPair1 joint in joints)
            {
                s += String.Format("\"{0}\": {{ \"x\": {1}, \"y\": {2}, \"z\": {3} }},",
                    joint.Name, joint.Point.X, joint.Point.Y, joint.Point.Z);
            }

            return s;
        }*/

        public override string ToString()
        {
            String s = "";

            foreach (NamePointPair1 joint in joints)
            {
                s += String.Format("{0}:{1}, ", joint.Name, joint.Point.ToString());
            }

            return s;
        }


        public string ToJson()
        {
            String s = "";

            foreach (NamePointPair1 joint in joints)
            {
                s += String.Format("\"{0}\":{1},", joint.Name, joint.Point.ToJson());
            }

            return s;
        }
    }
}
