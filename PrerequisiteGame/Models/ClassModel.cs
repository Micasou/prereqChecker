using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrerequisiteGame.Models
{
    public class ClassModel
    {
        public int CID { get; set; } //Course Number
        public string CourseCode { get; set; } //Example T ACCT
        public string CourseName { get; set; } //example FInancial Accoutning II:gvwhghw
        public List<ClassModel> Prereqs { get; set; }
        public int credits { get; set; } //credit the class is worth

    }
}