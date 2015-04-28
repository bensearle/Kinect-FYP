namespace KinectTrackerAndBroadcaster.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database7")
        {
        }

        public virtual DbSet<Face> Faces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Face>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Face>()
                .Property(e => e.face_code)
                .HasPrecision(38, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_0_44_45)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_44_45_47)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_45_47_62)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_47_62_61)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_62_61_63)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_61_63_43)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_63_43_30)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_43_30_28)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_30_28_29)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_28_29_14)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_29_14_12)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_14_12_11)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_12_11_0)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_11_0_34)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_0_34_45)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_34_45_46)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_45_46_47)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_46_47_2)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_47_2_62)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_2_62_60)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_62_60_61)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_60_61_41)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_61_41_63)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_41_63_42)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_63_42_30)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_42_30_27)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_30_27_29)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_27_29_13)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_29_13_12)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_13_12_1)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_12_1_11)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_1_11_2)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_11_2_14)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_2_14_36)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_14_36_13)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_36_13_1)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_13_1_34)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_1_34_46)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_34_46_53)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_46_53_60)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_53_60_59)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_60_59_112)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_59_112_6)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_112_6_111)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_6_111_26)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_111_26_25)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_26_25_75)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_25_75_5)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_75_5_76)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_5_76_58)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_76_58_59)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_58_59_93)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_59_93_94)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_93_94_92)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_94_92_5)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_92_5_94)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_5_94_25)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_94_25_58)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_25_58_25)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_58_25_6)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_25_6_42)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_6_42_27)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_42_27_20)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_27_20_95)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_20_95_19)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_95_19_103)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_19_103_23)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_103_23_109)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_23_109_24)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_109_24_101)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_24_101_20)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_101_20_103)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_20_103_72)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_103_72_95)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_72_95_68)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_95_68_19)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_68_19_4)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_19_4_52)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_4_52_96)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_52_96_53)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_96_53_56)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_53_56_104)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_56_104_52)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_104_52_102)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_52_102_110)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_102_110_57)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_110_57_96)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_57_96_57)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_96_57_94)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_57_94_56)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_94_56_74)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_56_74_70)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_74_70_53)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_70_53_43)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_53_43_0)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_43_0_20)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_0_20_53)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_20_53_2)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_53_2_6)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_0_44_45)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_44_45_47)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_45_47_62)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_47_62_61)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_62_61_63)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_61_63_43)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_63_43_30)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_43_30_28)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_30_28_29)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_28_29_14)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_29_14_12)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_14_12_11)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_12_11_0)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_11_0_34)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_0_34_45)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_34_45_46)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_45_46_47)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_46_47_2)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_47_2_62)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_2_62_60)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_62_60_61)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_60_61_41)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_61_41_63)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_41_63_42)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_63_42_30)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_42_30_27)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_30_27_29)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_27_29_13)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_29_13_12)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_13_12_1)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_12_1_11)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_1_11_2)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_11_2_14)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_2_14_36)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_14_36_13)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_36_13_1)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_13_1_34)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_1_34_46)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_34_46_53)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_46_53_60)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_53_60_59)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_60_59_112)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_59_112_6)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_112_6_111)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_6_111_26)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_111_26_25)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_26_25_75)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_25_75_5)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_75_5_76)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_5_76_58)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_76_58_59)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_58_59_93)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_59_93_94)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_93_94_92)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_94_92_5)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_92_5_94)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_5_94_25)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_94_25_58)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_25_58_25)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_58_25_6)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_25_6_42)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_6_42_27)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_42_27_20)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_27_20_95)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_20_95_19)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_95_19_103)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_19_103_23)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_103_23_109)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_23_109_24)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_109_24_101)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_24_101_20)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_101_20_103)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_20_103_72)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_103_72_95)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_72_95_68)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_95_68_19)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_68_19_4)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_19_4_52)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_4_52_96)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_52_96_53)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_96_53_56)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_53_56_104)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_56_104_52)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_104_52_102)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_52_102_110)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_102_110_57)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_110_57_96)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_57_96_57)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_96_57_94)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_57_94_56)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_94_56_74)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_56_74_70)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_74_70_53)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_70_53_43)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_53_43_0)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_43_0_20)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_0_20_53)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_20_53_2)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.magRatio_53_2_6)
                .HasPrecision(18, 15);
        }
    }
}
