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

            face.name = "benny_searle";
            face.nose_angle_1 = (decimal)Maths.angle_from_coords(coords[92], coords[94], coords[93]); // nose_angle
            get_match(face);
            //add_to_db(face);
            Console.WriteLine(face.nose_angle_1);
        }

        private static void get_match(Face face)
        {
            using (var db = new Database.Database())
            {
                double target_match = (double)face.nose_angle_1;
                double match = Double.MaxValue; // the closest match
                string name = ""; // name of the closest match

                // Display all Blogs from the database
                var query = from b in db.Faces
                            orderby b.name
                            select b;

                Console.WriteLine("Search database...");
                Console.WriteLine("checked " + "beneth searle");

                foreach (var found_face in query)
                {
                    if (found_face.name == "ben_searle") {
                        Console.WriteLine();
                    }
                    Console.WriteLine("checked " + found_face.name);
                    if (found_face.nose_angle_1 != null)
                    {
                        double diff = Math.Sqrt(Math.Pow(((double)found_face.nose_angle_1 - (double)face.nose_angle_1), 2));
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
