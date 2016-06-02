using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrerequisiteGame.Models
{
    public class Prereq
    {
        [Key]
        public int CID { get; set; } //Course Number
        public int PrereqCode { get; set; }

        public virtual ClassOffering ClassOffering { get; set; }
    }
}