using FaceTrackingBasics.Models;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace FaceTrackingBasics
{
    class SkeletalTracking
    {

        public List<NamePointPair> Process(Skeleton skeleton)
        {
            var joints = new List<NamePointPair>();

            foreach (JointType joint in Enum.GetValues(typeof(JointType)))
            {
                Unit3D joint_position = new Unit3D(skeleton.Joints[joint]);

                joints.Add(new NamePointPair(joint.ToString(), joint_position));

                //Console.WriteLine(joint + ":: " + j.ToString());
                float x = skeleton.Joints[joint].Position.X;
                //skeleton.Joints[joint].Position.X;
                //string s = joint.JointType;
            }

            return joints;

        }
        

    }
}
