namespace FaceTrackingBasics.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class facial_data
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public decimal? nose_angle_1 { get; set; }

        public decimal? forehead_length_1 { get; set; }
    }
}
