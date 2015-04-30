using KinectTrackerAndBroadcaster.Models;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit.FaceTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KinectTrackerAndBroadcaster
{
    public static class SkeletonProcessing
    {
        public static bool[] skeletonReady = { false, false, false, false, false, false }; // is the skeleton ready to be processed
        public static Skeleton[] skeletons = new Skeleton[6]; // all of the skeletons
        public static EnumIndexableCollection<FeaturePoint, Vector3DF>[] facePoints3D = new EnumIndexableCollection<FeaturePoint, Vector3DF>[6]; // all of the 3D face points
    
        // arrays of json strings
        private static String[] jsonSkeleton = { "", "", "", "", "", "" };
        private static String[] jsonJoints = new String[6];
        private static String[] jsonNames = { "\"name\": unknown", "\"name\": unknown", "\"name\": unknown", "\"name\": unknown", "\"name\": unknown", "\"name\": unknown" };

        private static String[] names = { "", "", "", "", "", "" }; // names of skeletons in scope

        private static string newPerson = ""; // name of person to be added to the system

        private static bool readyToSend = false; // is json data ready to be sent
        private static string jsonString = "{}"; // the json string to be sent

        private static bool toInitialize = true; // do the threads need to be initialized
    
        private static Thread[] skeletonThreads; // threads for processing skeletons
        private static Thread jsonSendThread = new Thread(sendJson); // thread for sending json data

        /// <summary>
        /// initialize all of threads
        /// </summary>
        public static void Initialize()
        {
            skeletonThreads = new Thread[6]; // create array of 6 threads
            // create the skeleton thread
            // label the skeleton thread
            // start the skeleton thread
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

            jsonSendThread.Start(); // start the json thread
        }

        /// <summary>
        /// start tracking a skeleton
        /// </summary>
        /// <param name="skeleton"></param>
        /// <param name="frame"></param>
        /// <param name="skeletonIndex"></param>
        public static void TrackSkeleton(Skeleton skeleton, FaceTrackFrame frame, int skeletonIndex)
        {
            if (toInitialize) // if not initialize
            {
                Initialize(); // initialize
                toInitialize = false; // flip bit
            }

            if (!skeletonReady[skeletonIndex]) // if skeleton is not being processed
            {
                Console.WriteLine("TrackSkeleton " + skeletonIndex);
                skeletons[skeletonIndex] = skeleton; // skeleton added to array
                facePoints3D[skeletonIndex] = frame.Get3DShape(); // get the facePoints3D from the frame and add to array
                skeletonReady[skeletonIndex] = true; // skeleton is now being processed               

            }
        }

        /// <summary>
        /// stop tracking a skeleton
        /// </summary>
        /// <param name="i">index of skeleton</param>
        public static void UntrackSkeleton(int i)
        {
            Console.WriteLine("Untrack " + i);
            skeletonReady[i] = false; // skeleton not ready
            jsonNames[i] = "\"name\": unknown"; // name is unkown
            names[i] = ""; // name is empty
            jsonSkeleton[i] = ""; // json string is empty
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skeletonIndex">index of skeleton</param>
        private static void processSkeleton(int skeletonIndex)
        {
            //Console.WriteLine("executed"+skeletonIndex);
            if (skeletonReady[skeletonIndex])
            { // if skeleton is being tracked
                Console.WriteLine("ProcessSkeleton " + skeletonIndex);

                if (newPerson != "") // if person is to be added to the system
                {
                    //Console.WriteLine("Add New Person: " + newPerson);
                    string name = newPerson; // create local copy of name
                    newPerson = ""; // remove name
                    //Console.WriteLine(name + " being added to database");
                    FacialRecognition fr = new FacialRecognition(); // create instance of facial recognition
                    string nameAdded = fr.Process(facePoints3D[skeletonIndex], name); // add the name and face to the system
                    names[skeletonIndex] = nameAdded; // set the name to local variable
                    Console.WriteLine(name + " added to database");
                }

                if (names[skeletonIndex] == "") // if the name is unkown
                {
                    processSkeletonFace(skeletonIndex); // get the name of the skeleton
                }
                processSkeletonJoints(skeletonIndex); // get skeleton joints

                // create the JSON for this skeleton
                jsonSkeleton[skeletonIndex] = "{\"Skeleton_" + skeletonIndex + "\": { " + jsonJoints[skeletonIndex] + jsonNames[skeletonIndex] + "}}";

                skeletonReady[skeletonIndex] = false; // change to false, so that more data can be added
                readyToSend = true; // json data is ready to be sent
            }
            try
            {
                //Thread.Sleep(Timeout.Infinite);
                Thread.Sleep(500); // sleep for 500ms

            }
            catch (ThreadInterruptedException e) // exception caught when thead is iterrupted
            {
                Console.WriteLine("Error - SkeletonProcessing.processSkeleton("+skeletonIndex+"): " + e);
                processSkeleton(skeletonIndex); // call this method
            }
            processSkeleton(skeletonIndex); // call this method
        }

        /// <summary>
        /// recognise the face of the skeleton
        /// </summary>
        /// <param name="i">index of skeleton</param>
        private static void processSkeletonFace(int i)
        {
            FacialRecognition fr = new FacialRecognition(); // create facial recognition instance
            string name = fr.Process(facePoints3D[i]); // get name
            names[i] = name; // set local name variable
            jsonNames[i] = String.Format("\"name\": \"{0}\"", name); // JSON format of name
        }

        /// <summary>
        /// get the joint positions from the skeleton
        /// </summary>
        /// <param name="i">index of skeleton</param>
        private static void processSkeletonJoints(int i)
        {
            JointPoints joints = new JointPoints(skeletons[i]); // get all joints as JointPoints
            string joints_json = joints.ToJson(); // create json of joints
            jsonJoints[i] = joints_json; // set local variable
        }

        /// <summary>
        /// method in the json thread to send data
        /// </summary>
        private static void sendJson()
        {
            readyToSend = false; // flip bit

            for (int i = 0; i < 6; i++) // iterate skeleton jsons
            {
                if (jsonSkeleton[i] != "") { // if the json has content
                    UdpSend.UdpBroadcastMessage(jsonSkeleton[i], 4); // send the json through port 4
                    jsonSkeleton[i] = ""; // remove json string from local variable
                }
            }

            // sending all skeletons at once
            /*
            JsonModel js = new JsonModel(jsonSkeleton);
            jsonString = js.JsonString;

            UdpSend.UdpBroadcastMessage(jsonString, 4);
            readyToSend = false;
            */

            while (!readyToSend)
            {
                // wait until ready to send
            }
            sendJson(); // call this method
        }

        /// <summary>
        /// set the name of the person to be added to the system
        /// </summary>
        /// <param name="name">name of person to be added</param>
        public static void NewPerson(string name)
        {
            newPerson = name; // set the local variable for name to be added
        }

        /// <summary>
        /// gets the name of a person for a specific skeleton
        /// </summary>
        /// <param name="i">index of skeleton</param>
        /// <returns>name</returns>
        public static string GetName(int i)
        {
            return names[i]; // return name
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
            //main();
            timer();
            Console.WriteLine("timer");
        }
    }
}
