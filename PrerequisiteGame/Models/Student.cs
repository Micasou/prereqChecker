using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrerequisiteGame.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string email { get; set; }

        public virtual IEnumerable<StudentSchedule> StudentSchedule { get; set; }
        public virtual IEnumerable<ClassesTaken> ClassesTaken { get; set; }
    }
}