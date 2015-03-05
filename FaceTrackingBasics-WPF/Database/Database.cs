namespace FaceTrackingBasics.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database3")
        {
        }

        public virtual DbSet<Face> Faces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Face>()
                .Property(e => e.name)
                .IsUnicode(false);

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
                .Property(e => e.angle_1)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_2)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_3)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_4)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_5)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_6)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_7)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_8)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_9)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.angle_10)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.length_1)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.length_2)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.length_3)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.length_4)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.length_5)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.length_6)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.length_7)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.length_8)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.length_9)
                .HasPrecision(18, 15);

            modelBuilder.Entity<Face>()
                .Property(e => e.length_10)
                .HasPrecision(18, 15);
        }
    }
}
