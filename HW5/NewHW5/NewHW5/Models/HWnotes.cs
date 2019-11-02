﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NewHW5.Models
{
    public class HWnotes
    {
        [Key]
        public int ID { get; set; }
        
        [Required, DisplayName("Due Date")]
        [StringLength(64)]
        public string DueDate { get; set; }

        
        [StringLength(12)]
        [Required, DisplayName("Due Time")]
        public string DueTime { get; set; }

        [DisplayName("Homwork Title"), Required, StringLength(20)]
        public string HomeworkTitle { get; set; }

        [DisplayName("Piority"), Required]
        public string Prioity { get; set; }

        [DisplayName("Department"), Required, StringLength(3)]
        public string Department { get; set; }

        [DisplayName("Course#"), Required]
        public int CourseNumber { get; set; }




        public override string ToString()
        {
            return $"{base.ToString()}: {DueDate} {DueTime} Homework Title = {HomeworkTitle} Piority = {Prioity} Department = {Department} CourseNumber= {CourseNumber}";
        }
    }
}