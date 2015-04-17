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

        private static string newPerson = ""; // name of person to be added to the system

        private static bool readyToSend = false;
        private static string jsonString = "{}";

        static bool toInitialize = true;
        static int testi = 0;

        private static int testint = 0;

        public static void TrackSkeleton(Skeleton skeleton, FaceTrackFrame frame, int skeletonIndex)
        {
            if (toInitialize)
            {
                Initialize();
                // start a thread to process the data
                //Thread thread_process = new Thread(StartProcessing);
                //thread_process.Start();
                //StartProcessing();
                toInitialize = false;
            }

            //Console.WriteLine(":::: " + skeletonIndex);
            if (!skeletonTracked[skeletonIndex])
            {            
                testi += 2;
                Console.WriteLine("£££££££ " + testi);
                skeletonTracked[skeletonIndex] = true; // skeleton is now being tracked
                skeletons[skeletonIndex] = skeleton; // skeleton added to array
                facePoints3D[skeletonIndex] = frame.Get3DShape(); // get the facePoints3D from the frame and add to array
                skeletonThreads[skeletonIndex].Interrupt(); // wake the thread to process the skeleton
                Console.WriteLine(" /\\ " + testint++);

            }
        }

        public static void NewPerson(string name)
        {
            newPerson = name;
            Console.WriteLine("@@@@@" + newPerson);
        }


        public static void UntrackSkeleton(int i)
        {
            skeletonTracked[i] = false;
            jsonNames[i] = "\"name\": unknown";
            // need to deal with skeletons that leave
        }

        private static Thread[] skeletonThreads;
        private static Thread jsonSendThread = new Thread(start_json_thread);
        private static Thread mainThread = new Thread(timer);

        public static void Initialize()
        {
            skeletonThreads = new Thread[6];
            skeletonThreads[0] = new Thread(() => ProcessSkeleton(0)); // create 6 threads
            skeletonThreads[0].Name = "ThreadSkel0";
            skeletonThreads[0].Start();
            skeletonThreads[1] = new Thread(() => ProcessSkeleton(1)); // create 6 threads
            skeletonThreads[1].Name = "ThreadSkel1";
            skeletonThreads[1].Start();
            skeletonThreads[2] = new Thread(() => ProcessSkeleton(2)); // create 6 threads
            skeletonThreads[2].Name = "ThreadSkel2";
            skeletonThreads[2].Start();
            skeletonThreads[3] = new Thread(() => ProcessSkeleton(3)); // create 6 threads
            skeletonThreads[3].Name = "ThreadSkel3";
            skeletonThreads[3].Start();
            skeletonThreads[4] = new Thread(() => ProcessSkeleton(4)); // create 6 threads
            skeletonThreads[4].Name = "ThreadSkel4";
            skeletonThreads[4].Start();
            skeletonThreads[5] = new Thread(() => ProcessSkeleton(5)); // create 6 threads
            skeletonThreads[5].Name = "ThreadSkel5";
            skeletonThreads[5].Start();

            //main();
            // mainThread.Start();
            jsonSendThread.Start(); // commented for testing
            //timer();
        }

        public static void createThread(int i)
        {
            switch (i)
            {
                case 0:
                    skeletonThreads[0] = new Thread(() => ProcessSkeleton(0));
                    skeletonThreads[0].Start();
                    break;
                case 1:
                    skeletonThreads[1] = new Thread(() => ProcessSkeleton(1));
                    skeletonThreads[1].Start();
                    break;
                case 2:
                    skeletonThreads[2] = new Thread(() => ProcessSkeleton(2));
                    skeletonThreads[2].Start();
                    break;
                case 3:
                    skeletonThreads[3] = new Thread(() => ProcessSkeleton(3));
                    skeletonThreads[3].Start();
                    break;
                case 4:
                    skeletonThreads[4] = new Thread(() => ProcessSkeleton(4));
                    skeletonThreads[4].Start();
                    break;
                case 5:
                    skeletonThreads[5] = new Thread(() => ProcessSkeleton(5));
                    skeletonThreads[5].Start();
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
                    if (!skeletonThreads[i].IsAlive)
                    {
                        createThread(i);
                        //skeletonThreads[i] = new Thread(() => ProcessSkeleton(i));
                        //skeletonThreads[i].Start(); // start the thread
                    }
                }
            }

            // wait until all threads have finished
            while (skeletonThreads[0].IsAlive || skeletonThreads[1].IsAlive ||
                skeletonThreads[2].IsAlive || skeletonThreads[3].IsAlive ||
                skeletonThreads[4].IsAlive || skeletonThreads[5].IsAlive)
            {
                // just wait
            }

            JsonModel js = new JsonModel(jsonSkeleton);
            jsonString = js.JsonString;
            readyToSend = true;
        }

        static System.Timers.Timer _timer; // From System.Timers

        private static void timer()
        {
            _timer = new System.Timers.Timer(3000); // Set up the timer 
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
            _timer.Enabled = true; // Enable it
        }

        private static void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            main();
            timer();
            Console.WriteLine("timer");
        }

        private static void ProcessSkeleton(int skeletonIndex)
        {
            if (skeletonTracked[skeletonIndex])
            { // if skeleton is being tracked
                Console.WriteLine("@@@@@111" + newPerson);

                if (newPerson != "") // if person is to be added to the system
                {
                    Console.WriteLine("@@@@@222" + newPerson);
                    string name = newPerson;
                    newPerson = "";
                    Console.WriteLine(name + " being added to database");
                    FacialRecognition fr = new FacialRecognition();
                    string nameAdded = fr.Process(facePoints3D[skeletonIndex], name); // returns name
                }

                testi += 1;
                Console.WriteLine(";;;;;;;;;;;; " + testi);
                Console.WriteLine("************* " + skeletonIndex);
                if (jsonNames[skeletonIndex] == "\"name\": unknown") // if the name is unkown
                {
                    //start_face_thread(skeletonIndex); // create thread for facial recognition
                }
                start_joints_thread(skeletonIndex); // create thread for tracking joints

                // create the JSON for this skeleton
                jsonSkeleton[skeletonIndex] += "\"Skeleton_" + skeletonIndex + "\": { " + jsonJoints[skeletonIndex] + jsonNames[skeletonIndex] + "}";

                skeletonTracked[skeletonIndex] = false; // change to false, so that more data can be added
                //ProcessSkeleton(skeletonIndex);
            }
            readyToSend = true;
            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException e) // exception caught when thead is iterrupted
            {
                ProcessSkeleton(skeletonIndex); // call this method
            }

            /*while (!skeletonTracked[skeletonIndex])
            {
                // wait
            }
            //Console.WriteLine("£$£$£$£$£$£$£$£$£$£$ money");
            ProcessSkeleton(skeletonIndex);
             */

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
        }

        private static void start_json_thread()
        {            
            JsonModel js = new JsonModel(jsonSkeleton);
            jsonString = js.JsonString;

            UdpSend.udpBroadcastMessage(jsonString, 4);
            readyToSend = false;

            while (!readyToSend)
            {
                // wait until ready to send
            }
            start_json_thread();
        }
    }
}
