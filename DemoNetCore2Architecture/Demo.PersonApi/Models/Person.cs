using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.PersonApi.Models
{
    public class Person
    {
        public Person() {
            Courses = new List<Course>();
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set;}
        public string Name { get; set;}
        public List<Course> Courses { get; set; }
    }
}