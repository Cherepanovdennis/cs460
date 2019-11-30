namespace Homework8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Athlete
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Athlete()
        {
            RACEEVENTs = new HashSet<RACEEVENT>();
        }

        public int AthleteId { get; set; }

        [Required]
        [StringLength(255)]
        public string AthleteName { get; set; }

        [Required]
        [StringLength(200)]
        public string AthleteGender { get; set; }

        public int TeamID { get; set; }

        public virtual Team Team { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RACEEVENT> RACEEVENTs { get; set; }
    }
}
