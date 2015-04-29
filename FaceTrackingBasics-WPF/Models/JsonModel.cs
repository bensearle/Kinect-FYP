using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectTrackerAndBroadcaster.Models
{
    class JsonModel
    {
        public string JsonString = ""; // json string for all skeletons

        /// <summary>
        /// create json string for all skeleton from array of json strings for each skeleton
        /// </summary>
        /// <param name="skeletons">array of all skeleton json strings</param>
        public JsonModel(string[] skeletons)
        {
            bool firstSkeleton = true; // bool to know whether it is the first skeleton

            JsonString += "{"; // start json string
            for (int i = 0; i < skeletons.Length; i++) // iterate skeleton array
            {
                if (skeletons[i].Length > 0) // if there is json for that skeleton
                {
                    if (!firstSkeleton) // if it is not the first skeleton
                    {
                        JsonString += ","; // put a comma before
                    }

                    JsonString += skeletons[i]; // add the skelton json to the string
                    firstSkeleton = false; // no longer the first skeleton
                }
            }
            JsonString += "}"; // end of json string
        }
    }
}
