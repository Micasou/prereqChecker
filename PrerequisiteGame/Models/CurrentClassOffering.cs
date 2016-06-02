using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrerequisiteGame.Models
{
    public class CurrentClassOffering
    {
        [Key]
        public int CurrentClassOfferingID { get; set; }

        [Required]
        [DisplayName("Class")]
        [ForeignKey("ClassOffering")]
        public int CID { get; set; } //Course Number
        public virtual ClassOffering ClassOffering { get; set; }

        public Quarter Quarter { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Year { get; set; }

        [DisplayName("Time Class is Offered")]
        public string timeOffered { get; set; }

        [DisplayName("Days Class is Offered")]
        public string daysOffered { get; set; }


       public virtual IEnumerable<StudentSchedule> StudentSchedules { get; set; }
    }
    public enum Quarter
    {
        Autumn,
        Winter,
        Spring,
        Summer
    }
}