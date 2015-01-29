using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FaceTrackingBasics.Models;
using FaceTrackingBasics.Database;

namespace FaceTrackingBasics
{
    class FacialRecognition
    {
        public static void recognise(XYZCoord[] coords)
        {
            Face face = new Face();

            // write all of the coordinates
            /*for (int i = 0; i < coords.Length; i++)
            {
                string s = coords[i].ToString();
                Console.WriteLine("Point " + i + ": " + s);
            }*/

            face.name = "Tests";
            // nose angle
            face.angle_1 = (decimal)Maths.angle_from_coords(coords[92], coords[94], coords[93]);
            // angle at the top of the head
            face.angle_2 = (decimal)Maths.angle_from_coords(coords[1], coords[0], coords[34]);
            // triangle above eyebrow
            face.angle_3 = (decimal)Maths.angle_from_coords(coords[13], coords[2], coords[1]);
            face.angle_4 = 0;
            face.angle_5 = 0;
            face.angle_6 = 0;
            face.angle_7 = 0;
            face.angle_8 = 0;
            face.angle_9 = 0;
            face.angle_10 = 0;
            // ratio of lengths (width of forehead) (mid forehead to top of head)
            face.length_1 = (decimal)Maths.ratio(coords[13], coords[46], coords[2], coords[0]);
            // ratio of lengths (width of forehead) (right of right eye to left of left eye)
            face.length_2 = (decimal)Maths.ratio(coords[13], coords[46], coords[20], coords[53]);
            // ratio of lengths (height of nose) (width of nose)
            face.length_3 = (decimal)Maths.ratio(coords[5], coords[77], coords[26], coords[59]);
            face.length_4 = 0;
            face.length_5 = 0;
            face.length_6 = 0;
            face.length_7 = 0;
            face.length_8 = 0;
            face.length_9 = 0;
            face.length_10 = 0;
            // face code is created by multiplying all values

            face.face_code = face.angle_1 * face.angle_2 * face.angle_3 *
                            face.length_1 * face.length_2 * face.length_3;
            /*face.face_code = face.angle_1 * face.angle_2 * face.angle_3 * face.angle_4 * face.angle_5 *
                            face.angle_6 * face.angle_7 * face.angle_8 * face.angle_9 * face.angle_10 *
                            face.length_1 * face.length_2 * face.length_3 * face.length_4 * face.length_5 *
                            face.length_6 * face.length_7 * face.length_8 * face.length_9 * face.length_10;*/
            
            //add_to_db(face); // add the face to the database
            get_match(face); // get the nearest match of the face

        }

        private static void add_to_db(Face face)
        {
            using (var db = new Database.Database())
            {
                db.Faces.Add(face); // add the face to the database
                db.SaveChanges(); // update the database
            }
        }

        private static void get_match(Face face)
        {
            using (var db = new Database.Database())
            {
                double target_match = (double)face.face_code;
                double match = Double.MaxValue; // the closest match
                string name = ""; // name of the closest match

                // Display all Blogs from the database
                var query = from b in db.Faces
                            orderby b.name
                            select b;

                Console.WriteLine("Searching database...");

                foreach (var found_face in query)
                {
                    Console.WriteLine("checked " + found_face.name);
                    if (found_face.face_code != null)
                    {
                        // difference between face and found face
                        double diff = Math.Sqrt(Math.Pow(((double)found_face.face_code - (double)face.face_code), 2));
                        if (diff < match) // if this found face is a closer match
                        {
                            match = diff; // set the difference
                            name = found_face.name; // set the name
                        }
                    }
                }
                Console.WriteLine("closest match: " + name); // write the name of the closest match
            }
        }
    }
}
