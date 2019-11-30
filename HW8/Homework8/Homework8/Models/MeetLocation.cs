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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MeetLocation()
        {
            RACEEVENTs = new HashSet<RACEEVENT>();
        }

        [Key]
        public int LocationID { get; set; }

        [Required]
        [StringLength(255)]
        public string NLocation { get; set; }

        [Column(TypeName = "date")]
        public DateTime MeetDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RACEEVENT> RACEEVENTs { get; set; }
    }
}
