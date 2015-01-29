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

        public decimal? nose_angle_1 { get; set; }

        public decimal? forehead_length_1 { get; set; }

        public decimal? face_code { get; set; }

        public decimal? angle_1 { get; set; }

        public decimal? angle_2 { get; set; }

        public decimal? angle_3 { get; set; }

        public decimal? angle_4 { get; set; }

        public decimal? angle_5 { get; set; }

        public decimal? angle_6 { get; set; }

        public decimal? angle_7 { get; set; }

        public decimal? angle_8 { get; set; }

        public decimal? angle_9 { get; set; }

        public decimal? angle_10 { get; set; }

        public decimal? length_1 { get; set; }

        public decimal? length_2 { get; set; }

        public decimal? length_3 { get; set; }

        public decimal? length_4 { get; set; }

        public decimal? length_5 { get; set; }

        public decimal? length_6 { get; set; }

        public decimal? length_7 { get; set; }

        public decimal? length_8 { get; set; }

        public decimal? length_9 { get; set; }

        public decimal? length_10 { get; set; }
    }
}
