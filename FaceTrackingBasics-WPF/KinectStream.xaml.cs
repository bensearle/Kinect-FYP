// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FaceTrackingBasics.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace KinectTrackerAndBroadcaster
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Microsoft.Kinect;
    using Microsoft.Kinect.Toolkit.FaceTracking;

    using Point = System.Windows.Point;
    using System.Globalization;
    using KinectTrackerAndBroadcaster.Models;

    /// <summary>
    /// Class that uses the Face Tracking SDK to display a face mask for
    /// tracked skeletons
    /// </summary>
    public partial class KinectStream : UserControl, IDisposable
    {
        public static readonly DependencyProperty KinectProperty = DependencyProperty.Register(
            "Kinect",
            typeof(KinectSensor),
            typeof(KinectStream),
            new PropertyMetadata(
                null, (o, args) => ((KinectStream)o).OnSensorChanged((KinectSensor)args.OldValue, (KinectSensor)args.NewValue)));

        private const uint MaxMissedFrames = 100;

        private readonly Dictionary<int, SkeletonTracker> trackedSkeletons = new Dictionary<int, SkeletonTracker>();

        private byte[] colorImage;

        private ColorImageFormat colorImageFormat = ColorImageFormat.Undefined;

        private short[] depthImage;

        private DepthImageFormat depthImageFormat = DepthImageFormat.Undefined;

        private bool disposed;

        private Skeleton[] skeletonData;

        private bool drawOnStream = true;

        public KinectStream()
        {
            this.InitializeComponent();
        }

        ~KinectStream()
        {
            this.Dispose(false);
        }

        public KinectSensor Kinect
        {
            get
            {
                return (KinectSensor)this.GetValue(KinectProperty);
            }

            set
            {
                this.SetValue(KinectProperty, value);
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                this.ResetFaceTracking();

                this.disposed = true;
            }
        }

        /// <summary>
        /// draw the joints and face on the video stream
        /// </summary>
        /// <param name="drawingContext">the window to be drawn on</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (drawOnStream) // if drawing is to happen
            {
                base.OnRender(drawingContext);

                // draw face
                foreach (SkeletonTracker faceInformation in this.trackedSkeletons.Values) // for each face being tracked
                {
                    faceInformation.DrawFaceModel(drawingContext); // draw face on screen
                }

                // draw joints
                if (this.skeletonData != null) // if not null
                {
                    int index = 0; // start index
                    foreach (Skeleton skeleton in this.skeletonData) // for each skeleton
                    {
                        if (skeleton.TrackingState != SkeletonTrackingState.NotTracked) // if skeleton is being tracked
                        {
                            foreach (JointType joint in Enum.GetValues(typeof(JointType))) // iterate joint types
                            {
                                Point p = skeletonPointToScreen(skeleton.Joints[joint].Position); // convert joint position in 3D space to position on screen
                                drawingContext.DrawEllipse(Brushes.Red, new Pen(Brushes.Red, 1), p, 5, 5); // draw a circle over the joint

                                if (joint.ToString() == "Head") // at the head
                                {
                                    // create text with the name of the person
                                    FormattedText f = new FormattedText(SkeletonProcessing.GetName(index),
                                        CultureInfo.GetCultureInfo("en-us"),
                                        FlowDirection.LeftToRight,
                                        new Typeface("Verdana"),
                                        16, System.Windows.Media.Brushes.Red);
                                    drawingContext.DrawText(f, new Point(p.X, p.Y - 25)); // write the name above the head
                                }
                            }
                        }
                        index++; // increment index
                    }
                }
            }
        }

        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor jointSensor;

        /// <summary>
        /// map a point in 3D space to point on screen
        /// </summary>
        /// <param name="skelpoint">point in 3D space</param>
        /// <returns>point on screen</returns>
        private Point skeletonPointToScreen(SkeletonPoint skelpoint)
        {
            // map point to 640x480 resolution.
            DepthImagePoint depthPoint = jointSensor.CoordinateMapper.MapSkeletonPointToDepthPoint(skelpoint, DepthImageFormat.Resolution640x480Fps30);
            return new Point(depthPoint.X + 2.5f, depthPoint.Y + 2.5f); // return point on screen
        }

        /// <summary>
        /// when colour and depth frames are ready to be processed, get the skeletons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="allFramesReadyEventArgs"></param>
        private void OnAllFramesReady(object sender, AllFramesReadyEventArgs allFramesReadyEventArgs)
        {
            //Kinect.SkeletonStream.TrackingMode = SkeletonTrackingMode.Default; // Use Standing Mode (all 20 joints)
            ColorImageFrame colorImageFrame = null;
            DepthImageFrame depthImageFrame = null;
            SkeletonFrame skeletonFrame = null;

            try
            {
                colorImageFrame = allFramesReadyEventArgs.OpenColorImageFrame();
                depthImageFrame = allFramesReadyEventArgs.OpenDepthImageFrame();
                skeletonFrame = allFramesReadyEventArgs.OpenSkeletonFrame();

                if (colorImageFrame == null || depthImageFrame == null || skeletonFrame == null)
                {
                    return;
                }

                // Check for image format changes.  The FaceTracker doesn't
                // deal with that so we need to reset.
                if (this.depthImageFormat != depthImageFrame.Format)
                {
                    this.ResetFaceTracking();
                    this.depthImage = null;
                    this.depthImageFormat = depthImageFrame.Format;
                }

                if (this.colorImageFormat != colorImageFrame.Format)
                {
                    this.ResetFaceTracking();
                    this.colorImage = null;
                    this.colorImageFormat = colorImageFrame.Format;
                }

                // Create any buffers to store copies of the data we work with
                if (this.depthImage == null)
                {
                    this.depthImage = new short[depthImageFrame.PixelDataLength];
                }

                if (this.colorImage == null)
                {
                    this.colorImage = new byte[colorImageFrame.PixelDataLength];
                }

                // Get the skeleton information
                if (this.skeletonData == null || this.skeletonData.Length != skeletonFrame.SkeletonArrayLength)
                {
                    this.skeletonData = new Skeleton[skeletonFrame.SkeletonArrayLength];
                }

                colorImageFrame.CopyPixelDataTo(this.colorImage);
                depthImageFrame.CopyPixelDataTo(this.depthImage);
                skeletonFrame.CopySkeletonDataTo(this.skeletonData);

                // Update the list of trackers and the trackers with the current frame information
                foreach (Skeleton skeleton in this.skeletonData)
                {

                    if (skeleton.TrackingState == SkeletonTrackingState.Tracked
                        || skeleton.TrackingState == SkeletonTrackingState.PositionOnly)
                    {
                        // We want keep a record of any skeleton, tracked or untracked.
                        if (!this.trackedSkeletons.ContainsKey(skeleton.TrackingId))
                        {
                            this.trackedSkeletons.Add(skeleton.TrackingId, new SkeletonTracker());
                        }

                        int skeletonIndex = Array.IndexOf(this.skeletonData, skeleton); // get the index of the skeleton

                        // Give each tracker the upated frame.
                        SkeletonTracker skeletonTracker;
                        if (this.trackedSkeletons.TryGetValue(skeleton.TrackingId, out skeletonTracker))
                        {
                            skeletonTracker.OnFrameReady(this.Kinect, colorImageFormat, colorImage, depthImageFormat, depthImage, skeleton, skeletonIndex);
                            skeletonTracker.LastTrackedFrame = skeletonFrame.FrameNumber;
                        }
                    }
                }

                this.RemoveOldTrackers(skeletonFrame.FrameNumber);

                this.InvalidateVisual();
            }
            finally
            {
                if (colorImageFrame != null)
                {
                    colorImageFrame.Dispose();
                }

                if (depthImageFrame != null)
                {
                    depthImageFrame.Dispose();
                }

                if (skeletonFrame != null)
                {
                    skeletonFrame.Dispose();
                }
            }
        }

        private void OnSensorChanged(KinectSensor oldSensor, KinectSensor newSensor)
        {
            if (oldSensor != null)
            {
                oldSensor.AllFramesReady -= this.OnAllFramesReady;
                this.ResetFaceTracking();
            }

            if (newSensor != null)
            {
                newSensor.AllFramesReady += this.OnAllFramesReady;
                jointSensor = newSensor; //
            }
        }

        /// <summary>
        /// Clear out any trackers for skeletons we haven't heard from for a while
        /// </summary>
        private void RemoveOldTrackers(int currentFrameNumber)
        {
            var trackersToRemove = new List<int>();

            foreach (var tracker in this.trackedSkeletons)
            {
                uint missedFrames = (uint)currentFrameNumber - (uint)tracker.Value.LastTrackedFrame;
                if (missedFrames > MaxMissedFrames)
                {
                    // There have been too many frames since we last saw this skeleton
                    trackersToRemove.Add(tracker.Key);
                }
            }

            foreach (int trackingId in trackersToRemove)
            {
                this.RemoveTracker(trackingId);
            }
        }

        private void RemoveTracker(int trackingId)
        {
            this.trackedSkeletons[trackingId].Dispose();
            this.trackedSkeletons.Remove(trackingId);
        }

        private void ResetFaceTracking()
        {
            foreach (int trackingId in new List<int>(this.trackedSkeletons.Keys))
            {
                this.RemoveTracker(trackingId);
            }
        }

        public class SkeletonTracker : IDisposable
        {
            private EnumIndexableCollection<FeaturePoint, PointF> facePoints;

            private FaceTracker faceTracker;

            private bool lastFaceTrackSucceeded;

            private SkeletonTrackingState skeletonTrackingState;

            public int LastTrackedFrame { get; set; }

            /// <summary>
            /// list of 121 facial points, with dynamic and duplicate points commented out
            /// location for each point is given
            /// </summary>
            private List<int> staticFacialPoints = new List<int>
            {
                0, // forehead
                1, // forehead
                2, // forehead
                3, // forehead
                4, // forehead
                5, // nose
                6, // nose
                //7, // upper lip
                //8, // chin
                //9, // chin
                //10, // chin
                11, // forehead
                12, // forehead
                13, // forehead
                14, // forehead
                //15, // left eyebrow
                //16, // left eyebrow
                //17, // left eyebrow
                //18, // left eyebrow
                19, // left eye
                20, // left eye
                //21, // upper left eye
                //22, // left eye - close to 24
                23, // left eye
                24, // left eye
                25, // nose
                26, // nose
                27, // left side of face
                28, // left side of face
                29, // left side of face
                30, // left side of face
                //31, // chin
                //32, // chin
                //33, // top lip
                34, // forehead
                //35, // forehead - same as 2
                //36, // forehead - same as 3
                //37, // nose - close to 4
                //38, // nose - same as 5
                //39, // nose - same as 6
                //40, // mouth
                41, // chin
                42, // chin
                43, // chin
                44, // forehead
                45, // forehead
                46, // forehead
                47, // forehead
                //48, // right eyebrow
                //49, // right eyebrow
                //50, // right eyebrow
                //51, // right eyebrow
                52, // right eye
                53, // right eye
                //54, // upper right eye
                //55, // right eye - close to 57
                56, // right eye
                57, // right eye
                58, // nose
                59, // nose
                60, // right side of face
                61, // right side of face
                62, // right side of face
                63, // right side of face
                //64, // chin
                //65, // chin
                //66, // top lip
                //67, // upper left eye
                68, // left eye
                //69, // upper right eye
                70, // right eye
                //71, // upper left eye
                72, // left eye
                //73, // upper right eye
                74, // right eye
                75, // nose
                76, // nose
                //77, // nose - close to 4
                //78, // nose - close to 4
                //79, // mouth
                //80, // mouth
                //81, // mouth
                //82, // mouth
                //83, // mouth
                //84, // mouth
                //85, // mouth
                //86, // mouth
                //87, // mouth
                //88, // mouth
                //89, // mouth
                //90, // top lip
                //91, // top lip
                92, // nose
                93, // nose
                94, // nose
                95, // left eye
                96, // right eye
                //97, // left eye - close to 95
                //98, // right eye - close to 96
                //99, // left eye - close to 101
                //100, // right eye - close to 102
                101, // left eye
                102, // right eye
                103, // left eye
                104, // right eye
                //105, // left eye - close to 103
                //106, // right eye - close to 104
                //107, // left eye - close to 109
                //108, // right eye - close to 110
                109, // left eye
                110, // right eye
                111, // nose
                112, // nose
                //113, // right side of face
                //114, // right side of face
                //115, // right side of face
                //116, // right side of face
                //117, // left side of face
                //118, // left side of face
                //119, // left side of face
                //120  // left side of face
            };

            /// <summary>
            /// the order of the line on the face
            /// </summary>
            private List<int> facialLine = new List<int> { 
                0,44,45,47,62,61,63,43,30,28,29,14,12,11,0, // outer of face loop
                34,45,46,47,2,62,60,61,41,63,42,30,27,29,13,12,1,11,2,14,36,// face loop of triangles
                13,1,34,46,53,60, // inner right of face loop
                59,112,6,111,26,25,75,5,76,58,59,93,94,92,5,94,25,58,25,6, // nose
                42,27, // inner left of face loop
                20,95,19,103,23,109,24,101,20,103,72,95,68,19, // left eye
                4,
                52,96,53,56,104,52,102,110,57,96,57,94,56,74,70,53, // right eye
                43,0,20,53,2,6// face cross
            };

            private List<int> facialAngles = new List<int>
            {
                1,0,34,
                11,0,44,
                12,11,0,
                0,44,45,
                11,12,14,
                44,45,47,
                12,14,29,
                45,47,62,
                14,29,28,
                47,62,61,
                29,28,30,
                62,61,63,
                28,30,43,
                61,63,43,
                30,43,63,
                30,42,63,
                30,41,63,
                41,61,60,
                41,28,27,
                27,29,2,
                60,62,2,
                14,2,29,
                47,2,62,
                1,3,34,
                13,3,46,
                34,46,53,
                1,13,20,
                13,20,27,
                46,53,60,
                20,27,26,
                53,60,59,
                14,1,34,
                47,34,1,
                23,3,56,
                20,3,53,
                26,4,59,
                92,4,93,
                92,94,93,
                75,94,76,
                26,25,94,
                59,58,94,
                111,26,25,
                112,59,58,
                26,111,75,
                59,112,76,
                75,6,76,
                25,5,58,
                20,95,19,
                95,19,103,
                19,103,23,
                103,23,109,
                23,109,24,
                109,24,103,
                24,103,20,
                103,20,95,
                56,104,52,
                104,52,96,
                52,96,53,
                96,53,102,
                53,102,57,
                102,57,110,
                57,110,56,
                110,56,104

            };

            public void Dispose()
            {
                if (this.faceTracker != null)
                {
                    this.faceTracker.Dispose();
                    this.faceTracker = null;
                }
            }

            /// <summary>
            /// draw line and face points on the face
            /// </summary>
            /// <param name="drawingContext">window to be drawn on</param>
            public void DrawFaceModel(DrawingContext drawingContext)
            {
                Boolean scaleFace = false; // do you want to increase the size of the face overlay?
                Boolean labelFacePoint = false; // do you want to label the face points?

                if (!this.lastFaceTrackSucceeded || this.skeletonTrackingState != SkeletonTrackingState.Tracked)
                {
                    return;
                }

                // get the coordinates for the face points
                var faceModelPts = new List<Point>();
                for (int i = 0; i < this.facePoints.Count; i++)
                {
                    faceModelPts.Add(new Point(this.facePoints[i].X + 0.5f, this.facePoints[i].Y + 0.5f));
                }

                // draw the face angles
                int anglesLength = facialAngles.Count;
                //int index = 0;
                for (int i = 0; i < anglesLength; i=i+3)
                {
                    drawingContext.DrawLine(new Pen(Brushes.Blue, 1), faceModelPts[facialAngles[i]], faceModelPts[facialAngles[i + 1]]);
                    drawingContext.DrawLine(new Pen(Brushes.Blue, 1), faceModelPts[facialAngles[i+1]], faceModelPts[facialAngles[i + 2]]);
                    //index = index + 3;
                }

                // draw the face line
                /*int lineLength = facialLine.Count;
                for (int i = 0; i < lineLength; i++)
                {
                    if (i != lineLength - 1) // last number in list
                    {
                        if (scaleFace)
                        {
                            drawingContext.DrawLine(new Pen(Brushes.Blue, 1), Maths.ScalePoint(faceModelPts[facialLine[i]]), Maths.ScalePoint(faceModelPts[facialLine[i + 1]]));

                        }
                        else
                        {
                            drawingContext.DrawLine(new Pen(Brushes.Blue, 1), faceModelPts[facialLine[i]], faceModelPts[facialLine[i + 1]]);
                        }
                    }
                }*/

                if (labelFacePoint)
                {
                    // draw the numbers over top of face
                    foreach (int point in staticFacialPoints)
                    {
                        Point p;
                        if (scaleFace)
                        {
                            p = Maths.ScalePoint(faceModelPts[point]);
                        }
                        else
                        {
                            p = faceModelPts[point];
                        }
                        FormattedText f = new FormattedText("" + point,
                            CultureInfo.GetCultureInfo("en-us"),
                            FlowDirection.LeftToRight,
                            new Typeface("Verdana"),
                            5, System.Windows.Media.Brushes.Blue);
                        drawingContext.DrawText(f, p);
                    }
                }

            }

            /// <summary>
            /// Updates the face tracking information for this skeleton
            /// calls the SkeletonProcessing class to start or stop processing data
            /// </summary>
            internal void OnFrameReady(KinectSensor kinectSensor, ColorImageFormat colorImageFormat, byte[] colorImage, DepthImageFormat depthImageFormat, short[] depthImage, Skeleton skeletonOfInterest, int skeletonIndex)
            {
                this.skeletonTrackingState = skeletonOfInterest.TrackingState;

                /*
                 * stop tracking the skeleton
                 */
                if (this.skeletonTrackingState != SkeletonTrackingState.Tracked) // if the skeleton is not being tracked
                {
                    SkeletonProcessing.UntrackSkeleton(skeletonIndex); // stop processing the skeleton
                    return;
                }

                if (this.faceTracker == null)
                {
                    try
                    {
                        this.faceTracker = new FaceTracker(kinectSensor);
                    }
                    catch (InvalidOperationException)
                    {
                        // During some shutdown scenarios the FaceTracker
                        // is unable to be instantiated.  Catch that exception
                        // and don't track a face.
                        Debug.WriteLine("AllFramesReady - creating a new FaceTracker threw an InvalidOperationException");
                        this.faceTracker = null;
                    }
                }

                /*
                 * start/continue tracking the skeleton
                 */
                if (this.faceTracker != null) // if there is data
                {
                    // create the face frame for skeleton from the colour and depth frames
                    FaceTrackFrame frame = this.faceTracker.Track(
                        colorImageFormat, colorImage, depthImageFormat, depthImage, skeletonOfInterest);

                    SkeletonProcessing.TrackSkeleton(skeletonOfInterest, frame, skeletonIndex); // process the skeleton

                    //EnumIndexableCollection<FeaturePoint, Vector3DF> face3D = frame.Get3DShape();
                    //EnumIndexableCollection<FeaturePoint, PointF> face2D = frame.GetProjected3DShape();

                    this.lastFaceTrackSucceeded = frame.TrackSuccessful;
                    if (this.lastFaceTrackSucceeded)
                    {
                        this.facePoints = frame.GetProjected3DShape();
                    }
                }
            }
        }
    }
}