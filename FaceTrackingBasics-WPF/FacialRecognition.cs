using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KinectTrackerAndBroadcaster.Models;
using KinectTrackerAndBroadcaster.Database;
using System.Windows.Media.Media3D;
using Microsoft.Kinect.Toolkit.FaceTracking;

namespace KinectTrackerAndBroadcaster
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
            return process_face(facePoints3D, ""); // return process_face, passing the points and no name
        }

        /// <summary>
        /// Method called to add the face and name to the database.
        /// </summary>
        /// <param name="frame">the face track frame</param>
        /// <param name="name">the name of the person whose face this is</param>
        /// <returns>the name of the person</returns>
        public String Process(EnumIndexableCollection<FeaturePoint, Vector3DF> facePoints3D, String name)
        {
            return process_face(facePoints3D, name); // return process_face, passing the points and name
        }

        /// <summary>
        /// Method used to process the face track frame.
        /// </summary>
        /// <param name="frame">the face track frame</param>
        /// <param name="name">name of the person or blank</param>
        /// <returns>the name of the person</returns>
        private String process_face(EnumIndexableCollection<FeaturePoint, Vector3DF> facePoints3D, String name)
        {
            // EnumIndexableCollection<FeaturePoint, Vector3DF> facePoints3D = frame.Get3DShape(); // get 3D face vectors
            Unit3D[] face_vectors = new Unit3D[121]; // create Unit3D array for the face vectors

            int index = 0; // index number
            foreach (Vector3DF vector in facePoints3D) // iterate through the points
            {
                Unit3D face_vector = new Unit3D(vector); // convert Vector3DF to Unit3D
                face_vectors[index] = face_vector; // add face vector to array
                index++; // increment index
            }

            Face face = get_face(face_vectors); // returns a face without a name

            if (name == "") // if face is to be recognised
            {
                return get_match(face); // return the name of nearest match to the face
            }
            else // face is to be added to the database
            {
                face.name = name; // set the face name
                add_to_db(face); // add the face to the database
                return name; // return the name
            }
        }

        /// <summary>
        /// Method used to calculate all of the face details, other than the name.
        /// </summary>
        /// <param name="face_vectors">array of Unit3D face vectors</param>
        /// <returns>the face details, but not the name</returns>
        private static Face get_face(Unit3D[] face_vectors)
        {
            Face face = new Face(); // initialize the face
            // calculate angles
            face.angle_0_44_45 = Maths.Angle(face_vectors[0], face_vectors[44], face_vectors[45]);
            face.angle_44_45_47 = Maths.Angle(face_vectors[44], face_vectors[45], face_vectors[47]);
            face.angle_45_47_62 = Maths.Angle(face_vectors[45], face_vectors[47], face_vectors[62]);
            face.angle_47_62_61 = Maths.Angle(face_vectors[47], face_vectors[62], face_vectors[61]);
            face.angle_62_61_63 = Maths.Angle(face_vectors[62], face_vectors[61], face_vectors[63]);
            face.angle_61_63_43 = Maths.Angle(face_vectors[61], face_vectors[63], face_vectors[43]);
            face.angle_63_43_30 = Maths.Angle(face_vectors[63], face_vectors[43], face_vectors[30]);
            face.angle_43_30_28 = Maths.Angle(face_vectors[43], face_vectors[30], face_vectors[28]);
            face.angle_30_28_29 = Maths.Angle(face_vectors[30], face_vectors[28], face_vectors[29]);
            face.angle_28_29_14 = Maths.Angle(face_vectors[28], face_vectors[29], face_vectors[14]);
            face.angle_29_14_12 = Maths.Angle(face_vectors[29], face_vectors[14], face_vectors[12]);
            face.angle_14_12_11 = Maths.Angle(face_vectors[14], face_vectors[12], face_vectors[11]);
            face.angle_12_11_0 = Maths.Angle(face_vectors[12], face_vectors[11], face_vectors[0]);
            face.angle_11_0_34 = Maths.Angle(face_vectors[11], face_vectors[0], face_vectors[34]);
            face.angle_0_34_45 = Maths.Angle(face_vectors[0], face_vectors[34], face_vectors[45]);
            face.angle_34_45_46 = Maths.Angle(face_vectors[34], face_vectors[45], face_vectors[46]);
            face.angle_45_46_47 = Maths.Angle(face_vectors[45], face_vectors[46], face_vectors[47]);
            face.angle_46_47_2 = Maths.Angle(face_vectors[46], face_vectors[47], face_vectors[2]);
            face.angle_47_2_62 = Maths.Angle(face_vectors[47], face_vectors[2], face_vectors[62]);
            face.angle_2_62_60 = Maths.Angle(face_vectors[2], face_vectors[62], face_vectors[60]);
            face.angle_62_60_61 = Maths.Angle(face_vectors[62], face_vectors[60], face_vectors[61]);
            face.angle_60_61_41 = Maths.Angle(face_vectors[60], face_vectors[61], face_vectors[41]);
            face.angle_61_41_63 = Maths.Angle(face_vectors[61], face_vectors[41], face_vectors[63]);
            face.angle_41_63_42 = Maths.Angle(face_vectors[41], face_vectors[63], face_vectors[42]);
            face.angle_63_42_30 = Maths.Angle(face_vectors[63], face_vectors[42], face_vectors[30]);
            face.angle_42_30_27 = Maths.Angle(face_vectors[42], face_vectors[30], face_vectors[27]);
            face.angle_30_27_29 = Maths.Angle(face_vectors[30], face_vectors[27], face_vectors[29]);
            face.angle_27_29_13 = Maths.Angle(face_vectors[27], face_vectors[29], face_vectors[13]);
            face.angle_29_13_12 = Maths.Angle(face_vectors[29], face_vectors[13], face_vectors[12]);
            face.angle_13_12_1 = Maths.Angle(face_vectors[13], face_vectors[12], face_vectors[1]);
            face.angle_12_1_11 = Maths.Angle(face_vectors[12], face_vectors[1], face_vectors[11]);
            face.angle_1_11_2 = Maths.Angle(face_vectors[1], face_vectors[11], face_vectors[2]);
            face.angle_11_2_14 = Maths.Angle(face_vectors[11], face_vectors[2], face_vectors[14]);
            face.angle_2_14_36 = Maths.Angle(face_vectors[2], face_vectors[14], face_vectors[36]);
            face.angle_14_36_13 = Maths.Angle(face_vectors[14], face_vectors[36], face_vectors[13]);
            face.angle_36_13_1 = Maths.Angle(face_vectors[36], face_vectors[13], face_vectors[1]);
            face.angle_13_1_34 = Maths.Angle(face_vectors[13], face_vectors[1], face_vectors[34]);
            face.angle_1_34_46 = Maths.Angle(face_vectors[1], face_vectors[34], face_vectors[46]);
            face.angle_34_46_53 = Maths.Angle(face_vectors[34], face_vectors[46], face_vectors[53]);
            face.angle_46_53_60 = Maths.Angle(face_vectors[46], face_vectors[53], face_vectors[60]);
            face.angle_53_60_59 = Maths.Angle(face_vectors[53], face_vectors[60], face_vectors[59]);
            face.angle_60_59_112 = Maths.Angle(face_vectors[60], face_vectors[59], face_vectors[112]);
            face.angle_59_112_6 = Maths.Angle(face_vectors[59], face_vectors[112], face_vectors[6]);
            face.angle_112_6_111 = Maths.Angle(face_vectors[112], face_vectors[6], face_vectors[111]);
            face.angle_6_111_26 = Maths.Angle(face_vectors[6], face_vectors[111], face_vectors[26]);
            face.angle_111_26_25 = Maths.Angle(face_vectors[111], face_vectors[26], face_vectors[25]);
            face.angle_26_25_75 = Maths.Angle(face_vectors[26], face_vectors[25], face_vectors[75]);
            face.angle_25_75_5 = Maths.Angle(face_vectors[25], face_vectors[75], face_vectors[5]);
            face.angle_75_5_76 = Maths.Angle(face_vectors[75], face_vectors[5], face_vectors[76]);
            face.angle_5_76_58 = Maths.Angle(face_vectors[5], face_vectors[76], face_vectors[58]);
            face.angle_76_58_59 = Maths.Angle(face_vectors[76], face_vectors[58], face_vectors[59]);
            face.angle_58_59_93 = Maths.Angle(face_vectors[58], face_vectors[59], face_vectors[93]);
            face.angle_59_93_94 = Maths.Angle(face_vectors[59], face_vectors[93], face_vectors[94]);
            face.angle_93_94_92 = Maths.Angle(face_vectors[93], face_vectors[94], face_vectors[92]);
            face.angle_94_92_5 = Maths.Angle(face_vectors[94], face_vectors[92], face_vectors[5]);
            face.angle_92_5_94 = Maths.Angle(face_vectors[92], face_vectors[5], face_vectors[94]);
            face.angle_5_94_25 = Maths.Angle(face_vectors[5], face_vectors[94], face_vectors[25]);
            face.angle_94_25_58 = Maths.Angle(face_vectors[94], face_vectors[25], face_vectors[58]);
            face.angle_25_58_25 = Maths.Angle(face_vectors[25], face_vectors[58], face_vectors[25]);
            face.angle_58_25_6 = Maths.Angle(face_vectors[58], face_vectors[25], face_vectors[6]);
            face.angle_25_6_42 = Maths.Angle(face_vectors[25], face_vectors[6], face_vectors[42]);
            face.angle_6_42_27 = Maths.Angle(face_vectors[6], face_vectors[42], face_vectors[27]);
            face.angle_42_27_20 = Maths.Angle(face_vectors[42], face_vectors[27], face_vectors[20]);
            face.angle_27_20_95 = Maths.Angle(face_vectors[27], face_vectors[20], face_vectors[95]);
            face.angle_20_95_19 = Maths.Angle(face_vectors[20], face_vectors[95], face_vectors[19]);
            face.angle_95_19_103 = Maths.Angle(face_vectors[95], face_vectors[19], face_vectors[103]);
            face.angle_19_103_23 = Maths.Angle(face_vectors[19], face_vectors[103], face_vectors[23]);
            face.angle_103_23_109 = Maths.Angle(face_vectors[103], face_vectors[23], face_vectors[109]);
            face.angle_23_109_24 = Maths.Angle(face_vectors[23], face_vectors[109], face_vectors[24]);
            face.angle_109_24_101 = Maths.Angle(face_vectors[109], face_vectors[24], face_vectors[101]);
            face.angle_24_101_20 = Maths.Angle(face_vectors[24], face_vectors[101], face_vectors[20]);
            face.angle_101_20_103 = Maths.Angle(face_vectors[101], face_vectors[20], face_vectors[103]);
            face.angle_20_103_72 = Maths.Angle(face_vectors[20], face_vectors[103], face_vectors[72]);
            face.angle_103_72_95 = Maths.Angle(face_vectors[103], face_vectors[72], face_vectors[95]);
            face.angle_72_95_68 = Maths.Angle(face_vectors[72], face_vectors[95], face_vectors[68]);
            face.angle_95_68_19 = Maths.Angle(face_vectors[95], face_vectors[68], face_vectors[19]);
            face.angle_68_19_4 = Maths.Angle(face_vectors[68], face_vectors[19], face_vectors[4]);
            face.angle_19_4_52 = Maths.Angle(face_vectors[19], face_vectors[4], face_vectors[52]);
            face.angle_4_52_96 = Maths.Angle(face_vectors[4], face_vectors[52], face_vectors[96]);
            face.angle_52_96_53 = Maths.Angle(face_vectors[52], face_vectors[96], face_vectors[53]);
            face.angle_96_53_56 = Maths.Angle(face_vectors[96], face_vectors[53], face_vectors[56]);
            face.angle_53_56_104 = Maths.Angle(face_vectors[53], face_vectors[56], face_vectors[104]);
            face.angle_56_104_52 = Maths.Angle(face_vectors[56], face_vectors[104], face_vectors[52]);
            face.angle_104_52_102 = Maths.Angle(face_vectors[104], face_vectors[52], face_vectors[102]);
            face.angle_52_102_110 = Maths.Angle(face_vectors[52], face_vectors[102], face_vectors[110]);
            face.angle_102_110_57 = Maths.Angle(face_vectors[102], face_vectors[110], face_vectors[57]);
            face.angle_110_57_96 = Maths.Angle(face_vectors[110], face_vectors[57], face_vectors[96]);
            face.angle_57_96_57 = Maths.Angle(face_vectors[57], face_vectors[96], face_vectors[57]);
            face.angle_96_57_94 = Maths.Angle(face_vectors[96], face_vectors[57], face_vectors[94]);
            face.angle_57_94_56 = Maths.Angle(face_vectors[57], face_vectors[94], face_vectors[56]);
            face.angle_94_56_74 = Maths.Angle(face_vectors[94], face_vectors[56], face_vectors[74]);
            face.angle_56_74_70 = Maths.Angle(face_vectors[56], face_vectors[74], face_vectors[70]);
            face.angle_74_70_53 = Maths.Angle(face_vectors[74], face_vectors[70], face_vectors[53]);
            face.angle_70_53_43 = Maths.Angle(face_vectors[70], face_vectors[53], face_vectors[43]);
            face.angle_53_43_0 = Maths.Angle(face_vectors[53], face_vectors[43], face_vectors[0]);
            face.angle_43_0_20 = Maths.Angle(face_vectors[43], face_vectors[0], face_vectors[20]);
            face.angle_0_20_53 = Maths.Angle(face_vectors[0], face_vectors[20], face_vectors[53]);
            face.angle_20_53_2 = Maths.Angle(face_vectors[20], face_vectors[53], face_vectors[2]);
            face.angle_53_2_6 = Maths.Angle(face_vectors[53], face_vectors[2], face_vectors[6]);
            // calculate magnitude ratios
            face.magRatio_0_44_45 = Maths.Ratio(face_vectors[0], face_vectors[44], face_vectors[45]);
            face.magRatio_44_45_47 = Maths.Ratio(face_vectors[44], face_vectors[45], face_vectors[47]);
            face.magRatio_45_47_62 = Maths.Ratio(face_vectors[45], face_vectors[47], face_vectors[62]);
            face.magRatio_47_62_61 = Maths.Ratio(face_vectors[47], face_vectors[62], face_vectors[61]);
            face.magRatio_62_61_63 = Maths.Ratio(face_vectors[62], face_vectors[61], face_vectors[63]);
            face.magRatio_61_63_43 = Maths.Ratio(face_vectors[61], face_vectors[63], face_vectors[43]);
            face.magRatio_63_43_30 = Maths.Ratio(face_vectors[63], face_vectors[43], face_vectors[30]);
            face.magRatio_43_30_28 = Maths.Ratio(face_vectors[43], face_vectors[30], face_vectors[28]);
            face.magRatio_30_28_29 = Maths.Ratio(face_vectors[30], face_vectors[28], face_vectors[29]);
            face.magRatio_28_29_14 = Maths.Ratio(face_vectors[28], face_vectors[29], face_vectors[14]);
            face.magRatio_29_14_12 = Maths.Ratio(face_vectors[29], face_vectors[14], face_vectors[12]);
            face.magRatio_14_12_11 = Maths.Ratio(face_vectors[14], face_vectors[12], face_vectors[11]);
            face.magRatio_12_11_0 = Maths.Ratio(face_vectors[12], face_vectors[11], face_vectors[0]);
            face.magRatio_11_0_34 = Maths.Ratio(face_vectors[11], face_vectors[0], face_vectors[34]);
            face.magRatio_0_34_45 = Maths.Ratio(face_vectors[0], face_vectors[34], face_vectors[45]);
            face.magRatio_34_45_46 = Maths.Ratio(face_vectors[34], face_vectors[45], face_vectors[46]);
            face.magRatio_45_46_47 = Maths.Ratio(face_vectors[45], face_vectors[46], face_vectors[47]);
            face.magRatio_46_47_2 = Maths.Ratio(face_vectors[46], face_vectors[47], face_vectors[2]);
            face.magRatio_47_2_62 = Maths.Ratio(face_vectors[47], face_vectors[2], face_vectors[62]);
            face.magRatio_2_62_60 = Maths.Ratio(face_vectors[2], face_vectors[62], face_vectors[60]);
            face.magRatio_62_60_61 = Maths.Ratio(face_vectors[62], face_vectors[60], face_vectors[61]);
            face.magRatio_60_61_41 = Maths.Ratio(face_vectors[60], face_vectors[61], face_vectors[41]);
            face.magRatio_61_41_63 = Maths.Ratio(face_vectors[61], face_vectors[41], face_vectors[63]);
            face.magRatio_41_63_42 = Maths.Ratio(face_vectors[41], face_vectors[63], face_vectors[42]);
            face.magRatio_63_42_30 = Maths.Ratio(face_vectors[63], face_vectors[42], face_vectors[30]);
            face.magRatio_42_30_27 = Maths.Ratio(face_vectors[42], face_vectors[30], face_vectors[27]);
            face.magRatio_30_27_29 = Maths.Ratio(face_vectors[30], face_vectors[27], face_vectors[29]);
            face.magRatio_27_29_13 = Maths.Ratio(face_vectors[27], face_vectors[29], face_vectors[13]);
            face.magRatio_29_13_12 = Maths.Ratio(face_vectors[29], face_vectors[13], face_vectors[12]);
            face.magRatio_13_12_1 = Maths.Ratio(face_vectors[13], face_vectors[12], face_vectors[1]);
            face.magRatio_12_1_11 = Maths.Ratio(face_vectors[12], face_vectors[1], face_vectors[11]);
            face.magRatio_1_11_2 = Maths.Ratio(face_vectors[1], face_vectors[11], face_vectors[2]);
            face.magRatio_11_2_14 = Maths.Ratio(face_vectors[11], face_vectors[2], face_vectors[14]);
            face.magRatio_2_14_36 = Maths.Ratio(face_vectors[2], face_vectors[14], face_vectors[36]);
            face.magRatio_14_36_13 = Maths.Ratio(face_vectors[14], face_vectors[36], face_vectors[13]);
            face.magRatio_36_13_1 = Maths.Ratio(face_vectors[36], face_vectors[13], face_vectors[1]);
            face.magRatio_13_1_34 = Maths.Ratio(face_vectors[13], face_vectors[1], face_vectors[34]);
            face.magRatio_1_34_46 = Maths.Ratio(face_vectors[1], face_vectors[34], face_vectors[46]);
            face.magRatio_34_46_53 = Maths.Ratio(face_vectors[34], face_vectors[46], face_vectors[53]);
            face.magRatio_46_53_60 = Maths.Ratio(face_vectors[46], face_vectors[53], face_vectors[60]);
            face.magRatio_53_60_59 = Maths.Ratio(face_vectors[53], face_vectors[60], face_vectors[59]);
            face.magRatio_60_59_112 = Maths.Ratio(face_vectors[60], face_vectors[59], face_vectors[112]);
            face.magRatio_59_112_6 = Maths.Ratio(face_vectors[59], face_vectors[112], face_vectors[6]);
            face.magRatio_112_6_111 = Maths.Ratio(face_vectors[112], face_vectors[6], face_vectors[111]);
            face.magRatio_6_111_26 = Maths.Ratio(face_vectors[6], face_vectors[111], face_vectors[26]);
            face.magRatio_111_26_25 = Maths.Ratio(face_vectors[111], face_vectors[26], face_vectors[25]);
            face.magRatio_26_25_75 = Maths.Ratio(face_vectors[26], face_vectors[25], face_vectors[75]);
            face.magRatio_25_75_5 = Maths.Ratio(face_vectors[25], face_vectors[75], face_vectors[5]);
            face.magRatio_75_5_76 = Maths.Ratio(face_vectors[75], face_vectors[5], face_vectors[76]);
            face.magRatio_5_76_58 = Maths.Ratio(face_vectors[5], face_vectors[76], face_vectors[58]);
            face.magRatio_76_58_59 = Maths.Ratio(face_vectors[76], face_vectors[58], face_vectors[59]);
            face.magRatio_58_59_93 = Maths.Ratio(face_vectors[58], face_vectors[59], face_vectors[93]);
            face.magRatio_59_93_94 = Maths.Ratio(face_vectors[59], face_vectors[93], face_vectors[94]);
            face.magRatio_93_94_92 = Maths.Ratio(face_vectors[93], face_vectors[94], face_vectors[92]);
            face.magRatio_94_92_5 = Maths.Ratio(face_vectors[94], face_vectors[92], face_vectors[5]);
            face.magRatio_92_5_94 = Maths.Ratio(face_vectors[92], face_vectors[5], face_vectors[94]);
            face.magRatio_5_94_25 = Maths.Ratio(face_vectors[5], face_vectors[94], face_vectors[25]);
            face.magRatio_94_25_58 = Maths.Ratio(face_vectors[94], face_vectors[25], face_vectors[58]);
            face.magRatio_25_58_25 = Maths.Ratio(face_vectors[25], face_vectors[58], face_vectors[25]);
            face.magRatio_58_25_6 = Maths.Ratio(face_vectors[58], face_vectors[25], face_vectors[6]);
            face.magRatio_25_6_42 = Maths.Ratio(face_vectors[25], face_vectors[6], face_vectors[42]);
            face.magRatio_6_42_27 = Maths.Ratio(face_vectors[6], face_vectors[42], face_vectors[27]);
            face.magRatio_42_27_20 = Maths.Ratio(face_vectors[42], face_vectors[27], face_vectors[20]);
            face.magRatio_27_20_95 = Maths.Ratio(face_vectors[27], face_vectors[20], face_vectors[95]);
            face.magRatio_20_95_19 = Maths.Ratio(face_vectors[20], face_vectors[95], face_vectors[19]);
            face.magRatio_95_19_103 = Maths.Ratio(face_vectors[95], face_vectors[19], face_vectors[103]);
            face.magRatio_19_103_23 = Maths.Ratio(face_vectors[19], face_vectors[103], face_vectors[23]);
            face.magRatio_103_23_109 = Maths.Ratio(face_vectors[103], face_vectors[23], face_vectors[109]);
            face.magRatio_23_109_24 = Maths.Ratio(face_vectors[23], face_vectors[109], face_vectors[24]);
            face.magRatio_109_24_101 = Maths.Ratio(face_vectors[109], face_vectors[24], face_vectors[101]);
            face.magRatio_24_101_20 = Maths.Ratio(face_vectors[24], face_vectors[101], face_vectors[20]);
            face.magRatio_101_20_103 = Maths.Ratio(face_vectors[101], face_vectors[20], face_vectors[103]);
            face.magRatio_20_103_72 = Maths.Ratio(face_vectors[20], face_vectors[103], face_vectors[72]);
            face.magRatio_103_72_95 = Maths.Ratio(face_vectors[103], face_vectors[72], face_vectors[95]);
            face.magRatio_72_95_68 = Maths.Ratio(face_vectors[72], face_vectors[95], face_vectors[68]);
            face.magRatio_95_68_19 = Maths.Ratio(face_vectors[95], face_vectors[68], face_vectors[19]);
            face.magRatio_68_19_4 = Maths.Ratio(face_vectors[68], face_vectors[19], face_vectors[4]);
            face.magRatio_19_4_52 = Maths.Ratio(face_vectors[19], face_vectors[4], face_vectors[52]);
            face.magRatio_4_52_96 = Maths.Ratio(face_vectors[4], face_vectors[52], face_vectors[96]);
            face.magRatio_52_96_53 = Maths.Ratio(face_vectors[52], face_vectors[96], face_vectors[53]);
            face.magRatio_96_53_56 = Maths.Ratio(face_vectors[96], face_vectors[53], face_vectors[56]);
            face.magRatio_53_56_104 = Maths.Ratio(face_vectors[53], face_vectors[56], face_vectors[104]);
            face.magRatio_56_104_52 = Maths.Ratio(face_vectors[56], face_vectors[104], face_vectors[52]);
            face.magRatio_104_52_102 = Maths.Ratio(face_vectors[104], face_vectors[52], face_vectors[102]);
            face.magRatio_52_102_110 = Maths.Ratio(face_vectors[52], face_vectors[102], face_vectors[110]);
            face.magRatio_102_110_57 = Maths.Ratio(face_vectors[102], face_vectors[110], face_vectors[57]);
            face.magRatio_110_57_96 = Maths.Ratio(face_vectors[110], face_vectors[57], face_vectors[96]);
            face.magRatio_57_96_57 = Maths.Ratio(face_vectors[57], face_vectors[96], face_vectors[57]);
            face.magRatio_96_57_94 = Maths.Ratio(face_vectors[96], face_vectors[57], face_vectors[94]);
            face.magRatio_57_94_56 = Maths.Ratio(face_vectors[57], face_vectors[94], face_vectors[56]);
            face.magRatio_94_56_74 = Maths.Ratio(face_vectors[94], face_vectors[56], face_vectors[74]);
            face.magRatio_56_74_70 = Maths.Ratio(face_vectors[56], face_vectors[74], face_vectors[70]);
            face.magRatio_74_70_53 = Maths.Ratio(face_vectors[74], face_vectors[70], face_vectors[53]);
            face.magRatio_70_53_43 = Maths.Ratio(face_vectors[70], face_vectors[53], face_vectors[43]);
            face.magRatio_53_43_0 = Maths.Ratio(face_vectors[53], face_vectors[43], face_vectors[0]);
            face.magRatio_43_0_20 = Maths.Ratio(face_vectors[43], face_vectors[0], face_vectors[20]);
            face.magRatio_0_20_53 = Maths.Ratio(face_vectors[0], face_vectors[20], face_vectors[53]);
            face.magRatio_20_53_2 = Maths.Ratio(face_vectors[20], face_vectors[53], face_vectors[2]);
            face.magRatio_53_2_6 = Maths.Ratio(face_vectors[53], face_vectors[2], face_vectors[6]);
            return face; // return the face
        }

        /// <summary>
        /// add face data and name to database
        /// </summary>
        /// <param name="face">face data</param>
        private static void add_to_db(Face face)
        {
            using (var db = new Database.Database()) // use the database
            {
                db.Faces.Add(face); // add the face to the database
                db.SaveChanges(); // update the database
            }
        }

        /// <summary>
        /// compare face with faces in the database to find closest match
        /// </summary>
        /// <param name="face">face data</param>
        /// <returns>the name of the closest match</returns>
        private static String get_match(Face face)
        {
            using (var db = new Database.Database()) // using the database
            {
                double match = Double.MinValue; // the closest match
                string name = ""; // name of the closest match

                // get all faces from the database
                var query = from b in db.Faces
                            where b.version == null
                            orderby b.name
                            select b;

                Console.WriteLine("Searching database...");
                Console.WriteLine("Name       :: Total Match                 :: Total Difference                        :: Mean        ");

                List<FaceMatch> faceMatches = new List<FaceMatch> { }; // list of all face comparisons

                foreach (var found_face in query) // iterate faces from database
                {
                    FaceMatch fm = new FaceMatch(found_face, face); // compare database face with unknown face
                    faceMatches.Add(fm); // add comparison to list
                    //decimal closeness = fm.GetMean();
                    /*
                    decimal closeness = fm.GetMatchCount();
                    if (closeness > match)
                    {
                        match = closeness;
                        name = found_face.name;
                    }
                    Console.WriteLine(String.Format("Checked {0} :: {1} :: {2} :: {3}",
                        found_face.name, fm.GetMatchCount(), fm.GetTotalMatch(), fm.GetMean()));
                    */
                    //Console.WriteLine("checked " + found_face.name + " :: " + closeness);
                }

                foreach (FaceMatch a in faceMatches) // itereate all face comparisons
                {
                    string nameA = a.Name; // get the name
                    double facesCount = 0; // total compaisons with the same name
                    double matchCountTotal = 0; // total match
                    foreach (FaceMatch b in faceMatches) // iterate all face comparisons
                    {
                        if (nameA == b.Name) // if names are the same
                        {
                            facesCount++; // increment count
                            matchCountTotal += b.GetMatchCount(); // increase the total match
                        }
                    }
                    a.AverageMatchCount = matchCountTotal / facesCount; // set the average match for this person
                }

                foreach (FaceMatch fm in faceMatches) // iterate all face comparisons
                {
                    double closeness = fm.AverageMatchCount; // get the average face match
                    if (closeness > match) // if match is closer than previous comparisons
                    {
                        match = closeness; // set new closest match
                        name = fm.Name; // set the name
                    }
                    Console.WriteLine(String.Format("Checked {0} :: {1} :: {2} :: {3} :: {4}",
                        fm.Name,closeness, fm.GetMatchCount(), fm.GetTotalMatch(), fm.GetMean()));
                }

                //MainWindow
                Console.WriteLine("closest match: " + name + " :: " + match); // write the name of the closest match
                return name; // return name of the closest match
            }
        }
    }
}
