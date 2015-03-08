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
        public static bool[] skeletonTracked = { false, false, false, false, false, false }; // whether each skeleton is being tracked
        public static Skeleton[] skeletons = new Skeleton[6]; // all of the skeletons
        //public static FaceTrackFrame[] frames = new FaceTrackFrame[6]; // all of the face tracking frames
        public static EnumIndexableCollection<FeaturePoint, Vector3DF>[] facePoints3D = new EnumIndexableCollection<FeaturePoint, Vector3DF>[6]; // all of the 3D face points

        private static String[] jsonJoints = new String[6];
        private static String[] jsonNames = { "\"name\": unknown", "\"name\": unknown", "\"name\": unknown", "\"name\": unknown", "\"name\": unknown", "\"name\": unknown" };
        private static String[] jsonSkeleton = { "", "", "", "", "", "" };

        private static bool readyToSend = false;
        private static string jsonString = "{}";
        static bool testbool = true;

        public static void TrackSkeleton(Skeleton skeleton, FaceTrackFrame frame, int skeletonIndex)
        {
            skeletonTracked[skeletonIndex] = true; // skeleton is now being tracked
            skeletons[skeletonIndex] = skeleton; // skeleton added to array
            facePoints3D[skeletonIndex] = frame.Get3DShape(); // get the facePoints3D from the frame and add to array

            if (testbool)
            {
                Initialize();
                // start a thread to process the data
                //Thread thread_process = new Thread(StartProcessing);
                //thread_process.Start();
                //StartProcessing();
                testbool = false;
            }
        }

        public static void UntrackSkeleton(int i)
        {
            skeletonTracked[0] = false;
        }

        private static Thread[] skeletonThreads;
        private static Thread jsonSendThread = new Thread(start_json_thread);

        public static void Initialize()
        {
            skeletonThreads = new Thread[6];
            skeletonThreads[0] = new Thread(() => ProcessSkeleton(0)); // create 6 threads
            skeletonThreads[1] = new Thread(() => ProcessSkeleton(1)); // create 6 threads
            skeletonThreads[2] = new Thread(() => ProcessSkeleton(2)); // create 6 threads
            skeletonThreads[3] = new Thread(() => ProcessSkeleton(3)); // create 6 threads
            skeletonThreads[4] = new Thread(() => ProcessSkeleton(4)); // create 6 threads
            skeletonThreads[5] = new Thread(() => ProcessSkeleton(5)); // create 6 threads

            main();
            jsonSendThread.Start();
            timer();
        }

        public static void createThread(int i)
        {
            switch (i)
            {
                case 0:
                    skeletonThreads[0] = new Thread(() => ProcessSkeleton(0));
                    break;
                case 1:
                    skeletonThreads[1] = new Thread(() => ProcessSkeleton(1));
                    break;
                case 2:
                    skeletonThreads[2] = new Thread(() => ProcessSkeleton(2));
                    break;
                case 3:
                    skeletonThreads[3] = new Thread(() => ProcessSkeleton(3));
                    break;
                case 4:
                    skeletonThreads[4] = new Thread(() => ProcessSkeleton(4));
                    break;
                case 5:
                    skeletonThreads[5] = new Thread(() => ProcessSkeleton(5));
                    break;
                default:
                    break;
            }
        }

        private static void main()
        {
            // start the threads
            for (int i = 0; i < 6; i++)
            {
                if (skeletonTracked[i]) // if a skeleton is being tracked
                {
                    createThread(i);
                    skeletonThreads[i].Start(); // start the thread
                }
            }

            // wait until all threads have finished
            while (skeletonThreads[0].IsAlive || skeletonThreads[1].IsAlive ||
                skeletonThreads[2].IsAlive || skeletonThreads[3].IsAlive ||
                skeletonThreads[4].IsAlive || skeletonThreads[5].IsAlive)
            {
                // just wait
            }

            // create the JSON
            /*string jsonString = "";
            for (int i = 0; i < 6; i++)
            {
                if (skeletonTracked[i]) // if a skeleton is being tracked
                {
                    jsonString += "\"Skeleton_" + i + "\": { " + jsonJoints[i] + jsonNames[i] + "}, ";
                }
            }*/

            JsonModel js = new JsonModel(jsonSkeleton);
            jsonString = js.JsonString;
            readyToSend = true;
        }

        static System.Timers.Timer _timer; // From System.Timers

        public static void timer()
        {
            _timer = new System.Timers.Timer(1000); // Set up the timer for 3 seconds
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
            _timer.Enabled = true; // Enable it
        }

        public static void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            main();
            timer();
            Console.WriteLine("timer");
        }

        public static void ProcessSkeleton(int skeletonIndex)
        {
            if (skeletonTracked[skeletonIndex])
            { // if skeleton is being tracked

                Thread thread_face = new Thread(() => start_face_thread(skeletonIndex)); // create thread for facial recognition
                if (jsonNames[skeletonIndex] == "\"name\": unknown") // if the name is unkown
                {
                    thread_face.Start(); // start the thread
                }
                Thread thread_joints = new Thread(() => start_joints_thread(skeletonIndex)); // create thread for tracking joints
                thread_joints.Start(); // start the thread

                //Thread thread_json = new Thread(() => start_json_thread(skeletonIndex));
                //thread_json.Start();

                while (thread_face.IsAlive || thread_joints.IsAlive)
                {
                    // wait
                }

                // create the JSON for this skeleton
                jsonSkeleton[skeletonIndex] += "\"Skeleton_" + skeletonIndex + "\": { " + jsonJoints[skeletonIndex] + jsonNames[skeletonIndex] + "}";

            }
        }

        private static void start_face_thread(int i)
        {
            FacialRecognition fr = new FacialRecognition();
            string name = fr.Process(facePoints3D[i]); // returns name
            string name_json = String.Format("\"name\": \"{0}\"", name); // JSON format of name
            jsonNames[i] = name_json;
        }

        private static void start_joints_thread(int i)
        {
            JointPoints joints = new JointPoints(skeletons[i]); // returns all joints as JointPoints
            string joints_json = joints.ToString(); // JSON of joints
            jsonJoints[i] = joints_json;
            //start_joints_thread(); // call this thread
            // no longer using SkeletalTracking
            /*SkeletalTracking st = new SkeletalTracking();
            List<NamePointPair> joints = new List<NamePointPair>(st.Process(skeletons[0]));

            foreach (NamePointPair np in joints)
            {
                 Console.WriteLine("????????????"+np.ToString());
            }*/
        }

        private static void start_json_thread()
        {
            while (!readyToSend)
            {
                // wait until ready to send
            }

            UdpSend.udpBroadcastMessage(jsonString, 4);
            readyToSend = false;

            start_json_thread();
        }
    }
}
