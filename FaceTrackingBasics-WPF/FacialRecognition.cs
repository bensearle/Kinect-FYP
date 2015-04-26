using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FaceTrackingBasics.Models;
using FaceTrackingBasics.Database;
using System.Windows.Media.Media3D;
using Microsoft.Kinect.Toolkit.FaceTracking;

namespace FaceTrackingBasics
{
    class FacialRecognition
    {
        /// <summary>
        /// Method called to search the database for the nearest facial match.
        /// </summary>
        /// <param name="frame">the face tracking frame</param>
        /// <returns>the name of the recognised person</returns>
        public String Process(EnumIndexableCollection<FeaturePoint, Vector3DF> facePoints3D)
        {
            return process_face(facePoints3D, "");
        }

        /// <summary>
        /// Method called to add the face and name to the database.
        /// </summary>
        /// <param name="frame">the face track frame</param>
        /// <param name="name">the name of the person whose face this is</param>
        /// <returns>the name of the person</returns>
        public String Process(EnumIndexableCollection<FeaturePoint, Vector3DF> facePoints3D, String name)
        {
            return process_face(facePoints3D, name);
        }

        /// <summary>
        /// Method used to process the face track frame.
        /// </summary>
        /// <param name="frame">the face track frame</param>
        /// <param name="name">name of the person or blank</param>
        /// <returns></returns>
        private String process_face(EnumIndexableCollection<FeaturePoint, Vector3DF> facePoints3D, String name)
        {
            // EnumIndexableCollection<FeaturePoint, Vector3DF> facePoints3D = frame.Get3DShape(); // get 3D face vectors
            Unit3D[] face_vectors = new Unit3D[121]; // create Unit3D array for the face vectors

            int index = 0;
            foreach (Vector3DF vector in facePoints3D)
            {
                Unit3D face_vector = new Unit3D(vector); // convert Vector3DF to Unit3D
                face_vectors[index] = face_vector; // add face vector to array
                index++;
            }

            Face face = get_face(face_vectors); // returns a face without a name

            if (name == "")
            {
                // face is to be recognised
                return get_match(face); // get the nearest match of the face
            }
            else
            {
                // face is to be added to the database
                face.name = name; // set the face name
                add_to_db(face); // add the face to the database
                return name;
            }
        }

