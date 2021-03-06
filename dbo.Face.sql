﻿CREATE TABLE [dbo].[Face] (
    [Id]                  INT              IDENTITY (1, 1) NOT NULL,
    [name]                VARCHAR (50)     NULL,
    [face_code]           DECIMAL (38, 15) NULL,
	[version]             INT              NULL,
	[angle_1_0_34]  DECIMAL (18, 15) NULL,
[angle_11_2_44]  DECIMAL (18, 15) NULL,
[angle_13_12_1]  DECIMAL (18, 15) NULL,
[angle_34_46_45]  DECIMAL (18, 15) NULL,
[angle_2_13_1]  DECIMAL (18, 15) NULL,
[angle_2_46_1]  DECIMAL (18, 15) NULL,
[angle_34_47_2]  DECIMAL (18, 15) NULL,
[angle_34_14_2]  DECIMAL (18, 15) NULL,
[angle_29_14_2]  DECIMAL (18, 15) NULL,
[angle_62_47_2]  DECIMAL (18, 15) NULL,
[angle_14_3_2]  DECIMAL (18, 15) NULL,
[angle_46_3_2]  DECIMAL (18, 15) NULL,
[angle_60_62_2]  DECIMAL (18, 15) NULL,
[angle_27_29_3]  DECIMAL (18, 15) NULL,
[angle_23_3_56]  DECIMAL (18, 15) NULL,
[angle_20_19_23]  DECIMAL (18, 15) NULL,
[angle_20_24_23]  DECIMAL (18, 15) NULL,
[angle_103_95_72]  DECIMAL (18, 15) NULL,
[angle_103_109_68]  DECIMAL (18, 15) NULL,
[angle_95_72_103]  DECIMAL (18, 15) NULL,
[angle_103_23_109]  DECIMAL (18, 15) NULL,
[angle_95_20_103]  DECIMAL (18, 15) NULL,
[angle_56_52_53]  DECIMAL (18, 15) NULL,
[angle_56_57_53]  DECIMAL (18, 15) NULL,
[angle_104_56_110]  DECIMAL (18, 15) NULL,
[angle_96_53_102]  DECIMAL (18, 15) NULL,
[angle_74_52_70]  DECIMAL (18, 15) NULL,
[angle_104_57_96]  DECIMAL (18, 15) NULL,
[angle_23_4_56]  DECIMAL (18, 15) NULL,
[angle_92_94_93]  DECIMAL (18, 15) NULL,
[angle_26_94_59]  DECIMAL (18, 15) NULL,
[angle_75_94_76]  DECIMAL (18, 15) NULL,
[angle_26_25_76]  DECIMAL (18, 15) NULL,
[angle_76_58_59]  DECIMAL (18, 15) NULL,
[angle_25_5_58]  DECIMAL (18, 15) NULL,
[angle_27_111_4]  DECIMAL (18, 15) NULL,
[angle_60_112_4]  DECIMAL (18, 15) NULL,
[angle_28_29_27]  DECIMAL (18, 15) NULL,
[angle_60_62_61]  DECIMAL (18, 15) NULL,
[angle_26_28_30]  DECIMAL (18, 15) NULL,
[angle_59_61_63]  DECIMAL (18, 15) NULL,
[angle_30_6_63]  DECIMAL (18, 15) NULL,
[angle_30_43_63]  DECIMAL (18, 15) NULL,
[angle_43_30_42]  DECIMAL (18, 15) NULL,
[angle_43_63_42]  DECIMAL (18, 15) NULL,
[angle_6_41_30]  DECIMAL (18, 15) NULL,
[angle_43_41_63]  DECIMAL (18, 15) NULL,
[magRatio_0_43_12_45]  DECIMAL (18, 15) NULL,
[magRatio_0_43_14_47]  DECIMAL (18, 15) NULL,
[magRatio_0_43_29_62]  DECIMAL (18, 15) NULL,
[magRatio_0_43_28_61]  DECIMAL (18, 15) NULL,
[magRatio_0_43_30_63]  DECIMAL (18, 15) NULL,
[magRatio_0_2_2_43]  DECIMAL (18, 15) NULL,
[magRatio_2_4_4_43]  DECIMAL (18, 15) NULL,
[magRatio_4_6_6_43]  DECIMAL (18, 15) NULL,
[magRatio_6_42_42_43]  DECIMAL (18, 15) NULL,
[magRatio_29_62_20_53]  DECIMAL (18, 15) NULL,
[magRatio_23_56_20_53]  DECIMAL (18, 15) NULL,
[magRatio_94_5_26_59]  DECIMAL (18, 15) NULL,
[magRatio_4_6_26_59]  DECIMAL (18, 15) NULL,
[magRatio_23_56_26_59]  DECIMAL (18, 15) NULL,
[magRatio_92_93_26_59]  DECIMAL (18, 15) NULL,
[magRatio_25_58_26_59]  DECIMAL (18, 15) NULL,
[magRatio_75_76_26_59]  DECIMAL (18, 15) NULL,
[magRatio_20_23_19_24]  DECIMAL (18, 15) NULL,
[magRatio_20_23_29_4]  DECIMAL (18, 15) NULL,
[magRatio_20_23_56_53]  DECIMAL (18, 15) NULL,
[magRatio_4_62_56_53]  DECIMAL (18, 15) NULL,
[magRatio_52_57_56_53]  DECIMAL (18, 15) NULL,
[magRatio_30_63_41_43]  DECIMAL (18, 15) NULL,

    [angle_0_44_45]       DECIMAL (18, 15) NULL,
    [angle_44_45_47]      DECIMAL (18, 15) NULL,
    [angle_45_47_62]      DECIMAL (18, 15) NULL,
    [angle_47_62_61]      DECIMAL (18, 15) NULL,
    [angle_62_61_63]      DECIMAL (18, 15) NULL,
    [angle_61_63_43]      DECIMAL (18, 15) NULL,
    [angle_63_43_30]      DECIMAL (18, 15) NULL,
    [angle_43_30_28]      DECIMAL (18, 15) NULL,
    [angle_30_28_29]      DECIMAL (18, 15) NULL,
    [angle_28_29_14]      DECIMAL (18, 15) NULL,
    [angle_29_14_12]      DECIMAL (18, 15) NULL,
    [angle_14_12_11]      DECIMAL (18, 15) NULL,
    [angle_12_11_0]       DECIMAL (18, 15) NULL,
    [angle_11_0_34]       DECIMAL (18, 15) NULL,
    [angle_0_34_45]       DECIMAL (18, 15) NULL,
    [angle_34_45_46]      DECIMAL (18, 15) NULL,
    [angle_45_46_47]      DECIMAL (18, 15) NULL,
    [angle_46_47_2]       DECIMAL (18, 15) NULL,
    [angle_47_2_62]       DECIMAL (18, 15) NULL,
    [angle_2_62_60]       DECIMAL (18, 15) NULL,
    [angle_62_60_61]      DECIMAL (18, 15) NULL,
    [angle_60_61_41]      DECIMAL (18, 15) NULL,
    [angle_61_41_63]      DECIMAL (18, 15) NULL,
    [angle_41_63_42]      DECIMAL (18, 15) NULL,
    [angle_63_42_30]      DECIMAL (18, 15) NULL,
    [angle_42_30_27]      DECIMAL (18, 15) NULL,
    [angle_30_27_29]      DECIMAL (18, 15) NULL,
    [angle_27_29_13]      DECIMAL (18, 15) NULL,
    [angle_29_13_12]      DECIMAL (18, 15) NULL,
    [angle_13_12_1_b]       DECIMAL (18, 15) NULL,
    [angle_12_1_11]       DECIMAL (18, 15) NULL,
    [angle_1_11_2]        DECIMAL (18, 15) NULL,
    [angle_11_2_14]       DECIMAL (18, 15) NULL,
    [angle_2_14_36]       DECIMAL (18, 15) NULL,
    [angle_14_36_13]      DECIMAL (18, 15) NULL,
    [angle_36_13_1]       DECIMAL (18, 15) NULL,
    [angle_13_1_34]       DECIMAL (18, 15) NULL,
    [angle_1_34_46]       DECIMAL (18, 15) NULL,
    [angle_34_46_53]      DECIMAL (18, 15) NULL,
    [angle_46_53_60]      DECIMAL (18, 15) NULL,
    [angle_53_60_59]      DECIMAL (18, 15) NULL,
    [angle_60_59_112]     DECIMAL (18, 15) NULL,
    [angle_59_112_6]      DECIMAL (18, 15) NULL,
    [angle_112_6_111]     DECIMAL (18, 15) NULL,
    [angle_6_111_26]      DECIMAL (18, 15) NULL,
    [angle_111_26_25]     DECIMAL (18, 15) NULL,
    [angle_26_25_75]      DECIMAL (18, 15) NULL,
    [angle_25_75_5]       DECIMAL (18, 15) NULL,
    [angle_75_5_76]       DECIMAL (18, 15) NULL,
    [angle_5_76_58]       DECIMAL (18, 15) NULL,
    [angle_76_58_59_b]      DECIMAL (18, 15) NULL,
    [angle_58_59_93]      DECIMAL (18, 15) NULL,
    [angle_59_93_94]      DECIMAL (18, 15) NULL,
    [angle_93_94_92]      DECIMAL (18, 15) NULL,
    [angle_94_92_5]       DECIMAL (18, 15) NULL,
    [angle_92_5_94]       DECIMAL (18, 15) NULL,
    [angle_5_94_25]       DECIMAL (18, 15) NULL,
    [angle_94_25_58]      DECIMAL (18, 15) NULL,
    [angle_25_58_25]      DECIMAL (18, 15) NULL,
    [angle_58_25_6]       DECIMAL (18, 15) NULL,
    [angle_25_6_42]       DECIMAL (18, 15) NULL,
    [angle_6_42_27]       DECIMAL (18, 15) NULL,
    [angle_42_27_20]      DECIMAL (18, 15) NULL,
    [angle_27_20_95]      DECIMAL (18, 15) NULL,
    [angle_20_95_19]      DECIMAL (18, 15) NULL,
    [angle_95_19_103]     DECIMAL (18, 15) NULL,
    [angle_19_103_23]     DECIMAL (18, 15) NULL,
    [angle_103_23_109_b]    DECIMAL (18, 15) NULL,
    [angle_23_109_24]     DECIMAL (18, 15) NULL,
    [angle_109_24_101]    DECIMAL (18, 15) NULL,
    [angle_24_101_20]     DECIMAL (18, 15) NULL,
    [angle_101_20_103]    DECIMAL (18, 15) NULL,
    [angle_20_103_72]     DECIMAL (18, 15) NULL,
    [angle_103_72_95]     DECIMAL (18, 15) NULL,
    [angle_72_95_68]      DECIMAL (18, 15) NULL,
    [angle_95_68_19]      DECIMAL (18, 15) NULL,
    [angle_68_19_4]       DECIMAL (18, 15) NULL,
    [angle_19_4_52]       DECIMAL (18, 15) NULL,
    [angle_4_52_96]       DECIMAL (18, 15) NULL,
    [angle_52_96_53]      DECIMAL (18, 15) NULL,
    [angle_96_53_56]      DECIMAL (18, 15) NULL,
    [angle_53_56_104]     DECIMAL (18, 15) NULL,
    [angle_56_104_52]     DECIMAL (18, 15) NULL,
    [angle_104_52_102]    DECIMAL (18, 15) NULL,
    [angle_52_102_110]    DECIMAL (18, 15) NULL,
    [angle_102_110_57]    DECIMAL (18, 15) NULL,
    [angle_110_57_96]     DECIMAL (18, 15) NULL,
    [angle_57_96_57]      DECIMAL (18, 15) NULL,
    [angle_96_57_94]      DECIMAL (18, 15) NULL,
    [angle_57_94_56]      DECIMAL (18, 15) NULL,
    [angle_94_56_74]      DECIMAL (18, 15) NULL,
    [angle_56_74_70]      DECIMAL (18, 15) NULL,
    [angle_74_70_53]      DECIMAL (18, 15) NULL,
    [angle_70_53_43]      DECIMAL (18, 15) NULL,
    [angle_53_43_0]       DECIMAL (18, 15) NULL,
    [angle_43_0_20]       DECIMAL (18, 15) NULL,
    [angle_0_20_53]       DECIMAL (18, 15) NULL,
    [angle_20_53_2]       DECIMAL (18, 15) NULL,
    [angle_53_2_6]        DECIMAL (18, 15) NULL,
    [magRatio_0_44_45]    DECIMAL (18, 15) NULL,
    [magRatio_44_45_47]   DECIMAL (18, 15) NULL,
    [magRatio_45_47_62]   DECIMAL (18, 15) NULL,
    [magRatio_47_62_61]   DECIMAL (18, 15) NULL,
    [magRatio_62_61_63]   DECIMAL (18, 15) NULL,
    [magRatio_61_63_43]   DECIMAL (18, 15) NULL,
    [magRatio_63_43_30]   DECIMAL (18, 15) NULL,
    [magRatio_43_30_28]   DECIMAL (18, 15) NULL,
    [magRatio_30_28_29]   DECIMAL (18, 15) NULL,
    [magRatio_28_29_14]   DECIMAL (18, 15) NULL,
    [magRatio_29_14_12]   DECIMAL (18, 15) NULL,
    [magRatio_14_12_11]   DECIMAL (18, 15) NULL,
    [magRatio_12_11_0]    DECIMAL (18, 15) NULL,
    [magRatio_11_0_34]    DECIMAL (18, 15) NULL,
    [magRatio_0_34_45]    DECIMAL (18, 15) NULL,
    [magRatio_34_45_46]   DECIMAL (18, 15) NULL,
    [magRatio_45_46_47]   DECIMAL (18, 15) NULL,
    [magRatio_46_47_2]    DECIMAL (18, 15) NULL,
    [magRatio_47_2_62]    DECIMAL (18, 15) NULL,
    [magRatio_2_62_60]    DECIMAL (18, 15) NULL,
    [magRatio_62_60_61]   DECIMAL (18, 15) NULL,
    [magRatio_60_61_41]   DECIMAL (18, 15) NULL,
    [magRatio_61_41_63]   DECIMAL (18, 15) NULL,
    [magRatio_41_63_42]   DECIMAL (18, 15) NULL,
    [magRatio_63_42_30]   DECIMAL (18, 15) NULL,
    [magRatio_42_30_27]   DECIMAL (18, 15) NULL,
    [magRatio_30_27_29]   DECIMAL (18, 15) NULL,
    [magRatio_27_29_13]   DECIMAL (18, 15) NULL,
    [magRatio_29_13_12]   DECIMAL (18, 15) NULL,
    [magRatio_13_12_1]    DECIMAL (18, 15) NULL,
    [magRatio_12_1_11]    DECIMAL (18, 15) NULL,
    [magRatio_1_11_2]     DECIMAL (18, 15) NULL,
    [magRatio_11_2_14]    DECIMAL (18, 15) NULL,
    [magRatio_2_14_36]    DECIMAL (18, 15) NULL,
    [magRatio_14_36_13]   DECIMAL (18, 15) NULL,
    [magRatio_36_13_1]    DECIMAL (18, 15) NULL,
    [magRatio_13_1_34]    DECIMAL (18, 15) NULL,
    [magRatio_1_34_46]    DECIMAL (18, 15) NULL,
    [magRatio_34_46_53]   DECIMAL (18, 15) NULL,
    [magRatio_46_53_60]   DECIMAL (18, 15) NULL,
    [magRatio_53_60_59]   DECIMAL (18, 15) NULL,
    [magRatio_60_59_112]  DECIMAL (18, 15) NULL,
    [magRatio_59_112_6]   DECIMAL (18, 15) NULL,
    [magRatio_112_6_111]  DECIMAL (18, 15) NULL,
    [magRatio_6_111_26]   DECIMAL (18, 15) NULL,
    [magRatio_111_26_25]  DECIMAL (18, 15) NULL,
    [magRatio_26_25_75]   DECIMAL (18, 15) NULL,
    [magRatio_25_75_5]    DECIMAL (18, 15) NULL,
    [magRatio_75_5_76]    DECIMAL (18, 15) NULL,
    [magRatio_5_76_58]    DECIMAL (18, 15) NULL,
    [magRatio_76_58_59]   DECIMAL (18, 15) NULL,
    [magRatio_58_59_93]   DECIMAL (18, 15) NULL,
    [magRatio_59_93_94]   DECIMAL (18, 15) NULL,
    [magRatio_93_94_92]   DECIMAL (18, 15) NULL,
    [magRatio_94_92_5]    DECIMAL (18, 15) NULL,
    [magRatio_92_5_94]    DECIMAL (18, 15) NULL,
    [magRatio_5_94_25]    DECIMAL (18, 15) NULL,
    [magRatio_94_25_58]   DECIMAL (18, 15) NULL,
    [magRatio_25_58_25]   DECIMAL (18, 15) NULL,
    [magRatio_58_25_6]    DECIMAL (18, 15) NULL,
    [magRatio_25_6_42]    DECIMAL (18, 15) NULL,
    [magRatio_6_42_27]    DECIMAL (18, 15) NULL,
    [magRatio_42_27_20]   DECIMAL (18, 15) NULL,
    [magRatio_27_20_95]   DECIMAL (18, 15) NULL,
    [magRatio_20_95_19]   DECIMAL (18, 15) NULL,
    [magRatio_95_19_103]  DECIMAL (18, 15) NULL,
    [magRatio_19_103_23]  DECIMAL (18, 15) NULL,
    [magRatio_103_23_109] DECIMAL (18, 15) NULL,
    [magRatio_23_109_24]  DECIMAL (18, 15) NULL,
    [magRatio_109_24_101] DECIMAL (18, 15) NULL,
    [magRatio_24_101_20]  DECIMAL (18, 15) NULL,
    [magRatio_101_20_103] DECIMAL (18, 15) NULL,
    [magRatio_20_103_72]  DECIMAL (18, 15) NULL,
    [magRatio_103_72_95]  DECIMAL (18, 15) NULL,
    [magRatio_72_95_68]   DECIMAL (18, 15) NULL,
    [magRatio_95_68_19]   DECIMAL (18, 15) NULL,
    [magRatio_68_19_4]    DECIMAL (18, 15) NULL,
    [magRatio_19_4_52]    DECIMAL (18, 15) NULL,
    [magRatio_4_52_96]    DECIMAL (18, 15) NULL,
    [magRatio_52_96_53]   DECIMAL (18, 15) NULL,
    [magRatio_96_53_56]   DECIMAL (18, 15) NULL,
    [magRatio_53_56_104]  DECIMAL (18, 15) NULL,
    [magRatio_56_104_52]  DECIMAL (18, 15) NULL,
    [magRatio_104_52_102] DECIMAL (18, 15) NULL,
    [magRatio_52_102_110] DECIMAL (18, 15) NULL,
    [magRatio_102_110_57] DECIMAL (18, 15) NULL,
    [magRatio_110_57_96]  DECIMAL (18, 15) NULL,
    [magRatio_57_96_57]   DECIMAL (18, 15) NULL,
    [magRatio_96_57_94]   DECIMAL (18, 15) NULL,
    [magRatio_57_94_56]   DECIMAL (18, 15) NULL,
    [magRatio_94_56_74]   DECIMAL (18, 15) NULL,
    [magRatio_56_74_70]   DECIMAL (18, 15) NULL,
    [magRatio_74_70_53]   DECIMAL (18, 15) NULL,
    [magRatio_70_53_43]   DECIMAL (18, 15) NULL,
    [magRatio_53_43_0]    DECIMAL (18, 15) NULL,
    [magRatio_43_0_20]    DECIMAL (18, 15) NULL,
    [magRatio_0_20_53]    DECIMAL (18, 15) NULL,
    [magRatio_20_53_2]    DECIMAL (18, 15) NULL,
    [magRatio_53_2_6]     DECIMAL (18, 15) NULL

    CONSTRAINT [PK_facial_data] PRIMARY KEY CLUSTERED ([Id] ASC)
);

