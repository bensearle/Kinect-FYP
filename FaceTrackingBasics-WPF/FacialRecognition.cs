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

            for (int i = 0; i < coords.Length; i++)
            {
                string s = coords[i].ToString();
                Console.WriteLine("*!*!*!*!*!*!*!*!*!* " + i + "   " + s);
            }

            face.name = "Ben";
            // nose angle
            face.angle_1 = (decimal)Maths.angle_from_coords(coords[92], coords[94], coords[93]);
            face.angle_2 = 0;
            face.angle_3 = 0;
            face.angle_4 = 0;
            face.angle_5 = 0;
            face.angle_6 = 0;
            face.angle_7 = 0;
            face.angle_8 = 0;
            face.angle_9 = 0;
            face.angle_10 = 0;
            face.length_1 = 0;
            face.length_2 = 0;
            face.length_3 = 0;
            face.length_4 = 0;
            face.length_5 = 0;
            face.length_6 = 0;
            face.length_7 = 0;
            face.length_8 = 0;
            face.length_9 = 0;
            face.length_10 = 0;
            face.face_code = face.angle_1 * face.angle_2 * face.angle_3 * face.angle_4 * face.angle_5 *
                            face.angle_6 * face.angle_7 * face.angle_8 * face.angle_9 * face.angle_10 *
                            face.length_1 * face.length_2 * face.length_3 * face.length_4 * face.length_5 *
                            face.length_6 * face.length_7 * face.length_8 * face.length_9 * face.length_10;
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
                    if (found_face.nose_angle_1 != null)
                    {
                        double diff = Math.Sqrt(Math.Pow(((double)found_face.face_code - (double)face.face_code), 2));
                        if (diff < match)
                        {
                            match = diff;
                            name = found_face.name;

                        }
                    }
                }
                Console.WriteLine("closest match: " + "beneth searle");
            }
        }

        private static void add_to_db(Face face)
        {
            using (var db = new Database.Database())
            {
                db.Faces.Add(face);
                db.SaveChanges();
            }
        }

    }
}
