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
        public static bool[] skeletonReady = { false, false, false, false, false, false }; // is the skeleton ready to be processed
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

        public static void Initialize()
        {
            skeletonThreads = new Thread[6];
            skeletonThreads[0] = new Thread(() => processSkeleton(0)); // create 6 threads
            skeletonThreads[0].Name = "ThreadSkel0";
            skeletonThreads[0].Start();
            skeletonThreads[1] = new Thread(() => processSkeleton(1)); // create 6 threads
            skeletonThreads[1].Name = "ThreadSkel1";
            skeletonThreads[1].Start();
            skeletonThreads[2] = new Thread(() => processSkeleton(2)); // create 6 threads
            skeletonThreads[2].Name = "ThreadSkel2";
            skeletonThreads[2].Start();
            skeletonThreads[3] = new Thread(() => processSkeleton(3)); // create 6 threads
            skeletonThreads[3].Name = "ThreadSkel3";
            skeletonThreads[3].Start();
            skeletonThreads[4] = new Thread(() => processSkeleton(4)); // create 6 threads
            skeletonThreads[4].Name = "ThreadSkel4";
            skeletonThreads[4].Start();
            skeletonThreads[5] = new Thread(() => processSkeleton(5)); // create 6 threads
            skeletonThreads[5].Name = "ThreadSkel5";
            skeletonThreads[5].Start();

            //main();
            // mainThread.Start();
            jsonSendThread.Start(); // commented for testing
            //timer();
        }

        public static void TrackSkeleton(Skeleton skeleton, FaceTrackFrame frame, int skeletonIndex)
        {
            if (toInitialize)
            {
                Initialize();
                toInitialize = false;
            }

            if (!skeletonReady[skeletonIndex])
            //if (skeletonThreads[skeletonIndex].ThreadState == ThreadState.WaitSleepJoin) // thread is sleeping
            {
                Console.WriteLine("TrackSkeleton " + skeletonIndex);
                skeletons[skeletonIndex] = skeleton; // skeleton added to array
                facePoints3D[skeletonIndex] = frame.Get3DShape(); // get the facePoints3D from the frame and add to array
                skeletonReady[skeletonIndex] = true; // skeleton is now being tracked               
                //Console.WriteLine(" THREAD STATE " + skeletonThreads[skeletonIndex].ThreadState);
                //skeletonThreads[skeletonIndex].Interrupt(); // wake the thread to process the skeleton
                //Console.WriteLine(" /\\ " + testint++);

            }
        }

        public static void UntrackSkeleton(int i)
        {
            skeletonReady[i] = false;
            jsonNames[i] = "\"name\": unknown";
            Console.WriteLine("***skel being untracked " + i);
        }

        public static void NewPerson(string name)
        {
            newPerson = name;
            //Console.WriteLine("@@@@@" + newPerson);
        }




        private static Thread[] skeletonThreads;
        private static Thread jsonSendThread = new Thread(sendJson);
        private static Thread mainThread = new Thread(timer);



        static System.Timers.Timer _timer; // From System.Timers

        private static void timer()
        {
            _timer = new System.Timers.Timer(3000); // Set up the timer 
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
            _timer.Enabled = true; // Enable it
        }

        private static void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //main();
            timer();
            Console.WriteLine("timer");
        }

        private static void processSkeleton(int skeletonIndex)
        {
            //Console.WriteLine("executed"+skeletonIndex);
            if (skeletonReady[skeletonIndex])
            { // if skeleton is being tracked
                Console.WriteLine("ProcessSkeleton " + skeletonIndex);

                if (newPerson != "") // if person is to be added to the system
                {
                    //Console.WriteLine("Add New Person: " + newPerson);
                    string name = newPerson;
                    newPerson = "";
                    //Console.WriteLine(name + " being added to database");
                    FacialRecognition fr = new FacialRecognition();
                    string nameAdded = fr.Process(facePoints3D[skeletonIndex], name); // returns name
                    Console.WriteLine(name + " added to database");
                }

                //testi += 1;

                if (jsonNames[skeletonIndex] == "\"name\": unknown") // if the name is unkown
                {
                    processSkeletonFace(skeletonIndex); // create thread for facial recognition
                    //MainWindow.UpdateNames("");        
                }
                processSkeletonJoints(skeletonIndex); // create thread for tracking joints

                // create the JSON for this skeleton
                jsonSkeleton[skeletonIndex] = "\"Skeleton_" + skeletonIndex + "\": { " + jsonJoints[skeletonIndex] + jsonNames[skeletonIndex] + "}";

                //Console.WriteLine(skeletonIndex + " --" + jsonSkeleton[skeletonIndex]);
                skeletonReady[skeletonIndex] = false; // change to false, so that more data can be added
                readyToSend = true;
            }
            try
            {
                //Thread.Sleep(Timeout.Infinite);
                Thread.Sleep(500);

            }
            catch (ThreadInterruptedException e) // exception caught when thead is iterrupted
            {
                Console.WriteLine("wake up");
                processSkeleton(skeletonIndex); // call this method
            }
            processSkeleton(skeletonIndex); // call this method

            /*while (!skeletonReady[skeletonIndex])
            {
                // wait
            }
            //Console.WriteLine("£$£$£$£$£$£$£$£$£$£$ money");
            ProcessSkeleton(skeletonIndex);
             */

        }

        private static void processSkeletonFace(int i)
        {
            FacialRecognition fr = new FacialRecognition();
            string name = fr.Process(facePoints3D[i]); // returns name
            string name_json = String.Format("\"name\": \"{0}\"", name); // JSON format of name
            jsonNames[i] = name_json;

        }

        private static void processSkeletonJoints(int i)
        {
            JointPoints joints = new JointPoints(skeletons[i]); // returns all joints as JointPoints
            string joints_json = joints.ToString(); // JSON of joints
            jsonJoints[i] = joints_json;
            //Console.WriteLine("++ "+i+" ++"+joints_json);
            //Console.WriteLine(i + " ++" + jsonJoints[i]);

        }

        private static void sendJson()
        {
            JsonModel js = new JsonModel(jsonSkeleton);
            jsonString = js.JsonString;

            UdpSend.udpBroadcastMessage(jsonString, 4);
            readyToSend = false;

            while (!readyToSend)
            {
                // wait until ready to send
            }
            sendJson();
        }
    }
}
