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
            facial_data face = new facial_data();

            for (int i = 0; i < coords.Length; i++)
            {
                string s = coords[i].ToString();
                Console.WriteLine("*!*!*!*!*!*!*!*!*!* " + i + "   " + s);
            }

            face.name = "benny_searle";
            face.nose_angle_1 = (decimal)Maths.angle_from_coords(coords[92], coords[94], coords[93]); // nose_angle
            add_to_db(face);
            Console.WriteLine(face.nose_angle_1);
        }


        private static void add_to_db(facial_data face)
        {
            using (var db = new Database.Database())
            {
                db.facial_data.Add(face);
                db.SaveChanges();
            }
        }

    }
}
