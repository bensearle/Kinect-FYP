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


            // draw rectangle on the video stream
            drawingContext.DrawRectangle(null, new Pen(Brushes.Blue, 10), new System.Windows.Rect(new Point(250, 0), new Point(400, 200)));

        }

        private void OnAllFramesReady(object sender, AllFramesReadyEventArgs allFramesReadyEventArgs)
        {
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
                            this.trackedSkeletons.Add(skeleton.TrackingId, new SkeletonFaceTracker());
                        }

                        // Give each tracker the upated frame.
                        SkeletonFaceTracker skeletonFaceTracker;
                        if (this.trackedSkeletons.TryGetValue(skeleton.TrackingId, out skeletonFaceTracker))
                        {
                            skeletonFaceTracker.OnFrameReady(this.Kinect, colorImageFormat, colorImage, depthImageFormat, depthImage, skeleton);
                            skeletonFaceTracker.LastTrackedFrame = skeletonFrame.FrameNumber;
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

        private class SkeletonFaceTracker : IDisposable
        {
            private static FaceTriangle[] faceTriangles;

            private EnumIndexableCollection<FeaturePoint, PointF> facePoints;

            private FaceTracker faceTracker;

            private FaceTriangle[] faceTriangles_;

            private bool lastFaceTrackSucceeded;

            private SkeletonTrackingState skeletonTrackingState;

            public int LastTrackedFrame { get; set; }

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

                FaceVector[] vectors_on_screen = new FaceVector[121]; // the 2 points on screen that each vector is between

                foreach (var t in faceTriangles)
                {
                    var triangle = new FaceModelTriangle();
                    triangle.P1 = faceModelPts[t.First];
                    triangle.P2 = faceModelPts[t.Second];
                    triangle.P3 = faceModelPts[t.Third];
                    faceModel.Add(triangle);
                    // add points and numbers to the list
                    list_number_coords.Add(Tuple.Create(triangle.P1, t.First));
                    list_number_coords.Add(Tuple.Create(triangle.P2, t.Second));
                    list_number_coords.Add(Tuple.Create(triangle.P3, t.Third));

                    vectors_on_screen[t.First].P1 = triangle.P1;
                    vectors_on_screen[t.First].P2 = triangle.P1;

                    vectors_on_screen[t.Second].P1 = triangle.P1;
                    vectors_on_screen[t.Second].P2 = triangle.P1;

                    vectors_on_screen[t.Third].P1 = triangle.P1;
                    vectors_on_screen[t.Third].P2 = triangle.P1;

                    /*// add text of first number
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
                        triangle.P3);*/
                }

                var faceModelGroup = new GeometryGroup();
                for (int i = 0; i < faceModel.Count; i++)
                {
                    var faceTriangle = new GeometryGroup();
                    faceTriangle.Children.Add(new LineGeometry(faceModel[i].P1, faceModel[i].P2));
                    faceTriangle.Children.Add(new LineGeometry(faceModel[i].P2, faceModel[i].P3));
                    faceTriangle.Children.Add(new LineGeometry(faceModel[i].P3, faceModel[i].P1));
                    faceModelGroup.Children.Add(faceTriangle);
                }

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


                drawingContext.DrawGeometry(Brushes.LightYellow, new Pen(Brushes.LightYellow, 1.0), faceModelGroup);
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
                //drawingContext.DrawRectangle(Brushes.Blue, new Pen(Brushes.Blue, 10), new System.Windows.Rect(new Point(200, 50), new Point(300, 200)));

            }

            /// <summary>
            /// Updates the face tracking information for this skeleton
            /// </summary>
            internal void OnFrameReady(KinectSensor kinectSensor, ColorImageFormat colorImageFormat, byte[] colorImage, DepthImageFormat depthImageFormat, short[] depthImage, Skeleton skeletonOfInterest)
            {
                this.skeletonTrackingState = skeletonOfInterest.TrackingState;

                if (this.skeletonTrackingState != SkeletonTrackingState.Tracked)
                {
                    // nothing to do with an untracked skeleton.
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
                        getXYZ(frame);
                    }
                }
            }

            private struct FaceModelTriangle
            {
                public Point P1;
                public Point P2;
                public Point P3;
            }

            private struct FaceVector
            {
                public Point P1;
                public Point P2;
            }


            /*public struct XYZCoord
            {
                public float X;
                public float Y;
                public float Z;
            }*/

            public XYZCoord[] face_coords;

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

            bool facial_regonition_sent = false;
            public void getXYZ(FaceTrackFrame frame)
            {
                //XYZCoord[] face_coords; // create array for face coordinates
                face_coords = new XYZCoord[121]; // initialize array to size 121

                EnumIndexableCollection<FeaturePoint, Vector3DF> facePoints3D = frame.Get3DShape();
                EnumIndexableCollection<FeaturePoint, PointF> facePoints = frame.GetProjected3DShape();
                Vector3DF rotation = frame.Rotation;
                Vector3DF translation = frame.Translation;
                

                /*Debug.WriteLine(
                    "**," + rotation.X +
                    "," + rotation.Y +
                    "," + rotation.Z );
                Debug.WriteLine(
                    "***********," + translation.X +
                    "," + translation.Y +
                    "," + translation.Z);
                */
                string s = "";

                double[] vector_magnitudes = new double[121];

                int index = 0;
                foreach (Vector3DF vector in facePoints3D)
                {
                    face_coords[index] = new XYZCoord(vector);
                    vector_magnitudes[index] = Maths.magnitude(face_coords[index]);
                    //face_coords[index].X = vector.X;
                    //face_coords[index].Y = vector.Y;
                    //face_coords[index].Z = vector.Z;
                    //Debug.WriteLine(string.Format("{0}, {1}, {2}, {3}", index, vector.X, vector.Y, vector.Z));

                    // s = (x,y)(x,y) for entering in to coord plotter (testing)
                    s = s + "(" + vector.X + "," + vector.Y + ")";

                    index++;
                }

                //Debug.WriteLine(Maths.rotate_vector(new XYZCoord(2,2,2), new Vector3DF(0,0,1)));
                //Debug.WriteLine(Maths.rotate_vector(new XYZCoord(2, 2, 2), new Vector3DF(0, 0, 10)));

                //Debug.WriteLine(face_coords[0] + " ** " + rotation.X+"," + rotation.Y+"," + rotation.Z + " ** " + Maths.rotate_vector(face_coords[0], rotation));
                //Debug.WriteLine(Maths.rotate_vector(face_coords[0], rotation));
                
                // angle between vec0 and vec1
                double anglebetween = Vector3D.AngleBetween(
                    new Vector3D(face_coords[0].X, face_coords[0].Y, face_coords[0].Z),
                    new Vector3D(face_coords[1].X, face_coords[1].Y, face_coords[1].Z));
                
                // angle between vec0 and vec1, after they have been rotated
                XYZCoord vec0 = Maths.rotate_vector(face_coords[0], rotation);
                XYZCoord vec1 = Maths.rotate_vector(face_coords[1], rotation);
                double anglebetweenrot = Vector3D.AngleBetween(
                    new Vector3D(vec0.X, vec0.Y, vec0.Z),
                    new Vector3D(vec1.X, vec1.Y, vec1.Z));


                Debug.WriteLine("*** " + anglebetween + " :: " + anglebetweenrot);

                double scaleX = 1 / face_coords[0].X;
                double scaleY = 1 / face_coords[0].Y;
                double scaleZ = 1 / face_coords[0].Z;

                /*Debug.WriteLine(
                    "**	" + vector_magnitudes[0] / vector_magnitudes[1] +
                    "	" + vector_magnitudes[1] / vector_magnitudes[0] +
                    "	" + vector_magnitudes[5] / vector_magnitudes[10]);
                */
                if (face_coords[0].X > 0)
                {
                    // if clause to get test data
                }
                if (!facial_regonition_sent)
                {
                    // frame.FaceRect.Bottom > bottom of rectangle
                    //FacialRecognition.recognise(face_coords);
                    facial_regonition_sent = true;
                }
                //this.face_coords = face_coords;
            }
        }
    }
}