using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Hw5.Models
{
    public class User
    {
        [Required, DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
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
