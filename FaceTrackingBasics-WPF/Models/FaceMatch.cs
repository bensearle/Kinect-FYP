﻿using FaceTrackingBasics.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceTrackingBasics.Models
{
    public class FaceMatch
    {
        private Face faceA { get; set; }
        private Face faceB { get; set; }
        private List<decimal?> matches;

        private decimal total = 0;
        private int count = 0;
        private decimal mean;
       /* public double median { get; set; }
        public double maximum { get; set; }
        public double minimum { get; set; }
        public double range { get; set; }
        public double standard_deviation { get; set; }
        */
        public FaceMatch(Face a, Face b)
        {
            faceA = a;
            faceB = b;
            getMatches();
            getAverages();
        }

        public decimal getMean(){
            return mean;
        }

        private void getAverages()
        {
            foreach (decimal match in matches)
            {
                total += match; // add to the total
                count++; // increment to count
            }
            mean = total / count;
        }

        private void getMatches()
        {

            matches.Add(Maths.NumericMatch((decimal)faceA.angle_0_1, (decimal)faceB.angle_0_1));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_1_2, (decimal)faceB.angle_1_2));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_2_3, (decimal)faceB.angle_2_3));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_3_4, (decimal)faceB.angle_3_4));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_4_5, (decimal)faceB.angle_4_5));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_5_6, (decimal)faceB.angle_5_6));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_6_7, (decimal)faceB.angle_6_7));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_7_8, (decimal)faceB.angle_7_8));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_8_9, (decimal)faceB.angle_8_9));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_9_10, (decimal)faceB.angle_9_10));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_10_11, (decimal)faceB.angle_10_11));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_11_12, (decimal)faceB.angle_11_12));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_12_13, (decimal)faceB.angle_12_13));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_13_14, (decimal)faceB.angle_13_14));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_14_15, (decimal)faceB.angle_14_15));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_15_16, (decimal)faceB.angle_15_16));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_16_17, (decimal)faceB.angle_16_17));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_17_18, (decimal)faceB.angle_17_18));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_18_19, (decimal)faceB.angle_18_19));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_19_20, (decimal)faceB.angle_19_20));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_20_21, (decimal)faceB.angle_20_21));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_21_22, (decimal)faceB.angle_21_22));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_22_23, (decimal)faceB.angle_22_23));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_23_24, (decimal)faceB.angle_23_24));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_24_25, (decimal)faceB.angle_24_25));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_25_26, (decimal)faceB.angle_25_26));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_26_27, (decimal)faceB.angle_26_27));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_27_28, (decimal)faceB.angle_27_28));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_28_29, (decimal)faceB.angle_28_29));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_29_30, (decimal)faceB.angle_29_30));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_30_31, (decimal)faceB.angle_30_31));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_31_32, (decimal)faceB.angle_31_32));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_32_33, (decimal)faceB.angle_32_33));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_33_34, (decimal)faceB.angle_33_34));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_34_35, (decimal)faceB.angle_34_35));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_35_36, (decimal)faceB.angle_35_36));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_36_37, (decimal)faceB.angle_36_37));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_37_38, (decimal)faceB.angle_37_38));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_38_39, (decimal)faceB.angle_38_39));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_39_40, (decimal)faceB.angle_39_40));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_40_41, (decimal)faceB.angle_40_41));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_41_42, (decimal)faceB.angle_41_42));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_42_43, (decimal)faceB.angle_42_43));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_43_44, (decimal)faceB.angle_43_44));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_44_45, (decimal)faceB.angle_44_45));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_45_46, (decimal)faceB.angle_45_46));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_46_47, (decimal)faceB.angle_46_47));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_47_48, (decimal)faceB.angle_47_48));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_48_49, (decimal)faceB.angle_48_49));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_49_50, (decimal)faceB.angle_49_50));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_50_51, (decimal)faceB.angle_50_51));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_51_52, (decimal)faceB.angle_51_52));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_52_53, (decimal)faceB.angle_52_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_53_54, (decimal)faceB.angle_53_54));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_54_55, (decimal)faceB.angle_54_55));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_55_56, (decimal)faceB.angle_55_56));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_56_57, (decimal)faceB.angle_56_57));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_57_58, (decimal)faceB.angle_57_58));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_58_59, (decimal)faceB.angle_58_59));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_59_60, (decimal)faceB.angle_59_60));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_60_61, (decimal)faceB.angle_60_61));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_61_62, (decimal)faceB.angle_61_62));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_62_63, (decimal)faceB.angle_62_63));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_63_64, (decimal)faceB.angle_63_64));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_64_65, (decimal)faceB.angle_64_65));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_65_66, (decimal)faceB.angle_65_66));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_66_67, (decimal)faceB.angle_66_67));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_67_68, (decimal)faceB.angle_67_68));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_68_69, (decimal)faceB.angle_68_69));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_69_70, (decimal)faceB.angle_69_70));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_70_71, (decimal)faceB.angle_70_71));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_71_72, (decimal)faceB.angle_71_72));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_72_73, (decimal)faceB.angle_72_73));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_73_74, (decimal)faceB.angle_73_74));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_74_75, (decimal)faceB.angle_74_75));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_75_76, (decimal)faceB.angle_75_76));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_76_77, (decimal)faceB.angle_76_77));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_77_78, (decimal)faceB.angle_77_78));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_78_79, (decimal)faceB.angle_78_79));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_79_80, (decimal)faceB.angle_79_80));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_80_81, (decimal)faceB.angle_80_81));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_81_82, (decimal)faceB.angle_81_82));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_82_83, (decimal)faceB.angle_82_83));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_83_84, (decimal)faceB.angle_83_84));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_84_85, (decimal)faceB.angle_84_85));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_85_86, (decimal)faceB.angle_85_86));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_86_87, (decimal)faceB.angle_86_87));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_87_88, (decimal)faceB.angle_87_88));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_88_89, (decimal)faceB.angle_88_89));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_89_90, (decimal)faceB.angle_89_90));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_90_91, (decimal)faceB.angle_90_91));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_91_92, (decimal)faceB.angle_91_92));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_92_93, (decimal)faceB.angle_92_93));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_93_94, (decimal)faceB.angle_93_94));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_94_95, (decimal)faceB.angle_94_95));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_95_96, (decimal)faceB.angle_95_96));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_96_97, (decimal)faceB.angle_96_97));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_97_98, (decimal)faceB.angle_97_98));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_98_99, (decimal)faceB.angle_98_99));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_99_100, (decimal)faceB.angle_99_100));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_100_101, (decimal)faceB.angle_100_101));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_101_102, (decimal)faceB.angle_101_102));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_102_103, (decimal)faceB.angle_102_103));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_103_104, (decimal)faceB.angle_103_104));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_104_105, (decimal)faceB.angle_104_105));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_105_106, (decimal)faceB.angle_105_106));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_106_107, (decimal)faceB.angle_106_107));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_107_108, (decimal)faceB.angle_107_108));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_108_109, (decimal)faceB.angle_108_109));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_109_110, (decimal)faceB.angle_109_110));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_110_111, (decimal)faceB.angle_110_111));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_111_112, (decimal)faceB.angle_111_112));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_112_113, (decimal)faceB.angle_112_113));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_113_114, (decimal)faceB.angle_113_114));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_114_115, (decimal)faceB.angle_114_115));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_115_116, (decimal)faceB.angle_115_116));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_116_117, (decimal)faceB.angle_116_117));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_117_118, (decimal)faceB.angle_117_118));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_118_119, (decimal)faceB.angle_118_119));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_119_120, (decimal)faceB.angle_119_120));
            matches.Add(Maths.NumericMatch((decimal)faceA.angle_120_0, (decimal)faceB.angle_120_0));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_0_1, (decimal)faceB.magRatio_0_1));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_1_2, (decimal)faceB.magRatio_1_2));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_2_3, (decimal)faceB.magRatio_2_3));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_3_4, (decimal)faceB.magRatio_3_4));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_4_5, (decimal)faceB.magRatio_4_5));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_5_6, (decimal)faceB.magRatio_5_6));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_6_7, (decimal)faceB.magRatio_6_7));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_7_8, (decimal)faceB.magRatio_7_8));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_8_9, (decimal)faceB.magRatio_8_9));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_9_10, (decimal)faceB.magRatio_9_10));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_10_11, (decimal)faceB.magRatio_10_11));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_11_12, (decimal)faceB.magRatio_11_12));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_12_13, (decimal)faceB.magRatio_12_13));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_13_14, (decimal)faceB.magRatio_13_14));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_14_15, (decimal)faceB.magRatio_14_15));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_15_16, (decimal)faceB.magRatio_15_16));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_16_17, (decimal)faceB.magRatio_16_17));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_17_18, (decimal)faceB.magRatio_17_18));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_18_19, (decimal)faceB.magRatio_18_19));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_19_20, (decimal)faceB.magRatio_19_20));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_20_21, (decimal)faceB.magRatio_20_21));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_21_22, (decimal)faceB.magRatio_21_22));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_22_23, (decimal)faceB.magRatio_22_23));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_23_24, (decimal)faceB.magRatio_23_24));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_24_25, (decimal)faceB.magRatio_24_25));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_25_26, (decimal)faceB.magRatio_25_26));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_26_27, (decimal)faceB.magRatio_26_27));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_27_28, (decimal)faceB.magRatio_27_28));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_28_29, (decimal)faceB.magRatio_28_29));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_29_30, (decimal)faceB.magRatio_29_30));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_30_31, (decimal)faceB.magRatio_30_31));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_31_32, (decimal)faceB.magRatio_31_32));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_32_33, (decimal)faceB.magRatio_32_33));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_33_34, (decimal)faceB.magRatio_33_34));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_34_35, (decimal)faceB.magRatio_34_35));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_35_36, (decimal)faceB.magRatio_35_36));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_36_37, (decimal)faceB.magRatio_36_37));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_37_38, (decimal)faceB.magRatio_37_38));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_38_39, (decimal)faceB.magRatio_38_39));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_39_40, (decimal)faceB.magRatio_39_40));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_40_41, (decimal)faceB.magRatio_40_41));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_41_42, (decimal)faceB.magRatio_41_42));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_42_43, (decimal)faceB.magRatio_42_43));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_43_44, (decimal)faceB.magRatio_43_44));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_44_45, (decimal)faceB.magRatio_44_45));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_45_46, (decimal)faceB.magRatio_45_46));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_46_47, (decimal)faceB.magRatio_46_47));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_47_48, (decimal)faceB.magRatio_47_48));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_48_49, (decimal)faceB.magRatio_48_49));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_49_50, (decimal)faceB.magRatio_49_50));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_50_51, (decimal)faceB.magRatio_50_51));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_51_52, (decimal)faceB.magRatio_51_52));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_52_53, (decimal)faceB.magRatio_52_53));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_53_54, (decimal)faceB.magRatio_53_54));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_54_55, (decimal)faceB.magRatio_54_55));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_55_56, (decimal)faceB.magRatio_55_56));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_56_57, (decimal)faceB.magRatio_56_57));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_57_58, (decimal)faceB.magRatio_57_58));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_58_59, (decimal)faceB.magRatio_58_59));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_59_60, (decimal)faceB.magRatio_59_60));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_60_61, (decimal)faceB.magRatio_60_61));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_61_62, (decimal)faceB.magRatio_61_62));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_62_63, (decimal)faceB.magRatio_62_63));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_63_64, (decimal)faceB.magRatio_63_64));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_64_65, (decimal)faceB.magRatio_64_65));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_65_66, (decimal)faceB.magRatio_65_66));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_66_67, (decimal)faceB.magRatio_66_67));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_67_68, (decimal)faceB.magRatio_67_68));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_68_69, (decimal)faceB.magRatio_68_69));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_69_70, (decimal)faceB.magRatio_69_70));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_70_71, (decimal)faceB.magRatio_70_71));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_71_72, (decimal)faceB.magRatio_71_72));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_72_73, (decimal)faceB.magRatio_72_73));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_73_74, (decimal)faceB.magRatio_73_74));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_74_75, (decimal)faceB.magRatio_74_75));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_75_76, (decimal)faceB.magRatio_75_76));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_76_77, (decimal)faceB.magRatio_76_77));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_77_78, (decimal)faceB.magRatio_77_78));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_78_79, (decimal)faceB.magRatio_78_79));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_79_80, (decimal)faceB.magRatio_79_80));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_80_81, (decimal)faceB.magRatio_80_81));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_81_82, (decimal)faceB.magRatio_81_82));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_82_83, (decimal)faceB.magRatio_82_83));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_83_84, (decimal)faceB.magRatio_83_84));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_84_85, (decimal)faceB.magRatio_84_85));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_85_86, (decimal)faceB.magRatio_85_86));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_86_87, (decimal)faceB.magRatio_86_87));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_87_88, (decimal)faceB.magRatio_87_88));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_88_89, (decimal)faceB.magRatio_88_89));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_89_90, (decimal)faceB.magRatio_89_90));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_90_91, (decimal)faceB.magRatio_90_91));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_91_92, (decimal)faceB.magRatio_91_92));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_92_93, (decimal)faceB.magRatio_92_93));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_93_94, (decimal)faceB.magRatio_93_94));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_94_95, (decimal)faceB.magRatio_94_95));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_95_96, (decimal)faceB.magRatio_95_96));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_96_97, (decimal)faceB.magRatio_96_97));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_97_98, (decimal)faceB.magRatio_97_98));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_98_99, (decimal)faceB.magRatio_98_99));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_99_100, (decimal)faceB.magRatio_99_100));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_100_101, (decimal)faceB.magRatio_100_101));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_101_102, (decimal)faceB.magRatio_101_102));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_102_103, (decimal)faceB.magRatio_102_103));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_103_104, (decimal)faceB.magRatio_103_104));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_104_105, (decimal)faceB.magRatio_104_105));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_105_106, (decimal)faceB.magRatio_105_106));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_106_107, (decimal)faceB.magRatio_106_107));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_107_108, (decimal)faceB.magRatio_107_108));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_108_109, (decimal)faceB.magRatio_108_109));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_109_110, (decimal)faceB.magRatio_109_110));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_110_111, (decimal)faceB.magRatio_110_111));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_111_112, (decimal)faceB.magRatio_111_112));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_112_113, (decimal)faceB.magRatio_112_113));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_113_114, (decimal)faceB.magRatio_113_114));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_114_115, (decimal)faceB.magRatio_114_115));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_115_116, (decimal)faceB.magRatio_115_116));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_116_117, (decimal)faceB.magRatio_116_117));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_117_118, (decimal)faceB.magRatio_117_118));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_118_119, (decimal)faceB.magRatio_118_119));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_119_120, (decimal)faceB.magRatio_119_120));
            matches.Add(Maths.NumericMatch((decimal)faceA.magRatio_120_0, (decimal)faceB.magRatio_120_0));
        }
    }
}
