using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrerequisiteGame.Models
{
    public class ClassOffering
    {
        [Key]
        public int ClassOfferingID { get; set; } //Course Number

        [Required]
        [DisplayName("Class")]
        public int CID { get; set; } //Course Number

        [DisplayName("Course Code")]
        public string CourseCode { get; set; } //Example T ACCT

        [DisplayName("Course Name")]
        public string CourseName { get; set; } //example FInancial Accoutning II:gvwhghw

        [DisplayName("Course Description")]
        public string CourseDescription { get; set; }

        public List<CurrentClassOffering> CurrentClassOfferings { get; set; }
        public List<Prereq> Prereqs { get; set; }

    }
}