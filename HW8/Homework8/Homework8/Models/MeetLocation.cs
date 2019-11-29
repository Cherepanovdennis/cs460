namespace Homework8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MeetLocation")]
    public partial class MeetLocation
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string NLocation { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime MeetDate { get; set; }
    }
}
