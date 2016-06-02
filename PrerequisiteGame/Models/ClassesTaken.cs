using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrerequisiteGame.Models
{
    public class ClassesTaken
    {
        [Key]
        public int ClassesTakenID { get; set; }

        [Required]
        [DisplayName("Student")]
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        [Required]
        [DisplayName("Class")]
        [ForeignKey("CurrentClassOffering")]
        public int CID { get; set; }
        public virtual CurrentClassOffering CurrentClassOffering { get; set; }

        [Required]
        [Range(typeof(decimal), "0.0","4.0")]
        public decimal GPA { get; set; }

      
    }
}