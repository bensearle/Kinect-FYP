using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit.FaceTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FaceTrackingBasics
{
    public static class SkeletonProcessing
    {
        public static bool[] skeletonTracked = {false,false,false,false,false,false}; // whether each skeleton is being tracked
        public static Skeleton[] skeletons; // all of the skeletons
        public static FaceTrackFrame[] frames = new FaceTrackFrame[6]; // all of the face tracking frames

        static bool testbool = true;

        public static void TrackSkeleton(Skeleton skeleton, FaceTrackFrame frame)
        {
            int id = skeleton.TrackingId; // id of the skeleton
            skeletonTracked[0] = true; // skeleton is now being tracked
            frames[0] = frame;

            if (testbool) {
                StartProcessing();
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

                FacialRecognition fr = new FacialRecognition();
                Console.WriteLine("*** * * * * ** ****"+fr.Process(frames[0]));
                //skeltons[0];
                //frames[0];

            }


        }
    }
}
