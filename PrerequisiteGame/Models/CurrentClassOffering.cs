using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrerequisiteGame.Models
{
    public class CurrentClassOffering
    {
        [Key]
        public int CID { get; set; } //Course Number
        public int Quarter { get; set; }
        public int Year { get; set; }
        public string timeOffered { get; set; }

        public virtual ClassOffering ClassOffering { get; set; }

       public virtual IEnumerable<StudentSchedule> StudentSchedulles { get; set; }
    }
}