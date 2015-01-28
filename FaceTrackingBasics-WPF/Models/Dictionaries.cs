using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FaceTrackingBasics.Models
{
    class Dictionaries
    {

        public Dictionary<int, JointType> Joints { get; set; }


        public Dictionaries()
        {
            Joint_Dictionary();
        }

        public Dictionaries(string d)
        {
            switch (d)
            {
                case "Joints":
                    Joint_Dictionary();
                    break;
                case "":
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        public void Joint_Dictionary()
        {
            Joints = new Dictionary<int, JointType>(); // create dictionary of joint types

            // add items to dictionary
            Joints.Add(0, JointType.Head);
            Joints.Add(1, JointType.ShoulderRight);
            Joints.Add(2, JointType.ShoulderCenter);
            Joints.Add(3, JointType.ShoulderLeft);
            Joints.Add(4, JointType.ElbowRight);
            Joints.Add(5, JointType.ElbowLeft);
            Joints.Add(6, JointType.WristRight);
            Joints.Add(7, JointType.WristLeft);
            Joints.Add(8, JointType.HandRight);
            Joints.Add(9, JointType.HandLeft);
            Joints.Add(10, JointType.Spine);
            Joints.Add(11, JointType.HipRight);
            Joints.Add(12, JointType.HipCenter);
            Joints.Add(13, JointType.HipLeft);
            Joints.Add(14, JointType.KneeRight);
            Joints.Add(15, JointType.KneeLeft);
            Joints.Add(16, JointType.AnkleRight);
            Joints.Add(17, JointType.AnkleLeft);
            Joints.Add(18, JointType.FootRight);
            Joints.Add(19, JointType.FootLeft);
        }

    }
}
