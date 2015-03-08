using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceTrackingBasics.Models
{
    class JsonModel
    {
        public string JsonString = "";

        public JsonModel(string[] skeletons)
        {
            bool firstSkeleton = true;

            JsonString += "{";
            for (int i = 0; i < skeletons.Length; i++)
            {
                if (skeletons[i].Length > 0) // if there is json for that skeleton
                {
                    if (!firstSkeleton) // if it is not the first skeleton
                    {
                        JsonString += ","; // put a comma before
                    }

                    JsonString += skeletons[i]; // at the skelton json to the string
                    firstSkeleton = false;
                }
            }
            JsonString += "}";
        }
    }
}
