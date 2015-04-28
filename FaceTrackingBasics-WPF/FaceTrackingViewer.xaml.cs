// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FaceTrackingViewer.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FaceTrackingBasics
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Microsoft.Kinect;
    using Microsoft.Kinect.Toolkit.FaceTracking;
    using System.Windows.Media.Media3D;
    using Coding4Fun.Kinect.Wpf;

    using Point = System.Windows.Point;
    using System.Globalization;
    using FaceTrackingBasics.Models;



    /// <summary>
    /// Class that uses the Face Tracking SDK to display a face mask for
    /// tracked skeletons
    /// </summary>
    public partial class FaceTrackingViewer : UserControl, IDisposable
    {
        public static readonly DependencyProperty KinectProperty = DependencyProperty.Register(
            "Kinect",
            typeof(KinectSensor),
            typeof(FaceTrackingViewer),
            new PropertyMetadata(
                null, (o, args) => ((FaceTrackingViewer)o).OnSensorChanged((KinectSensor)args.OldValue, (KinectSensor)args.NewValue)));

        private const uint MaxMissedFrames = 100;

        private readonly Dictionary<int, SkeletonFaceTracker> trackedSkeletons = new Dictionary<int, SkeletonFaceTracker>();

        private byte[] colorImage;

        private ColorImageFormat colorImageFormat = ColorImageFormat.Undefined;

        private short[] depthImage;

        private DepthImageFormat depthImageFormat = DepthImageFormat.Undefined;

        private bool disposed;

        private Skeleton[] skeletonData;

        public FaceTrackingViewer()
        {
            this.InitializeComponent();
        }

        ~FaceTrackingViewer()
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

        protected override void OnRender(DrawingContext drawingContext)
        {

            base.OnRender(drawingContext);
            foreach (SkeletonFaceTracker faceInformation in this.trackedSkeletons.Values)
            {
                faceInformation.DrawFaceModel(drawingContext);
            }

            // draw joints
            if (this.skeletonData != null &&false)
            {
                int index = 0;
                foreach (Skeleton skeleton in this.skeletonData)
                {
                    if (skeleton.TrackingState != SkeletonTrackingState.NotTracked)
                    {
                        foreach (JointType joint in Enum.GetValues(typeof(JointType)))
                        {
                            Point p = skeletonPointToScreen(skeleton.Joints[joint].Position);
                            drawingContext.DrawEllipse(Brushes.Red, new Pen(Brushes.Red, 1), p, 5, 5);

                            if (joint.ToString() == "Head")
                            {
                                FormattedText f = new FormattedText(SkeletonProcessing.GetName(index),
                                    CultureInfo.GetCultureInfo("en-us"),
                                    FlowDirection.LeftToRight,
                                    new Typeface("Verdana"),
                                    14, System.Windows.Media.Brushes.Red);
                                drawingContext.DrawText(f, new Point(p.X, p.Y+10));
                            }
                        }
                    }
                    index++;
                }
            }
        }

        // draw rectangle on the video stream
        //drawingContext.DrawRectangle(null, new Pen(Brushes.Blue, 10), new System.Windows.Rect(new Point(250, 0), new Point(400, 200)));

        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor jointSensor;

        /// <summary>
        /// Maps a SkeletonPoint to lie within our render space and converts to Point
        /// </summary>
        /// <param name="skelpoint">point to map</param>
        /// <returns>mapped point</returns>
        private Point skeletonPointToScreen(SkeletonPoint skelpoint)
        {
            // Convert point to depth space.  
            // We are not using depth directly, but we do want the points in our 640x480 output resolution.
            DepthImagePoint depthPoint = jointSensor.CoordinateMapper.MapSkeletonPointToDepthPoint(skelpoint, DepthImageFormat.Resolution640x480Fps30);
            return new Point(depthPoint.X, depthPoint.Y);
        }

        private void OnAllFramesReady(object sender, AllFramesReadyEventArgs allFramesReadyEventArgs)
        {
            // ************************
            // commented for testing
            Kinect.SkeletonStream.TrackingMode = SkeletonTrackingMode.Default; // Use Standing Mode (all 20 joints)
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

                int total_skeleton_count = 0;

                // Update the list of trackers and the trackers with the current frame information
                foreach (Skeleton skeleton in this.skeletonData)
                {

                    if (skeleton.TrackingState == SkeletonTrackingState.Tracked
                        || skeleton.TrackingState == SkeletonTrackingState.PositionOnly)
                    {
                        // We want keep a record of any skeleton, tracked or untracked.
                        if (!this.trackedSkeletons.ContainsKey(skeleton.TrackingId))
                        {
                            this.trackedSkeletons.Add(skeleton.TrackingId, new SkeletonFaceTracker());
                        }

                        int skeletonIndex = Array.IndexOf(this.skeletonData, skeleton); // get the index of the skeleton

                        // Give each tracker the upated frame.
                        SkeletonFaceTracker skeletonFaceTracker;
                        if (this.trackedSkeletons.TryGetValue(skeleton.TrackingId, out skeletonFaceTracker))
                        {
                            skeletonFaceTracker.OnFrameReady(this.Kinect, colorImageFormat, colorImage, depthImageFormat, depthImage, skeleton, skeletonIndex);
                            skeletonFaceTracker.LastTrackedFrame = skeletonFrame.FrameNumber;
                            //Console.WriteLine(skeletonFrame.FrameNumber);
                            total_skeleton_count++;
                            //s.OnFrameReady(this.Kinect, colorImageFormat, colorImage, depthImageFormat, depthImage, skeleton);

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

        public class SkeletonFaceTracker : IDisposable
        {
            private static FaceTriangle[] faceTriangles;

            private EnumIndexableCollection<FeaturePoint, PointF> facePoints;

            private FaceTracker faceTracker;

            private FaceTriangle[] faceTriangles_;

            private bool lastFaceTrackSucceeded;

            private SkeletonTrackingState skeletonTrackingState;

            public int LastTrackedFrame { get; set; }

            private List<Tuple<int, int>> facialPairs = new List<Tuple<int, int>>
            {
                new Tuple<int, int>( 1, 2 ),
                new Tuple<int, int>( 2, 3 ),
                new Tuple<int, int>( 1, 4 )
            };

            private List<int> facialVectors = new List<int>
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
            public void Dispose()
            {
                if (this.faceTracker != null)
                {
                    this.faceTracker.Dispose();
                    this.faceTracker = null;
                }
            }

            public void DrawFaceModel(DrawingContext drawingContext)
            {
                Boolean drawFaceNumbers = false;

                List<Tuple<Point, int>> list_number_coords = new List<Tuple<Point, int>>();

                if (!this.lastFaceTrackSucceeded || this.skeletonTrackingState != SkeletonTrackingState.Tracked)
                {
                    return;
                }

                var faceModelPts = new List<Point>();
                var faceModel = new List<FaceModelTriangle>();

                for (int i = 0; i < this.facePoints.Count; i++)
                {
                    faceModelPts.Add(new Point(this.facePoints[i].X + 0.5f, this.facePoints[i].Y + 0.5f));
                }

                for (int i = 0; i < facialVectors.Count - 1; i++)
                {
                    //drawingContext.DrawLine(new Pen(Brushes.Yellow, 1), Maths.ScalePoint(faceModelPts[facialVectors[i]]), Maths.ScalePoint(faceModelPts[facialVectors[i+1]]));
                }

                int lineLength = facialLine.Count;
                for (int i = 0; i < lineLength; i++)
                {
                    if (i == lineLength - 1) // last number in list
                    {

                    }
                    else
                    {
                        drawingContext.DrawLine(new Pen(Brushes.Blue, 1), Maths.ScalePoint(faceModelPts[facialLine[i]]), Maths.ScalePoint(faceModelPts[facialLine[i + 1]]));
                    }
                }

                //Console.WriteLine("**");
                //Unit3D dot0 = new Unit3D(faceModelPts[0].X,faceModelPts[0].Y,0);
                //foreach (int vec in facialVectors)
                {
                    //drawingContext.DrawLine(new Pen(Brushes.Yellow, 1), Maths.ScalePoint(faceModelPts[vec]), Maths.ScalePoint(faceModelPts[vec + 1]));
                    //Unit3D dot = new Unit3D(faceModelPts[vec].X,faceModelPts[vec].Y,0);
                    //double mag = Maths.Magnitude(dot0, dot);
                    //Console.Write(vec+","+mag+",");
                    //Point p = Maths.MidwayPoint(faceModelPts[vec], faceModelPts[vec + 1]);
                    /*Point p = faceModelPts[vec];

                    FormattedText f = new FormattedText("" + vec,
                        CultureInfo.GetCultureInfo("en-us"),
                        FlowDirection.LeftToRight,
                        new Typeface("Verdana"),
                        5, System.Windows.Media.Brushes.Red);
                    drawingContext.DrawText(f, p);*/
                }

                // draw the numbers over top
                foreach (int vec in facialVectors)
                {
                    //Point p = Maths.MidwayPoint(faceModelPts[vec], faceModelPts[vec + 1]);
                    //Point p = new Point (faceModelPts[vec].X*4-1200, faceModelPts[vec].Y*4-800);
                    Point p = Maths.ScalePoint(faceModelPts[vec]);

                    FormattedText f = new FormattedText("" + vec,
                        CultureInfo.GetCultureInfo("en-us"),
                        FlowDirection.LeftToRight,
                        new Typeface("Verdana"),
                        5, System.Windows.Media.Brushes.Yellow);
                    drawingContext.DrawText(f, p);
                }

                //drawingContext.DrawLine(new Pen(Brushes.Red, 1), new Point(faceModelPts[69].X * 4 - 1200, faceModelPts[69].Y * 4 - 800), new Point(faceModelPts[54].X * 4 - 1200, faceModelPts[54].Y * 4 - 800));
                //drawingContext.DrawLine(new Pen(Brushes.Red, 1), new Point(faceModelPts[73].X * 4 - 1200, faceModelPts[73].Y * 4 - 800), new Point(faceModelPts[54].X * 4 - 1200, faceModelPts[54].Y * 4 - 800));
                //drawingContext.DrawLine(new Pen(Brushes.Red, 1), new Point(faceModelPts[21].X * 4 - 1200, faceModelPts[21].Y * 4 - 800), new Point(faceModelPts[71].X * 4 - 1200, faceModelPts[71].Y * 4 - 800));
                //drawingContext.DrawLine(new Pen(Brushes.Red, 1), new Point(faceModelPts[21].X * 4 - 1200, faceModelPts[21].Y * 4 - 800), new Point(faceModelPts[67].X * 4 - 1200, faceModelPts[67].Y * 4 - 800));


                /*for (int i = 0; i < 120; i++)
                {
                    drawingContext.DrawLine(new Pen(Brushes.Blue, 1), faceModelPts[i], faceModelPts[i + 1]);

                }*/

                /*foreach (var t in faceTriangles)
                {
                    var triangle = new FaceModelTriangle();
                    triangle.P1 = faceModelPts[t.First];
                    triangle.P2 = faceModelPts[t.Second];
                    triangle.P3 = faceModelPts[t.Third];
                    faceModel.Add(triangle);
                    // add points and numbers to the list
                    if (drawFaceNumbers)
                    {
                        list_number_coords.Add(Tuple.Create(triangle.P1, t.First));
                        list_number_coords.Add(Tuple.Create(triangle.P2, t.Second));
                        list_number_coords.Add(Tuple.Create(triangle.P3, t.Third));
                    }
                    // add text of first number
                    drawingContext.DrawText(new FormattedText("" + t.First,
                        CultureInfo.GetCultureInfo("en-us"),
                        FlowDirection.LeftToRight,
                        new Typeface("Verdana"),
                        8, System.Windows.Media.Brushes.Red),
                        triangle.P1);
                    // add text of second number
                    drawingContext.DrawText(new FormattedText("" + t.Second,
                        CultureInfo.GetCultureInfo("en-us"),
                        FlowDirection.LeftToRight,
                        new Typeface("Verdana"),
                        8, System.Windows.Media.Brushes.Red),
                        triangle.P2);
                    // add text of third number
                    drawingContext.DrawText(new FormattedText("" + t.Third,
                        CultureInfo.GetCultureInfo("en-us"),
                        FlowDirection.LeftToRight,
                        new Typeface("Verdana"),
                        8, System.Windows.Media.Brushes.Red),
                        triangle.P3);
                }*/

                /*var faceModelGroup = new GeometryGroup();
                for (int i = 0; i < faceModel.Count; i++)
                {
                    var faceTriangle = new GeometryGroup();
                    faceTriangle.Children.Add(new LineGeometry(faceModel[i].P1, faceModel[i].P2));
                    faceTriangle.Children.Add(new LineGeometry(faceModel[i].P2, faceModel[i].P3));
                    faceTriangle.Children.Add(new LineGeometry(faceModel[i].P3, faceModel[i].P1));
                    faceModelGroup.Children.Add(faceTriangle);
                }*/

                /*for (int i = 0; i < face_coords.Length; i++)
                {
                    XYZCoord xyzCoord = face_coords[i];
                    Point p = new Point(xyzCoord.X*100, xyzCoord.Y*100);
                    //p.X = xyzCoord.X;
                    //p.Y = xyzCoord.Y;
                    FormattedText f = new FormattedText(""+i,
                        CultureInfo.GetCultureInfo("en-us"),
                        FlowDirection.LeftToRight,
                        new Typeface("Verdana"),
                        36, System.Windows.Media.Brushes.Yellow);
                    drawingContext.DrawText(f, p);
                    Debug.WriteLine(string.Format("{0}, {1}, {2}, {3}", i, p.X, p.Y, " ** "));
                }*/


                // drawingContext.DrawGeometry(Brushes.Red, new Pen(Brushes.Red, 1.0), faceModelGroup);
                if (drawFaceNumbers)
                {
                    foreach (Tuple<Point, int> t in list_number_coords) // iterate through the number and points list
                    {

                        if ((t.Item2) == MainWindow.tInc) // 
                        {
                            // add the number to the drawing context
                            drawingContext.DrawText(new FormattedText("" + t.Item2,
                                CultureInfo.GetCultureInfo("en-us"),
                                FlowDirection.LeftToRight,
                                new Typeface("Verdana"),
                                12, System.Windows.Media.Brushes.Blue),
                                t.Item1);
                            drawingContext.DrawEllipse(Brushes.Blue, new Pen(Brushes.Blue, 1), t.Item1, 1, 1);
                            //drawingContext.DrawRectangle(null, new Pen(Brushes.Blue, 10), new System.Windows.Rect(new Point(0, 0), t.Item1));                    

                        }
                    }
                }
                //drawingContext.DrawRectangle(Brushes.Blue, new Pen(Brushes.Blue, 10), new System.Windows.Rect(new Point(200, 50), new Point(300, 200)));

            }

            /// <summary>
            /// Updates the face tracking information for this skeleton
            /// </summary>
            internal void OnFrameReady(KinectSensor kinectSensor, ColorImageFormat colorImageFormat, byte[] colorImage, DepthImageFormat depthImageFormat, short[] depthImage, Skeleton skeletonOfInterest, int skeletonIndex)
            {
                this.skeletonTrackingState = skeletonOfInterest.TrackingState;

                if (this.skeletonTrackingState != SkeletonTrackingState.Tracked)
                {
                    // nothing to do with an untracked skeleton.
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

                if (this.faceTracker != null)
                {
                    FaceTrackFrame frame = this.faceTracker.Track(
                        colorImageFormat, colorImage, depthImageFormat, depthImage, skeletonOfInterest);

                    // printFaceVectors(frame);
                    // commented for testing
                    //SkeletonProcessing.TrackSkeleton(skeletonOfInterest, frame, skeletonIndex);

                    //EnumIndexableCollection<FeaturePoint, Vector3DF> face3D = frame.Get3DShape();
                    //EnumIndexableCollection<FeaturePoint, PointF> face2D = frame.GetProjected3DShape();
                    
                    /*
                    if (sendData[skeletonIndex])
                    {
                        SkeletonProcessing.TrackSkeleton(skeletonOfInterest, frame, skeletonIndex);
                        sendData[skeletonIndex] = false;
                    }
                    */

                    this.lastFaceTrackSucceeded = frame.TrackSuccessful;
                    if (this.lastFaceTrackSucceeded)
                    {
                        if (faceTriangles == null)
                        {
                            // only need to get this once.  It doesn't change.
                            faceTriangles = frame.GetTriangles();
                        }

                        this.facePoints = frame.GetProjected3DShape();
                        this.faceTriangles_ = faceTriangles;
                    }
                }
            }

            private void printFaceVectors(FaceTrackFrame frame)
            {
                string s = " *** ,";
                int i = 0;
                EnumIndexableCollection<FeaturePoint, Vector3DF> facePoints3D = frame.Get3DShape(); // get 3D face vectors
                foreach (Vector3DF vector in facePoints3D)
                {
                    s += "Vector" + i + "," + vector.X + "," + vector.Y + "," + vector.Z + ",";

                    i++;
                }
                Console.WriteLine(s);
            }

            public static bool[] sendData = { true, true, true, true, true, true };

            private struct FaceModelTriangle
            {
                public Point P1;
                public Point P2;
                public Point P3;
            }

            static int tInc = 0;
            static System.Timers.Timer _timer; // From System.Timers

            public static void timer_5()
            {
                _timer = new System.Timers.Timer(1000); // Set up the timer for 3 seconds
                _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
                _timer.Enabled = true; // Enable it
            }

            public static void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                if (tInc == 5)
                {
                    tInc = 5;
                }
                else
                {
                    tInc++;
                }
                Console.WriteLine(tInc);
                // _l.Add(DateTime.Now); // Add date on each timer event
            }

        }
    }
}