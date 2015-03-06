using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceTrackingBasics
{
    class SkeletonProcessing
    {
        private bool tracked0 = false;
        private bool tracked1 = false;
        private bool tracked2 = false;
        private bool tracked3 = false;
        private bool tracked4 = false;
        private bool tracked5 = false;


        public bool SkeletonTracked(int i, bool b)
        {
            switch (i)
            {
                case 0:
                    tracked0 = b;
                    return true;
                case 1:
                    tracked1 = b;
                    return true;
                case 2:
                    tracked2 = b;
                    return true;
                case 3:
                    tracked3 = b;
                    return true;
                case 4:
                    tracked4 = b;
                    return true;
                case 5:
                    tracked5 = b;
                    return true;
                default:
                    Console.WriteLine(String.Format("Error: SkeletonTracked({0}, {1})", i, b));
                    return false;
            }
        }
    }
}
