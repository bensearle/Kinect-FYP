namespace FaceTrackingBasics.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database6")
        {
        }

        public virtual DbSet<Face> Faces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Face>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_0_1_2)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_1_2_3)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_2_3_4)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_3_4_5)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_4_5_6)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_5_6_11)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_6_11_12)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_11_12_13)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_12_13_14)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_13_14_19)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_14_19_20)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_19_20_22)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_20_22_23)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_22_23_24)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_23_24_25)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_24_25_26)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_25_26_27)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_26_27_28)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_27_28_29)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_28_29_30)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_29_30_34)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_30_34_35)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_34_35_36)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_35_36_37)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_36_37_38)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_37_38_39)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_38_39_40)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_39_40_41)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_40_41_42)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_41_42_43)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_42_43_44)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_43_44_45)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_44_45_46)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_45_46_47)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_46_47_52)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_47_52_53)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_52_53_55)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_53_55_56)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_55_56_57)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_56_57_58)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_57_58_59)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_58_59_60)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_59_60_61)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_60_61_62)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_61_62_63)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_62_63_68)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_63_68_70)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_68_70_72)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_70_72_74)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_72_74_75)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_74_75_76)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_75_76_77)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_76_77_78)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_77_78_92)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_78_92_93)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_92_93_94)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_93_94_95)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_94_95_96)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_95_96_97)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_96_97_98)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_97_98_99)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_98_99_100)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_99_100_101)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_100_101_102)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_101_102_103)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_102_103_104)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_103_104_105)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_104_105_106)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_105_106_107)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_106_107_108)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_107_108_109)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_108_109_110)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_109_110_111)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_110_111_112)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_111_112_0)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_112_0_1)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_0_1_2)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_1_2_3)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_2_3_4)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_3_4_5)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_4_5_6)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_5_6_11)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_6_11_12)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_11_12_13)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_12_13_14)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_13_14_19)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_14_19_20)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_19_20_22)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_20_22_23)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_22_23_24)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_23_24_25)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_24_25_26)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_25_26_27)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_26_27_28)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_27_28_29)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_28_29_30)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_29_30_34)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_30_34_35)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_34_35_36)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_35_36_37)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_36_37_38)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_37_38_39)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_38_39_40)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_39_40_41)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_40_41_42)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_41_42_43)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_42_43_44)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_43_44_45)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_44_45_46)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_45_46_47)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_46_47_52)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_47_52_53)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_52_53_55)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_53_55_56)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_55_56_57)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_56_57_58)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_57_58_59)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_58_59_60)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_59_60_61)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_60_61_62)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_61_62_63)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_62_63_68)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_63_68_70)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_68_70_72)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_70_72_74)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_72_74_75)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_74_75_76)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_75_76_77)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_76_77_78)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_77_78_92)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_78_92_93)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_92_93_94)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_93_94_95)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_94_95_96)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_95_96_97)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_96_97_98)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_97_98_99)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_98_99_100)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_99_100_101)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_100_101_102)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_101_102_103)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_102_103_104)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_103_104_105)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_104_105_106)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_105_106_107)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_106_107_108)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_107_108_109)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_108_109_110)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_109_110_111)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_110_111_112)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_111_112_0)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_112_0_1)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.nose_angle_1)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.forehead_length_1)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.face_code)
                .HasPrecision(38, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_0_1)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_1_2)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_2_3)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_3_4)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_4_5)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_5_6)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_6_7)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_7_8)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_8_9)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_9_10)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_10_11)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_11_12)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_12_13)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_13_14)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_14_15)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_15_16)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_16_17)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_17_18)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_18_19)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_19_20)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_20_21)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_21_22)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_22_23)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_23_24)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_24_25)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_25_26)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_26_27)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_27_28)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_28_29)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_29_30)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_30_31)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_31_32)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_32_33)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_33_34)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_34_35)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_35_36)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_36_37)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_37_38)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_38_39)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_39_40)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_40_41)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_41_42)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_42_43)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_43_44)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_44_45)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_45_46)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_46_47)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_47_48)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_48_49)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_49_50)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_50_51)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_51_52)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_52_53)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_53_54)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_54_55)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_55_56)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_56_57)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_57_58)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_58_59)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_59_60)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_60_61)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_61_62)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_62_63)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_63_64)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_64_65)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_65_66)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_66_67)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_67_68)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_68_69)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_69_70)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_70_71)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_71_72)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_72_73)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_73_74)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_74_75)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_75_76)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_76_77)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_77_78)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_78_79)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_79_80)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_80_81)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_81_82)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_82_83)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_83_84)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_84_85)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_85_86)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_86_87)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_87_88)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_88_89)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_89_90)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_90_91)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_91_92)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_92_93)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_93_94)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_94_95)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_95_96)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_96_97)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_97_98)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_98_99)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_99_100)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_100_101)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_101_102)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_102_103)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_103_104)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_104_105)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_105_106)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_106_107)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_107_108)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_108_109)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_109_110)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_110_111)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_111_112)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_112_113)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_113_114)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_114_115)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_115_116)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_116_117)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_117_118)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_118_119)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_119_120)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_120_0)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_0_1)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_1_2)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_2_3)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_3_4)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_4_5)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_5_6)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_6_7)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_7_8)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_8_9)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_9_10)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_10_11)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_11_12)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_12_13)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_13_14)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_14_15)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_15_16)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_16_17)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_17_18)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_18_19)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_19_20)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_20_21)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_21_22)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_22_23)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_23_24)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_24_25)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_25_26)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_26_27)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_27_28)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_28_29)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_29_30)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_30_31)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_31_32)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_32_33)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_33_34)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_34_35)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_35_36)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_36_37)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_37_38)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_38_39)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_39_40)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_40_41)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_41_42)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_42_43)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_43_44)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_44_45)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_45_46)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_46_47)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_47_48)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_48_49)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_49_50)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_50_51)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_51_52)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_52_53)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_53_54)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_54_55)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_55_56)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_56_57)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_57_58)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_58_59)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_59_60)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_60_61)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_61_62)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_62_63)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_63_64)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_64_65)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_65_66)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_66_67)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_67_68)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_68_69)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_69_70)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_70_71)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_71_72)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_72_73)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_73_74)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_74_75)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_75_76)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_76_77)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_77_78)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_78_79)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_79_80)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_80_81)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_81_82)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_82_83)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_83_84)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_84_85)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_85_86)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_86_87)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_87_88)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_88_89)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_89_90)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_90_91)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_91_92)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_92_93)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_93_94)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_94_95)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_95_96)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_96_97)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_97_98)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_98_99)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_99_100)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_100_101)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_101_102)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_102_103)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_103_104)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_104_105)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_105_106)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_106_107)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_107_108)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_108_109)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_109_110)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_110_111)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_111_112)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_112_113)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_113_114)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_114_115)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_115_116)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_116_117)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_117_118)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_118_119)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_119_120)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_120_0)
                .HasPrecision(18, 15);
        }
    }
}
