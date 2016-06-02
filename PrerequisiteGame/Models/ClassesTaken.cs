using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrerequisiteGame.Models
{
    public class ClassesTaken
    {
        [Key]
        public int StudentID { get; set; }
        public int CID { get; set; }
        public decimal GPA { get; set; }

        public virtual Student Student { get; set; }
    }
}