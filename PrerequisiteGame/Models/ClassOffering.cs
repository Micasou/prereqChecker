using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrerequisiteGame.Models
{
    public class ClassOffering
    {
        [Key]
        public int CID { get; set; } //Course Number
        public string CourseCode { get; set; } //Example T ACCT
        public string CourseName { get; set; } //example FInancial Accoutning II:gvwhghw
        public string CourseDescription { get; set; }

        public List<CurrentClassOffering> CurrentClassOfferings { get; set; }
        public List<Prereq> Prereqs { get; set; }

    }
}