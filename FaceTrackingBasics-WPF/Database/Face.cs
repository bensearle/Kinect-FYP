namespace FaceTrackingBasics.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Face")]
    public partial class Face
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public decimal? angle_0_1_2 { get; set; }

        public decimal? angle_1_2_3 { get; set; }

        public decimal? angle_2_3_4 { get; set; }

        public decimal? angle_3_4_5 { get; set; }

        public decimal? angle_4_5_6 { get; set; }

        public decimal? angle_5_6_11 { get; set; }

        public decimal? angle_6_11_12 { get; set; }

        public decimal? angle_11_12_13 { get; set; }

        public decimal? angle_12_13_14 { get; set; }

        public decimal? angle_13_14_19 { get; set; }

        public decimal? angle_14_19_20 { get; set; }

        public decimal? angle_19_20_22 { get; set; }

        public decimal? angle_20_22_23 { get; set; }

        public decimal? angle_22_23_24 { get; set; }

        public decimal? angle_23_24_25 { get; set; }

        public decimal? angle_24_25_26 { get; set; }

        public decimal? angle_25_26_27 { get; set; }

        public decimal? angle_26_27_28 { get; set; }

        public decimal? angle_27_28_29 { get; set; }

        public decimal? angle_28_29_30 { get; set; }

        public decimal? angle_29_30_34 { get; set; }

        public decimal? angle_30_34_35 { get; set; }

        public decimal? angle_34_35_36 { get; set; }

        public decimal? angle_35_36_37 { get; set; }

        public decimal? angle_36_37_38 { get; set; }

        public decimal? angle_37_38_39 { get; set; }

        public decimal? angle_38_39_40 { get; set; }

        public decimal? angle_39_40_41 { get; set; }

        public decimal? angle_40_41_42 { get; set; }

        public decimal? angle_41_42_43 { get; set; }

        public decimal? angle_42_43_44 { get; set; }

        public decimal? angle_43_44_45 { get; set; }

        public decimal? angle_44_45_46 { get; set; }

        public decimal? angle_45_46_47 { get; set; }

        public decimal? angle_46_47_52 { get; set; }

        public decimal? angle_47_52_53 { get; set; }

        public decimal? angle_52_53_55 { get; set; }

        public decimal? angle_53_55_56 { get; set; }

        public decimal? angle_55_56_57 { get; set; }

        public decimal? angle_56_57_58 { get; set; }

        public decimal? angle_57_58_59 { get; set; }

        public decimal? angle_58_59_60 { get; set; }

        public decimal? angle_59_60_61 { get; set; }

        public decimal? angle_60_61_62 { get; set; }

        public decimal? angle_61_62_63 { get; set; }

        public decimal? angle_62_63_68 { get; set; }

        public decimal? angle_63_68_70 { get; set; }

        public decimal? angle_68_70_72 { get; set; }

        public decimal? angle_70_72_74 { get; set; }

        public decimal? angle_72_74_75 { get; set; }

        public decimal? angle_74_75_76 { get; set; }

        public decimal? angle_75_76_77 { get; set; }

        public decimal? angle_76_77_78 { get; set; }

        public decimal? angle_77_78_92 { get; set; }

        public decimal? angle_78_92_93 { get; set; }

        public decimal? angle_92_93_94 { get; set; }

        public decimal? angle_93_94_95 { get; set; }

        public decimal? angle_94_95_96 { get; set; }

        public decimal? angle_95_96_97 { get; set; }

        public decimal? angle_96_97_98 { get; set; }

        public decimal? angle_97_98_99 { get; set; }

        public decimal? angle_98_99_100 { get; set; }

        public decimal? angle_99_100_101 { get; set; }

        public decimal? angle_100_101_102 { get; set; }

        public decimal? angle_101_102_103 { get; set; }

        public decimal? angle_102_103_104 { get; set; }

        public decimal? angle_103_104_105 { get; set; }

        public decimal? angle_104_105_106 { get; set; }

        public decimal? angle_105_106_107 { get; set; }

        public decimal? angle_106_107_108 { get; set; }

        public decimal? angle_107_108_109 { get; set; }

        public decimal? angle_108_109_110 { get; set; }

        public decimal? angle_109_110_111 { get; set; }

        public decimal? angle_110_111_112 { get; set; }

        public decimal? angle_111_112_0 { get; set; }

        public decimal? angle_112_0_1 { get; set; }

        public decimal? magRatio_0_1_2 { get; set; }

        public decimal? magRatio_1_2_3 { get; set; }

        public decimal? magRatio_2_3_4 { get; set; }

        public decimal? magRatio_3_4_5 { get; set; }

        public decimal? magRatio_4_5_6 { get; set; }

        public decimal? magRatio_5_6_11 { get; set; }

        public decimal? magRatio_6_11_12 { get; set; }

        public decimal? magRatio_11_12_13 { get; set; }

        public decimal? magRatio_12_13_14 { get; set; }

        public decimal? magRatio_13_14_19 { get; set; }

        public decimal? magRatio_14_19_20 { get; set; }

        public decimal? magRatio_19_20_22 { get; set; }

        public decimal? magRatio_20_22_23 { get; set; }

        public decimal? magRatio_22_23_24 { get; set; }

        public decimal? magRatio_23_24_25 { get; set; }

        public decimal? magRatio_24_25_26 { get; set; }

        public decimal? magRatio_25_26_27 { get; set; }

        public decimal? magRatio_26_27_28 { get; set; }

        public decimal? magRatio_27_28_29 { get; set; }

        public decimal? magRatio_28_29_30 { get; set; }

        public decimal? magRatio_29_30_34 { get; set; }

        public decimal? magRatio_30_34_35 { get; set; }

        public decimal? magRatio_34_35_36 { get; set; }

        public decimal? magRatio_35_36_37 { get; set; }

        public decimal? magRatio_36_37_38 { get; set; }

        public decimal? magRatio_37_38_39 { get; set; }

        public decimal? magRatio_38_39_40 { get; set; }

        public decimal? magRatio_39_40_41 { get; set; }

        public decimal? magRatio_40_41_42 { get; set; }

        public decimal? magRatio_41_42_43 { get; set; }

        public decimal? magRatio_42_43_44 { get; set; }

        public decimal? magRatio_43_44_45 { get; set; }

        public decimal? magRatio_44_45_46 { get; set; }

        public decimal? magRatio_45_46_47 { get; set; }

        public decimal? magRatio_46_47_52 { get; set; }

        public decimal? magRatio_47_52_53 { get; set; }

        public decimal? magRatio_52_53_55 { get; set; }

        public decimal? magRatio_53_55_56 { get; set; }

        public decimal? magRatio_55_56_57 { get; set; }

        public decimal? magRatio_56_57_58 { get; set; }

        public decimal? magRatio_57_58_59 { get; set; }

        public decimal? magRatio_58_59_60 { get; set; }

        public decimal? magRatio_59_60_61 { get; set; }

        public decimal? magRatio_60_61_62 { get; set; }

        public decimal? magRatio_61_62_63 { get; set; }

        public decimal? magRatio_62_63_68 { get; set; }

        public decimal? magRatio_63_68_70 { get; set; }

        public decimal? magRatio_68_70_72 { get; set; }

        public decimal? magRatio_70_72_74 { get; set; }

        public decimal? magRatio_72_74_75 { get; set; }

        public decimal? magRatio_74_75_76 { get; set; }

        public decimal? magRatio_75_76_77 { get; set; }

        public decimal? magRatio_76_77_78 { get; set; }

        public decimal? magRatio_77_78_92 { get; set; }

        public decimal? magRatio_78_92_93 { get; set; }

        public decimal? magRatio_92_93_94 { get; set; }

        public decimal? magRatio_93_94_95 { get; set; }

        public decimal? magRatio_94_95_96 { get; set; }

        public decimal? magRatio_95_96_97 { get; set; }

        public decimal? magRatio_96_97_98 { get; set; }

        public decimal? magRatio_97_98_99 { get; set; }

        public decimal? magRatio_98_99_100 { get; set; }

        public decimal? magRatio_99_100_101 { get; set; }

        public decimal? magRatio_100_101_102 { get; set; }

        public decimal? magRatio_101_102_103 { get; set; }

        public decimal? magRatio_102_103_104 { get; set; }

        public decimal? magRatio_103_104_105 { get; set; }

        public decimal? magRatio_104_105_106 { get; set; }

        public decimal? magRatio_105_106_107 { get; set; }

        public decimal? magRatio_106_107_108 { get; set; }

        public decimal? magRatio_107_108_109 { get; set; }

        public decimal? magRatio_108_109_110 { get; set; }

        public decimal? magRatio_109_110_111 { get; set; }

        public decimal? magRatio_110_111_112 { get; set; }

        public decimal? magRatio_111_112_0 { get; set; }

        public decimal? magRatio_112_0_1 { get; set; }

        public decimal? nose_angle_1 { get; set; }

        public decimal? forehead_length_1 { get; set; }

        public decimal? face_code { get; set; }

        public decimal? angle_0_1 { get; set; }

        public decimal? angle_1_2 { get; set; }

        public decimal? angle_2_3 { get; set; }

        public decimal? angle_3_4 { get; set; }

        public decimal? angle_4_5 { get; set; }

        public decimal? angle_5_6 { get; set; }

        public decimal? angle_6_7 { get; set; }

        public decimal? angle_7_8 { get; set; }

        public decimal? angle_8_9 { get; set; }

        public decimal? angle_9_10 { get; set; }

        public decimal? angle_10_11 { get; set; }

        public decimal? angle_11_12 { get; set; }

        public decimal? angle_12_13 { get; set; }

        public decimal? angle_13_14 { get; set; }

        public decimal? angle_14_15 { get; set; }

        public decimal? angle_15_16 { get; set; }

        public decimal? angle_16_17 { get; set; }

        public decimal? angle_17_18 { get; set; }

        public decimal? angle_18_19 { get; set; }

        public decimal? angle_19_20 { get; set; }

        public decimal? angle_20_21 { get; set; }

        public decimal? angle_21_22 { get; set; }

        public decimal? angle_22_23 { get; set; }

        public decimal? angle_23_24 { get; set; }

        public decimal? angle_24_25 { get; set; }

        public decimal? angle_25_26 { get; set; }

        public decimal? angle_26_27 { get; set; }

        public decimal? angle_27_28 { get; set; }

        public decimal? angle_28_29 { get; set; }

        public decimal? angle_29_30 { get; set; }

        public decimal? angle_30_31 { get; set; }

        public decimal? angle_31_32 { get; set; }

        public decimal? angle_32_33 { get; set; }

        public decimal? angle_33_34 { get; set; }

        public decimal? angle_34_35 { get; set; }

        public decimal? angle_35_36 { get; set; }

        public decimal? angle_36_37 { get; set; }

        public decimal? angle_37_38 { get; set; }

        public decimal? angle_38_39 { get; set; }

        public decimal? angle_39_40 { get; set; }

        public decimal? angle_40_41 { get; set; }

        public decimal? angle_41_42 { get; set; }

        public decimal? angle_42_43 { get; set; }

        public decimal? angle_43_44 { get; set; }

        public decimal? angle_44_45 { get; set; }

        public decimal? angle_45_46 { get; set; }

        public decimal? angle_46_47 { get; set; }

        public decimal? angle_47_48 { get; set; }

        public decimal? angle_48_49 { get; set; }

        public decimal? angle_49_50 { get; set; }

        public decimal? angle_50_51 { get; set; }

        public decimal? angle_51_52 { get; set; }

        public decimal? angle_52_53 { get; set; }

        public decimal? angle_53_54 { get; set; }

        public decimal? angle_54_55 { get; set; }

        public decimal? angle_55_56 { get; set; }

        public decimal? angle_56_57 { get; set; }

        public decimal? angle_57_58 { get; set; }

        public decimal? angle_58_59 { get; set; }

        public decimal? angle_59_60 { get; set; }

        public decimal? angle_60_61 { get; set; }

        public decimal? angle_61_62 { get; set; }

        public decimal? angle_62_63 { get; set; }

        public decimal? angle_63_64 { get; set; }

        public decimal? angle_64_65 { get; set; }

        public decimal? angle_65_66 { get; set; }

        public decimal? angle_66_67 { get; set; }

        public decimal? angle_67_68 { get; set; }

        public decimal? angle_68_69 { get; set; }

        public decimal? angle_69_70 { get; set; }

        public decimal? angle_70_71 { get; set; }

        public decimal? angle_71_72 { get; set; }

        public decimal? angle_72_73 { get; set; }

        public decimal? angle_73_74 { get; set; }

        public decimal? angle_74_75 { get; set; }

        public decimal? angle_75_76 { get; set; }

        public decimal? angle_76_77 { get; set; }

        public decimal? angle_77_78 { get; set; }

        public decimal? angle_78_79 { get; set; }

        public decimal? angle_79_80 { get; set; }

        public decimal? angle_80_81 { get; set; }

        public decimal? angle_81_82 { get; set; }

        public decimal? angle_82_83 { get; set; }

        public decimal? angle_83_84 { get; set; }

        public decimal? angle_84_85 { get; set; }

        public decimal? angle_85_86 { get; set; }

        public decimal? angle_86_87 { get; set; }

        public decimal? angle_87_88 { get; set; }

        public decimal? angle_88_89 { get; set; }

        public decimal? angle_89_90 { get; set; }

        public decimal? angle_90_91 { get; set; }

        public decimal? angle_91_92 { get; set; }

        public decimal? angle_92_93 { get; set; }

        public decimal? angle_93_94 { get; set; }

        public decimal? angle_94_95 { get; set; }

        public decimal? angle_95_96 { get; set; }

        public decimal? angle_96_97 { get; set; }

        public decimal? angle_97_98 { get; set; }

        public decimal? angle_98_99 { get; set; }

        public decimal? angle_99_100 { get; set; }

        public decimal? angle_100_101 { get; set; }

        public decimal? angle_101_102 { get; set; }

        public decimal? angle_102_103 { get; set; }

        public decimal? angle_103_104 { get; set; }

        public decimal? angle_104_105 { get; set; }

        public decimal? angle_105_106 { get; set; }

        public decimal? angle_106_107 { get; set; }

        public decimal? angle_107_108 { get; set; }

        public decimal? angle_108_109 { get; set; }

        public decimal? angle_109_110 { get; set; }

        public decimal? angle_110_111 { get; set; }

        public decimal? angle_111_112 { get; set; }

        public decimal? angle_112_113 { get; set; }

        public decimal? angle_113_114 { get; set; }

        public decimal? angle_114_115 { get; set; }

        public decimal? angle_115_116 { get; set; }

        public decimal? angle_116_117 { get; set; }

        public decimal? angle_117_118 { get; set; }

        public decimal? angle_118_119 { get; set; }

        public decimal? angle_119_120 { get; set; }

        public decimal? angle_120_0 { get; set; }

        public decimal? magRatio_0_1 { get; set; }

        public decimal? magRatio_1_2 { get; set; }

        public decimal? magRatio_2_3 { get; set; }

        public decimal? magRatio_3_4 { get; set; }

        public decimal? magRatio_4_5 { get; set; }

        public decimal? magRatio_5_6 { get; set; }

        public decimal? magRatio_6_7 { get; set; }

        public decimal? magRatio_7_8 { get; set; }

        public decimal? magRatio_8_9 { get; set; }

        public decimal? magRatio_9_10 { get; set; }

        public decimal? magRatio_10_11 { get; set; }

        public decimal? magRatio_11_12 { get; set; }

        public decimal? magRatio_12_13 { get; set; }

        public decimal? magRatio_13_14 { get; set; }

        public decimal? magRatio_14_15 { get; set; }

        public decimal? magRatio_15_16 { get; set; }

        public decimal? magRatio_16_17 { get; set; }

        public decimal? magRatio_17_18 { get; set; }

        public decimal? magRatio_18_19 { get; set; }

        public decimal? magRatio_19_20 { get; set; }

        public decimal? magRatio_20_21 { get; set; }

        public decimal? magRatio_21_22 { get; set; }

        public decimal? magRatio_22_23 { get; set; }

        public decimal? magRatio_23_24 { get; set; }

        public decimal? magRatio_24_25 { get; set; }

        public decimal? magRatio_25_26 { get; set; }

        public decimal? magRatio_26_27 { get; set; }

        public decimal? magRatio_27_28 { get; set; }

        public decimal? magRatio_28_29 { get; set; }

        public decimal? magRatio_29_30 { get; set; }

        public decimal? magRatio_30_31 { get; set; }

        public decimal? magRatio_31_32 { get; set; }

        public decimal? magRatio_32_33 { get; set; }

        public decimal? magRatio_33_34 { get; set; }

        public decimal? magRatio_34_35 { get; set; }

        public decimal? magRatio_35_36 { get; set; }

        public decimal? magRatio_36_37 { get; set; }

        public decimal? magRatio_37_38 { get; set; }

        public decimal? magRatio_38_39 { get; set; }

        public decimal? magRatio_39_40 { get; set; }

        public decimal? magRatio_40_41 { get; set; }

        public decimal? magRatio_41_42 { get; set; }

        public decimal? magRatio_42_43 { get; set; }

        public decimal? magRatio_43_44 { get; set; }

        public decimal? magRatio_44_45 { get; set; }

        public decimal? magRatio_45_46 { get; set; }

        public decimal? magRatio_46_47 { get; set; }

        public decimal? magRatio_47_48 { get; set; }

        public decimal? magRatio_48_49 { get; set; }

        public decimal? magRatio_49_50 { get; set; }

        public decimal? magRatio_50_51 { get; set; }

        public decimal? magRatio_51_52 { get; set; }

        public decimal? magRatio_52_53 { get; set; }

        public decimal? magRatio_53_54 { get; set; }

        public decimal? magRatio_54_55 { get; set; }

        public decimal? magRatio_55_56 { get; set; }

        public decimal? magRatio_56_57 { get; set; }

        public decimal? magRatio_57_58 { get; set; }

        public decimal? magRatio_58_59 { get; set; }

        public decimal? magRatio_59_60 { get; set; }

        public decimal? magRatio_60_61 { get; set; }

        public decimal? magRatio_61_62 { get; set; }

        public decimal? magRatio_62_63 { get; set; }

        public decimal? magRatio_63_64 { get; set; }

        public decimal? magRatio_64_65 { get; set; }

        public decimal? magRatio_65_66 { get; set; }

        public decimal? magRatio_66_67 { get; set; }

        public decimal? magRatio_67_68 { get; set; }

        public decimal? magRatio_68_69 { get; set; }

        public decimal? magRatio_69_70 { get; set; }

        public decimal? magRatio_70_71 { get; set; }

        public decimal? magRatio_71_72 { get; set; }

        public decimal? magRatio_72_73 { get; set; }

        public decimal? magRatio_73_74 { get; set; }

        public decimal? magRatio_74_75 { get; set; }

        public decimal? magRatio_75_76 { get; set; }

        public decimal? magRatio_76_77 { get; set; }

        public decimal? magRatio_77_78 { get; set; }

        public decimal? magRatio_78_79 { get; set; }

        public decimal? magRatio_79_80 { get; set; }

        public decimal? magRatio_80_81 { get; set; }

        public decimal? magRatio_81_82 { get; set; }

        public decimal? magRatio_82_83 { get; set; }

        public decimal? magRatio_83_84 { get; set; }

        public decimal? magRatio_84_85 { get; set; }

        public decimal? magRatio_85_86 { get; set; }

        public decimal? magRatio_86_87 { get; set; }

        public decimal? magRatio_87_88 { get; set; }

        public decimal? magRatio_88_89 { get; set; }

        public decimal? magRatio_89_90 { get; set; }

        public decimal? magRatio_90_91 { get; set; }

        public decimal? magRatio_91_92 { get; set; }

        public decimal? magRatio_92_93 { get; set; }

        public decimal? magRatio_93_94 { get; set; }

        public decimal? magRatio_94_95 { get; set; }

        public decimal? magRatio_95_96 { get; set; }

        public decimal? magRatio_96_97 { get; set; }

        public decimal? magRatio_97_98 { get; set; }

        public decimal? magRatio_98_99 { get; set; }

        public decimal? magRatio_99_100 { get; set; }

        public decimal? magRatio_100_101 { get; set; }

        public decimal? magRatio_101_102 { get; set; }

        public decimal? magRatio_102_103 { get; set; }

        public decimal? magRatio_103_104 { get; set; }

        public decimal? magRatio_104_105 { get; set; }

        public decimal? magRatio_105_106 { get; set; }

        public decimal? magRatio_106_107 { get; set; }

        public decimal? magRatio_107_108 { get; set; }

        public decimal? magRatio_108_109 { get; set; }

        public decimal? magRatio_109_110 { get; set; }

        public decimal? magRatio_110_111 { get; set; }

        public decimal? magRatio_111_112 { get; set; }

        public decimal? magRatio_112_113 { get; set; }

        public decimal? magRatio_113_114 { get; set; }

        public decimal? magRatio_114_115 { get; set; }

        public decimal? magRatio_115_116 { get; set; }

        public decimal? magRatio_116_117 { get; set; }

        public decimal? magRatio_117_118 { get; set; }

        public decimal? magRatio_118_119 { get; set; }

        public decimal? magRatio_119_120 { get; set; }

        public decimal? magRatio_120_0 { get; set; }
    }
}