        /// <summary>
        /// Method used to calculate all of the face details, other than the name.
        /// </summary>
        /// <param name="face_vectors">array of Unit3D face vectors</param>
        /// <returns>the face details, but not the name</returns>
        private static Face get_face(Unit3D[] face_vectors)
        {
            Face face = new Face();

            face.angle_0_1 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[0].X, face_vectors[0].Y, face_vectors[0].Z), new Vector3D(face_vectors[1].X, face_vectors[1].Y, face_vectors[1].Z));
            face.angle_1_2 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[1].X, face_vectors[1].Y, face_vectors[1].Z), new Vector3D(face_vectors[2].X, face_vectors[2].Y, face_vectors[2].Z));
            face.angle_2_3 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[2].X, face_vectors[2].Y, face_vectors[2].Z), new Vector3D(face_vectors[3].X, face_vectors[3].Y, face_vectors[3].Z));
            face.angle_3_4 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[3].X, face_vectors[3].Y, face_vectors[3].Z), new Vector3D(face_vectors[4].X, face_vectors[4].Y, face_vectors[4].Z));
            face.angle_4_5 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[4].X, face_vectors[4].Y, face_vectors[4].Z), new Vector3D(face_vectors[5].X, face_vectors[5].Y, face_vectors[5].Z));
            face.angle_5_6 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[5].X, face_vectors[5].Y, face_vectors[5].Z), new Vector3D(face_vectors[6].X, face_vectors[6].Y, face_vectors[6].Z));
            face.angle_6_7 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[6].X, face_vectors[6].Y, face_vectors[6].Z), new Vector3D(face_vectors[7].X, face_vectors[7].Y, face_vectors[7].Z));
            face.angle_7_8 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[7].X, face_vectors[7].Y, face_vectors[7].Z), new Vector3D(face_vectors[8].X, face_vectors[8].Y, face_vectors[8].Z));
            face.angle_8_9 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[8].X, face_vectors[8].Y, face_vectors[8].Z), new Vector3D(face_vectors[9].X, face_vectors[9].Y, face_vectors[9].Z));
            face.angle_9_10 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[9].X, face_vectors[9].Y, face_vectors[9].Z), new Vector3D(face_vectors[10].X, face_vectors[10].Y, face_vectors[10].Z));
            face.angle_10_11 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[10].X, face_vectors[10].Y, face_vectors[10].Z), new Vector3D(face_vectors[11].X, face_vectors[11].Y, face_vectors[11].Z));
            face.angle_11_12 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[11].X, face_vectors[11].Y, face_vectors[11].Z), new Vector3D(face_vectors[12].X, face_vectors[12].Y, face_vectors[12].Z));
            face.angle_12_13 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[12].X, face_vectors[12].Y, face_vectors[12].Z), new Vector3D(face_vectors[13].X, face_vectors[13].Y, face_vectors[13].Z));
            face.angle_13_14 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[13].X, face_vectors[13].Y, face_vectors[13].Z), new Vector3D(face_vectors[14].X, face_vectors[14].Y, face_vectors[14].Z));
            face.angle_14_15 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[14].X, face_vectors[14].Y, face_vectors[14].Z), new Vector3D(face_vectors[15].X, face_vectors[15].Y, face_vectors[15].Z));
            face.angle_15_16 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[15].X, face_vectors[15].Y, face_vectors[15].Z), new Vector3D(face_vectors[16].X, face_vectors[16].Y, face_vectors[16].Z));
            face.angle_16_17 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[16].X, face_vectors[16].Y, face_vectors[16].Z), new Vector3D(face_vectors[17].X, face_vectors[17].Y, face_vectors[17].Z));
            face.angle_17_18 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[17].X, face_vectors[17].Y, face_vectors[17].Z), new Vector3D(face_vectors[18].X, face_vectors[18].Y, face_vectors[18].Z));
            face.angle_18_19 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[18].X, face_vectors[18].Y, face_vectors[18].Z), new Vector3D(face_vectors[19].X, face_vectors[19].Y, face_vectors[19].Z));
            face.angle_19_20 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[19].X, face_vectors[19].Y, face_vectors[19].Z), new Vector3D(face_vectors[20].X, face_vectors[20].Y, face_vectors[20].Z));
            face.angle_20_21 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[20].X, face_vectors[20].Y, face_vectors[20].Z), new Vector3D(face_vectors[21].X, face_vectors[21].Y, face_vectors[21].Z));
            face.angle_21_22 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[21].X, face_vectors[21].Y, face_vectors[21].Z), new Vector3D(face_vectors[22].X, face_vectors[22].Y, face_vectors[22].Z));
            face.angle_22_23 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[22].X, face_vectors[22].Y, face_vectors[22].Z), new Vector3D(face_vectors[23].X, face_vectors[23].Y, face_vectors[23].Z));
            face.angle_23_24 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[23].X, face_vectors[23].Y, face_vectors[23].Z), new Vector3D(face_vectors[24].X, face_vectors[24].Y, face_vectors[24].Z));
            face.angle_24_25 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[24].X, face_vectors[24].Y, face_vectors[24].Z), new Vector3D(face_vectors[25].X, face_vectors[25].Y, face_vectors[25].Z));
            face.angle_25_26 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[25].X, face_vectors[25].Y, face_vectors[25].Z), new Vector3D(face_vectors[26].X, face_vectors[26].Y, face_vectors[26].Z));
            face.angle_26_27 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[26].X, face_vectors[26].Y, face_vectors[26].Z), new Vector3D(face_vectors[27].X, face_vectors[27].Y, face_vectors[27].Z));
            face.angle_27_28 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[27].X, face_vectors[27].Y, face_vectors[27].Z), new Vector3D(face_vectors[28].X, face_vectors[28].Y, face_vectors[28].Z));
            face.angle_28_29 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[28].X, face_vectors[28].Y, face_vectors[28].Z), new Vector3D(face_vectors[29].X, face_vectors[29].Y, face_vectors[29].Z));
            face.angle_29_30 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[29].X, face_vectors[29].Y, face_vectors[29].Z), new Vector3D(face_vectors[30].X, face_vectors[30].Y, face_vectors[30].Z));
            face.angle_30_31 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[30].X, face_vectors[30].Y, face_vectors[30].Z), new Vector3D(face_vectors[31].X, face_vectors[31].Y, face_vectors[31].Z));
            face.angle_31_32 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[31].X, face_vectors[31].Y, face_vectors[31].Z), new Vector3D(face_vectors[32].X, face_vectors[32].Y, face_vectors[32].Z));
            face.angle_32_33 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[32].X, face_vectors[32].Y, face_vectors[32].Z), new Vector3D(face_vectors[33].X, face_vectors[33].Y, face_vectors[33].Z));
            face.angle_33_34 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[33].X, face_vectors[33].Y, face_vectors[33].Z), new Vector3D(face_vectors[34].X, face_vectors[34].Y, face_vectors[34].Z));
            face.angle_34_35 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[34].X, face_vectors[34].Y, face_vectors[34].Z), new Vector3D(face_vectors[35].X, face_vectors[35].Y, face_vectors[35].Z));
            face.angle_35_36 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[35].X, face_vectors[35].Y, face_vectors[35].Z), new Vector3D(face_vectors[36].X, face_vectors[36].Y, face_vectors[36].Z));
            face.angle_36_37 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[36].X, face_vectors[36].Y, face_vectors[36].Z), new Vector3D(face_vectors[37].X, face_vectors[37].Y, face_vectors[37].Z));
            face.angle_37_38 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[37].X, face_vectors[37].Y, face_vectors[37].Z), new Vector3D(face_vectors[38].X, face_vectors[38].Y, face_vectors[38].Z));
            face.angle_38_39 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[38].X, face_vectors[38].Y, face_vectors[38].Z), new Vector3D(face_vectors[39].X, face_vectors[39].Y, face_vectors[39].Z));
            face.angle_39_40 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[39].X, face_vectors[39].Y, face_vectors[39].Z), new Vector3D(face_vectors[40].X, face_vectors[40].Y, face_vectors[40].Z));
            face.angle_40_41 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[40].X, face_vectors[40].Y, face_vectors[40].Z), new Vector3D(face_vectors[41].X, face_vectors[41].Y, face_vectors[41].Z));
            face.angle_41_42 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[41].X, face_vectors[41].Y, face_vectors[41].Z), new Vector3D(face_vectors[42].X, face_vectors[42].Y, face_vectors[42].Z));
            face.angle_42_43 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[42].X, face_vectors[42].Y, face_vectors[42].Z), new Vector3D(face_vectors[43].X, face_vectors[43].Y, face_vectors[43].Z));
            face.angle_43_44 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[43].X, face_vectors[43].Y, face_vectors[43].Z), new Vector3D(face_vectors[44].X, face_vectors[44].Y, face_vectors[44].Z));
            face.angle_44_45 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[44].X, face_vectors[44].Y, face_vectors[44].Z), new Vector3D(face_vectors[45].X, face_vectors[45].Y, face_vectors[45].Z));
            face.angle_45_46 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[45].X, face_vectors[45].Y, face_vectors[45].Z), new Vector3D(face_vectors[46].X, face_vectors[46].Y, face_vectors[46].Z));
            face.angle_46_47 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[46].X, face_vectors[46].Y, face_vectors[46].Z), new Vector3D(face_vectors[47].X, face_vectors[47].Y, face_vectors[47].Z));
            face.angle_47_48 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[47].X, face_vectors[47].Y, face_vectors[47].Z), new Vector3D(face_vectors[48].X, face_vectors[48].Y, face_vectors[48].Z));
            face.angle_48_49 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[48].X, face_vectors[48].Y, face_vectors[48].Z), new Vector3D(face_vectors[49].X, face_vectors[49].Y, face_vectors[49].Z));
            face.angle_49_50 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[49].X, face_vectors[49].Y, face_vectors[49].Z), new Vector3D(face_vectors[50].X, face_vectors[50].Y, face_vectors[50].Z));
            face.angle_50_51 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[50].X, face_vectors[50].Y, face_vectors[50].Z), new Vector3D(face_vectors[51].X, face_vectors[51].Y, face_vectors[51].Z));
            face.angle_51_52 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[51].X, face_vectors[51].Y, face_vectors[51].Z), new Vector3D(face_vectors[52].X, face_vectors[52].Y, face_vectors[52].Z));
            face.angle_52_53 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[52].X, face_vectors[52].Y, face_vectors[52].Z), new Vector3D(face_vectors[53].X, face_vectors[53].Y, face_vectors[53].Z));
            face.angle_53_54 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[53].X, face_vectors[53].Y, face_vectors[53].Z), new Vector3D(face_vectors[54].X, face_vectors[54].Y, face_vectors[54].Z));
            face.angle_54_55 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[54].X, face_vectors[54].Y, face_vectors[54].Z), new Vector3D(face_vectors[55].X, face_vectors[55].Y, face_vectors[55].Z));
            face.angle_55_56 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[55].X, face_vectors[55].Y, face_vectors[55].Z), new Vector3D(face_vectors[56].X, face_vectors[56].Y, face_vectors[56].Z));
            face.angle_56_57 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[56].X, face_vectors[56].Y, face_vectors[56].Z), new Vector3D(face_vectors[57].X, face_vectors[57].Y, face_vectors[57].Z));
            face.angle_57_58 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[57].X, face_vectors[57].Y, face_vectors[57].Z), new Vector3D(face_vectors[58].X, face_vectors[58].Y, face_vectors[58].Z));
            face.angle_58_59 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[58].X, face_vectors[58].Y, face_vectors[58].Z), new Vector3D(face_vectors[59].X, face_vectors[59].Y, face_vectors[59].Z));
            face.angle_59_60 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[59].X, face_vectors[59].Y, face_vectors[59].Z), new Vector3D(face_vectors[60].X, face_vectors[60].Y, face_vectors[60].Z));
            face.angle_60_61 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[60].X, face_vectors[60].Y, face_vectors[60].Z), new Vector3D(face_vectors[61].X, face_vectors[61].Y, face_vectors[61].Z));
            face.angle_61_62 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[61].X, face_vectors[61].Y, face_vectors[61].Z), new Vector3D(face_vectors[62].X, face_vectors[62].Y, face_vectors[62].Z));
            face.angle_62_63 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[62].X, face_vectors[62].Y, face_vectors[62].Z), new Vector3D(face_vectors[63].X, face_vectors[63].Y, face_vectors[63].Z));
            face.angle_63_64 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[63].X, face_vectors[63].Y, face_vectors[63].Z), new Vector3D(face_vectors[64].X, face_vectors[64].Y, face_vectors[64].Z));
            face.angle_64_65 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[64].X, face_vectors[64].Y, face_vectors[64].Z), new Vector3D(face_vectors[65].X, face_vectors[65].Y, face_vectors[65].Z));
            face.angle_65_66 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[65].X, face_vectors[65].Y, face_vectors[65].Z), new Vector3D(face_vectors[66].X, face_vectors[66].Y, face_vectors[66].Z));
            face.angle_66_67 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[66].X, face_vectors[66].Y, face_vectors[66].Z), new Vector3D(face_vectors[67].X, face_vectors[67].Y, face_vectors[67].Z));
            face.angle_67_68 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[67].X, face_vectors[67].Y, face_vectors[67].Z), new Vector3D(face_vectors[68].X, face_vectors[68].Y, face_vectors[68].Z));
            face.angle_68_69 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[68].X, face_vectors[68].Y, face_vectors[68].Z), new Vector3D(face_vectors[69].X, face_vectors[69].Y, face_vectors[69].Z));
            face.angle_69_70 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[69].X, face_vectors[69].Y, face_vectors[69].Z), new Vector3D(face_vectors[70].X, face_vectors[70].Y, face_vectors[70].Z));
            face.angle_70_71 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[70].X, face_vectors[70].Y, face_vectors[70].Z), new Vector3D(face_vectors[71].X, face_vectors[71].Y, face_vectors[71].Z));
            face.angle_71_72 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[71].X, face_vectors[71].Y, face_vectors[71].Z), new Vector3D(face_vectors[72].X, face_vectors[72].Y, face_vectors[72].Z));
            face.angle_72_73 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[72].X, face_vectors[72].Y, face_vectors[72].Z), new Vector3D(face_vectors[73].X, face_vectors[73].Y, face_vectors[73].Z));
            face.angle_73_74 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[73].X, face_vectors[73].Y, face_vectors[73].Z), new Vector3D(face_vectors[74].X, face_vectors[74].Y, face_vectors[74].Z));
            face.angle_74_75 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[74].X, face_vectors[74].Y, face_vectors[74].Z), new Vector3D(face_vectors[75].X, face_vectors[75].Y, face_vectors[75].Z));
            face.angle_75_76 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[75].X, face_vectors[75].Y, face_vectors[75].Z), new Vector3D(face_vectors[76].X, face_vectors[76].Y, face_vectors[76].Z));
            face.angle_76_77 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[76].X, face_vectors[76].Y, face_vectors[76].Z), new Vector3D(face_vectors[77].X, face_vectors[77].Y, face_vectors[77].Z));
            face.angle_77_78 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[77].X, face_vectors[77].Y, face_vectors[77].Z), new Vector3D(face_vectors[78].X, face_vectors[78].Y, face_vectors[78].Z));
            face.angle_78_79 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[78].X, face_vectors[78].Y, face_vectors[78].Z), new Vector3D(face_vectors[79].X, face_vectors[79].Y, face_vectors[79].Z));
            face.angle_79_80 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[79].X, face_vectors[79].Y, face_vectors[79].Z), new Vector3D(face_vectors[80].X, face_vectors[80].Y, face_vectors[80].Z));
            face.angle_80_81 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[80].X, face_vectors[80].Y, face_vectors[80].Z), new Vector3D(face_vectors[81].X, face_vectors[81].Y, face_vectors[81].Z));
            face.angle_81_82 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[81].X, face_vectors[81].Y, face_vectors[81].Z), new Vector3D(face_vectors[82].X, face_vectors[82].Y, face_vectors[82].Z));
            face.angle_82_83 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[82].X, face_vectors[82].Y, face_vectors[82].Z), new Vector3D(face_vectors[83].X, face_vectors[83].Y, face_vectors[83].Z));
            face.angle_83_84 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[83].X, face_vectors[83].Y, face_vectors[83].Z), new Vector3D(face_vectors[84].X, face_vectors[84].Y, face_vectors[84].Z));
            face.angle_84_85 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[84].X, face_vectors[84].Y, face_vectors[84].Z), new Vector3D(face_vectors[85].X, face_vectors[85].Y, face_vectors[85].Z));
            face.angle_85_86 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[85].X, face_vectors[85].Y, face_vectors[85].Z), new Vector3D(face_vectors[86].X, face_vectors[86].Y, face_vectors[86].Z));
            face.angle_86_87 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[86].X, face_vectors[86].Y, face_vectors[86].Z), new Vector3D(face_vectors[87].X, face_vectors[87].Y, face_vectors[87].Z));
            face.angle_87_88 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[87].X, face_vectors[87].Y, face_vectors[87].Z), new Vector3D(face_vectors[88].X, face_vectors[88].Y, face_vectors[88].Z));
            face.angle_88_89 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[88].X, face_vectors[88].Y, face_vectors[88].Z), new Vector3D(face_vectors[89].X, face_vectors[89].Y, face_vectors[89].Z));
            face.angle_89_90 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[89].X, face_vectors[89].Y, face_vectors[89].Z), new Vector3D(face_vectors[90].X, face_vectors[90].Y, face_vectors[90].Z));
            face.angle_90_91 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[90].X, face_vectors[90].Y, face_vectors[90].Z), new Vector3D(face_vectors[91].X, face_vectors[91].Y, face_vectors[91].Z));
            face.angle_91_92 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[91].X, face_vectors[91].Y, face_vectors[91].Z), new Vector3D(face_vectors[92].X, face_vectors[92].Y, face_vectors[92].Z));
            face.angle_92_93 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[92].X, face_vectors[92].Y, face_vectors[92].Z), new Vector3D(face_vectors[93].X, face_vectors[93].Y, face_vectors[93].Z));
            face.angle_93_94 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[93].X, face_vectors[93].Y, face_vectors[93].Z), new Vector3D(face_vectors[94].X, face_vectors[94].Y, face_vectors[94].Z));
            face.angle_94_95 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[94].X, face_vectors[94].Y, face_vectors[94].Z), new Vector3D(face_vectors[95].X, face_vectors[95].Y, face_vectors[95].Z));
            face.angle_95_96 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[95].X, face_vectors[95].Y, face_vectors[95].Z), new Vector3D(face_vectors[96].X, face_vectors[96].Y, face_vectors[96].Z));
            face.angle_96_97 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[96].X, face_vectors[96].Y, face_vectors[96].Z), new Vector3D(face_vectors[97].X, face_vectors[97].Y, face_vectors[97].Z));
            face.angle_97_98 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[97].X, face_vectors[97].Y, face_vectors[97].Z), new Vector3D(face_vectors[98].X, face_vectors[98].Y, face_vectors[98].Z));
            face.angle_98_99 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[98].X, face_vectors[98].Y, face_vectors[98].Z), new Vector3D(face_vectors[99].X, face_vectors[99].Y, face_vectors[99].Z));
            face.angle_99_100 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[99].X, face_vectors[99].Y, face_vectors[99].Z), new Vector3D(face_vectors[100].X, face_vectors[100].Y, face_vectors[100].Z));
            face.angle_100_101 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[100].X, face_vectors[100].Y, face_vectors[100].Z), new Vector3D(face_vectors[101].X, face_vectors[101].Y, face_vectors[101].Z));
            face.angle_101_102 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[101].X, face_vectors[101].Y, face_vectors[101].Z), new Vector3D(face_vectors[102].X, face_vectors[102].Y, face_vectors[102].Z));
            face.angle_102_103 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[102].X, face_vectors[102].Y, face_vectors[102].Z), new Vector3D(face_vectors[103].X, face_vectors[103].Y, face_vectors[103].Z));
            face.angle_103_104 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[103].X, face_vectors[103].Y, face_vectors[103].Z), new Vector3D(face_vectors[104].X, face_vectors[104].Y, face_vectors[104].Z));
            face.angle_104_105 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[104].X, face_vectors[104].Y, face_vectors[104].Z), new Vector3D(face_vectors[105].X, face_vectors[105].Y, face_vectors[105].Z));
            face.angle_105_106 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[105].X, face_vectors[105].Y, face_vectors[105].Z), new Vector3D(face_vectors[106].X, face_vectors[106].Y, face_vectors[106].Z));
            face.angle_106_107 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[106].X, face_vectors[106].Y, face_vectors[106].Z), new Vector3D(face_vectors[107].X, face_vectors[107].Y, face_vectors[107].Z));
            face.angle_107_108 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[107].X, face_vectors[107].Y, face_vectors[107].Z), new Vector3D(face_vectors[108].X, face_vectors[108].Y, face_vectors[108].Z));
            face.angle_108_109 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[108].X, face_vectors[108].Y, face_vectors[108].Z), new Vector3D(face_vectors[109].X, face_vectors[109].Y, face_vectors[109].Z));
            face.angle_109_110 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[109].X, face_vectors[109].Y, face_vectors[109].Z), new Vector3D(face_vectors[110].X, face_vectors[110].Y, face_vectors[110].Z));
            face.angle_110_111 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[110].X, face_vectors[110].Y, face_vectors[110].Z), new Vector3D(face_vectors[111].X, face_vectors[111].Y, face_vectors[111].Z));
            face.angle_111_112 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[111].X, face_vectors[111].Y, face_vectors[111].Z), new Vector3D(face_vectors[112].X, face_vectors[112].Y, face_vectors[112].Z));
            face.angle_112_113 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[112].X, face_vectors[112].Y, face_vectors[112].Z), new Vector3D(face_vectors[113].X, face_vectors[113].Y, face_vectors[113].Z));
            face.angle_113_114 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[113].X, face_vectors[113].Y, face_vectors[113].Z), new Vector3D(face_vectors[114].X, face_vectors[114].Y, face_vectors[114].Z));
            face.angle_114_115 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[114].X, face_vectors[114].Y, face_vectors[114].Z), new Vector3D(face_vectors[115].X, face_vectors[115].Y, face_vectors[115].Z));
            face.angle_115_116 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[115].X, face_vectors[115].Y, face_vectors[115].Z), new Vector3D(face_vectors[116].X, face_vectors[116].Y, face_vectors[116].Z));
            face.angle_116_117 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[116].X, face_vectors[116].Y, face_vectors[116].Z), new Vector3D(face_vectors[117].X, face_vectors[117].Y, face_vectors[117].Z));
            face.angle_117_118 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[117].X, face_vectors[117].Y, face_vectors[117].Z), new Vector3D(face_vectors[118].X, face_vectors[118].Y, face_vectors[118].Z));
            face.angle_118_119 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[118].X, face_vectors[118].Y, face_vectors[118].Z), new Vector3D(face_vectors[119].X, face_vectors[119].Y, face_vectors[119].Z));
            face.angle_119_120 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[119].X, face_vectors[119].Y, face_vectors[119].Z), new Vector3D(face_vectors[120].X, face_vectors[120].Y, face_vectors[120].Z));
            face.angle_120_0 = (decimal)Vector3D.AngleBetween(new Vector3D(face_vectors[120].X, face_vectors[120].Y, face_vectors[120].Z), new Vector3D(face_vectors[0].X, face_vectors[0].Y, face_vectors[0].Z));

            face.magRatio_0_1 = (decimal)(Maths.Magnitude(face_vectors[0]) / Maths.Magnitude(face_vectors[1]));
            face.magRatio_1_2 = (decimal)(Maths.Magnitude(face_vectors[1]) / Maths.Magnitude(face_vectors[2]));
            face.magRatio_2_3 = (decimal)(Maths.Magnitude(face_vectors[2]) / Maths.Magnitude(face_vectors[3]));
            face.magRatio_3_4 = (decimal)(Maths.Magnitude(face_vectors[3]) / Maths.Magnitude(face_vectors[4]));
            face.magRatio_4_5 = (decimal)(Maths.Magnitude(face_vectors[4]) / Maths.Magnitude(face_vectors[5]));
            face.magRatio_5_6 = (decimal)(Maths.Magnitude(face_vectors[5]) / Maths.Magnitude(face_vectors[6]));
            face.magRatio_6_7 = (decimal)(Maths.Magnitude(face_vectors[6]) / Maths.Magnitude(face_vectors[7]));
            face.magRatio_7_8 = (decimal)(Maths.Magnitude(face_vectors[7]) / Maths.Magnitude(face_vectors[8]));
            face.magRatio_8_9 = (decimal)(Maths.Magnitude(face_vectors[8]) / Maths.Magnitude(face_vectors[9]));
            face.magRatio_9_10 = (decimal)(Maths.Magnitude(face_vectors[9]) / Maths.Magnitude(face_vectors[10]));
            face.magRatio_10_11 = (decimal)(Maths.Magnitude(face_vectors[10]) / Maths.Magnitude(face_vectors[11]));
            face.magRatio_11_12 = (decimal)(Maths.Magnitude(face_vectors[11]) / Maths.Magnitude(face_vectors[12]));
            face.magRatio_12_13 = (decimal)(Maths.Magnitude(face_vectors[12]) / Maths.Magnitude(face_vectors[13]));
            face.magRatio_13_14 = (decimal)(Maths.Magnitude(face_vectors[13]) / Maths.Magnitude(face_vectors[14]));
            face.magRatio_14_15 = (decimal)(Maths.Magnitude(face_vectors[14]) / Maths.Magnitude(face_vectors[15]));
            face.magRatio_15_16 = (decimal)(Maths.Magnitude(face_vectors[15]) / Maths.Magnitude(face_vectors[16]));
            face.magRatio_16_17 = (decimal)(Maths.Magnitude(face_vectors[16]) / Maths.Magnitude(face_vectors[17]));
            face.magRatio_17_18 = (decimal)(Maths.Magnitude(face_vectors[17]) / Maths.Magnitude(face_vectors[18]));
            face.magRatio_18_19 = (decimal)(Maths.Magnitude(face_vectors[18]) / Maths.Magnitude(face_vectors[19]));
            face.magRatio_19_20 = (decimal)(Maths.Magnitude(face_vectors[19]) / Maths.Magnitude(face_vectors[20]));
            face.magRatio_20_21 = (decimal)(Maths.Magnitude(face_vectors[20]) / Maths.Magnitude(face_vectors[21]));
            face.magRatio_21_22 = (decimal)(Maths.Magnitude(face_vectors[21]) / Maths.Magnitude(face_vectors[22]));
            face.magRatio_22_23 = (decimal)(Maths.Magnitude(face_vectors[22]) / Maths.Magnitude(face_vectors[23]));
            face.magRatio_23_24 = (decimal)(Maths.Magnitude(face_vectors[23]) / Maths.Magnitude(face_vectors[24]));
            face.magRatio_24_25 = (decimal)(Maths.Magnitude(face_vectors[24]) / Maths.Magnitude(face_vectors[25]));
            face.magRatio_25_26 = (decimal)(Maths.Magnitude(face_vectors[25]) / Maths.Magnitude(face_vectors[26]));
            face.magRatio_26_27 = (decimal)(Maths.Magnitude(face_vectors[26]) / Maths.Magnitude(face_vectors[27]));
            face.magRatio_27_28 = (decimal)(Maths.Magnitude(face_vectors[27]) / Maths.Magnitude(face_vectors[28]));
            face.magRatio_28_29 = (decimal)(Maths.Magnitude(face_vectors[28]) / Maths.Magnitude(face_vectors[29]));
            face.magRatio_29_30 = (decimal)(Maths.Magnitude(face_vectors[29]) / Maths.Magnitude(face_vectors[30]));
            face.magRatio_30_31 = (decimal)(Maths.Magnitude(face_vectors[30]) / Maths.Magnitude(face_vectors[31]));
            face.magRatio_31_32 = (decimal)(Maths.Magnitude(face_vectors[31]) / Maths.Magnitude(face_vectors[32]));
            face.magRatio_32_33 = (decimal)(Maths.Magnitude(face_vectors[32]) / Maths.Magnitude(face_vectors[33]));
            face.magRatio_33_34 = (decimal)(Maths.Magnitude(face_vectors[33]) / Maths.Magnitude(face_vectors[34]));
            face.magRatio_34_35 = (decimal)(Maths.Magnitude(face_vectors[34]) / Maths.Magnitude(face_vectors[35]));
            face.magRatio_35_36 = (decimal)(Maths.Magnitude(face_vectors[35]) / Maths.Magnitude(face_vectors[36]));
            face.magRatio_36_37 = (decimal)(Maths.Magnitude(face_vectors[36]) / Maths.Magnitude(face_vectors[37]));
            face.magRatio_37_38 = (decimal)(Maths.Magnitude(face_vectors[37]) / Maths.Magnitude(face_vectors[38]));
            face.magRatio_38_39 = (decimal)(Maths.Magnitude(face_vectors[38]) / Maths.Magnitude(face_vectors[39]));
            face.magRatio_39_40 = (decimal)(Maths.Magnitude(face_vectors[39]) / Maths.Magnitude(face_vectors[40]));
            face.magRatio_40_41 = (decimal)(Maths.Magnitude(face_vectors[40]) / Maths.Magnitude(face_vectors[41]));
            face.magRatio_41_42 = (decimal)(Maths.Magnitude(face_vectors[41]) / Maths.Magnitude(face_vectors[42]));
            face.magRatio_42_43 = (decimal)(Maths.Magnitude(face_vectors[42]) / Maths.Magnitude(face_vectors[43]));
            face.magRatio_43_44 = (decimal)(Maths.Magnitude(face_vectors[43]) / Maths.Magnitude(face_vectors[44]));
            face.magRatio_44_45 = (decimal)(Maths.Magnitude(face_vectors[44]) / Maths.Magnitude(face_vectors[45]));
            face.magRatio_45_46 = (decimal)(Maths.Magnitude(face_vectors[45]) / Maths.Magnitude(face_vectors[46]));
            face.magRatio_46_47 = (decimal)(Maths.Magnitude(face_vectors[46]) / Maths.Magnitude(face_vectors[47]));
            face.magRatio_47_48 = (decimal)(Maths.Magnitude(face_vectors[47]) / Maths.Magnitude(face_vectors[48]));
            face.magRatio_48_49 = (decimal)(Maths.Magnitude(face_vectors[48]) / Maths.Magnitude(face_vectors[49]));
            face.magRatio_49_50 = (decimal)(Maths.Magnitude(face_vectors[49]) / Maths.Magnitude(face_vectors[50]));
            face.magRatio_50_51 = (decimal)(Maths.Magnitude(face_vectors[50]) / Maths.Magnitude(face_vectors[51]));
            face.magRatio_51_52 = (decimal)(Maths.Magnitude(face_vectors[51]) / Maths.Magnitude(face_vectors[52]));
            face.magRatio_52_53 = (decimal)(Maths.Magnitude(face_vectors[52]) / Maths.Magnitude(face_vectors[53]));
            face.magRatio_53_54 = (decimal)(Maths.Magnitude(face_vectors[53]) / Maths.Magnitude(face_vectors[54]));
            face.magRatio_54_55 = (decimal)(Maths.Magnitude(face_vectors[54]) / Maths.Magnitude(face_vectors[55]));
            face.magRatio_55_56 = (decimal)(Maths.Magnitude(face_vectors[55]) / Maths.Magnitude(face_vectors[56]));
            face.magRatio_56_57 = (decimal)(Maths.Magnitude(face_vectors[56]) / Maths.Magnitude(face_vectors[57]));
            face.magRatio_57_58 = (decimal)(Maths.Magnitude(face_vectors[57]) / Maths.Magnitude(face_vectors[58]));
            face.magRatio_58_59 = (decimal)(Maths.Magnitude(face_vectors[58]) / Maths.Magnitude(face_vectors[59]));
            face.magRatio_59_60 = (decimal)(Maths.Magnitude(face_vectors[59]) / Maths.Magnitude(face_vectors[60]));
            face.magRatio_60_61 = (decimal)(Maths.Magnitude(face_vectors[60]) / Maths.Magnitude(face_vectors[61]));
            face.magRatio_61_62 = (decimal)(Maths.Magnitude(face_vectors[61]) / Maths.Magnitude(face_vectors[62]));
            face.magRatio_62_63 = (decimal)(Maths.Magnitude(face_vectors[62]) / Maths.Magnitude(face_vectors[63]));
            face.magRatio_63_64 = (decimal)(Maths.Magnitude(face_vectors[63]) / Maths.Magnitude(face_vectors[64]));
            face.magRatio_64_65 = (decimal)(Maths.Magnitude(face_vectors[64]) / Maths.Magnitude(face_vectors[65]));
            face.magRatio_65_66 = (decimal)(Maths.Magnitude(face_vectors[65]) / Maths.Magnitude(face_vectors[66]));
            face.magRatio_66_67 = (decimal)(Maths.Magnitude(face_vectors[66]) / Maths.Magnitude(face_vectors[67]));
            face.magRatio_67_68 = (decimal)(Maths.Magnitude(face_vectors[67]) / Maths.Magnitude(face_vectors[68]));
            face.magRatio_68_69 = (decimal)(Maths.Magnitude(face_vectors[68]) / Maths.Magnitude(face_vectors[69]));
            face.magRatio_69_70 = (decimal)(Maths.Magnitude(face_vectors[69]) / Maths.Magnitude(face_vectors[70]));
            face.magRatio_70_71 = (decimal)(Maths.Magnitude(face_vectors[70]) / Maths.Magnitude(face_vectors[71]));
            face.magRatio_71_72 = (decimal)(Maths.Magnitude(face_vectors[71]) / Maths.Magnitude(face_vectors[72]));
            face.magRatio_72_73 = (decimal)(Maths.Magnitude(face_vectors[72]) / Maths.Magnitude(face_vectors[73]));
            face.magRatio_73_74 = (decimal)(Maths.Magnitude(face_vectors[73]) / Maths.Magnitude(face_vectors[74]));
            face.magRatio_74_75 = (decimal)(Maths.Magnitude(face_vectors[74]) / Maths.Magnitude(face_vectors[75]));
            face.magRatio_75_76 = (decimal)(Maths.Magnitude(face_vectors[75]) / Maths.Magnitude(face_vectors[76]));
            face.magRatio_76_77 = (decimal)(Maths.Magnitude(face_vectors[76]) / Maths.Magnitude(face_vectors[77]));
            face.magRatio_77_78 = (decimal)(Maths.Magnitude(face_vectors[77]) / Maths.Magnitude(face_vectors[78]));
            face.magRatio_78_79 = (decimal)(Maths.Magnitude(face_vectors[78]) / Maths.Magnitude(face_vectors[79]));
            face.magRatio_79_80 = (decimal)(Maths.Magnitude(face_vectors[79]) / Maths.Magnitude(face_vectors[80]));
            face.magRatio_80_81 = (decimal)(Maths.Magnitude(face_vectors[80]) / Maths.Magnitude(face_vectors[81]));
            face.magRatio_81_82 = (decimal)(Maths.Magnitude(face_vectors[81]) / Maths.Magnitude(face_vectors[82]));
            face.magRatio_82_83 = (decimal)(Maths.Magnitude(face_vectors[82]) / Maths.Magnitude(face_vectors[83]));
            face.magRatio_83_84 = (decimal)(Maths.Magnitude(face_vectors[83]) / Maths.Magnitude(face_vectors[84]));
            face.magRatio_84_85 = (decimal)(Maths.Magnitude(face_vectors[84]) / Maths.Magnitude(face_vectors[85]));
            face.magRatio_85_86 = (decimal)(Maths.Magnitude(face_vectors[85]) / Maths.Magnitude(face_vectors[86]));
            face.magRatio_86_87 = (decimal)(Maths.Magnitude(face_vectors[86]) / Maths.Magnitude(face_vectors[87]));
            face.magRatio_87_88 = (decimal)(Maths.Magnitude(face_vectors[87]) / Maths.Magnitude(face_vectors[88]));
            face.magRatio_88_89 = (decimal)(Maths.Magnitude(face_vectors[88]) / Maths.Magnitude(face_vectors[89]));
            face.magRatio_89_90 = (decimal)(Maths.Magnitude(face_vectors[89]) / Maths.Magnitude(face_vectors[90]));
            face.magRatio_90_91 = (decimal)(Maths.Magnitude(face_vectors[90]) / Maths.Magnitude(face_vectors[91]));
            face.magRatio_91_92 = (decimal)(Maths.Magnitude(face_vectors[91]) / Maths.Magnitude(face_vectors[92]));
            face.magRatio_92_93 = (decimal)(Maths.Magnitude(face_vectors[92]) / Maths.Magnitude(face_vectors[93]));
            face.magRatio_93_94 = (decimal)(Maths.Magnitude(face_vectors[93]) / Maths.Magnitude(face_vectors[94]));
            face.magRatio_94_95 = (decimal)(Maths.Magnitude(face_vectors[94]) / Maths.Magnitude(face_vectors[95]));
            face.magRatio_95_96 = (decimal)(Maths.Magnitude(face_vectors[95]) / Maths.Magnitude(face_vectors[96]));
            face.magRatio_96_97 = (decimal)(Maths.Magnitude(face_vectors[96]) / Maths.Magnitude(face_vectors[97]));
            face.magRatio_97_98 = (decimal)(Maths.Magnitude(face_vectors[97]) / Maths.Magnitude(face_vectors[98]));
            face.magRatio_98_99 = (decimal)(Maths.Magnitude(face_vectors[98]) / Maths.Magnitude(face_vectors[99]));
            face.magRatio_99_100 = (decimal)(Maths.Magnitude(face_vectors[99]) / Maths.Magnitude(face_vectors[100]));
            face.magRatio_100_101 = (decimal)(Maths.Magnitude(face_vectors[100]) / Maths.Magnitude(face_vectors[101]));
            face.magRatio_101_102 = (decimal)(Maths.Magnitude(face_vectors[101]) / Maths.Magnitude(face_vectors[102]));
            face.magRatio_102_103 = (decimal)(Maths.Magnitude(face_vectors[102]) / Maths.Magnitude(face_vectors[103]));
            face.magRatio_103_104 = (decimal)(Maths.Magnitude(face_vectors[103]) / Maths.Magnitude(face_vectors[104]));
            face.magRatio_104_105 = (decimal)(Maths.Magnitude(face_vectors[104]) / Maths.Magnitude(face_vectors[105]));
            face.magRatio_105_106 = (decimal)(Maths.Magnitude(face_vectors[105]) / Maths.Magnitude(face_vectors[106]));
            face.magRatio_106_107 = (decimal)(Maths.Magnitude(face_vectors[106]) / Maths.Magnitude(face_vectors[107]));
            face.magRatio_107_108 = (decimal)(Maths.Magnitude(face_vectors[107]) / Maths.Magnitude(face_vectors[108]));
            face.magRatio_108_109 = (decimal)(Maths.Magnitude(face_vectors[108]) / Maths.Magnitude(face_vectors[109]));
            face.magRatio_109_110 = (decimal)(Maths.Magnitude(face_vectors[109]) / Maths.Magnitude(face_vectors[110]));
            face.magRatio_110_111 = (decimal)(Maths.Magnitude(face_vectors[110]) / Maths.Magnitude(face_vectors[111]));
            face.magRatio_111_112 = (decimal)(Maths.Magnitude(face_vectors[111]) / Maths.Magnitude(face_vectors[112]));
            face.magRatio_112_113 = (decimal)(Maths.Magnitude(face_vectors[112]) / Maths.Magnitude(face_vectors[113]));
            face.magRatio_113_114 = (decimal)(Maths.Magnitude(face_vectors[113]) / Maths.Magnitude(face_vectors[114]));
            face.magRatio_114_115 = (decimal)(Maths.Magnitude(face_vectors[114]) / Maths.Magnitude(face_vectors[115]));
            face.magRatio_115_116 = (decimal)(Maths.Magnitude(face_vectors[115]) / Maths.Magnitude(face_vectors[116]));
            face.magRatio_116_117 = (decimal)(Maths.Magnitude(face_vectors[116]) / Maths.Magnitude(face_vectors[117]));
            face.magRatio_117_118 = (decimal)(Maths.Magnitude(face_vectors[117]) / Maths.Magnitude(face_vectors[118]));
            face.magRatio_118_119 = (decimal)(Maths.Magnitude(face_vectors[118]) / Maths.Magnitude(face_vectors[119]));
            face.magRatio_119_120 = (decimal)(Maths.Magnitude(face_vectors[119]) / Maths.Magnitude(face_vectors[120]));
            face.magRatio_120_0 = (decimal)(Maths.Magnitude(face_vectors[120]) / Maths.Magnitude(face_vectors[0]));

            return face;
        }

        private static void add_to_db(Face face)
        {
            using (var db = new Database.Database())
            {
                db.Faces.Add(face); // add the face to the database
                db.SaveChanges(); // update the database
            }
        }

        private static String get_match(Face face)
        {
            using (var db = new Database.Database())
            {
                //double target_match = (double)face.face_code;
                decimal match = Decimal.MinValue; // the closest match
                string name = ""; // name of the closest match

                // Display all Blogs from the database
                var query = from b in db.Faces
                            orderby b.name
                            select b;

                Console.WriteLine("Searching database...");

                foreach (var found_face in query)
                {
                    FaceMatch fm = new FaceMatch(found_face, face);
                    decimal closeness = fm.getMean();

                    if (closeness > match)
                    {
                        match = closeness;
                        name = found_face.name;
                    }

                    Console.WriteLine("checked " + found_face.name + " :: " + closeness);
                }
                //MainWindow
                Console.WriteLine("closest match: " + name + " :: " + match); // write the name of the closest match
                return name;
            }
        }
    }
}
