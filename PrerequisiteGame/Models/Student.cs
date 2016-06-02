using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrerequisiteGame.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailAddress]
        public string email { get; set; }

        public virtual IEnumerable<StudentSchedule> StudentSchedule { get; set; }
        public virtual IEnumerable<ClassesTaken> ClassesTaken { get; set; }
    }
}