using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NewHW5.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        
        [Required, DisplayName("First Name")]
        [StringLength(64)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth"), Required]
        public DateTime DOB { get; set; }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DOB.Year;
                if (DOB > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} DOB = {DOB} Age = {Age}";
        }
    }
}