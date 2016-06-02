using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrerequisiteGame.Models
{
    public class StudentSchedule
    {
        [Key]
        public int StudentID { get; set; }
        [ForeignKey("CurrentClassOffering")]
        public int CID { get; set; }

        public virtual Student Student { get; set; }
        public virtual CurrentClassOffering CurrentClassOffering { get; set; }
    }
}