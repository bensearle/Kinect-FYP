namespace FaceTrackingBasics
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database")
        {
        }

        public virtual DbSet<facial_data> facial_data { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<facial_data>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<facial_data>()
                .Property(e => e.nose_angle_1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<facial_data>()
                .Property(e => e.forehead_length_1)
                .HasPrecision(18, 0);
        }
    }
}
