namespace Homework8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RACEEVENT")]
    public partial class RACEEVENT
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string DISTANCE { get; set; }

        public int LOCATIONID { get; set; }

        public int ATHLETEID { get; set; }

        public float RACETIME { get; set; }

        public virtual Athlete Athlete { get; set; }

        public virtual MeetLocation MeetLocation { get; set; }
    }
}
