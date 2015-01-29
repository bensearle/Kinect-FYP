// -----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace FaceTrackingBasics
{
    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Microsoft.Kinect;
    using Microsoft.Kinect.Toolkit;
    using System.Diagnostics;
    using FaceTrackingBasics.Database; // classes in the database folder
    using System.Linq;
    using FaceTrackingBasics.Models;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly int Bgr32BytesPerPixel = (PixelFormats.Bgr32.BitsPerPixel + 7) / 8;
        private readonly KinectSensorChooser sensorChooser = new KinectSensorChooser();
        private WriteableBitmap colorImageWritableBitmap;
        private byte[] colorImageData;
        private ColorImageFormat currentColorImageFormat = ColorImageFormat.Undefined;

        public MainWindow()
        {
            // testing
            //testDB();
            
//            FaceTrackingBasics.FaceTrackingViewer.timer_5();
            //testAngle();
            Console.WriteLine("************");
            /*Console.WriteLine(JointType.Head.ToString());
            Dictionaries d = new Dictionaries();
            JointType j = d.Joints[0];
            Console.WriteLine(JointType.Head);
            Console.WriteLine(j);

            XYZCoord joint_coords = new XYZCoord();
            joint_coords.X = skeleton.Joints[joint_dictionary[i]].Position.X;*/


            InitializeComponent();

            var faceTrackingViewerBinding = new Binding("Kinect") { Source = sensorChooser };
            faceTrackingViewer.SetBinding(FaceTrackingViewer.KinectProperty, faceTrackingViewerBinding);

            sensorChooser.KinectChanged += SensorChooserOnKinectChanged;

            sensorChooser.Start();
        }



        static int tInc = 0;
        static System.Timers.Timer _timer; // From System.Timers

        static void timer_5()
        {
            _timer = new System.Timers.Timer(1000); // Set up the timer for 3 seconds
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
            _timer.Enabled = true; // Enable it
        }
        static void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            tInc++;
            Console.WriteLine(tInc);
            // _l.Add(DateTime.Now); // Add date on each timer event
        }

        public void testAngle()
        {
            Vector_ v1 = new Vector_(0, 4);
            Vector_ v2 = new Vector_(4, 0);
            Vector_ v3 = new Vector_(4, 4);
            Vector_ v4 = new Vector_(4, 4);

            Console.WriteLine("************");
            Console.WriteLine(angle(v1, v2));
            Console.WriteLine(angle(v1, v4));
            Console.WriteLine(angle(v4, v1));
            Console.WriteLine(angle(v4, v2));
            Console.WriteLine(angle(v4, v4));

        }

        public double angle(Vector_ v1, Vector_ v2)
        {
            double v1_magnitude;
            double v2_magnitude;
            Vector_ v1_normalized;
            Vector_ v2_normalized;
            double dot_product;
            double angle_radians;
            double angle_degrees;

            // get the magnitude of each vector
            v1_magnitude = Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z);
            v2_magnitude = Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);

            // normalize the vectors
            v1_normalized = new Vector_(v1.X / v1_magnitude, v1.Y / v1_magnitude, v1.Z / v1_magnitude);
            v2_normalized = new Vector_(v2.X / v2_magnitude, v2.Y / v2_magnitude, v2.Z / v2_magnitude);

            // calculate the dot product
            dot_product = v1_normalized.X * v2_normalized.X + v1_normalized.Y * v2_normalized.Y + v1_normalized.Z * v2_normalized.Z;

            // calculate the angle
            angle_radians = Math.Acos(dot_product);

            // convert angle to degrees
            angle_degrees = angle_radians * (180.0 / Math.PI);

            return angle_degrees;
        }

        private void testDB()
        {
            Debug.WriteLine("ben***");
            using (var db = new Database.Database())
            {
                // Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");

                var entry = new facial_data { Id = 6, name = "benny_7" };
                db.facial_data.Add(entry);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.facial_data
                            orderby b.name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.name);
                }
            }
        }

        private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs kinectChangedEventArgs)
        {
            KinectSensor oldSensor = kinectChangedEventArgs.OldSensor;
            KinectSensor newSensor = kinectChangedEventArgs.NewSensor;

            if (oldSensor != null)
            {
                oldSensor.AllFramesReady -= KinectSensorOnAllFramesReady;
                oldSensor.ColorStream.Disable();
                oldSensor.DepthStream.Disable();
                oldSensor.DepthStream.Range = DepthRange.Default;
                oldSensor.SkeletonStream.Disable();
                oldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                oldSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Default;
            }

            if (newSensor != null)
            {
                try
                {
                    newSensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                    newSensor.DepthStream.Enable(DepthImageFormat.Resolution320x240Fps30);
                    try
                    {
                        // This will throw on non Kinect For Windows devices.
                        newSensor.DepthStream.Range = DepthRange.Near;
                        newSensor.SkeletonStream.EnableTrackingInNearRange = true;
                    }
                    catch (InvalidOperationException)
                    {
                        newSensor.DepthStream.Range = DepthRange.Default;
                        newSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    }

                    newSensor.SkeletonStream.TrackingMode = SkeletonTrackingMode.Seated;
                    newSensor.SkeletonStream.Enable();
                    newSensor.AllFramesReady += KinectSensorOnAllFramesReady;
                }
                catch (InvalidOperationException)
                {
                    // This exception can be thrown when we are trying to
                    // enable streams on a device that has gone away.  This
                    // can occur, say, in app shutdown scenarios when the sensor
                    // goes away between the time it changed status and the
                    // time we get the sensor changed notification.
                    //
                    // Behavior here is to just eat the exception and assume
                    // another notification will come along if a sensor
                    // comes back.
                }
            }
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            sensorChooser.Stop();
            faceTrackingViewer.Dispose();
        }

        private void KinectSensorOnAllFramesReady(object sender, AllFramesReadyEventArgs allFramesReadyEventArgs)
        {
            using (var colorImageFrame = allFramesReadyEventArgs.OpenColorImageFrame())
            {
                if (colorImageFrame == null)
                {
                    return;
                }

                // Make a copy of the color frame for displaying.
                var haveNewFormat = this.currentColorImageFormat != colorImageFrame.Format;
                if (haveNewFormat)
                {
                    this.currentColorImageFormat = colorImageFrame.Format;
                    this.colorImageData = new byte[colorImageFrame.PixelDataLength];
                    this.colorImageWritableBitmap = new WriteableBitmap(
                        colorImageFrame.Width, colorImageFrame.Height, 96, 96, PixelFormats.Bgr32, null);
                    ColorImage.Source = this.colorImageWritableBitmap;
                }

                colorImageFrame.CopyPixelDataTo(this.colorImageData);
                this.colorImageWritableBitmap.WritePixels(
                    new Int32Rect(0, 0, colorImageFrame.Width, colorImageFrame.Height),
                    this.colorImageData,
                    colorImageFrame.Width * Bgr32BytesPerPixel,
                    0);
            }
        }
    }
}
