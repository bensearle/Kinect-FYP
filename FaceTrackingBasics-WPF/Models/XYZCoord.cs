﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceTrackingBasics.Models
{
    class XYZCoord
    {

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public XYZCoord()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public XYZCoord(float x)
        {
            X = x;
            Y = 0;
            Z = 0;
        }

        public XYZCoord(float x, float y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        public XYZCoord(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

    }
}