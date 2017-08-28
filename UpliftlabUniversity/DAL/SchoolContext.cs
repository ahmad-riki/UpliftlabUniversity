using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using UpliftlabUniversity.Models;

namespace UpliftlabUniversity.DAL
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolContext")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Instructor>().HasOptional(p => p.OfficeAssignment).WithRequired(p => p.Instructor); //one-to-zero-or-one relationship
            modelBuilder.Entity<Course>().HasMany(c => c.Instructor).WithMany(i => i.Courses).Map(t => t.MapLeftKey("CourseID").
            MapRightKey("InstructorID").ToTable("CourseInstructor")); //many-to-many relationship between the Instructor and Course Entities
            modelBuilder.Entity<Department>().HasOptional(x => x.Administrator); //zero-or-one-to-many relationship
        }
    }
}