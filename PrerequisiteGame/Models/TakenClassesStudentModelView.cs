using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrerequisiteGame.Models
{
    public class TakenClassesStudentModelView
    {
        public Student Student { get; set; }
        public ClassesTaken forStringValuesOfClassesTaken { get; set; }
        public IEnumerable<ClassesTaken> ClassesTaken { get; set; }

        public TakenClassesStudentModelView(Student theStudent)
        {
            Student = theStudent;
            forStringValuesOfClassesTaken = new ClassesTaken();
            ClassesTaken = new List<ClassesTaken>();
        }
    }
}