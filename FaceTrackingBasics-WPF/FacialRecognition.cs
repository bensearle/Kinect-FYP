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

            face.angle_0_44_45 = (decimal)Maths.Angle(face_vectors[0], face_vectors[44], face_vectors[45]);
            face.angle_44_45_47 = (decimal)Maths.Angle(face_vectors[44], face_vectors[45], face_vectors[47]);
            face.angle_45_47_62 = (decimal)Maths.Angle(face_vectors[45], face_vectors[47], face_vectors[62]);
            face.angle_47_62_61 = (decimal)Maths.Angle(face_vectors[47], face_vectors[62], face_vectors[61]);
            face.angle_62_61_63 = (decimal)Maths.Angle(face_vectors[62], face_vectors[61], face_vectors[63]);
            face.angle_61_63_43 = (decimal)Maths.Angle(face_vectors[61], face_vectors[63], face_vectors[43]);
            face.angle_63_43_30 = (decimal)Maths.Angle(face_vectors[63], face_vectors[43], face_vectors[30]);
            face.angle_43_30_28 = (decimal)Maths.Angle(face_vectors[43], face_vectors[30], face_vectors[28]);
            face.angle_30_28_29 = (decimal)Maths.Angle(face_vectors[30], face_vectors[28], face_vectors[29]);
            face.angle_28_29_14 = (decimal)Maths.Angle(face_vectors[28], face_vectors[29], face_vectors[14]);
            face.angle_29_14_12 = (decimal)Maths.Angle(face_vectors[29], face_vectors[14], face_vectors[12]);
            face.angle_14_12_11 = (decimal)Maths.Angle(face_vectors[14], face_vectors[12], face_vectors[11]);
            face.angle_12_11_0 = (decimal)Maths.Angle(face_vectors[12], face_vectors[11], face_vectors[0]);
            face.angle_11_0_34 = (decimal)Maths.Angle(face_vectors[11], face_vectors[0], face_vectors[34]);
            face.angle_0_34_45 = (decimal)Maths.Angle(face_vectors[0], face_vectors[34], face_vectors[45]);
            face.angle_34_45_46 = (decimal)Maths.Angle(face_vectors[34], face_vectors[45], face_vectors[46]);
            face.angle_45_46_47 = (decimal)Maths.Angle(face_vectors[45], face_vectors[46], face_vectors[47]);
            face.angle_46_47_2 = (decimal)Maths.Angle(face_vectors[46], face_vectors[47], face_vectors[2]);
            face.angle_47_2_62 = (decimal)Maths.Angle(face_vectors[47], face_vectors[2], face_vectors[62]);
            face.angle_2_62_60 = (decimal)Maths.Angle(face_vectors[2], face_vectors[62], face_vectors[60]);
            face.angle_62_60_61 = (decimal)Maths.Angle(face_vectors[62], face_vectors[60], face_vectors[61]);
            face.angle_60_61_41 = (decimal)Maths.Angle(face_vectors[60], face_vectors[61], face_vectors[41]);
            face.angle_61_41_63 = (decimal)Maths.Angle(face_vectors[61], face_vectors[41], face_vectors[63]);
            face.angle_41_63_42 = (decimal)Maths.Angle(face_vectors[41], face_vectors[63], face_vectors[42]);
            face.angle_63_42_30 = (decimal)Maths.Angle(face_vectors[63], face_vectors[42], face_vectors[30]);
            face.angle_42_30_27 = (decimal)Maths.Angle(face_vectors[42], face_vectors[30], face_vectors[27]);
            face.angle_30_27_29 = (decimal)Maths.Angle(face_vectors[30], face_vectors[27], face_vectors[29]);
            face.angle_27_29_13 = (decimal)Maths.Angle(face_vectors[27], face_vectors[29], face_vectors[13]);
            face.angle_29_13_12 = (decimal)Maths.Angle(face_vectors[29], face_vectors[13], face_vectors[12]);
            face.angle_13_12_1 = (decimal)Maths.Angle(face_vectors[13], face_vectors[12], face_vectors[1]);
            face.angle_12_1_11 = (decimal)Maths.Angle(face_vectors[12], face_vectors[1], face_vectors[11]);
            face.angle_1_11_2 = (decimal)Maths.Angle(face_vectors[1], face_vectors[11], face_vectors[2]);
            face.angle_11_2_14 = (decimal)Maths.Angle(face_vectors[11], face_vectors[2], face_vectors[14]);
            face.angle_2_14_36 = (decimal)Maths.Angle(face_vectors[2], face_vectors[14], face_vectors[36]);
            face.angle_14_36_13 = (decimal)Maths.Angle(face_vectors[14], face_vectors[36], face_vectors[13]);
            face.angle_36_13_1 = (decimal)Maths.Angle(face_vectors[36], face_vectors[13], face_vectors[1]);
            face.angle_13_1_34 = (decimal)Maths.Angle(face_vectors[13], face_vectors[1], face_vectors[34]);
            face.angle_1_34_46 = (decimal)Maths.Angle(face_vectors[1], face_vectors[34], face_vectors[46]);
            face.angle_34_46_53 = (decimal)Maths.Angle(face_vectors[34], face_vectors[46], face_vectors[53]);
            face.angle_46_53_60 = (decimal)Maths.Angle(face_vectors[46], face_vectors[53], face_vectors[60]);
            face.angle_53_60_59 = (decimal)Maths.Angle(face_vectors[53], face_vectors[60], face_vectors[59]);
            face.angle_60_59_112 = (decimal)Maths.Angle(face_vectors[60], face_vectors[59], face_vectors[112]);
            face.angle_59_112_6 = (decimal)Maths.Angle(face_vectors[59], face_vectors[112], face_vectors[6]);
            face.angle_112_6_111 = (decimal)Maths.Angle(face_vectors[112], face_vectors[6], face_vectors[111]);
            face.angle_6_111_26 = (decimal)Maths.Angle(face_vectors[6], face_vectors[111], face_vectors[26]);
            face.angle_111_26_25 = (decimal)Maths.Angle(face_vectors[111], face_vectors[26], face_vectors[25]);
            face.angle_26_25_75 = (decimal)Maths.Angle(face_vectors[26], face_vectors[25], face_vectors[75]);
            face.angle_25_75_5 = (decimal)Maths.Angle(face_vectors[25], face_vectors[75], face_vectors[5]);
            face.angle_75_5_76 = (decimal)Maths.Angle(face_vectors[75], face_vectors[5], face_vectors[76]);
            face.angle_5_76_58 = (decimal)Maths.Angle(face_vectors[5], face_vectors[76], face_vectors[58]);
            face.angle_76_58_59 = (decimal)Maths.Angle(face_vectors[76], face_vectors[58], face_vectors[59]);
            face.angle_58_59_93 = (decimal)Maths.Angle(face_vectors[58], face_vectors[59], face_vectors[93]);
            face.angle_59_93_94 = (decimal)Maths.Angle(face_vectors[59], face_vectors[93], face_vectors[94]);
            face.angle_93_94_92 = (decimal)Maths.Angle(face_vectors[93], face_vectors[94], face_vectors[92]);
            face.angle_94_92_5 = (decimal)Maths.Angle(face_vectors[94], face_vectors[92], face_vectors[5]);
            face.angle_92_5_94 = (decimal)Maths.Angle(face_vectors[92], face_vectors[5], face_vectors[94]);
            face.angle_5_94_25 = (decimal)Maths.Angle(face_vectors[5], face_vectors[94], face_vectors[25]);
            face.angle_94_25_58 = (decimal)Maths.Angle(face_vectors[94], face_vectors[25], face_vectors[58]);
            face.angle_25_58_25 = (decimal)Maths.Angle(face_vectors[25], face_vectors[58], face_vectors[25]);
            face.angle_58_25_6 = (decimal)Maths.Angle(face_vectors[58], face_vectors[25], face_vectors[6]);
            face.angle_25_6_42 = (decimal)Maths.Angle(face_vectors[25], face_vectors[6], face_vectors[42]);
            face.angle_6_42_27 = (decimal)Maths.Angle(face_vectors[6], face_vectors[42], face_vectors[27]);
            face.angle_42_27_20 = (decimal)Maths.Angle(face_vectors[42], face_vectors[27], face_vectors[20]);
            face.angle_27_20_95 = (decimal)Maths.Angle(face_vectors[27], face_vectors[20], face_vectors[95]);
            face.angle_20_95_19 = (decimal)Maths.Angle(face_vectors[20], face_vectors[95], face_vectors[19]);
            face.angle_95_19_103 = (decimal)Maths.Angle(face_vectors[95], face_vectors[19], face_vectors[103]);
            face.angle_19_103_23 = (decimal)Maths.Angle(face_vectors[19], face_vectors[103], face_vectors[23]);
            face.angle_103_23_109 = (decimal)Maths.Angle(face_vectors[103], face_vectors[23], face_vectors[109]);
            face.angle_23_109_24 = (decimal)Maths.Angle(face_vectors[23], face_vectors[109], face_vectors[24]);
            face.angle_109_24_101 = (decimal)Maths.Angle(face_vectors[109], face_vectors[24], face_vectors[101]);
            face.angle_24_101_20 = (decimal)Maths.Angle(face_vectors[24], face_vectors[101], face_vectors[20]);
            face.angle_101_20_103 = (decimal)Maths.Angle(face_vectors[101], face_vectors[20], face_vectors[103]);
            face.angle_20_103_72 = (decimal)Maths.Angle(face_vectors[20], face_vectors[103], face_vectors[72]);
            face.angle_103_72_95 = (decimal)Maths.Angle(face_vectors[103], face_vectors[72], face_vectors[95]);
            face.angle_72_95_68 = (decimal)Maths.Angle(face_vectors[72], face_vectors[95], face_vectors[68]);
            face.angle_95_68_19 = (decimal)Maths.Angle(face_vectors[95], face_vectors[68], face_vectors[19]);
            face.angle_68_19_4 = (decimal)Maths.Angle(face_vectors[68], face_vectors[19], face_vectors[4]);
            face.angle_19_4_52 = (decimal)Maths.Angle(face_vectors[19], face_vectors[4], face_vectors[52]);
            face.angle_4_52_96 = (decimal)Maths.Angle(face_vectors[4], face_vectors[52], face_vectors[96]);
            face.angle_52_96_53 = (decimal)Maths.Angle(face_vectors[52], face_vectors[96], face_vectors[53]);
            face.angle_96_53_56 = (decimal)Maths.Angle(face_vectors[96], face_vectors[53], face_vectors[56]);
            face.angle_53_56_104 = (decimal)Maths.Angle(face_vectors[53], face_vectors[56], face_vectors[104]);
            face.angle_56_104_52 = (decimal)Maths.Angle(face_vectors[56], face_vectors[104], face_vectors[52]);
            face.angle_104_52_102 = (decimal)Maths.Angle(face_vectors[104], face_vectors[52], face_vectors[102]);
            face.angle_52_102_110 = (decimal)Maths.Angle(face_vectors[52], face_vectors[102], face_vectors[110]);
            face.angle_102_110_57 = (decimal)Maths.Angle(face_vectors[102], face_vectors[110], face_vectors[57]);
            face.angle_110_57_96 = (decimal)Maths.Angle(face_vectors[110], face_vectors[57], face_vectors[96]);
            face.angle_57_96_57 = (decimal)Maths.Angle(face_vectors[57], face_vectors[96], face_vectors[57]);
            face.angle_96_57_94 = (decimal)Maths.Angle(face_vectors[96], face_vectors[57], face_vectors[94]);
            face.angle_57_94_56 = (decimal)Maths.Angle(face_vectors[57], face_vectors[94], face_vectors[56]);
            face.angle_94_56_74 = (decimal)Maths.Angle(face_vectors[94], face_vectors[56], face_vectors[74]);
            face.angle_56_74_70 = (decimal)Maths.Angle(face_vectors[56], face_vectors[74], face_vectors[70]);
            face.angle_74_70_53 = (decimal)Maths.Angle(face_vectors[74], face_vectors[70], face_vectors[53]);
            face.angle_70_53_43 = (decimal)Maths.Angle(face_vectors[70], face_vectors[53], face_vectors[43]);
            face.angle_53_43_0 = (decimal)Maths.Angle(face_vectors[53], face_vectors[43], face_vectors[0]);
            face.angle_43_0_20 = (decimal)Maths.Angle(face_vectors[43], face_vectors[0], face_vectors[20]);
            face.angle_0_20_53 = (decimal)Maths.Angle(face_vectors[0], face_vectors[20], face_vectors[53]);
            face.angle_20_53_2 = (decimal)Maths.Angle(face_vectors[20], face_vectors[53], face_vectors[2]);
            face.angle_53_2_6 = (decimal)Maths.Angle(face_vectors[53], face_vectors[2], face_vectors[6]);

            face.magRatio_0_44_45 = (decimal)Maths.Ratio(face_vectors[0], face_vectors[44], face_vectors[45]);
            face.magRatio_44_45_47 = (decimal)Maths.Ratio(face_vectors[44], face_vectors[45], face_vectors[47]);
            face.magRatio_45_47_62 = (decimal)Maths.Ratio(face_vectors[45], face_vectors[47], face_vectors[62]);
            face.magRatio_47_62_61 = (decimal)Maths.Ratio(face_vectors[47], face_vectors[62], face_vectors[61]);
            face.magRatio_62_61_63 = (decimal)Maths.Ratio(face_vectors[62], face_vectors[61], face_vectors[63]);
            face.magRatio_61_63_43 = (decimal)Maths.Ratio(face_vectors[61], face_vectors[63], face_vectors[43]);
            face.magRatio_63_43_30 = (decimal)Maths.Ratio(face_vectors[63], face_vectors[43], face_vectors[30]);
            face.magRatio_43_30_28 = (decimal)Maths.Ratio(face_vectors[43], face_vectors[30], face_vectors[28]);
            face.magRatio_30_28_29 = (decimal)Maths.Ratio(face_vectors[30], face_vectors[28], face_vectors[29]);
            face.magRatio_28_29_14 = (decimal)Maths.Ratio(face_vectors[28], face_vectors[29], face_vectors[14]);
            face.magRatio_29_14_12 = (decimal)Maths.Ratio(face_vectors[29], face_vectors[14], face_vectors[12]);
            face.magRatio_14_12_11 = (decimal)Maths.Ratio(face_vectors[14], face_vectors[12], face_vectors[11]);
            face.magRatio_12_11_0 = (decimal)Maths.Ratio(face_vectors[12], face_vectors[11], face_vectors[0]);
            face.magRatio_11_0_34 = (decimal)Maths.Ratio(face_vectors[11], face_vectors[0], face_vectors[34]);
            face.magRatio_0_34_45 = (decimal)Maths.Ratio(face_vectors[0], face_vectors[34], face_vectors[45]);
            face.magRatio_34_45_46 = (decimal)Maths.Ratio(face_vectors[34], face_vectors[45], face_vectors[46]);
            face.magRatio_45_46_47 = (decimal)Maths.Ratio(face_vectors[45], face_vectors[46], face_vectors[47]);
            face.magRatio_46_47_2 = (decimal)Maths.Ratio(face_vectors[46], face_vectors[47], face_vectors[2]);
            face.magRatio_47_2_62 = (decimal)Maths.Ratio(face_vectors[47], face_vectors[2], face_vectors[62]);
            face.magRatio_2_62_60 = (decimal)Maths.Ratio(face_vectors[2], face_vectors[62], face_vectors[60]);
            face.magRatio_62_60_61 = (decimal)Maths.Ratio(face_vectors[62], face_vectors[60], face_vectors[61]);
            face.magRatio_60_61_41 = (decimal)Maths.Ratio(face_vectors[60], face_vectors[61], face_vectors[41]);
            face.magRatio_61_41_63 = (decimal)Maths.Ratio(face_vectors[61], face_vectors[41], face_vectors[63]);
            face.magRatio_41_63_42 = (decimal)Maths.Ratio(face_vectors[41], face_vectors[63], face_vectors[42]);
            face.magRatio_63_42_30 = (decimal)Maths.Ratio(face_vectors[63], face_vectors[42], face_vectors[30]);
            face.magRatio_42_30_27 = (decimal)Maths.Ratio(face_vectors[42], face_vectors[30], face_vectors[27]);
            face.magRatio_30_27_29 = (decimal)Maths.Ratio(face_vectors[30], face_vectors[27], face_vectors[29]);
            face.magRatio_27_29_13 = (decimal)Maths.Ratio(face_vectors[27], face_vectors[29], face_vectors[13]);
            face.magRatio_29_13_12 = (decimal)Maths.Ratio(face_vectors[29], face_vectors[13], face_vectors[12]);
            face.magRatio_13_12_1 = (decimal)Maths.Ratio(face_vectors[13], face_vectors[12], face_vectors[1]);
            face.magRatio_12_1_11 = (decimal)Maths.Ratio(face_vectors[12], face_vectors[1], face_vectors[11]);
            face.magRatio_1_11_2 = (decimal)Maths.Ratio(face_vectors[1], face_vectors[11], face_vectors[2]);
            face.magRatio_11_2_14 = (decimal)Maths.Ratio(face_vectors[11], face_vectors[2], face_vectors[14]);
            face.magRatio_2_14_36 = (decimal)Maths.Ratio(face_vectors[2], face_vectors[14], face_vectors[36]);
            face.magRatio_14_36_13 = (decimal)Maths.Ratio(face_vectors[14], face_vectors[36], face_vectors[13]);
            face.magRatio_36_13_1 = (decimal)Maths.Ratio(face_vectors[36], face_vectors[13], face_vectors[1]);
            face.magRatio_13_1_34 = (decimal)Maths.Ratio(face_vectors[13], face_vectors[1], face_vectors[34]);
            face.magRatio_1_34_46 = (decimal)Maths.Ratio(face_vectors[1], face_vectors[34], face_vectors[46]);
            face.magRatio_34_46_53 = (decimal)Maths.Ratio(face_vectors[34], face_vectors[46], face_vectors[53]);
            face.magRatio_46_53_60 = (decimal)Maths.Ratio(face_vectors[46], face_vectors[53], face_vectors[60]);
            face.magRatio_53_60_59 = (decimal)Maths.Ratio(face_vectors[53], face_vectors[60], face_vectors[59]);
            face.magRatio_60_59_112 = (decimal)Maths.Ratio(face_vectors[60], face_vectors[59], face_vectors[112]);
            face.magRatio_59_112_6 = (decimal)Maths.Ratio(face_vectors[59], face_vectors[112], face_vectors[6]);
            face.magRatio_112_6_111 = (decimal)Maths.Ratio(face_vectors[112], face_vectors[6], face_vectors[111]);
            face.magRatio_6_111_26 = (decimal)Maths.Ratio(face_vectors[6], face_vectors[111], face_vectors[26]);
            face.magRatio_111_26_25 = (decimal)Maths.Ratio(face_vectors[111], face_vectors[26], face_vectors[25]);
            face.magRatio_26_25_75 = (decimal)Maths.Ratio(face_vectors[26], face_vectors[25], face_vectors[75]);
            face.magRatio_25_75_5 = (decimal)Maths.Ratio(face_vectors[25], face_vectors[75], face_vectors[5]);
            face.magRatio_75_5_76 = (decimal)Maths.Ratio(face_vectors[75], face_vectors[5], face_vectors[76]);
            face.magRatio_5_76_58 = (decimal)Maths.Ratio(face_vectors[5], face_vectors[76], face_vectors[58]);
            face.magRatio_76_58_59 = (decimal)Maths.Ratio(face_vectors[76], face_vectors[58], face_vectors[59]);
            face.magRatio_58_59_93 = (decimal)Maths.Ratio(face_vectors[58], face_vectors[59], face_vectors[93]);
            face.magRatio_59_93_94 = (decimal)Maths.Ratio(face_vectors[59], face_vectors[93], face_vectors[94]);
            face.magRatio_93_94_92 = (decimal)Maths.Ratio(face_vectors[93], face_vectors[94], face_vectors[92]);
            face.magRatio_94_92_5 = (decimal)Maths.Ratio(face_vectors[94], face_vectors[92], face_vectors[5]);
            face.magRatio_92_5_94 = (decimal)Maths.Ratio(face_vectors[92], face_vectors[5], face_vectors[94]);
            face.magRatio_5_94_25 = (decimal)Maths.Ratio(face_vectors[5], face_vectors[94], face_vectors[25]);
            face.magRatio_94_25_58 = (decimal)Maths.Ratio(face_vectors[94], face_vectors[25], face_vectors[58]);
            face.magRatio_25_58_25 = (decimal)Maths.Ratio(face_vectors[25], face_vectors[58], face_vectors[25]);
            face.magRatio_58_25_6 = (decimal)Maths.Ratio(face_vectors[58], face_vectors[25], face_vectors[6]);
            face.magRatio_25_6_42 = (decimal)Maths.Ratio(face_vectors[25], face_vectors[6], face_vectors[42]);
            face.magRatio_6_42_27 = (decimal)Maths.Ratio(face_vectors[6], face_vectors[42], face_vectors[27]);
            face.magRatio_42_27_20 = (decimal)Maths.Ratio(face_vectors[42], face_vectors[27], face_vectors[20]);
            face.magRatio_27_20_95 = (decimal)Maths.Ratio(face_vectors[27], face_vectors[20], face_vectors[95]);
            face.magRatio_20_95_19 = (decimal)Maths.Ratio(face_vectors[20], face_vectors[95], face_vectors[19]);
            face.magRatio_95_19_103 = (decimal)Maths.Ratio(face_vectors[95], face_vectors[19], face_vectors[103]);
            face.magRatio_19_103_23 = (decimal)Maths.Ratio(face_vectors[19], face_vectors[103], face_vectors[23]);
            face.magRatio_103_23_109 = (decimal)Maths.Ratio(face_vectors[103], face_vectors[23], face_vectors[109]);
            face.magRatio_23_109_24 = (decimal)Maths.Ratio(face_vectors[23], face_vectors[109], face_vectors[24]);
            face.magRatio_109_24_101 = (decimal)Maths.Ratio(face_vectors[109], face_vectors[24], face_vectors[101]);
            face.magRatio_24_101_20 = (decimal)Maths.Ratio(face_vectors[24], face_vectors[101], face_vectors[20]);
            face.magRatio_101_20_103 = (decimal)Maths.Ratio(face_vectors[101], face_vectors[20], face_vectors[103]);
            face.magRatio_20_103_72 = (decimal)Maths.Ratio(face_vectors[20], face_vectors[103], face_vectors[72]);
            face.magRatio_103_72_95 = (decimal)Maths.Ratio(face_vectors[103], face_vectors[72], face_vectors[95]);
            face.magRatio_72_95_68 = (decimal)Maths.Ratio(face_vectors[72], face_vectors[95], face_vectors[68]);
            face.magRatio_95_68_19 = (decimal)Maths.Ratio(face_vectors[95], face_vectors[68], face_vectors[19]);
            face.magRatio_68_19_4 = (decimal)Maths.Ratio(face_vectors[68], face_vectors[19], face_vectors[4]);
            face.magRatio_19_4_52 = (decimal)Maths.Ratio(face_vectors[19], face_vectors[4], face_vectors[52]);
            face.magRatio_4_52_96 = (decimal)Maths.Ratio(face_vectors[4], face_vectors[52], face_vectors[96]);
            face.magRatio_52_96_53 = (decimal)Maths.Ratio(face_vectors[52], face_vectors[96], face_vectors[53]);
            face.magRatio_96_53_56 = (decimal)Maths.Ratio(face_vectors[96], face_vectors[53], face_vectors[56]);
            face.magRatio_53_56_104 = (decimal)Maths.Ratio(face_vectors[53], face_vectors[56], face_vectors[104]);
            face.magRatio_56_104_52 = (decimal)Maths.Ratio(face_vectors[56], face_vectors[104], face_vectors[52]);
            face.magRatio_104_52_102 = (decimal)Maths.Ratio(face_vectors[104], face_vectors[52], face_vectors[102]);
            face.magRatio_52_102_110 = (decimal)Maths.Ratio(face_vectors[52], face_vectors[102], face_vectors[110]);
            face.magRatio_102_110_57 = (decimal)Maths.Ratio(face_vectors[102], face_vectors[110], face_vectors[57]);
            face.magRatio_110_57_96 = (decimal)Maths.Ratio(face_vectors[110], face_vectors[57], face_vectors[96]);
            face.magRatio_57_96_57 = (decimal)Maths.Ratio(face_vectors[57], face_vectors[96], face_vectors[57]);
            face.magRatio_96_57_94 = (decimal)Maths.Ratio(face_vectors[96], face_vectors[57], face_vectors[94]);
            face.magRatio_57_94_56 = (decimal)Maths.Ratio(face_vectors[57], face_vectors[94], face_vectors[56]);
            face.magRatio_94_56_74 = (decimal)Maths.Ratio(face_vectors[94], face_vectors[56], face_vectors[74]);
            face.magRatio_56_74_70 = (decimal)Maths.Ratio(face_vectors[56], face_vectors[74], face_vectors[70]);
            face.magRatio_74_70_53 = (decimal)Maths.Ratio(face_vectors[74], face_vectors[70], face_vectors[53]);
            face.magRatio_70_53_43 = (decimal)Maths.Ratio(face_vectors[70], face_vectors[53], face_vectors[43]);
            face.magRatio_53_43_0 = (decimal)Maths.Ratio(face_vectors[53], face_vectors[43], face_vectors[0]);
            face.magRatio_43_0_20 = (decimal)Maths.Ratio(face_vectors[43], face_vectors[0], face_vectors[20]);
            face.magRatio_0_20_53 = (decimal)Maths.Ratio(face_vectors[0], face_vectors[20], face_vectors[53]);
            face.magRatio_20_53_2 = (decimal)Maths.Ratio(face_vectors[20], face_vectors[53], face_vectors[2]);
            face.magRatio_53_2_6 = (decimal)Maths.Ratio(face_vectors[53], face_vectors[2], face_vectors[6]);

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
                Console.WriteLine("Name     :: Total Match           :: Total Difference            :: Mean        ");
                foreach (var found_face in query)
                {
                    FaceMatch fm = new FaceMatch(found_face, face);
                    //decimal closeness = fm.GetMean();
                    decimal closeness = fm.GetTotalDifference();
                    if (closeness > match)
                    {
                        match = closeness;
                        name = found_face.name;
                    }
                    Console.WriteLine(String.Format("Checked {0} :: {1} :: {2} :: {3}",
                        found_face.name, fm.GetTotalMatch(), fm.GetTotalDifference(), fm.GetMean()));

                    Console.WriteLine("checked " + found_face.name + " :: " + closeness);
                }
                //MainWindow
                Console.WriteLine("closest match: " + name + " :: " + match); // write the name of the closest match
                return name;
            }
        }
    }
}
