using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrerequisiteGame.Models
{
    /*
     * Model View to pass multiple things to the front end.
     */
    public class PreReqModelView
    {
        public ClassOffering ClassOffering { get; set; }
        public IEnumerable<ClassOffering> PrereqFor { get; set; }
        public IEnumerable<ClassOffering> Requires { get; set; }

        public PreReqModelView(ClassOffering theClassOffering)
        {
            PrereqFor = new List<ClassOffering>();
            Requires = new List<ClassOffering>();
            ClassOffering = theClassOffering;
        }
    }
}