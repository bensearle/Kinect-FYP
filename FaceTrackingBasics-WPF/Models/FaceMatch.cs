using KinectTrackerAndBroadcaster.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectTrackerAndBroadcaster.Models
{
    public class FaceMatch
    {
        public String Name { get; set; } // name of the person
        private Face faceA { get; set; } // the face of the known person
        private Face faceB { get; set; } // the face of the unknown person
        private List<decimal?> matches = new List<decimal?>(); // list of 

        private decimal total = 0; // total sum of matches
        private int count = 0; // total count of matches
        private decimal mean; // mean average of the matches (total/count)
        private decimal lowest = 1; // the lowest match
        private decimal totalDifference = 0; // sum of all differnces between 1 and match
        private decimal totalMatch = 1; // 1 - totalDifference
        private int matchCount = 0; // how many of the matches are above n% accuracy

        public decimal AverageMatchCount { get; set; } // the average match count for people with this name

        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="a">the known face</param>
        /// <param name="b">the face to be compared against</param>
        public FaceMatch(Face a, Face b)
        {
            // set local variables
            Name = a.name;
            faceA = a;
            faceB = b;
            // call methods
            getMatches();
            calculateAverages();
        }

        /// <summary>
        /// get the mean average
        /// </summary>
        /// <returns>mean average</returns>
        public decimal GetMean()
        {
            return mean;
        }

        /// <summary>
        /// get the lowest match
        /// </summary>
        /// <returns>lowest match</returns>
        public decimal GetLowest()
        {
            return lowest;
        }

        /// <summary>
        /// get the total difference between 1 and match
        /// </summary>
        /// <returns>total difference</returns>
        public decimal GetTotalDifference()
        {
            return totalDifference;
        }

        /// <summary>
        /// get the total match
        /// </summary>
        /// <returns>1-totalDifference</returns>
        public decimal GetTotalMatch()
        {
            return totalMatch;
        }

        /// <summary>
        /// get the count of matches above n% accuracy
        /// </summary>
        /// <returns>count of matches</returns>
        public int GetMatchCount()
        {
            return matchCount;
        }

        /// <summary>
        /// calculate all of the averages
        /// </summary>
        private void calculateAverages()
        {
            foreach (decimal match in matches) // iterate through the matches
            {
                total += match; // add to the total
                count++; // increment count
                totalDifference += 1 - match;
                if (match < lowest) // if match is lowest so far
                {
                    lowest = match; // set match to be lowest
                }
                if (match > .9999m) // if match is more than 99.99% accurate
                {
                    matchCount++; // increment the matches about n% accuracy
                }
            }
            totalMatch = 1 - totalDifference;
            mean = total / count; // calculate mean
        }

        /// <summary>
        /// get all of the matches between faceA data and faceB data
        /// </summary>
        private void getMatches()
        {
            // matches for angles
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_1_0_34, (decimal)faceB.angle_1_0_34));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_11_0_44, (decimal)faceB.angle_11_0_44));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_12_11_0, (decimal)faceB.angle_12_11_0));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_0_44_45, (decimal)faceB.angle_0_44_45));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_11_12_14, (decimal)faceB.angle_11_12_14));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_44_45_47, (decimal)faceB.angle_44_45_47));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_12_14_29, (decimal)faceB.angle_12_14_29));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_45_47_62, (decimal)faceB.angle_45_47_62));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_14_29_28, (decimal)faceB.angle_14_29_28));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_47_62_61, (decimal)faceB.angle_47_62_61));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_29_28_30, (decimal)faceB.angle_29_28_30));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_62_61_63, (decimal)faceB.angle_62_61_63));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_28_30_43, (decimal)faceB.angle_28_30_43));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_61_63_43, (decimal)faceB.angle_61_63_43));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_30_43_63, (decimal)faceB.angle_30_43_63));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_30_42_63, (decimal)faceB.angle_30_42_63));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_30_41_63, (decimal)faceB.angle_30_41_63));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_41_61_60, (decimal)faceB.angle_41_61_60));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_41_28_27, (decimal)faceB.angle_41_28_27));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_27_29_2, (decimal)faceB.angle_27_29_2));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_60_62_2, (decimal)faceB.angle_60_62_2));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_14_2_29, (decimal)faceB.angle_14_2_29));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_47_2_62, (decimal)faceB.angle_47_2_62));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_1_3_34, (decimal)faceB.angle_1_3_34));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_13_3_46, (decimal)faceB.angle_13_3_46));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_34_46_53, (decimal)faceB.angle_34_46_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_1_13_20, (decimal)faceB.angle_1_13_20));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_13_20_27, (decimal)faceB.angle_13_20_27));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_46_53_60, (decimal)faceB.angle_46_53_60));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_20_27_26, (decimal)faceB.angle_20_27_26));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_53_60_59, (decimal)faceB.angle_53_60_59));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_14_1_34, (decimal)faceB.angle_14_1_34));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_47_34_1, (decimal)faceB.angle_47_34_1));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_23_3_56, (decimal)faceB.angle_23_3_56));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_20_3_53, (decimal)faceB.angle_20_3_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_26_4_59, (decimal)faceB.angle_26_4_59));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_92_4_93, (decimal)faceB.angle_92_4_93));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_92_94_93, (decimal)faceB.angle_92_94_93));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_75_94_76, (decimal)faceB.angle_75_94_76));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_26_25_94, (decimal)faceB.angle_26_25_94));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_59_58_94, (decimal)faceB.angle_59_58_94));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_111_26_25, (decimal)faceB.angle_111_26_25));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_112_59_58, (decimal)faceB.angle_112_59_58));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_26_111_75, (decimal)faceB.angle_26_111_75));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_59_112_76, (decimal)faceB.angle_59_112_76));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_75_6_76, (decimal)faceB.angle_75_6_76));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_25_5_58, (decimal)faceB.angle_25_5_58));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_20_95_19, (decimal)faceB.angle_20_95_19));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_95_19_103, (decimal)faceB.angle_95_19_103));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_19_103_23, (decimal)faceB.angle_19_103_23));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_103_23_109, (decimal)faceB.angle_103_23_109));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_23_109_24, (decimal)faceB.angle_23_109_24));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_109_24_103, (decimal)faceB.angle_109_24_103));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_24_103_20, (decimal)faceB.angle_24_103_20));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_103_20_95, (decimal)faceB.angle_103_20_95));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_56_104_52, (decimal)faceB.angle_56_104_52));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_104_52_96, (decimal)faceB.angle_104_52_96));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_52_96_53, (decimal)faceB.angle_52_96_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_96_53_102, (decimal)faceB.angle_96_53_102));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_53_102_57, (decimal)faceB.angle_53_102_57));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_102_57_110, (decimal)faceB.angle_102_57_110));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_57_110_56, (decimal)faceB.angle_57_110_56));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_110_56_104, (decimal)faceB.angle_110_56_104));

            // matches for magnitude ratios
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_0_43_12_45, (decimal)faceB.magRatio_0_43_12_45));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_0_43_14_47, (decimal)faceB.magRatio_0_43_14_47));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_0_43_29_62, (decimal)faceB.magRatio_0_43_29_62));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_0_43_28_61, (decimal)faceB.magRatio_0_43_28_61));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_0_43_30_63, (decimal)faceB.magRatio_0_43_30_63));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_0_2_2_43, (decimal)faceB.magRatio_0_2_2_43));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_2_4_4_43, (decimal)faceB.magRatio_2_4_4_43));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_4_6_6_43, (decimal)faceB.magRatio_4_6_6_43));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_6_42_42_43, (decimal)faceB.magRatio_6_42_42_43));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_29_62_20_53, (decimal)faceB.magRatio_29_62_20_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_23_56_20_53, (decimal)faceB.magRatio_23_56_20_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_94_5_26_59, (decimal)faceB.magRatio_94_5_26_59));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_4_6_26_59, (decimal)faceB.magRatio_4_6_26_59));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_23_56_26_59, (decimal)faceB.magRatio_23_56_26_59));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_92_93_26_59, (decimal)faceB.magRatio_92_93_26_59));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_25_58_26_59, (decimal)faceB.magRatio_25_58_26_59));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_75_76_26_59, (decimal)faceB.magRatio_75_76_26_59));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_20_23_19_24, (decimal)faceB.magRatio_20_23_19_24));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_20_23_29_4, (decimal)faceB.magRatio_20_23_29_4));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_20_23_56_53, (decimal)faceB.magRatio_20_23_56_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_4_62_56_53, (decimal)faceB.magRatio_4_62_56_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_52_57_56_53, (decimal)faceB.magRatio_52_57_56_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_30_63_41_43, (decimal)faceB.magRatio_30_63_41_43));
        }

        /// <summary>
        /// get all of the matches between faceA data and faceB data
        /// </summary>
        private void getMatches_submissionVersion()
        {
            // matches for angles
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_0_44_45, (decimal)faceB.angle_0_44_45));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_44_45_47, (decimal)faceB.angle_44_45_47));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_45_47_62, (decimal)faceB.angle_45_47_62));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_47_62_61, (decimal)faceB.angle_47_62_61));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_62_61_63, (decimal)faceB.angle_62_61_63));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_61_63_43, (decimal)faceB.angle_61_63_43));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_63_43_30, (decimal)faceB.angle_63_43_30));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_43_30_28, (decimal)faceB.angle_43_30_28));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_30_28_29, (decimal)faceB.angle_30_28_29));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_28_29_14, (decimal)faceB.angle_28_29_14));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_29_14_12, (decimal)faceB.angle_29_14_12));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_14_12_11, (decimal)faceB.angle_14_12_11));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_12_11_0, (decimal)faceB.angle_12_11_0));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_11_0_34, (decimal)faceB.angle_11_0_34));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_0_34_45, (decimal)faceB.angle_0_34_45));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_34_45_46, (decimal)faceB.angle_34_45_46));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_45_46_47, (decimal)faceB.angle_45_46_47));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_46_47_2, (decimal)faceB.angle_46_47_2));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_47_2_62, (decimal)faceB.angle_47_2_62));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_2_62_60, (decimal)faceB.angle_2_62_60));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_62_60_61, (decimal)faceB.angle_62_60_61));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_60_61_41, (decimal)faceB.angle_60_61_41));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_61_41_63, (decimal)faceB.angle_61_41_63));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_41_63_42, (decimal)faceB.angle_41_63_42));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_63_42_30, (decimal)faceB.angle_63_42_30));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_42_30_27, (decimal)faceB.angle_42_30_27));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_30_27_29, (decimal)faceB.angle_30_27_29));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_27_29_13, (decimal)faceB.angle_27_29_13));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_29_13_12, (decimal)faceB.angle_29_13_12));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_13_12_1, (decimal)faceB.angle_13_12_1));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_12_1_11, (decimal)faceB.angle_12_1_11));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_1_11_2, (decimal)faceB.angle_1_11_2));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_11_2_14, (decimal)faceB.angle_11_2_14));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_2_14_36, (decimal)faceB.angle_2_14_36));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_14_36_13, (decimal)faceB.angle_14_36_13));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_36_13_1, (decimal)faceB.angle_36_13_1));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_13_1_34, (decimal)faceB.angle_13_1_34));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_1_34_46, (decimal)faceB.angle_1_34_46));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_34_46_53, (decimal)faceB.angle_34_46_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_46_53_60, (decimal)faceB.angle_46_53_60));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_53_60_59, (decimal)faceB.angle_53_60_59));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_60_59_112, (decimal)faceB.angle_60_59_112));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_59_112_6, (decimal)faceB.angle_59_112_6));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_112_6_111, (decimal)faceB.angle_112_6_111));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_6_111_26, (decimal)faceB.angle_6_111_26));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_111_26_25, (decimal)faceB.angle_111_26_25));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_26_25_75, (decimal)faceB.angle_26_25_75));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_25_75_5, (decimal)faceB.angle_25_75_5));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_75_5_76, (decimal)faceB.angle_75_5_76));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_5_76_58, (decimal)faceB.angle_5_76_58));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_76_58_59, (decimal)faceB.angle_76_58_59));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_58_59_93, (decimal)faceB.angle_58_59_93));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_59_93_94, (decimal)faceB.angle_59_93_94));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_93_94_92, (decimal)faceB.angle_93_94_92));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_94_92_5, (decimal)faceB.angle_94_92_5));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_92_5_94, (decimal)faceB.angle_92_5_94));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_5_94_25, (decimal)faceB.angle_5_94_25));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_94_25_58, (decimal)faceB.angle_94_25_58));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_25_58_25, (decimal)faceB.angle_25_58_25));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_58_25_6, (decimal)faceB.angle_58_25_6));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_25_6_42, (decimal)faceB.angle_25_6_42));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_6_42_27, (decimal)faceB.angle_6_42_27));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_42_27_20, (decimal)faceB.angle_42_27_20));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_27_20_95, (decimal)faceB.angle_27_20_95));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_20_95_19, (decimal)faceB.angle_20_95_19));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_95_19_103, (decimal)faceB.angle_95_19_103));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_19_103_23, (decimal)faceB.angle_19_103_23));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_103_23_109, (decimal)faceB.angle_103_23_109));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_23_109_24, (decimal)faceB.angle_23_109_24));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_109_24_101, (decimal)faceB.angle_109_24_101));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_24_101_20, (decimal)faceB.angle_24_101_20));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_101_20_103, (decimal)faceB.angle_101_20_103));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_20_103_72, (decimal)faceB.angle_20_103_72));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_103_72_95, (decimal)faceB.angle_103_72_95));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_72_95_68, (decimal)faceB.angle_72_95_68));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_95_68_19, (decimal)faceB.angle_95_68_19));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_68_19_4, (decimal)faceB.angle_68_19_4));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_19_4_52, (decimal)faceB.angle_19_4_52));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_4_52_96, (decimal)faceB.angle_4_52_96));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_52_96_53, (decimal)faceB.angle_52_96_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_96_53_56, (decimal)faceB.angle_96_53_56));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_53_56_104, (decimal)faceB.angle_53_56_104));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_56_104_52, (decimal)faceB.angle_56_104_52));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_104_52_102, (decimal)faceB.angle_104_52_102));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_52_102_110, (decimal)faceB.angle_52_102_110));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_102_110_57, (decimal)faceB.angle_102_110_57));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_110_57_96, (decimal)faceB.angle_110_57_96));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_57_96_57, (decimal)faceB.angle_57_96_57));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_96_57_94, (decimal)faceB.angle_96_57_94));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_57_94_56, (decimal)faceB.angle_57_94_56));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_94_56_74, (decimal)faceB.angle_94_56_74));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_56_74_70, (decimal)faceB.angle_56_74_70));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_74_70_53, (decimal)faceB.angle_74_70_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_70_53_43, (decimal)faceB.angle_70_53_43));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_53_43_0, (decimal)faceB.angle_53_43_0));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_43_0_20, (decimal)faceB.angle_43_0_20));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_0_20_53, (decimal)faceB.angle_0_20_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_20_53_2, (decimal)faceB.angle_20_53_2));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_53_2_6, (decimal)faceB.angle_53_2_6));

            // matches for magnitude ratios
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_0_44_45, (decimal)faceB.magRatio_0_44_45));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_44_45_47, (decimal)faceB.magRatio_44_45_47));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_45_47_62, (decimal)faceB.magRatio_45_47_62));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_47_62_61, (decimal)faceB.magRatio_47_62_61));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_62_61_63, (decimal)faceB.magRatio_62_61_63));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_61_63_43, (decimal)faceB.magRatio_61_63_43));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_63_43_30, (decimal)faceB.magRatio_63_43_30));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_43_30_28, (decimal)faceB.magRatio_43_30_28));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_30_28_29, (decimal)faceB.magRatio_30_28_29));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_28_29_14, (decimal)faceB.magRatio_28_29_14));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_29_14_12, (decimal)faceB.magRatio_29_14_12));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_14_12_11, (decimal)faceB.magRatio_14_12_11));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_12_11_0, (decimal)faceB.magRatio_12_11_0));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_11_0_34, (decimal)faceB.magRatio_11_0_34));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_0_34_45, (decimal)faceB.magRatio_0_34_45));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_34_45_46, (decimal)faceB.magRatio_34_45_46));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_45_46_47, (decimal)faceB.magRatio_45_46_47));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_46_47_2, (decimal)faceB.magRatio_46_47_2));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_47_2_62, (decimal)faceB.magRatio_47_2_62));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_2_62_60, (decimal)faceB.magRatio_2_62_60));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_62_60_61, (decimal)faceB.magRatio_62_60_61));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_60_61_41, (decimal)faceB.magRatio_60_61_41));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_61_41_63, (decimal)faceB.magRatio_61_41_63));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_41_63_42, (decimal)faceB.magRatio_41_63_42));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_63_42_30, (decimal)faceB.magRatio_63_42_30));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_42_30_27, (decimal)faceB.magRatio_42_30_27));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_30_27_29, (decimal)faceB.magRatio_30_27_29));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_27_29_13, (decimal)faceB.magRatio_27_29_13));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_29_13_12, (decimal)faceB.magRatio_29_13_12));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_13_12_1, (decimal)faceB.magRatio_13_12_1));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_12_1_11, (decimal)faceB.magRatio_12_1_11));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_1_11_2, (decimal)faceB.magRatio_1_11_2));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_11_2_14, (decimal)faceB.magRatio_11_2_14));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_2_14_36, (decimal)faceB.magRatio_2_14_36));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_14_36_13, (decimal)faceB.magRatio_14_36_13));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_36_13_1, (decimal)faceB.magRatio_36_13_1));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_13_1_34, (decimal)faceB.magRatio_13_1_34));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_1_34_46, (decimal)faceB.magRatio_1_34_46));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_34_46_53, (decimal)faceB.magRatio_34_46_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_46_53_60, (decimal)faceB.magRatio_46_53_60));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_53_60_59, (decimal)faceB.magRatio_53_60_59));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_60_59_112, (decimal)faceB.magRatio_60_59_112));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_59_112_6, (decimal)faceB.magRatio_59_112_6));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_112_6_111, (decimal)faceB.magRatio_112_6_111));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_6_111_26, (decimal)faceB.magRatio_6_111_26));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_111_26_25, (decimal)faceB.magRatio_111_26_25));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_26_25_75, (decimal)faceB.magRatio_26_25_75));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_25_75_5, (decimal)faceB.magRatio_25_75_5));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_75_5_76, (decimal)faceB.magRatio_75_5_76));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_5_76_58, (decimal)faceB.magRatio_5_76_58));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_76_58_59, (decimal)faceB.magRatio_76_58_59));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_58_59_93, (decimal)faceB.magRatio_58_59_93));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_59_93_94, (decimal)faceB.magRatio_59_93_94));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_93_94_92, (decimal)faceB.magRatio_93_94_92));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_94_92_5, (decimal)faceB.magRatio_94_92_5));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_92_5_94, (decimal)faceB.magRatio_92_5_94));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_5_94_25, (decimal)faceB.magRatio_5_94_25));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_94_25_58, (decimal)faceB.magRatio_94_25_58));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_25_58_25, (decimal)faceB.magRatio_25_58_25));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_58_25_6, (decimal)faceB.magRatio_58_25_6));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_25_6_42, (decimal)faceB.magRatio_25_6_42));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_6_42_27, (decimal)faceB.magRatio_6_42_27));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_42_27_20, (decimal)faceB.magRatio_42_27_20));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_27_20_95, (decimal)faceB.magRatio_27_20_95));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_20_95_19, (decimal)faceB.magRatio_20_95_19));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_95_19_103, (decimal)faceB.magRatio_95_19_103));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_19_103_23, (decimal)faceB.magRatio_19_103_23));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_103_23_109, (decimal)faceB.magRatio_103_23_109));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_23_109_24, (decimal)faceB.magRatio_23_109_24));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_109_24_101, (decimal)faceB.magRatio_109_24_101));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_24_101_20, (decimal)faceB.magRatio_24_101_20));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_101_20_103, (decimal)faceB.magRatio_101_20_103));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_20_103_72, (decimal)faceB.magRatio_20_103_72));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_103_72_95, (decimal)faceB.magRatio_103_72_95));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_72_95_68, (decimal)faceB.magRatio_72_95_68));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_95_68_19, (decimal)faceB.magRatio_95_68_19));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_68_19_4, (decimal)faceB.magRatio_68_19_4));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_19_4_52, (decimal)faceB.magRatio_19_4_52));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_4_52_96, (decimal)faceB.magRatio_4_52_96));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_52_96_53, (decimal)faceB.magRatio_52_96_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_96_53_56, (decimal)faceB.magRatio_96_53_56));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_53_56_104, (decimal)faceB.magRatio_53_56_104));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_56_104_52, (decimal)faceB.magRatio_56_104_52));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_104_52_102, (decimal)faceB.magRatio_104_52_102));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_52_102_110, (decimal)faceB.magRatio_52_102_110));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_102_110_57, (decimal)faceB.magRatio_102_110_57));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_110_57_96, (decimal)faceB.magRatio_110_57_96));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_57_96_57, (decimal)faceB.magRatio_57_96_57));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_96_57_94, (decimal)faceB.magRatio_96_57_94));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_57_94_56, (decimal)faceB.magRatio_57_94_56));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_94_56_74, (decimal)faceB.magRatio_94_56_74));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_56_74_70, (decimal)faceB.magRatio_56_74_70));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_74_70_53, (decimal)faceB.magRatio_74_70_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_70_53_43, (decimal)faceB.magRatio_70_53_43));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_53_43_0, (decimal)faceB.magRatio_53_43_0));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_43_0_20, (decimal)faceB.magRatio_43_0_20));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_0_20_53, (decimal)faceB.magRatio_0_20_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_20_53_2, (decimal)faceB.magRatio_20_53_2));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_53_2_6, (decimal)faceB.magRatio_53_2_6));
        }
    }
}
