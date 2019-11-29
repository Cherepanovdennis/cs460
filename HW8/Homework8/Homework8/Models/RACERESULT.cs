namespace Homework8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RACERESULT")]
    public partial class RACERESULT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string MeetLocation { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime MeetDate { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Team { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Coach { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventID { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AthleteID { get; set; }

        public float RaceTime { get; set; }

        public virtual Athlete Athlete { get; set; }

        public virtual Coach Coach1 { get; set; }

        public virtual RaceEvent RaceEvent { get; set; }

        public virtual Team Team1 { get; set; }
    }
}
