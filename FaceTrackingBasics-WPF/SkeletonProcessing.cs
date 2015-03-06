using FaceTrackingBasics.Models;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit.FaceTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FaceTrackingBasics
{
    public static class SkeletonProcessing
    {
        public static bool[] skeletonTracked = {false,false,false,false,false,false}; // whether each skeleton is being tracked
        public static Skeleton[] skeletons = new Skeleton[6]; // all of the skeletons
        //public static FaceTrackFrame[] frames = new FaceTrackFrame[6]; // all of the face tracking frames
        public static EnumIndexableCollection<FeaturePoint, Vector3DF>[] facePoints3D = new EnumIndexableCollection<FeaturePoint, Vector3DF>[6]; // all of the 3D face points

        private static String[] jsonJoints = new String[6];
        private static String[] jsonNames = new String[6];
        
        static bool testbool = true;

        public static void TrackSkeleton(Skeleton skeleton, FaceTrackFrame frame)
        {
            int id = skeleton.TrackingId; // id of the skeleton
            skeletonTracked[0] = true; // skeleton is now being tracked
            skeletons[0] = skeleton; // skeleton added to array
            //frames[0] = frame;
            facePoints3D[0] = frame.Get3DShape(); // facePoints3D added to array
            
            if (testbool) {
                // start a thread to process the data
                Thread thread_process = new Thread(StartProcessing);
                thread_process.Start();
                //StartProcessing();
                testbool = false;
            }
        }

        public static void UntrackSkeleton(int i)
        {
            skeletonTracked[0] = false;
        }

        public static void StartProcessing()
        {
            if (skeletonTracked[0]){ // if skeleton is being tracked

                Thread thread_face = new Thread(start_face_thread); // create thread for facial recognition
                Thread thread_joints = new Thread(start_joints_thread); // create thread for tracking joints
                Thread mainThread = null;
                mainThread = Thread.CurrentThread; //main thread reference                
                
                // start threads
                thread_face.Start();
                thread_joints.Start();

                while (thread_face.IsAlive || thread_joints.IsAlive)
                {
                    // at least one thread is alive
                    //Console.WriteLine(".");
                }
                Console.WriteLine(jsonJoints[0]+jsonNames[0]);
            }
        }

        private static void start_face_thread()
        {
            FacialRecognition fr = new FacialRecognition();
            string name = fr.Process(facePoints3D[0]); // returns name
            string name_json = String.Format("\"name\": {0}", name); // JSON format of name
            jsonNames[0] = name_json;
        }

        private static void start_joints_thread()
        {
            JointPoints joints = new JointPoints(skeletons[0]); // returns all joints as JointPoints
            string joints_json = joints.ToString(); // JSON of joints
            jsonJoints[0] = joints_json;
            // no longer using SkeletalTracking
            /*SkeletalTracking st = new SkeletalTracking();
            List<NamePointPair> joints = new List<NamePointPair>(st.Process(skeletons[0]));

            foreach (NamePointPair np in joints)
            {
                 Console.WriteLine("????????????"+np.ToString());
            }*/
        }
    }
}
