using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PrerequisiteGame.Models
{
    public class ClassContext : DbContext
    {
        public ClassContext() : base("ClassContext")
        {

        }
        //estbalishing the entities we are going to be storing in the database!
        public DbSet<ClassOffering> ClassOfferings { get; set; }
        public DbSet<Prereq> Prereqs { get; set; }
        public DbSet<CurrentClassOffering> CurrentClassOfferings { get; set; }
        public DbSet<StudentSchedule> StudentSchedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassesTaken> ClassesTakens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //model creation naming convetions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}