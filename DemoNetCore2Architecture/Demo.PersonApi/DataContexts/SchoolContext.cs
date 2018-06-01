using Demo.PersonApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.PersonApi.DataContexts
{
    public class SchoolContext: DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>().ToTable("Person");
            builder.Entity<Course>().ToTable("Course");
            builder.Entity<PersonCourse>().ToTable("PersonCourse");
            builder.Entity<PersonCourse>().HasKey(x => new { x.PersonId, x.CourseId });
        }
        public DbSet<Person> People { get; set;}
        public DbSet<Course> Courses { get; set;}
        public DbSet<PersonCourse> PersonCourses { get; set;}
    }
}