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
        }
        public DbSet<Person> People { get; set;}
        public DbSet<Course> Course { get; set;}
    }
}