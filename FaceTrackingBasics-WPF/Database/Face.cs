namespace KinectTrackerAndBroadcaster.Database
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

        public decimal? face_code { get; set; }

        public decimal? angle_0_44_45 { get; set; }

        public decimal? angle_44_45_47 { get; set; }

        public decimal? angle_45_47_62 { get; set; }

        public decimal? angle_47_62_61 { get; set; }

        public decimal? angle_62_61_63 { get; set; }

        public decimal? angle_61_63_43 { get; set; }

        public decimal? angle_63_43_30 { get; set; }

        public decimal? angle_43_30_28 { get; set; }

        public decimal? angle_30_28_29 { get; set; }

        public decimal? angle_28_29_14 { get; set; }

        public decimal? angle_29_14_12 { get; set; }

        public decimal? angle_14_12_11 { get; set; }

        public decimal? angle_12_11_0 { get; set; }

        public decimal? angle_11_0_34 { get; set; }

        public decimal? angle_0_34_45 { get; set; }

        public decimal? angle_34_45_46 { get; set; }

        public decimal? angle_45_46_47 { get; set; }

        public decimal? angle_46_47_2 { get; set; }

        public decimal? angle_47_2_62 { get; set; }

        public decimal? angle_2_62_60 { get; set; }

        public decimal? angle_62_60_61 { get; set; }

        public decimal? angle_60_61_41 { get; set; }

        public decimal? angle_61_41_63 { get; set; }

        public decimal? angle_41_63_42 { get; set; }

        public decimal? angle_63_42_30 { get; set; }

        public decimal? angle_42_30_27 { get; set; }

        public decimal? angle_30_27_29 { get; set; }

        public decimal? angle_27_29_13 { get; set; }

        public decimal? angle_29_13_12 { get; set; }

        public decimal? angle_13_12_1 { get; set; }

        public decimal? angle_12_1_11 { get; set; }

        public decimal? angle_1_11_2 { get; set; }

        public decimal? angle_11_2_14 { get; set; }

        public decimal? angle_2_14_36 { get; set; }

        public decimal? angle_14_36_13 { get; set; }

        public decimal? angle_36_13_1 { get; set; }

        public decimal? angle_13_1_34 { get; set; }

        public decimal? angle_1_34_46 { get; set; }

        public decimal? angle_34_46_53 { get; set; }

        public decimal? angle_46_53_60 { get; set; }

        public decimal? angle_53_60_59 { get; set; }

        public decimal? angle_60_59_112 { get; set; }

        public decimal? angle_59_112_6 { get; set; }

        public decimal? angle_112_6_111 { get; set; }

        public decimal? angle_6_111_26 { get; set; }

        public decimal? angle_111_26_25 { get; set; }

        public decimal? angle_26_25_75 { get; set; }

        public decimal? angle_25_75_5 { get; set; }

        public decimal? angle_75_5_76 { get; set; }

        public decimal? angle_5_76_58 { get; set; }

        public decimal? angle_76_58_59 { get; set; }

        public decimal? angle_58_59_93 { get; set; }

        public decimal? angle_59_93_94 { get; set; }

        public decimal? angle_93_94_92 { get; set; }

        public decimal? angle_94_92_5 { get; set; }

        public decimal? angle_92_5_94 { get; set; }

        public decimal? angle_5_94_25 { get; set; }

        public decimal? angle_94_25_58 { get; set; }

        public decimal? angle_25_58_25 { get; set; }

        public decimal? angle_58_25_6 { get; set; }

        public decimal? angle_25_6_42 { get; set; }

        public decimal? angle_6_42_27 { get; set; }

        public decimal? angle_42_27_20 { get; set; }

        public decimal? angle_27_20_95 { get; set; }

        public decimal? angle_20_95_19 { get; set; }

        public decimal? angle_95_19_103 { get; set; }

        public decimal? angle_19_103_23 { get; set; }

        public decimal? angle_103_23_109 { get; set; }

        public decimal? angle_23_109_24 { get; set; }

        public decimal? angle_109_24_101 { get; set; }

        public decimal? angle_24_101_20 { get; set; }

        public decimal? angle_101_20_103 { get; set; }

        public decimal? angle_20_103_72 { get; set; }

        public decimal? angle_103_72_95 { get; set; }

        public decimal? angle_72_95_68 { get; set; }

        public decimal? angle_95_68_19 { get; set; }

        public decimal? angle_68_19_4 { get; set; }

        public decimal? angle_19_4_52 { get; set; }

        public decimal? angle_4_52_96 { get; set; }

        public decimal? angle_52_96_53 { get; set; }

        public decimal? angle_96_53_56 { get; set; }

        public decimal? angle_53_56_104 { get; set; }

        public decimal? angle_56_104_52 { get; set; }

        public decimal? angle_104_52_102 { get; set; }

        public decimal? angle_52_102_110 { get; set; }

        public decimal? angle_102_110_57 { get; set; }

        public decimal? angle_110_57_96 { get; set; }

        public decimal? angle_57_96_57 { get; set; }

        public decimal? angle_96_57_94 { get; set; }

        public decimal? angle_57_94_56 { get; set; }

        public decimal? angle_94_56_74 { get; set; }

        public decimal? angle_56_74_70 { get; set; }

        public decimal? angle_74_70_53 { get; set; }

        public decimal? angle_70_53_43 { get; set; }

        public decimal? angle_53_43_0 { get; set; }

        public decimal? angle_43_0_20 { get; set; }

        public decimal? angle_0_20_53 { get; set; }

        public decimal? angle_20_53_2 { get; set; }

        public decimal? angle_53_2_6 { get; set; }

        public decimal? magRatio_0_44_45 { get; set; }

        public decimal? magRatio_44_45_47 { get; set; }

        public decimal? magRatio_45_47_62 { get; set; }

        public decimal? magRatio_47_62_61 { get; set; }

        public decimal? magRatio_62_61_63 { get; set; }

        public decimal? magRatio_61_63_43 { get; set; }

        public decimal? magRatio_63_43_30 { get; set; }

        public decimal? magRatio_43_30_28 { get; set; }

        public decimal? magRatio_30_28_29 { get; set; }

        public decimal? magRatio_28_29_14 { get; set; }

        public decimal? magRatio_29_14_12 { get; set; }

        public decimal? magRatio_14_12_11 { get; set; }

        public decimal? magRatio_12_11_0 { get; set; }

        public decimal? magRatio_11_0_34 { get; set; }

        public decimal? magRatio_0_34_45 { get; set; }

        public decimal? magRatio_34_45_46 { get; set; }

        public decimal? magRatio_45_46_47 { get; set; }

        public decimal? magRatio_46_47_2 { get; set; }

        public decimal? magRatio_47_2_62 { get; set; }

        public decimal? magRatio_2_62_60 { get; set; }

        public decimal? magRatio_62_60_61 { get; set; }

        public decimal? magRatio_60_61_41 { get; set; }

        public decimal? magRatio_61_41_63 { get; set; }

        public decimal? magRatio_41_63_42 { get; set; }

        public decimal? magRatio_63_42_30 { get; set; }

        public decimal? magRatio_42_30_27 { get; set; }

        public decimal? magRatio_30_27_29 { get; set; }

        public decimal? magRatio_27_29_13 { get; set; }

        public decimal? magRatio_29_13_12 { get; set; }

        public decimal? magRatio_13_12_1 { get; set; }

        public decimal? magRatio_12_1_11 { get; set; }

        public decimal? magRatio_1_11_2 { get; set; }

        public decimal? magRatio_11_2_14 { get; set; }

        public decimal? magRatio_2_14_36 { get; set; }

        public decimal? magRatio_14_36_13 { get; set; }

        public decimal? magRatio_36_13_1 { get; set; }

        public decimal? magRatio_13_1_34 { get; set; }

        public decimal? magRatio_1_34_46 { get; set; }

        public decimal? magRatio_34_46_53 { get; set; }

        public decimal? magRatio_46_53_60 { get; set; }

        public decimal? magRatio_53_60_59 { get; set; }

        public decimal? magRatio_60_59_112 { get; set; }

        public decimal? magRatio_59_112_6 { get; set; }

        public decimal? magRatio_112_6_111 { get; set; }

        public decimal? magRatio_6_111_26 { get; set; }

        public decimal? magRatio_111_26_25 { get; set; }

        public decimal? magRatio_26_25_75 { get; set; }

        public decimal? magRatio_25_75_5 { get; set; }

        public decimal? magRatio_75_5_76 { get; set; }

        public decimal? magRatio_5_76_58 { get; set; }

        public decimal? magRatio_76_58_59 { get; set; }

        public decimal? magRatio_58_59_93 { get; set; }

        public decimal? magRatio_59_93_94 { get; set; }

        public decimal? magRatio_93_94_92 { get; set; }

        public decimal? magRatio_94_92_5 { get; set; }

        public decimal? magRatio_92_5_94 { get; set; }

        public decimal? magRatio_5_94_25 { get; set; }

        public decimal? magRatio_94_25_58 { get; set; }

        public decimal? magRatio_25_58_25 { get; set; }

        public decimal? magRatio_58_25_6 { get; set; }

        public decimal? magRatio_25_6_42 { get; set; }

        public decimal? magRatio_6_42_27 { get; set; }

        public decimal? magRatio_42_27_20 { get; set; }

        public decimal? magRatio_27_20_95 { get; set; }

        public decimal? magRatio_20_95_19 { get; set; }

        public decimal? magRatio_95_19_103 { get; set; }

        public decimal? magRatio_19_103_23 { get; set; }

        public decimal? magRatio_103_23_109 { get; set; }

        public decimal? magRatio_23_109_24 { get; set; }

        public decimal? magRatio_109_24_101 { get; set; }

        public decimal? magRatio_24_101_20 { get; set; }

        public decimal? magRatio_101_20_103 { get; set; }

        public decimal? magRatio_20_103_72 { get; set; }

        public decimal? magRatio_103_72_95 { get; set; }

        public decimal? magRatio_72_95_68 { get; set; }

        public decimal? magRatio_95_68_19 { get; set; }

        public decimal? magRatio_68_19_4 { get; set; }

        public decimal? magRatio_19_4_52 { get; set; }

        public decimal? magRatio_4_52_96 { get; set; }

        public decimal? magRatio_52_96_53 { get; set; }

        public decimal? magRatio_96_53_56 { get; set; }

        public decimal? magRatio_53_56_104 { get; set; }

        public decimal? magRatio_56_104_52 { get; set; }

        public decimal? magRatio_104_52_102 { get; set; }

        public decimal? magRatio_52_102_110 { get; set; }

        public decimal? magRatio_102_110_57 { get; set; }

        public decimal? magRatio_110_57_96 { get; set; }

        public decimal? magRatio_57_96_57 { get; set; }

        public decimal? magRatio_96_57_94 { get; set; }

        public decimal? magRatio_57_94_56 { get; set; }

        public decimal? magRatio_94_56_74 { get; set; }

        public decimal? magRatio_56_74_70 { get; set; }

        public decimal? magRatio_74_70_53 { get; set; }

        public decimal? magRatio_70_53_43 { get; set; }

        public decimal? magRatio_53_43_0 { get; set; }

        public decimal? magRatio_43_0_20 { get; set; }

        public decimal? magRatio_0_20_53 { get; set; }

        public decimal? magRatio_20_53_2 { get; set; }

        public decimal? magRatio_53_2_6 { get; set; }

        public int? version { get; set; }
    }
}
